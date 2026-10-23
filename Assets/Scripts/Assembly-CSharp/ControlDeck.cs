using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ExitGames.Client.Photon;
using Photon.Pun;
using RecRoom.Activities.Vehicles;
using RecRoom.Core;
using UnityEngine;

public class ControlDeck : MonoBehaviourPun, KFLNCOLKJEM
{
	public enum NBIPDNKGMCC
	{
		UNOCCUPIED = 0,
		OCCUPIED = 1
	}

	public enum NPEFOMMMGAO
	{
		NONE = 0,
		VR_MOTION_INPUT = 1,
		VR_BUTTON_INPUT = 2,
		SCREENS_BUTTON_INPUT = 3,
		REMOTE = 4
	}

	public struct PNLOPFPCEMN
	{
		private static readonly ELFDKCLHAMN DGJEOFHPNDP;

		public ControlDeck DLFKMDFDAFO;

		public float MBGINMACAMP;

		public bool PMGGKMKKIME;

		private void KMDJNOCMKDB(ELFDKCLHAMN DGJEOFHPNDP)
		{
		}

		private static PNLOPFPCEMN JFDMJLPIIPF(ELFDKCLHAMN DGJEOFHPNDP)
		{
			return default;
		}

		public static short IIADKJHBOIN(StreamBuffer HLHADAOGCMN, object PJGPNPBFMFD)
		{
			return 0;
		}

		public static object BBCFAILGGHN(StreamBuffer FAMJGEFEDDM, short MNKGPEKFPKK)
		{
			return null;
		}
	}

	private sealed class KKMEEHECKKO : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public PlayerHand hand;

		public ControlDeck _003C_003E4__this;

		private Tool _003CheldTool_003E5__2;

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
		public KKMEEHECKKO(int _003C_003E1__state)
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
	private BaseRecRallyVehicle vehicle;

	[SerializeField]
	private VehicleEngine vehicleEngine;

	[SerializeField]
	private VehicleControls vehicleControls;

	[SerializeField]
	private SteeringWheel steeringWheel;

	[SerializeField]
	private BrakeHandle handBrake;

	[SerializeField]
	private BoostButton boostButton;

	[SerializeField]
	private ResetVehicleHandle frontBumper;

	[SerializeField]
	private ResetVehicleHandle rearBumper;

	public VehicleControls.OMDHEGMMAIK Input;

	private ODLNADPFBMD[] ECEBDMIJEFF;

	private MDEJADHJOEJ BGBIFFLGANM;

	private IDisposable OBECBJCGHMB;

	private bool HFPDHGICOFM;

	private JNKNMMDAHCF DHCLACKALOF;

	private HLNFDOBEGJO CHABDOLEEMD;

public bool BoostControlsAllowed
{
get 	{
		return false;
	}

}

public bool BoostButtonCurrentlyUsable
{
get 	{
		return false;
	}

}

public BrakeHandle Handbrake
{
get 	{
		return null;
	}

}

public Vector3 BoostButtonPosition
{
get 	{
		return default;
	}

}

private SeatManagement DILDJLDCBKG
{
get 	{
		return null;
	}

}

private Player LKHCBAHNDGD
{
get 	{
		return null;
	}

}

	protected override void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void GetSteeringWheelHandTransform(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, out Vector3 KLCDCMHPFFF, out Quaternion OIJHJMDDEIH)
	{
		KLCDCMHPFFF = default;
		OIJHJMDDEIH = default;
	}

	public void AddControlsRestriction(VehicleControl.OENNEAGDNCI NAOILMPNIEO)
	{
	}

	public void RemoveControlsRestriction(VehicleControl.OENNEAGDNCI NAOILMPNIEO)
	{
	}

	private void IEHKKOCNILD(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
	{
	}

	void KFLNCOLKJEM.OnPhotonSerializeView(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IEHKKOCNILD
		this.IEHKKOCNILD(EDIGAFOKGOJ, AKOKILEPANJ);
	}

	private void FACJKNHNPJP(PNLOPFPCEMN KBKJADAEFED)
	{
	}

	private PNLOPFPCEMN NHKOBNMOFHE()
	{
		return default;
	}

	private void JJGEEOBAPAI()
	{
	}

	private void ILBDBJLHOOB()
	{
	}

	private void HBFCDHKCCAF()
	{
	}

	private void HKCICHOBGFJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void NILADOJLNIO()
	{
	}

	private void KFNPKIPLMHL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void ANCIBGIMCAE()
	{
	}

	private void POEPPPIDGHO(bool KBEDOFPBEFJ)
	{
	}

	private void MOMABFGAIPN(PlayerHand PMNLJGLDMJN)
	{
	}

	private IEnumerator<EGGPGCCKPCO> HKOGGCBMLBG(PlayerHand PMNLJGLDMJN)
	{
		return null;
	}

	private void IHDFGFPLANH()
	{
	}

	private void FLMJPPGGCCA()
	{
	}

	private NPEFOMMMGAO JHJCFOHBFBA()
	{
		return NPEFOMMMGAO.NONE;
	}

	private void IGPKLHEAMGH()
	{
	}

	public void OnRoomSaveStarted(GBAJDOHJDHJ GADDGJANIGG)
	{
	}
}
