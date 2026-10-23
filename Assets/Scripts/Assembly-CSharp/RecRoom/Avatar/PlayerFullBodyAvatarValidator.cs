using System;
using RecRoom.Avatars;
using RecRoom.Avatars.Face;
using UnityEngine;

namespace RecRoom.Avatar
{
	public class PlayerFullBodyAvatarValidator : MonoBehaviour
	{
		public Color hairPrimaryColor;

		public Color hairSecondaryColor;

		public Color beardPrimaryColor;

		public Color beardSecondaryColor;

		public Color skinColor;

		public int faceShapeIndex;

		public int hairPatternIndex;

		public int beardPatternIndex;

		public AvatarFaceShape[] faceShapes;

		public AvatarHairPattern[] hairPatterns;

		public bool hideEars;

		public AvatarCustomizationSettings.JKCCIHPHNHL useHelmetHair;

		public AnchorParams hatAnchorParams;

		public CLMEHHLKBJG HatAnchorRestrictions;

		public bool UseHatAnchorParams;

		public FullBodyInspectorOutfitSelection hat;

		public FullBodyInspectorOutfitSelection hair;

		public FullBodyInspectorOutfitSelection ear;

		public FullBodyInspectorOutfitSelection eye;

		public FullBodyInspectorOutfitSelection mouth;

		public FullBodyInspectorOutfitSelection neck;

		public FullBodyInspectorOutfitSelection shirt;

		public FullBodyInspectorOutfitSelection belt;

		public FullBodyInspectorOutfitSelection pocket;

		public FullBodyInspectorOutfitSelection rightHand;

		public FullBodyInspectorOutfitSelection leftHand;

		public FullBodyInspectorOutfitSelection legs;

		public FullBodyInspectorOutfitSelection leftFoot;

		public FullBodyInspectorOutfitSelection rightFoot;

		[SerializeField]
		public PlayerAvatarDisplay avatarDisplay;

		private KBNLMPKNOHN BOFHFBPOFIJ;

		public Animator leftHandAnimator;

		public Animator rightHandAnimator;

		public PlayerFacialAnimator facialAnimator;

		public Animator animator;

		public RigidbodyEx originTrackedSpace;

		public RigidbodyEx headTrackedSpace;

		public RigidbodyEx leftHandTrackedSpace;

		public RigidbodyEx rightHandTrackedSpace;

		public Transform headIKEffector;

		public Transform leftHandIKEffector;

		public Transform rightHandIKEffector;

		public int lod;

		public OAKPNJLCDDM rightHandState;

		public float rightHandCurl;

		public OAKPNJLCDDM leftHandState;

		public float leftHandCurl;

		public int eyeBrowSelection;

		public int eyeSelection;

		public int eyeGleamSelection;

		public int mouthSelection;

		public float eyeBrowPositionOffsetHorizontal;

		public float eyeBrowPositionOffsetVertical;

		public float eyeBrowScale;

		public float eyePositionOffsetHorizontal;

		public float eyePositionOffsetVertical;

		public float eyeScale;

		public float mouthPositionOffsetHorizontal;

		public float mouthPositionOffsetVertical;

		public float mouthScale;

		public int facialExpressionIndex;

		public float normalizedTime;

		private bool MBHFDAJBDEO;

		public readonly GGPGBAKGFDL[] FacialExpressions;

		private Guid LMOAFPCBOIP;

		private static Guid HOFEKFOBIPJ;

public PlayerAvatarDisplay.BFEINBHPKOD LeftHandController
{
get 		{
			return null;
		}

}

public PlayerAvatarDisplay.BFEINBHPKOD RightHandController
{
get 		{
			return null;
		}

}

private static Guid MGMPMGONHLI
{
get 		{
			return default;
		}

}

		public void Initialize()
		{
		}

		public void Teardown()
		{
		}

		private void Start()
		{
		}
	}
}
