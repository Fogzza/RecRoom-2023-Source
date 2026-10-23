using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Theme;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace RRUI.Data
{
	public class PickerDialogModelController : ModelController<PickerDialogModel>
	{
		[Serializable]
		private class TestImpl : ControllerImplementation<PickerDialogModel>
		{
			private sealed class MJKPHFJHAEG
			{
				public List<DFDECAEJBIO> accounts;

				public HashSet<int> selected;

				public Func<int, string> _003C_003E9__8;

				internal void _003CInitialize_003Eb__1(GameObject instance, int index, TextMeshProUGUI textMeshProUGUI)
				{
				}

				internal bool _003CInitialize_003Eb__2(string value, int index)
				{
					return false;
				}

				internal bool _003CInitialize_003Eb__4(int index)
				{
					return false;
				}

				internal bool _003CInitialize_003Eb__5(int index)
				{
					return false;
				}

				internal bool _003CInitialize_003Eb__6(int index)
				{
					return false;
				}

				internal void _003CInitialize_003Eb__7()
				{
				}

				internal string _003CInitialize_003Eb__8(int index)
				{
					return null;
				}
			}

			[SerializeField]
			private GameObject prefab;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void AOKCLIKNKEP(List<DFDECAEJBIO> AGIGKKMBEKN)
			{
			}
		}

		[Serializable]
		private class NoResultsTextImpl : TextControllerImpl<PickerDialogModel>
		{
			[SerializeField]
			private string defaultNoItemsText;

			[SerializeField]
			private LocalizedString localizedDefaultNoItemsText;

			[SerializeField]
			private string defaultNoResultsText;

			[SerializeField]
			private LocalizedString localizedDefaultNoResultsText;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class NoResultsImageImpl : ImageControllerImpl<PickerDialogModel>
		{
			[SerializeField]
			private Sprite defaultNoItemsImage;

			[SerializeField]
			private Sprite defaultNoResultsImage;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ExplicitSearchButtonImpl : ButtonControllerImpl<PickerDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TextFilterInputFieldImpl : InputFieldControllerImpl<PickerDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}

			protected override void OCBEIMLCCCH(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class HideIfNoTextFilterImpl : HideableControllerImpl<PickerDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoExplicitSearchBehaviorImpl : HideableControllerImpl<PickerDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoFilterGroupsImpl : HideableControllerImpl<PickerDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoFooterElementsImpl : HideableControllerImpl<PickerDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfEmptyImpl : HideableControllerImpl<PickerDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotEmptyImpl : HideableControllerImpl<PickerDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PickerFilterSpawnerImpl : PrefabSpawnerControllerImpl<PickerDialogModel>
		{
			private sealed class PEMFFDDGFJD
			{
				public PickerFilterSpawnerImpl _003C_003E4__this;

				public KCOKPCOFDIM.BNCPIBNIELN filterGroup;

				internal void _003COnPopulateInstance_003Eb__0()
				{
				}
			}

			private IReadOnlyList<KCOKPCOFDIM.BNCPIBNIELN> filterGroups;

			private ToggleTheme[] toggleThemes;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class PickerItemSpawnerImpl : RecyclingListControllerImpl<PickerDialogModel, CardModel>
		{
			[NonSerialized]
			private uint lastRefreshVersion;

			protected override GameObject DefaultPrefabToSpawn => null;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}
	}
}
