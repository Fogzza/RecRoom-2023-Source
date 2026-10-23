using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JobQueueManager : SingletonMonoBehaviour<JobQueueManager>
{
	public enum MPDNGOEPNCG
	{
		Default = 0,
		TextMeshGeneration = 1,
		RoomCommentViewCreation = 2
	}

	[Serializable]
	private class GroupConfig
	{
		public MPDNGOEPNCG Id;

		public float TimesliceMs;
	}

	private struct EOCLPIEDBNP
	{
		public string GHIEHEOOCPN;

		public Action HGAFPNEKDEE;
	}

	private sealed class HBHJKIHHDCO
	{
		public string jobId;

		internal bool _003CEnqueueJob_003Eb__0(EOCLPIEDBNP x)
		{
			return false;
		}
	}

	private sealed class HCOEMJOCNCH
	{
		public string jobId;

		internal bool _003CCancelJob_003Eb__0(EOCLPIEDBNP x)
		{
			return false;
		}
	}

	private sealed class DKBBIKGOHON
	{
		public MPDNGOEPNCG id;

		internal bool _003CFindGroupConfig_003Eb__0(GroupConfig x)
		{
			return false;
		}
	}

	[SerializeField]
	private GroupConfig[] groups;

	private static double JHAAPJHFJLA;

	private GroupConfig AHAOPKBLCHI;

	private readonly Stopwatch GOAIDLOKKIC;

	private readonly Dictionary<MPDNGOEPNCG, List<EOCLPIEDBNP>> PKEHNDKPFKB;

	protected override void Awake()
	{
	}

	public void EnqueueJob(string GPCMKNOBHNA, bool IAOAMPLCPDM, Action NHPNCIAFHDG)
	{
	}

	public void EnqueueJob(string GPCMKNOBHNA, MPDNGOEPNCG FGGACMEPNJK, bool IAOAMPLCPDM, Action NHPNCIAFHDG)
	{
	}

	public void CancelJob(string GPCMKNOBHNA, MPDNGOEPNCG HFBCDNJHGBI = MPDNGOEPNCG.Default)
	{
	}

	private GroupConfig HPLHNNFDAMK(MPDNGOEPNCG IKHNIJKGJFD)
	{
		return null;
	}

	private void Update()
	{
	}
}
