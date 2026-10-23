using System;
using Photon.Pun;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Core
{
	public class SynchronizedHoldToInteractHandler : MonoBehaviourPun
	{
		private enum DCBMKNMDHBI
		{
			NOT_INTERACTED = 0,
			HOLDING_FOR_INTERACTION = 1,
			INTERACTED = 2
		}

		private static readonly int NHKLAHEBNEL;

		private static readonly int LJFPFDJDLCC;

		private const float ECPGAJBBBDD = 10f;

		[SerializeField]
		protected Animator animator;

		private bool ENMFHEGBPML;

		private bool JGCEDANDPGG;

		[SerializeField]
		private RecRoomAudioClip startHoldingAudio;

		[SerializeField]
		private RecRoomAudioClip holdingForInteractionAudio;

		[SerializeField]
		private RecRoomAudioClip interactionFinishedAudio;

		protected ONFFMHBFHEC BGBIFFLGANM;

		private SFXAudioSource JGCFEGNGAPI;

		private float AIOOALKJHFP;

		private float LICAENCDAJF;

		private global::MOBDJNEDDKC<float> BNMEEONEFNG;

		private PlayerHand MAPNHMHFJCB;

		private ILNJNAIHNJF.HAMLJAHAGPF FHCHKLHNDIE__BackingField;

		private ILNJNAIHNJF.HAMLJAHAGPF JHBHEFKBJAJ__BackingField;

		private Action DGBBODOAHAF__BackingField;

		private Action NCDDCAMDDGM__BackingField;

		private Action<bool> KIFPEBKPALM__BackingField;

		private Action EMKAPOJJPIM__BackingField;

public Animator Animator
{
get 		{
			return null;
		}

}

public bool NotInteracted
{
get 		{
			return false;
		}

}

public bool HoldingForInteraction
{
get 		{
			return false;
		}

}

public bool Interacted
{
get 		{
			return false;
		}

}

public float AuthorityUpdateRate
{
get 		{
			return 0f;
		}

set {
		}
}

public float NonAuthorityUpdateRate
{
get 		{
			return 0f;
		}

set {
		}
}

public float HoldProgress
{
get 		{
			return 0f;
		}

set {
		}
}

public PlayerHand InteractingHand
{
get 		{
			return null;
		}

private set {
		}
}

public event ILNJNAIHNJF.HAMLJAHAGPF OnUpdateNotInteractedStateEvent {
add {
		}
remove {
		}
}

public event ILNJNAIHNJF.HAMLJAHAGPF OnUpdateHoldingForInteractionStateEvent {
add {
		}
remove {
		}
}

public event Action EnteredNotInteractedState {
add {
		}
remove {
		}
}

public event Action EnteredHoldingForInteractionState {
add {
		}
remove {
		}
}

public event Action<bool> ExitedHoldingForInteractionState {
add {
		}
remove {
		}
}

public event Action EnteredInteractedState {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		public void AuthorityStartInteracting(PlayerHand KOMMPCGEMAP)
		{
		}

		public void AuthorityFinishInteracting()
		{
		}

		public void AuthorityReset()
		{
		}

		private void HLJLPACDCDK(ushort MEHPPOKJBGM, ushort PHJCBBKLFME)
		{
		}

		private void AMJJIJFMIOL(ushort MEHPPOKJBGM, ushort PHJCBBKLFME)
		{
		}

		private void NFBAHFGIDLJ(ushort DBMCLBLGGJG, ushort FGIFDHEDJHL)
		{
		}

		private void OOMDAJLOIFC()
		{
		}

		private void NBFBFPGIPAN(ushort MEHPPOKJBGM, ushort PHJCBBKLFME)
		{
		}

		private void DDBKCEGPFAL()
		{
		}

		private void OONMPDIPLNH()
		{
		}

		private void BLPOPKEDADI()
		{
		}
	}
}
