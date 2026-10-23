using System;
using RecRoom.Avatars;
using RecRoom.Avatars.Face;
using UnityEngine;

namespace RecRoom.Avatar
{
	public class PlayerAvatarValidator : MonoBehaviour
	{
		public Color hairPrimaryColor;

		public Color hairSecondaryColor;

		public Color beardPrimaryColor;

		public Color beardSecondaryColor;

		public Color skinColor;

		public int faceShapeIndex;

		public int bodyShapeIndex;

		public int hairPatternIndex;

		public int beardPatternIndex;

		public AvatarFaceShape[] faceShapes;

		public AvatarBodyShape[] bodyShapes;

		public AvatarHairPattern[] hairPatterns;

		public bool hideEars;

		public AvatarCustomizationSettings.JKCCIHPHNHL useHelmetHair;

		public AnchorParams hatAnchorParams;

		public CLMEHHLKBJG HatAnchorRestrictions;

		public bool UseHatAnchorParams;

		public InspectorOutfitSelection hat;

		public InspectorOutfitSelection hair;

		public InspectorOutfitSelection ear;

		public InspectorOutfitSelection eye;

		public InspectorOutfitSelection mouth;

		public InspectorOutfitSelection neck;

		public InspectorOutfitSelection shirt;

		public InspectorOutfitSelection belt;

		public InspectorOutfitSelection pocket;

		public InspectorOutfitSelection rightHand;

		public InspectorOutfitSelection leftHand;

		[SerializeField]
		public PlayerAvatarDisplay avatarDisplay;

		public Action BuildComplete;

		public Animator leftHandAnimator;

		public Animator rightHandAnimator;

		public PlayerFacialAnimator facialAnimator;

		public Animator animator;

		public int lod;

		public OAKPNJLCDDM rightHandState;

		public float rightHandCurl;

		public OAKPNJLCDDM leftHandState;

		public float leftHandCurl;

		public int eyeSelection;

		public int mouthSelection;

		public float eyePositionOffsetHorizontal;

		public float eyePositionOffsetVertical;

		public float eyeScale;

		public float mouthPositionOffsetHorizontal;

		public float mouthPositionOffsetVertical;

		public float mouthScale;

		public int facialExpressionIndex;

		public float normalizedTime;

		public readonly GGPGBAKGFDL[] FacialExpressions;

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

		private void Start()
		{
		}
	}
}
