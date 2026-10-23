using System;
using RecRoom.Activities.Vehicles;
using UnityEngine;

public class DebugVehicleScenarioConfig : ScriptableObject
{
	[Serializable]
	public class Scenario
	{
		[Serializable]
		public class ScenarioVersionBase
		{
			public virtual string Name { get; }

			public virtual void AGKICHFHMHD(GroundVehicle GFNJONFMHFK)
			{
			}
		}

		[Serializable]
		public class ScenarioV0 : ScenarioVersionBase
		{
			public enum AJCHNOGOPPM
			{
				CURRENT = 0,
				OFFSET_FROM_CURRENT = 1,
				CUSTOM = 2,
				OFFSET_FROM_CUSTOM = 3
			}

			[SerializeField]
			private string name;

			public AJCHNOGOPPM positionSource;

			[SerializeField]
			public Vector3 customPosition;

			[SerializeField]
			public Vector3 positionOffset;

			public AJCHNOGOPPM rotationSource;

			[SerializeField]
			public Vector3 customRotation;

			[SerializeField]
			public Vector3 rotationOffset;

			public Vector3 LinearVelocity;

			public Vector3 AngularVelocity;

			public bool Depenetrate;

			public bool ResetSuspensionState;

			public override string Name => null;

			private Vector3 DHEDODPMONG(Vector3 CDCEFBJHIAN)
			{
				return default;
			}

			private Quaternion HCNLPOFMHLF(Quaternion GDHHCIKHKAJ)
			{
				return default;
			}

			public override void AGKICHFHMHD(GroundVehicle GFNJONFMHFK)
			{
			}
		}

		public ScenarioV0 ScenarioV0Instance;

		private ScenarioVersionBase CurrentVersion => null;

		public string Name => null;

		public void AGKICHFHMHD(GroundVehicle GFNJONFMHFK)
		{
		}
	}

	[SerializeField]
	public Scenario[] Scenarios;
}
