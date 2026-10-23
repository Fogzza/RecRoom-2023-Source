using System;
using UnityEngine;

namespace RRUI.Data
{
	public class MakerPenAnalyticsControllers : ModelController<ModelBase>
	{
		[Serializable]
		public class MakerPenAnalytics_Button : ButtonControllerImpl<ModelBase>
		{
			[SerializeField]
			protected string analyticsName;

			[SerializeField]
			protected MakerPenMenuModel.IEKCDJICBLP menuTab;

			[SerializeField]
			protected string subMenuName;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		public class MakerPenAnalytics_PaletteButton : MakerPenAnalytics_Button
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
