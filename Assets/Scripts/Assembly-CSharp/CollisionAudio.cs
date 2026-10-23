using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Core;
using UnityEngine;

public class CollisionAudio : MonoBehaviour
{
	private class FIOJCNJAJLG
	{
		public GameObject LNDKNKKNELC;

		public float IMFJEADNDLG;
	}

	[Serializable]
	public class AudioClipsToLayer
	{
		public enum HDNPAMBKCJL
		{
			SFX3D = 0,
			SFX2D = 1,
			TutorialVoiceOver = 2
		}

		public string Name;

		public HDNPAMBKCJL Type;

		public LayerMask Layers;

		public string Tag;

		public AnimationCurve velocityToVolumeCurve;

		public RecRoomAudioClip[] Clips;

		public float InstanceLimitDuration;

		public float? LastInstanceTime { get; set; }

		public bool IsStillOnCooldown => false;

		public bool CGFBDBCFIKJ(GameObject HKPJJHILEBG)
		{
			return false;
		}
	}

	private sealed class ODMCCFOEMED : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CollisionAudio _003C_003E4__this;

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
		public ODMCCFOEMED(int _003C_003E1__state)
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

	private const float FHMKEECJGAO = 25f;

	private float BIEJFAAAMCP;

	[SerializeField]
	private AudioClipsToLayer[] audioMappings;

	[SerializeField]
	private bool useCustomRolloff;

	[SerializeField]
	private AudioRolloff customRolloff;

	[SerializeField]
	private MeleeWeaponCollider[] meleeWeaponColliders;

	[SerializeField]
	private ProxyPhysicsCollision proxyPhysicsCollision;

	private List<FIOJCNJAJLG> NODMGDINDCG;

	private bool INNJNMNHAOE;

	private bool LHFCMMGLCOO;

	private bool CPKGBABABEO;

public bool IsMuted
{
get 	{
		return false;
	}

set {
	}
}

	private IEnumerator Start()
	{
		return null;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnCollisionEnter(Collision KDGCDLJEAMD)
	{
	}

	private void FixedUpdate()
	{
	}

	private void INAGMPJLFMH()
	{
	}

	private void IDKPEPGBAOB(MeleeWeaponCollider LLKCFCIIGOB, NGLCDIDOEMK BNFNJFKJEOA)
	{
	}

	private void MCADMCHDCEG(GameObject BOHGNJKBLGB, Vector3 OGEABPMOJJB, Vector3 PPAPLBAOIGF, Vector3 HCAOLLKLKIM)
	{
	}
}
