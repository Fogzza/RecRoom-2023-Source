using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom;
using UnityEngine;

public class LaundryBinPickup : RigidbodyPickup
{
	private sealed class NDDPKHINHML : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public LaundryBinPickup _003C_003E4__this;

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
		public NDDPKHINHML(int _003C_003E1__state)
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

	private const float FJNJHBALALK = 0.001f;

	[SerializeField]
	private float spring;

	[SerializeField]
	private float damper;

	private Joint EOHKFIMKNBC;

public override bool IsPickedUp
{
get 	{
		return false;
	}

}

public override Vector3 TargetPosition
{
get 	{
		return default;
	}

}

public override Quaternion TargetRotation
{
get 	{
		return default;
	}

}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void FGHEOJJEHEK(Tool PMEFICGEDFK)
	{
	}

	private void GJCLGHAONAN(Tool PMEFICGEDFK)
	{
	}

	public override void Pickup(RigidbodyEx GFCPAMJILIO, Vector3 BFNEJBJJKCL, Quaternion EFKFJMLEBIP)
	{
	}

	public override void Release()
	{
	}

	private IEnumerator<EGGPGCCKPCO> JJPNNDIMOLA()
	{
		return null;
	}

	private void OFKGDEJMDMK()
	{
	}

	private Joint PKCHJJKDLCH(Rigidbody GFCPAMJILIO)
	{
		return null;
	}
}
