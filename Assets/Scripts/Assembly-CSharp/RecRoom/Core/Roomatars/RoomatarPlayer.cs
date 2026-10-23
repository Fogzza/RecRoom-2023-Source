using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.Holotars;
using UnityEngine;

namespace RecRoom.Core.Roomatars
{
	public class RoomatarPlayer : MonoBehaviour
	{
		private sealed class DBEGEPNCHLA
		{
			public RoomatarPlayer _003C_003E4__this;

			public LKGILLBEJEK capturedPlayRoutine;

			internal void _003CStartPlaying_003Eb__0()
			{
			}
		}

		private sealed class AFGHCCBKGBC
		{
			public CreationManager.ALEFKNOEIAL spawnResult;

			public string spawnError;

			internal void _003CPlayRoutine_003Eb__2(CreationManager.ALEFKNOEIAL result)
			{
			}

			internal void _003CPlayRoutine_003Eb__3(string message)
			{
			}
		}

		private sealed class LAAIOBDKLNM : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public RoomatarPlayer _003C_003E4__this;

			private AFGHCCBKGBC _003C_003E8__1;

			private BLPAFKLBBCF.PKFOGHJLHNG.ILEMMLKCNFD[] _003CspawnableTemplateToolAnimations_003E5__2;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public LAAIOBDKLNM(int _003C_003E1__state)
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
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		protected HolotarPlaybackPuppet playbackPuppetPrefab;

		[SerializeField]
		protected TextAsset roomatarData;

		[SerializeField]
		protected bool forceToolPickupBeaconsOff;

		[SerializeField]
		protected float autoPlayDelay;

		private LKGILLBEJEK KGKBCDEONAP;

		private global::NCOKFFGPIJM<CreationManager.ALEFKNOEIAL> GMGNHBBIMDN;

		private float OGAHJDOOFGI;

		private float KPIJFNMFANE;

		private TextAsset LKJFECPEOAF;

		private BLPAFKLBBCF BPCEFNPGJDC;

		private readonly List<LABENHLPGDK> CNFGICBPPFK;

		private readonly List<GGOJEMLKEOC> DCDKBFIHDAC;

private bool AFMFFNMPDJK
{
get 		{
			return false;
		}

}

		protected void OnEnable()
		{
		}

		protected void OnDisable()
		{
		}

		protected void OnValidate()
		{
		}

		private void ENNMMBNHKKD()
		{
		}

		private void DHPAONNNCIM()
		{
		}

		private void PMEGMHMMBGL()
		{
		}

		private IEnumerator<EGGPGCCKPCO> LAKICMMEJCH()
		{
			return null;
		}

		[CompilerGenerated]
		private void KCPNLBCNLHC(CreationManager.ALEFKNOEIAL MJKJPIOJMID)
		{
		}

		[CompilerGenerated]
		private void KLEHFJFPBAA(string PEOLHGGDCPN)
		{
		}
	}
}
