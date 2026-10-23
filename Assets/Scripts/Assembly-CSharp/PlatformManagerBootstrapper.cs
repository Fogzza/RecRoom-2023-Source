using RecRoom.Platforms;
using UnityEngine;

public class PlatformManagerBootstrapper : MonoBehaviour
{
	private const int NMJHJIDADJI = 16;

	[SerializeField]
	private PlatformManager steamPlatformPrefab;

	[SerializeField]
	private PlatformManager oculusPlatformPrefab;

	[SerializeField]
	private PlatformManager ps4PlatformPrefab;

	[SerializeField]
	private PlatformManager playstationPlatformPrefab;

	[SerializeField]
	private PlatformManager iosPlatformPrefab;

	[SerializeField]
	private PlatformManager xboxPlatformPrefab;

	[SerializeField]
	private PlatformManager windowsPlatformlessPlatformPrefab;

	[SerializeField]
	private PlatformManager googlePlayPlatformPrefab;

	[SerializeField]
	private PlatformManager picoPlatformPrefab;

	[SerializeField]
	private MockVRDeviceManager mockVRDeviceManager;

	private static bool MCNCOBAGLDN;

	static PlatformManagerBootstrapper()
	{
	}

	private void Awake()
	{
	}
}
