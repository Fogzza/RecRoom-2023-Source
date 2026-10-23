using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class ConfigurableCollider : MonoBehaviour
	{
		public enum KKJDGDLNIGG
		{
			Environment = 0,
			Decoration = 1,
			Physical = 2
		}

		private const string NNKIPIEBCKF = "ConfigurableCollider";

		[SerializeField]
		private Collider collider;

		[SerializeField]
		private KKJDGDLNIGG physicsMode;

		[SerializeField]
		private RigidbodyEx rigidbodyEx;

		[SerializeField]
		private Tool tool;

public Collider Collider
{
get 		{
			return null;
		}

}

public KKJDGDLNIGG Type
{
get 		{
			return KKJDGDLNIGG.Environment;
		}

}

		private void OnEnable()
		{
		}
	}
}
