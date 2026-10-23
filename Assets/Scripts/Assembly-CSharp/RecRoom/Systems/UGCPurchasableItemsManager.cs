using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RecRoom.Systems
{
	public class UGCPurchasableItemsManager : SingletonMonoBehaviour<UGCPurchasableItemsManager>
	{
		public enum GFGOGCKNPFH
		{
			Viewing = 0,
			Configuration = 1
		}

		private class CGADNGHOOLD
		{
			private sealed class KBPIEFJIJHJ
			{
				public CCMLCGONCIE purchasable;

				internal bool _003CAddOrUpdateUGCPurchasableItem_003Eb__0(KPMECOOBOKJ po)
				{
					return false;
				}
			}

			private readonly Dictionary<EGLJLFNLOGJ, CCMLCGONCIE> FMCLJFJNLMP;

			private readonly Dictionary<EGLJLFNLOGJ, Guid> HKGBIKJNCMO;

			private DateTime IOMKNPHIHGK;

			private readonly TimeSpan LAHCLDCDKJC;

			private readonly Lazy<IMLDFNOCMHL> PNAIMBGIHPK;

			private long? JAAMCAFAAFL;

private IMLDFNOCMHL FNMIGFKCOMI
{
get 			{
				return null;
			}

}

public long? CBCCEPHPKGN
{
get 			{
				return null;
			}

private set {
			}
}

public bool KKKHNMGIFMF
{
get 			{
				return false;
			}

}

public bool FBNFGAFNEKD
{
get 			{
				return false;
			}

}

public int BPIIJGBNBGB
{
get 			{
				return 0;
			}

}

			public bool KGKILKIFAIA(EGLJLFNLOGJ HLMMFDMGBDK, out CCMLCGONCIE KNFCCFOFDOL)
			{
				KNFCCFOFDOL = null;
				return false;
			}

			public bool NCMLMBJJJKM(EGLJLFNLOGJ HLMMFDMGBDK, out Guid LFNGEFEDKJM)
			{
				LFNGEFEDKJM = default;
				return false;
			}

			public IEnumerable<EGLJLFNLOGJ> FIJEDAKLIOM()
			{
				return null;
			}

			public IEnumerable<CCMLCGONCIE> LJMMOLLBBFK()
			{
				return null;
			}

			public List<EGLJLFNLOGJ> OCEJOHAJMKF()
			{
				return null;
			}

			public void NEMFDPEKAEF(IEnumerable<EGLJLFNLOGJ> IJEOKKCCDHD)
			{
			}

			public bool KJIEICGMLIO(CCMLCGONCIE KNFCCFOFDOL, IEnumerable<KPMECOOBOKJ> DDGCHPPNCBH)
			{
				return false;
			}

			public bool FDFIOBBEOAM(CCMLCGONCIE KNFCCFOFDOL)
			{
				return false;
			}

			public void KLGBKKHDEEC(EGLJLFNLOGJ HLMMFDMGBDK)
			{
			}

			public void EGMNBCEOAFG(Guid LFNGEFEDKJM)
			{
			}

			public void PAKIMOKGMBI()
			{
			}

			public void HMACBFEADGH()
			{
			}

			public void JJAHECGFAOL(long EPOBIFCHLNM)
			{
			}

			public void HEGIHBMJPHB()
			{
			}
		}

		private sealed class PDPFGICGCLJ
		{
			public IEnumerable<CCMLCGONCIE> purchasables;

			internal bool _003CSyncUGCPurchasablesCache_003Eb__0(CCMLCGONCIE purchasable)
			{
				return false;
			}
		}

		private sealed class FJONAEPFAFJ
		{
			public CCMLCGONCIE purchasable;

			internal bool _003CSyncUGCPurchasablesCache_003Eb__1(CCMLCGONCIE p)
			{
				return false;
			}
		}

		private sealed class JFCIGIGLCHF
		{
			public UGCPurchasableItemsManager _003C_003E4__this;

			public EGGMEJDMHKF roomInstance;

			internal void _003CRefreshCache_OnRoomInstanceChanged_003Eb__0()
			{
			}
		}

		private static readonly IEnumerable<CCMLCGONCIE> GDDHAHBAFGA;

		private readonly CGADNGHOOLD OKOMALFNKGH;

		private GFGOGCKNPFH JFFGNAJEONJ;

		private JKHCJAJHGAO MEHLBINIKLL;

		private int EBGGDIBMBNE;

		private IDisposable CNAGCKBFLOE;

		public static readonly EEANDDJEMJC UGCPurchasableItemsModified;

		private Lazy<DCFGCHBJPOO> BBJDNEMJCIL;

protected DCFGCHBJPOO PPOCIMALCCC
{
get 		{
			return null;
		}

}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public ILODPOPFPAH CreateDeserializationHandler()
		{
			return null;
		}

		public LAHBDKNMNHN RefreshUGCPurchasableItemsForCurrentRoom(GFGOGCKNPFH GLLFHCCFIGK, List<EGLJLFNLOGJ> IJEOKKCCDHD = null, bool KAGIMFAPGOG = false)
		{
			return null;
		}

		private LAHBDKNMNHN LNAOMNHLCED(long EPOBIFCHLNM, GFGOGCKNPFH GLLFHCCFIGK, List<EGLJLFNLOGJ> IJEOKKCCDHD = null, bool KAGIMFAPGOG = false)
		{
			return null;
		}

		private void KIIGJEFNFHH(IEnumerable<CCMLCGONCIE> DILGFDPBHMH, IEnumerable<KPMECOOBOKJ> DDGCHPPNCBH)
		{
		}

		public bool TryGetCachedCurrencyIdByIdentifier(EGLJLFNLOGJ ALAHDCCCJMM, out Guid LFNGEFEDKJM)
		{
			LFNGEFEDKJM = default;
			return false;
		}

		public bool TryGetCachedUGCPurchasableItemByIdentifier(EGLJLFNLOGJ ALAHDCCCJMM, out CCMLCGONCIE MDDPMBOGFCO)
		{
			MDDPMBOGFCO = null;
			return false;
		}

		public IEnumerable<CCMLCGONCIE> GetCachedUGCPurchasablesForCurrentRoom()
		{
			return null;
		}

		private void CADBBFECNNO(Guid GFGAKKMOHON)
		{
		}

		private void JPPLMAJGGGJ(Guid GFGAKKMOHON)
		{
		}

		private void OJPFBNCGGPN(EOHADGOEBOD FDAIMOMOHIG)
		{
		}

		private void CMHILCCOKGK(long IBFKGINGICK, Guid IEMFHCFEHCA)
		{
		}

		private void FNOJPHLEDED(BKCIEBLAHHB DLAOMGCBOAI)
		{
		}

		private void DNKMJCOIOBG(Guid LFNGEFEDKJM)
		{
		}

		private void DNMDAHLOIIH(KPMECOOBOKJ IAIINGKGKJP)
		{
		}

		private void IEOIFOKLHHH(Guid FJBOFHHJDBF)
		{
		}

		private void GPLDOAONDNF(LINLOKECLME LNKODFBLOKJ)
		{
		}

		private void GHADJBMGDKH(LINLOKECLME LNKODFBLOKJ)
		{
		}

		private void EJKIPEFBDCE(BBEGCPACHAD NIFOGEBEDNG, Guid IEJFFJNKFMK)
		{
		}

		private void CHPGEHOLIAD(BBEGCPACHAD NIFOGEBEDNG, Guid IEJFFJNKFMK)
		{
		}

		private void KNPHFGNCOKM(EGGMEJDMHKF GPKOELKKOBP)
		{
		}

		private void LKANJLAFKHM()
		{
		}

		private void BPLAAFJFPNL()
		{
		}

		private void EGJBMNPICPI()
		{
		}

		[CompilerGenerated]
		private void LFFGMCOOFFO(Tuple<IReadOnlyList<CCMLCGONCIE>, IReadOnlyList<KPMECOOBOKJ>> ILJGHKGMILC)
		{
		}

		[CompilerGenerated]
		private void DAFMJJLIEOD()
		{
		}
	}
}
