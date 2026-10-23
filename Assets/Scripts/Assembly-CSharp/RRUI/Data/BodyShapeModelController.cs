using System;

namespace RRUI.Data
{
	public class BodyShapeModelController : ModelController<BodyShapeModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class BodyShapeSpriteImpl : ImageControllerImpl<BodyShapeModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BodyShapeToggleImpl : ToggleControllerImpl<BodyShapeModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class BodyShapeToCardImpl : ToCardControllerImpl<BodyShapeModel>
		{
			protected override AEBHFHIINHM CardData => null;
		}

		public JLOCLGGLOPP GetToCardController()
		{
			return null;
		}
	}
}
