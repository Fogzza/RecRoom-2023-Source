using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public abstract class MakerPenVROffHandTranslate<T> : MakerPenVROffHandOperation
	{
		private sealed class NOONLKGCNFA
		{
			public MakerPenVROffHandTranslate<T> _003C_003E4__this;

			public IReadOnlyDictionary<Collider, DHJLEHBOGBG> collidersMap;

			internal bool _003CUpdateMovement_003Eb__0(Collider collider)
			{
				return false;
			}
		}

		[NonSerialized]
		protected bool clearSelectionOnRelease;

		[NonSerialized]
		private bool _isPerformingMove;

		[NonSerialized]
		protected Vector3 pickupRelativePivotPoint;

		[NonSerialized]
		protected float pickupStartTime;

		[NonSerialized]
		protected float magnetDuration;

		[NonSerialized]
		protected Quaternion handRotationOffset;

		[NonSerialized]
		protected Vector3 objectPickupOffset;

		[NonSerialized]
		protected Vector3 worldPickupPosition;

		[NonSerialized]
		protected Vector3 originalPosition;

		[NonSerialized]
		protected Quaternion originalRotation;

		[NonSerialized]
		protected Quaternion prevSnappedRot;

		[NonSerialized]
		protected Vector3 prevSnappedPos;

		[NonSerialized]
		protected Vector3 prevFrameSelectionWorldPos;

		private const float MAGNET_DURATION_MIN = 0.03f;

		private const float MAGNET_DURATION_MAX = 0.15f;

		private const float SNAPPING_STICKYNESS = 0.4f;

		private const float SNAPPING_SMOOTHNESS = 0.3f;

		private const float SNAPPING_ROT_SMOOTHNESS = 0.4f;

		private KFFPADCMOAJ rotatedBoundsCollision;

		protected bool isPerformingMove
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected virtual global::FNLEEFFPAAJ<T> SelectionContext { get; }

		protected virtual int MaxAllowedBounds => 0;

		public override void HGLAFJGGJJP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		public override void KDCJDJMMOIB(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected virtual FBEHJNCKJPN BENGDPDMNBP()
		{
			return FBEHJNCKJPN.CreateShape;
		}

		protected void GAHKPFFGGEN(T[] EELPNFMFDDB, ref int MECHOBLPLIL, ref Vector3 PFKIFLJCDFF, ref Collider FJPMBOEANID)
		{
		}

		protected virtual bool IKIFEFKKIBA(T[] EELPNFMFDDB, int PFFGDNCHJFD)
		{
			return false;
		}

		protected virtual void ONMGAKDFAPA(bool FENEHNOCMAM, Vector3 GFIGODPPIKP)
		{
		}

		protected virtual bool KCGNILIKJDB()
		{
			return false;
		}

		protected void GKGHFLJNJEL()
		{
		}

		protected abstract void NKPFLGJHALH();

		protected abstract void KDAPCMMBGOL(Vector3 GACEEHCHKKI);

		protected abstract void OOLDPNCBOGE(Quaternion EMJCGIGPJKI, Vector3? CEMHEJBNIBC = null);

		protected abstract void BOLOAPLLJKJ();

		protected void BLDKNEPNIBE()
		{
		}

		protected virtual void BLHHIEGPNHP()
		{
		}
	}
}
