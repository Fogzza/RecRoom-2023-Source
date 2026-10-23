using System;
using UnityEngine;

namespace RRUI.Data
{
	public class MakerPenTopBarModelController : ModelController<MakerPenTopBarModel>
	{
		[Serializable]
		private class ProgressBar_ChipCount : ProgressBarControllerImpl<MakerPenTopBarModel>
		{
			[SerializeField]
			private GOHEHBGBFIE progressType;

			protected override void NGFFCLPHKJN()
			{
			}

			private float IPGDBIKIGOD(float DDKCONDPEJF)
			{
				return 0f;
			}
		}

		[Serializable]
		private class Text_Progress_Chip : TextControllerImpl<MakerPenTopBarModel>
		{
			[SerializeField]
			private GOHEHBGBFIE progressType;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		private enum GOHEHBGBFIE
		{
			Chip = 0,
			Cpu = 1,
			Ink = 2,
			Net = 3
		}

private static float PECNKBHJOPN
{
get 		{
			return 0f;
		}

}

private static float FKOEAPLINLH
{
get 		{
			return 0f;
		}

}

private static float LMIIHBJIJNJ
{
get 		{
			return 0f;
		}

}

private static float BPOIBDNLMMG
{
get 		{
			return 0f;
		}

}

		private static string PFMFLLFPJKM(GOHEHBGBFIE NIFOGEBEDNG)
		{
			return null;
		}
	}
}
