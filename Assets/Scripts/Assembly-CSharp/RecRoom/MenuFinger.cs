using System;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using Photon.Pun;
using RecRoom.Core.UI;
using RecRoom.Inputs;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom
{
	public class MenuFinger : MonoBehaviour
	{
		private const float HHCPEAPFGGF = 1f;

		private const float CENPDPOADJM = 0.7f;

		private const float KLKGNBJJMLD = 0.5f;

		private const float IEBBJJLMIDA = 0.1f;

		private const float OHFCCJFEJAL = 0.005f;

		private const float HMBFCIIGCNC = -0.1f;

		private const float PIMAAEBONLB = 0.2f;

		private const float NDHCHHLNIEK = 20f;

		private const float FPHNEKIBGGI = 0.02f;

		private const float BKLIPHMGEPK = 30f;

		public Transform FingertipTransform;

		[SerializeField]
		public BoxCollider overlapCollider;

		[SerializeField]
		private PhotonView photonView;

		[SerializeField]
		private PlayerHand.ICBKGDOJNDN fingerType;

		[SerializeField]
		private LineRenderer menuLaser;

		[SerializeField]
		private AnimationCurve laserScaleByDistanceCurve;

		[SerializeField]
		private float fadeOutNormalizedPosition;

		[SerializeField]
		[Space]
		private RectTransform laserDotRoot;

		[SerializeField]
		private Image laserDotImage;

		[SerializeField]
		private float laserDotSquashScale;

		[SerializeField]
		private RectTransform tactileButtonRoot;

		[SerializeField]
		private RectTransform tactileGridCutout;

		[SerializeField]
		private CanvasScaler tactileButtonCanvasScaler;

		[SerializeField]
		[Space]
		private RectTransform tactileGridRoot;

		[SerializeField]
		private Image tactileGridImage;

		[SerializeField]
		private Material tactileGridHoverMaterial;

		[SerializeField]
		private Material tactileGridPressedMaterial;

		[SerializeField]
		[Space]
		private float tactileTravelDistance;

		[SerializeField]
		private float tactileActuationPercent;

		[SerializeField]
		private float tactileReleasePercent;

		[SerializeField]
		private float tactileHoverDistance;

		[SerializeField]
		private float tactilePreHoverDistance;

		[SerializeField]
		private float tactileVisualSquashRadius;

		private CanvasGroup[] JKILBMEOFDG;

		private CanvasGroup EANGACOLGBO;

		private CanvasGroup OBCLGIDLPBF;

		private Button3DBase PLBDDDBADKE;

		private PhysicalButtonBase HHBOCLNINNO;

		private IDisposable OBECBJCGHMB;

		private GBKDNGEMHGJ KIBAPIGAIEB;

		private GameObject JKPLDGODMPJ;

		private Vector3 JBMAAEBIDDM;

		private Vector3 JGGLIEGOPHP;

		private bool EOEKKAMDOEJ;

		private bool AGNNLKCJDNB;

		private bool DBKGDHADEDN;

		private bool IGMFLPCLDCJ;

		private static JNKNMMDAHCF JPKKAMIKFJO;

		private VRCanvas EPEKOBDKDMJ;

		private float JHBJJOKAHCI;

		private float AGPINFKEFIB;

public bool HadUIInput
{
get 		{
			return false;
		}

private set {
		}
}

private static JNKNMMDAHCF BLCBBOHOOGI
{
get 		{
			return null;
		}

}

private VRInputHandler KPFCDEIIEPO
{
get 		{
			return null;
		}

}

private float DFKGBPEEMOB
{
get 		{
			return 0f;
		}

}

private float KBJHJBLIGFG
{
get 		{
			return 0f;
		}

}

private float MMKEPMODDAK
{
get 		{
			return 0f;
		}

}

public float TactileHoverRange
{
get 		{
			return 0f;
		}

}

public float TactilePreHoverRange
{
get 		{
			return 0f;
		}

}

public float TactileMinSubmergedDistance
{
get 		{
			return 0f;
		}

}

public VRCanvas LastHoveredTactileCanvas
{
get 		{
			return null;
		}

set {
		}
}

public float LastHoveredTactileCanvasAltitude
{
get 		{
			return 0f;
		}

set {
		}
}

public bool IsHoveringCanvasForTactilePress
{
get 		{
			return false;
		}

}

public bool IsPreHoveringCanvasForTactilePress
{
get 		{
			return false;
		}

}

public bool IsLaserEnabled
{
get 		{
			return false;
		}

}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void PONCEJGGKKF()
		{
		}

		public void Vibrate(int HIJKHPMDNMK, float DOEJGDJILAD)
		{
		}

		private void GAHHBGJBCCA(float OKBAJEAPIHG)
		{
		}

		private void EODMPAOBGAH()
		{
		}

		public void UpdateUIInput(CHILKDJABBF FBCDJHOIDJJ, DLLIMLHNBON KKDCMADMHMO, Vector2 KFMBEKEFMNO, UIInputModule.GJFEIPEOFAK CFOEBLBCFBB)
		{
		}

		private bool AFGCNBBGJND(UIInputModule.GJFEIPEOFAK CFOEBLBCFBB)
		{
			return false;
		}

		private bool ABIPJBJDKAC(UIInputModule.GJFEIPEOFAK CFOEBLBCFBB, bool FHNKMHBHBNP)
		{
			return false;
		}

		private bool CHJKKCMLJOE(UIInputModule.GJFEIPEOFAK CFOEBLBCFBB, out float DAMOGGANOJL)
		{
			DAMOGGANOJL = default;
			return false;
		}

		private void GJMPNLBKNEE(UIInputModule.GJFEIPEOFAK CFOEBLBCFBB, UIInputModule.IAPKENCHHMC LBLLDHNCAME, bool LEBLMIDDCCD)
		{
		}

		private void FEACPPGHCOK(bool MFOOLFJFANH, bool MOCOCOGLMLL, CHILKDJABBF EKOFNPFCLMO, PhysicalButtonBase HHDMPJJAPJJ)
		{
		}

		public void ReleaseLaserPushedButton(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		public void UpdateMenuLaser(Vector3 EDGHCIEJHLG, UIInputModule.GJFEIPEOFAK CDNLFEOBNKB, bool LBDAEPILOFM, bool GNCKIAEEHLH = true, bool GPKFJMEIBHN = true)
		{
		}

		public void UpdateGestureLaser(Vector3 EDGHCIEJHLG, Vector3 INKGHPCDMCG, bool DNPIJEOOLKB)
		{
		}

		public void UpdateLaser(Vector3 EDGHCIEJHLG, Vector3 OEGIKFAHBMH, Vector3 CHEKLLFMKBP, bool DNPIJEOOLKB, bool BHLPHMMGDHG, bool GNCKIAEEHLH, bool GPKFJMEIBHN)
		{
		}

		public void DisableMenuLaser()
		{
		}

		private float CEDACDLMPIO(Vector3 ALOGGMGGOCM, Vector3 OEGIKFAHBMH, bool BHLPHMMGDHG, bool DNPIJEOOLKB)
		{
			return 0f;
		}

		[CompilerGenerated]
		internal static RectTransform GMJCKPDEIMK(GameObject ICHBECDKHOJ)
		{
			return null;
		}
	}
}
