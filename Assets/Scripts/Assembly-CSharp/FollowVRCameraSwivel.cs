using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FollowVRCameraSwivel : MonoBehaviour
{
	private sealed class LACPMMAECOK : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public FollowVRCameraSwivel _003C_003E4__this;

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
		public LACPMMAECOK(int _003C_003E1__state)
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

	[SerializeField]
	private float minDistanceFromTarget;

	[SerializeField]
	private float maxDistanceFromHead;

	[SerializeField]
	private float deadZoneAngleHard;

	[SerializeField]
	private float deadZoneAngleSoft;

	[SerializeField]
	private float distanceLerpSpeed;

	[SerializeField]
	private float swivelSpeed;

	[SerializeField]
	private bool lockYPos;

	[SerializeField]
	private bool orientTowardsCamera;

	private LKDMDLACMHN GABEPNJCMKJ;

	private PCKEFGFAJNM ICADHFCFCHK;

	private float DCCOFFGCGMM;

	private CPBPJLLMKDB LIPCPJMCHDF;

	private LHHINNFLJMD KFFFJMKEKMO;

	private Vector3 HEHLJIOCEAC;

	private Vector3 HHFANDNLLID;

	private LKGILLBEJEK PMGDFJFEABG;

public LKDMDLACMHN Scheduler
{
get 	{
		return null;
	}

set {
	}
}

public PCKEFGFAJNM ScheduleFactory
{
get 	{
		return null;
	}

set {
	}
}

	private void Start()
	{
	}

	public void Init()
	{
	}

	private void OnDestroy()
	{
	}

	private void HBOGBIEPFMM()
	{
	}

	private IEnumerator<EGGPGCCKPCO> HPDMHOEPPNE()
	{
		return null;
	}
}
