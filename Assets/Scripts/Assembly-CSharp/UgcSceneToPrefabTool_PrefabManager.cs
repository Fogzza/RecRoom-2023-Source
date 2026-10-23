using RecRoom;
using RecRoom.Core.Rendering;
using UnityEngine;

[ExecuteInEditMode]
public class UgcSceneToPrefabTool_PrefabManager : MonoBehaviour
{
	public Light sun;

	public Material skybox;

	public SceneRenderingSettings sceneRenderingSettings;

	public EnvironmentLightingSettings envSettings;

	public FogSettings fogSettings;

	public Texture[] refProbeTextures;

	public ReflectionProbe[] refProbeObjects;

	private void Awake()
	{
	}
}
