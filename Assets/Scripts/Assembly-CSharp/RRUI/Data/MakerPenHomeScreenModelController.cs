using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RRUI.Theme;
using RecRoom.Core.Creation.SandboxGizmos;
using RecRoom.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class MakerPenHomeScreenModelController : ModelController<MakerPenHomeScreenMenuModel>
	{
		[Serializable]
		private class Button_OpenPalette : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Slider_SnappingMode : RadioButtonSliderControllerImpl<MakerPenHomeScreenMenuModel>
		{
			private bool suppressOnChangeEvent;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void FHPNDLFMODO(float IPMIIEAGJKC)
			{
			}

			protected string AEFNMELOGAP(JNODIIINKKJ.PBDGIEELIHN GLMKCLLFLBE)
			{
				return null;
			}
		}

		[Serializable]
		private class Text_Edit : TextControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Icon_Edit : ImageControllerImpl<MakerPenHomeScreenMenuModel>
		{
			[SerializeField]
			private Sprite editSprite;

			[SerializeField]
			private Sprite doneSprite;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Text_Palette : TextControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Toggle_ShowGadgets : SettingToggle
		{
			protected override bool Setting
			{
				get
				{
					return false;
				}
				set
				{
				}
			}
		}

		[Serializable]
		private class Toggle_WorldAxis : SettingToggle
		{
			protected override bool Setting
			{
				get
				{
					return false;
				}
				set
				{
				}
			}
		}

		[Serializable]
		private class Button_Redo : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_Undo : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Text_Redo : TextControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Text_Undo : TextControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		private abstract class SettingToggle : ToggleControllerImpl<MakerPenHomeScreenMenuModel>
		{

protected abstract bool Setting
{
get ;
set ;
}

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ToolButton_Clone : ToolButton, NHPNOFLBHNH, KHKHJJFMNGI, HJJNFDHMAJL, DLFDIBHPKEL
		{
			public override FBEHJNCKJPN ToolMode => FBEHJNCKJPN.CreateShape;
		}

		[Serializable]
		private class ToolButton_Connect : ToolButton, AHBNPHNDAMB, KHKHJJFMNGI, DLFDIBHPKEL
		{
			public override FBEHJNCKJPN ToolMode => FBEHJNCKJPN.CreateShape;
		}

		[Serializable]
		private class ToolButton_Create : ToolButton, NHPNOFLBHNH, KHKHJJFMNGI, HJJNFDHMAJL, DLFDIBHPKEL
		{
			private FBEHJNCKJPN toolMode;

			public override FBEHJNCKJPN ToolMode => FBEHJNCKJPN.CreateShape;

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ToolButton_CreateInvention : ToolButton, KHKHJJFMNGI
		{
			public override FBEHJNCKJPN ToolMode => FBEHJNCKJPN.CreateShape;

			protected override bool LDMFKKAPOOC()
			{
				return false;
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ToolButton_Delete : ToolButton, NHPNOFLBHNH, KHKHJJFMNGI, HJJNFDHMAJL, DLFDIBHPKEL, BPFCFODNLFJ
		{
			public override FBEHJNCKJPN ToolMode => FBEHJNCKJPN.CreateShape;
		}

		[Serializable]
		private class ToolButton_Edit : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			private HHNPLBOFAGE TargetMode => HHNPLBOFAGE.Object;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ToolButton_ForceEdit : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			private HHNPLBOFAGE TargetMode => HHNPLBOFAGE.Object;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ToolButton_ScopeOut : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ToolButton_ClearScope : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ToolButton_Freeze : ToolButton, KHKHJJFMNGI
		{
			public override FBEHJNCKJPN ToolMode => FBEHJNCKJPN.CreateShape;

			protected override bool LDMFKKAPOOC()
			{
				return false;
			}
		}

		[Serializable]
		private class ToolButton_Manipulate : ToolButton, AEDBNOHFJCD, KHKHJJFMNGI, HJJNFDHMAJL
		{
			public override FBEHJNCKJPN ToolMode => FBEHJNCKJPN.CreateShape;

			protected override bool LDMFKKAPOOC()
			{
				return false;
			}
		}

		[Serializable]
		private class ToolButton_Move : ToolButton, NEKAFNOFFHE, KHKHJJFMNGI, HJJNFDHMAJL, DLFDIBHPKEL, NDCNIFEAENF, BPFCFODNLFJ
		{
			public override FBEHJNCKJPN ToolMode => FBEHJNCKJPN.CreateShape;
		}

		[Serializable]
		private class ToolButton_Repaint : ToolButton, AEDBNOHFJCD, KHKHJJFMNGI, HJJNFDHMAJL
		{
			public override FBEHJNCKJPN ToolMode => FBEHJNCKJPN.CreateShape;
		}

		[Serializable]
		private class ToolButton_Rotate : ToolButton, NEKAFNOFFHE, KHKHJJFMNGI, HJJNFDHMAJL, DLFDIBHPKEL, NDCNIFEAENF, BPFCFODNLFJ
		{
			public override FBEHJNCKJPN ToolMode => FBEHJNCKJPN.CreateShape;
		}

		[Serializable]
		private class ToolButton_Scale : ToolButton, NHPNOFLBHNH, KHKHJJFMNGI, HJJNFDHMAJL, DLFDIBHPKEL, BPFCFODNLFJ
		{
			public override FBEHJNCKJPN ToolMode => FBEHJNCKJPN.CreateShape;
		}

		[Serializable]
		private class ToolButton_Select : ToolButton, NEKAFNOFFHE, KHKHJJFMNGI, HJJNFDHMAJL, DLFDIBHPKEL, NDCNIFEAENF, BPFCFODNLFJ
		{
			public override FBEHJNCKJPN ToolMode => FBEHJNCKJPN.CreateShape;
		}

		[Serializable]
		private class ToolButton_Settings : ToolButton, NHPNOFLBHNH, KHKHJJFMNGI, HJJNFDHMAJL, DLFDIBHPKEL
		{
			public override FBEHJNCKJPN ToolMode => FBEHJNCKJPN.CreateShape;
		}

		[Serializable]
		private class ToolButton_Transform : ToolButton, NEKAFNOFFHE, KHKHJJFMNGI, HJJNFDHMAJL, DLFDIBHPKEL, NDCNIFEAENF, BPFCFODNLFJ
		{
			public override FBEHJNCKJPN ToolMode => FBEHJNCKJPN.CreateShape;
		}

		[Serializable]
		private class ConfigureDynamicUIImpl : ControllerImplementation<MakerPenHomeScreenMenuModel>
		{
			[SerializeField]
			private DynamicUIModel dynamicUIModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		private abstract class ToolButton : MakerPenToolThemeControllerImpl<MakerPenHomeScreenMenuModel>
		{
			[SerializeField]
			private Hideable hideable;

			[SerializeField]
			private ToggleTheme toggleTheme;

			[SerializeField]
			private List<MakerPenHomeScreenMenuModel.KCFFDMFHIIB> settingsType;

public override bool RefreshWhileInactiveOrHidden
{
get 			{
				return false;
			}

}

public abstract FBEHJNCKJPN ToolMode
{
get ;
}

			protected virtual bool LDMFKKAPOOC()
			{
				return false;
			}

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			protected sealed override void NGFFCLPHKJN()
			{
			}

			private void DGDJJGFDJIJ()
			{
			}

			private void KKLIEDDICMG()
			{
			}
		}

		private interface NDCNIFEAENF
		{
		}

		private interface BEDOCNOJOPG
		{
		}

		private interface DLFDIBHPKEL
		{
		}

		private interface KHKHJJFMNGI
		{
		}

		private interface HJJNFDHMAJL
		{
		}

		private interface BPFCFODNLFJ
		{
		}

		private interface AHBNPHNDAMB : KHKHJJFMNGI, DLFDIBHPKEL
		{
		}

		private interface AEDBNOHFJCD : KHKHJJFMNGI, HJJNFDHMAJL
		{
		}

		private interface NHPNOFLBHNH : KHKHJJFMNGI, HJJNFDHMAJL, DLFDIBHPKEL
		{
		}

		private interface DAMOEOIOKPG : KHKHJJFMNGI, HJJNFDHMAJL, DLFDIBHPKEL, NDCNIFEAENF
		{
		}

		private interface NEKAFNOFFHE : KHKHJJFMNGI, HJJNFDHMAJL, DLFDIBHPKEL, NDCNIFEAENF, BPFCFODNLFJ
		{
		}

		[Serializable]
		private class Hideable_CurrentShapeType : HideableControllerImpl<MakerPenHomeScreenMenuModel>
		{
			[SerializeField]
			private AMEPDCGKFOG visibleForMode;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_IsEditing : HideableControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_HasScope : HideableControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_HasParentScope : HideableControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_SelfScalingEnabled : HideableControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_Snapping : HideableControllerImpl<MakerPenHomeScreenMenuModel>
		{
			[SerializeField]
			private JNODIIINKKJ.PBDGIEELIHN visibleForMode;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		protected class Hideable_TargetMode : HideableControllerImpl<MakerPenHomeScreenMenuModel>
		{
			[SerializeField]
			private List<HHNPLBOFAGE> visibleForModes;

			protected virtual bool shouldHide => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_InCircuitGraph : Hideable_TargetMode
		{
			protected override bool shouldHide => false;
		}

		[Serializable]
		private class Hideable_CanEdit : HideableControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected bool shouldHide => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_ToolMode : HideableControllerImpl<MakerPenHomeScreenMenuModel>
		{
			[SerializeField]
			private List<FBEHJNCKJPN> visibleForModes;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Hideable_ToolMenuSplitTest : HideableControllerImpl<MakerPenHomeScreenMenuModel>
		{
			[SerializeField]
			private bool showForColorTest;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Controller_ToolMenuSplitTestGridSize : ControllerImplementation<MakerPenHomeScreenMenuModel>
		{
			[SerializeField]
			private GridLayoutGroup gridLayoutGroup;

			[SerializeField]
			private int newHeight;

			[SerializeField]
			private int newWidth;

			[SerializeField]
			private int oldHeight;

			[SerializeField]
			private int oldWidth;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Controller_ToolMenuSplitTestHighlightSize : ControllerImplementation<MakerPenHomeScreenMenuModel>
		{
			[SerializeField]
			private RectTransform rectTransform;

			[SerializeField]
			private int newHeight;

			[SerializeField]
			private int newWidth;

			[SerializeField]
			private int oldHeight;

			[SerializeField]
			private int oldWidth;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_Foldouts : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			[SerializeField]
			private Sprite collapseSprite;

			[SerializeField]
			private Sprite expandSprite;

			[SerializeField]
			private Image buttonIcon;

			[SerializeField]
			private ScrollRect scrollView;

			private bool Collapsed => false;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		private abstract class OJOLMLGELND<T> : ButtonControllerImpl<MakerPenHomeScreenMenuModel> where T : Enum
		{
			private BaseDialogModel<KCOKPCOFDIM> OIBPGEEMMGM;

			[SerializeField]
			private TMP_Text tmpText;

protected abstract T HANONBJEEAE
{
get ;
set ;
}

protected abstract string LJJGMJNNJKN
{
get ;
}

			protected abstract string AEFNMELOGAP(T GLMKCLLFLBE);

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void GPCENOFFNFP(T DNLPIHIBJDP)
			{
			}

			[CompilerGenerated]
			private void OKKNKJGDLJE(BaseDialogModel<KCOKPCOFDIM> COLMAMKJPJE)
			{
			}
		}

		private abstract class ABKABIBPCPH<T> : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			private BaseDialogModel<KCOKPCOFDIM> OIBPGEEMMGM;

			protected bool JBMHNHAIFMP;

			[SerializeField]
			private TMP_Text tmpText;

protected abstract List<T> DFFGLFMJPMI
{
get ;
}

protected abstract T HANONBJEEAE
{
get ;
set ;
}

protected abstract string LJJGMJNNJKN
{
get ;
}

			protected abstract void OnClick(T ONCGIPFNENB);

			protected virtual void OEHAHAAAKLL(T ONCGIPFNENB)
			{
			}

			protected abstract string AEFNMELOGAP(T ONCGIPFNENB);

			protected virtual string NMAABHFCNCE(T ONCGIPFNENB)
			{
				return null;
			}

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void GPCENOFFNFP(T DNLPIHIBJDP)
			{
			}

			[CompilerGenerated]
			private void LJGGFPOODKL(BaseDialogModel<KCOKPCOFDIM> COLMAMKJPJE)
			{
			}
		}

		private abstract class BPDBCCGILJH<T> : ABKABIBPCPH<T>
		{
			[SerializeField]
			protected TMP_InputField inputField;

			[SerializeField]
			protected Hideable inputFieldHideable;

			private List<T> GLLFHCCFIGK;

			private T ACNEEHKHELN;

protected override List<T> DFFGLFMJPMI
{
get 			{
				return null;
			}

}

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected abstract bool ADIFALOFFIB(string JCHGMKOHPGE, out T KLDKHJHEOCD);

			protected void DPBAKCJAABL(List<T> PAFIFJPOKMF, T ACNEEHKHELN)
			{
			}

			private void PLOOKDDLPHC(string JCHGMKOHPGE)
			{
			}

			protected override string NMAABHFCNCE(T ONCGIPFNENB)
			{
				return null;
			}

			protected override void OnClick(T ONCGIPFNENB)
			{
			}

			protected override void OEHAHAAAKLL(T ONCGIPFNENB)
			{
			}
		}

		[Serializable]
		private class Button_AnimationAddFrame : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_AnimationCopy : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_AnimationCurveIn : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_AnimationCurveOut : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_AnimationNextFrame : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_AnimationPaste : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_AnimationPlay : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_AnimationPreviousFrame : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Button_AnimationSetTime : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void GAPFBOGKOON(float KBMIOMICALD)
			{
			}
		}

		[Serializable]
		private class Button_RemoveFrame : ButtonControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Image_AnimationPlay : ImageControllerImpl<MakerPenHomeScreenMenuModel>
		{
			[SerializeField]
			private Sprite playSprite;

			[SerializeField]
			private Sprite stopSprite;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Slider_AnimationFrameContinuous : ContinuousNotchedSliderControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void JGFPOMHLIJO(BaseEventData GGMPLAIGLHP)
			{
			}

			protected override void FHPNDLFMODO(float IPMIIEAGJKC)
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected void JJFBBIJALPI()
			{
			}
		}

		[Serializable]
		private class Text_AnimationAddFrame : TextControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Text_AnimationCurveIn : TextControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Text_AnimationCurveOut : TextControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Text_AnimationFrame : TextControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Text_AnimationPlay : TextControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Text_AnimationTime : TextControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Toggle_AnimationSmooth : ToggleControllerImpl<MakerPenHomeScreenMenuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

private static MakerPen FMMANPOHFCE
{
get 		{
			return null;
		}

}

private static AnimationGizmo MIENPEEHIHI
{
get 		{
			return null;
		}

}

private static bool NGNBFHDMFKB
{
get 		{
			return false;
		}

}

private static bool DLEEOFMDHCL
{
get 		{
			return false;
		}

}

		public static void TogglePalette()
		{
		}

		public static void ShowPalette()
		{
		}

		private static bool GHJPDDGLMGF(out AnimationGizmo CKPMAHHPKPD, out bool NKEPHKJBJFH, out int BDAFOPHLJEG, out float OPJNGCKGFAP, out int GNGEFBBFBLF)
		{
			CKPMAHHPKPD = null;
			NKEPHKJBJFH = default;
			BDAFOPHLJEG = default;
			OPJNGCKGFAP = default;
			GNGEFBBFBLF = default;
			return false;
		}

		private static void KPEIOHJGNCD(AnimationGizmo CKPMAHHPKPD, out int ADJHCGFGDJN, out List<float> MKPAEINNGNE, float JDFDFBKKBPO = 1f)
		{
			ADJHCGFGDJN = default;
			MKPAEINNGNE = null;
		}
	}
}
