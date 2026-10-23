using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressionManager : SingletonMonoBehaviour<ProgressionManager>
{
	[Serializable]
	public class ObjectiveTypeDescription
	{
		public string Name;

		public PNLFAAAPEID ObjectiveType;

		public string Description;

		public string ToolTip;

		public float NotificationDelay;

		public string BAHCBPJJNBJ(int HJKMBFELIDI)
		{
			return null;
		}
	}

	[Serializable]
	public class RangeBucket
	{
		public string Name;

		public float Multiplier;

		public int Max;
	}

	private sealed class ABCANEIALCM : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public ProgressionManager _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public ABCANEIALCM(int _003C_003E1__state)
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
		private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
		{
			return null;
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private Dictionary<PNLFAAAPEID, int> HFDAOEFKOAH;

	[SerializeField]
	private RecRoomAudioClip becomeMemberToUseThisClip;

	[SerializeField]
	private ObjectiveTypeDescription[] objectiveTypeDescriptions;

	private Dictionary<PNLFAAAPEID, ObjectiveTypeDescription> KCABJPJIHCF;

	[SerializeField]
	private List<PNLFAAAPEID> majorObjectiveTypes;

	private List<PNLFAAAPEID> JHHIDBEMGFC;

	[Obsolete]
	private List<LKKOPNLCJBC.MHEJMGIDMNM> MLJNCHOHPIK;

	private bool JEDPCLEHGDN;

public RecRoomAudioClip BecomeMemberToUseThisClip
{
get 	{
		return null;
	}

}

public float LocalXPProgression
{
get 	{
		return 0f;
	}

}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void LJJJEOKIIGJ()
	{
	}

	public void Initialize()
	{
	}

	private void NFMCAIEMJPL()
	{
	}

	private IEnumerator<EGGPGCCKPCO> DFKPAMILKAO()
	{
		return null;
	}

	private void EOAHDDBACMP(Scene PBLCKBNCAFM, Scene FFDKLDFJBMF)
	{
	}

	public void LocalCompleteObjective(PNLFAAAPEID NIFOGEBEDNG, float HIJDKOAMHHM, long? EPOBIFCHLNM)
	{
	}

	private void DNECCBCNILA(PNLFAAAPEID NIFOGEBEDNG, float HIJDKOAMHHM, long? EPOBIFCHLNM)
	{
	}

	public void RequestObjectiveCompletionRecordFlush()
	{
	}

	private void IJBKKDKCDBK()
	{
	}

	public ObjectiveTypeDescription GetObjectiveDescription(PNLFAAAPEID AEIMECBNBPE)
	{
		return null;
	}

	private void DDAKACMDHFO(List<PlayerObjectiveTracker.HLEKPIKPAMK> LFJHCMNADEH)
	{
	}

	[CompilerGenerated]
	private void KDCFCJKEGDK(float GADDGJANIGG)
	{
	}
}
