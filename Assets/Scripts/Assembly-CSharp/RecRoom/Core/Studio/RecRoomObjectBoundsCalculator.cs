using UnityEngine;

namespace RecRoom.Core.Studio
{
	public class RecRoomObjectBoundsCalculator : MonoBehaviour
	{
		[SerializeField]
		private BoxCollider selectionBoundsOverride;

public BoxCollider SelectionBoundsOverride
{
get 		{
			return null;
		}

}

		private void Start()
		{
		}
	}
}
