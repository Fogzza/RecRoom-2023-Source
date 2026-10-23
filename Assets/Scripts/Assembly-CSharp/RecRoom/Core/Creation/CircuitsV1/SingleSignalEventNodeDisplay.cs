using System;
using System.Collections.Generic;
using RecRoom.CircuitsV1;
using UnityEngine;
using UnityEngine.Events;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public class SingleSignalEventNodeDisplay : CircuitEventNodeDisplayBase, LHGCLOHKAOA
	{
		[Serializable]
		public class SingleSignalReceived : UnityEvent<int>
		{
		}

		public EDBMANFHGGO signalInput;

		public bool ListenToZeroSignal;

		public SingleSignalReceived OnRecievedNewSignal;

		[SerializeField]
		private InputMetadata[] inputMeta;

public override InputMetadata[] InputMeta
{
get 		{
			return null;
		}

set {
		}
}

		protected override void BOIENBABEHB(Dictionary<EDBMANFHGGO, int> KLPFODAMNED)
		{
		}
	}
}
