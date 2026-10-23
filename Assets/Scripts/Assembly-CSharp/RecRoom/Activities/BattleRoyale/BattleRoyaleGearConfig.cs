using System;
using UnityEngine;

namespace RecRoom.Activities.BattleRoyale
{
	[Serializable]
	public class BattleRoyaleGearConfig : ScriptableObject
	{
		[SerializeField]
		private Color commonColor;

		[SerializeField]
		private Color uncommonColor;

		[SerializeField]
		private Color rareColor;

		[SerializeField]
		private Color epicColor;

		[SerializeField]
		private Color legendaryColor;

		[SerializeField]
		private int pistolDropWeight;

		[SerializeField]
		private int automaticDropWeight;

		[SerializeField]
		private int rifleDropWeight;

		[SerializeField]
		private int shotgunDropWeight;

		[SerializeField]
		private int handCannonDropWeight;

		[SerializeField]
		private int bowDropWeight;

		[SerializeField]
		private int rocketLauncherDropWeight;

		public Color CommonColor => default;

		public Color UncommonColor => default;

		public Color RareColor => default;

		public Color EpicColor => default;

		public Color LegendaryColor => default;

		public int PistolDropWeight => 0;

		public int AutomaticDropWeight => 0;

		public int RifleDropWeight => 0;

		public int ShotgunDropWeight => 0;

		public int HandCannonDropWeight => 0;

		public int BowDropWeight => 0;

		public int RocketLauncherDropWeight => 0;
	}
}
