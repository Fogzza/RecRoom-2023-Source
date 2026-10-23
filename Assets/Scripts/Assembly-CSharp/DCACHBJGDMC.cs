using System.Collections.Generic;
using UnityEngine;

public static class DCACHBJGDMC
{
	public enum KFFIOAHCGCJ
	{
		MISS = 0,
		HIT = 1,
		OVERLAP = 2
	}

	public enum ENAKFGOOAHI
	{
		WALL = 0,
		FLOOR = 1,
		CEILING = 2
	}

	public delegate bool KFCPKPOOIKD(Collider ADMCDJKKCIA);

	public delegate bool HHJPDONAACI(Collider ADMCDJKKCIA, List<Collider> GEEGNLOGPDI);

	public const float BCMGIMHAOHI = 0.001f;

	public const float EAOPGBBGHEI = 45f;

	private const float MEBMPLBGJLG = 0.0001f;

	private static readonly Collider[] GMJIGIKAFIA;

	private static readonly Collider[] AOBNEHEGDIP;

	private static readonly RaycastHit[] PBILDBGHEPM;

	private static SphereCollider MIAJHMEOLOD;

	private static CapsuleCollider ILGHFHPFIJO;

	private static BoxCollider HAEBLPHDCGK;

public static int NBEEKPEEJJC
{
get 	{
		return 0;
	}

}

public static Collider[] KFIGGJICFDA
{
get 	{
		return null;
	}

}

private static SphereCollider PKDOGNJNBHI
{
get 	{
		return null;
	}

}

private static CapsuleCollider NDEHEAJIAMO
{
get 	{
		return null;
	}

}

private static BoxCollider FIHKCPBAAEP
{
get 	{
		return null;
	}

}

	private static T DNMHPLJAJBF<T>(string KNOPFGAGMCN) where T : Collider
	{
		return null;
	}

	public static KFFIOAHCGCJ KHDIAAGJBJI(Vector3 PEJEOHJJKBA, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, int MPJGCPAKKKA, out RaycastHit KHFHAAMKDHD)
	{
		KHFHAAMKDHD = default;
		return KFFIOAHCGCJ.MISS;
	}

	public static KFFIOAHCGCJ KHDIAAGJBJI(Vector3 PEJEOHJJKBA, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, int MPJGCPAKKKA, KFCPKPOOIKD HNGJGPJCNBJ, out RaycastHit KHFHAAMKDHD)
	{
		KHFHAAMKDHD = default;
		return KFFIOAHCGCJ.MISS;
	}

	public static KFFIOAHCGCJ KHDIAAGJBJI(Vector3 PEJEOHJJKBA, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, int MPJGCPAKKKA, KFCPKPOOIKD HNGJGPJCNBJ, QueryTriggerInteraction JKDFLHPFIEF, out RaycastHit KHFHAAMKDHD)
	{
		KHFHAAMKDHD = default;
		return KFFIOAHCGCJ.MISS;
	}

	public static Vector3 OLCEOBHLIKE(Vector3 JDPJIBHABJL, float CHFEMIAABLG, float KDEPJBHMOMO, Vector3 EKBNFNAIJPG, int MPJGCPAKKKA, int IOGJINADLLM, float CLKAFJOAHAO = 0.001f)
	{
		return default;
	}

	public static Vector3 OLCEOBHLIKE(Vector3 JDPJIBHABJL, float CHFEMIAABLG, float KDEPJBHMOMO, Vector3 EKBNFNAIJPG, int MPJGCPAKKKA, int IOGJINADLLM, float CLKAFJOAHAO, out bool LKAGFGLHBMK)
	{
		LKAGFGLHBMK = default;
		return default;
	}

	public static KFFIOAHCGCJ KEPIKJLEHHK(Vector3 IMFPGCBFLIB, float CHFEMIAABLG, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, int MPJGCPAKKKA, out RaycastHit KHFHAAMKDHD)
	{
		KHFHAAMKDHD = default;
		return KFFIOAHCGCJ.MISS;
	}

	public static KFFIOAHCGCJ KEPIKJLEHHK(Vector3 IMFPGCBFLIB, float CHFEMIAABLG, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, int MPJGCPAKKKA, KFCPKPOOIKD HNGJGPJCNBJ, out RaycastHit KHFHAAMKDHD)
	{
		KHFHAAMKDHD = default;
		return KFFIOAHCGCJ.MISS;
	}

	public static bool KGNDMJIKPBE(Vector3 JDPJIBHABJL, Quaternion ECLGEEBGEPK, float CHFEMIAABLG, int MPJGCPAKKKA, KFCPKPOOIKD DEABFFHHODC, out Vector3 AIAOLAOKKIL)
	{
		AIAOLAOKKIL = default;
		return false;
	}

	public static Collider HGODAMPICON(Vector3 JDPJIBHABJL, float CHFEMIAABLG, int MPJGCPAKKKA, KFCPKPOOIKD DEABFFHHODC, QueryTriggerInteraction JKDFLHPFIEF)
	{
		return null;
	}

	public static int KNKMFAKEBBD(Vector3 JDPJIBHABJL, float CHFEMIAABLG, int MPJGCPAKKKA, KFCPKPOOIKD DEABFFHHODC, Collider[] MIJJHKEGEJI)
	{
		return 0;
	}

	public static int KNKMFAKEBBD(Vector3 JDPJIBHABJL, float CHFEMIAABLG, int MPJGCPAKKKA, KFCPKPOOIKD DEABFFHHODC, QueryTriggerInteraction JKDFLHPFIEF, Collider[] MIJJHKEGEJI)
	{
		return 0;
	}

	public static bool GIIIBNJIGKL(Vector3 JDPJIBHABJL, float CHFEMIAABLG, int MPJGCPAKKKA, KFCPKPOOIKD DEABFFHHODC)
	{
		return false;
	}

	public static bool PHIMILFLKDM(Vector3 JDPJIBHABJL, Quaternion ECLGEEBGEPK, float CHFEMIAABLG, int GECBAAKDJFA, Collider[] OBKHOHIFGJA, out Vector3 AIAOLAOKKIL)
	{
		AIAOLAOKKIL = default;
		return false;
	}

	public static KFFIOAHCGCJ GFHEEKFIFFH(Vector3 MIAAJAABHEB, Vector3 EOLMDLBOJGA, float OHBOCNDPHFA, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, int MPJGCPAKKKA, out RaycastHit KHFHAAMKDHD)
	{
		KHFHAAMKDHD = default;
		return KFFIOAHCGCJ.MISS;
	}

	public static KFFIOAHCGCJ GFHEEKFIFFH(Vector3 MIAAJAABHEB, Vector3 EOLMDLBOJGA, float OHBOCNDPHFA, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, int MPJGCPAKKKA, KFCPKPOOIKD HNGJGPJCNBJ, out RaycastHit KHFHAAMKDHD)
	{
		KHFHAAMKDHD = default;
		return KFFIOAHCGCJ.MISS;
	}

	public static KFFIOAHCGCJ GFHEEKFIFFH(Vector3 MIAAJAABHEB, Vector3 EOLMDLBOJGA, float OHBOCNDPHFA, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, int MPJGCPAKKKA, HHJPDONAACI HNGJGPJCNBJ, List<Collider> GEEGNLOGPDI, out RaycastHit KHFHAAMKDHD)
	{
		KHFHAAMKDHD = default;
		return KFFIOAHCGCJ.MISS;
	}

	public static bool LFJDNKEAJDN(Vector3 GMGMJLANNNB, Vector3 LDJIOAJODFJ, float OHBOCNDPHFA, int MPJGCPAKKKA, out Vector3 AIAOLAOKKIL)
	{
		AIAOLAOKKIL = default;
		return false;
	}

	public static bool LFJDNKEAJDN(Vector3 GMGMJLANNNB, Vector3 LDJIOAJODFJ, float OHBOCNDPHFA, int MPJGCPAKKKA, KFCPKPOOIKD DEABFFHHODC, out Vector3 AIAOLAOKKIL)
	{
		AIAOLAOKKIL = default;
		return false;
	}

	public static bool LFJDNKEAJDN(Vector3 GMGMJLANNNB, Vector3 LDJIOAJODFJ, float OHBOCNDPHFA, Collider[] MIJJHKEGEJI, int EAIIFFEKLGO, out Vector3 AIAOLAOKKIL)
	{
		AIAOLAOKKIL = default;
		return false;
	}

	public static int DNMDGEIPHEL(Vector3 GMGMJLANNNB, Vector3 LDJIOAJODFJ, float OHBOCNDPHFA, int MPJGCPAKKKA, Collider[] MIJJHKEGEJI)
	{
		return 0;
	}

	public static int DNMDGEIPHEL(Vector3 GMGMJLANNNB, Vector3 LDJIOAJODFJ, float OHBOCNDPHFA, int MPJGCPAKKKA, KFCPKPOOIKD DEABFFHHODC, Collider[] MIJJHKEGEJI)
	{
		return 0;
	}

	public static bool FMDNONNFCBN(Vector3 GMGMJLANNNB, Vector3 LDJIOAJODFJ, float OHBOCNDPHFA, int MPJGCPAKKKA, KFCPKPOOIKD DEABFFHHODC)
	{
		return false;
	}

	public static bool GKJMJHAJHNC(Vector3 OOMHEFENBOD, Quaternion BOJGAJAMLPD, float OHBOCNDPHFA, float FOLMDELMMBC, int GECBAAKDJFA, Collider[] OBKHOHIFGJA, out Vector3 AIAOLAOKKIL)
	{
		AIAOLAOKKIL = default;
		return false;
	}

	public static bool AMLJJFMNIPM(Vector3 CFMLEBMOOEC, Quaternion HBMAIAGDAFM, float OHBOCNDPHFA, float FOLMDELMMBC, int MPJGCPAKKKA, KFCPKPOOIKD DEABFFHHODC, out Vector3 AIAOLAOKKIL, int IOGJINADLLM = 10)
	{
		AIAOLAOKKIL = default;
		return false;
	}

	public static Collider DPBFPCPGMDL(Vector3 CFMLEBMOOEC, Quaternion HBMAIAGDAFM, Vector3 LGOFCCMAGBP, int MPJGCPAKKKA, KFCPKPOOIKD DEABFFHHODC, QueryTriggerInteraction JKDFLHPFIEF)
	{
		return null;
	}

	public static int DPBFPCPGMDL(Vector3 CFMLEBMOOEC, Quaternion HBMAIAGDAFM, Vector3 LGOFCCMAGBP, int MPJGCPAKKKA, KFCPKPOOIKD DEABFFHHODC, Collider[] MIJJHKEGEJI)
	{
		return 0;
	}

	public static int DPBFPCPGMDL(Vector3 CFMLEBMOOEC, Quaternion HBMAIAGDAFM, Vector3 LGOFCCMAGBP, int MPJGCPAKKKA, KFCPKPOOIKD DEABFFHHODC, QueryTriggerInteraction JKDFLHPFIEF, Collider[] MIJJHKEGEJI)
	{
		return 0;
	}

	public static bool GEPAGNMJOAK(Vector3 CFMLEBMOOEC, Quaternion HBMAIAGDAFM, Vector3 LGOFCCMAGBP, int MPJGCPAKKKA, KFCPKPOOIKD DEABFFHHODC, out Vector3 AIAOLAOKKIL, int IOGJINADLLM = 10)
	{
		AIAOLAOKKIL = default;
		return false;
	}

	public static ENAKFGOOAHI DIEOEJBLNPF(Vector3 GJOCEGMFHMC)
	{
		return ENAKFGOOAHI.WALL;
	}

	public static ENAKFGOOAHI DIEOEJBLNPF(Vector3 GJOCEGMFHMC, Vector3 EJCHJGLEECL)
	{
		return ENAKFGOOAHI.WALL;
	}

	public static bool BNKBPNBICPC(Collider ADMCDJKKCIA)
	{
		return false;
	}

	public static bool AOJPEELHKAL(Collider ADMCDJKKCIA)
	{
		return false;
	}

	public static bool AFPEIFJPDHI(Collider ADMCDJKKCIA)
	{
		return false;
	}

	public static bool MPEDIJKPCPE(Collider ADMCDJKKCIA, List<Collider> GEEGNLOGPDI)
	{
		return false;
	}

	public static bool CBNICAEMAGE(Collider ADMCDJKKCIA)
	{
		return false;
	}

	public static bool BNKBAICFNHF(Collider ADMCDJKKCIA)
	{
		return false;
	}

	public static bool KEFJOGKLGOG(Collider ADMCDJKKCIA)
	{
		return false;
	}

	public static bool MAMBFNKLLAC(Collider ADMCDJKKCIA)
	{
		return false;
	}

	public static bool DFCBGPECIBC(Collider ADMCDJKKCIA)
	{
		return false;
	}

	public static bool DFCBGPECIBC(Collider ADMCDJKKCIA, Vector3 GJOCEGMFHMC)
	{
		return false;
	}

	public static bool DFCBGPECIBC(Collider ADMCDJKKCIA, Vector3 GJOCEGMFHMC, Vector3 EJCHJGLEECL)
	{
		return false;
	}

	public static bool LCIPJHIEKNJ(Vector3 PDFEDMAOMNH, float EGHDHPLDJGI, float MJDEJFDEKGG)
	{
		return false;
	}

	public static bool LCIPJHIEKNJ(Vector3 PDFEDMAOMNH, float EGHDHPLDJGI, float MJDEJFDEKGG, out RaycastHit KHFHAAMKDHD)
	{
		KHFHAAMKDHD = default;
		return false;
	}

	public static Vector3 JCBIGIKHHNM(Vector3 INKGHPCDMCG, Vector3 LMOKMOKNCMF, float AKLKLAGHMNK, float PFJNHNHEPEN)
	{
		return default;
	}

	public static Vector3 JCBIGIKHHNM(Vector3 INKGHPCDMCG, Vector3 LMOKMOKNCMF, float AKLKLAGHMNK, float PFJNHNHEPEN, KFCPKPOOIKD DEABFFHHODC)
	{
		return default;
	}

	private static int NNKDEGMNAKL(int EAIIFFEKLGO, Collider[] LDKOJBBGHLL, KFCPKPOOIKD HNGJGPJCNBJ, Collider[] ILJGHKGMILC)
	{
		return 0;
	}

	private static bool KIMJFEEAGEH(Collider LLKCFCIIGOB, Vector3 JHCANBOBDPE, Quaternion LKPJDJAKGBA, int GECBAAKDJFA, Collider[] OBKHOHIFGJA, out Vector3 AIAOLAOKKIL)
	{
		AIAOLAOKKIL = default;
		return false;
	}

	private static bool ABILFKLAAOB(Collider LLKCFCIIGOB, Vector3 JHCANBOBDPE, Quaternion LKPJDJAKGBA, int GECBAAKDJFA, Collider[] OBKHOHIFGJA, out Vector3 BCEKIMGKAMG)
	{
		BCEKIMGKAMG = default;
		return false;
	}

	private static bool KIMJFEEAGEH(Collider LLKCFCIIGOB, Vector3 JHCANBOBDPE, Quaternion LKPJDJAKGBA, Collider LGFFIPOGNGD, out Vector3 INCDEMGNJFD)
	{
		INCDEMGNJFD = default;
		return false;
	}

	private static KFFIOAHCGCJ JGGIOKKAEKA(int BEBMLJIDPAP, float GKJHODLJDHD, KFCPKPOOIKD HNGJGPJCNBJ, out RaycastHit KHFHAAMKDHD)
	{
		KHFHAAMKDHD = default;
		return KFFIOAHCGCJ.MISS;
	}

	private static KFFIOAHCGCJ JGGIOKKAEKA(int BEBMLJIDPAP, float GKJHODLJDHD, HHJPDONAACI HNGJGPJCNBJ, List<Collider> GEEGNLOGPDI, out RaycastHit KHFHAAMKDHD)
	{
		KHFHAAMKDHD = default;
		return KFFIOAHCGCJ.MISS;
	}
}
