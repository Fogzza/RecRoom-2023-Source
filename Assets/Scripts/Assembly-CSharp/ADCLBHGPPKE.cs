using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RecRoom;
using RecRoom.Core.Controllers.ScreenBehaviors;
using RecRoom.Core.Gestures;
using UnityEngine;

public abstract class ADCLBHGPPKE<Runtime, Config> : global::NJHDFCIBDLG<Runtime, Config> where Runtime : global::ADCLBHGPPKE<Runtime, Config>, new() where Config : GestureBaseScreenPlayerBehaviorConfig<Runtime, Config>
{
	public class PKKDBDDFBCH
	{
		public Player EKOFNPFCLMO;

		public bool AFNBLBDDBJL;

		public bool NFEGKABFHBC;

		public PlayerHand.ICBKGDOJNDN[] HHPCFKGNDPK;
	}

	private enum CPONAAJAJBC
	{
		DISABLED = 0,
		IDLE = 1,
		OFFERING = 2,
		OFFER_RUNNING = 3,
		ACCEPT_RUNNING = 4
	}

	[StructLayout((LayoutKind)3)]
	private struct NEJNECGBHCG
	{
		public PlayerHand.ICBKGDOJNDN[] supportedHands;

		public global::ADCLBHGPPKE<Runtime, Config> _003C_003E4__this;
	}

	[StructLayout((LayoutKind)3)]
	private struct POPOJOFDCEM
	{
		public PlayerHand.ICBKGDOJNDN[] supportedHands;
	}

	private readonly PlayerHand.ICBKGDOJNDN[] DFMJANAOECD;

	private const float EAJGFIJGPEP = 0.5f;

	private const float KLJFEBILINO = 1f;

	private const float HHLHPNJODAB = 1f;

	private const float OIGDAKKIDKC = 35f;

	private const float CMDDHCKLIDJ = 90f;

	private const float ILIKODMFEAM = 45f;

	private MDEJADHJOEJ BGBIFFLGANM;

	private bool KIEIGNLPDEN;

	private readonly OBLFPAAMGKM HAKINKFAIOF;

	private readonly CBJIHCIDPGO NIGFPPLNACF;

	private NEJPICDKICB MKCBMEKAFLA;

	private NEJPICDKICB DFNCIPFCNDC;

	private PKKDBDDFBCH HCGFMFLGHHL;

public PKKDBDDFBCH IIKOHPJGHNN
{
get 	{
		return null;
	}

private set {
	}
}

public Player NPPNNHHAGCJ
{
get 	{
		return null;
	}

}

protected abstract ScreenPlayerController.OKKOMNMEDEH BGIIHPLAHAF
{
get ;
}

protected abstract bool MBFDHGILDFE
{
get ;
}

protected abstract PlayerHandGestures.NAHIAFFDEIO CAIGPHIHBBF
{
get ;
}

protected FMNJCGLEDJO NDNDFIFBCEI
{
get 	{
		return FMNJCGLEDJO.SmartInteractButton;
	}

}

protected FMNJCGLEDJO PDNFOAIJBPO
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

private bool BGDENLDMHFC
{
get 	{
		return false;
	}

}

protected bool LIMFJDDOHBI
{
get 	{
		return false;
	}

}

protected bool OAGADLDKBII
{
get 	{
		return false;
	}

}

protected bool IEFALMHMKJK
{
get 	{
		return false;
	}

}

protected bool IGLBMBLNJAL
{
get 	{
		return false;
	}

}

protected bool HHBFLNLCGMH
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

protected abstract GHCICEFBOGM FMJLFILCDBD
{
get ;
}

protected virtual bool KMHCAOIPNDO
{
get 	{
		return false;
	}

}

	public override void IHEKMEOIBOI(Config FPJKGKBOAOA, AJBBKCCIBGF HJOOFGLHNBG)
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

	public override void EHMICKMBCPH()
	{
	}

	protected abstract bool NPNBJBCDLAN(Player EKOFNPFCLMO, out bool AFNBLBDDBJL, out bool NFEGKABFHBC, out PlayerHand.ICBKGDOJNDN[] HHPCFKGNDPK);

	protected abstract void ONJPLFOHPPK(Player EKOFNPFCLMO, bool NFEGKABFHBC, bool BHMPELIPIKB);

	protected abstract void PMEIPJFPGII();

	protected abstract void CMIDHACKGNN();

	protected abstract bool GPBGBOLCOHH();

	private void DHKNKKFJNMC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void KHCLBMBFPLC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void MPBJLGJNLMD()
	{
	}

	private void JDBOLOHPFEF(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void KMELJPHEPAC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void EIIPEKIBOCF()
	{
	}

	private void CPKKMCCJEJC(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void ACDLBLHEBBP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void CHHAOMLGIHN()
	{
	}

	private void KBPGNJJBPPG(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void ACJFLPLFDHM(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void FKJANGIEHJC()
	{
	}

	private void KKNHOCMLPML(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void CIHPPALMCBJ(Player PLNGHFIMCDB)
	{
	}

	private bool FHAHEMHJJFB()
	{
		return false;
	}

	private void MKKBCLGNOPI(bool GEJLCKEMMDI = false)
	{
	}

	private void IJEEMFDEDDK()
	{
	}

	private void LCLFHIFGCEM()
	{
	}

	private void PMIIPJFKEFC()
	{
	}

	private void KFLNPIDLKDK()
	{
	}

	private void OAJCGDFLOCG()
	{
	}

	private void DOFJBKJLPHN()
	{
	}

	private bool KHPCLHHHDBH(PlayerHand.ICBKGDOJNDN[] HHPCFKGNDPK)
	{
		return false;
	}

	private bool FKHAHHEEKJC(PlayerHand.ICBKGDOJNDN[] HHPCFKGNDPK)
	{
		return false;
	}

	private void FMKELECNAMH(GHCICEFBOGM GBNJJMNDNAA)
	{
	}

	private void HIJHLNIHOOB()
	{
	}

	protected void LMFCKJFCDHP()
	{
	}

	private void IPABFPOACCP(Player EKOFNPFCLMO)
	{
	}

	private void IOPCAKEGPJN()
	{
	}

	private void KEBADMFHLML()
	{
	}

	private void KPILCJBJMCF()
	{
	}

	private Player IPNEPHCHDMD()
	{
		return null;
	}

	private static bool KKPIOKGOGBM(Player KLAKFKJEIKL, Player CBDPEOAABOH, Vector3 EOAGOBCKFAJ, float GDIENBGMGIB)
	{
		return false;
	}

	private void GDEOAJJOJBA(out Vector3 GAPJHPHLEME, out Vector3 IJKJDAMLMMG)
	{
		GAPJHPHLEME = default;
		IJKJDAMLMMG = default;
	}

	private void MBOKALKNAAH()
	{
	}

	private bool NFJMHONAGIG()
	{
		return false;
	}

	private void LMLAJHCIAPM(PlayerHand OHBLJLMCFNC, PlayerHand HKOFDEKJKIH, PlayerHandGestures.NAHIAFFDEIO AEBIACPKIKH, Player JMONNCKMMIO, Player LJAGFDGOADG)
	{
	}

	private void LHJMILHIFFL()
	{
	}

	private void LAIMFPEOIMJ()
	{
	}

	private void EHGMLPLHJAK(string OFCFPGACNJB)
	{
	}

	[CompilerGenerated]
	private bool MCBCMMCGDKA(PlayerHand PMNLJGLDMJN, ref NEJNECGBHCG P_1)
	{
		return false;
	}

	[CompilerGenerated]
	private static bool JLDBAFBNOBF(PlayerHand PMNLJGLDMJN, ref POPOJOFDCEM P_1)
	{
		return false;
	}
}
