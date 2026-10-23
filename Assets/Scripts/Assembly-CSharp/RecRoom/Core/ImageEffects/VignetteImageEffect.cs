using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace RecRoom.Core.ImageEffects
{
	[DisallowMultipleComponent]
	public class VignetteImageEffect : MonoBehaviour
	{
		[Serializable]
		private struct VignetteSettings
		{
			public Color Color;

			public float Intensity;

			public float Smoothness;

			public bool IsSquareVignette;

			public bool SupportsIntensityRange;

			public float MinRangeIntensity;

			public float MaxRangeIntensity;

			public static VignetteSettings Default;
		}

		private class LMKOEOCHNLC
		{
			public string PALADLMJNAK;

			public Color OHPPOFOLCOA;

			public float AHAJNOALBEM;

			public bool KMIMNPFJDLC;

			public bool HNLKOIFNMMO;

			public float NHIBNHKNHFC;

			public float DKEANNKJBNI;

			public float MJMKBACCGHA;

			public float NKPGOALBACM;

			public float ACEBHGJPOOK;

			public bool KMMJNKBHFGO;

			public bool MPDAMMGPFGK;

			public float FLCLBKJNHNM;

			public float ABDIGLDCHOJ;

			public readonly int LDHIBGALEDK;

public float DHAJLEGAMLK
{
get 			{
				return 0f;
			}

}

			public float KGIEFFFALCF()
			{
				return 0f;
			}

			public LMKOEOCHNLC(int LAGADKBKLAD, string KNOPFGAGMCN, bool MJKIDOMBIPF = false)
			{
			}

			private float FDEJHFAAFEK()
			{
				return 0f;
			}
		}

		[SerializeField]
		private VignetteSettings teleporterLocomotionComfortSettings;

		[SerializeField]
		private VignetteSettings teleportSettings;

		[SerializeField]
		private VignetteSettings walkSettings;

		[SerializeField]
		private VignetteSettings sprintSettings;

		[SerializeField]
		private VignetteSettings climbClamberSettings;

		[SerializeField]
		private VignetteSettings fallSettings;

		[SerializeField]
		private VignetteSettings slideSettings;

		[SerializeField]
		private VignetteSettings flySettings;

		[SerializeField]
		private VignetteSettings vehicleSettings;

		[SerializeField]
		private VignetteSettings forcesSettings;

		[SerializeField]
		private VignetteSettings continuousRotationSettings;

		[SerializeField]
		private VignetteSettings swipeRotateSettings;

		[SerializeField]
		private VignetteSettings worldCollisionSettings;

		[SerializeField]
		private VignetteSettings takeDamageSettings;

		[SerializeField]
		private Mesh mobileVignetteMesh;

		[SerializeField]
		private AnimationCurve mobileVignetteIntensityCurve;

		[SerializeField]
		private AnimationCurve mobileVignetteStereoIntensityCurve;

		[SerializeField]
		private float mobileVignetteStereoIntesity;

		private const float EOFBHGPIMDH = 0.1f;

		private const float KCEINHJMEIM = 0.25f;

		private const float JCLMIPGBOJO = 1f;

		private const float COMKOFHOMCE = 7.5f;

		private const float IFOJMDFFMBN = 1.66f;

		private const float MJEBDFOPFLC = 0.001f;

		private readonly List<LMKOEOCHNLC> PEODBBLODMP;

		private LMKOEOCHNLC KNLKNIPCCDE;

		private LMKOEOCHNLC EDLFODJKBKI;

		private LMKOEOCHNLC HENOMEGAHIO;

		private LMKOEOCHNLC FHICPPBBICH;

		private LMKOEOCHNLC EGECACNGOAI;

		private LMKOEOCHNLC DHEFDHAEPLP;

		private LMKOEOCHNLC ELBGFEJJFAC;

		private LMKOEOCHNLC AAMIEEMANPB;

		private LMKOEOCHNLC OKJMKHGHDGG;

		private LMKOEOCHNLC GLIHDDHLIHI;

		private LMKOEOCHNLC PJCEHDGPLNA;

		private LMKOEOCHNLC MPHMGJKAPJK;

		private LMKOEOCHNLC ODHOPDLKNCO;

		private LMKOEOCHNLC EHJPHAHDIMJ;

		private LMKOEOCHNLC GMDJLBFKBHA;

		private float KJMDGMBJIAJ;

		private float OGFJLABPBJI;

		private float MGFNAPIADFJ;

		private float CAKEFGLCDPA;

		private float LICPMGIICCC;

		private VolumeProfile HDIBHMLMKIM;

		private JNKNMMDAHCF DHCLACKALOF;

private LMKOEOCHNLC HBEBMCCEHHF
{
get 		{
			return null;
		}

}

private bool CPPIDJKNLGG
{
get 		{
			return false;
		}

}

		public void Initialize(VolumeProfile HDIBHMLMKIM)
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void StartWorldCollisionVignette(float BMEFMHLONIK)
		{
		}

		public void StopWorldCollisionVignette(float LFJNMLGJBFD)
		{
		}

		public void StartTeleportVignette(float BMEFMHLONIK)
		{
		}

		public void StopTeleportVignette(float LFJNMLGJBFD)
		{
		}

		public void StartFlyVignette(float BMEFMHLONIK)
		{
		}

		public void StopFlyVignette(float LFJNMLGJBFD)
		{
		}

		public void StartContinuousRotationVignette(float BMEFMHLONIK)
		{
		}

		public void StopContinuousRotationVignette(float LFJNMLGJBFD)
		{
		}

		public void StartSwipeRotateVignette(float BMEFMHLONIK)
		{
		}

		public void StopSwipeRotateVignette(float LFJNMLGJBFD)
		{
		}

		public void StartFallingVignette(bool OBFOPJHLMBO, float BMEFMHLONIK)
		{
		}

		public void StopFallingVignette(float LFJNMLGJBFD)
		{
		}

		public void StartClimbingVignette(float BMEFMHLONIK)
		{
		}

		public void StopClimbingVignette(float LFJNMLGJBFD)
		{
		}

		public void StartWalkingVignette(float BMEFMHLONIK)
		{
		}

		public void StopWalkingVignette(float LFJNMLGJBFD)
		{
		}

		public void StartVehicleVignette(float BMEFMHLONIK)
		{
		}

		public void StopVehicleVignette(float LFJNMLGJBFD)
		{
		}

		public void StartForcesVignette(float BMEFMHLONIK)
		{
		}

		public void StopForcesVignette(float LFJNMLGJBFD)
		{
		}

		public void StartSprintingVignette(float BMEFMHLONIK)
		{
		}

		public void StopSprintingVignette(float LFJNMLGJBFD)
		{
		}

		public void StartSlideVignette(float BMEFMHLONIK)
		{
		}

		public void StopSlideVignette(float LFJNMLGJBFD)
		{
		}

		public void StartSeatTransitionVignette(float BMEFMHLONIK = 0f)
		{
		}

		public void StopSeatTransitionVignette(float LFJNMLGJBFD = 0f)
		{
		}

		public void StartComfortModeLayer(float BMEFMHLONIK)
		{
		}

		public void StopComfortModeLayer(float LFJNMLGJBFD)
		{
		}

		public void SetComfortModeInterpolation(float IHPJCBCPLCM)
		{
		}

		public void SetWalkingVignetteIntensityInterpolation(float HLFPKOMKNDJ)
		{
		}

		public void SetSlideVignetteIntensityInterpolation(float HLFPKOMKNDJ)
		{
		}

		public float GetVehicleVignetteIntensityInterpolation()
		{
			return 0f;
		}

		public void SetVehicleVignetteIntensityInterpolation(float HLFPKOMKNDJ)
		{
		}

		public void StartTakeDamageVignette(float BMEFMHLONIK)
		{
		}

		public void StopTakeDamageVignette(float LFJNMLGJBFD)
		{
		}

		public void StartCircuitVignette(float BMEFMHLONIK, Color HMCAFGCGFJF, float DOEJGDJILAD)
		{
		}

		public void StopCircuitVignette(float LFJNMLGJBFD)
		{
		}

		private void EANHLOAGAGG(LMKOEOCHNLC KOADGMIKBAB, VignetteSettings CAOIPCMMNMJ, float IMJAKNMGIJI)
		{
		}

		private void FMLIPHCMDLL(LMKOEOCHNLC KOADGMIKBAB, float OGCKDCJOOGH)
		{
		}

		private void DDIHOMNLMFG()
		{
		}

		private void GAPFOKKODGK()
		{
		}

		private bool HLNBMFEJOBG(LMKOEOCHNLC KOADGMIKBAB)
		{
			return false;
		}

		private void NPABHJGPFEE(LMKOEOCHNLC KOADGMIKBAB)
		{
		}

		private void EPBFJPHJFFO()
		{
		}

		private LMKOEOCHNLC LNLFJEBLNJE()
		{
			return null;
		}
	}
}
