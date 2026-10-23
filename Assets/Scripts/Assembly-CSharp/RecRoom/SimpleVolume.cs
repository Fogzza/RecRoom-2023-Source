using UnityEngine;

namespace RecRoom
{
	public class SimpleVolume : SimpleVolumeBase
	{
		[SerializeField]
		private Vector3 center;

		[SerializeField]
		private Vector3 localSize;

		public bool DrawSolidGizmos;

public Vector3 LocalCenter
{
get 		{
			return default;
		}

set {
		}
}

public Vector3 LocalSize
{
get 		{
			return default;
		}

set {
		}
}

public override Vector3 WorldSpaceCenter
{
get 		{
			return default;
		}

}

public Vector3 WorldSpaceSize
{
get 		{
			return default;
		}

}

		public override bool ContainsPoint(Vector3 PDFEDMAOMNH)
		{
			return false;
		}

		public bool ContainsPoint(Vector3 PDFEDMAOMNH, Vector3 GOGMOMIKKNL, Vector3 HEFKIIAGIHO)
		{
			return false;
		}

		public override int OverlapTest(Collider[] ILJGHKGMILC, int MPJGCPAKKKA, QueryTriggerInteraction BAMJBELIHBB)
		{
			return 0;
		}

		protected virtual void OnDrawGizmosSelected()
		{
		}
	}
}
