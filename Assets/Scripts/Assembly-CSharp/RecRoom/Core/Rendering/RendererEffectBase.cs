using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace RecRoom.Core.Rendering
{
	public abstract class RendererEffectBase<T, U> : PerCameraRenderEffect where U : RendererEffectBase<T, U>
	{
		protected struct AGEKDMMLCEP
		{
			public Renderer CDLDAEEIHLI;

			public IReadOnlyList<Camera> PFKHMMAMFMD;

			public T PLFALCECDIM;
		}

		protected class JJBOMPKOMPB
		{
			public delegate bool PIJGMPHIBIO(T PDPPJGDIJOE, T DJEFCGHGEKL);

			private List<AGEKDMMLCEP> KJJMMGMBOFO;

			private HashSet<Renderer> KNABCECOOAE;

			private bool KIMAGLMPCHB;

public int EPBJKODLMLB
{
get 			{
				return 0;
			}

}

public int BPIIJGBNBGB
{
get 			{
				return 0;
			}

}

public bool DNEDGCNOCCA
{
get 			{
				return false;
			}

private set {
			}
}

			// C# has no syntax for parameterized property 'POFBPBHJKPE'.
			public AGEKDMMLCEP get_POFBPBHJKPE(int FDAIMOMOHIG)
			{
				return PGNPFMMCBMF(FDAIMOMOHIG);
			}

			public AGEKDMMLCEP PGNPFMMCBMF(int FDAIMOMOHIG)
			{
				return default;
			}

			public JJBOMPKOMPB(int FAPOEIDOLFP, bool JBNDKLOGAOI = false)
			{
			}

			public bool IHBPACPAOAE(Renderer LPCBHIEOFOB, T PCPEJHIMHJJ, IReadOnlyList<Camera> GPODDNLCBNL = null, bool EEBGANHCFHP = false)
			{
				return false;
			}

			public bool MKPLNNOCFFG(Renderer LPCBHIEOFOB, T DJEFCGHGEKL, PIJGMPHIBIO AEJPNIOFPEL = null)
			{
				return false;
			}

			public void GLBPPAIACJF()
			{
			}

			public void BFGJAOCGAGD(Comparison<AGEKDMMLCEP> JBCFCKGMMHO)
			{
			}
		}

		protected class NKCONLEMIFP
		{
			private Renderer LHLFGCOGOGE;

			private MaterialPropertyBlock HOOJEGOGAPE;

			private bool GIIAJANJGIE;

public bool CHIFEIABJCE
{
get 			{
				return false;
			}

private set {
			}
}

public MaterialPropertyBlock GFHEANALBCP
{
get 			{
				return null;
			}

}

			public void PBLLDJKLCPL(Renderer LPCBHIEOFOB)
			{
			}

			public void AIBNAJGOJIH()
			{
			}
		}

		private sealed class EJHIEFBLCFI
		{
			public RendererEffectBase<T, U> _003C_003E4__this;

			public NKCONLEMIFP[] prevArray;

			public int capacity;

			internal object _003CAllocateCachedMaterialPropertyBlocks_003Eb__0()
			{
				return null;
			}
		}

		private static MaterialPropertyBlock FFJMIFGCCEC;

		private static NKCONLEMIFP[] FJLENKDCDCI;

		protected Camera FFKFDLHBGKF;

		private bool PHBIHODBCCG;

protected abstract JJBOMPKOMPB LFDFCNKLPMN
{
get ;
}

protected virtual bool GGGGBKEFNJA
{
get 		{
			return false;
		}

}

protected virtual bool LNBEGMNPDCK
{
get 		{
			return false;
		}

}

protected bool KKKHNMGIFMF
{
get 		{
			return false;
		}

private set {
		}
}

		protected abstract void KLNJBOIGDOA();

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		public sealed override void RenderPass(CommandBuffer DLPDGBIHCIK, ScriptableRenderContext DELCOFCGDFF, ref RenderingData NFDHHMBJELE)
		{
		}

		protected virtual void LEPEMCAADPD(CommandBuffer DLPDGBIHCIK, ScriptableRenderContext DELCOFCGDFF, ref RenderingData NFDHHMBJELE)
		{
		}

		private void EMEIHHEMJIN(ScriptableRenderContext DELCOFCGDFF, Camera GAPPCJHIBEK)
		{
		}

		protected virtual bool FOKDGMFEKAG(AGEKDMMLCEP EKNALAIJINI)
		{
			return false;
		}

		private bool BEIAJOLBGNJ(AGEKDMMLCEP CMDPMJBEBAB)
		{
			return false;
		}

		protected virtual void FGAONLCMEDL(AGEKDMMLCEP CMDPMJBEBAB, ref MaterialPropertyBlock CCJNODPJDNN)
		{
		}

		private void POOALGBMFDD()
		{
		}

		protected void NIDBGLJNGMI()
		{
		}

		protected abstract void DCPKGHCIFNC(AGEKDMMLCEP EKNALAIJINI);

		protected virtual void BEIOCKDCEGG()
		{
		}

		protected bool LJIPOMFGJPJ(int JBMLCLNDGFF)
		{
			return false;
		}

		protected void CFKNNIFOFIC(int FAPOEIDOLFP)
		{
		}
	}
}
