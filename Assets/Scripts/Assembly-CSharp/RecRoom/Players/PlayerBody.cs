using System;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Players
{
	public sealed class PlayerBody : MonoBehaviour
	{
		private enum AMOFAAIOEFB
		{
			Stationary = 0,
			Walking = 1,
			Disabled = 2
		}

		private const int DJECPHGDEMJ = 3;

		private const float DGGMMFKDIEN = 5f;

		[SerializeField]
		private VisibleInCamera visibleInCamera;

		[SerializeField]
		private Collider bodyCollider;

		[SerializeField]
		private Rigidbody bodyRigidbody;

		[SerializeField]
		private SimpleVolume bodyEnemyDamageRegion;

		[SerializeField]
		private Transform toolEquipSlotsRoot;

		[SerializeField]
		private PhotonView _photonView;

		[SerializeField]
		private float bodyWeightFollowTime;

		[SerializeField]
		private float neckHorizontalOffset;

		[SerializeField]
		private float neckVerticalOffset;

		[SerializeField]
		private float minPitch;

		[SerializeField]
		private float maxPitch;

		[SerializeField]
		private float minYaw;

		[SerializeField]
		private float maxYaw;

		[SerializeField]
		private float proneMinBodyLengthToKeepAboveGround;

		[SerializeField]
		private float pronePitchAngleSmoothTime;

		[SerializeField]
		private float proneYawSmoothTime;

		[SerializeField]
		private float proneMaxYaw;

		[SerializeField]
		private float maxForwardYaw;

		[SerializeField]
		private float minBrokenNeckDetectionAngle;

		[SerializeField]
		private float minBrokenNeckCompensationAngle;

		[SerializeField]
		private Animator headWalkAnimator;

		[SerializeField]
		private float WalkingAnimationMultiplier;

		[SerializeField]
		private AMBBOEBJPNH lowQualityLOD;

		private static readonly int HHLLALJPOJI;

		[NonSerialized]
		public bool AlignWithGravity;

		private Player JCPLJCIFGFK;

		private bool ACGGCDEGMHL;

		private Transform LHJGGHJIPGO;

		private Vector3 DFEHALGDIGE;

		private float LNADFCBJBDB;

		private Vector3 CCBPIGCHLJM;

		private Vector3 JPKOJFOOEPO;

		private Vector3 HLAABBOEPBH;

		private Vector3 CCAIGGNNMEL;

		private global::ADOKDOGIPIF<float> HDOPHKOPMOD;

		private readonly CGOBNNIEKLB BPAFAGBPAIA;

		private readonly CNHEOBEGMKA ANDMBDMMKEH;

		private readonly FIHGBEHGLGB AMOCCGFHHJM;

		private readonly global::MKJNCDLHHNA<bool> CNPIMOADDGM;

		private readonly FIHGBEHGLGB GOBHLBBPABE;

		private Vector3 CBMBLELEPDE;

		private Vector3 HJOKAPPLIDF;

		private Vector3 PBOFJNMPECF;

		private Vector3 NHKCEIMFBIF;

		private AMOFAAIOEFB AMCOAEOEDOL;

		private static Vector3 FPIENBALJKJ;

public PhotonView PhotonView
{
get 		{
			return null;
		}

}

public Player Player
{
get 		{
			return null;
		}

private set {
		}
}

public Rigidbody Rigidbody
{
get 		{
			return null;
		}

}

public Collider BodyCollider
{
get 		{
			return null;
		}

}

public PlayerCollider BodyPlayerCollider
{
get 		{
			return null;
		}

}

public SimpleVolume EnemyDamageRegion
{
get 		{
			return null;
		}

}

private AMOFAAIOEFB ABDCBCHEGPA
{
get 		{
			return AMOFAAIOEFB.Stationary;
		}

set {
		}
}

		private Vector3 AMPDNGDNJIN()
		{
			return default;
		}

		public void SetTorsoRendererAndCollisionEnabled(object IALNODEHBNN, bool BFDBCMGIOBG)
		{
		}

		private void OCJFNBKFJJF()
		{
		}

		public void AddCollisionDisabled(object IALNODEHBNN)
		{
		}

		public void RemoveCollisionDisabled(object IALNODEHBNN)
		{
		}

		private void AGBDHBLGDHA()
		{
		}

		public void AddHandsRotateShouldersRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveHandsRotateShouldersRestriction(object IALNODEHBNN)
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void UpdateBody()
		{
		}

		private void AIEIOCOLKFK(float OKBAJEAPIHG)
		{
		}

		private void EFFEBBFHFHG(bool PPIILKGOLFP)
		{
		}

		private void DPLMAJIFCFB(bool PPIILKGOLFP)
		{
		}

		private void BNMBOOCMGMC(bool PPIILKGOLFP)
		{
		}

		private void ABNJMNAIIAK(Vector3 HGPMMKIFHHB, Vector3 HDHILCFLOIJ, Vector3 OCENBLBFKHJ, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH)
		{
			INLGLHIPOMC = default;
			HEGBBJCMANH = default;
		}

		private Vector3 IMINJPMOHEB(Vector3 FJLLDGKADNH)
		{
			return default;
		}

		private void OHNDBBDHAFH(Vector3 HGPMMKIFHHB, out Vector3 AIIGKKHBGAI, out Vector3 CBCFCCHGDFH, out Vector3 IEBNHMMLDIA, out bool HFKCAPIJPEO)
		{
			AIIGKKHBGAI = default;
			CBCFCCHGDFH = default;
			IEBNHMMLDIA = default;
			HFKCAPIJPEO = default;
		}

		private Vector3 EEAMOGMAKJE()
		{
			return default;
		}

		private Vector3 KHEPHPFEGGL(Vector3 HGPMMKIFHHB, Vector3 LJFMJIPNECB, Vector3 PLHNEEOCFIC, bool PPIILKGOLFP)
		{
			return default;
		}

		private void GADBMNJNKPN(Vector3 HGPMMKIFHHB, Vector3 ACLPPDMGPID)
		{
		}

		private Vector3 EGNFJDKBPJM(Vector3 HGPMMKIFHHB)
		{
			return default;
		}

		private Vector3 AMHPMMHILLN(Vector3 NMBEMIKCNJJ, Vector3 AKNJMKGKLMG)
		{
			return default;
		}

		private Vector3 IDDCLBMKIJO(Vector3 PICLIENOAAI, Vector3 FJLLDGKADNH)
		{
			return default;
		}

		public bool ShouldUseHighQualityUpdates()
		{
			return false;
		}
	}
}
