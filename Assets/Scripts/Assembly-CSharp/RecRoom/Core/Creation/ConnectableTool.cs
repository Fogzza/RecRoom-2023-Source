using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class ConnectableTool : MonoBehaviourPun, FEFLLFBLFPG, AGDEBJCJJPB, COJCPCLGIAI, IEquatable<AGDEBJCJJPB>, NKHKPBPHIEG
	{
		private AGPBNJJLCOP implementation;

		[SerializeField]
		private ConnectionPoint[] connectionPoints;

		[SerializeField]
		private Tool _tool;

		public AGPBNJJLCOP Impl => null;

		public AGDEBJCJJPB ParentConnectable => null;

		public Vector3 RelativePositionToParent => default;

		public Quaternion RelativeRotationToParent => default;

		public bool IsParented => false;

		public bool ParentIsTool => false;

		public Tool ParentTool => null;

		public Tool RootTool => null;

		public IEnumerable<AGDEBJCJJPB> ChildrenConnectables => null;

		public bool PhysicallyUnparented
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Tool Tool => null;

		public Transform Transform => null;

		public GameObject GameObject => null;

		public string Name => null;

		public Guid PersistenceId => default;

		public int PhotonId => 0;

		public HPHBHAKAACD ObjectId => default;

		public virtual bool ShouldSerializeUnparented => false;

		public event ANFBFDNAEDE ChildAddedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ANFBFDNAEDE ChildRemovedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ANFBFDNAEDE ConnectionModifiedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event NDPLCNICHIL RootChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private AGPBNJJLCOP GetOrInit()
		{
			return null;
		}

		private void Init()
		{
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Start()
		{
		}

		void NKHKPBPHIEG.OnSelected()
		{
		}

		void NKHKPBPHIEG.OnDeselected()
		{
		}

		public Tool GetSafeRootTool()
		{
			return null;
		}

		protected virtual bool CustomPickupCondition(Tool thisTool, Player selectingPlayer, Vector3 selectionPoint, bool physicalPickup)
		{
			return false;
		}

		protected virtual Tool CustomToolForwarding()
		{
			return null;
		}

		public void AuthorityParentThisConnectableToOther(int slotIndex, AGDEBJCJJPB parentConnectable, int parentSlotIndex)
		{
		}

		public void AuthorityUnparentThisConnectableFromOther()
		{
		}

		public void AuthorityParentOtherConnectableToThis(int slotIndex, AGDEBJCJJPB childConnectable, int childSlotIndex, Vector3? relativePosition = null, Quaternion? relativeRotation = null)
		{
		}

		public void AuthorityUnparentOtherConnectableFromThis(AGDEBJCJJPB childConnectable)
		{
		}

		public void SetConnectionPoint(int index, Vector3 pos)
		{
		}

		public void OnDeformationUpdateChildrenPositionAndRotation(Vector3 previousPosition)
		{
		}

		public void AuthorityUpdateParentAndChildrenNodesRelativePositionsAndRotations()
		{
		}

		public OBIIECHNFJK NavMeshNotSupportedWhenParented()
		{
			return OBIIECHNFJK.NotSupported;
		}

		public virtual Vector3 GetConnectionSlotPosition(int slotIndex)
		{
			return default;
		}

		public virtual Vector3 GetConnectionSlotLocalPosition(int slotIndex)
		{
			return default;
		}

		public virtual Color GetConnectionSlotColor(int slotIndex)
		{
			return default;
		}

		public virtual bool CanConnectTo(int slotIndex, AGDEBJCJJPB otherConnectable, int otherConnectableSlotIndex)
		{
			return false;
		}

		public virtual bool Equals(AGDEBJCJJPB other)
		{
			return false;
		}

		public virtual void ParentChanged(int slotIndex, AGDEBJCJJPB newParentConnectable, int newParentSlot, Vector3 newRelativePosition, Quaternion newRelativeRotation)
		{
		}

		public virtual void ChildAdded(int slotIndex, AGDEBJCJJPB newChildConnectable, int newChildSlot, Vector3 relativePosition, Quaternion relativeRotation)
		{
		}

		public virtual void ChildRemoved(int slotIndex, AGDEBJCJJPB removedChildConnectable, int removedChildSlot)
		{
		}

		public virtual void ConnectionModified(int slotIndex, AGDEBJCJJPB parentConnectable, int parentSlotIndex, Vector3 relativePosition, Quaternion relativeRotation)
		{
		}

		public virtual void RootChanged(AGDEBJCJJPB previousRootConnectable, AGDEBJCJJPB newRootConnectable)
		{
		}

		private static void RegisterRpcSerializationHandlers()
		{
		}

		private static void UnregisterRpcSerializationHandlers()
		{
		}

		private static object SerializeIConnectable(object input)
		{
			return null;
		}

		private static object DeserializeIConnectable(object input)
		{
			return null;
		}
	}
}
