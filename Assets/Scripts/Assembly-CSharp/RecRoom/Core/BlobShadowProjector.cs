using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace RecRoom.Core
{
	public class BlobShadowProjector : MonoBehaviour
	{
		public enum KLMFACEGOHH
		{
			SIMPLE_TEXTURE = 0,
			PROJECTED_RENDERERS = 1
		}

		private struct PCNMAHCGHBA
		{
			public Renderer CDLDAEEIHLI;

			public int[] DOIIGPFPKEE;

			public ShadowCastingMode OCACFEPLKGC;
		}

		private sealed class BCDHHAHIGKJ
		{
			public Renderer renderer;

			internal bool _003CRemoveShadowOnlyRenderer_003Eb__0(Renderer r)
			{
				return false;
			}
		}

		private sealed class LEENKFHFDCN
		{
			public Renderer renderer;

			internal bool _003CRemoveShadowCaster_003Eb__0(PCNMAHCGHBA r)
			{
				return false;
			}
		}

		private const int EPCMDKLBNKP = 256;

		private const int FEDJDNNFOMB = 8;

		private static readonly Quaternion AKMHHBCJOFC;

		private static Material KOLAOJJCOBM;

		[SerializeField]
		private Projector projector;

		[SerializeField]
		private KLMFACEGOHH defaultShadowType;

		[SerializeField]
		private Material simpleShadowMaterial;

		[SerializeField]
		private float simpleTextureOrthographicProjectionSize;

		[SerializeField]
		private float desiredPositionAboveParent;

		private KLMFACEGOHH IEGCOJLKJPK;

		private RenderTexture KAACGMLIKHK;

		private List<PCNMAHCGHBA> NPKPKBNACFA;

		private List<Renderer> COICOFKAOOM;

		private List<int> PMIECBFJKBH;

		private Material MAEMCDOBFAC;

		private IDisposable OBECBJCGHMB;

		private CommandBuffer FKAHEDPPANP;

		private Camera NMEBHKCNOLK;

		private FIHGBEHGLGB GJGNJLLNNPG;

		private Vector3 OMJJNEBPDDB;

		private Quaternion LOFHJKJJAPF;

		private float HMMBNAOEKIC;

		private static readonly Vector3[] PGFMJJBCFNM;

		private static readonly Color[] JKKDBHMLDMK;

private static Material PIJNOOGLFON
{
get 		{
			return null;
		}

}

		public void AddBlobShadowsRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveBlobShadowsRestriction(object IALNODEHBNN)
		{
		}

		public void SetShadowType(KLMFACEGOHH IEGCOJLKJPK)
		{
		}

		public void AddShadowCaster(Renderer LPCBHIEOFOB)
		{
		}

		public void AddShadowCaster(MeshRenderer LPCBHIEOFOB)
		{
		}

		public void AddShadowCaster(SkinnedMeshRenderer LPCBHIEOFOB)
		{
		}

		public void AddShadowCaster(Renderer LPCBHIEOFOB, int POPJPDOHHMD)
		{
		}

		public void AddShadowCaster(Renderer LPCBHIEOFOB, int[] HFEMPPIBLFN)
		{
		}

		public void AddShadowOnlyRenderer(Renderer LPCBHIEOFOB)
		{
		}

		public void RemoveShadowOnlyRenderer(Renderer LPCBHIEOFOB)
		{
		}

		public void RemoveShadowCaster(Renderer LPCBHIEOFOB)
		{
		}

		private void LOHELFLOHDJ(int GMEHLIHLGEH)
		{
		}

		private void BOJMHMPCMCD(int GMEHLIHLGEH)
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void CCDGHDACEHP()
		{
		}

		private void FMMJBBGGALK(Camera GAPPCJHIBEK)
		{
		}

		private void MJCGODGPOMI()
		{
		}

		private void LMHOGMEOAPA(Vector3 JECMGJFLJPB, Quaternion AFEKKLLPIFA, float GJCFPPBOPKO, float IFMFPCOEHLI, float MCANODKKJAM, out Matrix4x4 GGIKAHPNIGC, out Matrix4x4 PLDBLPENEIO)
		{
			GGIKAHPNIGC = default;
			PLDBLPENEIO = default;
		}

		private Rect OJGKANPEIIN()
		{
			return default;
		}

		private void MONNOIEKDCL()
		{
		}

		private void HGKNNLFOILH()
		{
		}

		private Bounds IAFAAGHKCHH()
		{
			return default;
		}

		private void GNDDNBOGOOH()
		{
		}

		private void FMKCPFEEADH()
		{
		}

		private void OECCLGGLOON()
		{
		}

		private void LEGHPPOMNBK()
		{
		}

		private void NLLPIKPLNBH()
		{
		}

		private Vector3 CBDFBAKIAEJ()
		{
			return default;
		}

		private void IBOLLAOMABA()
		{
		}

		private void BCALDIAEEEJ(int DNMMECEHEFC, bool BFDBCMGIOBG)
		{
		}

		private void FIFCLGHNPMH(int JAIOLGIBEEF, bool BFDBCMGIOBG)
		{
		}

		private void KDIGOCBMILK()
		{
		}
	}
}
