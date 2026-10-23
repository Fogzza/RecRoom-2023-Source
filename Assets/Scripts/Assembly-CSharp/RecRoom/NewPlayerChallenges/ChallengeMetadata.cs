using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.NewPlayerChallenges
{
	[Serializable]
	public struct ChallengeMetadata
	{
		[Serializable]
		public struct PlatformSpecificOverrides
		{
			[SerializeField]
			private BDAAMJJEJIA _platform;

			[TextArea]
			[SerializeField]
			private string _helpInfo;

			[SerializeField]
			private Texture2D _helpImage;

			public BDAAMJJEJIA Platform => BDAAMJJEJIA.Mobile;

			public string HelpInfo => null;

			public Texture2D HelpImage => null;
		}

		[SerializeField]
		private string _description;

		[SerializeField]
		private string _familyName;

		[SerializeField]
		[TextArea]
		private string _helpInfo;

		[SerializeField]
		private Texture2D _helpImage;

		[SerializeField]
		private bool _canBeSkipped;

		[SerializeField]
		private bool _skipIfJunior;

		[SerializeField]
		private Sprite _rewardsImage;

		[SerializeField]
		private List<PlatformSpecificOverrides> _platformOverrides;

		[SerializeField]
		private PNLFAAAPEID _objective;

		[SerializeField]
		private string _roomServerKeyPrefix;

		[SerializeField]
		private DBECJLAIPEL _roomLoadSource;

		[SerializeField]
		private GameObject _toolToSkinPrefab;

		public string Description => null;

		public string FamilyName => null;

		public string HelpInfo => null;

		public Texture2D HelpImage => null;

		public bool CanBeSkipped => false;

		public bool SkipIfJunior => false;

		public Sprite RewardsImage => null;

		public IReadOnlyList<PlatformSpecificOverrides> PlatformOverrides => null;

		public PNLFAAAPEID Objective => (PNLFAAAPEID)0;

		public bool HasPlatformSpecificOverrides => false;

		public string RoomServerKeyPrefix => null;

		public DBECJLAIPEL RoomLoadSource => DBECJLAIPEL.NOT_SET;

		public GameObject ToolToSkinPrefab => null;
	}
}
