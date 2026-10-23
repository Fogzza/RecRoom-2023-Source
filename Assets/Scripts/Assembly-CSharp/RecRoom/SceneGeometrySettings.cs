using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RecRoom
{
	[Serializable]
	public sealed class SceneGeometrySettings : NMIKADGOIOE
	{
		private sealed class OMFGPJLDCHC : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public SceneGeometrySettings _003C_003E4__this;

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
			public OMFGPJLDCHC(int _003C_003E1__state)
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

		private global::MOBDJNEDDKC<bool> _movementBlockersEnabled;

		private global::MOBDJNEDDKC<bool> _enforceHostsOnlyAreas;

		[CompilerGenerated]
		private Action SettingsChangedEvent;

		private RecRoomSceneManager sceneManager;

		private bool thisSceneContainsHostOnlyAreas;

		public bool MovementBlockersEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool EnforceHostsOnlyAreas
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private bool LocalPlayerBlockedFromHostOnlyAreas => false;

		private bool LocalPlayerOverValidTeleportRegion => false;

public event Action GCEJIDLFBFI {
add {
		}
remove {
		}
}

		public void JGHENDHCBHF(RecRoomSceneManager MACMCOFLIIO)
		{
		}

		public void BJDNGFKFKPK()
		{
		}

		public void LJODMHLJPAD()
		{
		}

		public void CDJHKCNAIKI()
		{
		}

		public void KPFOBOPDHJM()
		{
		}

		private void GJBKOIIEFDH()
		{
		}

		private void HMKLDEJGFGF(Player EKOFNPFCLMO)
		{
		}

		private void NOHEGKAFBND()
		{
		}

		private void DGJNDPBOELJ()
		{
		}

		private IEnumerator<EGGPGCCKPCO> MLMOPJOAJGD()
		{
			return null;
		}
	}
}
