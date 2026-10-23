using UnityEngine;

namespace RecRoom.UI.Notifications
{
	public class VRModeScreenSpaceNotification : MonoBehaviour, IBPJIOJOPLF
	{
		public enum PCJNNELBCMG
		{
			None = 0,
			Top = 1,
			Middle = 2,
			Bottom = 3
		}

		[SerializeField]
		private VRModeNotificationText title;

		[SerializeField]
		private VRModeNotificationText subtitle;

		public MeshRenderer DesaturationBackdrop;

		public Transform AlignmentPoint;

		public PCJNNELBCMG Alignment;

		public FloatValueCurve DesaturationEaseInCurve;

		public FloatValueCurve DesaturationEaseOutCurve;

		public FloatValueCurve AlphaEaseInCurve;

		public FloatValueCurve AlphaEaseOutCurve;

		public Vector3ValueCurve CameraOffsetEaseInCurve;

		public Vector3ValueCurve CameraOffsetEaseOutCurve;

		private Color FGGAGAKIPBM;

		private Color NIDMPONHBCP;

		private Vector3 JELEDLDGGFP;

		private Material FDOAHCJMCFE;

		private Vector3 IHMEBCDIAHK;

		private static readonly int IMPAKDMJIJJ;

public GGPAKCCMKMG Title
{
get 		{
			return null;
		}

}

public GGPAKCCMKMG Subtitle
{
get 		{
			return null;
		}

}

public Vector3 positionCameraSpace
{
get 		{
			return default;
		}

set {
		}
}

public float AnimateInDuration
{
get 		{
			return 0f;
		}

}

public float AnimateOutDuration
{
get 		{
			return 0f;
		}

}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void MENDECICLMG()
		{
		}

		private void DCJBPOFFPNG(float MEGHPOMLDMP)
		{
		}

		private void ALHEIGLDCON(float DJBGOHKOOIN)
		{
		}

		private void MKCPCPOFAAL()
		{
		}

		private void JOJJGGLDIMG()
		{
		}

		public void Initialize(NotificationManager.IAMJAHDKBDF FIAINCAEOKG, bool KEKFKDMLBOC)
		{
		}

		public void SetVisible(bool BMGEHFPFCBJ)
		{
		}

		public void UpdateAnimateIn(float BBGNJMKOHPL)
		{
		}

		public void UpdateAnimateOut(float BBGNJMKOHPL)
		{
		}
	}
}
