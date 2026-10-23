using System;
using RecRoom.Avatars;
using RecRoom.Avatars.Outfit;
using UnityEngine;

[SelectionBase]
public class PlayerDisplayPoser : MonoBehaviour
{
	[Serializable]
	public class HandState
	{
		public float OpenClose;

		public bool ThumbsUpActive;

		public PlayerAvatarDisplay.LMIHKAEHAPA HandVisualState;
	}

	[SerializeField]
	private PlayerAvatarDisplay playerAvatarDisplay;

	public Transform Head;

	public Transform Torso;

	public Transform LeftHand;

	public Transform RightHand;

	public HandState LeftHandState;

	public HandState RightHandState;

	public OutfitPrefab hairPrefab;

	public OutfitPrefab hatPrefab;

	public OutfitPrefab HeadAccessory;

	public OutfitPrefab torsoPrefab;

	public OutfitPrefab accessoryPrefab;

	public OutfitPrefab LeftGlove;

	public OutfitPrefab RightGlove;

public PlayerAvatarDisplay PlayerAvatarDisplay
{
get 	{
		return null;
	}

}

	private void Awake()
	{
	}
}
