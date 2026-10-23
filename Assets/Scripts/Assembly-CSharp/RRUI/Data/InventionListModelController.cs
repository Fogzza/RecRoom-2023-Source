using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Navigation;
using UnityEngine;

namespace RRUI.Data
{
	public class InventionListModelController : ModelController<InventionListModel>
	{
		[Serializable]
		private class SourceLabelTextImpl : TextControllerImpl<InventionListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowSearchPageFilterDialogPopUpButtonImpl : ButtonControllerImpl<InventionListModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowStoreTabFilterDialogPopUpButtonImpl : ButtonControllerImpl<InventionListModel>
		{
			[SerializeField]
			private Route route;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SortByDropdownImpl : DropdownControllerImpl<InventionListModel>
		{
			[NonSerialized]
			private List<InventionsConfig.InventionSortFriendlyNameMapping> sortCriteriaConfig;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void OBNGIJHLCJE(int GMEHLIHLGEH)
			{
			}

			[CompilerGenerated]
			private bool CPIGDEKABHN(InventionsConfig.InventionSortFriendlyNameMapping ONCGIPFNENB)
			{
				return false;
			}
		}

		[Serializable]
		private class InventionsBySourceLinkImpl : LinkControllerImpl<InventionListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class InventionListLinkImpl : LinkControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SearchInventionListLinkImpl : LinkControllerImpl<InventionListModel>
		{
			[SerializeField]
			private List<string> tagList;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SearchTabLinkImpl : LinkControllerImpl<InventionListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FromUriImpl : FromUriControllerImpl<InventionListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class FromSearchUriImpl : FromUriControllerImpl<InventionListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfShowingLocalAccountInventionsImpl : HideableControllerImpl<InventionListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfShowingRemoteAccountInventionsImpl : HideableControllerImpl<InventionListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class InventionListSpawnerImpl : RecyclingListControllerImpl<InventionListModel, InventionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class InventionListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<InventionListModel, InventionModel, InventionModelController>
		{
			private sealed class ODEGKPDNNMH
			{
				public InventionModel inventionModel;

				internal string _003COnPopulateInstance_003Eb__0()
				{
					return null;
				}

				internal string _003COnPopulateInstance_003Eb__2()
				{
					return null;
				}

				internal string _003COnPopulateInstance_003Eb__4()
				{
					return null;
				}

				internal string _003COnPopulateInstance_003Eb__6()
				{
					return null;
				}

				internal Sprite _003COnPopulateInstance_003Eb__7()
				{
					return null;
				}

				internal string _003COnPopulateInstance_003Eb__8()
				{
					return null;
				}

				internal Sprite _003COnPopulateInstance_003Eb__9()
				{
					return null;
				}
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, InventionModel CLOCJGJMJJH, JLOCLGGLOPP OKFDBBHKCOD)
			{
			}
		}
	}
}
