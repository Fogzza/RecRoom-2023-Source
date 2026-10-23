using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

namespace RecRoom.Inputs
{
	[Serializable]
	public class SteamVrInputHandler : VRInputHandler
	{
		public enum DHNJBAPGJDL
		{
			None = 0,
			Stick = 1,
			PrimaryButton = 2,
			SecondaryButton = 3,
			COUNT = 4
		}

		public Axis2DSettings WalkAxisSettings;

		public Axis2DSettings RotateAxisSettings;

		public float RotateAxisDeadZone;

		public AxisPressButtons RotateAxisPressButtons;

		public Axis2DSettings SmoothSwipeRotateAxisSettings;

		public Axis2DSettings ScrollAxisSettings;

		public List<XRNodeState> nodeStates;

		public DeprecatedAxisSettings TriggerSettings;

		private readonly Dictionary<JCFFMMKDGOA, (DHNJBAPGJDL, MHIBEFMDHNN)> ControlToInputMap;

		private readonly global::FDAEEPIALBA<JCFFMMKDGOA, DHNJBAPGJDL> inputConsumerMap;

		protected SteamVR_Events.Action newPosesAction;

		protected SteamVR_Action_Boolean SecondaryButtonAction;

		protected SteamVR_Action_Boolean PrimaryButtonAction;

		protected SteamVR_Action_Boolean SprintButtonAction;

		protected SteamVR_Action_Boolean SlideButtonAction;

		protected SteamVR_Action_Boolean PushToTalkButtonAction;

		protected SteamVR_Action_Boolean SelfScaleButtonAction;

		protected SteamVR_Action_Boolean GripTurnButtonAction;

		protected SteamVR_Action_Boolean ThumbDownButtonAction;

		protected SteamVR_Action_Single TriggerAxisAction;

		protected SteamVR_Action_Single PickupAxisAction;

		protected SteamVR_Action_Single CapacitiveGripPickupAxisAction;

		protected SteamVR_Action_Single HandOpenCloseAxisAction;

		protected SteamVR_Action_Vector2 WalkAxisAction;

		protected SteamVR_Action_Vector2 RotateAxisAction;

		protected SteamVR_Action_Vector2 SmoothRotateAxisAction;

		protected SteamVR_Action_Vector2 ScrollAxisAction;

		protected SteamVR_Action_Vibration haptics;

		protected SteamVR_Input_Sources SteamInputHandSource => SteamVR_Input_Sources.Any;

		public override bool MJKJHKJGCJM(JCFFMMKDGOA POINFDHCNCM)
		{
			return false;
		}

		protected void GHANJDEJDOF()
		{
		}

		protected override void OPMEDJKHIDF(ref HGLAMAFCPPN DADHJJNJEFA)
		{
		}

		public override void PPOCOGLBGFD()
		{
		}

		public override void HFCGCFAAAJP()
		{
		}

		protected bool DHMOFNGJPHA(out uint GMEHLIHLGEH)
		{
			GMEHLIHLGEH = default;
			return false;
		}

		protected override void PGLAHOCNCON(float DOEJGDJILAD, bool HIFDJFBEADN)
		{
		}

		private void APEDLNPMPHM(TrackedDevicePose_t[] EOFCGIFBGHM)
		{
		}

		protected DLLIMLHNBON JMIBLEOOBPI(SteamVR_Action_Boolean FDAIMOMOHIG, SteamVR_Input_Sources EJKFCKKGKCD, out bool ICHOFOKGCEN, JCFFMMKDGOA POINFDHCNCM = JCFFMMKDGOA.None)
		{
			ICHOFOKGCEN = default;
			return default;
		}

		protected DLLIMLHNBON JFMNEEAMMDN(KeyCode FDAIMOMOHIG)
		{
			return default;
		}

		protected GAEDOFGKFJA BCLOEHFCHDC(SteamVR_Action_Single FDAIMOMOHIG, SteamVR_Input_Sources EJKFCKKGKCD, float HJKEDPGBBGM = 0f)
		{
			return default;
		}

		protected GAEDOFGKFJA BCLOEHFCHDC(SteamVR_Action_Single[] LLNNCEMACKC, SteamVR_Input_Sources EJKFCKKGKCD, float HJKEDPGBBGM = 0f)
		{
			return default;
		}

		protected Vector2 KPDNOLPNABB(JCFFMMKDGOA POINFDHCNCM, DHNJBAPGJDL GGNFFFABKNA, SteamVR_Action_Vector2 FDAIMOMOHIG, SteamVR_Input_Sources EJKFCKKGKCD, Axis2DSettings KKHPPOLGFBF)
		{
			return default;
		}
	}
}
