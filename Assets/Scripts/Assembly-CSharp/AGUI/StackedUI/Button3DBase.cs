using System;
using System.Collections.Generic;
using RecRoom;
using RecRoom.Audio;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public abstract class Button3DBase : Selectable, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		public delegate void ALPEOKPFAHI(Button3DBase HHDMPJJAPJJ);

		[Serializable]
		public class Button3DConstraints
		{
			[SerializeField]
			private float UnpressedOffset;

			[SerializeField]
			private float MaxPressedOffset;

			public float FLPJDFCLADN(float MOHMCFDNHKH)
			{
				return 0f;
			}

			public float KOGHFGNLBLA(float OJBODCOIDJO)
			{
				return 0f;
			}
		}

		private const float DPOGHIEOKMC = 1f;

		private const float EHPDBIAGENJ = 1.5f;

		private ALPEOKPFAHI GFFIFIHEGEH__BackingField;

		private ALPEOKPFAHI EJCINGNDLGC__BackingField;

		private ALPEOKPFAHI DHLOLPOKKFM__BackingField;

		public Color BaseColor;

		public Color ToggleColor;

		[SerializeField]
		private GameObject object2d;

		[SerializeField]
		private float hairTriggerCancelThreshold;

		[SerializeField]
		private ButtonHighlight buttonHighlight;

		[SerializeField]
		private DGFHKEBHIFF toastId;

		private Toast DEKOKEMOCCH;

		[SerializeField]
		protected TextMeshProUGUI label;

		private bool BFKHOCNPHDA;

		[SerializeField]
		protected Button3DConstraints constraints;

		private MenuFinger JJDCOJLPACL;

		private List<Graphic> CGKCJPBPGEA;

		private float HBJLFKKOJHI;

		private float GPDHEBMHCDL;

		private bool GLIALHEABAK;

		private float DCDELDNFCJI;

		private float GELHLPGEPBC;

		private StackedUIBase MKHLKCMEBLE;

		private bool NCNNPHBPJDL;

		private bool PMIHKLMPKPE;

		private float IDEDLHACIPK;

		private SelectionState FNPMDJJALJF;

		private UI3DScaler DOFNLEHCJBH;

		private Renderer OIINJDFIOMH;

		private BoxCollider OPNJEPPCOPN;

		private float BNGIGHJCMOO;

		private bool LPOOJLHHGGJ;

		private bool HLHEBBPKKFB;

		private bool INBCLKCIKEE;

		public RecRoomAudioClip ButtonDownAudio;

		public RecRoomAudioClip ButtonUpAudio;

public TextMeshProUGUI Label
{
get 		{
			return null;
		}

}

public bool Interactable
{
get 		{
			return false;
		}

set {
		}
}

public bool Toggled
{
get 		{
			return false;
		}

set {
		}
}

public MenuFinger MenuFinger
{
get 		{
			return null;
		}

set {
		}
}

private float FJIFHICDMGD
{
get 		{
			return 0f;
		}

set {
		}
}

private float EJDGLOPDLCE
{
get 		{
			return 0f;
		}

set {
		}
}

protected virtual float PDOFHPBPEKM
{
get 		{
			return 0f;
		}

}

protected virtual float KOPIEMBDDFC
{
get 		{
			return 0f;
		}

}

protected virtual float JFGEKMLMKAB
{
get 		{
			return 0f;
		}

}

protected virtual float BHNCBEPGLOA
{
get 		{
			return 0f;
		}

}

protected StackedUIBase OODKHJEMACH
{
get 		{
			return null;
		}

}

public bool ButtonPressed
{
get 		{
			return false;
		}

set {
		}
}

protected bool BHLFLNPJAEP
{
get 		{
			return false;
		}

}

public bool PointerPressed
{
get 		{
			return false;
		}

set {
		}
}

public bool AttractHighlighted
{
get 		{
			return false;
		}

set {
		}
}

public event ALPEOKPFAHI DownEvent {
add {
		}
remove {
		}
}

public event ALPEOKPFAHI UpEvent {
add {
		}
remove {
		}
}

public event ALPEOKPFAHI CanceledEvent {
add {
		}
remove {
		}
}

		protected virtual float ACLIGCDJKAM()
		{
			return 0f;
		}

		protected void LJJGPGCIDHC()
		{
		}

		private SelectionState GNLELPGEFDL()
		{
			return SelectionState.Normal;
		}

		protected override void DoStateTransition(SelectionState DADHJJNJEFA, bool LDDPJCGNHNG)
		{
		}

		protected override void Start()
		{
		}

		protected override void Awake()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected virtual void Update()
		{
		}

		private void JEFPAGGAPIG()
		{
		}

		public virtual void SetAxisValue(float JFNHHMPHEMO, bool COPOILGLIAJ = false)
		{
		}

		private void EGOIALDPCPK(float ALJOBCHFMEP)
		{
		}

		private void GIDOJOENMMK()
		{
		}

		private void KPAPBFPKMLK(float AEOBFPFLDMC)
		{
		}

		protected virtual void JGHFDPCHPJJ(bool JGBEGFNGCKM = false)
		{
		}

		protected virtual void BCFAHLGGFLJ(bool JGBEGFNGCKM = false)
		{
		}

		protected virtual void KDPJHOOPHAL()
		{
		}

		public void TrySetMenuFinger(MenuFinger JJDCOJLPACL)
		{
		}

		public void TryReleaseMenuFinger(MenuFinger JJDCOJLPACL)
		{
		}

		protected void MBEMPCDGMKN(bool MAFIFKNHLOB = false)
		{
		}

		public override void OnPointerDown(PointerEventData OEPDOIOJPHD)
		{
		}

		public override void OnPointerUp(PointerEventData OEPDOIOJPHD)
		{
		}

		public void ForcePressed()
		{
		}

		protected void FMBILFHKLIE(bool MAFIFKNHLOB = false)
		{
		}

		public override void OnPointerEnter(PointerEventData OEPDOIOJPHD)
		{
		}

		public override void OnPointerExit(PointerEventData OEPDOIOJPHD)
		{
		}

		protected void HBFKLJNKINK()
		{
		}

		protected void DEKCJOIELKC()
		{
		}

		public void RenderOutline()
		{
		}
	}
}
