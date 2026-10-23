using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

public class GameReviveHandshakeFeedback : MonoBehaviour
{
	private sealed class MBJGLOAPGAM : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GameReviveHandshakeFeedback _003C_003E4__this;

		public CHILKDJABBF revivingPlayer;

		public PlayerHand revivingHand;

		public PlayerHand revivedHand;

		public float duration;

		private float _003CendTime_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public MBJGLOAPGAM(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private PooledParticle particlesPrefab;

	[SerializeField]
	private RecRoomAudioClip loopingAudioClip;

	[SerializeField]
	private float almostFinishedTimeRemaining;

	[SerializeField]
	private RecRoomAudioClip almostFinishAudioClip;

	private CHILKDJABBF PDLLHIIGELF;

	private PlayerHand JICBLAODMPP;

	private PlayerHand BNGFJPIEFGN;

	private Coroutine JMJCGJECGLG;

	private PooledParticle PHIBMFLAKPA;

	private SFXAudioSource JGCFEGNGAPI;

	private SFXAudioSource HIDIGKBIHGG;

public CHILKDJABBF RevivingPlayer
{
get 	{
		return null;
	}

private set {
	}
}

	private void OnDestroy()
	{
	}

	public void StartRunning(CHILKDJABBF OOJOIFKCDLH, PlayerHand JICBLAODMPP, PlayerHand BNGFJPIEFGN, float FGBPJMKCMAO)
	{
	}

	public void Release()
	{
	}

	private void BGEDMNCGCIB(CHILKDJABBF OOJOIFKCDLH, PlayerHand JICBLAODMPP, PlayerHand BNGFJPIEFGN, float FGBPJMKCMAO)
	{
	}

	private void MCNOIGCAIDI()
	{
	}

	private void ACJPKMEBDOP(Vector3 PDFEDMAOMNH, float FGBPJMKCMAO)
	{
	}

	private void FDDMDHJNCAD()
	{
	}

	private IEnumerator PBBMPKIDCMO(CHILKDJABBF OOJOIFKCDLH, PlayerHand JICBLAODMPP, PlayerHand BNGFJPIEFGN, float FGBPJMKCMAO)
	{
		return null;
	}

	private void LMGOIFENPBM()
	{
	}

	private void IOGEHKOCFLO()
	{
	}

	private void NBKAJJMJKFC()
	{
	}

	private Vector3 ELIKBMOGLEJ()
	{
		return default;
	}
}
