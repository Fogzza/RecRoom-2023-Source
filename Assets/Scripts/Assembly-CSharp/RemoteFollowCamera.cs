using System;
using UnityEngine;

public class RemoteFollowCamera : MonoBehaviour
{
	[Serializable]
	public class PlacementOffset
	{
		public Vector3 position;

		[SerializeField]
		private Vector3 rotationEuler;

		private Quaternion? _rotation;

		public Quaternion rotation => default;
	}

	public enum BLGACNDFEFP
	{
		None = 0,
		Default = 1,
		ThirdPerson = 2,
		BirdsEye = 3
	}

	[SerializeField]
	private Transform targetTransform;

	[SerializeField]
	private Camera camera;

	[SerializeField]
	private float positionSmoothingTime;

	[SerializeField]
	private float rotationSmoothingTime;

	[SerializeField]
	private BLGACNDFEFP currentFollowMode;

	[SerializeField]
	private PlacementOffset thirdPersonPlacementOffset;

	[SerializeField]
	private PlacementOffset birdsEyePlacementOffset;

	private Vector3 OIEPDFJCEHE;

	private Vector3 INAAEPEFNIM;

	private Vector3 NNAJOEJONDJ;

	private Quaternion AAHOBDFJLPB;

	private Vector3 OOBHCHIDJCN;

	private Quaternion MAGICGBMDLK;

public Camera Camera
{
get 	{
		return null;
	}

}

public BLGACNDFEFP CurrentFollowMode
{
get 	{
		return BLGACNDFEFP.None;
	}

}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void LateUpdate()
	{
	}

	public BLGACNDFEFP CycleFollowMode()
	{
		return BLGACNDFEFP.None;
	}
}
