using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR;

namespace RecRoom.Inputs
{
	[Serializable]
	public class PicoVRInputHandler : VRInputHandler
	{
		private enum CGPGAMLBFKP
		{
			None = 0,
			PrimaryButton = 1,
			SecondaryButton = 2,
			MenuButton = 3,
			Thumbstick = 4,
			Grip = 5,
			Trigger = 6
		}

		protected enum AGEJNAFHFMM
		{
			PrimaryButton = 0,
			SecondaryButton = 1,
			MenuButton = 2,
			PrimaryThumbstickClick = 3
		}

		protected enum LENJFMLFLAE
		{
			Trigger = 0,
			Grip = 1
		}

		protected enum HEGILHAJNIM
		{
			Primary2DAxis = 0
		}

		protected enum KFEFDBIJIDK
		{
			PrimaryTouch = 0,
			SecondaryTouch = 1
		}

		[Serializable]
		private class Map
		{
			public LENJFMLFLAE[] PickupAxes;

			public LENJFMLFLAE TriggerAxis;

			public LENJFMLFLAE SelfScalingAxis;

			public AGEJNAFHFMM MenuButton;

			public AGEJNAFHFMM SecondaryButton;

			public AGEJNAFHFMM PrimaryButton;

			public AGEJNAFHFMM GripTurnButton;

			public AGEJNAFHFMM SprintButton;

			public AGEJNAFHFMM SlideButton;

			public AGEJNAFHFMM PushToTalkButton;

			public HEGILHAJNIM RotateAxis;

			public HEGILHAJNIM WalkAxis;

			public HEGILHAJNIM SmoothSwipeRotateAxis;

			public HEGILHAJNIM ScrollAxis;

			public KFEFDBIJIDK[] ThumbDownTouches;

			public AGEJNAFHFMM RCMainButton;

			public Axis2DSettings RotateAxisSettings;

			public Axis2DSettings WalkAxisSettings;

			public Axis2DSettings SmoothSwipeRotateAxisSettings;

			public Axis2DSettings ScrollAxisSettings;

			public DeprecatedAxisSettings TriggerSettings;

			public AxisPressButtons ThumbstickDirectionButtons;

			public float RotateAxisDeadZone;
		}

		private sealed class BADFNBLPBKD
		{
			public InputDeviceCharacteristics handednessCharacteristic;

			internal bool _003Cget_InputDevice_003Eb__0(InputDevice d)
			{
				return false;
			}
		}

		private sealed class PIMLBOPOFCP : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PicoVRInputHandler _003C_003E4__this;

			public float intensity;

			public int milliseconds;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public PIMLBOPOFCP(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private HOCAKIFHDHC selfScalingHairTriggerButton;

		private List<InputDevice> _allInputDevices;

		private InputDevice cachedInputDevice;

		private const int PICO_BUTTON_COUNT = 4;

		private static readonly InputFeatureUsage<bool>[] picoButtonFeatures;

		private const int PICO_AXIS1D_COUNT = 2;

		private static readonly InputFeatureUsage<float>[] picoAxis1DFeatures;

		private const int PICO_AXIS2D_COUNT = 1;

		private static readonly InputFeatureUsage<Vector2>[] picoAxis2DFeatures;

		private const int PICO_TOUCH_COUNT = 2;

		private static readonly InputFeatureUsage<bool>[] picoTouchFeatures;

		[SerializeField]
		private Map map;

		private static (CGPGAMLBFKP, MHIBEFMDHNN)[] ControlToPicoInputMap;

		private readonly DLLIMLHNBON[] picoButtonStates;

		private readonly DLLIMLHNBON[] picoTouchStates;

		private readonly float[] picoAxis1DStates;

		private readonly Vector2[] picoAxis2DStates;

		private readonly global::FDAEEPIALBA<JCFFMMKDGOA, CGPGAMLBFKP> inputConsumerMap;

		public override bool SupportsAimWalkAndStickWalkSimultaneously => false;

		public override bool SupportsNaturalGrip => false;

		public override bool HasDedicatedMenuButton => false;

		private InputDevice InputDevice => default;

		public override bool MJKJHKJGCJM(JCFFMMKDGOA POINFDHCNCM)
		{
			return false;
		}

		private void GHANJDEJDOF()
		{
		}

		public override void PPOCOGLBGFD()
		{
		}

		public override void HFCGCFAAAJP()
		{
		}

		private void GHGDLJCIFMN()
		{
		}

		protected override IEnumerator LJLEIHBODCE(int HIJKHPMDNMK, float DOEJGDJILAD, bool HIFDJFBEADN = false)
		{
			return null;
		}

		private void OJMLHLMODFJ(InputDevice IDHOAIKBEAC)
		{
		}

		private void NMGKEPOJMIE(InputDevice IDHOAIKBEAC)
		{
		}

		private void NJBNFBANIPH(InputDevice IDHOAIKBEAC)
		{
		}

		private void EHOBEIFHEPJ(InputDevice IDHOAIKBEAC)
		{
		}

		protected override void OPMEDJKHIDF(ref HGLAMAFCPPN DADHJJNJEFA)
		{
		}

		protected DLLIMLHNBON NNHNHEKAKHI(AGEJNAFHFMM FDAIMOMOHIG, out bool ICHOFOKGCEN, JCFFMMKDGOA POINFDHCNCM = JCFFMMKDGOA.None)
		{
			ICHOFOKGCEN = default;
			return default;
		}

		protected DLLIMLHNBON JEFHMKONKKO(KFEFDBIJIDK[] LLNNCEMACKC)
		{
			return default;
		}

		protected GAEDOFGKFJA BCLOEHFCHDC(LENJFMLFLAE FDAIMOMOHIG, float HJKEDPGBBGM = 0f)
		{
			return default;
		}

		protected GAEDOFGKFJA BCLOEHFCHDC(LENJFMLFLAE[] LLNNCEMACKC, float HJKEDPGBBGM = 0f)
		{
			return default;
		}

		protected Vector2 KPDNOLPNABB(JCFFMMKDGOA POINFDHCNCM, HEGILHAJNIM FDAIMOMOHIG, Axis2DSettings KKHPPOLGFBF)
		{
			return default;
		}
	}
}
