using System;

namespace RRUI.Data
{
	public class HomeTop5TabsModelController : ModelController<HomeTop5TabsModel>
	{
		[Serializable]
		private class TabButtonImpl : TabsToggleControllerImpl<EKNOKKDNHFP>
		{
		}

		[Serializable]
		private class ContentHideableImpl : TabsHideableControllerImpl<EKNOKKDNHFP>
		{
		}
	}
}
