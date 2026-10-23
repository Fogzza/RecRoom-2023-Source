using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using RecRoom.Activities.Vehicles;
using RecRoom.Core;
using UnityEngine;

public abstract class VehicleControl : MonoBehaviourPun, ODLNADPFBMD
{
	public delegate bool OENNEAGDNCI(CHILKDJABBF EKOFNPFCLMO, VehicleControl BADKNFDLLEG);

	private sealed class AKBAMMMHOAK : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public PlayerHand hand;

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
		public AKBAMMMHOAK(int _003C_003E1__state)
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
	protected VehicleControls vehicleControls;

	[SerializeField]
	protected GroundVehicle vehicle;

	[SerializeField]
	protected ControlDeck controlDeck;

	protected MDEJADHJOEJ BGBIFFLGANM;

	private LKGILLBEJEK KPMPOPCOCIC;

	private ControlDeck.NPEFOMMMGAO JOLABNAOOOF;

	private readonly List<OENNEAGDNCI> FBHLFCLNLJJ;

public GroundVehicle Vehicle
{
get 	{
		return null;
	}

}

public ControlDeck ControlDeck
{
get 	{
		return null;
	}

}

public ControlDeck.NPEFOMMMGAO CurrentInputType
{
get 	{
		return ControlDeck.NPEFOMMMGAO.NONE;
	}

set {
	}
}

public SeatManagement DriversSeat
{
get 	{
		return null;
	}

}

	protected override void Awake()
	{
	}

	public void DisplayInput(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	public void CollectInput(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	public abstract void Release();

	public void AddUseRestriction(OENNEAGDNCI NAOILMPNIEO)
	{
	}

	public void RemoveUseRestriction(OENNEAGDNCI NAOILMPNIEO)
	{
	}

	public bool PlayerCanUse(Player EKOFNPFCLMO)
	{
		return false;
	}

	protected virtual void GLNCBIJEHEI(CHILKDJABBF HIGOLKPFBPL)
	{
	}

	protected virtual void EBNEEMIBNLD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	protected virtual void NKNOBLPFCJD(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	protected virtual void CBPOMCILEML(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected virtual void OGLHAOIFBNC(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected virtual void EGDAKPMBJGG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	protected virtual void GDMNCBAFCHK(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	protected virtual void AAPJPKCBCCE(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected virtual void HJGEJOJNJJJ(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected virtual void OHHLLILGIKI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	protected virtual void JBNGPJANMJF(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	protected virtual void ABOAKEANGNC(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected virtual void CIIBOPFIPGJ(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected virtual void FKIEOJEEBFO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	protected virtual void KLIPKANLHDC(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	protected virtual void MPEOOIOHGIP(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected void IFBPOPMBOHD(PlayerHand PMNLJGLDMJN)
	{
	}

	protected void DCLGBJKFNAP()
	{
	}

	private IEnumerator<EGGPGCCKPCO> DFDPCMDGHKA(PlayerHand PMNLJGLDMJN)
	{
		return null;
	}
}
