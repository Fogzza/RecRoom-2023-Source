using UnityEngine;

public class BulletinBoardVisualLayer : MonoBehaviour
{
	public enum KEGLNAKIAMC
	{
		Default = 0,
		LargeVideoPlayer = 1,
		LargeImageView = 2,
		Banned = 3,
		Warning = 4
	}

	public KEGLNAKIAMC Layer;

	private void Awake()
	{
	}
}
