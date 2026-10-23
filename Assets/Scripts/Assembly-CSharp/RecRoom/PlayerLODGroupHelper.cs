using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom
{
	public class PlayerLODGroupHelper : MonoBehaviour
	{
		private sealed class OKCDCEPPGGK : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerLODGroupHelper _003C_003E4__this;

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
			public OKCDCEPPGGK(int _003C_003E1__state)
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

		private const int EIJCJDOGDNN = 10;

		[SerializeField]
		private LODGroup lodGroup;

		[SerializeField]
		private int maxOutfitLod;

		private Coroutine MBDMLFIPGIC;

		private LOD[] KPBFGIFOHDO;

		private List<Renderer>[] GFFNJAJLJJB;

		private bool BAIOLKPJDHF;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		public void AddOutfitRenderer(Renderer LPCBHIEOFOB)
		{
		}

		private void INPPNOACBMD()
		{
		}

		private IEnumerator COGKPHHCDIJ()
		{
			return null;
		}

		private void NKJEPIFAIHF()
		{
		}

		private void DAFDOCFGGNJ()
		{
		}
	}
}
