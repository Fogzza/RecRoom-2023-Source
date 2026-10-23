using System;
using System.Collections.Generic;
using AGUI;
using AGUI.StackedUI;
using UnityEngine;
using UnityEngine.Events;

public class BackpackToolButtonPagedGrid : RecyclerPagedGrid<BKMDFCCNPGE, BackpackToolButton>
{
	[Serializable]
	public class BackpackToolSelectedEvent : UnityEvent<bool, BKMDFCCNPGE>
	{
	}

	private sealed class HLBOEJEPAKO
	{
		public BackpackToolButtonPagedGrid _003C_003E4__this;

		public BackpackToolButton button;

		internal void _003CSetupNewChild_003Eb__0(bool isOn)
		{
		}

		internal void _003CSetupNewChild_003Eb__1(bool isOn)
		{
		}
	}

	[SerializeField]
	private StackedUIFlowBase uiFlowBase;

	public BackpackToolSelectedEvent OnBackpackToolFavoritedEvent;

	public BackpackToolSelectedEvent OnBackpackToolUseEvent;

	private void Start()
	{
	}

	protected override void LKIICDHGCMD(BackpackToolButton HHDMPJJAPJJ)
	{
	}

	private void OnDestroy()
	{
	}

	public void SetBackpackTools(IEnumerable<BKMDFCCNPGE> BFAKBIJCJAF)
	{
	}

	protected override void ANLHNIJPJEC(BKMDFCCNPGE CKEPLIBLBFJ, BackpackToolButton HHDMPJJAPJJ, int GNGEFBBFBLF)
	{
	}

	private void EHNODPAMMCF(Tool IEGMBEPJMGC, BKMDFCCNPGE CKEPLIBLBFJ, bool EPDJDCDHLMP, bool OENLCMEDCNI)
	{
	}

	private void BNDKMFGINLD(BKMDFCCNPGE KHOLBJMCNCH)
	{
	}
}
