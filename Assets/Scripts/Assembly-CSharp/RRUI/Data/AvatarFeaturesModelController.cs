using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class AvatarFeaturesModelController : ModelController<AvatarFeaturesModel>
	{
		[Serializable]
		private class OutfitItemToCardImpl : ToCardControllerImpl<AvatarFeaturesModel>
		{
			[SerializeField]
			private bool hideEars;

			protected override AEBHFHIINHM CardData => null;

			[CompilerGenerated]
			private void BCDLPOHGFLN()
			{
			}
		}

		public JLOCLGGLOPP GetToCardController()
		{
			return null;
		}
	}
}
