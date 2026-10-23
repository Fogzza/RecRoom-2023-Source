using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace RecRoom.Core.Rendering
{
	public sealed class WorldFadeRendererEffect : CommandBufferRendererEffect<byte, WorldFadeRendererEffect>
	{
		private const int OKKMPFILNEJ = 128;

		private static Material GPPCHIIIMDB;

		private static Material HCEPPLOAJAM;

		private static Material MKBGFDDKMGB;

		private static readonly JJBOMPKOMPB FJACCNPGBJL;

protected override JJBOMPKOMPB LFDFCNKLPMN
{
get 		{
			return null;
		}

}

public override string BufferName
{
get 		{
			return null;
		}

}

protected override bool GGGGBKEFNJA
{
get 		{
			return false;
		}

}

protected override CameraEvent PEPGNCFJNOK
{
get 		{
			return CameraEvent.BeforeDepthTexture;
		}

}

protected override bool LNBEGMNPDCK
{
get 		{
			return false;
		}

}

public override bool RequiresOpaqueTexture
{
get 		{
			return false;
		}

}

		public static void SetMaterials(WorldFadeMaterialsConfig CGDFGHPCLIA)
		{
		}

		protected override void KLNJBOIGDOA()
		{
		}

		public static void RenderCornerMoveMask(Renderer LPCBHIEOFOB, int FIKBGLGGDGP = 1)
		{
		}

		public static void RenderMask(Renderer LPCBHIEOFOB, int FIKBGLGGDGP = 1, EKEODDHDLIH EIAEOGBOPKM = EKEODDHDLIH.RENDER_WHEN_ENABLED)
		{
		}

		private static void PJNDGPFKIIJ(Renderer LPCBHIEOFOB, Material DJCJPMCMKIP, int FIKBGLGGDGP, EKEODDHDLIH EIAEOGBOPKM = EKEODDHDLIH.RENDER_WHEN_ENABLED)
		{
		}

		public static void RenderMaskForTool(Tool IEGMBEPJMGC)
		{
		}

		public static void RenderFirstPersonMask()
		{
		}

		public static bool ShouldRenderImageEffect()
		{
			return false;
		}

		protected override void LEPEMCAADPD(CommandBuffer DLPDGBIHCIK, ScriptableRenderContext DELCOFCGDFF, ref RenderingData NFDHHMBJELE)
		{
		}
	}
}
