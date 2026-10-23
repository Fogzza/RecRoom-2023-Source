using System;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using RecNet;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom
{
	public class RoomCommentView : MonoBehaviour
	{
		private Action<RoomCommentView> KLEFJCOJLOH__BackingField;

		[SerializeField]
		private AccountSpecificUIBehaviour accountWatcher;

		[SerializeField]
		private PlayerInfoUIControl playerInfoControl;

		[SerializeField]
		private Transform visibilityRoot;

		[SerializeField]
		private Transform messageRoot;

		[SerializeField]
		private TMP_Text messageTextField;

		[SerializeField]
		private TMP_Text usernameTextField;

		[SerializeField]
		private TMP_Text dateTextField;

		[SerializeField]
		private Image backgroundImage;

		[SerializeField]
		private Image proxyIconImage;

		[SerializeField]
		private Transform cheerButtonRoot;

		[SerializeField]
		private Transform reportButtonRoot;

		[SerializeField]
		private Renderer proxyRenderer;

		[SerializeField]
		private Color deactivatedProxyColor;

		private bool MDAHNFIPBOB;

		private RoomComment EOGAFGLIEAN;

		private bool INLPNMBLIKE;

		private MaterialPropertyBlock HOOJEGOGAPE;

		private CanvasGroup[] BMPPNIOMIDO;

		private Vector3 DDBCKIFAOEJ;

public bool IsShowing
{
get 		{
			return false;
		}

private set {
		}
}

public RoomComment Model
{
get 		{
			return null;
		}

private set {
		}
}

public event Action<RoomCommentView> VisibilityChanged {
add {
		}
remove {
		}
}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		public void SetModel(RoomComment PKEPJNJACDM)
		{
		}

		public void ShowComment()
		{
		}

		public void ToggleCommentVisibility()
		{
		}

		public void HideComment()
		{
		}

		private void JCMOPIGGMLK(RoomComment.LDMAFFPGJCL IECPKMLJDCJ)
		{
		}

		private void NOAAOJONEFK()
		{
		}

		private void MFIMMBHBAPH()
		{
		}

		private void PINFCAGMGIE()
		{
		}

		private void NAGGNKJLLOA()
		{
		}

		private void NJMCOMBNPLN()
		{
		}

		private void FCOOADFBNIH(bool BMGEHFPFCBJ, bool COPOILGLIAJ)
		{
		}

		public void ButtonPress_CreatorInfo()
		{
		}

		public void ButtonPress_ToggleVisibility()
		{
		}

		public void ButtonPress_Report()
		{
		}

		public void ButtonPress_Visit()
		{
		}

		public void ButtonPress_Delete()
		{
		}

		public void ButtonPress_CheerPlayer()
		{
		}

		private void OnDisable()
		{
		}

		[CompilerGenerated]
		private void BABOCAHDMGB()
		{
		}
	}
}
