using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.Tools.Productivity
{
	public class DesktopScreenSharingDisplay : MonoBehaviourPun, KFLNCOLKJEM
	{
		[Serializable]
		private class QualitySettings
		{
			public float ImageRefreshFrequency;

			public int ImageHorizontalResolution;

			public int ImageCompressionQuality;
		}

		private sealed class DDFBIGHMDMK
		{
			public DesktopScreenSharingDisplay _003C_003E4__this;

			public int localPlayerId;

			internal void _003CTryStartBroadcasting_003Eb__0(bool hasScreenSharePermissions)
			{
			}
		}

		private sealed class PENNDKIPLKC
		{
			public int photonActorNr;

			public DesktopScreenSharingDisplay _003C_003E4__this;

			public CHILKDJABBF photonPlayer;

			internal bool _003CTrySetRemoteBroadcaster_003Eb__0(CHILKDJABBF p)
			{
				return false;
			}

			internal void _003CTrySetRemoteBroadcaster_003Eb__1(bool hasScreenSharePermissions)
			{
			}
		}

		private sealed class MCEMJPFKIHI
		{
			public int reportedPlayerId;

			internal void _003CButton_Report_003Eb__0(string imageName)
			{
			}
		}

		private const float NOKHHEFCLGD = 5f;

		private const float GDIBAFKBHBA = 0.2f;

		private const float GJEFBECNBCM = 10f;

		private const string BIBMKLDLPGF = "UGC.ScreenSharing.ResolutionMultiplier";

		private const string PEDLNGEMBPI = "UGC.ScreenSharing.RefreshHzMultiplier";

		private const string LNNADJAPKAL = "UGC.ScreenSharing.CompressionQualityMultiplier";

		private const string INIIGCINGOJ = "UGC.ScreenSharing.EnableZipCompression";

		private const string NJDACBOEDKE = "UGC.ScreenSharing.MaxFragmentBytes";

		private const string GNNOGADIGIB = "UGC.ScreenSharing.EnabledForMultiInstanceEvents";

		private const int LKBOAAKPFFD = 0;

		private const int IKHJKALAKCA = -1;

		private const int BKJHNDEJFNH = 10;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private Renderer screenRenderer;

		[SerializeField]
		private int screenMaterialIndex;

		[SerializeField]
		private Material enabledMaterialPrefab;

		[SerializeField]
		private Material disabledMaterial;

		[SerializeField]
		private TextMeshProUGUI broadcasterLabel;

		[SerializeField]
		private Button displayIndexCycleButton;

		[SerializeField]
		private Button reportButton;

		[SerializeField]
		private QualitySettings broadcastingToSingleInstanceQuality;

		[SerializeField]
		private QualitySettings broadcastingToMultipleInstancesQuality;

		private static byte[] FKBBHNJMIML;

		private static readonly Dictionary<int, DesktopScreenSharingDisplay> NEBGKOIOMPE;

		private global::JPEBBAFCBEP<int, int> AMIKEMEGOHN;

		private Material[] LDFHAEGIADD;

		private Material LLOKLFPGOIB;

		private Texture2D INMOMJFAEKK;

		private float NBFJECOGDGF;

		private IILDCCEMGBA LCPOIILBNLD;

		private float KHKHCJPFJOJ;

		private float IFBHABJNCCG;

		private float DKOJLJJAFEJ;

		private bool IJJKMIBPPON;

		private int OCILKHMKJCO;

		private bool IMCINHFBNOI;

		private readonly LCLJBBEDPBO PEPNMGCKKHN;

		private readonly JKGPGIMFHEC KAAODLGBDBO;

		private float LBHKOCEAGHC;

		private float DNKAHKABDND;

public static Dictionary<int, DesktopScreenSharingDisplay> ActiveDisplaysByPhotonViewId
{
get 		{
			return null;
		}

}

private int FCMAODIOPJD
{
get 		{
			return 0;
		}

}

private bool OLCGPNMEECP
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void EEDKFEHNKNM()
		{
		}

		private void Update()
		{
		}

		public void OnPhotonSerializeView(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
		{
		}

		private float LPMOKKGMMPJ(ANEIIIEOCMN EDIGAFOKGOJ)
		{
			return 0f;
		}

		private void KKLDCDEBBND(ANEIIIEOCMN EDIGAFOKGOJ)
		{
		}

		private void BLMKLELKCED(byte[] GMJJBPLGCNA)
		{
		}

		private void BGCAAGBKMLC()
		{
		}

		private void EHILAJFKNDK(QualitySettings MPAOCGOAKAA)
		{
		}

		private void JIPBMJIGONO()
		{
		}

		private void MLNNGCDMIEF()
		{
		}

		private int KDEMLEJDLPC()
		{
			return 0;
		}

		private bool FHBNAMBANOI()
		{
			return false;
		}

		private bool GJFOGHPNKNF()
		{
			return false;
		}

		private bool EBODJIPNDEI()
		{
			return false;
		}

		private bool PHDGJHJFKFA()
		{
			return false;
		}

		private bool CPNINCIIIJO()
		{
			return false;
		}

		private void JCBKABIGNDA(CHILKDJABBF HIGOLKPFBPL)
		{
		}

		private void NMAHCCOBCPA()
		{
		}

		private void POGFLEHJJIP()
		{
		}

		public void TrySetRemoteBroadcaster(int AHKKEMKGOHL)
		{
		}

		private void MLBKMIEACBG()
		{
		}

		private void AFBFKEHAELP()
		{
		}

		private void LJMBFMNAJBC(string KNOPFGAGMCN)
		{
		}

		private void OIEECKBCMGB()
		{
		}

		public void Button_ToggleBroadcastingClaim()
		{
		}

		public void Button_CycleScreenIndex()
		{
		}

		public void Button_Report()
		{
		}

		[CompilerGenerated]
		private void GBLOKGEIHFG(byte[] DMDILGKAAJM)
		{
		}

		[CompilerGenerated]
		private void IHKBNMEEJEB(DFDECAEJBIO ACBGBAAHOIM)
		{
		}
	}
}
