using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using AGUI.StackedUI;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom
{
	public class AnimationRecordingStudioMenu : MonoBehaviour
	{
		private sealed class FCCAILPFKPJ : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public AnimationRecordingStudioMenu _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public FCCAILPFKPJ(int _003C_003E1__state)
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
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private GameObject mainControlPanelRoot;

		[SerializeField]
		private Text mainControlPanelLabel;

		[SerializeField]
		private Button3D mainControlPanelCalibrateButton;

		[SerializeField]
		private Button3D mainControlPanelRecordNewAnimationButton;

		[SerializeField]
		private Button3D mainControlPanelRecordAnotherTakeButton;

		[SerializeField]
		private GameObject namingControlPanelRoot;

		[SerializeField]
		private InputField3D namingInputField;

		[SerializeField]
		private GameObject calibrationControlPanelRoot;

		[SerializeField]
		private Image calibrationSuccessStatusImage;

		[SerializeField]
		private Image calibrationFailureStatusImage;

		[SerializeField]
		private Text calibrationHeadValue;

		[SerializeField]
		private Text calibrationShoulderValue;

		[SerializeField]
		private Text calibrationArmsValue;

		[SerializeField]
		private Button3D recalibrationButton;

		[SerializeField]
		private GameObject recordingControlPanelRoot;

		[SerializeField]
		private ToggleButton3D automatePositionButton;

		[SerializeField]
		private ToggleButton3D automateRotationButton;

		[SerializeField]
		private ToggleButton3D visualizeAimButton;

		private AnimationRecordingStudio CIGHABAGOGA;

		private LKGILLBEJEK EGAKADNJGKH;

		private string IKBGOAJKLJF;

		private bool EGHLJLHMOGH;

		private bool LDLFNPFLCKG;

		private bool IFHJAKBKMKB;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void KJDPALNKPMJ()
		{
		}

		private void GGIKNFAALFE()
		{
		}

		private void DNFDKKLJHMI()
		{
		}

		private void DCOMMDHNDJN()
		{
		}

		private void IBOILIPFDGK()
		{
		}

		private void MCJLHCFFNGP()
		{
		}

		private bool NELABCCEPLM()
		{
			return false;
		}

		private IEnumerator<EGGPGCCKPCO> FMGLDKEIFAJ()
		{
			return null;
		}

		public void Button_StartCalibration()
		{
		}

		public void Button_RecordNewAnimation()
		{
		}

		public void Button_RecordAnotherTake()
		{
		}

		public void Toggle_AutomatePositionsValueChange(bool value)
		{
		}

		public void Toggle_AutomateRotationValueChange(bool value)
		{
		}

		public void Toggle_VisualizeAimValueChange(bool value)
		{
		}
	}
}
