using System;

namespace RRUI.Data
{
	public class MirrorEyeOptionsTabsModelController : ModelController<MirrorEyeOptionsTabsModel>
	{
		[Serializable]
		private class TabButtonImpl : TabsToggleControllerImpl<AOAOHPHBPBD>
		{
		}

		[Serializable]
		private class ContentHideableImpl : TabsHideableControllerImpl<AOAOHPHBPBD>
		{
		}
	}
}
