using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Core.GameManagement
{
	public class EquipmentSpawnerChest : MonoBehaviourPun
	{
		public delegate void NEFBAMIBBPD(EquipmentSpawnerChest BHJOAPIABAC);

		[SerializeField]
		private BaseOpenableChest chest;

		[SerializeField]
		private SparkleOutline sparkleEffect;

		[SerializeField]
		private Transform spawnOrigin;

		[SerializeField]
		private float spawnArcAngle;

		[SerializeField]
		private float spawnArcAngleMinRandomOffset;

		[SerializeField]
		private float spawnArcAngleMaxRandomOffset;

		[SerializeField]
		private float spawnRadius;

		[SerializeField]
		private float spawnSpeed;

		[SerializeField]
		private float spawnSpeedRandomMultiplier;

		[SerializeField]
		private float spawnMaxAngularSpeed;

		private global::MOBDJNEDDKC<bool> NMNMONHBBFB;

		public static readonly List<EquipmentSpawnerChest> AllChests;

		public static NEFBAMIBBPD ChestOpenEvent;

public bool IsEnabled
{
get 		{
			return false;
		}

set {
		}
}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Start()
		{
		}

		public void MasterEnable(bool BFDBCMGIOBG)
		{
		}

		public void MasterReset()
		{
		}

		public void GetEquipmentSpawnPhysics(float BEOPLBNPNJF, out Vector3 INLGLHIPOMC, out Quaternion POIOCLOKJGH, out Vector3 MCBCBMFBKCA, out Vector3 MEBJBANMPLK)
		{
			INLGLHIPOMC = default;
			POIOCLOKJGH = default;
			MCBCBMFBKCA = default;
			MEBJBANMPLK = default;
		}

		private void LAOMOJONPPG(BaseOpenableChest IEODCBDCDFF)
		{
		}

		private void MJCNPOOKNHM(BaseOpenableChest IEODCBDCDFF)
		{
		}

		private void IEEHHONMJGK(BaseOpenableChest IEODCBDCDFF)
		{
		}

		private void IDIEHBILCLL()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		private Vector3 FOGJAGBIBMG(float MILGOCGHFJG, Vector3 BPKEANIGKON)
		{
			return default;
		}
	}
}
