using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.AGUI.Expresso
{
	public class ExpressoButtonSpawner : ExpressoButtonSpawner<ExpressoButton>
	{
	}
	public class ExpressoButtonSpawner<T> : PrefabSpawner<T> where T : ExpressoButton
	{
		public MeshRenderer proxyMeshRenderer;

		public bool resizeTrigger;

		public bool CloseMenuOnInteraction;

		public ExpressoButton.ExpressoButtonInteraction OnInteractionEnter;

		public ExpressoButton.ExpressoButtonInteraction OnInteractionStay;

		public ExpressoButton.ExpressoButtonInteraction OnInteractionExit;

		public ExpressoButton.ExpressoButtonInteraction OnButtonActivated;

		public ExpressoButton.ExpressoButtonInteraction OnButtonDeactivated;

		public Sprite iconSprite;

		public string labelText;

		public float exitAnimationDuration;

		public string interactionNotification;

		public Material visualVolumeOverwrite;

		public RecRoomAudioClip EnterAudio;

		public RecRoomAudioClip StayAudio;

		public RecRoomAudioClip ExitAudio;

		protected override void BMICBPLMKDN()
		{
		}

		protected override void Awake()
		{
		}
	}
}
