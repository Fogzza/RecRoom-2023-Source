using System.Collections.Generic;
using RecRoom;
using RecRoom.Core.Animation;
using RecRoom.Core.Controllers.ScreenBehaviors;
using RecRoom.Core.Screens.PlayerController;
using UnityEngine;

public class EBPLFGOHPCE : global::NJHDFCIBDLG<EBPLFGOHPCE, HandPilotScreenPlayerBehaviorConfig>
{
	private enum HENGCFNPMGK
	{
		DEACTIVATED = 0,
		IDLE = 1,
		IDLE_POSE = 2,
		IDLE_REACHING = 3,
		WAVING = 4
	}

	private enum IDJLANLKEAD
	{
		NORTH = 0,
		EAST = 1,
		SOUTH = 2,
		WEST = 3
	}

	private readonly struct EBGIIIBLLFL
	{
		public readonly FMNJCGLEDJO NJNBLOEAGLO;

		public readonly GHCICEFBOGM PKIMHMDLHKF;

		public EBGIIIBLLFL(FMNJCGLEDJO POINFDHCNCM, GHCICEFBOGM GBNJJMNDNAA)
		{
			NJNBLOEAGLO = FMNJCGLEDJO.SmartInteractButton;
			PKIMHMDLHKF = GHCICEFBOGM.None;
		}
	}

	private const float LEGCHLGHIFP = 0.0125f;

	private const float AAOHJKLLIGI = 0.05f;

	private MDEJADHJOEJ BGBIFFLGANM;

	private bool KIEIGNLPDEN;

	private int KGBOGIHCFNP;

	private Vector2 NMOECIOJOCK;

	private float ACDELMJCGBG;

	private GHCICEFBOGM ICLEDNFDDNM;

	private readonly CGOBNNIEKLB AMALMAEDIKP;

	private readonly PICMAMGICEC GAHHEHDPACE;

	private readonly CNHEOBEGMKA AFFCIJNKPCO;

	private readonly CNHEOBEGMKA KGIPACFNEJG;

	private readonly Dictionary<PlayerAnimation3DBlendedPoseSet, WeightedPlayerAnimationData> GHJBCOEOKHM;

	private readonly Dictionary<IDJLANLKEAD, EBGIIIBLLFL> HMLHLLGIAGP;

	private readonly Dictionary<IDJLANLKEAD, EBGIIIBLLFL> GLMDJGLDEAN;

	private NEJPICDKICB BNOBAOKIHEN;

	private NEJPICDKICB BOJMJGOOEMG;

	private NEJPICDKICB ICLHIHIGCKG;

	private NEJPICDKICB MMHLMDJLDAF;

	private NEJPICDKICB HMNMDGCMCMF;

	private NEJPICDKICB PJNBEIFBKFF;

	private NEJPICDKICB EIMCNACFLLM;

private bool HOFBDILGDBG
{
get 	{
		return false;
	}

}

private bool LAKAKHPMDFA
{
get 	{
		return false;
	}

}

private bool PFDMJJGBLEH
{
get 	{
		return false;
	}

}

private bool GKLIGODNGMG
{
get 	{
		return false;
	}

}

public override int LDHIBGALEDK
{
get 	{
		return 0;
	}

}

public override bool HFDBOJHHDHK
{
get 	{
		return false;
	}

}

private FMNJCGLEDJO OBDLNBICAPA
{
get 	{
		return FMNJCGLEDJO.SmartInteractButton;
	}

}

private FMNJCGLEDJO ANLGLOKOCFP
{
get 	{
		return FMNJCGLEDJO.SmartInteractButton;
	}

}

private FMNJCGLEDJO GKAMOHPONLI
{
get 	{
		return FMNJCGLEDJO.SmartInteractButton;
	}

}

private FMNJCGLEDJO NODJNLJAGAN
{
get 	{
		return FMNJCGLEDJO.SmartInteractButton;
	}

}

private bool DICCBNPOAHO
{
get 	{
		return false;
	}

}

	public override void IHEKMEOIBOI(HandPilotScreenPlayerBehaviorConfig FPJKGKBOAOA, AJBBKCCIBGF HJOOFGLHNBG)
	{
	}

	public override void Dispose()
	{
	}

	protected override void LDBOEGKIPKO()
	{
	}

	protected override void LIKPEPFGGFO()
	{
	}

	protected override void JNLNGJHMMFJ()
	{
	}

	protected override void CANDLFMBAAF()
	{
	}

	public override void EHMICKMBCPH()
	{
	}

	public override void EMKNJNEKHFE()
	{
	}

	private void MNKHGBOHGJL(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void KHCLBMBFPLC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void MPBJLGJNLMD()
	{
	}

	private void JDBOLOHPFEF(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void BADCEMANOEM(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void EBNBFFFMHJL()
	{
	}

	private void HCOMGMOPGHO(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void CJNPPOAGKFM(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void AMGJHKAINEN()
	{
	}

	private void CJJJCNHKPLP(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void KFNBCLEANIG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void FAOGHDHFOKF()
	{
	}

	private void CIEOFGJGLPJ(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private bool EBPMIDNFOPG(HENGCFNPMGK DADHJJNJEFA)
	{
		return false;
	}

	private void GGPDGIPIPDE(GHCICEFBOGM GBNJJMNDNAA, PlayerHand.CJJEEOGMEAB LAGADKBKLAD = PlayerHand.CJJEEOGMEAB.ScreensWavingActive)
	{
	}

	private void IBOKLELGKGL()
	{
	}

	private void NKMLHBLKEFE(GHCICEFBOGM AEBIACPKIKH)
	{
	}

	private void PFEAPLDANCI()
	{
	}

	private void NFAKGFKAMMJ()
	{
	}

	private NEJPICDKICB CLPGGHBMCCJ(IDJLANLKEAD HLFIBIDOLEF)
	{
		return null;
	}

	private EBGIIIBLLFL COCAMKAAEHL(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, IDJLANLKEAD HLFIBIDOLEF)
	{
		return default;
	}

	private bool NIBJHHMPGKF(out GHCICEFBOGM IJHEFDFGAKL)
	{
		IJHEFDFGAKL = default;
		return false;
	}

	private void OHOIBDNHJHL(out Vector2 NBNKGHOAMBN, out float PAPOLBGDDGH)
	{
		NBNKGHOAMBN = default;
		PAPOLBGDDGH = default;
	}

	private bool EMEEKIFJMJD()
	{
		return false;
	}

	private float IPMLNEINMCP()
	{
		return 0f;
	}

	private bool NKCPNGIHECA()
	{
		return false;
	}

	private bool NKCPNGIHECA(out bool CNAHDJGNHOO)
	{
		CNAHDJGNHOO = default;
		return false;
	}

	private bool CAIOOAEDPIC()
	{
		return false;
	}

	private bool LPMAIFGICGE(out Vector2 NBNKGHOAMBN)
	{
		NBNKGHOAMBN = default;
		return false;
	}

	private bool MEFMKOGEKBI()
	{
		return false;
	}

	private void NFJMHONAGIG(bool EFCAKBLNFLO)
	{
	}

	private void FLNDPOJFLJO(bool EPDJDCDHLMP)
	{
	}

	private static Sprite LBKMDIGJFEF(GHCICEFBOGM EPKIAECHKFB)
	{
		return null;
	}

	private void LBCFBMMDAGL(Vector2 POMDPPLEHNN, float GHAEOKNIJON)
	{
	}

	private HandPilotingAnimationPoseSet DCBNFNEIEON()
	{
		return null;
	}

	private HandPilotingAnimationPoseSet JDGAOCFOKID()
	{
		return null;
	}

	private WeightedPlayerAnimationData GNAGGHEKFPC(PlayerAnimation3DBlendedPoseSet LPKMEBJKNCG)
	{
		return null;
	}

	private void AFDLFEFEPLN(HandPilotingAnimationPoseSet LPKMEBJKNCG, float ELGHOKJOEIN, Vector2 NMAGMDGFFHF)
	{
	}

	private void KBPDPJEAGIG(bool OELEGABGDMD, bool IAKMCEAGFJB)
	{
	}

	private void PMIIPJFKEFC()
	{
	}

	private bool HHJOMONKLAB()
	{
		return false;
	}

	private ILKAJHIJEJK GOGLAJNDAJJ(ILKAJHIJEJK CDPFBDBELHI, bool AOIDMDIPBFG)
	{
		return default;
	}

	private Vector3 LBHCGALDPKO(Vector3 LCBKNABBHBN, Vector3 JKGCPMJEEOO)
	{
		return default;
	}

	private Vector3 DDBFJBLAKDF(Vector3 MOHMCFDNHKH)
	{
		return default;
	}

	private float BKFGKDKFCMP()
	{
		return 0f;
	}
}
