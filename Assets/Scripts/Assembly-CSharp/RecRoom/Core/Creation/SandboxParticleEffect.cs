using System;
using RecRoom.Core.Pools;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	[Serializable]
	public class SandboxParticleEffect : ScriptableObject
	{
		public string FriendlyName;

		public PooledParticle Prefab;

		public float MaxScale;

		public float MinScale;

		public float MaxSpeed;

		public float MinSpeed;

		[SerializeField]
		private SerializedGuid guid;

		public Guid Guid => default;
	}
}
