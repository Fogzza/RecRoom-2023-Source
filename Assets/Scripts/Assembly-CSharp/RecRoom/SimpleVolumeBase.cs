using UnityEngine;

namespace RecRoom
{
	public abstract class SimpleVolumeBase : MonoBehaviour
	{
		[SerializeField]
		private new string name;

public abstract Vector3 WorldSpaceCenter
{
get ;
}

		public override string ToString()
		{
			return null;
		}

		public abstract bool ContainsPoint(Vector3 PDFEDMAOMNH);

		public abstract int OverlapTest(Collider[] ILJGHKGMILC, int MPJGCPAKKKA, QueryTriggerInteraction BAMJBELIHBB);

		public bool ContainsPhotonPlayer(CHILKDJABBF FBCDJHOIDJJ)
		{
			return false;
		}

		public bool ContainsPlayer(Player EKOFNPFCLMO)
		{
			return false;
		}
	}
}
