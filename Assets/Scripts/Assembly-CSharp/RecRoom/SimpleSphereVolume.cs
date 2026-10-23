using UnityEngine;

namespace RecRoom
{
	public class SimpleSphereVolume : SimpleVolumeBase
	{
		[SerializeField]
		private Vector3 center;

		[SerializeField]
		private float radius;

		private float CDOALGEOAOJ;

public override Vector3 WorldSpaceCenter
{
get 		{
			return default;
		}

}

public float WorldSpaceRadius
{
get 		{
			return 0f;
		}

}

		private void Awake()
		{
		}

		public override bool ContainsPoint(Vector3 PDFEDMAOMNH)
		{
			return false;
		}

		public override int OverlapTest(Collider[] ILJGHKGMILC, int MPJGCPAKKKA, QueryTriggerInteraction BAMJBELIHBB)
		{
			return 0;
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
