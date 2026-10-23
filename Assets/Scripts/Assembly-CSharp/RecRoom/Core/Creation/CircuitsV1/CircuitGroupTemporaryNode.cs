using System;
using UnityEngine;
using UnityEngine.Events;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public class CircuitGroupTemporaryNode : ConnectionPoint
	{
		[Serializable]
		public class TemporaryNodeConnectionEndEvent : UnityEvent<ConnectionPoint>
		{
		}

		[SerializeField]
		private TemporaryNodeConnectionEndEvent OnTemporaryNodeConnectionEnd;

		public CircuitGroup OwningGroup;

		public override void ConnectionEnd(ConnectionCreationContext DELCOFCGDFF, ConnectionPoint PCJINKBIFLC, ConnectionPoint HLBJDAGMEND, EBNPGOBCABE IFEOGBCJEBI, ININJKAJDDN LOHCFFGPEAA = null)
		{
		}
	}
}
