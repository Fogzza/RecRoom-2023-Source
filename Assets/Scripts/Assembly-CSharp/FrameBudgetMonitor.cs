using System;
using UnityEngine;

public class FrameBudgetMonitor : SingletonMonoBehaviour<FrameBudgetMonitor>
{
	[Serializable]
	private class Property
	{
		public string Name;

		public float MeanLimit;

		public float PeakLimit;

		public string Suffix;

		public float Multiplier;

		[NonSerialized]
		public int Id;

		[NonSerialized]
		public float Mean;

		[NonSerialized]
		public float Peak;
	}

	private enum KLJEOKMKAKM
	{
		Bandwidth = 0,
		RPCs = 1,
		RoomPropUpdates = 2,
		ObjectInstantiate = 3,
		ObjectDestroys = 4,
		OwnershipTransfers = 5
	}

	[Serializable]
	private class NetworkProperty : Property
	{
		public KLJEOKMKAKM Type;
	}

	[SerializeField]
	private Property[] cpuProperties;

	[SerializeField]
	private Property[] gpuProperties;

	[SerializeField]
	private NetworkProperty[] outboundNetworkProperties;

	[SerializeField]
	private NetworkProperty[] inboundNetworkProperties;
}
