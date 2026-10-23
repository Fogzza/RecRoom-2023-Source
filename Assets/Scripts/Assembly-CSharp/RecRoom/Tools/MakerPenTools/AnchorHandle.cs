using System;
using RecRoom.Core;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	public class AnchorHandle : MakerPenMeshHandle
	{
		[SerializeField]
		private Transform visualRoot;

		[SerializeField]
		private float screenSize;

		[SerializeField]
		private float hoverSize;

		[SerializeField]
		private float interactionSize;

		[SerializeField]
		private Color backColor;

		[SerializeField]
		public float MaxLOD_Size;

		public EGCMHLJMADG Type;

		private float LNHHAGBPHNM;

		private Vector3 NPGPFLMIFPE;

		private Color JKAGJNEGKBB;

		private float[] CCEHPLAFKNE;

		private Func<AnchorHandle, GJEAOEFGMJC> LGIBBHPMAHG;

		private Action<AnchorHandle> LGOOBHLMGFH;

public override bool AllowIndirectHitClicks
{
get 		{
			return false;
		}

}

public override float StickyAngle
{
get 		{
			return 0f;
		}

}

public float MaxWorldSize
{
get 		{
			return 0f;
		}

set {
		}
}

public bool IsCenter
{
get 		{
			return false;
		}

}

public Vector3 Offset
{
get 		{
			return default;
		}

private set {
		}
}

		public bool IsVisible(float[] GEGMNBPCCKN)
		{
			return false;
		}

		private bool LAPFLNJOMMB(Vector3 KNGAEDPENOJ)
		{
			return false;
		}

		public void Initialize(Func<AnchorHandle, GJEAOEFGMJC> OOCMJGCBEOP, Action<AnchorHandle> HPDOGGHJDDM)
		{
		}

		protected void Update()
		{
		}

		public override GJEAOEFGMJC CreateState<T>(global::FNLEEFFPAAJ<T> KFGAPPJMKEB, global::DDLEHONFEBP<T> LBDKKGGNBPP, global::BAIMOJOCJOK<T> FJEHNLGPHLA, CAMIJPMLKOA DJKLHEEIMEO, CreationController IJIAEDONGKE, Vector3 HJODBKHINKL)
		{
			return null;
		}

		public override void OnClicked<T>(global::FNLEEFFPAAJ<T> KFGAPPJMKEB, global::DDLEHONFEBP<T> LBDKKGGNBPP, global::BAIMOJOCJOK<T> FJEHNLGPHLA, CreationController IJIAEDONGKE)
		{
		}
	}
}
