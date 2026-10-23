using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom
{
	[DisallowMultipleComponent]
	public class AnimateInOut : MonoBehaviour
	{
		private sealed class BDHCOLJOKIJ : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AnimateInOut _003C_003E4__this;

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
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public BDHCOLJOKIJ(int _003C_003E1__state)
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

		private const float NCEJFHBDODG = 0.2f;

		private static readonly List<Renderer> FNBPDJLLNMA;

		[SerializeField]
		private PooledParticle effectPrefab;

		[SerializeField]
		private Transform boundsRendererRoot;

		[SerializeField]
		private List<Renderer> ignoredRenderers;

		[SerializeField]
		private SimpleVolume boundingVolume;

		[SerializeField]
		private float animInStartOffset;

		[SerializeField]
		private float animOutStartOffset;

		public bool SupportsAnimateIn;

		public bool SupportsAnimateOut;

		public bool SuppressAnimation;

		private PooledParticle LNFEKLMNKAB;

		private bool PNEHCGFFGFO;

		private Renderer[] KJJMMGMBOFO;

		private bool LPOOJLHHGGJ;

private bool BLDMBOPFINP
{
get 		{
			return false;
		}

}

private bool GHNDJBBPCIB
{
get 		{
			return false;
		}

}

public List<Renderer> IgnoredRenderers
{
get 		{
			return null;
		}

}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void MKEHDKMALJN()
		{
		}

		private void OnDisable()
		{
		}

		public void WarmUp(int ANBIMKAPPGP = 1)
		{
		}

		public void PlayEffect(bool NLEOLDJOANA, Vector3? INLGLHIPOMC = null, Quaternion? HEGBBJCMANH = null, bool DGMMGMMCBPM = false)
		{
		}

		private void IJJPHJMCGID(PooledParticle IKPJEGICCBD, bool NLEOLDJOANA)
		{
		}

		private IEnumerator KCCMHPFCODJ(bool NLEOLDJOANA)
		{
			return null;
		}

		public void StopEffect()
		{
		}

		private void EHNIFCADIIB(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
		{
		}

		public bool GetEffectBounds(out Bounds DBPFJELGIGI)
		{
			DBPFJELGIGI = default;
			return false;
		}

		private void HLFOJANIDLA(Transform FGNGGLFNLIP, List<Renderer> KJJMMGMBOFO)
		{
		}

		[CompilerGenerated]
		private bool NEGCGBDAPPI(Renderer GOJCEBCMFJK)
		{
			return false;
		}
	}
}
