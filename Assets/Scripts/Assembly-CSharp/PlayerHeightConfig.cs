using UnityEngine;

public class PlayerHeightConfig : ScriptableObject
{
	public const float PLAYER_HEIGHT_DEFAULT = 1.74f;

	public const float PLAYER_CROWN_OF_HEAD_HEIGHT = 0.14f;

	private static readonly Vector3 PLAYER_CROWN_OF_HEAD_OFFSET;

	[SerializeField]
	private float minHeight;

	[SerializeField]
	private float maxHeight;

	[SerializeField]
	private float wingspanToHeightRatio;

	[SerializeField]
	private float maxWingspanToTrust;

	[SerializeField]
	private float handToHeadLeashLength;

	public float MinHeight => 0f;

	public float MaxHeight => 0f;

	public float WingspanToHeightRatio => 0f;

	public float MaxWingspanToTrust => 0f;

	public float HandToHeadLeashLength => 0f;

	public static Vector3 LPHKKNDHNAF(Transform CEJJKGMIIPA)
	{
		return default;
	}

	public float HGPCMDCOOGH(float BICGJAOHKIJ)
	{
		return 0f;
	}
}
