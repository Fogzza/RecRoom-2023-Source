using System;
using RRUI.Navigation;

namespace RRUI.Data
{
	public class MakerPenMoreScreenRoutesModelController : ModelController<MakerPenMoreScreenRoutesModel>
	{
		[Serializable]
		private class Text_TabName : TextControllerImpl<MakerPenMoreScreenRoutesModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MoreScreenRoutesHideable : HideableControllerImpl<MakerPenMoreScreenRoutesModel>
		{
			public int minimumRoutesToShow;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		private abstract class ACGGPJBJMOA : ControllerImplementation<MakerPenMoreScreenRoutesModel>
		{
			public Route LEIAPFMILFN;

			public string HGHLBCLFGAE;

			public abstract bool MMHLDINLAFF();

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
