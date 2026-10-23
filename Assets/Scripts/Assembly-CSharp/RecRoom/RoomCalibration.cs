using System;
using RecRoom.Inputs;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom
{
	public class RoomCalibration : MonoBehaviour
	{
		[Serializable]
		public struct CalibrationInstruction
		{
			public KBFBLDKBOJG state;

			public string instructionText;

			public Sprite instructionSprite;
		}

		public enum KBFBLDKBOJG
		{
			Invalid = -1,
			Started = 0,
			Height = 1,
			Verification = 2,
			Warning = 3,
			Finished = 4,
			ConfirmStanding = 5
		}

		public enum CFMOHFNNEHC
		{
			Off = 0,
			Full = 1,
			ImmediateMimick = 2
		}

		public static EEANDDJEMJC OnRoomCalibrationCompleted;

		[SerializeField]
		private float hmdToTopOfHead;

		[SerializeField]
		private float manualHeightAdjustIncrement;

		[SerializeField]
		private CalibrationInstruction[] calibrationInstructions;

		[SerializeField]
		private Transform roomCenterTransform;

		[SerializeField]
		private GameObject trackerGizmo;

		[SerializeField]
		private GameObject showDuringVerification;

		[SerializeField]
		private Text heightMetersText;

		[SerializeField]
		private Text heightFeetText;

		[SerializeField]
		private Text cameraHeightMetersText;

		[SerializeField]
		private Text cameraHeightFeetText;

		[SerializeField]
		private Animator instructionsAnimator;

		private float LFICLOLLNIJ;

		[SerializeField]
		private Text instructionText;

		[SerializeField]
		private Image instructionImage;

		public static readonly string CALIBRATION_STATE_PREF;

		public static readonly string CALIBRATION_HEIGHT_PREF;

		public static readonly string CALIBRATION_DEPTH_PREF;

		public static readonly string CALIBRATION_OFFCENTER_PREF;

		private const float AHBEHPNLOAL = 2f;

		private const float CEIFAEFJHBP = 1f;

		private KBFBLDKBOJG LMMEGEIPPLM;

		private KBFBLDKBOJG MEHPPOKJBGM;

		private Vector3 HCDKDOGPJPB;

		private float DBCJHKLCBJC;

		private float BFOKAADBFPA;

		public static bool LoadDormRoomOnCompletion;

		private static bool IHFPAACMKKH;

		private BHNJIBDJFAL NJPJBDDAEFH;

private KBFBLDKBOJG MBHNCCMHIPK
{
get 		{
			return KBFBLDKBOJG.Started;
		}

set {
		}
}

public static bool Completed
{
get 		{
			return false;
		}

private set {
		}
}

public static bool UsesRoomCalibration
{
get 		{
			return false;
		}

}

public static CFMOHFNNEHC RoomCalibrationType
{
get 		{
			return CFMOHFNNEHC.Off;
		}

}

public static bool RequiresCalibration
{
get 		{
			return false;
		}

}

private VRInputHandler CAMONPJJAIJ
{
get 		{
			return null;
		}

}

private VRInputHandler AHBADACHDPE
{
get 		{
			return null;
		}

}

private bool GEIHPLINEPC
{
get 		{
			return false;
		}

}

private bool GDFMIJPLNNM
{
get 		{
			return false;
		}

}

private bool MLBKEKJCCBD
{
get 		{
			return false;
		}

}

private bool DBAPONGBOAD
{
get 		{
			return false;
		}

}

private bool NNKFGPOJFIL
{
get 		{
			return false;
		}

}

private bool GKKIINLNJLL
{
get 		{
			return false;
		}

}

private bool HMCBEANHLKM
{
get 		{
			return false;
		}

}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		public static void SaveRoomCalibration()
		{
		}

		public static void LoadRoomCalibration()
		{
		}

		private void NIHABMLABNM()
		{
		}

		private void KFGGILLHJNK()
		{
		}

		public void UpdateInstructionsForCurrentState()
		{
		}

		private void CCMEGNOOHED()
		{
		}

		private void HNOBIPIBJMM()
		{
		}

		public void RecenterPlayarea()
		{
		}

		private void KEMIPNBGLHN(float ANNHCEHMEPJ)
		{
		}

		private void FFNJBKGOCKL()
		{
		}

		public void Button_RaiseHeight(PhysicalButtonBase button, Player player)
		{
		}

		public void Button_LowerHeight(PhysicalButtonBase button, Player player)
		{
		}

		public void Button_StartOver(PhysicalButtonBase button, Player player)
		{
		}

		public void Button_Done(PhysicalButtonBase button, Player player)
		{
		}

		private void EOBGBMAJHGK()
		{
		}

		private void MCNLCCDGEEE()
		{
		}

		private void KGBBPKGGAGH()
		{
		}

		private void OBILIKFFEII()
		{
		}

		private void BEKBHAKAEKL()
		{
		}

		public static Vector3 GetHMDPositionRelativeToTracker()
		{
			return default;
		}

		public static Vector3 GetTrackerWorldPosition()
		{
			return default;
		}

		private void FOAGABDIDJJ()
		{
		}

		private CalibrationInstruction FHCBLPFOAIJ(KBFBLDKBOJG DADHJJNJEFA)
		{
			return default;
		}

		private void AMGLNMDKBHD()
		{
		}
	}
}
