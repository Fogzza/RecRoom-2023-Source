using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using AGUI.StackedUI.Dialog;
using TMPro;
using UnityEngine;

namespace RecRoom.AGUI.ToolUIs
{
	public class MakerPenMainScreen : MakerPenUIFlowBase
	{
		private sealed class DFGBCDDPLFA
		{
			public string title;

			public string body;

			public Action<float> callback;

			public bool wasOpen;

			public MakerPenMainScreen _003C_003E4__this;

			internal global::NCOKFFGPIJM<TextInputUIDialog.FOBELBLMBDE> _003CAnimationButton_SetTime_003Eb__2(TextInputUIDialog dialog)
			{
				return null;
			}

			internal void _003CAnimationButton_SetTime_003Eb__3(TextInputUIDialog.FOBELBLMBDE r)
			{
			}
		}

		private sealed class NIAJIOBEABC
		{
			public MakerPenMainScreen _003C_003E4__this;

			public FBEHJNCKJPN toolMode;

			internal bool _003COnMakerPenModeChanged_003Eb__0(RadioButton3D b)
			{
				return false;
			}

			internal bool _003COnMakerPenModeChanged_003Eb__1(RadioButton3D b)
			{
				return false;
			}
		}

		public readonly EEANDDJEMJC CreateInventionButtonPressed;

		public readonly EEANDDJEMJC DoneEditingButtonPressed;

		public readonly EEANDDJEMJC RedoButtonPressed;

		public readonly global::HHOBPMOCKMJ<FBEHJNCKJPN> ToolSelectionButtonPressed;

		public readonly EEANDDJEMJC UndoButtonPressed;

		[SerializeField]
		private List<RadioButton3D> activeButtonsInAnimationMode;

		[SerializeField]
		private List<RadioButton3D> activeButtonsInCircuitGroupMode;

		[SerializeField]
		private List<RadioButton3D> activeButtonsInObjectMode;

		[SerializeField]
		private List<RadioButton3D> activeButtonsInShapeMode;

		[SerializeField]
		private List<RadioButton3D> allButtons;

		[SerializeField]
		private TMP_Text animationAddText;

		[SerializeField]
		private TMP_Text animationCurveInText;

		[SerializeField]
		private TMP_Text animationCurveOutText;

		[SerializeField]
		private Slider3D animationFrameSlider;

		[SerializeField]
		private TMP_Text animationFrameText;

		[SerializeField]
		private TMP_Text animationPlayText;

		[SerializeField]
		private GameObject animationSection;

		[SerializeField]
		private ToggleButton3D animationSmoothButton;

		[SerializeField]
		private TMP_Text animationTimeText;

		[SerializeField]
		private RadioButton3D createButton;

		[SerializeField]
		private Button3D doneEditingButton;

		[SerializeField]
		private RadioButton3D editButton;

		[SerializeField]
		private RadioButton3D freezeButton;

		[SerializeField]
		private RadioButton3D makeInventionButton;

		[SerializeField]
		private RadioButton3D manipulateButton;

		[SerializeField]
		private MakerPenToolRadioGroup modeButtonsGroup;

		[SerializeField]
		private Button3D openPaletteButton;

		[SerializeField]
		private Button3D redoButton;

		[SerializeField]
		private Button3D removeFrameButton;

		[SerializeField]
		private ToggleButton3D showGadgetsToggle;

		[SerializeField]
		private Slider3D snappingSlider;

		[SerializeField]
		private TextInputUIDialog textInputDialogPrefab;

		[SerializeField]
		private Button3D undoButton;

		[SerializeField]
		private ToggleButton3D worldAxisButton;

		private CGOPOAFDIDN AAKFKPKFDJJ;

		public void AnimationButton_Add()
		{
		}

		public void AnimationButton_CopyFrame()
		{
		}

		public void AnimationButton_First()
		{
		}

		public void AnimationButton_FrameSliderRelease(float val)
		{
		}

		public void AnimationButton_FrameSliderUpdate(float val)
		{
		}

		public void AnimationButton_InCurve()
		{
		}

		public void AnimationButton_Last()
		{
		}

		public void AnimationButton_Next()
		{
		}

		public void AnimationButton_OutCurve()
		{
		}

		public void AnimationButton_PasteFrame()
		{
		}

		public void AnimationButton_Play()
		{
		}

		public void AnimationButton_Prev()
		{
		}

		public void AnimationButton_Rec()
		{
		}

		public void AnimationButton_Remove()
		{
		}

		public void AnimationButton_SetFrame()
		{
		}

		public void AnimationButton_SetTime()
		{
		}

		public void AnimationButton_ToggleSmooth(bool isOn)
		{
		}

		public void UpdateAnimationSliderPosition()
		{
		}

		public void UpdateAnimationText()
		{
		}

		public void UpdateSliderTicks()
		{
		}

		private void JAKFICEDLJK()
		{
		}

		private void ELKCMJIPNMN()
		{
		}

		private void Update()
		{
		}

		private void IHAFHAIHAIJ()
		{
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void Start()
		{
		}

		private void HEIAGEOHKNH()
		{
		}

		private void LCBDJFJCJDD()
		{
		}

		private void HHLDDEGPLKP(FBEHJNCKJPN CIMCLAFMGFE, HHNPLBOFAGE IACECANFEKI)
		{
		}

		private void ADDLPHDPGPN(bool LNBOCMEBNEB)
		{
		}

		private void AFJCAMKMKEN(JDCIJIEOFOL FBCDJHOIDJJ)
		{
		}

		private void INBPOIIJCDI(List<RadioButton3D> MHIONEPICHG)
		{
		}

		private void KEMIIAODAOG()
		{
		}

		private void DCENLLKGGJJ()
		{
		}

		private void PIEOFKGEBJK()
		{
		}

		public void Button_Clone()
		{
		}

		public void Button_Configure()
		{
		}

		public void Button_Create()
		{
		}

		public void Button_Delete()
		{
		}

		public void Button_Done()
		{
		}

		public void Button_EditShapes()
		{
		}

		public void Button_Freeze()
		{
		}

		public void Button_MakeInvention()
		{
		}

		public void Button_Manipulate()
		{
		}

		public void Button_Move()
		{
		}

		public void Button_OpenPaletteMenu()
		{
		}

		public void Button_Recolor()
		{
		}

		public void Button_Redo()
		{
		}

		public void Button_Rotate()
		{
		}

		public void Button_Scale()
		{
		}

		public void Button_Select()
		{
		}

		public void Button_Undo()
		{
		}

		public void Button_Wire()
		{
		}

		public void Slider_SnappingMode(float val)
		{
		}

		public void Toggle_ShowGadgetsForMe(bool show)
		{
		}

		public void Toggle_WorldAxis(bool isOn)
		{
		}

		[CompilerGenerated]
		private void DOPCANBLMNH(TextInputUIDialog.FOBELBLMBDE GOJCEBCMFJK)
		{
		}

		[CompilerGenerated]
		private void PNNBCFLPIGI(float KBMIOMICALD)
		{
		}

		[CompilerGenerated]
		private void PIECOFAFKKH(string OFMGPNLDCAB, string BMIOOJNLJAO, Action<float> ONAFALABHKI)
		{
		}
	}
}
