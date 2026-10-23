using System.Collections.Generic;
using RecRoom.Core.Creation;
using TMPro;
using UnityEngine;

namespace RecRoom.AGUI.ToolUIs.PaletteSearch
{
	public sealed class MakerPenPaletteSearchScreen : MonoBehaviour
	{
		private sealed class JCKDBAOJJII
		{
			public MakerPenPaletteSearchScreen _003C_003E4__this;

			public string certifiedInventionFormat;

			public string inventionFormat;

			public string[][] certifiedInventionFilters;

			public string[][] inventionFilters;

			public string[][] colorFilters;

			public string[][] materialFilters;

			public string[][] shapeFilters;

			internal GEMEIEHGLIO _003CTryRebuildSearchContext_003Eb__3((string[][], string, RuntimeSpawnableToolConfig) toolInfo)
			{
				return null;
			}

			internal BEIANCHHAJA _003CTryRebuildSearchContext_003Eb__4(OEBAEGDPBLA invention)
			{
				return null;
			}

			internal DCCGEPLEODM _003CTryRebuildSearchContext_003Eb__5(ShapeColorInfo colorInfo)
			{
				return null;
			}

			internal MIHLBNKMMIP _003CTryRebuildSearchContext_003Eb__6(ShapeMaterialInfo materialInfo)
			{
				return null;
			}

			internal ENILADICJJL _003CTryRebuildSearchContext_003Eb__7(AMEPDCGKFOG shapeType)
			{
				return null;
			}
		}

		private sealed class PIOGINFKPJB
		{
			public OPJCLOIDAHH circuitButtonData;

			internal bool _003CTryRebuildSearchContext_003Eb__8()
			{
				return false;
			}
		}

		private sealed class HBLKGLHIPFC
		{
			public string groupStr;

			internal (string, SpawnableToolCategoryConfig.CategoryConfig) _003CTryRebuildSearchContext_003Eb__9(SpawnableToolCategoryConfig.CategoryConfig category)
			{
				return default;
			}
		}

		private sealed class NBDAHKEBIOI
		{
			public string groupStr;

			public string categoryStr;

			internal (string[][], string, RuntimeSpawnableToolConfig) _003CTryRebuildSearchContext_003Eb__11(RuntimeSpawnableToolConfig tool)
			{
				return default;
			}
		}

		private sealed class HADENLEGHBH
		{
			public JBGFOIKBKED spawnableToolType;

			public JCKDBAOJJII CS_0024_003C_003E8__locals1;

			internal bool _003CTryRebuildSearchContext_003Eb__12()
			{
				return false;
			}

			internal void _003CTryRebuildSearchContext_003Eb__13()
			{
			}
		}

		private sealed class GJGLIOKOJJJ
		{
			public OEBAEGDPBLA invention;

			public JCKDBAOJJII CS_0024_003C_003E8__locals2;

			internal bool _003CTryRebuildSearchContext_003Eb__14()
			{
				return false;
			}

			internal void _003CTryRebuildSearchContext_003Eb__15()
			{
			}
		}

		private sealed class LBGFHLAFHEM
		{
			public ShapeColorInfo colorInfo;

			public JCKDBAOJJII CS_0024_003C_003E8__locals3;

			internal bool _003CTryRebuildSearchContext_003Eb__17()
			{
				return false;
			}

			internal void _003CTryRebuildSearchContext_003Eb__18()
			{
			}
		}

		private sealed class PEOAHOPLGPF
		{
			public ShapeMaterialInfo materialInfo;

			public JCKDBAOJJII CS_0024_003C_003E8__locals4;

			internal bool _003CTryRebuildSearchContext_003Eb__19()
			{
				return false;
			}

			internal void _003CTryRebuildSearchContext_003Eb__20()
			{
			}
		}

		private sealed class FIGDJFKKOMK
		{
			public AMEPDCGKFOG shapeType;

			public JCKDBAOJJII CS_0024_003C_003E8__locals5;

			internal bool _003CTryRebuildSearchContext_003Eb__21()
			{
				return false;
			}

			internal void _003CTryRebuildSearchContext_003Eb__22()
			{
			}
		}

		[SerializeField]
		private MakerPenPaletteSearchPagedGrid pagedGrid;

		[SerializeField]
		private MakerPenPaletteSearchPagedGrid filtersPagedGrid;

		[SerializeField]
		private TMP_InputField filterInputField;

		[SerializeField]
		private Subscreen subscreen;

		[SerializeField]
		private MakerPenPaletteMainScreen mainScreen;

		[SerializeField]
		private bool autoFocusInput;

		private bool GIELPFPDAOH;

		private BDHJHNNAEEB HLBMAEEEJLD;

		private IEnumerable<OEBAEGDPBLA> LBNJECIDABI;

public Subscreen Subscreen
{
get 		{
			return null;
		}

}

private bool PPLFCICBOGD
{
get 		{
			return false;
		}

}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public static string FormatDescription(string GKHMKKBKEKC)
		{
			return null;
		}

		private void OHHCAHENLHE()
		{
		}

		private void KNKPDPHMPAH(bool GADDGJANIGG)
		{
		}

		private bool HKOJAPMDEJH()
		{
			return false;
		}

		private void OOBBECDJFLJ(string HNGJGPJCNBJ)
		{
		}

		private void PMPDGPLFJOL(string JDPGCELOKNO)
		{
		}

		private void BPECCLHFLEN(IEnumerable<FKHIHDBONBB> JNAAHMPCPAB, IReadOnlyList<bool> LKCAJHNIMJI)
		{
		}

		private void KIKCMKIMBHK(IEnumerable<FKHIHDBONBB> JNAAHMPCPAB, IReadOnlyList<bool> LKCAJHNIMJI)
		{
		}

		public void ClearInputField()
		{
		}

		public void BackspaceInputField()
		{
		}

		public void ApplyFilter(string HLIGBKANEEA)
		{
		}

		private void FMEJCJCEPGM()
		{
		}

		public void SetPendingInventions(IEnumerable<OEBAEGDPBLA> AMIAEMLONAO)
		{
		}

		private void AFBBEELBCKD(string GADDGJANIGG)
		{
		}
	}
}
