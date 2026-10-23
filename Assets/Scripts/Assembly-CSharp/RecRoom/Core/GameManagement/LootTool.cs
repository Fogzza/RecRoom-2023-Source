using RecRoom.Core.Pools;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.Core.GameManagement
{
	public class LootTool : CurrencyTool
	{
		public delegate void CJCNLKDKADO(LootTool PKHNIDIMALE);

		[SerializeField]
		private LootManager.ADHKIGLDKHN lootType;

		[SerializeField]
		private int customValue;

		[SerializeField]
		private bool beaconOnlyEnabledWhenDespawning;

		[SerializeField]
		private float blinkFeedbackTimeRemaining;

		[SerializeField]
		private float blinkFeedbackMinFrequency;

		[SerializeField]
		private float blinkFeedbackMaxFrequency;

		[SerializeField]
		private PooledParticle pickupVFXPrefab;

		[SerializeField]
		private GameObject nameTagCanvas;

		[SerializeField]
		private Text nameTag;

		private bool JMBAFIPAFLD;

		private int PECMPPGKAEC;

		private float GAJIKIMFCJH;

		private HONEDBECDOK FBPAJPEEHNP;

		private global::MOBDJNEDDKC<bool> CNDAOMGHCMP;

		private global::MDAHOKBAGPC<bool, int, float> AJJLFADMGOB;

		private global::MOBDJNEDDKC<bool> ANBCBGCFNEF;

		public static CJCNLKDKADO CollectEvent;

public LootManager.ADHKIGLDKHN LootType
{
get 		{
			return LootManager.ADHKIGLDKHN.SMALL_PILE;
		}

}

public int CustomValue
{
get 		{
			return 0;
		}

}

public PooledParticle PickupVFXPrefab
{
get 		{
			return null;
		}

}

public bool IsLostLoot
{
get 		{
			return false;
		}

}

public int LostLootOwnerId
{
get 		{
			return 0;
		}

}

public float LostLootValue
{
get 		{
			return 0f;
		}

}

public bool AlreadyPickedUp
{
get 		{
			return false;
		}

}

private bool OODKLMOGOAO
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected void Update()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OBLJLMBPIPG()
		{
		}

		private void FKGHKDNJGIF(int EJIHLJJMOBD)
		{
		}

		private void PGECOKBOLCM()
		{
		}

		public void MasterInitializeAsLostLoot(int PCKCPNGPNBJ, float NBGOKOAPJGG)
		{
		}

		public void MasterStartDespawn(float OOBOIODABDP)
		{
		}

		public void MasterSetAlreadyPickedUp()
		{
		}

		private void NKIKFNNLKPJ()
		{
		}

		protected override void MBIOLEBFOOM(Tool IEGMBEPJMGC, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		public override bool CanBeTargetedByPlayer(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN)
		{
			return false;
		}

		protected override void BMAJDOLNIPC()
		{
		}
	}
}
