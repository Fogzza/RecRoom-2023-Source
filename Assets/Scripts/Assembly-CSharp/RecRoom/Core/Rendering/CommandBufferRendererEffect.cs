using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace RecRoom.Core.Rendering
{
	public abstract class CommandBufferRendererEffect<T, U> : RendererEffectBase<CommandBufferRendererEffect<T, U>.ONCLNMEDCAM, U> where U : CommandBufferRendererEffect<T, U>
	{
		public enum EKEODDHDLIH
		{
			RENDER_WHEN_ENABLED = 0,
			ALWAYS_RENDER = 1,
			DO_NOT_RENDER = 2
		}

		public struct ONCLNMEDCAM
		{
			public Material LJDLKAAOHDN;

			public int CAJHKLDEKCM;

			public int NBMDANEOPGP;

			public int KALALOABEAE;

			public EKEODDHDLIH MPPDGAMCNMJ;

			public T LHCPOAANKCM;
		}

		private CommandBuffer OGEGKBIDLAD;

protected virtual CameraEvent PEPGNCFJNOK
{
get 		{
			return CameraEvent.BeforeDepthTexture;
		}

}

		protected override void LEPEMCAADPD(CommandBuffer FKAHEDPPANP, ScriptableRenderContext DELCOFCGDFF, ref RenderingData NFDHHMBJELE)
		{
		}

		protected override void DCPKGHCIFNC(AGEKDMMLCEP EKNALAIJINI)
		{
		}

		protected override bool FOKDGMFEKAG(AGEKDMMLCEP EKNALAIJINI)
		{
			return false;
		}
	}
}
