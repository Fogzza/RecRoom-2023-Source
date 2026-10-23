using System;
using System.Collections.Generic;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.CircuitsV2.Adapter
{
	public sealed class MockCircuitsV2Manager : MonoBehaviour, EPHNMPLOKJG
	{
		[SerializeField]
		private Chip chipPrefab;

		[SerializeField]
		private MockCircuitsViewDependencies _circuitsViewDependencies;

		private GODLDNHNMLJ KCBJOFCEEOA;

		private Dictionary<Guid, (Chip, MockChipAdapter)> MEFLAKIEPCN;

		private List<Guid> HIHIGPAMPKD;

		public MockChipAdapter mockChipAdapter;

		[HideInInspector]
		public SerializedGuid srcNodeId;

		[HideInInspector]
		public int srcNodeDescIndex;

		[HideInInspector]
		public int srcPortIndex;

		[HideInInspector]
		public SerializedGuid dstNodeId;

		[HideInInspector]
		public int dstNodeDescIndex;

		[HideInInspector]
		public int dstPortIndex;

public HEJEFJABMHN CircuitsViewDependencies
{
get 		{
			return null;
		}

}

		public bool TryGetChip(in Guid IKHNIJKGJFD, out Chip JJMNDCAFBDA)
		{
			JJMNDCAFBDA = null;
			return false;
		}

		public void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void AddChip(MockChipAdapter JJMNDCAFBDA)
		{
		}

		public void ConnectChips(in Guid NMLPLKEFOHI, int JLLECIFFCON, int ENJEKMMNJKG, in Guid JJMPODDJMCJ, int FBEHCEJELLM, int AIGIIICCJOJ)
		{
		}

		public void DisconnectChips(in Guid NMLPLKEFOHI, int JLLECIFFCON, int ENJEKMMNJKG, in Guid JJMPODDJMCJ, int FBEHCEJELLM, int AIGIIICCJOJ)
		{
		}

		public void Clear()
		{
		}

		private bool DNMAJELLBOC(in Guid KKBFAENPLID, out Chip JJMNDCAFBDA)
		{
			JJMNDCAFBDA = null;
			return false;
		}

		bool EPHNMPLOKJG.TryGetChip(in Guid KKBFAENPLID, out Chip JJMNDCAFBDA)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DNMAJELLBOC
			return this.DNMAJELLBOC(in KKBFAENPLID, out JJMNDCAFBDA);
		}
	}
}
