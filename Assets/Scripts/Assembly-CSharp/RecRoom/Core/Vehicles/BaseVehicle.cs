using System;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Core.Vehicles
{
	public abstract class BaseVehicle : MonoBehaviourPun, IOMDCIACIMF
	{
		[SerializeField]
		protected RigidbodyEx rigidbodyEx;

		[SerializeField]
		private ScreenVehicleController screenController;

		protected float OMNCIAKEMBA;

		protected float LICIFGJOOOH;

		private CHILKDJABBF NFBBEKBEBEE;

		private global::MOBDJNEDDKC<int> AHPLGNFPBBE;

		public Action<BaseVehicle, CHILKDJABBF> PlayerBoardEvent;

		public Action<BaseVehicle, CHILKDJABBF> PlayerExitEvent;

		private const float FHFIGPKDICN = 0f;

		private const float MEFFCGDMHFN = 0.2f;

public RigidbodyEx RigidbodyEx
{
get 		{
			return null;
		}

}

public CHILKDJABBF Rider
{
get 		{
			return null;
		}

private set {
		}
}

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void LocalPlayerBoard()
		{
		}

		public ScreenVehicleController GetScreenController()
		{
			return null;
		}

		protected abstract void GHDLHBBBDEL(Player EKOFNPFCLMO, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH);

		protected virtual void LPLOJFCFBCH()
		{
		}

		protected virtual void EEDHMNMAKMC(CHILKDJABBF MDAFKDJGBLH)
		{
		}

		protected virtual void CBEHAHCFNIH(CHILKDJABBF PAAEPEPFNHE)
		{
		}

		private void MLFJMFFLBHL()
		{
		}

		private void LAELCNBNDND()
		{
		}
	}
}
