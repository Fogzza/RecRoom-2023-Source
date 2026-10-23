using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace RecRoom.Core.Updates
{
	public class DynamicUpdateManager : UpdateManagerBase<NDKDHAJOJIM, HOOKIMFPFAK>
	{
		public delegate float EKFIKLGGAAI();

		public delegate bool HPAFFFCHOPL();

		public delegate Transform AKLHMODIOIA();

		private struct BDFMFAMIJKM
		{
			public EHIGGKJFCDL PDFEDMAOMNH;

			public bool GNGKKJPOAPJ;

			public Vector3 INLGLHIPOMC;
		}

		private sealed class NEBFKPGGNEP
		{
			public HPAFFFCHOPL isVisible;

			public AKLHMODIOIA getTransform;

			internal float _003CDefaultCostFunction_003Eb__0()
			{
				return 0f;
			}
		}

		private static DynamicUpdateManager EJDHGIDGKIB;

		private static bool FKNKJKILKMP;

		private static Transform MHKGLBCLJBN;

		private static List<BDFMFAMIJKM> OPNNMBINBGF;

public static DynamicUpdateManager Instance
{
get 		{
			return null;
		}

}

public static bool IsInitialized
{
get 		{
			return false;
		}

}

		public static EKFIKLGGAAI DefaultCostFunction(HPAFFFCHOPL GMEKKCPLMOB, AKLHMODIOIA LIJPGHNKGCA)
		{
			return null;
		}

		public void RegisterGroup(string LMCPBPEPKNG, float BFABNNEFILC, bool GOMDEGPJHDN, int[] PKALAOLCABI)
		{
		}

		public void RegisterObject(string LMCPBPEPKNG, Behaviour NPODHMILIGI, EKFIKLGGAAI OMGEPKBDCKI, EECFEKHMMHP.GCPMMFFIFPI HBMFEINCLMB)
		{
		}

		public void RegisterPointOfInterest(EHIGGKJFCDL AEGBIKFABPF)
		{
		}

		public void UnregisterPointOfInterest(EHIGGKJFCDL AEGBIKFABPF)
		{
		}

		protected override void DMDLCPBCBLH(List<NDKDHAJOJIM> DBFMCDMHPMN, UpdateRateLimitType NBCIJGBGOPI)
		{
		}
	}
}
