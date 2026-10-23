using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Com.TheFallenGames.OSA.Core;
using RRUI.Navigation;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class CachedViewStateModelController : ModelController<CachedViewStateModel>
	{
		[Serializable]
		private class ClearViewStateOnClickImpl : ButtonControllerImpl<CachedViewStateModel>
		{
			[SerializeField]
			private Route _route;

			private RRUI.Navigation.Uri _uri;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClearViewStateOnBrowserChangeImpl : NavigationListenerControllerImpl<CachedViewStateModel>
		{
			[SerializeField]
			private SerializableIdentifier serializableIdentifier;

			[SerializeField]
			private List<Route> excludedRoutes;

			public override bool SubscribeToDefaultModelEvents => false;

			protected override LAHBDKNMNHN IDEGIPICGIP(RRUI.Navigation.Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL IJBCMNDEFKG)
			{
				return null;
			}

			protected override LAHBDKNMNHN NJNBNGMACNI(RRUI.Navigation.Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL NNNNCKGCFDC)
			{
				return null;
			}

			protected override LAHBDKNMNHN CBHPENGFHGC(RRUI.Navigation.Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL CPPLLDJOLBG)
			{
				return null;
			}

			protected override LAHBDKNMNHN EHOFAGJCHPA(JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL JJBAOLFOIMI, MCMEHFCNDOL IMLLIIBAJMB)
			{
				return null;
			}

			protected override LAHBDKNMNHN PLLBMDOLLBP(JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL JJBAOLFOIMI, MCMEHFCNDOL IMLLIIBAJMB)
			{
				return null;
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CacheScrollPositionFromScrollRectImpl : CachedViewStateControllerImpl<Vector2>
		{
			[SerializeField]
			private ScrollRect scrollRect;

			[SerializeField]
			private BaseOSA osaScrollRect;

			[SerializeField]
			private bool overrideDefaultScrollPosition;

			[SerializeField]
			private bool isAbsolutePosition;

			[SerializeField]
			private Vector2 defaultScrollPositionOverride;

			private bool _useScrollRect;

			private Vector2 defaultScrollPosition;

			private Vector2 AnchoredPosition
			{
				get
				{
					return default;
				}
				set
				{
				}
			}

			private Vector2 NormalizedPosition
			{
				get
				{
					return default;
				}
				set
				{
				}
			}

			protected override Vector2 DefaultValue => default;

			protected override void CCMFKEPOHDI()
			{
			}

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void DHJMFHGCFKA(Vector2 IPMIIEAGJKC)
			{
			}

			protected override Vector2 KDCICDPCCJK()
			{
				return default;
			}

			[CompilerGenerated]
			private void NODCPEPNIJD()
			{
			}
		}

		[Serializable]
		private class CacheStateFromFoldoutImpl : CachedViewStateControllerImpl<bool>
		{
			[SerializeField]
			private Foldout foldout;

			[SerializeField]
			private bool defaultIsOpen;

			protected override bool DefaultValue => false;

			protected override void DHJMFHGCFKA(bool IPMIIEAGJKC)
			{
			}

			protected override bool KDCICDPCCJK()
			{
				return false;
			}
		}
	}
}
