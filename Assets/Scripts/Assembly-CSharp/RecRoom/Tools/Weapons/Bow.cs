using System;
using RecRoom.Audio;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class Bow : RangedWeapon
	{
		[SerializeField]
		private float maxDrawLength;

		[SerializeField]
		private AnimationCurve arrowChargeOverDrawLengthCurve;

		[SerializeField]
		private Transform rightHandedArrowShelfTransform;

		[SerializeField]
		private Transform leftHandedArrowShelfTransform;

		[SerializeField]
		private float minChargeArrowSpeed;

		[SerializeField]
		private RecRoomAudioClip limbCreakAudioClip;

		[SerializeField]
		private AnimationCurve pitchShiftCurve;

		[SerializeField]
		private float limbFeedbackDistanceInterval;

		[SerializeField]
		private RecRoomAudioClip arrowNockingAudioClip;

		[SerializeField]
		private Transform meshTransform;

		[NonSerialized]
		public bool FireArrowOnStringPickupRelease;

		private BowArrow IEOIFDIABFO;

		private float HILKAIFIOFL;

		private IDisposable LBOMEMELOPJ;

		protected static readonly int PHLBFHADGJA;

		private BowString MKLNEFMFNAF;

		private OffsetRotationRigidbodyPickup DIBCAOMKJJB;

public BowString BowString
{
get 		{
			return null;
		}

set {
		}
}

public OffsetRotationRigidbodyPickup OffsetRotationRigidbodyPickup
{
get 		{
			return null;
		}

private set {
		}
}

private Transform DHGHNEJELFO
{
get 		{
			return null;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void ICFECOPDCIL()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void KNALNPOIOPN(Tool IEGMBEPJMGC)
		{
		}

		private void MNPLCFMNCJL(Tool IEGMBEPJMGC)
		{
		}

		public void ReadyArrow()
		{
		}

		public void AuthorityFireArrowAtTargetPoint(float NGFAGNLPAPB)
		{
		}

		private void ELCCLBMHNLH(Vector3 HLFIBIDOLEF, float NGFAGNLPAPB)
		{
		}

		public void OnStringPickup()
		{
		}

		public void OnStringRelease()
		{
		}

		protected override void MPNCIDCFDNM(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 OIEPDFJCEHE, float BHEFDILBFOI, bool GHCPLAPAGHB, byte CMBCNFBLLNI)
		{
		}

		private void JOHLDJEAHCL(float PLGJMBNMALJ)
		{
		}

		private void KFEHGMJCGMF(bool LBINIIAEHLF)
		{
		}
	}
}
