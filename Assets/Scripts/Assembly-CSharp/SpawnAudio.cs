using RecRoom.Audio;
using UnityEngine;

public class SpawnAudio : MonoBehaviour
{
	[SerializeField]
	private RecRoomAudioClip startAudio;

	[SerializeField]
	private RecRoomAudioClip destroyAudio;

	[SerializeField]
	private bool is3DSFX;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}
}
