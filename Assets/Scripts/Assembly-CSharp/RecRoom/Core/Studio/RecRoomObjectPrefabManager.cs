using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core.Studio
{
	public class RecRoomObjectPrefabManager : SingletonMonoBehaviour<RecRoomObjectPrefabManager>
	{
		private readonly Dictionary<Guid, GameObject> IDELAAMMGON;

		private GameObject FHMHEBMBKGK;

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public bool IsKnownPrefab(Guid HKEGNBMGHBK)
		{
			return false;
		}

		public bool TryGetPrefab(Guid HKEGNBMGHBK, out GameObject GDEKLMNKJBC)
		{
			GDEKLMNKJBC = null;
			return false;
		}

		public void RegisterPrefabs(IReadOnlyList<RecRoomObjectPrefabEntry> KOJPAGOKKBA)
		{
		}

		private void GGEHJBEKFIJ(RecRoomObjectPrefabEntry OCMJJKDAPDD)
		{
		}

		private void BKDHJJJJNNJ(GameObject GDEKLMNKJBC)
		{
		}
	}
}
