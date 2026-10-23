using Photon.Pun;
using UnityEngine;

namespace RecRoom.Activities.Arena
{
	public class ArenaVendingMachineSlot : MonoBehaviourPun
	{
		public delegate void DIKCCJJPBBC(ArenaVendingMachineSlot HHOGFBCFGAB, CHILKDJABBF CCCPIDKGIFJ, int EEHIDEKCNKP);

		[SerializeField]
		protected int creditCost;

		[SerializeField]
		private TextMesh priceTagLabel;

		[SerializeField]
		private MeshRenderer priceTagBackground;

		[SerializeField]
		private GameObject lockIcon;

		protected bool EHAGONKLLDH;

		protected ArenaVendingMachine KLNODHDDMJD;

		protected GIBEGHKMCIE NEBNOBLPNEP;

		private DIKCCJJPBBC MKACGEHOBEF__BackingField;

public event DIKCCJJPBBC MasterPurchaseRequestEvent {
add {
		}
remove {
		}
}

		protected void EMJBJIDCDIP(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
		}

		public virtual void Initialize(ArenaVendingMachine KLNODHDDMJD, GIBEGHKMCIE NEBNOBLPNEP)
		{
		}

		public virtual void SetLocalPlayerCredits(int EOOEHDBBHMM)
		{
		}

		public virtual void OnMasterPurchaseSuccess()
		{
		}

		private void OOMCHMCFBLI()
		{
		}
	}
}
