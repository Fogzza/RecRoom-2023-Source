using System;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class VehicleTerrainMarkup : MonoBehaviour
	{
		public enum PNFJOJKLMJL
		{
			Blend = -1,
			CompactDirt = 0,
			LooseDirt = 1,
			Gravel = 2,
			Grass = 3,
			Mud = 4,
			Water = 5
		}

		[Serializable]
		public struct GroundDrivingConfig
		{
			public PNFJOJKLMJL type;

			public float frictionCoefficient;

			public float frictionTorque;

			public float extraVehicleDrag;

			public static GroundDrivingConfig Default;
		}

		[SerializeField]
		private Terrain terrain;

		[SerializeField]
		private GroundDrivingConfig[] groundConfigs;

		private void OnValidate()
		{
		}

		public GroundDrivingConfig GetBlendedDrivingConfig(Vector3 ADJINPMOILO)
		{
			return default;
		}
	}
}
