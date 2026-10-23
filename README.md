# SolarNet source

This private repository holds a reviewed, code-only snapshot of the recovered RR23 project. Files keep their project-relative paths, including `Assets`, `CompilerSupport`, `ProjectSettings`, and package manifests. Required SDK and compiler support and the original metadata for retained files and folders are included when listed in the publication manifest.

Original game scenes, art, audio, and StreamingAssets are excluded. This is not a complete playable Unity project or a claim that a full recovered game build passes. Binary SDK dependencies may remain in the approved support scope. Recovery validation and a small Windows build do not establish full-game import, rendering, or gameplay correctness.

Tested source changes are published here first. A matching, human-written development note is then committed to the public `Fogzza/SolarNet-updates` repository. The public repository contains documentation only; source, diffs, credentials, and local paths stay private. Discord notifications are configured on that public repository in GitHub, not in these files.

## Local publisher

The publisher uses Git and its configured Git Credential Manager. It never prints credentials, contacts Discord, force-pushes, or copies an unlisted project file. Preview is the default. Publishing requires an explicit title, a public note file, a truthful private test summary, and `--publish`.

Create the ignored `.publisher.local.json` locally:

```json
{
  "project_root": "<local RR23 directory>",
  "updates_root": "../SolarNet-updates",
  "manifest": "<fresh reviewed manifest.json>",
  "manifest_sha256": "<manifest SHA-256>",
  "reviewed_manifest_sha256": "<same SHA after source and credential review>",
  "recovery_manifest": "<fresh reviewed recovery-tool manifest.json>",
  "recovery_manifest_sha256": "<recovery manifest SHA-256>",
  "reviewed_recovery_manifest_sha256": "<same SHA after recovery-tool review>"
}
```

Refresh the reviewed `reviewed-Unity-code-only-publication-inputs/v1` manifest before each publication. Review its redacted credential scan and resolve actual secrets before setting the reviewed hash. The manifest is the entire allowed project-file scope; matching file and parent-folder metadata must already be enumerated in it.

The separate `reviewed-recovery-source-publication-inputs/v1` manifest manages the approved Python/C# tools under `tools/recovery`. Its exact source paths and hashes are checked independently. Both snapshot JSON files are kept private. Existing snapshots must be refreshed to match a changed manifest before publication. All paths in the ignored config are relative to that config file unless absolute. Once recovery tools are owned, omitting their manifest is refused.

After an initial manual source upload, record its ownership state with `python tools/publish_tested_source.py --initialize`. This only verifies the local snapshot and writes an ignored state file; it does not commit or push.

For later tested changes:

```text
python tools/publish_tested_source.py --title "A factual development update" --note-file .publisher-notes.md --test-summary "The checks actually run and their results"
python tools/publish_tested_source.py --publish --title "A factual development update" --note-file .publisher-notes.md --test-summary "The checks actually run and their results"
```

The publisher copies only manifest files, checkpoints a private commit, pushes private source, then appends the supplied note to the public changelog and pushes its commit. Public README and other setup documentation are preserved. An interrupted publication remains in the ignored pending ledger. Use the same arguments with `--publish --resume`; it confirms the private push before making the public update and does not duplicate a recorded commit. A conflicting local or remote change stops the operation for review.

The public repository allows only `README.md`, `CHANGELOG.md`, `.gitignore`, and `.gitattributes`. Notes must be plain, accurate prose. Never describe a failed or memory-limited import as a successful full build.
