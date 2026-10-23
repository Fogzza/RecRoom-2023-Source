using System.Collections.Generic;
using RecRoom.Core.Controllers.ScreenBehaviors;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace RecRoom.Core.Rendering
{
	public class PIPRenderToTexture : MonoBehaviour
	{
		private struct HCIOCPKBCAE
		{
			public Material LJDLKAAOHDN;

			public Renderer CDLDAEEIHLI;

			public int PEAPBNFJIJO;
		}

		private BDKPCAJPNKO NEIEDNEBECJ;

		private Camera JMJLBBFMIHD;

		private PictureInPictureScreenPlayerBehaviorConfig HKGBPHDIKOI;

		private List<Renderer> LJLOOKMANHC;

		private List<HCIOCPKBCAE> NPIABEDHANM;

		private List<ParticleSystemRenderer> ELIBKMOOKPO;

		private Dictionary<Renderer, Material[]> BODIBGFLIKL;

public bool ReadyToBeRendered
{
get 		{
			return false;
		}

}

public RenderTexture TargetRenderTexture
{
get 		{
			return null;
		}

}

public ComputeShader ComputeBufferTransfer
{
set {
		}
}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void PreRender(Camera HNPGFMPMGFH, PictureInPictureScreenPlayerBehaviorConfig FPJKGKBOAOA, List<Renderer> KJJMMGMBOFO, List<ParticleSystemRenderer> FBCLLODFGNJ)
		{
		}

		public void Execute(ScriptableRenderContext DELCOFCGDFF, ref RenderingData NFDHHMBJELE)
		{
		}

		private void IOMPLFNIMBD(CommandBuffer DLPDGBIHCIK, ref ScriptableRenderContext DELCOFCGDFF)
		{
		}

		private void OLMLNFIHBED(CommandBuffer DLPDGBIHCIK, ref ScriptableRenderContext DELCOFCGDFF, ref RenderingData NFDHHMBJELE)
		{
		}

		private void KGJDNHKMIDC(CommandBuffer DLPDGBIHCIK, ref ScriptableRenderContext DELCOFCGDFF, ref RenderingData NFDHHMBJELE)
		{
		}

		private void ODCBENKFBLH()
		{
		}

		private void AAAFMAMFEMI()
		{
		}

		private static int GMLLKGOGPAD(HCIOCPKBCAE NNMPJECKECI, HCIOCPKBCAE EFNJCAIBDLA)
		{
			return 0;
		}
	}
}
