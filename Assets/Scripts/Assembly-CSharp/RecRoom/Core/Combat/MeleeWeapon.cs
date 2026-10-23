using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Core.Combat
{
	public class MeleeWeapon : Weapon, JCPJHDPNDKB
	{
		private enum JKABOIMACBI
		{
			NOT_SWINGING = 0,
			SWINGING = 1,
			POST_SWING = 2,
			DISABLED = 3
		}

		protected class DPDLLPPOBGM
		{
			public readonly UnityEngine.Object BKILBJFMBOJ;

			public readonly int ADEOFKKFHFP;

			public readonly Vector3 JHEKFCANAOI;

			public readonly Vector3 EEAJIEJHCCI;

			public readonly DJBEHNDMJDL LEOCHGJGFDL;

			private readonly float HDGFHFCPNPD;

			private readonly int AMBFNAKPAFB;

public bool HHOGOJJELLH
{
get 			{
				return false;
			}

}

private float BNOAMOIENGM
{
get 			{
				return 0f;
			}

}

			public DPDLLPPOBGM(UnityEngine.Object GFCPAMJILIO, int AHNIMJDLOPB, float HDGFHFCPNPD, int AMBFNAKPAFB, DJBEHNDMJDL IKEDGLGPGEA, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK)
			{
			}

			public bool DGOCBAKDBLM(int AMBFNAKPAFB)
			{
				return false;
			}
		}

		private sealed class OEONALCDBBK : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MeleeWeapon _003C_003E4__this;

			private float _003Cendtime_003E5__2;

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
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public OEONALCDBBK(int _003C_003E1__state)
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

		private sealed class NABPJLFKBEB
		{
			public MeleeWeapon _003C_003E4__this;

			public Player hitPlayer;

			public Player.NBPIPAJOGLC hitBodyPart;

			public NGLCDIDOEMK impact;

			internal void _003COnThrowPlayerHit_003Eb__0()
			{
			}
		}

		[SerializeField]
		private bool supportsStationaryCollisionTests;

		[SerializeField]
		private float minSpeedImpulseSpeed;

		[SerializeField]
		private float maxSpeedImpulseSpeed;

		[SerializeField]
		private float minSpeedImpulseAngularSpeed;

		[SerializeField]
		private float maxSpeedImpulseAngularSpeed;

		[SerializeField]
		private bool supportsThrowDamage;

		[SerializeField]
		private float throwDamageMultiplier;

		[SerializeField]
		private float minThrowDamageSpeed;

		[SerializeField]
		private bool useToolCenterOfMassWhenHeld;

		[SerializeField]
		private bool canBlockEnemyMeleeAttacks;

		[SerializeField]
		private bool canBeBlockedByEnemiesWhileThrown;

		[SerializeField]
		private bool isDestructible;

		[SerializeField]
		private bool canPickupLastDestructibleChunk;

		[SerializeField]
		private MeleeWeaponChunk[] destructibleChunks;

		[SerializeField]
		private PooledParticle chunkBreakParticles;

		[SerializeField]
		private RecRoomAudioClip chunkBreakAudio;

		[SerializeField]
		private Color impactColor;

		[SerializeField]
		private float trailFadeInSmoothSpeed;

		[SerializeField]
		private float trailFadeOutSmoothSpeed;

		[SerializeField]
		private bool showTrailOnSwing;

		[SerializeField]
		private bool showTrailOnThrow;

		[SerializeField]
		private bool supportSwingSpringiness;

		[SerializeField]
		private RigidbodyPickup.SpringSettings defaultSpringSettings;

		[SerializeField]
		private RigidbodyPickup.SpringSettings swingSpringSettings;

		private const float AOLFFPMJDEC = 0.2f;

		private const float EOCMJKAMIEP = 1f;

		private const float AIOOAGABAJC = 3f;

		private const float IPIDDMJHOEP = 5f;

		private const float IFOPLMKKGKF = 0.33f;

		private const float DGEKECMHLLC = 0.5f;

		private const float BAPOGNEKLOL = 0.33f;

		private const float AIFAEBMNMJD = 1f;

		private const float GJLLKANLEEI = 5f;

		private const float MCNCJGBPLAH = 0.1f;

		private const float OPNMIFHJMHE = 0.5f;

		private const float ODADPOAMFOG = 3f;

		private const float DHDDHGONEJL = 4.1f;

		private const float CHEOELAAANJ = 0.2f;

		private const float LOHLMGBPAHL = 0.66f;

		public static global::HHOBPMOCKMJ<MeleeWeapon> StaticLocalPlayerSwingEvent;

		private MeleeWeaponCollider[] GHACMINFMCJ;

		private DynamicMeshTrail[] KKGLEENPHMK;

		private float BMLCHMCPOHF;

		private float ILGGKCBPAOG;

		private Coroutine GIDDJMGNAAP;

		private global::MOBDJNEDDKC<int> BHICIKCEJFL;

		private JKABOIMACBI CLCHBIHNNBK;

		private float OHBPDKMIIED;

		private bool BFJFCILGCKB;

		private float KMHACJIJCNC;

		private float EBBENIMPPMD;

		private float KBKOLLNCFKK;

		private float JLELDKAKENN;

		private global::MOBDJNEDDKC<bool> JDMNEOFOPDL;

		private global::MOBDJNEDDKC<bool> IGEEKOMFBOP;

		private global::MOBDJNEDDKC<bool> BONJFPGOEDF;

		private int AMBFNAKPAFB;

		private bool FDEEOPENDKF;

		private float KALAKLBDKJC;

		private float JMJHJEJFLLM;

		private List<DPDLLPPOBGM> LIBMPOPMCJN;

		private List<DPDLLPPOBGM> HHPCAJADMEM;

		private List<DPDLLPPOBGM> HNKBPMONNEH;

		private List<DPDLLPPOBGM> KHGBDFDGHNI;

		private List<DPDLLPPOBGM> IMGBILNDDHJ;

		private float LOHIFCHGGPB;

		private NGLCDIDOEMK GIOOMAMFMHG;

private int GEBOICFKBEL
{
get 		{
			return 0;
		}

set {
		}
}

public bool CalculateSwingingAutomatically
{
get 		{
			return false;
		}

set {
		}
}

public bool BlocksEnemyAttacksAutomatically
{
get 		{
			return false;
		}

set {
		}
}

public bool ManualBlockingEnabled
{
get 		{
			return false;
		}

set {
		}
}

public override DJBEHNDMJDL DamageType
{
get 		{
			return DJBEHNDMJDL.DEFAULT;
		}

}

public bool CanBlockEnemyMeleeAttacks
{
get 		{
			return false;
		}

}

public bool CanBeBlockedByEnemies
{
get 		{
			return false;
		}

}

public bool IsBroken
{
get 		{
			return false;
		}

}

protected override Color EGOOKBNKAEM
{
get 		{
			return default;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void AddImpactIgnoredCollider(Collider ADMCDJKKCIA)
		{
		}

		public override void RemoveImpactIgnoredCollider(Collider ADMCDJKKCIA)
		{
		}

		public override void AddImpactIgnoredColliders(IEnumerable<Collider> GHKNKHCKPII)
		{
		}

		public override void RemoveImpactIgnoredColliders(IEnumerable<Collider> GHKNKHCKPII)
		{
		}

		private void FixedUpdate()
		{
		}

		protected override void AOMPLKNJDAI()
		{
		}

		private void HAJACOHFHBE(Tool IEGMBEPJMGC)
		{
		}

		private void KNALNPOIOPN(Tool IEGMBEPJMGC)
		{
		}

		private void MNPLCFMNCJL(Tool IEGMBEPJMGC)
		{
		}

		protected virtual void PJNFLEELGDJ(Tool IEGMBEPJMGC)
		{
		}

		protected override void PLLGKABPABI(Tool PMEFICGEDFK, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		private void GCJABMONHDB(Tool PMEFICGEDFK, float MILGOCGHFJG, float FGBPJMKCMAO)
		{
		}

		private void ILMIKHGMNMG(Tool PMEFICGEDFK, float FGBPJMKCMAO)
		{
		}

		public void StartManualSwing(float OHBPDKMIIED, bool BFJFCILGCKB)
		{
		}

		public void StopManualSwing()
		{
		}

		public bool IsSwing()
		{
			return false;
		}

		public void RaiseStaticLocalSwingEvent()
		{
		}

		private void ECANILAMGJI()
		{
		}

		private void NOAFEAOHGHN()
		{
		}

		private void GGBKBBFGKKI(Tool IEGMBEPJMGC)
		{
		}

		private void CNPFNGKGEPL(float FGBPJMKCMAO)
		{
		}

		private void KKJLDNAAGLL(Color HMCAFGCGFJF)
		{
		}

		private void KKJLDNAAGLL()
		{
		}

		private void LPEICKAIDDN(bool BMGEHFPFCBJ)
		{
		}

		private void NOEBIFHJAOH()
		{
		}

		private void NEMLAGPKMAA()
		{
		}

		private void EEGOPOBGADH()
		{
		}

		private void FMOOMDFPJCJ()
		{
		}

		private bool KPMMECMNBCE(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
		{
			return false;
		}

		private bool HFHKEAAEDCM(Tool PMEFICGEDFK, Player DHPGNFBDHKH, CHNLCOIEBMH JMEEAMAPEDC)
		{
			return false;
		}

		private float HCNIHNEOJKL()
		{
			return 0f;
		}

		private int CILGGLGBHAG()
		{
			return 0;
		}

		private int DPHDPPHAGOC()
		{
			return 0;
		}

		private void CBMBCOLDAIG()
		{
		}

		private void ALJDFLDJLCE(Vector3 HCAOLLKLKIM, Vector3 GJOCEGMFHMC, int AFFACBOBCLC)
		{
		}

		private void HCCOPCALJMB(int IFLKNFOCJOL, Vector3 FEAHICFJDJO, Vector3 GMDILKACGIH, bool EPBDIPNPNDC)
		{
		}

		private bool LMJLIGIGMLM()
		{
			return false;
		}

		private void PMPEHFFGJIP()
		{
		}

		private void DJKEODPDPLJ()
		{
		}

		private IEnumerator MEIHIOGBOHC()
		{
			return null;
		}

		private void ELCFDHPEJAI()
		{
		}

		private bool JGLMPEAMBKC()
		{
			return false;
		}

		protected override void NHJOPMPGEFM(RigidbodyEx FDPNBMFPHHJ)
		{
		}

		private void NIPLHLNHEFO()
		{
		}

		private void LEDDGPIOEOI()
		{
		}

		private void GDPCGMMJKOJ(bool PNPCGNAPEKG)
		{
		}

		private void HFEJLPJALIC()
		{
		}

		private void OnCollisionEnter(Collision KDGCDLJEAMD)
		{
		}

		private void OnCollisionStay(Collision KDGCDLJEAMD)
		{
		}

		private void OnCollisionExit(Collision KDGCDLJEAMD)
		{
		}

		private void BCMIJCAPLDJ(Collision KDGCDLJEAMD)
		{
		}

		private DPDLLPPOBGM NHNINHHOIBE(Enemy GFCPAMJILIO)
		{
			return null;
		}

		private DPDLLPPOBGM MCDCJJCNGEE(Tool GFCPAMJILIO)
		{
			return null;
		}

		private DPDLLPPOBGM PLMKJIJGIAA(Trap GFCPAMJILIO)
		{
			return null;
		}

		private DPDLLPPOBGM EJDGPGBGFKM(Player GFCPAMJILIO)
		{
			return null;
		}

		private DPDLLPPOBGM JJEBNCBJKDI(UnityEngine.Object GFCPAMJILIO, List<DPDLLPPOBGM> MILHIOINMLE)
		{
			return null;
		}

		private void ICAHEIBEBNI()
		{
		}

		private void EBNMCMOCPFN()
		{
		}

		private void HCBGPACMIAH()
		{
		}

		private void LNFDKOIBIIO()
		{
		}

		private void LFMJDDLGPJL()
		{
		}

		private void GMPBDGOPGLN(Enemy DPENEFKKNDN, BHHAHFFCKJO GFHNJGJNNCK, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK)
		{
		}

		private void GBJOKDEOMFN(Player GFCPAMJILIO)
		{
		}

		private void POHLFKBENNM(Tool IEGMBEPJMGC, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK)
		{
		}

		private void CFGGDMGNGKG(Trap MBLENDJGFCI, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK)
		{
		}

		public override void NotifyWeaponDealtPlayerOnPlayerDamage(Player KJCCPIIFNGO)
		{
		}

		private void EAAFPNJINAP(MeleeWeaponCollider ADMCDJKKCIA, Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void ADCHBFLMEGC(Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void CPHPDNKELEP(Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void LJMIIMNNFON(Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void PFHCKKIBBAD(Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void NNBOPIIIBFC(MeleeWeaponCollider ADMCDJKKCIA, Enemy NJDDIIEPJDM, BHHAHFFCKJO MBKGKPOBHBB, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void OJDJNPEDHHO(Enemy NJDDIIEPJDM, BHHAHFFCKJO EKJJODPHDJK, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void PFNPDKAMILO(Enemy NJDDIIEPJDM, BHHAHFFCKJO EKJJODPHDJK, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void BADNPOJDELK(Enemy NJDDIIEPJDM, BHHAHFFCKJO EKJJODPHDJK, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void JEMEJIJDICH(Enemy DPENEFKKNDN, Collision KDGCDLJEAMD)
		{
		}

		private void AKIOKOJICJJ(Enemy DPENEFKKNDN)
		{
		}

		private void MMGCLAPFOJE(Enemy DPENEFKKNDN)
		{
		}

		private void OMPDFOGEGPH(MeleeWeaponCollider ADMCDJKKCIA, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void EKJENNHAJMH(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void HJMFBPIIEPD(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void HBALFKKDLMH(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void FJDHLLOOIKA(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void OADCKEKNDMN(Tool LMEKFBDFCDN)
		{
		}

		private void HFHALHKGNLL(Tool HBBJGPLMAFC)
		{
		}

		private void LIGBNPIMPFN(Tool HBBJGPLMAFC)
		{
		}

		private void KODJDHCNALE(MeleeWeaponCollider ADMCDJKKCIA, Trap AOCKEAPKNDE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void GEHGHAKFPOF(Trap AOCKEAPKNDE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void DIOKAMKEEIF(Trap AOCKEAPKNDE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void DLOCFGGPHDO(Trap AOCKEAPKNDE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void GNFGKOMBEON(Trap MBLENDJGFCI)
		{
		}

		private void LOLDPDLJIEI(MeleeWeaponCollider ADMCDJKKCIA, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void IKFJHADFFFH(NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void IFNCPPCEIIH(NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void ANNGGMANNPH(NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private bool EJJIMODKNKO()
		{
			return false;
		}

		public override int GetPlayerImpactDamage(Player.NBPIPAJOGLC AAEAKJPHADF, float ONDJPLPDHEC, bool DLFEBMLOBAM)
		{
			return 0;
		}

		public override int GetEnemyDamage(float BHEFDILBFOI = 0f)
		{
			return 0;
		}

		private float GKAPDKNGBCL()
		{
			return 0f;
		}

		protected float FLKJAPOMOBP()
		{
			return 0f;
		}

		protected float FMLAGEPEBMD(float CNMCICBLKOM)
		{
			return 0f;
		}

		protected float OAHOJCNJLKE(float CNMCICBLKOM)
		{
			return 0f;
		}

		protected Vector3 KOFHFHBNKAC(Vector3 HCAOLLKLKIM)
		{
			return default;
		}

		protected void PFDMGLCDPAJ(float FGBPJMKCMAO = 0.2f)
		{
		}

		private void CODOBHEGOMI()
		{
		}

		private void HDCHBMBCPNF(float DHPHKLIFBJH)
		{
		}

		private void EAGCBEFAKFN(Color HMCAFGCGFJF)
		{
		}

		private void HGLDAOHPEBF(bool GMEKKCPLMOB)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnChunkDestruction(int IFLKNFOCJOL, Vector3 FEAHICFJDJO, Vector3 GMDILKACGIH, bool EPBDIPNPNDC)
		{
		}

		private void GLKBCCNFINJ(MNENEENPCFE HMJOKPKOPCN)
		{
		}

		void JCPJHDPNDKB.PrepareImposter(MNENEENPCFE HMJOKPKOPCN)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GLKBCCNFINJ
			this.GLKBCCNFINJ(HMJOKPKOPCN);
		}
	}
}
