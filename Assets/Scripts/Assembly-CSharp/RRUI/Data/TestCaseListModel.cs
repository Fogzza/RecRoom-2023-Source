using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RRUI.Data
{
	public class TestCaseListModel : FilterableListModel<string, BNMEGKPHFPA, string>
	{
		public enum DIHNJIPGFHF
		{
			MyUnfinished = 0,
			NotYetTested = 1,
			Claimed = 2,
			Failed = 3,
			Passed = 4,
			Blocked = 5
		}

		private sealed class FIFGBKMMFLA
		{
			public uint id;

			public TestCaseListModel _003C_003E4__this;

			internal IReadOnlyList<BNMEGKPHFPA> _003CRefreshCacheInternal_003Eb__0(ONCHFLDGGCK testPass)
			{
				return null;
			}
		}

		private sealed class LMPDCFNIONN
		{
			public KeyValuePair<DIHNJIPGFHF, Func<BNMEGKPHFPA, bool>> filter;

			internal bool _003COnTestPassLoaded_003Eb__4(BNMEGKPHFPA tc)
			{
				return false;
			}
		}

		private sealed class MDNFFLCECIE
		{
			public string tag;

			internal bool _003CIsPinnedTagActive_003Eb__0(string t)
			{
				return false;
			}
		}

		private DIHNJIPGFHF AIDOCIKAKCJ;

		private uint PNLINCEFEAO;

		private ONCHFLDGGCK EDJIDJCJFNO;

		private HashSet<string> HOKHCAKHDAJ;

		private List<string> LMEFFKAOLIB;

		private HashSet<DIHNJIPGFHF> KGEMNLLNPLB;

		private readonly IReadOnlyDictionary<DIHNJIPGFHF, Func<BNMEGKPHFPA, bool>> AJJODLNMOEE;

		private static Dictionary<string, DIHNJIPGFHF> LGEBFKCBDGJ;

		private Dictionary<string, int> BOCHMPFFEBJ;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public DIHNJIPGFHF DisplayMode
{
get 		{
			return DIHNJIPGFHF.MyUnfinished;
		}

set {
		}
}

public uint TestPassId
{
get 		{
			return 0u;
		}

set {
		}
}

public HashSet<string> ActivePinnedTags
{
get 		{
			return null;
		}

private set {
		}
}

public List<string> FilterTags
{
get 		{
			return null;
		}

private set {
		}
}

public HashSet<DIHNJIPGFHF> DisabledModes
{
get 		{
			return null;
		}

private set {
		}
}

		protected override global::NCOKFFGPIJM<IReadOnlyList<BNMEGKPHFPA>> LFFEHHGOFFN()
		{
			return null;
		}

		private void GPFFHIJOPDB(ONCHFLDGGCK EJLLCEKNPED)
		{
		}

		private List<BNMEGKPHFPA> KMFIKJKFHJP()
		{
			return null;
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override string EIDFFKOOKDK(BNMEGKPHFPA ONCGIPFNENB)
		{
			return null;
		}

		public void Set(HashSet<string> CMBMOBEBGIN, uint PNLINCEFEAO)
		{
		}

		public static DIHNJIPGFHF? AsMode(string AHNIMJDLOPB)
		{
			return null;
		}

		public static string AsModeString(string AHNIMJDLOPB)
		{
			return null;
		}

		public bool IsPinnedTagActive(string AHNIMJDLOPB)
		{
			return false;
		}

		public void RemoveActivePinnedTag(string AHNIMJDLOPB)
		{
		}

		public void AddActivePinnedTag(string AHNIMJDLOPB)
		{
		}

		[CompilerGenerated]
		private bool KFCGFMDPAJA(KeyValuePair<string, int> EKJEPNEDGAP)
		{
			return false;
		}

		[CompilerGenerated]
		private bool LKCMPLANJAI(DIHNJIPGFHF DNLPIHIBJDP)
		{
			return false;
		}

		[CompilerGenerated]
		private bool JBPKHPLKOBH(BNMEGKPHFPA AIIAIBBJAKE)
		{
			return false;
		}

		[CompilerGenerated]
		private bool HABMCGLNNKP(string AHNIMJDLOPB)
		{
			return false;
		}
	}
}
