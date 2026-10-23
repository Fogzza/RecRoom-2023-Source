using System;
using System.Threading.Tasks;
using RecRoom.Core.Creation.Shapes;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class CurveControlPoint : CreationObjectControlPoint
	{
		[Flags]
		private enum CGIGDPGHMGO
		{
			None = 0,
			Move = 1,
			Rotate = 2,
			Translation = 4,
			Scale = 8
		}

		private const float JAHFAIGDFJO = 2.5f;

		private const float KBFIILHFPOF = 0.6f;

		private const float DLJFPDGOPPO = 0.8f;

		private const float ONLNKEGOOBD = 0.05f;

		private const float FHLBNAIPHAM = 0.1f;

		private const float LIFIOJEIOFK = 0.4f;

		private const float GHKHPGBHCDC = 90f;

		private CGIGDPGHMGO MLHPFDHGDIL;

		private BJIJHMNPDCH NGMIPPKLMCC;

		private ShapeContainer.LEIOBPHGMAO AHLCFJFHFEC;

		private int MNOFNLJDEKJ;

		[SerializeField]
		private MeshRenderer mesh;

		[SerializeField]
		private Transform root;

		[SerializeField]
		private Material normalMaterial;

		[SerializeField]
		private Material selectedMaterial;

		private float DCLBFIEEOAA;

		private float FKACEFODGPN;

public BJIJHMNPDCH Owner
{
get 		{
			return null;
		}

private set {
		}
}

public ShapeContainer.LEIOBPHGMAO CurveShape
{
get 		{
			return null;
		}

private set {
		}
}

public int Index
{
get 		{
			return 0;
		}

private set {
		}
}

public override bool IsLockedByRoomOwners
{
get 		{
			return false;
		}

}

public override bool IsLockedForLocalPlayer
{
get 		{
			return false;
		}

}

public override int DeleteSortValue
{
get 		{
			return 0;
		}

}

public float WorldScale
{
get 		{
			return 0f;
		}

}

		public override Bounds GetWorldBounds()
		{
			return default;
		}

		private void Awake()
		{
		}

		public void AssignPoint(BJIJHMNPDCH GCILADHGICM, ShapeContainer.LEIOBPHGMAO HOCECBDMJLO, int GMEHLIHLGEH, Guid JMIFIJDBMNM)
		{
		}

		private void OnDestroy()
		{
		}

		private void LateUpdate()
		{
		}

		private void IFFHCIPKAIE()
		{
		}

		private void IACGJGNMHHO()
		{
		}

		private void KPGCCFHADJB()
		{
		}

		private void BJBMALJKJJL()
		{
		}

		public override void OnHoverFinished(FBEHJNCKJPN CIMCLAFMGFE)
		{
		}

		public override void OnHoverStart(FBEHJNCKJPN CIMCLAFMGFE, Collider LPGAJGPGKFM)
		{
		}

		public override void OnDeselected()
		{
		}

		public override void OnSelected()
		{
		}

		public override void RenderOutline(LMKFOACECEG? IEMMIFODLAI)
		{
		}

		public override void OnTranslated()
		{
		}

		public override void OnRotated()
		{
		}

		public override void OnScaled()
		{
		}

		public override void OnMoveFinished()
		{
		}

		public override void OnMoveStart()
		{
		}

		public override void OnTranslationFinished()
		{
		}

		public override void OnTranslationStart()
		{
		}

		public override void OnScaleFinished()
		{
		}

		public override void OnScaleStart()
		{
		}

		public override void OnRotationFinished()
		{
		}

		public override void OnRotationStart()
		{
		}

		private void KAOKIJJHCHJ(CGIGDPGHMGO HDCJBCHGIOK)
		{
		}

		private void BHBFGGBBGED(CGIGDPGHMGO HDCJBCHGIOK)
		{
		}

		public override void SetTransformationDataForUndoRedo(Vector3? INLGLHIPOMC, Quaternion? HEGBBJCMANH, float? PDNBMOJFPKO, Vector3? IGMDHMAILAN)
		{
		}

		public override Task DeleteAsync()
		{
			return null;
		}

		public override FEAHDFKGCDD GetCreateControlPointUndoStep()
		{
			return null;
		}

		public override FEAHDFKGCDD GetDestroyControlPointUndoStep()
		{
			return null;
		}
	}
}
