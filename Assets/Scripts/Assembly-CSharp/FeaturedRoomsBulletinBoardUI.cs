using System;
using System.Collections.Generic;
using AGUI.StackedUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeaturedRoomsBulletinBoardUI : MonoBehaviour
{
	[Serializable]
	public struct FeaturedRoomData
	{
		public string roomName;

		public long roomId;

		public Texture2D featuredImage;
	}

	private struct MNNPFBBICGP
	{
		public bool NNAKHLOJMNI;

		public bool PIECHKFHCLE;
	}

	private sealed class NHPHLLCKDIN
	{
		public int roomListIdx;

		public FeaturedRoomsBulletinBoardUI _003C_003E4__this;

		internal void _003CRefresh_003Eb__0(Texture2D texture)
		{
		}
	}

	private static readonly LALFNFGHKHL.HIPPLPKINHO AJNKLNMHEEG;

	[SerializeField]
	private GameObject featuredRoomsContainer;

	[SerializeField]
	private GameObject defaultContainer;

	[SerializeField]
	private TextMeshProUGUI featuredRoomGroupName;

	[SerializeField]
	private TextMeshProUGUI featuredRoomName;

	[SerializeField]
	private RawImage featuredRoomImage;

	[SerializeField]
	private float displayTimePerRoom;

	[SerializeField]
	private Animator contentRefreshAnimator;

	[SerializeField]
	private GameObject roomFullMessage;

	[SerializeField]
	private GameObject roomErrorMessage;

	[SerializeField]
	private Button3DBase goToRoomButton;

	private int PLAEBHAABDC;

	private float EJMOOJFKPPB;

	private bool IDIGDPNANHF;

	private int DODNLEGHCMG;

	private FeaturedRoomData[] NGFEBJIIMBM;

	private List<GDHOAGNFOBD.KEIAPDLHGPG> EOCCMOAOALB;

	private MNNPFBBICGP[] BMCOKCABMBP;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	private void GODLBKDFPDG()
	{
	}

	private void JNIILPBDPBA()
	{
	}

	private void JNKKHIANKLN()
	{
	}

	private void PJIOBKBKDLE()
	{
	}

	private void HJKDGGBOFFA(int CMIGEHOIFPM)
	{
	}

	private void GLFKAPHICKE(ANAGHNCECEB CDNLFEOBNKB)
	{
	}

	public void Button_GoToCurrentRoom()
	{
	}

	public void Button_ShowNextRoom()
	{
	}

	public void Button_ShowPreviousRoom()
	{
	}
}
