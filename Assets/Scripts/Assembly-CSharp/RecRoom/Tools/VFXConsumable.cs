using System;
using Photon.Pun;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Tools
{
	public class VFXConsumable : MonoBehaviourPun
	{
		private enum MDPPJMIEPOO
		{
			Deployed = 0,
			Active = 1,
			Finished = 2
		}

		[SerializeField]
		private float duration;

		[SerializeField]
		private string activeAnimationName;

		[SerializeField]
		private Tool tool;

		private SFXAudioSource HLEIBALFCNF;

		[SerializeField]
		private RecRoomAudioClip vfxStartClip;

		[SerializeField]
		private RecRoomAudioClip vfxActiveClip;

		[SerializeField]
		private RecRoomAudioClip vfxFinishClip;

		[SerializeField]
		private AudioRolloff audioRolloff;

		private global::MOBDJNEDDKC<bool> NEELFMLKOFH;

		private global::MOBDJNEDDKC<bool> HFPCFDKHLEG;

		private float EBLLIMOBJKB;

		private global::MOBDJNEDDKC<float> NDEFDKILHEM;

		private IDisposable MHDDFJJOCJK;

		private JOJOABLFOBA BGBIFFLGANM;

		private Animator BJBMJJOPBJD;

public bool Activated
{
get 		{
			return false;
		}

set {
		}
}

private bool LCJJFDCAJPF
{
get 		{
			return false;
		}

set {
		}
}

public float NormalizedAnimTime
{
get 		{
			return 0f;
		}

set {
		}
}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void POCNBHIAIJI(int KOADGMIKBAB = 0)
		{
		}

		private void NEJEICHBPFJ()
		{
		}

		private void FFDDNNHLIEH(Tool IEGMBEPJMGC)
		{
		}

		private void JJGKILLDMPK(float OKBAJEAPIHG)
		{
		}

		private void LAMPMJCBMMI(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void DCFJEJFKBII()
		{
		}

		private void HBMMOCHNGJD(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void OnCollisionEnter(Collision KDGCDLJEAMD)
		{
		}

		private void AEKFCJOHAHC()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
