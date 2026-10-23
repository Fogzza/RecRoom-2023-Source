using System;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Tools;
using UnityEngine;

namespace RecRoom.Activities.Quest.Goblin2
{
	public class Potion : MonoBehaviourPun
	{
		public delegate void GHFELGOCKNN(Potion PLICGODCNBM, CHILKDJABBF EKOFNPFCLMO);

		private GHFELGOCKNN PFIKJEBFNGE__BackingField;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private DrinkableBottle waterBottle;

		[SerializeField]
		private BreakableObject breakableObject;

		[SerializeField]
		private FGBJLABIGCM powerupType;

		[SerializeField]
		private int drinksToActivate;

		[SerializeField]
		private float drinkResetTime;

		[SerializeField]
		private RecRoomAudioClip[] clinkSfx;

		[SerializeField]
		private bool shareable;

		[SerializeField]
		private Transform liquidLevelTransform;

		[SerializeField]
		private Vector3[] liquidScaleByDrinks;

		private CHILKDJABBF DDGEPFOJEOD;

		private float EMENBPJNLPN;

		private global::MOBDJNEDDKC<int> KHAGJPEBEHN;

		[NonSerialized]
		public bool AutomaticDrinkingEnabled;

public int ConsecutiveDrinks
{
get 		{
			return 0;
		}

private set {
		}
}

public int DrinksLeft
{
get 		{
			return 0;
		}

}

public event GHFELGOCKNN PotionActivatedEvent {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void ScreensTryConsumeDrink(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private void OnTriggerEnter(Collider ADMCDJKKCIA)
		{
		}

		private void MBIOLEBFOOM(Tool PMEFICGEDFK, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		private void CDPDNMOBOAD(DrinkableBottle IHJLCMGGPDD, CHILKDJABBF POHGAFHJGJF)
		{
		}

		private void FDFKHCBMHJO(DrinkableBottle IHJLCMGGPDD)
		{
		}

		private void GCFEKNDCLJI()
		{
		}

		private void NEJEICHBPFJ()
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnPotionActivated(CHILKDJABBF CLKBOLMGCCD)
		{
		}
	}
}
