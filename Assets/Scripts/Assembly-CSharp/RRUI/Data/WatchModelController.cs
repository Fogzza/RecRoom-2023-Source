using System;
using System.Runtime.CompilerServices;
using RRUI.Navigation;
using UnityEngine;

namespace RRUI.Data
{
	public class WatchModelController : ModelController<WatchModel>
	{
		[Serializable]
		private class CloseWatchUIButtonImpl : ButtonControllerImpl<WatchModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DetachAndReattachButtonImpl : ToggleControllerImpl<WatchModel>
		{
			[SerializeField]
			private bool overrideDefaultDetach;

			[SerializeField]
			private float detachedDistance;

			[SerializeField]
			private float detachedVerticalOffsetFromHead;

			[SerializeField]
			private float detachedScale;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			private void LIMFMJEOGGC()
			{
			}
		}

		[Serializable]
		private class ConfigureSidebarHomeButtonForScrollRectImpl : ControllerImplementation<WatchModel>
		{
			[SerializeField]
			private RRUIScrollRect _scrollRect;

			[SerializeField]
			private Vector2 _absolutePosition;

			[SerializeField]
			private float _duration;

			private KOIBOLKJOIH _cachedTween;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void ENCIKAJGOID()
			{
			}

			[CompilerGenerated]
			private Vector3 BIHDNEPPFMG()
			{
				return default;
			}

			[CompilerGenerated]
			private void OIAKEHFEOGI(Vector3 IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class WatchTabsImpl : TabControllerImpl<WatchModel>
		{
			[SerializeField]
			private ELCPGOKLPLO watchTab;

			protected override Enum Identifier => null;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void CCMFKEPOHDI()
			{
			}
		}

		[Serializable]
		private class WatchTabsToHomeImpl : TabControllerImpl<WatchModel>
		{
			protected override Enum Identifier => null;

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class WatchTabsToNotificationsImpl : TabControllerImpl<WatchModel>
		{
			private LHMPPJKHCJG _player;

			protected override Enum Identifier => null;

			private LHMPPJKHCJG Player => null;

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToProfileTabImpl : WatchTabsImpl
		{
			protected override void AMGDOPGLANB(RRUI.Navigation.Uri FKFKJOJNCLM)
			{
			}
		}

		[Serializable]
		private class VRWatchMenuSizeControllerImpl : ControllerImplementation<WatchModel>
		{
			[SerializeField]
			private Transform transform;

			private CPBPJLLMKDB localPlayerAccess;

			private AOEKMGDBIBC tweenService;

			private Vector3 initialScale;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			private void MKBOJDKLDGG()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
