using RecRoom.Core;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	public class MakerPenHandle : MonoBehaviour
	{
		public enum KAAACAIMIBI
		{
			X = 0,
			Y = 1,
			Z = 2,
			XY = 3,
			XZ = 4,
			YZ = 5,
			XYZ = 6
		}

		public static global::HHOBPMOCKMJ<MakerPenHandle> HoverStarted;

		public static global::HHOBPMOCKMJ<MakerPenHandle> HoverEnded;

		private int CNOLPIFAMGC;

		private float NNOOGHBMEDM;

		private bool GFNHKHIFNOK;

		private bool HJNJJNFOKNK;

		private float PCHDPEELDJN;

		private static MakerPenHandle POBEILFDPMH;

		private bool CPFCDNNCHOB;

		private KAAACAIMIBI KNGCIJIKKOI;

public int Priority
{
get 		{
			return 0;
		}

set {
		}
}

public float LocalHandleSize
{
get 		{
			return 0f;
		}

set {
		}
}

public bool Interactive
{
get 		{
			return false;
		}

set {
		}
}

public bool AllowClicks
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool AllowIndirectHitClicks
{
get 		{
			return false;
		}

}

public virtual float StickyAngle
{
get 		{
			return 0f;
		}

set {
		}
}

protected MakerPenHandle NGFHNKENPLF
{
get 		{
			return null;
		}

}

public bool Hovered
{
get 		{
			return false;
		}

set {
		}
}

public KAAACAIMIBI Axis
{
get 		{
			return KAAACAIMIBI.X;
		}

set {
		}
}

		public virtual Vector3 GetHandleCollisionPos()
		{
			return default;
		}

		public virtual Vector3 GetLocalHandleOffset()
		{
			return default;
		}

		public float GetLocalHandleSize()
		{
			return 0f;
		}

		protected virtual void OnDestroy()
		{
		}

		public virtual bool RayCast(Ray HAAAJDJGEFF, ref float KEDBAELNJIE)
		{
			return false;
		}

		public virtual GJEAOEFGMJC CreateState<T>(global::FNLEEFFPAAJ<T> KFGAPPJMKEB, global::DDLEHONFEBP<T> LBDKKGGNBPP, global::BAIMOJOCJOK<T> FJEHNLGPHLA, CAMIJPMLKOA DJKLHEEIMEO, CreationController IJIAEDONGKE, Vector3 HJODBKHINKL)
		{
			return null;
		}

		public virtual void OnClicked<T>(global::FNLEEFFPAAJ<T> KFGAPPJMKEB, global::DDLEHONFEBP<T> LBDKKGGNBPP, global::BAIMOJOCJOK<T> FJEHNLGPHLA, CreationController IJIAEDONGKE)
		{
		}

		public virtual void ResetAnimation()
		{
		}
	}
}
