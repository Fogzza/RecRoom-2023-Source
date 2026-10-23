using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.NewPlayerChallenges
{
	[CreateAssetMenu]
	public class NewPlayerChallengesConfig : ScriptableObject, HJJEIGNLBHA.AJEJADNFEAJ, CKHDMIPMALK
	{
		[SerializeField]
		private List<ChallengeMetadata> allChallengeMetadata;

		[SerializeField]
		private Sprite defaultRewardImage;

		public IEnumerable<ChallengeMetadata> AllChallengeMetadata => null;

		public Sprite DefaultRewardImage => null;
	}
}
