using UnityEngine;

public class MainTextureOverride : MonoBehaviour
{
	[SerializeField]
	private Renderer renderer;

	[SerializeField]
	private Texture2D defaultTexture;

	[SerializeField]
	private Texture2D steamVrVive;

	[SerializeField]
	private Texture2D steamVrOculus;

	[SerializeField]
	private Texture2D steamVrMicrosoft;

	[SerializeField]
	private Texture2D oculusRift;

	[SerializeField]
	private Texture2D oculusQuest;

	[SerializeField]
	private Texture2D ps4Move;

	private void Start()
	{
	}
}
