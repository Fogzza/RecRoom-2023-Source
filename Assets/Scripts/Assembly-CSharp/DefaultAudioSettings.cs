using UnityEngine;

public class DefaultAudioSettings : SingletonMonoBehaviour<DefaultAudioSettings>
{
	[SerializeField]
	private DefaultAudioConfig configAsset;

public static DefaultAudioConfig ConfigAsset
{
get 	{
		return null;
	}

}
}
