using System.Collections.Generic;
using RRUI.Navigation;
using RecNet;
using UnityEngine;

namespace RRUI.Data
{
	public class AdCarouselItemListModel : FilterableListModel<int, StorefrontAdCarouselItem, string>, FDFHJNFMGOJ
	{
		public enum NFBOHJNNJKE
		{
			Store = 0
		}

		private sealed class AAOELICFJDP
		{
			public List<POPLPJGHHIA.KGDMKAOCGMG> tokenBundles;

			internal bool _003CRefreshCacheInternal_003Eb__1(StorefrontAdCarouselItem item)
			{
				return false;
			}
		}

		private sealed class GMJABBFFMMF
		{
			public StorefrontAdCarouselItem item;

			internal bool _003CRefreshCacheInternal_003Eb__2(POPLPJGHHIA.KGDMKAOCGMG tb)
			{
				return false;
			}
		}

		private const string OEHPAGEPJOC = "Featured";

		[SerializeField]
		private NFBOHJNNJKE source;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public NFBOHJNNJKE Source
{
get 		{
			return NFBOHJNNJKE.Store;
		}

set {
		}
}

public GameObject GameObject
{
get 		{
			return null;
		}

}

		public void Set(NFBOHJNNJKE? GLLFHCCFIGK)
		{
		}

		protected override global::NCOKFFGPIJM<IReadOnlyList<StorefrontAdCarouselItem>> LFFEHHGOFFN()
		{
			return null;
		}

		protected override int EIDFFKOOKDK(StorefrontAdCarouselItem ONCGIPFNENB)
		{
			return 0;
		}

		public LAHBDKNMNHN OnBeforePageSwapFrom(Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL IJBCMNDEFKG)
		{
			return null;
		}

		public LAHBDKNMNHN OnBeforePageSwapTo(Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL NNNNCKGCFDC)
		{
			return null;
		}

		public LAHBDKNMNHN OnAfterPageSwapTo(Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL CPPLLDJOLBG)
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
	}
}
