using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom;
using RecRoom.Core.Locomotion;
using RecRoom.Core.VR.PlayerController;
using RecRoom.Inputs;
using UnityEngine;

public class JBHDBPAKAMM
{
	private class JJPPEPEJLDD
	{
		private readonly Vector3 JJHBKFOHBGM;

		private readonly Vector3 GGEEKCJGOEM;

		private PlayerHand JHDKMHPLHAH;

		private VRInputHandler JDHKMCLBHGM;

		private PlayerFlyIndicator LEAKJJCHOBE;

		private float GMKBEJGABMO;

		private bool MIDOJMHMOLN;

public PlayerHand HOOIMOAJMMO
{
get 		{
			return null;
		}

private set {
		}
}

public VRInputHandler HIFHKFBPECF
{
get 		{
			return null;
		}

private set {
		}
}

private PlayerFlyIndicator FINPBDCLOGD
{
get 		{
			return null;
		}

set {
		}
}

public bool DFKLGAPFHPC
{
get 		{
			return false;
		}

}

private bool DJLBDJFJHJD
{
get 		{
			return false;
		}

set {
		}
}

private float EPGBALDCPFH
{
get 		{
			return 0f;
		}

}

public bool KFIOFDGBAHK
{
get 		{
			return false;
		}

}

public bool CKJOMKMDGFB
{
get 		{
			return false;
		}

}

		public void PPGNJEFPGCA(VRPlayerController BIEDNOLFJBE, PlayerHand PMNLJGLDMJN, VRInputHandler KAEDAICECGN, PlayerFlyIndicator GDEKLMNKJBC)
		{
		}

		public void NLKKGFJKAJD()
		{
		}

		public void GIOJCHNBDLN()
		{
		}

		public void JIMIMPOCECF()
		{
		}

		public void APCMACIEOAP()
		{
		}
	}

	private sealed class EMGNNLIMIDL : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public JBHDBPAKAMM _003C_003E4__this;

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
		public EMGNNLIMIDL(int _003C_003E1__state)
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

	private const string IKOHLEDAJEL = "FLY_ACTIVE";

	private const string OGADEEOKEDM = "WALL_RUN";

	private const string IBKKJJPHDAP = " WALL_CLIMB";

	private const string EKCKNKPMJGM = "WALL_CLIMB_LEFT_HAND";

	private const string KKDLEINCNAF = "WALL_CLIMB_RIGHT_HAND";

	private const string DKPKCEDLEDK = "WALL_CLIMB_JUMP";

	private const string HJAOIBCJAJP = "Seated";

	private const string AOEHJCLBLBB = "SIT_LEFT_HAND";

	private const string DNIFBKLFDIA = "SIT_RIGHT_HAND";

	private const int HNKDJMEKFID = 5000;

	private const int BAGEMMOBIFI = 5500;

	private const int OJCLJHBHHHN = 5501;

	private const int DGHNNDNGFHD = 5502;

	private const int LGMDCGPFNGE = 6001;

	private const int PKLJAEABJBP = 10001;

	private const float BLBJELJGFIN = 0.66f;

	private const float DNDCBJOIDFH = 0f;

	private const float DDBLCHGEGLM = 0.15f;

	private const float ODIPNHLDADG = 0f;

	private const float BGCFBNAPDLM = 0.2f;

	private const float FIKAFHKBDFC = 0.2f;

	private const float BKOLDOMAEEO = 0.1f;

	private const float DLAICFIPDPH = 0.1f;

	private const float PNCCMKMCOGN = 0.1f;

	private const float EBGAIDHOBPI = 0f;

	private const float DDLCKFBNPKF = 0.2f;

	private const float AGAFHDKBBOJ = 0f;

	private const float FONHECHCPDB = 0.2f;

	private const float DOAEEPIJCGK = 0.7f;

	private const float LECGKCCMLJD = 45f;

	private const float GGIHDOENGLE = 0.33f;

	private const float AILEAENADND = 0.1f;

	private const float GJLLDPFHEIP = 0.25f;

	private const float BAOMCPMNNDI = 0f;

	private const float JCOPFABPLON = 0.2f;

	private const float HDBNELAOHIJ = 0.15f;

	private VRPlayerLocomotionContent GEEDDDDPKND;

	private VRPlayerController DHHICLJMBED;

	private Camera NMEBHKCNOLK;

	private Player DODHPDIHODE;

	private VRInputHandler JNGPHLABAAO;

	private VRInputHandler PPAJCFAJGAE;

	private Transform OOIABNBCAMP;

	private PlayerMovement LDGMNBHAJKE;

	private float GBGLKDLNHOP;

	private float NNJFIFIPANM;

	private bool NMCPEMMOOHI;

	private readonly JNKNMMDAHCF DHCLACKALOF;

	private bool PFFBELPLBAG;

	private PlayerHand HAIPMCDMDMD;

	private VRInputHandler MOAGEMPGOKA;

	private bool BHACNBPOPGM;

	private bool CJGHIGIDFPB;

	private float FDLBFBIOFHB;

	private bool JMLOHPHEEBO;

	private bool LKHONONCIFO;

	private bool LEMJKCJKHCD;

	private bool HPDGNABGIDH;

	private bool KEIEKELEIKE;

	private float? CBFDJENGHHP;

	private bool MHMGDGHANEL;

	private bool PLDOJPKBBHC;

	private float BKOGIEOGCIP;

	private bool MADDBKMNOEK;

	private float KKNKMKKJNFC;

	private bool CKELOOMIBCJ;

	private bool KFDKKNIKGCP;

	private bool CILIHCCCPEJ;

	private bool MIKLFNPMMDG;

	private bool KKLCDMECOLJ;

	private Vector3 LIFKIEGLBKL;

	private Vector3 JPPBAJHONHM;

	private PFPHHBKDIOO ADEEIILKNFJ;

	private PFPHHBKDIOO CLNMBEGJCLF;

	private KOLAIEEAMLH KCGPEPNHFLM;

	private KOLAIEEAMLH MKDHAPHNNFB;

	private bool OBFOPJHLMBO;

	private bool HAACMLABJOP;

	private bool GNLNMNHGGCG;

	private readonly JJPPEPEJLDD OLIHNEDBJNA;

	private float AKJGONAPOIL;

	private bool ANJPHLLAMOA;

	private bool MMLOGMNCJCN;

	private bool COLBFLOFDIE;

	private bool FJLNGPEDPDF;

	private float BFHEICBBOBL;

	private bool AOJJOKMCGGA;

	private float OLNJILFPMJD;

	private LKGILLBEJEK CHKPDBNADGE;

	private float ECPIFLLIDAO;

	private LCBKGKMLDKI LBMMAAGBGEC;

	private JKCIBBMNLLN CHLDBKACEKI;

	public void IHEKMEOIBOI()
	{
	}

	public void JHECFGDENEP(Player EKOFNPFCLMO)
	{
	}

	public void GGLOGJANACC(Player EKOFNPFCLMO)
	{
	}

	public void PNKNNGBLONO(VRPlayerLocomotionContent GJNKHFLDKHK, VRPlayerController BIEDNOLFJBE, Camera GAPPCJHIBEK, Player EKOFNPFCLMO, VRInputHandler HDBKANLLDFE, VRInputHandler BEPMOMADFIE, Transform CLMCPAFCAIH, PlayerMovement EJGAMFOKJOO, float GGEPGCNHMDB, float OKBAJEAPIHG)
	{
	}

	public void DNOKMNHPIAG(VRPlayerLocomotionContent GJNKHFLDKHK, VRPlayerController BIEDNOLFJBE, Camera GAPPCJHIBEK, Player EKOFNPFCLMO, VRInputHandler HDBKANLLDFE, VRInputHandler BEPMOMADFIE, Transform CLMCPAFCAIH, PlayerMovement EJGAMFOKJOO, float GGEPGCNHMDB, float OKBAJEAPIHG)
	{
	}

	public void PPGOLHLBGGH()
	{
	}

	private void KFIGFLMOLGC()
	{
	}

	private void NIEOOMKEHFB()
	{
	}

	private void LFPJEHHJEGB()
	{
	}

	private void OLLKLEPCGKK()
	{
	}

	private void FJOLAHEHLGB()
	{
	}

	private bool AHPIBJOOCMI()
	{
		return false;
	}

	private bool ENCNBMPIHOI(out PlayerHand HAIPMCDMDMD, out VRInputHandler MOAGEMPGOKA)
	{
		HAIPMCDMDMD = null;
		MOAGEMPGOKA = null;
		return false;
	}

	private void ANFPDIBEIGF()
	{
	}

	private void PMFEMKLHIGH()
	{
	}

	private void FKHGCNIAKCG()
	{
	}

	private void BIGKGHEAAOC()
	{
	}

	private VRInputHandler NDOCBDHJIKN()
	{
		return null;
	}

	private PlayerHand ENJJCEJMIDI()
	{
		return null;
	}

	private void MCEOBKBPBKM()
	{
	}

	private void PDOHKAOLCOL()
	{
	}

	private bool EAAFBOANHDE()
	{
		return false;
	}

	private bool GBCKEJBKCEP()
	{
		return false;
	}

	private VRInputHandler EDCOIAOBLHD()
	{
		return null;
	}

	private void KJIDABKGHEI()
	{
	}

	private void ELHHNCCEIIE()
	{
	}

	private void MCMAKBFJGPM()
	{
	}

	private void IENGENODAGL()
	{
	}

	private void GMDBACNBOOG()
	{
	}

	private void BDPEGEPAILI()
	{
	}

	private void COIOMFLCOEF()
	{
	}

	private void CDEOKFIJOEG()
	{
	}

	private void MBDICPEDGKA()
	{
	}

	private void PAPDCNAPDLA()
	{
	}

	private void AFHEDEANIKC()
	{
	}

	private void HCGEJOODLKH()
	{
	}

	private void PJOJEJJFLIH()
	{
	}

	private void FPEGNKFGEAH()
	{
	}

	private void KJLHEEPLFPI()
	{
	}

	private void LCECHCJLPHB()
	{
	}

	private void CKBGDJLOOHD(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, VRInputHandler KAEDAICECGN)
	{
	}

	private void INMIOIPGDOM()
	{
	}

	private void CEINPMMEIHM()
	{
	}

	private void BMNKIOBJPOH()
	{
	}

	private void NKNKBNPFKBG()
	{
	}

	private void LEJAIKJCBPK(PlayerHand PMNLJGLDMJN, VRInputHandler KAEDAICECGN, PFPHHBKDIOO JHHAOGGLGFK, ref bool NMEKDJDPHNO, ref Vector3 GHLGLAJEBKD)
	{
	}

	private void NPJONKEKGLN(PlayerHand PMNLJGLDMJN)
	{
	}

	private void AAOOMHOBIKH(PlayerHand PMNLJGLDMJN)
	{
	}

	private void DCKODCMJGEH()
	{
	}

	private void DNGFLGICJIA(PlayerHand PMNLJGLDMJN, string LBAIHDLEFFO, int NABOFKIICIB, VRInputHandler KAEDAICECGN, KOLAIEEAMLH KABFAJJCNHG, ref bool FKJGCBMGHFK, ref Vector3 AHKHHGFPEGL)
	{
	}

	private void ACFJMCGAGNB(PlayerHand PMNLJGLDMJN, PlayerHand.ICBKGDOJNDN BNNHCJJILFB, string LBAIHDLEFFO, int NABOFKIICIB, VRInputHandler KAEDAICECGN, KOLAIEEAMLH KABFAJJCNHG, ref Vector3 AHKHHGFPEGL)
	{
	}

	private void LDCFHJAIFKF(PlayerHand PMNLJGLDMJN, PlayerHand.ICBKGDOJNDN BNNHCJJILFB, VRInputHandler KAEDAICECGN, string LBAIHDLEFFO)
	{
	}

	private void CIEBLHHKGBH(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, VRInputHandler KAEDAICECGN, KOLAIEEAMLH KABFAJJCNHG)
	{
	}

	private bool HJDNJEJMMIJ(PlayerHand PMNLJGLDMJN, VRInputHandler JLFMCCADIKH)
	{
		return false;
	}

	private Vector3 DJLCCKIILNN(VRInputHandler KAEDAICECGN, PFPHHBKDIOO JHHAOGGLGFK)
	{
		return default;
	}

	private Vector3 MOFGBHDPOCD(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, VRInputHandler KAEDAICECGN, ref Vector3 GKLBOPPMLBH)
	{
		return default;
	}

	private Vector3 LFFJKHAOLKN(float ALJPLDJDODE)
	{
		return default;
	}

	private PlayerHand.ICBKGDOJNDN OIHGADHLBJJ(float ALJPLDJDODE)
	{
		return PlayerHand.ICBKGDOJNDN.Left;
	}

	private Vector3 HEONGCIFLBA(VRInputHandler KAEDAICECGN)
	{
		return default;
	}

	private Vector3 HEONGCIFLBA(Vector3 DLOLGDANPLJ)
	{
		return default;
	}

	private Quaternion DHGCFJLFCFN(Vector3 GMABPMFJNIA, Vector3 OLLJOPPFGKK)
	{
		return default;
	}

	private void JLMAMGJOJLN(VRInputHandler KAEDAICECGN, out Vector3 DLOLGDANPLJ, out Quaternion JDIIOEJJDGK)
	{
		DLOLGDANPLJ = default;
		JDIIOEJJDGK = default;
	}

	private void GIBNNAPNJPC(Vector3 DLOLGDANPLJ, Vector3 GEBBADLDDEL, PlayerHand.ICBKGDOJNDN BNNHCJJILFB, out Vector3 IGKJCMNPMIC, out float NBMDLMENLAN, out float NNAHHDMEBBK)
	{
		IGKJCMNPMIC = default;
		NBMDLMENLAN = default;
		NNAHHDMEBBK = default;
	}

	private bool NLPOGDGHBJD(Vector3 KLOKBKPFGLL, Vector3 GEBBADLDDEL, PlayerHand.ICBKGDOJNDN BNNHCJJILFB, out Vector3 OLLJOPPFGKK, out Vector3 KNANFPGMDPO, out Collider MACBOMEMMFB)
	{
		OLLJOPPFGKK = default;
		KNANFPGMDPO = default;
		MACBOMEMMFB = null;
		return false;
	}

	private bool PDHOOFLEPGB(Vector3 KLOKBKPFGLL, Vector3 GEBBADLDDEL, Vector3 EMIBKEEBOAE, PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
	{
		return false;
	}

	private void LMHHICDBKHL()
	{
	}

	private void NFIBNJNLJLG()
	{
	}

	private void MFLBDFICHCA()
	{
	}

	private void MAPDNPAIFKP()
	{
	}

	private void NEOEEKPEDGC()
	{
	}

	private void OFLDNANMCPA()
	{
	}

	private void BLFIFLIBNIF()
	{
	}

	private void NOADJFFCJJJ()
	{
	}

	private void BOHHNIKPAFP()
	{
	}

	private void DEKPIHHLEBE()
	{
	}

	private void LEMNOIPOHDH()
	{
	}

	private bool DAIAALDLCCP()
	{
		return false;
	}

	private bool DDAJNAHJHEI()
	{
		return false;
	}

	private bool CKCEAGNBLFK()
	{
		return false;
	}

	private bool ICDOFDDDCPA()
	{
		return false;
	}

	private void MNENLHACFPM(JJPPEPEJLDD IOCHKMJLAEG, VRPlayerController BIEDNOLFJBE, PlayerFlyIndicator NIDNCLOIKCI)
	{
	}

	private bool PAEIGNOPECB(JJPPEPEJLDD IOCHKMJLAEG, VRPlayerController BIEDNOLFJBE, PlayerHand GBHOAABLEKO, VRInputHandler HDBKANLLDFE, PlayerHand BCLLPMALPJK, VRInputHandler BEPMOMADFIE, PlayerFlyIndicator NIDNCLOIKCI)
	{
		return false;
	}

	private bool LIIGPMBMHLH(PlayerHand FDEILAMGIEN, VRInputHandler CLAOHMAKDID)
	{
		return false;
	}

	private bool CKDLOABEKCO(VRInputHandler JLFMCCADIKH)
	{
		return false;
	}

	private VRInputHandler APMKEEJKNPL(VRInputHandler KAEDAICECGN)
	{
		return null;
	}

	private PlayerHand.ICBKGDOJNDN HMCIMOMCKNB(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
	{
		return PlayerHand.ICBKGDOJNDN.Left;
	}

	private void KIDLLBMNKAO()
	{
	}

	private void DJOALBKPKEH()
	{
	}

	private void FGIILABEKMP()
	{
	}

	private void JIOHEBHHCLN()
	{
	}

	private void OPCFHFJFFAD()
	{
	}

	private void DGCJEBGINEJ()
	{
	}

	private void HEOGIFOJJGM()
	{
	}

	private void BHMJEOMFJEK()
	{
	}

	private void PLABCLACIHI()
	{
	}

	private void MFLNNJHACNB()
	{
	}

	private IEnumerator<EGGPGCCKPCO> DMCPDJDNACI()
	{
		return null;
	}

	[CompilerGenerated]
	internal static float FOEGFCACFKH(Vector3 JMIGJNODJGE, float ILAOOKFPBNC)
	{
		return 0f;
	}
}
