using System;
using System.Collections.Generic;
using RecRoom.Core;
using RecRoom.Core.Rendering;
using UnityEngine;

namespace RecRoom.Avatars
{
	public class PlayerAvatarDisplayIgnoreEffect : MonoBehaviour
	{
		public struct GLCAHADFBOK
		{
			public Vector3 INLGLHIPOMC;

			public float NNLEGJGIGHA;
		}

		private static readonly SkinnedMeshRenderer[] ELPJPEGIDPP;

		private const float HCHJJAGNLIL = 9f;

		private const float JLBFIABIPJA = 0f;

		private const float JMJNANEHHOP = 0.05f;

		[SerializeField]
		private Player thisPlayer;

		[SerializeField]
		private PlayerAvatarDisplay PlayerAvatarDisplay;

		[SerializeField]
		private Renderer[] extraHideRenderers;

		[SerializeField]
		private Renderer[] extraGhostRenderers;

		[SerializeField]
		private float headBufferRadius;

		[SerializeField]
		private float bodyBufferRadius;

		[SerializeField]
		private float handBufferRadius;

		[SerializeField]
		private float teamColorFadeAmount;

		private GameManager KPCADKBOAFA;

		private int CKKHPEFEMJG;

		private List<GLCAHADFBOK> NAJLKBDBLNP;

		private List<Renderer> LOKNGFHEPEH;

		private List<Renderer> BJAGDHAHECL;

		private Player GKIIIDJHFHP;

		private readonly FIHGBEHGLGB LDGBDCBOAOB;

		private bool ICNAGNDLCMF;

		private CameraIgnoreBubble NKBMAKJGEMI;

		private IgnoredRendererEffect.EDOKFCMFOJO? JCAENJPDFOD;

		private Color POIKCGEMLFM;

		private bool LLGPIBHBMAN;

		private IDisposable DHIBBMJFIGK;

		private float FPIBLHFAOPH;

		public Action<float> DesiredVoiceVolumeMultiplierChanged;

		private bool AAPPFOPLNFJ;

public Player ThisPlayer
{
get 		{
			return null;
		}

}

public Player IgnoringPlayer
{
get 		{
			return null;
		}

}

public CameraIgnoreBubble IgnoringCamera
{
get 		{
			return null;
		}

}

public Color IgnoreAccentColor
{
get 		{
			return default;
		}

}

public float MinAlpha
{
get 		{
			return 0f;
		}

}

public float MinVoiceMultiplier
{
get 		{
			return 0f;
		}

}

public bool IncludeHandsInDistanceCalculations
{
get 		{
			return false;
		}

}

public float DesiredVoiceVolumeMultiplier
{
get 		{
			return 0f;
		}

set {
		}
}

public bool Ignored
{
get 		{
			return false;
		}

private set {
		}
}

		private void Start()
		{
		}

		private void JPOLCEPLIHN()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		protected void OnDestroy()
		{
		}

		private void KGPEKODGCPL(CHILKDJABBF FFDEPLCDBNA, bool OHDEKMCDIPE)
		{
		}

		private void GAHHBGJBCCA(float OKBAJEAPIHG)
		{
		}

		private void MDOOCIBOGKK()
		{
		}

		private void LIOOHIMDIBG()
		{
		}

		public void SetHideInActiveCameraAndFirstPersonCameraIgnoreSettings()
		{
		}

		public void SetCustomIgnoredSettings(IgnoredRendererEffect.EDOKFCMFOJO CAOIPCMMNMJ)
		{
		}

		public void ClearCustomIgnoredSettings()
		{
		}

		public IReadOnlyList<GLCAHADFBOK> GetTestPoints()
		{
			return null;
		}

		private void HBHBBKEGGJC()
		{
		}

		private void LGEJEJBHMNM(IgnoredRendererEffect.EDOKFCMFOJO INDFAHOKEHG)
		{
		}

		private void MDHHBJOGGNO()
		{
		}

		private void DHEINEJINPN(Player GKIIIDJHFHP, bool LLGPIBHBMAN, float DFGADKANOHD = -1f)
		{
		}

		private void EDGLEMCIEPA(CameraIgnoreBubble LIMLPGGGLEG)
		{
		}

		private void HBHBBKEGGJC(Vector3 ODJJBMNEKIH, float HNBOEPGMOJB, float EIGIKPJOLPF, float DFGADKANOHD = -1f, List<Camera> IDMOCIJGMFH = null)
		{
		}

		private CameraIgnoreBubble GEPCIHLKCLN()
		{
			return null;
		}

		private Player FLNFCELLKAD(out bool LLGPIBHBMAN, out float FPIBLHFAOPH)
		{
			LLGPIBHBMAN = default;
			FPIBLHFAOPH = default;
			return null;
		}

		public void SetHideAvatar(object IALNODEHBNN, bool GMJGLPNAENI)
		{
		}

		private void MNAMFIKFMDK()
		{
		}

		private void JDHLLABGLFI(ref List<Renderer> LAIFMGFEHDJ, ref List<Renderer> AGIACEBDNDK)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
