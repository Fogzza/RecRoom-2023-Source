using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class MagicDoorModelController : ModelController<MagicDoorModel>
	{
		[Serializable]
		private class NewDestinationTitleTextImpl : TextControllerImpl<MagicDoorModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DestinationRefreshingTitleTextImpl : TextControllerImpl<MagicDoorModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CountdownTitleTextImpl : TextControllerImpl<MagicDoorModel>
		{
			[SerializeField]
			private string postfix;

			private IDisposable countdownDisposable;

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void ALHNNKKLGHC(float GADDGJANIGG = 0f)
			{
			}
		}

		[Serializable]
		private class MagicDoorButtonImpl : ButtonControllerImpl<MagicDoorModel>
		{
			private bool isLoadingRoom;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			private void LOACFIICNBM()
			{
			}

			[CompilerGenerated]
			private void OCPEODBABOB()
			{
			}
		}

		[Serializable]
		private class HideIfPlayerHasNotVisitedDestinationImpl : HideableControllerImpl<MagicDoorModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
