using System;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Consumable;
using UnityEngine;

namespace RecRoom
{
	public class EdibleItem : MonoBehaviourPun
	{
		[SerializeField]
		private Tool tool;

		[SerializeField]
		private BreakableObject breakableObject;

		[SerializeField]
		private float minBiteInterval;

		[SerializeField]
		private GameObject[] visualsAfterEachBite;

		[SerializeField]
		private bool isLastPieceNonEdible;

		[SerializeField]
		private bool destroyFinalPieceOnCollision;

		[SerializeField]
		private RecRoomAudioClip[] biteAudioClips;

		[SerializeField]
		private AudioRolloff audioRolloff;

		[SerializeField]
		private ParticleSystem[] biteParticles;

		[NonSerialized]
		public bool SupportsAutomaticEating;

		[SerializeField]
		public Transform eatPositionOverride;

		[SerializeField]
		private float minDistanceFromHeadSq;

		private float KLOCPPGJMKK;

		private bool HOCFFNMCCJJ;

		private global::MOBDJNEDDKC<int> PHEDKOIJIPO;

		private global::MOBDJNEDDKC<string> NNDNDJAPMEK;

		private global::MOBDJNEDDKC<string> OCEJFLHACGO;

private int ICLLLJHIPPO
{
get 		{
			return 0;
		}

set {
		}
}

private string LANPLMLJMPJ
{
get 		{
			return null;
		}

set {
		}
}

private string LJNKEPIHFJF
{
get 		{
			return null;
		}

set {
		}
}

		public void AuthorityTakeBite()
		{
		}

		public void SetConsumableInfo(ConsumableInfo AKOKILEPANJ)
		{
		}

		public bool IsLastBite()
		{
			return false;
		}

		protected override void Awake()
		{
		}

		protected void Start()
		{
		}

		private void OnTriggerStay(Collider PAKCCEOOEJB)
		{
		}

		private void CNDKEJICODE()
		{
		}

		private void OnCollisionEnter(Collision KDGCDLJEAMD)
		{
		}

		private void NIELJMNCAHE(bool KBOBBDBAAMB)
		{
		}
	}
}
