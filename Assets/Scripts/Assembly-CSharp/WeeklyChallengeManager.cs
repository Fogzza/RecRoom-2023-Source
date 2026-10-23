using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WeeklyChallengeManager : SingletonMonoBehaviour<WeeklyChallengeManager>
{
	public enum MFDOPFBFDIG
	{
		Enabled = 0,
		Disabled_IsUGCRoom = 1
	}

	private sealed class NLOJIACHJCP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WeeklyChallengeManager _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public NLOJIACHJCP(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private sealed class NPIIBPPCNJN : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WeeklyChallengeManager _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public NPIIBPPCNJN(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private sealed class AFHBPDJGJBC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WeeklyChallengeManager _003C_003E4__this;

		public CKLCFFGDCLA challenge;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public AFHBPDJGJBC(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public const string LAST_SEEN_CHALLENGE_MAP_ID = "Recroom.ChallengeMap";

	public const int MIN_REQUIRED = 3;

	private HPKPMHODMPG GAMIKAAGAMC;

	private BHNJIBDJFAL NJPJBDDAEFH;

	private Action MJCOHEIEFHO__BackingField;

	private NLGDEBPNCIN DNNBMPIHGJO;

	private DateTime? NHPPAALLIOO;

	private TimeSpan? ELENOEEOKEM;

	[SerializeField]
	private string challengeNotificationStringFormat;

	private Coroutine AEPBEKPIALJ;

	private float EPHBMGBMLEH;

	private Dictionary<int, Coroutine> GNNIBGALOCB;

	private Dictionary<int, Coroutine> AJIKCPEJGKF;

	private Action LBFBNJLDNEI__BackingField;

	private Coroutine AGDHFHAKJJJ;

public HPKPMHODMPG ChallengeEventBus
{
get 	{
		return null;
	}

private set {
	}
}

public bool CompletedRequired
{
get 	{
		return false;
	}

}

public MFDOPFBFDIG WeeklyChallengesState
{
get 	{
		return MFDOPFBFDIG.Enabled;
	}

}

public bool HasSeenThisWeeksChallenges
{
get 	{
		return false;
	}

}

public bool IsWeeklyChallengeActive
{
get 	{
		return false;
	}

}

public NLGDEBPNCIN ChallengeMap
{
get 	{
		return null;
	}

private set {
	}
}

public DateTime? EndAtUTC
{
get 	{
		return null;
	}

set {
	}
}

public TimeSpan? TimeDiff
{
get 	{
		return null;
	}

set {
	}
}

public float SecondsUntilNewChallenges
{
get 	{
		return 0f;
	}

private set {
	}
}

public event Action ChallengeEnabledStateChanged {
add {
	}
remove {
	}
}

public event Action OnWeeklyChallengeUpdated {
add {
	}
remove {
	}
}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void Initialize()
	{
	}

	private IEnumerator ONNNFAIAMKM()
	{
		return null;
	}

	private void CHLOGBIAJBN()
	{
	}

	private IEnumerator LODBNEAPKLP()
	{
		return null;
	}

	private void JOMAPIHICGI()
	{
	}

	private void DEALFHBFFPO(List<CKLCFFGDCLA> LEJIDHMAFPK)
	{
	}

	private void JMGKNLKKBGM(List<CKLCFFGDCLA> LEJIDHMAFPK, bool DCJIKOGMHEG)
	{
	}

	private void MPHDHGKKKJB(CKLCFFGDCLA ANABCFJHOFA)
	{
	}

	private void HAFAGCGEHCM(CKLCFFGDCLA ANABCFJHOFA, int BFFJHKFEFPP, int FIABAMNGCHP)
	{
	}

	private IEnumerator LOKPNPFDIJG(CKLCFFGDCLA ANABCFJHOFA)
	{
		return null;
	}

	private void DGLDAHAGBII(CKLCFFGDCLA ANABCFJHOFA)
	{
	}

	private void IPKFOBGICLH(CKLCFFGDCLA ANABCFJHOFA)
	{
	}

	private void AAIIAAOAECE(CKLCFFGDCLA ANABCFJHOFA)
	{
	}

	private void PKDNBMFNHAP(CKLCFFGDCLA ANABCFJHOFA)
	{
	}

	public void UpdateLastSeenChallengeMapId()
	{
	}

	public void CustomGameSettingsChanged()
	{
	}

	public void SandboxStatusChanged()
	{
	}

	[CompilerGenerated]
	private void NDDKNALKPCH(NLGDEBPNCIN MLDANHIGANI)
	{
	}

	[CompilerGenerated]
	private void LJDEDEIFLIH(string NLJOHEKGNDH)
	{
	}

	[CompilerGenerated]
	private void CNNJAALKNKO()
	{
	}
}
