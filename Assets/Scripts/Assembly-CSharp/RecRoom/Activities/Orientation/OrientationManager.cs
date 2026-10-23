using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RecRoom.Activities.Orientation
{
	public class OrientationManager : NetworkedSingletonMonoBehaviour<OrientationManager>
	{
		private enum OJLDBMADBCO
		{
			INVALID = 0,
			RUNNING = 1,
			LEAVE_TO_DORM = 2,
			DEEP_LINK_FLOW = 3
		}

		private enum NIEIOOEHFMC
		{
			RUNNING_SCENE_SUB_STATE = 0,
			UNLOADING_SCENE_SUB_STATE = 1,
			STRIDE = 2
		}

		private sealed class NHPPOGFICIP
		{
			public OrientationManager _003C_003E4__this;

			public int currentSubsceneIndex;

			internal void _003COnUpdateRunningSceneSubState_003Eb__0(NBGHEOAONCI result)
			{
			}
		}

		private sealed class JEDKBGAADPG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

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
			public JEDKBGAADPG(int _003C_003E1__state)
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

		private int OBMFNPMHIEE;

		private int EBJNKJPNBBC;

		private APGPNOKPLLL NKKHAEFBOLO;

		private OrientationSubScene HMEHELLMLJJ;

		private JOJOABLFOBA GKPCJAGAGPP;

		private HONEDBECDOK PLPHABIOJNH;

		private bool EJLKBFEFCKN;

		private NHNKJMHGBBG FMPNEKPNOPB;

public static bool IsReturningPlayer
{
get 		{
			return false;
		}

}

public NHNKJMHGBBG ActiveDeepLinkType
{
get 		{
			return NHNKJMHGBBG.None;
		}

private set {
		}
}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void AOPOLBLKGKH(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void MGHPNKGHCDF()
		{
		}

		private void NIDHDMPBDLC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void KINBIDBBFMJ()
		{
		}

		private void LNHBIOMMECE(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void BPINAGNMEHL(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void AEOHGEMOBIG()
		{
		}

		private void OPPOBKCCGOG(int HAFOBFDBCJD)
		{
		}

		private void NHIDMJJJGNO()
		{
		}

		private void OAAPBNDMENO()
		{
		}

		private void JHOCHOLNNKH(int HAFOBFDBCJD, GameObject[] NKDBEJHDHCB)
		{
		}

		private ushort BOMEGHHIJNA(int OOMCLENBFPI)
		{
			return 0;
		}

		private ushort CBLIPFPCHIL(int OOMCLENBFPI)
		{
			return 0;
		}

		private int FLMALBDHEIK(int OOMCLENBFPI, NIEIOOEHFMC ACFPEJKNBDE)
		{
			return 0;
		}

		public int GetCurrentSubsceneIndex()
		{
			return 0;
		}

		private int KBECJHBNMKJ(ushort BEOILOFKEIA)
		{
			return 0;
		}

		public string GetCurrentSubsceneName()
		{
			return null;
		}

		public static void AddLocalPlayerRestrictions(object IALNODEHBNN)
		{
		}

		public static void RemoveLocalPlayerRestrictions(object IALNODEHBNN)
		{
		}

		private static void DPFBIHKIMMG(object IALNODEHBNN)
		{
		}

		public static void UnlockWatch()
		{
		}

		private void CNFJCMKALJH()
		{
		}

		[CompilerGenerated]
		private void FAIEPIGFLJN(FKCGPAFDHIN OIPHMDLCHLH)
		{
		}

		[CompilerGenerated]
		internal static void KBNLOMCPNGK(PlayerHand PMNLJGLDMJN)
		{
		}

		[CompilerGenerated]
		internal static IEnumerator<EGGPGCCKPCO> DIEFPIOCGOC()
		{
			return null;
		}

		[CompilerGenerated]
		private void CLCMJFBGABP()
		{
		}
	}
}
