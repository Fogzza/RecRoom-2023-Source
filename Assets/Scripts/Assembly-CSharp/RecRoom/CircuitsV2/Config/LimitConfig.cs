using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace RecRoom.CircuitsV2.Config
{
	[Serializable]
	public sealed class LimitConfig : GameConfigSourcedConfiguration
	{
		[Serializable]
		private sealed class NetworkConfig
		{
			public int NumPlayersForActivation;

			public int Bytes;

			public int BytesTimeWindowFrame60s;

			public int Rpcs;

			public int RpcTimeWindowFrame60s;
		}

		[StructLayout((LayoutKind)3)]
		private struct NNCDPAMHPPK
		{
			public int activeNetworkConfig;

			public NetworkConfig[] currentNetworkConfigs;

			public int maxPlayers;
		}

		[SerializeField]
		private NetworkConfig[] network;

		private NetworkConfig _activeNetworkConfig;

		[SerializeField]
		private int compute;

		public const int CHIPS_DEFAULT = 3000;

		[SerializeField]
		private int chips;

		[SerializeField]
		private int cloudValues;

		[SerializeField]
		private float cloudValuesAutosaveSeconds;

		[SerializeField]
		private int unculledChips;

		[SerializeField]
		private int visibleChips;

		[SerializeField]
		private int inkPerChip;

		private NetworkConfig ActiveNetworkConfig => null;

		public int NumPlayersForActivation => 0;

		public int NetworkBytes => 0;

		public int NetworkBytesTimeWindowFrame60s => 0;

		public int Rpcs => 0;

		public int RpcTimeWindowFrame60s => 0;

		public int Compute => 0;

		public int Chips => 0;

		public int CloudValues => 0;

		public float CloudValuesAutosaveSeconds => 0f;

		public int UnculledChips => 0;

		public int VisibleChips => 0;

		public int InkPerChip => 0;

		protected override void CPJEOKKDJBC()
		{
		}

		[CompilerGenerated]
		private static bool GCGKGHKBBDC(ref NNCDPAMHPPK P_0)
		{
			return false;
		}
	}
}
