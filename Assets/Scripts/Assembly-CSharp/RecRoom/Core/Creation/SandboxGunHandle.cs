using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.CircuitsV2.GraphNodes;
using RecRoom.Core.Creation.CircuitsV1;
using RecRoom.Systems.PlayerRoles;
using RecRoom.UI;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class SandboxGunHandle : MonoBehaviourPun, GFLPAFBGELM, NEKJJEGPHFG, DJLCHGFCFAD, GAAKCFPLMHN
	{
		public enum JKECCNMECFM
		{
			NOT_SUPPORTED = 0,
			UNAVAILABLE = 1,
			BLOCKED_BY_OTHER_TOOL = 2,
			AVAILABLE = 3
		}

		private sealed class NCHILNOBKKE : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public SandboxGunHandle _003C_003E4__this;

			public Quaternion recoilRotation;

			public float recoilDuration;

			public float returnDuration;

			private Quaternion _003CrecoilStartTotalAccumulatedRecoil_003E5__2;

			private Quaternion _003CrecoilEndTotalAccumulatedRecoil_003E5__3;

			private float _003CrecoilStartTime_003E5__4;

			private float _003CrecoilEndTime_003E5__5;

			private float _003Ct_003E5__6;

			private Quaternion _003CreturnStartTotalAccumulatedRecoil_003E5__7;

			private Quaternion _003CreturnEndTotalAccumulatedRecoil_003E5__8;

			private float _003CreturnStartTime_003E5__9;

			private float _003CreturnEndTime_003E5__10;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public NCHILNOBKKE(int _003C_003E1__state)
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

		private const int EOIDNNPCJJN = 6;

		private const float HJBOJFIDANM = 20f;

		private const float OHJFNMANEGE = 1f;

		private const int FLHDOICGKLB = 30;

		private const float OIENILPGBDA = 0.025f;

		private const float HLMMJBAGEOF = 2.5f;

		private const float FDNOPNGOMOL = 3f;

		private const float JPOGMNBPEPK = 0.66f;

		private const float FOLLIBFJMGC = 0.66f;

		private const float AHGMFKGOENJ = 0.33f;

		private const float GFJHOOJBODA = 1.5f;

		private const float PMNIEDFMCDE = 1f;

		[SerializeField]
		private ControlPanelCircuitObject controlPanelCircuitObject;

		[SerializeField]
		private Tool _tool;

		[SerializeField]
		private CreationObject creationObject;

		[SerializeField]
		private ConfigurableCircuitVisibilityBehaviour circuitVisibility;

		[SerializeField]
		private PlayerAnimation pistolOneHandedPose;

		[SerializeField]
		private PlayerAnimation pistolTwoHandedPose;

		[SerializeField]
		private PlayerAnimation shotgunOneHandedPose;

		[SerializeField]
		private PlayerAnimation shotgunTwoHandedPose;

		[SerializeField]
		private PlayerAnimation rifleOneHandedPose;

		[SerializeField]
		private PlayerAnimation rifleTwoHandedPose;

		private bool PJCKKJMEELC;

		private Vector3 DLCCPIKPMPK;

		private Action<Vector2, float, float> PEEKNEKLNHB__BackingField;

		private global::CDLJMENCODC<int> GMOOIMMHOPF;

		private float KPLOLOBPAMO;

		private bool NLALBCKEPGI;

		private IDisposable KEDDLINDMIG;

		private global::CDLJMENCODC<int> CBOAOOJFGDC;

		private global::CDLJMENCODC<bool> DNBJDOENCLJ;

		private global::CDLJMENCODC<float> DEAMGJAHBLO;

		private global::CDLJMENCODC<float> GEEMMOPAFKK;

		private global::CDLJMENCODC<int> LNEBNONBFCH;

		private global::CDLJMENCODC<float> PFFBGIBOEMC;

		private global::CDLJMENCODC<float> GGAKOOIBCGP;

		private global::CDLJMENCODC<float> FHLMNEGDJND;

		private global::CDLJMENCODC<float> PLBNCLKOFAC;

		private global::CDLJMENCODC<float> JGKMPAMNCFA;

		private global::CDLJMENCODC<float> JDIKAHOCLFN;

		private global::CDLJMENCODC<bool> KOMFPJCONEC;

		private global::CDLJMENCODC<bool> ANBIGIJINNI;

		private global::CDLJMENCODC<float> ECKPDFIKFCD;

		private global::CDLJMENCODC<bool> DADNHCLOOHJ;

		private global::CDLJMENCODC<float> FKMABKPDGJM;

		private global::CDLJMENCODC<bool> HHJDDAHPIAG;

		private global::CDLJMENCODC<int> MCOHPJKDPCK;

		private global::MOBDJNEDDKC<bool> NMHHDPPGJLI;

		private global::CDLJMENCODC<bool> OCOCGIMHAKA;

		private global::EDPNALIEGFA<Guid> EAPNHDAKANA;

		private ConnectableTool AAPKAJOCACA;

		private Quaternion BKCBHGJOCHE;

		private LKGILLBEJEK EGOKIPELFJC;

		public global::HHOBPMOCKMJ<SandboxGunHandle> OnGunHandleFired;

		private static readonly LayerMask BKCLFLJFOLN;

		private const float LBDAOPLAPBA = 1000f;

		private static readonly Dictionary<string, MIBJNNKFLND> PLLHJCIAJCF;

public Tool Tool
{
get 		{
			return null;
		}

}

public bool HasOverriddenTargetPoint
{
get 		{
			return false;
		}

set {
		}
}

public Vector3 OverrideTargetPoint
{
get 		{
			return default;
		}

set {
		}
}

public int CurrentAmmo
{
get 		{
			return 0;
		}

set {
		}
}

private bool NIPAPBIFAPE
{
get 		{
			return false;
		}

}

public float TimeSinceLastFire
{
get 		{
			return 0f;
		}

}

public bool IsOnCooldown
{
get 		{
			return false;
		}

}

public int MaxAmmo
{
get 		{
			return 0;
		}

set {
		}
}

public bool ContinuousFire
{
get 		{
			return false;
		}

set {
		}
}

public float MaxFireRate
{
get 		{
			return 0f;
		}

set {
		}
}

public float ReloadDuration
{
get 		{
			return 0f;
		}

set {
		}
}

public int CrosshairTicks
{
get 		{
			return 0;
		}

set {
		}
}

public float CrosshairIdleSpread
{
get 		{
			return 0f;
		}

set {
		}
}

public float CrosshairWalkScalar
{
get 		{
			return 0f;
		}

set {
		}
}

public float CrosshairSprintScalar
{
get 		{
			return 0f;
		}

set {
		}
}

public float CrosshairCrouchScalar
{
get 		{
			return 0f;
		}

set {
		}
}

public float CrosshairProneScalar
{
get 		{
			return 0f;
		}

set {
		}
}

public float CrosshairADSScalar
{
get 		{
			return 0f;
		}

set {
		}
}

public bool ADSEnabled
{
get 		{
			return false;
		}

set {
		}
}

public bool ADSCrosshairEnabled
{
get 		{
			return false;
		}

set {
		}
}

public float ADSZoom
{
get 		{
			return 0f;
		}

set {
		}
}

public bool AimFrictionEnabled
{
get 		{
			return false;
		}

set {
		}
}

public float AimFrictionRadius
{
get 		{
			return 0f;
		}

set {
		}
}

public bool ProjectileMagnetismEnabled
{
get 		{
			return false;
		}

set {
		}
}

private AKBDGPJCNDM.BEHNIICONEC.KOAAOINNOGO GMOPOLDPGEN
{
get 		{
			return AKBDGPJCNDM.BEHNIICONEC.KOAAOINNOGO.PistolOneHanded;
		}

set {
		}
}

public bool IsReloading
{
get 		{
			return false;
		}

set {
		}
}

public bool SupportsReload
{
get 		{
			return false;
		}

set {
		}
}

private ISet<Guid> KMJEGIEHOBD
{
get 		{
			return null;
		}

}

public global::MPNGGJINIEL<KGGKJGICJLE> ObjectDefinitionId
{
get 		{
			return default;
		}

}

public GMHHJCFIMML CV2CreationObject
{
get 		{
			return null;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

public event Action<Vector2, float, float> OnApplyRecoil {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		protected void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void ResetObject()
		{
		}

		public KLNOBKBCIEK GetAutoAimRoles()
		{
			return KLNOBKBCIEK.AG_EVERYONE;
		}

		private bool AANAFAPJOHO(ScreenHUDCrosshair.IKNLFLEALLL EBBNMKKOLJD)
		{
			return false;
		}

		private void BAAAKPGIFLI(ScreenHUDCrosshair.IKNLFLEALLL EBBNMKKOLJD, bool BFDBCMGIOBG)
		{
		}

		private void HLMOFPPJLNP(RigidbodyEx AAFNLLCIFBP)
		{
		}

		private void ICFFPGJLBHA(RigidbodyEx AAFNLLCIFBP)
		{
		}

		public void ToolHighlightingOverride(LMKFOACECEG? IEMMIFODLAI)
		{
		}

		private void JJFJPCBMOFC(Vector2 MILGOCGHFJG, float FGBPJMKCMAO, float CBBGNGJLMFM)
		{
		}

		private void MCKCHANJGDA()
		{
		}

		private IEnumerator<EGGPGCCKPCO> CKEMCAJJJOH(Quaternion MBGNAPBGPOB, float GHEMNAKHNAI, float CBBGNGJLMFM)
		{
			return null;
		}

		private void IEELJEBHDEI(Tool IEGMBEPJMGC)
		{
		}

		private void JMNJJLBJLEK(Tool PMEFICGEDFK)
		{
		}

		private void NJOLOHLEIFG(Tool PMEFICGEDFK)
		{
		}

		public void OnInputUp(Tool PMEFICGEDFK)
		{
		}

		private void BHEDNHMJFIE(Tool PMEFICGEDFK)
		{
		}

		private void JFGMIGPAJNO(Tool IEGMBEPJMGC)
		{
		}

		private void MCNIJHMCMIA()
		{
		}

		protected virtual void BENOONGCBKO()
		{
		}

		protected virtual void NHDINKLIIOC()
		{
		}

		public bool IsAutomaticFireRunning()
		{
			return false;
		}

		private void GEHPFHJJPDG(float OKBAJEAPIHG)
		{
		}

		public JKECCNMECFM GetReloadAvailability()
		{
			return JKECCNMECFM.NOT_SUPPORTED;
		}

		private void MEAAIGPPHBN()
		{
		}

		public void ReloadStartedCV2Invoke()
		{
		}

		public void ReloadCompletedCV2Invoke()
		{
		}

		public void ReloadCancelledCV2Invoke()
		{
		}

		public void ReloadActionPressedCV2Invoke()
		{
		}

		public void ReloadActionReleasedInvoke()
		{
		}

		public void ReloadActionHeldCV2Invoke()
		{
		}

		public void PrimaryActionPressedCV2Invoke()
		{
		}

		public void PrimaryActionReleasedCV2Invoke()
		{
		}

		public void PrimaryActionHeldCV2Invoke()
		{
		}

		private void CNPHPLFFOHM(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private void PJBIKLIBBFE(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private global::FAIKNKAIPLB<OHAJOLBEFND> DCBNIOPDHIN(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		global::FAIKNKAIPLB<OHAJOLBEFND> GFLPAFBGELM.Self(JEGAPHLGBJA GCBHEJANCJK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DCBNIOPDHIN
			return this.DCBNIOPDHIN(GCBHEJANCJK);
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetMaxAmmo(JEGAPHLGBJA GCBHEJANCJK, int LIODLDNGDIO)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetCurrentAmmo(JEGAPHLGBJA GCBHEJANCJK, int IJHMKEIOKHN)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetADSEnabled(JEGAPHLGBJA GCBHEJANCJK, bool BFDBCMGIOBG)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetCanReload(JEGAPHLGBJA GCBHEJANCJK, bool LEFFANAKDLP)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2ApplyRecoil(JEGAPHLGBJA GCBHEJANCJK, Vector2 MILGOCGHFJG, float FGBPJMKCMAO, float CBBGNGJLMFM)
		{
			return default;
		}

		public Vector3 CV2GetFiringDirection(JEGAPHLGBJA GCBHEJANCJK, GMHHJCFIMML EDGHCIEJHLG)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2AddAutoAimRole(JEGAPHLGBJA GCBHEJANCJK, GameRole KLBONOOHBND)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RemoveAutoAimRole(JEGAPHLGBJA GCBHEJANCJK, GameRole KLBONOOHBND)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetAutoAimRoles(JEGAPHLGBJA GCBHEJANCJK, List<GameRole> LGEIKKCKJHH)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetRateOfFire(JEGAPHLGBJA GCBHEJANCJK, float MGKOCKICGLN)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetReloadDuration(JEGAPHLGBJA GCBHEJANCJK, float BBGNJMKOHPL)
		{
			return default;
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		private bool MJACCMINHOC(out PlayerAnimation BLBGBBKBLKB)
		{
			BLBGBBKBLKB = null;
			return false;
		}

		private PlayerAnimation LIJNLAFEJAN()
		{
			return null;
		}

		[CompilerGenerated]
		private int DJGIGDEGPMM()
		{
			return 0;
		}

		[CompilerGenerated]
		private void OKMOEGBPNOL(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int BMLMLLGJNKJ()
		{
			return 0;
		}

		[CompilerGenerated]
		private void KDILAMPJACI(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool PFHIBANHJDL()
		{
			return false;
		}

		[CompilerGenerated]
		private bool BDDMMAPADOE()
		{
			return false;
		}

		[CompilerGenerated]
		private void HPAOJICGOJI(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool JLFCFDMBHEJ()
		{
			return false;
		}

		[CompilerGenerated]
		private float MENGEIDFLHC()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void NBBCGCLJKNL(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool LBDBEHBFJEM()
		{
			return false;
		}

		[CompilerGenerated]
		private bool HPOBOKDNPEM()
		{
			return false;
		}

		[CompilerGenerated]
		private void FEEEFKFMBHA(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool FOJDPGCCDIP()
		{
			return false;
		}

		[CompilerGenerated]
		private float DGGDODHGALH()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void MJNCIDEPHIM(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool DHGCBKHDKPH()
		{
			return false;
		}

		[CompilerGenerated]
		private bool PEKPHGBNLDI()
		{
			return false;
		}

		[CompilerGenerated]
		private void MLMONKEKLFC(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool IIAEBFHCPKK()
		{
			return false;
		}

		[CompilerGenerated]
		private void ACKLPMPEHHI(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool JPAOMIHBEKF()
		{
			return false;
		}

		[CompilerGenerated]
		private float NIOGAPEHANI()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void OFCFOABIFNK(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool ADMACBGDLDL()
		{
			return false;
		}

		[CompilerGenerated]
		private bool EFHMCMCIOMP()
		{
			return false;
		}

		[CompilerGenerated]
		private void MMJFBFMPOPL(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool NIKNFDCDAKI()
		{
			return false;
		}

		[CompilerGenerated]
		private void DAKJNBNICJL(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool DNNDGAFAPKG()
		{
			return false;
		}

		[CompilerGenerated]
		private void EDMEMMGDECI(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool EBMLLDPPDCH()
		{
			return false;
		}

		[CompilerGenerated]
		private void MBMOGCFFMDO(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float PODMKGOINLO()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void CNNOLLNCMFL(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float PKACODNPFIJ()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void IADDKBFAPPB(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float IDFMBPFKJBJ()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void GEADNCFFPNG(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float NOEHOCEECEL()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void BPHDFAKPEMB(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float BCBGFGPOHEE()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void DPIJCFEFIHI(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float KHDLEADDKEM()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void GHLDPAEGOBF(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool ENIEBCENOBH()
		{
			return false;
		}

		[CompilerGenerated]
		private bool LOIJCLLNMEJ()
		{
			return false;
		}

		[CompilerGenerated]
		private void FFDNNMLMCFO(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float FOHKPGDBGMK()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void CKNKFNBJANE(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool LBBGMEICKOK()
		{
			return false;
		}

		[CompilerGenerated]
		private bool FJOPKEOFOOI()
		{
			return false;
		}

		[CompilerGenerated]
		private void DFHABKEJOLO(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private HashSet<Guid> BAFBMCHCLDF()
		{
			return null;
		}

		[CompilerGenerated]
		private void JKFHINBDLHD(IEnumerable<Guid> IPMIIEAGJKC)
		{
		}
	}
}
