using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RRUI.Navigation;
using UnityEngine;

namespace RRUI.Data
{
	public class SkuListModel : FilterableListModel<POPLPJGHHIA.OCDCJKGHBON, POPLPJGHHIA.OCDCJKGHBON, string>, FDFHJNFMGOJ
	{
		private enum MBMKLNEANCO
		{
			AllSKUs = 0,
			AllStoreCampaigns = 1,
			TokenBundlesAndDefaultSKUs = 2,
			DefaultSKUs = 3
		}

		private sealed class CDPJDAJDNAG
		{
			public POPLPJGHHIA.KAEKKCCLKLH plainSku;

			internal bool _003CGetEnhancedSkus_003Eb__1(POPLPJGHHIA.KGDMKAOCGMG tb)
			{
				return false;
			}

			internal bool _003CGetEnhancedSkus_003Eb__3(POPLPJGHHIA.LOBKJCHKJAA pc)
			{
				return false;
			}
		}

		private sealed class PBJBHFKFNHF
		{
			public POPLPJGHHIA.LOBKJCHKJAA purchaseCampaign;

			internal bool _003CGetEnhancedSkus_003Eb__2(POPLPJGHHIA.KGDMKAOCGMG tb)
			{
				return false;
			}
		}

		private bool BODPNNDFBBM;

		private bool BMKGCMHIAPI;

		private string INOOEJDNPKC;

		private string OMHKGGPLBNK;

		private bool BABEFDKIGDA;

		private MessageDialogModel HIBHINOKJLL;

		private IPGOOJIFBAB OCIPICLBINB;

		private bool IOOFKFANCMF;

		[SerializeField]
		private bool isTokenStore;

		[SerializeField]
		private bool useCustomEntrypoint;

		[SerializeField]
		private string customEntrypoint;

		[SerializeField]
		private MBMKLNEANCO includedSkuTypes;

		private readonly Lazy<MBPOJAEGNPN> DJKPPJGPDDK;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public bool IsPurchaseRestricted
{
get 		{
			return false;
		}

private set {
		}
}

public bool CanShowWarningSection
{
get 		{
			return false;
		}

private set {
		}
}

public bool ArePurchasesDisabledForPlatform
{
get 		{
			return false;
		}

}

public string TokenStoreDisplayText
{
get 		{
			return null;
		}

private set {
		}
}

public string EntrypointName
{
get 		{
			return null;
		}

private set {
		}
}

public GameObject GameObject
{
get 		{
			return null;
		}

}

public bool UseCustomEntrypoint
{
get 		{
			return false;
		}

}

public string CustomEntrypoint
{
get 		{
			return null;
		}

}

private MBPOJAEGNPN KHOJOBPPEEL
{
get 		{
			return null;
		}

}

		public void Set(string PGEIBONDJJP)
		{
		}

		protected override global::NCOKFFGPIJM<IReadOnlyList<POPLPJGHHIA.OCDCJKGHBON>> LFFEHHGOFFN()
		{
			return null;
		}

		private bool FOEFEEPOPCD(List<POPLPJGHHIA.OCDCJKGHBON> HPELBOFIPLN)
		{
			return false;
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override POPLPJGHHIA.OCDCJKGHBON EIDFFKOOKDK(POPLPJGHHIA.OCDCJKGHBON ONCGIPFNENB)
		{
			return null;
		}

		private LAHBDKNMNHN CFKNBANKFGB()
		{
			return null;
		}

		private global::NCOKFFGPIJM<List<POPLPJGHHIA.OCDCJKGHBON>> LGDKFBLDJKL()
		{
			return null;
		}

		private bool HGECBKMKJLB()
		{
			return false;
		}

		private bool LLJKFCHLJEE()
		{
			return false;
		}

		private bool MECKGLBLONB()
		{
			return false;
		}

		private static int LANALKNFPEA(POPLPJGHHIA.OCDCJKGHBON JGJCLMLJMAP, POPLPJGHHIA.OCDCJKGHBON KKEAPLHDJIE)
		{
			return 0;
		}

		private void BHOGLJJFNNC()
		{
		}

		private void MMDFNFAMJPO(string OFMGPNLDCAB, string OFCFPGACNJB)
		{
		}

		public LAHBDKNMNHN OnBeforePageSwapFrom(RRUI.Navigation.Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL IJBCMNDEFKG)
		{
			return null;
		}

		public LAHBDKNMNHN OnBeforePageSwapTo(RRUI.Navigation.Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL NNNNCKGCFDC)
		{
			return null;
		}

		public LAHBDKNMNHN OnAfterPageSwapTo(RRUI.Navigation.Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL CPPLLDJOLBG)
		{
			return null;
		}

		public LAHBDKNMNHN OnShow(JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL JJBAOLFOIMI, MCMEHFCNDOL IMLLIIBAJMB)
		{
			return null;
		}

		public LAHBDKNMNHN OnHide(JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL JJBAOLFOIMI, MCMEHFCNDOL IMLLIIBAJMB)
		{
			return null;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<List<POPLPJGHHIA.OCDCJKGHBON>> JAGBGIJBOLP()
		{
			return null;
		}

		[CompilerGenerated]
		private void LFEHIAFCFDG(List<POPLPJGHHIA.OCDCJKGHBON> HPELBOFIPLN)
		{
		}

		[CompilerGenerated]
		private void AJKANFPPLIL(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void IBJDBNIJHEA(bool LPBPNNLKPLK)
		{
		}

		[CompilerGenerated]
		private List<POPLPJGHHIA.OCDCJKGHBON> FJPGFIFLCJF(Tuple<List<POPLPJGHHIA.KGDMKAOCGMG>, List<POPLPJGHHIA.LOBKJCHKJAA>, List<POPLPJGHHIA.KAEKKCCLKLH>> ILJGHKGMILC)
		{
			return null;
		}

		[CompilerGenerated]
		private void CNDCKPEDFEE()
		{
		}

		[CompilerGenerated]
		private void BPPIBLPIEJO(BaseDialogModel<IPGOOJIFBAB> GDMKJGAKCND)
		{
		}
	}
}
