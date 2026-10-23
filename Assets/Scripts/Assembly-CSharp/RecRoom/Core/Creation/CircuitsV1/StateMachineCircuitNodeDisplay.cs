using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public class StateMachineCircuitNodeDisplay : CircuitNodeDisplay
	{
		private sealed class CIENLIGFMEN
		{
			public StateMachineState toState;

			internal bool _003CUpdateStateTransitionsForState_003Eb__0(StateMachineTransition elem)
			{
				return false;
			}
		}

		[SerializeField]
		private ConnectionPoint mainConnectionPoint;

		[SerializeField]
		private LineRenderer startStateLine;

		public const byte INVALID_STATE = byte.MaxValue;

		private byte PMHHFABLPAC;

		private Dictionary<byte, StateMachineState> AEFKINBPBDL;

		private Vector3 MLLHDDPNGKO;

		private Vector3 MGIMCPLBBJH;

		private byte CALMJPKEMOE;

public IEnumerable<StateMachineState> AllStates
{
get 		{
			return null;
		}

}

public byte CurrentState
{
get 		{
			return 0;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected override void FLBLLLBEIHC(PhotonView CIPJGOKLPNK)
		{
		}

		public override void OnCircuitNodeInitialized(BNOPDNILAFA KNBPIEINLIG)
		{
		}

		public override void OnCircuitNodeDeserialized()
		{
		}

		private bool DPPCHAILIGE(EDBMANFHGGO HHOGFBCFGAB)
		{
			return false;
		}

		public bool TryGetAvailableInputSlot(out EDBMANFHGGO PIBFOFICOPE)
		{
			PIBFOFICOPE = default;
			return false;
		}

		public void AddState(StateMachineState HDCJBCHGIOK)
		{
		}

		public void RemoveState(StateMachineState DADHJJNJEFA)
		{
		}

		public bool IsStateRemoved(byte ENFMLJPDLHP)
		{
			return false;
		}

		public bool CanAddState()
		{
			return false;
		}

		public byte GetAvailableStateIndex()
		{
			return 0;
		}

		private void PLKPPBNKLGN(ConnectionPoint PCJINKBIFLC, ConnectionPoint HLBJDAGMEND, ConnectionPoint.ININJKAJDDN LOHCFFGPEAA = null)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcMasterRequestSetDefaultState(StateMachineState DADHJJNJEFA)
		{
		}

		private void KLMFNDJJNCB(StateMachineState DADHJJNJEFA)
		{
		}

		private void NBCGMKPNHHK()
		{
		}

		private void GAHHBGJBCCA(float OKBAJEAPIHG)
		{
		}

		private void NMMCIEIBCFP()
		{
		}

		private void NDEDDOPKPJD()
		{
		}

		public void CreateStateTransitionsForDeserializedState(StateMachineState HDCJBCHGIOK)
		{
		}

		public void UpdateStateTransitionsForState(StateMachineState DADHJJNJEFA)
		{
		}

		private byte CBHIINLCLED()
		{
			return 0;
		}

		public void ModifyCircuitStateValues(StateMachineState DADHJJNJEFA, Dictionary<object, object> MIILKIDEDGJ = null)
		{
		}

		public void ModifyCircuitStateTransitions(StateMachineState DADHJJNJEFA, Dictionary<object, object> MIILKIDEDGJ = null)
		{
		}

		public void ModifyCircuitRemoveState(StateMachineState DADHJJNJEFA, Dictionary<object, object> MIILKIDEDGJ = null)
		{
		}

		public void ModifyCircuitAddState(StateMachineState DADHJJNJEFA, Dictionary<object, object> MIILKIDEDGJ = null)
		{
		}

		public void ModifyCircuitDefaultState(Dictionary<object, object> MIILKIDEDGJ = null)
		{
		}

		public void ModifyCircuit(Dictionary<object, object> MIILKIDEDGJ)
		{
		}

		public void UpdateMetaData()
		{
		}
	}
}
