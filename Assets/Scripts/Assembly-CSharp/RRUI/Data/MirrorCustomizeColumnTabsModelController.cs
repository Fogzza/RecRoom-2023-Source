using System;

namespace RRUI.Data
{
	public class MirrorCustomizeColumnTabsModelController : ModelController<MirrorCustomizeColumnTabsModel>
	{
		[Serializable]
		private class TabButtonImpl : TabsToggleControllerImpl<POIGBBHMBLK>
		{
		}

		[Serializable]
		private class ContentHideableImpl : TabsHideableControllerImpl<POIGBBHMBLK>
		{
		}
	}
}
