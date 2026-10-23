using Photon.Pun;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public abstract class SandboxCircuitBeaconBase : MonoBehaviourPun
	{
		private MaterialPropertyBlock HOOJEGOGAPE;

		[SerializeField]
		protected MeshRenderer beamMesh;

		[SerializeField]
		private MeshRenderer baseMesh;

		[SerializeField]
		private float baseAlpha;

		[SerializeField]
		private float scanlineAlpha;

		[SerializeField]
		private float scanlineColorLighteningFactor;

		[SerializeField]
		protected SandboxColorable sandboxColorable;

		[SerializeField]
		private Tool tool;

public abstract float BeamHeight
{
get ;
}

public abstract bool BeamEnabled
{
get ;
}

		protected virtual void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void EIOBOFGDLDI()
		{
		}

		protected abstract void LIAFPENGDGP();

		protected void AIBDNLFFPIA()
		{
		}

		protected void DGONLKEOBHL()
		{
		}

		private void FKNMIJAKJEN(int JGFCLDGKBAO, out Color EBMCKJCOLFP, out Color HOAILAAFLCO)
		{
			EBMCKJCOLFP = default;
			HOAILAAFLCO = default;
		}

		protected void BCKGAGOBPCA(int JGFCLDGKBAO)
		{
		}
	}
}
