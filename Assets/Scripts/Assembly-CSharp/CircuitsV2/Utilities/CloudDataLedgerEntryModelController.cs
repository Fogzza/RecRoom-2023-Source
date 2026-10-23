using System;
using JetBrains.Annotations;
using RRUI.Data;
using RRUI.Theme;
using UnityEngine;

namespace CircuitsV2.Utilities
{
	public class CloudDataLedgerEntryModelController : ModelController<CloudDataLedgerEntryModel>
	{
		[Serializable]
		private class NameTextImpl : TextControllerImpl<CloudDataLedgerEntryModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TypeTextImpl : TextControllerImpl<CloudDataLedgerEntryModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private sealed class SubroomCountTextImpl : TextControllerImpl<CloudDataLedgerEntryModel>
		{
			private LabelTheme _labelTheme;

			[SerializeField]
			private string pluralSuffix;

			[SerializeField]
			private string singularSuffix;

			[SerializeField]
			private string prospectiveVariableText;

			[NotNull]
			private LabelTheme LabelTheme => null;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ResetVariableButtonImpl : ButtonControllerImpl<CloudDataLedgerEntryModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DeleteVariableButtonImpl : ButtonControllerImpl<CloudDataLedgerEntryModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ShowIfCanDeleteVariableImpl : HideableControllerImpl<CloudDataLedgerEntryModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowIfCanResetVariableImpl : HideableControllerImpl<CloudDataLedgerEntryModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowIfProspecitveVariableImpl : HideableControllerImpl<CloudDataLedgerEntryModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoSubroomsImpl : HideableControllerImpl<CloudDataLedgerEntryModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SubroomSpawnerImpl : PrefabSpawnerControllerImpl<CloudDataLedgerEntryModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}
	}
}
