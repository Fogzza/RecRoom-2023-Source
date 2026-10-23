using System;
using UnityEngine;

namespace RecRoom.CircuitsV2.Config
{
	[Serializable]
	public sealed class GameConfig : GameConfigSourcedConfiguration, GPCAHGDNIAF
	{
		[SerializeField]
		private int actionCompressionThresholdBytes;

		private int? _actionCompressionThresholdBytesFromGameConfig;

		[SerializeField]
		private int snapshotThresholdBytes;

		private int? _snapshotThresholdBytesFromGameConfig;

		[SerializeField]
		private int rpcMessageSplitSizeBytes;

		private int? _rpcMessageSplitSizeBytesFromGameConfig;

		public int ActionCompressionThresholdBytes => 0;

		public int SnapshotThresholdBytes => 0;

		public int SnapshotThresholdBytesSerializedDefault => 0;

		public int RpcMessageSplitSizeBytes => 0;

		private static int PENOIPMLODL(int ODBGNNDKAMK)
		{
			return 0;
		}

		protected override void CPJEOKKDJBC()
		{
		}
	}
}
