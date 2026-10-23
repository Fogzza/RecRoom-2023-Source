using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using RecRoom;
using RecRoom.Core;
using UnityEngine;

public class PlayerTrackingSpace : MonoBehaviourPun
{
	public enum MHFKOLOAGLE
	{
		Default = 0,
		AvatarSkeleton = 1,
		SelfScale = 2
	}

	private sealed class DHLBBEDMIJI : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public float simulationDuraion;

		public PlayerTrackingSpace _003C_003E4__this;

		public Vector3 impulseDirection;

		public float impulseSpeed;

		public float maxSpeed;

		private float _003CendTime_003E5__2;

		private Vector3 _003CsimVelocity_003E5__3;

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
		public DHLBBEDMIJI(int _003C_003E1__state)
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

	private static PlayerTrackingSpace DEEBGMJNFKO;

	[SerializeField]
	private NetworkTransform _networkTransform;

	[SerializeField]
	private RigidbodyEx _rigidbodyEx;

	[SerializeField]
	private float SimulateRemoteImpulseLocallyPingMultiplier;

	private NDNDHMIKFJI CJDMGEHAEFA;

	private SeatManagement GLMLCKBKJAI;

	private Player EKOFNPFCLMO;

	private readonly global::ONFONCEBGPD<float> ELPAIOODIMD;

	private LKGILLBEJEK BECNHPKLPIE;

public NetworkTransform NetworkTransform
{
get 	{
		return this._networkTransform;
	}

}

public RigidbodyEx RigidbodyEx
{
get 	{
		return this._rigidbodyEx;
	}

}

public NDNDHMIKFJI VelocityTracker
{
get 	{
		return this.CJDMGEHAEFA;
	}

private set {
	}
}

public SeatManagement LocalPlayerSeat
{
get 	{
		return this.GLMLCKBKJAI;
	}

private set {
	}
}

public Player Player
{
get 	{
		return this.EKOFNPFCLMO;
	}

}

public float CurrentUniformScale
{
get 	{
		return 0f;
	}

}

public static float LocalTrackingSpaceScale
{
get 	{
		return 0f;
	}

}

	public void AddScaleSource(MHFKOLOAGLE GLLFHCCFIGK, float IPMIIEAGJKC)
	{
	}

	public bool HasScaleSource(MHFKOLOAGLE GLLFHCCFIGK)
	{
		return false;
	}

	public void RemoveScaleSource(MHFKOLOAGLE GLLFHCCFIGK)
	{
	}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void ANBLLNFDMDE(PhotonView BKFJMCAAIKF)
	{
	}

	public void SimulateRemoteImpulseLocally(Vector3 GDBGENEPKJJ, float JCOIPNJNGNL, float MJJDNDIGKOE)
	{
	}

	private IEnumerator<EGGPGCCKPCO> OCEABICHLBA(Vector3 GDBGENEPKJJ, float JCOIPNJNGNL, float MJJDNDIGKOE, float DBKJAJFHIFE)
	{
		return null;
	}

	public bool CanLocalPlayerLeaveSeat()
	{
		return false;
	}

	private void FOMBBKAEMMD(RigidbodyEx NEJMOIPCOAO, bool LDEEGDEKBLJ)
	{
	}

	public void TryFixUniformScale()
	{
	}

	public void SetLocalPlayerSeat(SeatManagement HGHEJNOMIJN, bool JHMMJMKHOMH = true)
	{
	}

	public void ClearLocalPlayerSeat(SeatManagement HGHEJNOMIJN)
	{
	}

	private void OnTransformParentChanged()
	{
	}
}
