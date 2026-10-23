using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RecRoom;
using RecRoom.Core.Locomotion;
using RecRoom.Core.Screens.PlayerController;
using UnityEngine;

public class FFDFFDDCCGC
{
	private enum IOKICPGFEMK
	{
		INVALID = 0,
		IDLE_STAND = 1,
		IDLE_CROUCH = 2,
		IDLE_PRONE = 3,
		WALK_STAND = 4,
		WALK_CROUCH = 5,
		WALK_PRONE = 6,
		JUMP = 7,
		FALL = 8,
		LAND_STAND = 9,
		LAND_CROUCH = 10,
		LAND_PRONE = 11,
		CLAMBER = 12,
		LADDER_FINISH = 13,
		FLY = 14,
		WALL_RUN = 15,
		WALL_CLIMB_CLIMB = 16,
		WALL_CLIMB_LOOK = 17,
		WALL_CLIMB_JUMP_RELEASE = 18,
		WALL_CLIMB_JUMP_REGRAB = 19,
		WALL_CLIMB_JUMP_POST = 20,
		SIT = 21
	}

	private const float AGDKGJACHII = 4f;

	private const string JLCFFKIEOOF = "PRONE_RESTRICT_TOOL_USE";

	private MDEJADHJOEJ BGBIFFLGANM;

	private DNIHEFNCPBG PJCDEDDKHOD;

	private AdditiveAnimationWeight NJLHDOBCNOF;

	private DNIHEFNCPBG EGNHAHMALPP;

	private ScreenPlayerController DHHICLJMBED;

	private Player DODHPDIHODE;

	private PlayerMovement LDGMNBHAJKE;

	private Tool PFLACCGEELM;

	private Tool ENCPGAKKEPI;

	private ScreenPlayerLocomotionAnimationContent GEEDDDDPKND;

	private float GBGLKDLNHOP;

	private float NNJFIFIPANM;

	private NMOIDHLDOMK HDKJECOELNL;

	private global::OFIKOABIHEL<IReadOnlyList<PlayerAnimationAsset>> DECHDMKODDB;

	private global::OFIKOABIHEL<IReadOnlyList<PlayerAnimationAsset>> GNOPCBMAAOH;

	private PlayerAnimation PAGBPKJLGAP;

	private PlayerAnimation ECHOHDKEMEM;

	private float CHHPKICDCKA;

	private DynamicBlendedPlayerAnimationData KNCKHLIOOPK;

	private DynamicBlendedPlayerAnimationData JAIBMHPGDFK;

	private DynamicBlendedPlayerAnimationData HPGCCKDFGIJ;

	private DNNIIIAOBEC MBDFECALJKO;

	private float GBBNHKGKOPO;

	private float CIEOPHLKNMB;

	private float BHHHPACLMOB;

	private float GBLIPMNEGLH;

	private bool HNNMNAOFGDE;

	private readonly CNHEOBEGMKA AEAAIJGPBHM;

	private DynamicBlendedPlayerAnimationData CEGIPHLDJHH;

	private DNNIIIAOBEC FKLKJGIBJLK;

	private readonly object CMCLBHEDDEF;

	public void IHEKMEOIBOI(ScreenPlayerLocomotionAnimationContent GJNKHFLDKHK)
	{
	}

	public NMOIDHLDOMK CDJHKCNAIKI(ScreenPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, float GGEPGCNHMDB, float OKBAJEAPIHG)
	{
		return default;
	}

	public void PAKIMOKGMBI()
	{
	}

	private void MBODKHGMAPH()
	{
	}

	private void OGEAHEMIKKE()
	{
	}

	private void APACBKKICHJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void GPLBOHJMBGP()
	{
	}

	private void IFBIOKPJDOH(out BEEOOBLCDOB KJNNONPENPP, out BEEOOBLCDOB LLMJMIKBEGN, out AdditiveAnimationWeight KNHHKDCBMFP, out BEEOOBLCDOB EMJPPNENJBK)
	{
		KJNNONPENPP = default;
		LLMJMIKBEGN = default;
		KNHHKDCBMFP = default;
		EMJPPNENJBK = default;
	}

	private void ENEFJGPIBJO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void EBDHBOIMNLL()
	{
	}

	private void HKKBFJAFHKK(out BEEOOBLCDOB GJOBKJCPIHP, out BEEOOBLCDOB KJNNONPENPP, out BEEOOBLCDOB LLMJMIKBEGN, out AdditiveAnimationWeight KNHHKDCBMFP, out BEEOOBLCDOB EMJPPNENJBK)
	{
		GJOBKJCPIHP = default;
		KJNNONPENPP = default;
		LLMJMIKBEGN = default;
		KNHHKDCBMFP = default;
		EMJPPNENJBK = default;
	}

	private bool LINJLFPLLDJ()
	{
		return false;
	}

	private void EFFEEGOBDDC(out BEEOOBLCDOB KIEAOEBGDOI, out BEEOOBLCDOB EBPPBFHOFKI, out BEEOOBLCDOB EMJPPNENJBK)
	{
		KIEAOEBGDOI = default;
		EBPPBFHOFKI = default;
		EMJPPNENJBK = default;
	}

	private void NBCOKLLHOOI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void CNEFNDKCAHP()
	{
	}

	private void ACHLAKIIMPE()
	{
	}

	private void GMENBCKFMDF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void GAPDJOLCBHI()
	{
	}

	private void POLBMIMGGDH(out BEEOOBLCDOB GJOBKJCPIHP, out BEEOOBLCDOB KJNNONPENPP, out BEEOOBLCDOB LLMJMIKBEGN, out AdditiveAnimationWeight KNHHKDCBMFP, out BEEOOBLCDOB EMJPPNENJBK)
	{
		GJOBKJCPIHP = default;
		KJNNONPENPP = default;
		LLMJMIKBEGN = default;
		KNHHKDCBMFP = default;
		EMJPPNENJBK = default;
	}

	private void KDGHCDDGBNF()
	{
	}

	private void FEGFCPPKOFO(out BEEOOBLCDOB KJNNONPENPP, out BEEOOBLCDOB LLMJMIKBEGN, out AdditiveAnimationWeight KNHHKDCBMFP, out BEEOOBLCDOB EMJPPNENJBK)
	{
		KJNNONPENPP = default;
		LLMJMIKBEGN = default;
		KNHHKDCBMFP = default;
		EMJPPNENJBK = default;
	}

	private void PMPCDAOKEFH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void DMENAPFHKIG(ushort NMDMMMGPDNC, ushort EDNNIIPAKCK)
	{
	}

	private void CONDJMHIDHE()
	{
	}

	private void AFGACKBLDBD()
	{
	}

	private void NKKEKHOHNPG(out BEEOOBLCDOB KJNNONPENPP, out BEEOOBLCDOB LLMJMIKBEGN, out BEEOOBLCDOB GJOBKJCPIHP, out AdditiveAnimationWeight KNHHKDCBMFP, out BEEOOBLCDOB EMJPPNENJBK)
	{
		KJNNONPENPP = default;
		LLMJMIKBEGN = default;
		GJOBKJCPIHP = default;
		KNHHKDCBMFP = default;
		EMJPPNENJBK = default;
	}

	private bool NGHCHCGLAIB()
	{
		return false;
	}

	private void ICOACILNMEB()
	{
	}

	private void NIFCGJMDEBE()
	{
	}

	private void LIBHODPFGDF()
	{
	}

	private void BAGFFIOBIJG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void PFGKLKGNIMM()
	{
	}

	private void JFDONIKFAGO(out BEEOOBLCDOB KJNNONPENPP, out BEEOOBLCDOB LLMJMIKBEGN, out AdditiveAnimationWeight KNHHKDCBMFP)
	{
		KJNNONPENPP = default;
		LLMJMIKBEGN = default;
		KNHHKDCBMFP = default;
	}

	private void FAKNIEFDGNB(out BEEOOBLCDOB KJNNONPENPP, out BEEOOBLCDOB LLMJMIKBEGN, out AdditiveAnimationWeight KNHHKDCBMFP, out BEEOOBLCDOB EMJPPNENJBK)
	{
		KJNNONPENPP = default;
		LLMJMIKBEGN = default;
		KNHHKDCBMFP = default;
		EMJPPNENJBK = default;
	}

	private void EDJLPBOBMDP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void AKDECCKEJKL()
	{
	}

	private void MGAMMKGOIFO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void EEJIDPFGFCO()
	{
	}

	private void FIMEHPCBABG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void HKHOGAACPLB()
	{
	}

	private void FHEKGJFMDDD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void NFDAJDANFKK()
	{
	}

	private void DAEAPDMALOP(JHIKPIHAJLC HBBIMKHGCOK, CIILFFLGMCL AEJOLGDBIHA, out DNIHEFNCPBG CKPMAHHPKPD, out bool GGKEGBJCCJF, out bool IJBHJBNBAPK)
	{
		CKPMAHHPKPD = null;
		GGKEGBJCCJF = default;
		IJBHJBNBAPK = default;
	}

	private void GHJPPMMFFPL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void FNDCCCPFCOO()
	{
	}

	private void LGJIPOMGDJD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void AOGAPBJPGDP()
	{
	}

	private void ECPJJJNMFNJ(bool GBDPKPIDEDF, out BEEOOBLCDOB KJNNONPENPP, out BEEOOBLCDOB LLMJMIKBEGN, out BEEOOBLCDOB EMJPPNENJBK, out AdditiveAnimationWeight KNHHKDCBMFP)
	{
		KJNNONPENPP = default;
		LLMJMIKBEGN = default;
		EMJPPNENJBK = default;
		KNHHKDCBMFP = default;
	}

	private void LMECMNOKHOP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void EKOCABJJIOL()
	{
	}

	private void LNGNJDPONLC()
	{
	}

	private void IKMHGMGBPHK(out DNIHEFNCPBG GJOBKJCPIHP, out bool KNMILELNMFH, out AdditiveAnimationWeight KNHHKDCBMFP)
	{
		GJOBKJCPIHP = null;
		KNMILELNMFH = default;
		KNHHKDCBMFP = default;
	}

	private void CCIJEKMDOMN()
	{
	}

	private float EPEAFHDDJEN(Vector3 HLFIBIDOLEF, Vector3 OLLJOPPFGKK)
	{
		return 0f;
	}

	private void ADPBEDACMLK(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void CBBCKJDPDGA()
	{
	}

	private void GHMJOFGDEAE(bool MJKDJGNHEDB, out DNIHEFNCPBG KJNNONPENPP, out DNIHEFNCPBG LLMJMIKBEGN, out bool AKMFPNLFCHM, out bool KCCDCOPJCNL, out AdditiveAnimationWeight KNHHKDCBMFP)
	{
		KJNNONPENPP = null;
		LLMJMIKBEGN = null;
		AKMFPNLFCHM = default;
		KCCDCOPJCNL = default;
		KNHHKDCBMFP = default;
	}

	private void NGJIAIAACEG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void ELBOBLPNLJH()
	{
	}

	private void JBNCILNIILD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void ADAKFKCDPOC()
	{
	}

	private void EAMJDMIBENG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void OHFIJAIAJBF()
	{
	}

	private void JDGPJDEOJAB(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void NCMLLFEGGLH()
	{
	}

	private void DDGPHECPBPN(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void AOKJHALEPNG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void EGELKKHHLHC()
	{
	}

	private void CMMFEMMOPGL(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private DNIHEFNCPBG BHKJDEACLKA()
	{
		return null;
	}

	private DNIHEFNCPBG JNFMKAMALCI()
	{
		return null;
	}

	private bool BFHBNJGJEPA(PlayerAnimation KMLHIOFJOIJ)
	{
		return false;
	}

	private void JNDFIMHIIDN()
	{
	}

	private PlayerAnimation CKMPPCMJNJA()
	{
		return null;
	}

	private global::OFIKOABIHEL<IReadOnlyList<PlayerAnimationAsset>> ICDHBGMNHMN(ScreenPlayerLocomotionAnimationContent.FidgetWeights ILENOIDKNFE)
	{
		return null;
	}

	private BEEOOBLCDOB PCOLNLGEOJF(DNIHEFNCPBG EMJPPNENJBK, bool KDBJBKJGEBM)
	{
		return default;
	}

	private void PILLCCEEGMG(out BEEOOBLCDOB KJNNONPENPP, out BEEOOBLCDOB LLMJMIKBEGN)
	{
		KJNNONPENPP = default;
		LLMJMIKBEGN = default;
	}

	private BEEOOBLCDOB PILLCCEEGMG(Tool DMEHNKDLHAC)
	{
		return default;
	}

	private bool EMFKEKOHCKG(DNIHEFNCPBG CKPMAHHPKPD, out float BBGNJMKOHPL)
	{
		BBGNJMKOHPL = default;
		return false;
	}

	private IOKICPGFEMK BMADDNPHIGC()
	{
		return IOKICPGFEMK.INVALID;
	}

	private void KFGGILLHJNK(IOKICPGFEMK DADHJJNJEFA)
	{
	}

	private static bool COAPPCKLDFE(ushort LMLDKMMPDFD)
	{
		return false;
	}

	private static bool COAPPCKLDFE(IOKICPGFEMK DADHJJNJEFA)
	{
		return false;
	}

	private void IINIDHGJBJK(DNIHEFNCPBG GJOBKJCPIHP, bool KNMILELNMFH, AdditiveAnimationWeight KNHHKDCBMFP)
	{
	}

	private void IINIDHGJBJK(DNIHEFNCPBG GJOBKJCPIHP, bool KNMILELNMFH, BEEOOBLCDOB EMJPPNENJBK, AdditiveAnimationWeight KNHHKDCBMFP)
	{
	}

	private void IINIDHGJBJK(BEEOOBLCDOB HACFFMEGICB, AdditiveAnimationWeight KNHHKDCBMFP)
	{
	}

	private void IINIDHGJBJK(BEEOOBLCDOB HACFFMEGICB, BEEOOBLCDOB EMJPPNENJBK, AdditiveAnimationWeight KNHHKDCBMFP)
	{
	}

	private void NFJMIPAKOMN(DNIHEFNCPBG KJNNONPENPP, DNIHEFNCPBG LLMJMIKBEGN, bool AKMFPNLFCHM, bool KCCDCOPJCNL, AdditiveAnimationWeight KNHHKDCBMFP)
	{
	}

	private void NFJMIPAKOMN(DNIHEFNCPBG KJNNONPENPP, DNIHEFNCPBG LLMJMIKBEGN, bool AKMFPNLFCHM, bool KCCDCOPJCNL, BodyAnimationMask ODKMDPPLHCI, BodyAnimationMask MJEAFFJKPGE, BEEOOBLCDOB EMJPPNENJBK, AdditiveAnimationWeight KNHHKDCBMFP)
	{
	}

	private void NFJMIPAKOMN(BEEOOBLCDOB BCLLPMALPJK, BEEOOBLCDOB GBHOAABLEKO, AdditiveAnimationWeight KNHHKDCBMFP)
	{
	}

	private void NFJMIPAKOMN(BEEOOBLCDOB BCLLPMALPJK, BEEOOBLCDOB GBHOAABLEKO, BEEOOBLCDOB EMJPPNENJBK, AdditiveAnimationWeight KNHHKDCBMFP)
	{
	}

	private void NDFKBAIMBFO(DNIHEFNCPBG CKPMAHHPKPD, bool KNMILELNMFH, AdditiveAnimationWeight KNHHKDCBMFP)
	{
	}

	private void PBCNFIOMHMH(DNIHEFNCPBG CKPMAHHPKPD, AdditiveAnimationWeight KNHHKDCBMFP)
	{
	}

	[CompilerGenerated]
	private IOKICPGFEMK KAIIHEAEGHP()
	{
		return IOKICPGFEMK.INVALID;
	}
}
