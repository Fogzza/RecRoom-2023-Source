using UnityEngine;

public class FakePlayerCollider : MonoBehaviour
{
	[SerializeField]
	protected Player.NBPIPAJOGLC bodyPart;

public Player.NBPIPAJOGLC BodyPart
{
get 	{
		return Player.NBPIPAJOGLC.Head;
	}

}
}
