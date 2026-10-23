using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace RecRoom
{
	[Serializable]
	public class SceneRenderingSettings : NMIKADGOIOE
	{
		private struct IINEOEHKKOP
		{
			public Camera GAPPCJHIBEK;

			public UniversalAdditionalCameraData ICPLLOMMEAO;

			public float? JDLDOCKKAFG;

			public bool? JCEEGOCAGOI;

			public bool? EBHPDGJFDHH;
		}

		public const float DEFAULT_NEAR_CLIP_PLANE = 0.06f;

		public const float DEFAULT_FAR_CLIP_PLANE = 1000f;

		[SerializeField]
		private bool overrideFarClip;

		[SerializeField]
		private float farClip;

		[SerializeField]
		private bool overrideShadowDistance;

		[SerializeField]
		private float shadowDistance;

		private float? initialShadowDistance;

		[SerializeField]
		private bool overrideAllowMSAA;

		[SerializeField]
		private bool allowMSAA;

		[SerializeField]
		private bool forceCachedShadowsOnLowTiers;

		private List<IINEOEHKKOP> cameraSettings;

		private global::MOBDJNEDDKC<bool> _showGadgetsToEveryone;

		private bool dryRunShowGadgetsToEveryone;

		private global::MOBDJNEDDKC<bool> _useNewMaterials;

		[CompilerGenerated]
		private Action SettingsChangedEvent;

		public bool ShowGadgetsToEveryone => false;

		public bool UseNewMaterials
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float FarClipPlane => 0f;

		public float NearClipPlane => 0f;

public event Action GCEJIDLFBFI {
add {
		}
remove {
		}
}

		public void JGHENDHCBHF(RecRoomSceneManager MACMCOFLIIO)
		{
		}

		public void BJDNGFKFKPK()
		{
		}

		public void LJODMHLJPAD()
		{
		}

		public void CDJHKCNAIKI()
		{
		}

		public void KPFOBOPDHJM()
		{
		}

		public void IMKOKFGADBA(Camera GAPPCJHIBEK)
		{
		}

		public bool LLLIBLICOLF(bool IPMIIEAGJKC, bool COPOILGLIAJ = false)
		{
			return false;
		}

		private void AJOLFBHFOMM()
		{
		}

		[CompilerGenerated]
		private void BMLKDGIGNMP()
		{
		}
	}
}
