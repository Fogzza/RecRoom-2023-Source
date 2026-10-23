using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Core.Locomotion
{
	public class LocomotionCollisionTrigger : MonoBehaviour
	{
		public delegate void OPCELMCGHNK(Player EKOFNPFCLMO, DCACHBJGDMC.ENAKFGOOAHI JEMNNNEKOJM);

		private sealed class LEDDDLMMFED : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public LocomotionCollisionTrigger _003C_003E4__this;

			public Player player;

			public DCACHBJGDMC.ENAKFGOOAHI surfaceType;

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
			public LEDDDLMMFED(int _003C_003E1__state)
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

		private OPCELMCGHNK GOMJJNFHOIA__BackingField;

		private OPCELMCGHNK MLHEAHDHJOE__BackingField;

		private Dictionary<DCACHBJGDMC.ENAKFGOOAHI, LKGILLBEJEK> DNIECNHJKFC;

public event OPCELMCGHNK CollisionEnterEvent {
add {
		}
remove {
		}
}

public event OPCELMCGHNK CollisionExitEvent {
add {
		}
remove {
		}
}

		public void OnLocomotionCollision(Player EKOFNPFCLMO, DCACHBJGDMC.ENAKFGOOAHI JEMNNNEKOJM)
		{
		}

		private IEnumerator<EGGPGCCKPCO> NJPDJHHHKFG(Player EKOFNPFCLMO, DCACHBJGDMC.ENAKFGOOAHI JEMNNNEKOJM)
		{
			return null;
		}
	}
}
