using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

public class Basketball : Ball
{
	private sealed class AJLEAGDHKIM : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector3 loc;

		private float _003Ct_003E5__2;

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
		public AJLEAGDHKIM(int _003C_003E1__state)
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

	public ParticleSystem FireTrail;

	public PooledParticle PassedRimParticle;

	public RecRoomAudioClip PassedRimAudio;

	private bool JGJCFFDKGPA;

	private Vector3 NHOBMPCJLCJ;

	private string MMBDDFKPKDB;

	private Player LKDEOABGACP;

public bool HasShooter
{
get 	{
		return false;
	}

private set {
	}
}

public Vector3 LastShotLocation
{
get 	{
		return default;
	}

private set {
	}
}

public string LastShooterName
{
get 	{
		return null;
	}

private set {
	}
}

public Player ShootingPlayer
{
get 	{
		return null;
	}

private set {
	}
}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void PassedRim(BasketballRim LHPBMBICINO)
	{
	}

	private IEnumerator LOMHGEBOJJF(Vector3 LPHJBAFNMIC)
	{
		return null;
	}

	private void NHIPGCIBDAD()
	{
	}

	private void BKMEGCENOGH(Tool IEGMBEPJMGC)
	{
	}
}
