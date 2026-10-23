"""Assign an owned Windows child to its configured job before its first instruction.

Uses documented Win32 APIs only. The caller owns the job and its memory/time
policy. No Editor, compiler, or other command is selected by this module.
"""
from __future__ import annotations

import ctypes
import os
import subprocess
import time
from ctypes import wintypes

CREATE_SUSPENDED = 0x00000004  # Documented Win32 flag; subprocess does not export it.


class SuspendedLaunchError(RuntimeError):
    def __init__(self, message, evidence):
        super().__init__(message)
        self.evidence = evidence


class ThreadEntry(ctypes.Structure):
    _fields_ = [
        ("dwSize", wintypes.DWORD), ("cntUsage", wintypes.DWORD),
        ("th32ThreadID", wintypes.DWORD), ("th32OwnerProcessID", wintypes.DWORD),
        ("tpBasePri", wintypes.LONG), ("tpDeltaPri", wintypes.LONG),
        ("dwFlags", wintypes.DWORD),
    ]


def _kernel_api():
    kernel = ctypes.WinDLL("kernel32", use_last_error=True)
    kernel.CreateToolhelp32Snapshot.argtypes = [wintypes.DWORD, wintypes.DWORD]
    kernel.CreateToolhelp32Snapshot.restype = wintypes.HANDLE
    for name in ("Thread32First", "Thread32Next"):
        api = getattr(kernel, name)
        api.argtypes = [wintypes.HANDLE, ctypes.POINTER(ThreadEntry)]
        api.restype = wintypes.BOOL
    kernel.OpenThread.argtypes = [wintypes.DWORD, wintypes.BOOL, wintypes.DWORD]
    kernel.OpenThread.restype = wintypes.HANDLE
    kernel.GetProcessIdOfThread.argtypes = [wintypes.HANDLE]
    kernel.GetProcessIdOfThread.restype = wintypes.DWORD
    kernel.ResumeThread.argtypes = [wintypes.HANDLE]
    kernel.ResumeThread.restype = wintypes.DWORD
    kernel.IsProcessInJob.argtypes = [wintypes.HANDLE, wintypes.HANDLE, ctypes.POINTER(wintypes.BOOL)]
    kernel.IsProcessInJob.restype = wintypes.BOOL
    kernel.CloseHandle.argtypes = [wintypes.HANDLE]
    kernel.CloseHandle.restype = wintypes.BOOL
    return kernel


def _only_thread(kernel, pid):
    # TH32CS_SNAPTHREAD snapshots every process, so filter the owned PID exactly.
    snapshot = kernel.CreateToolhelp32Snapshot(0x4, 0)
    if snapshot == ctypes.c_void_p(-1).value:
        raise ctypes.WinError(ctypes.get_last_error())
    try:
        entry = ThreadEntry()
        entry.dwSize = ctypes.sizeof(entry)
        found = []
        present = kernel.Thread32First(snapshot, ctypes.byref(entry))
        while present:
            if entry.dwSize < ThreadEntry.th32OwnerProcessID.offset + ctypes.sizeof(wintypes.DWORD):
                raise RuntimeError("Toolhelp returned an incomplete thread record")
            if entry.th32OwnerProcessID == pid:
                found.append(int(entry.th32ThreadID))
            entry.dwSize = ctypes.sizeof(entry)
            present = kernel.Thread32Next(snapshot, ctypes.byref(entry))
        if ctypes.get_last_error() != 18:  # ERROR_NO_MORE_FILES is successful end.
            raise ctypes.WinError(ctypes.get_last_error())
        if len(found) != 1:
            raise RuntimeError("Expected exactly one suspended primary thread, found " + str(found))
        return found[0]
    finally:
        kernel.CloseHandle(snapshot)


def launch_suspended_in_job(command, *, job, cwd=None, stdout=None, stderr=None, env=None):
    """Return (Popen, evidence), or terminate/wait only this child on failure.

    ``job`` must expose an existing non-NULL ``handle`` and ``attach(Popen)``.
    The launcher does not close the caller's job. Popen closes its initial
    thread handle, so Toolhelp32 locates the sole still-suspended primary thread.
    """
    if os.name != "nt":
        raise RuntimeError("Windows is required")
    if not job.handle:
        raise RuntimeError("An existing configured owned job is required")
    kernel = _kernel_api()
    child = None
    thread = None
    started = time.monotonic()
    evidence = {"schema": "owned-assign-before-resume/v1", "resumed": False,
                "creation_flags": CREATE_SUSPENDED | subprocess.CREATE_NO_WINDOW,
                "events": []}
    try:
        child = subprocess.Popen(command, cwd=cwd, stdout=stdout, stderr=stderr, env=env,
                                 shell=False, creationflags=evidence["creation_flags"])
        evidence["owned_pid"] = child.pid
        evidence["events"].append("created_suspended")
        job.attach(child)
        evidence["events"].append("assigned_to_owned_job_while_suspended")
        tid = _only_thread(kernel, child.pid)
        evidence["primary_thread_id"] = tid
        # THREAD_QUERY_LIMITED_INFORMATION also proves the opened thread still
        # belongs to the owned PID, excluding a stale snapshot/TID reuse.
        thread = kernel.OpenThread(0x0002 | 0x0800, False, tid)
        if not thread:
            raise ctypes.WinError(ctypes.get_last_error())
        owner_pid = kernel.GetProcessIdOfThread(thread)
        if not owner_pid:
            raise ctypes.WinError(ctypes.get_last_error())
        if owner_pid != child.pid:
            raise RuntimeError("Opened primary thread does not belong to the owned child")
        evidence["opened_thread_owner_pid"] = int(owner_pid)
        if child.poll() is not None:
            raise RuntimeError("Owned child exited before resume")
        member = wintypes.BOOL()
        if not kernel.IsProcessInJob(int(child._handle), job.handle, ctypes.byref(member)):
            raise ctypes.WinError(ctypes.get_last_error())
        if not member.value:
            raise RuntimeError("Owned child is not in the exact configured job")
        evidence["membership_verified_before_resume"] = True
        evidence["events"].append("exact_job_membership_verified_before_resume")
        previous = kernel.ResumeThread(thread)
        evidence["resume_previous_suspend_count"] = int(previous)
        if previous == 0xFFFFFFFF:
            raise ctypes.WinError(ctypes.get_last_error())
        if previous != 1:
            raise RuntimeError("Unexpected primary thread suspend count: " + str(previous))
        evidence["resumed"] = True
        evidence["events"].append("primary_thread_resumed")
        return child, evidence
    except BaseException as error:
        evidence["error"] = repr(error)
        if child is not None:
            evidence["cleanup_owned_pid"] = child.pid
            evidence["cleanup_before_resume"] = "resume_previous_suspend_count" not in evidence
            try:
                if child.poll() is None:
                    try:
                        child.terminate()  # Exact owned handle, never a PID/name sweep.
                        evidence["owned_child_terminate_requested"] = True
                    except OSError as terminate_error:
                        # Assignment may itself have killed the child, or it may
                        # have exited between poll and termination. Still wait.
                        evidence["terminate_error"] = repr(terminate_error)
                evidence["cleanup_exit_code"] = child.wait(timeout=10)
                evidence["owned_child_exit_confirmed"] = True
            except BaseException as cleanup_error:
                evidence["cleanup_error"] = repr(cleanup_error)
                evidence["owned_child_exit_confirmed"] = False
        raise SuspendedLaunchError(str(error), evidence) from error
    finally:
        if thread:
            evidence["primary_thread_handle_closed"] = bool(kernel.CloseHandle(thread))
        evidence["seconds"] = round(time.monotonic() - started, 4)
