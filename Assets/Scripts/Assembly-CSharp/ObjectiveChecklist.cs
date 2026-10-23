using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AGUI.StackedUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveChecklist : MonoBehaviour
{
	public enum HIDBMDGLFFM
	{
		Daily = 0,
		Weekly = 1
	}

	private sealed class JIMFCAIAKNP
	{
		public global::NCOKFFGPIJM<GameObject> rewardPromise;

		public ObjectiveChecklist _003C_003E4__this;

		internal void _003CSpawnReward_003Eb__4(Transform parent)
		{
		}
	}

	private sealed class IIALFJJFEBI
	{
		public Transform parent;

		public JIMFCAIAKNP CS_0024_003C_003E8__locals1;

		internal void _003CSpawnReward_003Eb__5(GameObject rewardObject)
		{
		}
	}

	[SerializeField]
	private Transform rewardRoot;

	[SerializeField]
	private Image rewardBackground;

	[SerializeField]
	private Color rewardedColor;

	[SerializeField]
	private Color notRewardedColor;

	[SerializeField]
	private ObjectiveView[] objectiveViews;

	[SerializeField]
	private TextMeshProUGUI allCompleteTokenText;

	[SerializeField]
	private HIDBMDGLFFM listType;

	[SerializeField]
	private GameObject allObjectivesCompleteImage;

	[SerializeField]
	private bool rewardUsedForFullSizeDisplay;

	[SerializeField]
	private float scaledRewardLocalRadius;

	[SerializeField]
	private GameObject tokenRewardParent;

	[SerializeField]
	private GameObject giftBoxRewardParent;

	[SerializeField]
	private string giftBoxMerchVisualPrefabName;

	[SerializeField]
	private float giftBoxRadius;

	[SerializeField]
	private GameObject tokenDescriptionText;

	[SerializeField]
	private GameObject rewardDescriptionText;

	public Action OnRewardClaimed;

	public Action<GameObject> OnRewardObjectSpawned;

	private CancellationTokenSource BGAGMFECJMM;

	private GameObject JJHOFOINHJM;

	private static bool DKNENHOEKLG;

	private static int LJDGHPLFKCD;

	private static int BAPPMJCIOEN;

	[NonSerialized]
	public StackedUIBase StackedUIBase;

	private static EEANDDJEMJC DOMDMMLBCCN;

public HIDBMDGLFFM ListType
{
get 	{
		return HIDBMDGLFFM.Daily;
	}

}

private bool BLABKJAFDON
{
get 	{
		return false;
	}

}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	private void PPHBLDJAELB()
	{
	}

	public bool UpdateAllObjectives()
	{
		return false;
	}

	private bool DOCKLLIDADP()
	{
		return false;
	}

	private bool PPCDCPJBBOE()
	{
		return false;
	}

	private void CJMECMOIKJK()
	{
	}

	private static void JECLAJKEOKL(GameObject BLNEOFLILEB, Transform HHFDFFDPCGO, bool DLCPKCOGMND, float MBEGOAAGGBN, Action<GameObject> NCNBKHPIDMM)
	{
	}

	private static void PAIBBGPHPEI()
	{
	}

	[CompilerGenerated]
	private void ACJKALNBCCO(GameObject BLNEOFLILEB)
	{
	}

	[CompilerGenerated]
	private Task<GameObject> FEBAIDBHFFO(CancellationToken IALNODEHBNN)
	{
		return null;
	}

	[CompilerGenerated]
	private void NNIHOKNGEKE(GameObject HKPJJHILEBG)
	{
	}
}
