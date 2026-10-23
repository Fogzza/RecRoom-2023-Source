using System;
using System.Runtime.CompilerServices;
using RRUI.Animation;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class ImageFeedItemModelController : ModelController<ImageFeedItemModel>
	{
		[Serializable]
		private class RoomIdLaunchImpl : ButtonControllerImpl<ImageFeedItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			[CompilerGenerated]
			private void PBDAACHFAPE()
			{
			}

			[CompilerGenerated]
			private void ODKLLEGOGHK()
			{
			}
		}

		[Serializable]
		private class ReportImageButtonImpl : ButtonControllerImpl<ImageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ExternalShareImpl : ButtonControllerImpl<ImageFeedItemModel>
		{
			private sealed class ALIFLLKHPJM
			{
				public ExternalShareImpl _003C_003E4__this;

				public string imageName;

				public string message;

				public GDHOAGNFOBD.KEIAPDLHGPG cachedImageHandle;

				internal void _003COnButtonClicked_003Eb__0(Texture2D texture)
				{
				}

				internal void _003COnButtonClicked_003Eb__1()
				{
				}
			}

			private const string STATSIG_EXPERIMENT_NAME = "discovery_q2_feed_sharing";

			private const string STATSIG_EXPERIMENT_PARAMETER = "Enabled";

			private bool shareInProgress;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			public global::NCOKFFGPIJM<Texture2D> AHIOCDOPBAF(string NPOEAPJKNFN, byte[] ILPAAAFNNFN, bool MGOPGCPJILM)
			{
				return null;
			}
		}

		[Serializable]
		private class HideIfCantNavigateToRoomImpl : HideableControllerImpl<ImageFeedItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FeedItemRoomNameTextImpl : TextControllerImpl<ImageFeedItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CheerFeedImageToggleImpl : ToggleControllerImpl<ImageFeedItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HighlightFeedItemImpl : ControllerImplementation<ImageFeedItemModel>
		{
			[SerializeField]
			private Image image;

			[SerializeField]
			private Transition transition;

			[SerializeField]
			private Color highlightColor;

			[NonSerialized]
			private KGLJAGOGBNM animation;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
