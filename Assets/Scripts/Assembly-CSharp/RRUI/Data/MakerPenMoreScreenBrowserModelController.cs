using System;
using System.Collections.Generic;
using RRUI.Navigation;
using RRUI.Theme;
using UnityEngine;

namespace RRUI.Data
{
	public class MakerPenMoreScreenBrowserModelController : ModelController<MakerPenMoreScreenBrowserModel>
	{
		[Serializable]
		private class AvailableRouteTogglesSpawnerImpl : PrefabSpawnerControllerImpl<MakerPenMoreScreenBrowserModel>
		{
			private sealed class GOHIJOIIDOK
			{
				public AvailableRouteTogglesSpawnerImpl _003C_003E4__this;

				public int index;

				internal void _003COnPopulateInstance_003Eg__OnButtonPress_007C0()
				{
				}
			}

			private IReadOnlyList<KeyValuePair<Route, string>> availableRoutes;

			private Dictionary<Route, ToggleTheme> routeToggles;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class EnforceValidBrowser : ControllerImplementation<MakerPenMoreScreenBrowserModel>
		{
			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
