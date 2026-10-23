using System.Runtime.CompilerServices;
using RecRoom;
using RecRoom.Core;
using RecRoom.Core.Controllers.ScreenBehaviors;
using RecRoom.Core.Creation;
using RecRoom.Tools;
using UnityEngine;

public class MAKLDLJIMFP : global::PKMKGBILFKD<MAKLDLJIMFP, MakerPenScreenToolBehaviorConfig>
{
	private enum PGIHMOGGCAM
	{
		DISABLED = 0,
		RESTRICTED = 1,
		GAMEPLAY = 2,
		MENU = 3
	}

	private enum HCOMNGCCEFF
	{
		NONE = 0,
		MOVE_REQUEST = 1,
		UNITY_STYLE = 2,
		ROTATION = 3,
		SELECTION = 4
	}

	private sealed class HCBKLCALIJB
	{
		public CreationController CreationController;

		internal void _003CGatherAvailableContextActionsShim_003Eb__7()
		{
		}

		internal void _003CGatherAvailableContextActionsShim_003Eb__8()
		{
		}

		internal void _003CGatherAvailableContextActionsShim_003Eb__9()
		{
		}

		internal void _003CGatherAvailableContextActionsShim_003Eb__10()
		{
		}

		internal void _003CGatherAvailableContextActionsShim_003Eb__11()
		{
		}

		internal void _003CGatherAvailableContextActionsShim_003Eb__12()
		{
		}

		internal global::NCOKFFGPIJM<string> _003CGatherAvailableContextActionsShim_003Eb__1()
		{
			return null;
		}

		internal global::NCOKFFGPIJM<string> _003CGatherAvailableContextActionsShim_003Eb__2()
		{
			return null;
		}

		internal global::NCOKFFGPIJM<string> _003CGatherAvailableContextActionsShim_003Eb__3()
		{
			return null;
		}

		internal global::NCOKFFGPIJM<string> _003CGatherAvailableContextActionsShim_003Eb__4()
		{
			return null;
		}

		internal global::NCOKFFGPIJM<string> _003CGatherAvailableContextActionsShim_003Eb__5()
		{
			return null;
		}

		internal global::NCOKFFGPIJM<string> _003CGatherAvailableContextActionsShim_003Eb__6()
		{
			return null;
		}

		internal void _003CGatherAvailableContextActionsShim_003Eb__17()
		{
		}

		internal void _003CGatherAvailableContextActionsShim_003Eb__18()
		{
		}

		internal void _003CGatherAvailableContextActionsShim_003Eb__19()
		{
		}

		internal void _003CGatherAvailableContextActionsShim_003Eb__20()
		{
		}

		internal global::NCOKFFGPIJM<string> _003CGatherAvailableContextActionsShim_003Eb__13()
		{
			return null;
		}

		internal global::NCOKFFGPIJM<string> _003CGatherAvailableContextActionsShim_003Eb__14()
		{
			return null;
		}

		internal global::NCOKFFGPIJM<string> _003CGatherAvailableContextActionsShim_003Eb__15()
		{
			return null;
		}

		internal global::NCOKFFGPIJM<string> _003CGatherAvailableContextActionsShim_003Eb__16()
		{
			return null;
		}

		internal global::NCOKFFGPIJM<string> _003CGatherAvailableContextActionsShim_003Eb__0()
		{
			return null;
		}
	}

	private sealed class JCBIKAFCDLA
	{
		public CreationController CreationController;

		internal void _003CTryFinishInvention_003Eb__0()
		{
		}
	}

	private sealed class NHILHGHIGMD
	{
		public CreationController cc;

		public Vector3 offset;

		public MMMPKIMPKKC shapeCreationContext;

		internal void _003CCloneShapeSelection_003Eb__0()
		{
		}
	}

	private sealed class AJAIIGIJNHC
	{
		public CreationContext creationContext;

		public Vector3 offset;

		public CreationController cc;

		internal void _003CCloneObjectSelection_003Eb__0()
		{
		}
	}

	private sealed class ANEHJIJNNAI
	{
		public ECMNCNMENKO undoEntry;

		public DHJLEHBOGBG[] cachedSelection;

		public CreationController cc;

		public AHCBMDMIAAM cachedActiveGroup;

		internal void _003CDeleteSelection_003Eb__0(GAMIBKOFAAE data)
		{
		}

		internal void _003CDeleteSelection_003Eb__1()
		{
		}
	}

	private readonly string PHKMLFAMBNB;

	private readonly string HKIAHLPFPIB;

	private const float AAIALMICFHH = 0.3f;

	private const float FMEMJPGHFCL = 1f;

	private MDEJADHJOEJ BGBIFFLGANM;

	private KKHFFLBNJPD JFCMCEGIFHJ;

	private KKHFFLBNJPD EGLLOMHDCDE;

	private MakerPen BHCCDMJFHEO;

	private WeightedPlayerAnimationData LEADAMKOHDA;

	private readonly CNHEOBEGMKA NCGFGGJIEDL;

	private readonly CBJIHCIDPGO EEJBBNKCAIL;

	private readonly MGGGBALGBJI MFMALOBGCKG;

	private readonly FKGIPMHKAEH NNKKGEHGCKK;

	private readonly FMFPOOAIEKE DPIOGIFLBDO;

	private NEJPICDKICB DFCPCPLPNFC;

	private NEJPICDKICB LHCLHOOHKBD;

	private NEJPICDKICB NKMJACMGCPL;

	private float ELELKHHGJPI;

	private float BFBLGOKMBLK;

	private HCOMNGCCEFF PPNKHINEJBM;

	private float KLOHLOONKHK;

	private DHJLEHBOGBG[] DCBIDHJOBDB;

	private bool NMBCJJPNMPO;

	private int GCOKBOJFPEK;

	private bool KMDKAEOJMJM;

	private JNODIIINKKJ.PBDGIEELIHN[] PCDGBLNGALD;

private float MPOPAFADGJH
{
get 	{
		return 0f;
	}

set {
	}
}

public int IDHAEHGKOGC
{
get 	{
		return 0;
	}

}

private ScreenPlayerController.OKKOMNMEDEH FABHACPGEOK
{
get 	{
		return ScreenPlayerController.OKKOMNMEDEH.DEFAULT;
	}

}

private FMNJCGLEDJO JBMFJHCBENC
{
get 	{
		return FMNJCGLEDJO.SmartInteractButton;
	}

}

private FMNJCGLEDJO LPFAEGMPCBP
{
get 	{
		return FMNJCGLEDJO.SmartInteractButton;
	}

}

private bool LMFOEFPLKOF
{
get 	{
		return false;
	}

}

public override bool HFDBOJHHDHK
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

	public override void IHEKMEOIBOI(MakerPenScreenToolBehaviorConfig FPJKGKBOAOA, KHDONLOELFG HJOOFGLHNBG)
	{
	}

	public override void Dispose()
	{
	}

	protected override void JNLNGJHMMFJ()
	{
	}

	protected override void CANDLFMBAAF()
	{
	}

	protected override void LDBOEGKIPKO()
	{
	}

	protected override void LIKPEPFGGFO()
	{
	}

	public override void EHMICKMBCPH()
	{
	}

	public override void EMKNJNEKHFE()
	{
	}

	private void DHKNKKFJNMC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void CNLOCLPCAPC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void HECDABOMKHP()
	{
	}

	private void AMCKPMDBKFF(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void JFGAOILBMIF()
	{
	}

	private void GCBABHEFKMD(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void IMCEPABJPEL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void HFHBJEAKHCO()
	{
	}

	private void DBHMHFGPGEJ(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void GEMBFCEIKHN()
	{
	}

	private void CMEHDGKLGBF()
	{
	}

	private bool IGIKNHLPJGP()
	{
		return false;
	}

	private void CLKJOIHBIME()
	{
	}

	private void HEGENLMAODF()
	{
	}

	private void AIHAIAODGIN()
	{
	}

	private void MALCDEKFBDK<T>(global::FNLEEFFPAAJ<T> DELCOFCGDFF)
	{
	}

	private void MFHLNOAAEBB()
	{
	}

	private void NKFOFEJMGLP(HCOMNGCCEFF KEJGPMMMJIK)
	{
	}

	private void FLAFNGKJNAK(bool NPPKOMNEAMM)
	{
	}

	private void OCKJMCGDOMC(bool NPPKOMNEAMM)
	{
	}

	private void KOAAPAOMFHB(bool NPPKOMNEAMM)
	{
	}

	private void OFLCOKECNAG(bool NPPKOMNEAMM)
	{
	}

	private bool CFGKAEBMHGH(Vector2 IBKIBIMNAEF)
	{
		return false;
	}

	private bool OAIMKAJIFIL(FBEHJNCKJPN DNLPIHIBJDP)
	{
		return false;
	}

	private bool CBBEDFLACJA(AECAHLPIFOC KAEDAICECGN)
	{
		return false;
	}

	private void IDCOGDFLELN()
	{
	}

	private void FBLBAPKKJLD()
	{
	}

	public static bool KOEGCPOJJCI(CreationController NIAACAALPJB)
	{
		return false;
	}

	private static global::NCOKFFGPIJM<string> IHPAOGBMLKI(CreationController NIAACAALPJB)
	{
		return null;
	}

	private void MDAFNGJACNO()
	{
	}

	private void BHOGGKAFDFO()
	{
	}

	private void PAKNDKACEON()
	{
	}

	private void JHJNCMCKJCO()
	{
	}

	private void BNEAADNGBAL()
	{
	}

	private void PIIJBGBGMPA(MakerPen BHCCDMJFHEO)
	{
	}

	private void MINAEBBLNFN()
	{
	}

	private void HHEHFKFJHBN()
	{
	}

	private bool FFGFLGCCMNH(GAMIBKOFAAE KDOHOHMMADB)
	{
		return false;
	}

	private void LBMLNIELMNH(CreationController HGGJGEGGLKA, Vector3 MOHMCFDNHKH)
	{
	}

	private void NNGMGGFAJAA(CreationController HGGJGEGGLKA, Vector3 MOHMCFDNHKH)
	{
	}

	private void CFALMLFCLMJ(CreationController HGGJGEGGLKA)
	{
	}

	private Vector3 MKHHJPODMIE(Vector3 HBNBDDOBFHD)
	{
		return default;
	}

	[CompilerGenerated]
	private void NOMGJDFMMMJ()
	{
	}

	[CompilerGenerated]
	private void MMNGOKILPIO()
	{
	}

	[CompilerGenerated]
	private void FEGKOCEPBND()
	{
	}

	[CompilerGenerated]
	private void KMACIEMPHNI()
	{
	}

	[CompilerGenerated]
	private void NBIPCLPADJB()
	{
	}

	[CompilerGenerated]
	private void IDLIBDADOMD()
	{
	}

	[CompilerGenerated]
	private void HPOLADEJHHF()
	{
	}

	[CompilerGenerated]
	private void HADKLFOKHCC()
	{
	}
}
