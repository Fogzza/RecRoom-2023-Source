using System;
using RecRoom.Core;
using RecRoom.Core.Creation;
using RecRoom.Inputs;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public abstract class MakerPenVROffHandOperation
	{
		protected static readonly DHJLEHBOGBG[] RAYCAST_OBJECTS_RESULTS;

		protected static int RaycastObjectsLastHitCount;

		protected static Vector3 RaycastObjectsLastHitPoint;

		protected static Collider RaycastObjectsLastHitCollider;

		protected static readonly Guid[] RAYCAST_SHAPES_RESULTS;

		protected static int RaycastShapesLastHitCount;

		protected static Vector3 RaycastShapesLastHitPoint;

		protected static Collider RaycastShapesLastHitCollider;

		[NonSerialized]
		private VRCreationController _controller;

		protected VRCreationController Controller
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		protected VRInputHandler OffHandInput => null;

		protected PlayerHand OffHand => null;

		protected MakerPen MakerPen => null;

		protected CreationContext ObjectContext => null;

		protected MMMPKIMPKKC ShapeContext => null;

		public MakerPenVROffHandOperation()
		{
		}

		public virtual void IHEKMEOIBOI(VRCreationController IJIAEDONGKE)
		{
		}

		public virtual void HGLAFJGGJJP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		public virtual void OJJECDPPKMI()
		{
		}

		public virtual void KDCJDJMMOIB(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected int KECOBNBNOEK<T>(global::FNLEEFFPAAJ<T> DELCOFCGDFF, T[] EELPNFMFDDB, ref Vector3 PFKIFLJCDFF, ref Collider FJPMBOEANID, out bool PKLDMPLDNNM)
		{
			PKLDMPLDNNM = default;
			return 0;
		}

		protected bool KPHJDFCPBAG()
		{
			return false;
		}

		protected bool KMKBPJBOAOO()
		{
			return false;
		}

		protected bool KGNPADABACJ<T>(global::FNLEEFFPAAJ<T> DELCOFCGDFF, int MECHOBLPLIL, T[] EELPNFMFDDB)
		{
			return false;
		}
	}
}
