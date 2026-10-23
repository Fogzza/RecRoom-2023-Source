using System;
using System.Collections.Generic;
using RecRoom.CircuitsV1;
using UnityEngine;
using UnityEngine.Events;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public class CircuitEventNodeDisplay : CircuitEventNodeDisplayBase, LHGCLOHKAOA
	{
		[Serializable]
		public class NodeInputReceived : UnityEvent<Dictionary<EDBMANFHGGO, int>>
		{
		}

		public NodeInputReceived OnRecievedNewInput;

		[SerializeField]
		private InputMetadata[] inputMeta;

		[SerializeField]
		private OutputMetadata[] outputMeta;

public override InputMetadata[] InputMeta
{
get 		{
			return null;
		}

set {
		}
}

public override OutputMetadata[] OutputMeta
{
get 		{
			return null;
		}

set {
		}
}

		public void AddInputMeta(EDBMANFHGGO OBONMNBJMLD, string GKHMKKBKEKC)
		{
		}

		public void AddInputMeta(InputMetadata NFGMCHFKCNH)
		{
		}

		public void RemoveInputMeta(EDBMANFHGGO GCKMKIKFHFK)
		{
		}

		protected override void BOIENBABEHB(Dictionary<EDBMANFHGGO, int> KLPFODAMNED)
		{
		}
	}
}
