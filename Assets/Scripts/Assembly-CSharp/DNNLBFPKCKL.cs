using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom;
using RecRoom.Core;
using RecRoom.Inputs;
using UnityEngine;

public class DNNLBFPKCKL
{
	private sealed class BKNKONJGAJG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public DNNLBFPKCKL _003C_003E4__this;

		public Vector2 recoilAngle;

		public float recoilDuration;

		public AnimationCurve recoilCurve;

		public float returnDuration;

		public AnimationCurve returnCurve;

		private Vector2 _003CrecoilStartTotalAccumulatedRecoil_003E5__2;

		private Vector2 _003CrecoilEndTotalAccumulatedRecoil_003E5__3;

		private float _003CrecoilStartTime_003E5__4;

		private float _003CrecoilEndTime_003E5__5;

		private float _003Ct_003E5__6;

		private Vector2 _003CreturnStartTotalAccumulatedRecoil_003E5__7;

		private Vector2 _003CreturnEndTotalAccumulatedRecoil_003E5__8;

		private float _003CreturnStartTime_003E5__9;

		private float _003CreturnEndTime_003E5__10;

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
		public BKNKONJGAJG(int _003C_003E1__state)
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

	private const float OLAFECAPLJH = 60f;

	private const float DIDCJHBACGA = 68f;

	private const int FALNEGADIAD = 8;

	private global::AFHOAHNAMGF<global::CNANNICAHPN<ScreenPlayerCameraSettings>> HFNGOCKBAEI;

	private ScreenPlayerCameraSettings KLHEBGNMCFE;

	private ScreenCameraTargetingData IOMBHPBGBHB;

	private global::AFHOAHNAMGF<ScreensCameraInputGamepadSettings> IFFOGEMPDKG;

	private ScreensCameraInputGamepadSettings MMCNFNFNGEB;

	private global::AFHOAHNAMGF<global::CNANNICAHPN<IIEDPHPMKAH>> PINAKBBDJKC;

	private IIEDPHPMKAH CEJDNJPMLJJ;

	private Quaternion FMMOBEKMFHJ;

	private Vector3 GHPJEFNLKAL;

	private Vector3 JBJJFBFABMP;

	private DGBBFAHNOGB EMDEIICNALN;

	private NCIMIGIHJDN IBOIOPGKCOI;

	private global::FKEKGHJNEKC<ScreenPlayerCameraSettings, ScreenCameraTargetingData> HLLMKECJHGI;

	private global::FKEKGHJNEKC<IIEDPHPMKAH, Quaternion> HNPHJDGALBO;

	private global::FKEKGHJNEKC<IIEDPHPMKAH, Vector3> EIAOJCBIGJN;

	private ScreenPlayerController DHHICLJMBED;

	private Player DODHPDIHODE;

	private Camera NMEBHKCNOLK;

	private AECAHLPIFOC OLCAEPNCIIB;

	private Vector2 BKCBHGJOCHE;

	private LKGILLBEJEK EGOKIPELFJC;

	private bool LPOKLPJJCCD;

	private Vector3 GKCNOPKFMNM;

	private Quaternion ODCILHKPJHC;

	public EEANDDJEMJC IGENINJBIME;

	private bool OAHIGOLHIEH;

public bool BHBLDOLJPCI
{
get 	{
		return false;
	}

private set {
	}
}

public Vector2 ANNHNAELNGH
{
get 	{
		return default;
	}

set {
	}
}

public bool OJLOEKLPNEK
{
get 	{
		return false;
	}

}

	public static float GMNOBEPAPBC()
	{
		return 0f;
	}

	public void BBAJDLHFBLL(ScreenPlayerCameraSettings NFPCPPGGCLI, float DHGKDPBMONF, object IALNODEHBNN, ScreenPlayerController.JGABDNCALLD LAGADKBKLAD)
	{
	}

	public void DBAMJEMELDF(object IALNODEHBNN)
	{
	}

	public void DBAMJEMELDF(object IALNODEHBNN, float JNJJEODMBNB)
	{
	}

	public bool KKBKEBNDBMO(ScreenPlayerCameraSettings NFPCPPGGCLI)
	{
		return false;
	}

	public void CMNMBGBPAAE(ScreenPlayerCameraSettings NFPCPPGGCLI)
	{
	}

	public bool GPEIFJOCKAI(out Vector3 ELFBHMFHAKC)
	{
		ELFBHMFHAKC = default;
		return false;
	}

	private void HJHHHHJAKCF(ScreenPlayerCameraSettings NFPCPPGGCLI, float DHGKDPBMONF)
	{
	}

	public void PPJJOCOGOBP(ScreensCameraInputGamepadSettings DDJBDOCNGHD, object IALNODEHBNN, ScreenPlayerController.JGABDNCALLD LAGADKBKLAD)
	{
	}

	public void EPOMKJALFKM(object IALNODEHBNN)
	{
	}

	private void BDCOLHPPPPH(ScreensCameraInputGamepadSettings PNKBGCLMABO)
	{
	}

	public void HMBFLKEHNKK(float BGGFEEADBNI, object IALNODEHBNN)
	{
	}

	public void JMEGAMBBDOL(object IALNODEHBNN)
	{
	}

	private void DPDFONBOFFM(float COHBNIGJJKO)
	{
	}

	public void IIDPMLNHOAM(IIEDPHPMKAH HAKINKFAIOF, float DHGKDPBMONF, object IALNODEHBNN, ScreenPlayerController.JGABDNCALLD LAGADKBKLAD)
	{
	}

	public void EAKGOMHEIGL(object IALNODEHBNN)
	{
	}

	public void EAKGOMHEIGL(object IALNODEHBNN, float JNJJEODMBNB)
	{
	}

	public bool GOCPJBBGFFN(IIEDPHPMKAH HAKINKFAIOF)
	{
		return false;
	}

	private void IJOHMNKIAMB(IIEDPHPMKAH HAKINKFAIOF, float DHGKDPBMONF)
	{
	}

	public void EHMICKMBCPH(ScreenPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Camera GAPPCJHIBEK, AECAHLPIFOC KAEDAICECGN)
	{
	}

	public void CCGINANHKEO(ScreenPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Camera GAPPCJHIBEK, AECAHLPIFOC KAEDAICECGN)
	{
	}

	public void LLIEFKBMIKM(Vector3 HNIMMIAGMNO, Quaternion MNCDNIDIBMP, float COHBNIGJJKO)
	{
	}

	public void EEJGEGDMPIJ(Vector2 DDLBMIJOFJH, AnimationCurve CJCJCPAPCGO, float GHEMNAKHNAI, AnimationCurve MFJHNGHENAN, float CBBGNGJLMFM)
	{
	}

	public void GGNCHKONGOM()
	{
	}

	private bool GPKGJGKHMCN()
	{
		return false;
	}

	private void MCKCHANJGDA()
	{
	}

	private IEnumerator<EGGPGCCKPCO> CKEMCAJJJOH(Vector2 DDLBMIJOFJH, AnimationCurve CJCJCPAPCGO, float GHEMNAKHNAI, AnimationCurve MFJHNGHENAN, float CBBGNGJLMFM)
	{
		return null;
	}

	private Quaternion EDCBDJJAGEP(Quaternion HEGBBJCMANH)
	{
		return default;
	}

	private Quaternion LLNEBHHLIOP(IIEDPHPMKAH HAKINKFAIOF, bool BKEBFPIHGEL, bool KDAMLDCCDOP)
	{
		return default;
	}

	private Quaternion PICCMIBNKGC(IIEDPHPMKAH HAKINKFAIOF)
	{
		return default;
	}

	private Vector3 CFFJHPDHHHI(IIEDPHPMKAH HAKINKFAIOF, bool BKEBFPIHGEL, bool KDAMLDCCDOP, out Vector3 ELFBHMFHAKC)
	{
		ELFBHMFHAKC = default;
		return default;
	}

	private Vector3 PMCKJIAMKHO(IIEDPHPMKAH HAKINKFAIOF)
	{
		return default;
	}

	private Quaternion AIDHHJKFMFA(Quaternion BLFKABPCHLN, Quaternion NPFMAENOPCH, float IHPJCBCPLCM)
	{
		return default;
	}

	private Vector3 LKLFPHCONLH(Vector3 BLFKABPCHLN, Vector3 NPFMAENOPCH, float IHPJCBCPLCM)
	{
		return default;
	}
}
