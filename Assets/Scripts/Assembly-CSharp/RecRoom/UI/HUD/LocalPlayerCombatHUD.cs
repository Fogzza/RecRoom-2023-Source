using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.UI.HUD
{
	public class LocalPlayerCombatHUD : MonoBehaviour
	{
		public delegate string AHCDEAILNAF();

		public delegate bool ENPNABOPGPC(out int JFBHLKBFDJI, out bool EDINMKJNNMK, out int KDENGJAAAAA, out int KFFDGGIMLOJ, out bool AMCPEAKKBKO, out int LIJGJGIGLOD);

		[SerializeField]
		private CanvasScaler canvasScaler;

		[SerializeField]
		private Image[] extraTeamColorElements;

		[SerializeField]
		private Slider healthBar;

		[SerializeField]
		private Slider shieldBar;

		[SerializeField]
		private Slider dbnoBar;

		[SerializeField]
		private AmmoHUDElement leftHandAmmoHUD;

		[SerializeField]
		private AmmoHUDElement rightHandAmmoHUD;

		[SerializeField]
		private ScoreHUDElement thisTeamScoreHUD;

		[SerializeField]
		private GameObject singleOpponentsTeamScoreRoot;

		[SerializeField]
		private ScoreHUDElement singleOpponentTeamScoreHUD;

		[SerializeField]
		private GameObject multipleOpponentsTeamScoreRoot;

		[SerializeField]
		private ScoreHUDElement[] multipleOpponentsTeamScoreHUDs;

		[SerializeField]
		private Text timerText;

		[SerializeField]
		private Canvas raceCanvas;

		[SerializeField]
		private Image racePlacementImage;

		[SerializeField]
		private Sprite[] racePlacementSprites;

		[SerializeField]
		private GameObject raceLapRoot;

		[SerializeField]
		private Text raceLapText;

		[SerializeField]
		private GameObject raceTimerRoot;

		[SerializeField]
		private Text raceTimeText;

		[SerializeField]
		private RemainingPlayersHUDElement remainingPlayersHUD;

		private Dictionary<GIBEGHKMCIE, ScoreHUDElement> MNGNOJMEGAB;

		private GameManager EAFKMPKOOGD;

		private CHILKDJABBF EKOFNPFCLMO;

		private Player BEMAFDJKONA;

		private Transform HOBAGGDMEIK;

		private readonly FIHGBEHGLGB IPFDLHKAINF;

		public AHCDEAILNAF TimerStringOverride;

		public ENPNABOPGPC RaceUIProvider;

private GameManager ENALBCPMOHF
{
get 		{
			return null;
		}

set {
		}
}

public Transform ParentTransform
{
get 		{
			return null;
		}

set {
		}
}

public bool IsCombatHUDRestricted
{
get 		{
			return false;
		}

}

		private void LateUpdate()
		{
		}

		private void OnDestroy()
		{
		}

		public void Initialize(GameManager KPCADKBOAFA, CHILKDJABBF EKOFNPFCLMO, IALAJKBOKBN EALMNLFNNDM = IALAJKBOKBN.OverlayNotifications, Transform HNECJLNIOCG = null)
		{
		}

		private void MFNKMCIINAL()
		{
		}

		private void JCNMAFMBIHL()
		{
		}

		private void KCEDPOPLBFJ()
		{
		}

		public void AddCombatHUDRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveCombatHUDRestriction(object IALNODEHBNN)
		{
		}

		public void Enable(bool OBFHBDLKFPA, object IALNODEHBNN)
		{
		}

		private void PMCFKMHNFMC()
		{
		}

		private void MHGBPFABJBI(CHILKDJABBF FFDEPLCDBNA, bool OHDEKMCDIPE)
		{
		}

		private void OELKHJICBPB()
		{
		}

		private void GGPIDCDEMLB(bool IAFOLNODICF, bool ANBOMEJNDMI, bool GEFAMLAKCKB)
		{
		}

		private void PPDMIIMDFMF()
		{
		}

		private void AGIGBMJDIJK(bool LIKOBOFKNKJ)
		{
		}

		private void GONNAJFIGOK()
		{
		}

		private void MJJMDICONIM()
		{
		}

		private void DJIPLDHDINM()
		{
		}

		private void KGJDOPHLPAP()
		{
		}

		private void GHDDIJHNHFA()
		{
		}

		private void CPJAJCMOMHI()
		{
		}

		private void BLGCHNEAHMK()
		{
		}

		private bool NOMPPCBGGAF(out Sprite GGKABKCGFFO, out bool EDINMKJNNMK, out string LBMAMEOGDJN, out bool AMCPEAKKBKO, out string DFCKKNELCNH)
		{
			GGKABKCGFFO = null;
			EDINMKJNNMK = default;
			LBMAMEOGDJN = null;
			AMCPEAKKBKO = default;
			DFCKKNELCNH = null;
			return false;
		}

		private void LOLMIJAHGFJ()
		{
		}
	}
}
