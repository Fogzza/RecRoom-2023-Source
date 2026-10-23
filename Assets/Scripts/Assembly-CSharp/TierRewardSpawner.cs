using System;
using System.Collections.Generic;
using AGUI.StackedUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TierRewardSpawner : MonoBehaviour
{
	private struct HKEGEOFEPDE
	{
		public Transform FGNGGLFNLIP;

		public Vector3 LNACHBLEBMJ;

		public Vector3 GDGKKBFEANN;
	}

	private sealed class ADFIIOKKCJB
	{
		public Transform[] rewardRoots;

		public TierRewardSpawner _003C_003E4__this;

		public List<CGGDEFPDNNN> rewards;
	}

	private sealed class GOAEPHJHHGN
	{
		public global::NCOKFFGPIJM<GameObject> rewardPromise;

		public int rewardIndex;

		public ADFIIOKKCJB CS_0024_003C_003E8__locals1;

		public Action<GameObject> _003C_003E9__2;

		internal void _003CSpawnVisuals_003Eb__0(Transform parent)
		{
		}

		internal void _003CSpawnVisuals_003Eb__2(GameObject visualGO)
		{
		}
	}

	private const float PBDMCDAPOHL = 62.5f;

	private const float HIHDILNOFPI = 93.75f;

	private static readonly int DJBPLPJLJHL;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private GiftBoxMerchVisual giftBoxMerchVisualPrefab;

	[SerializeField]
	private GameObject xpBoostVisualPrefab;

	[SerializeField]
	private TextMeshProUGUI tierNumberText;

	[SerializeField]
	private Button3D buyTierButton;

	[SerializeField]
	private Transform[] freeRewardRoots;

	[SerializeField]
	private GameObject freeRewardBottomRow;

	[SerializeField]
	private Image freeBackground;

	[SerializeField]
	private GameObject freeLockObject;

	[SerializeField]
	private Transform[] paidRewardRoots;

	[SerializeField]
	private GameObject paidRewardBottomRow;

	[SerializeField]
	private Image paidBackground;

	[SerializeField]
	private GameObject paidLockObject;

	[SerializeField]
	private Color freeUnlockedColor;

	[SerializeField]
	private Color freeLockedColor;

	[SerializeField]
	private Color paidBasicPlayerUnlockedColor;

	[SerializeField]
	private Color paidElitePlayerUnlockedColor;

	[SerializeField]
	private Color paidLockedColor;

	private KGFLMPJOODP NBGNNIGCIJD;

	private float PJEDHHNKKDM;

	private float LPKIKLIHION;

	private float IMICOBDGKPI;

	private float CKPEJPAMEHA;

	private bool FGJDJPNGAHO;

	private OMNLIPPAPDI CMKBBNLKAON;

	private List<HKEGEOFEPDE> IPILJHGNEHH;

	[HideInInspector]
	public WatchUIFlow ThisFlow;

public Button3D.OnButton3DClick ButtonAction
{
get 	{
		return null;
	}

}

public int TierNumber
{
get 	{
		return 0;
	}

}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void LIEPLBEJPPB(OMNLIPPAPDI CAPKFCHDLFA)
	{
	}

	private void POLCEDOIIII(int LHICMLPLMKO, OMNLIPPAPDI CAPKFCHDLFA)
	{
	}

	public void UpdateBuyButton(bool PCNPMPMHGHF, string HLIGBKANEEA)
	{
	}

	public void PlayUnlockAnimation(float FGBPJMKCMAO)
	{
	}

	private void JLGLBDLEMFB(bool JNMICCLKBDH, bool IKFMMDOEGHH, bool LKCEHCNBOAP)
	{
	}

	public void SetTier(KGFLMPJOODP JHHLNFDJCHE, bool JNMICCLKBDH, bool IKFMMDOEGHH, bool LKCEHCNBOAP)
	{
	}

	private void KEEEJEAEABL(List<CGGDEFPDNNN> BCLPEFKFMEA, Transform[] HIODNAACBIM, GameObject LJPPCBJEDIL)
	{
	}

	private void PCAHMKJPEHI(bool CFFILBOIDIO)
	{
	}

	private void PDHIGPJBDAJ(List<CGGDEFPDNNN> BCLPEFKFMEA, Transform[] HIODNAACBIM)
	{
	}
}
