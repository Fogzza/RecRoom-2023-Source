using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.Core.GameManagement
{
	public class LootManager : MonoBehaviourPun
	{
		public enum ADHKIGLDKHN
		{
			SMALL_PILE = 0,
			LARGE_PILE = 1,
			CUSTOM_VALUE = 2
		}

		private enum BGAKAKPNJHE
		{
			LOCAL = 0,
			GAME_STAT = 1
		}

		private enum FHPAFBIBCPP
		{
			LOSE_LOOT = -1,
			RECOVERABLE_LOST_LOOT = 0,
			BANK_AT_CHECKPOINTS = 1
		}

		private struct EDOPCEGBHFP
		{
			public float LKDHJKNGKHD;

			public IPLNKMKGEFN EBGKPFIAIMM;

			public bool GKMFGLDHGEN;

			public int HFJHGPAHFJG;

			public Vector3 OGPENFHJKOP;

			public Quaternion NAECMDMFCGO;
		}

		private sealed class CFNGAGIDHPH : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LootManager _003C_003E4__this;

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
			public CFNGAGIDHPH(int _003C_003E1__state)
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

		private sealed class DCBPFJGIGAA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LootManager _003C_003E4__this;

			private float _003CcurrentLootValue_003E5__2;

			private bool _003CmaxedOutLootPile_003E5__3;

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
			public DCBPFJGIGAA(int _003C_003E1__state)
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

		private sealed class NGMJCNHBGND : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LootManager _003C_003E4__this;

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
			public NGMJCNHBGND(int _003C_003E1__state)
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

		private sealed class MNHCIDLAINN : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public bool questWasWon;

			public LootManager _003C_003E4__this;

			private int _003Cbonus_003E5__2;

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
			public MNHCIDLAINN(int _003C_003E1__state)
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

		private sealed class MFBKAHJOEGP : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LootManager _003C_003E4__this;

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
			public MFBKAHJOEGP(int _003C_003E1__state)
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
		private GKPEKOLBBJL currencyType;

		[SerializeField]
		private string lootBankedText;

		[SerializeField]
		private FHPAFBIBCPP lootLossType;

		[SerializeField]
		private RankBucket[] rankBonuses;

		[SerializeField]
		private float dropLostLootDelay;

		[SerializeField]
		private RecRoomAudioClip dropLostLootAudio;

		[SerializeField]
		private float dropLostLootNotificationDelay;

		[SerializeField]
		private RecRoomAudioClip dropLostLootNotificationAudio;

		[SerializeField]
		private float bankLootDelay;

		[SerializeField]
		private RecRoomAudioClip bankLootNotificationAudio;

		[SerializeField]
		private float lostLootReminderNotificationDelay;

		[SerializeField]
		private RecRoomAudioClip lostLootReminderNotificationAudio;

		[SerializeField]
		private float lostLootNearbyNotificationDelay;

		[SerializeField]
		private RecRoomAudioClip lostLootNearbyNotificationAudio;

		[SerializeField]
		private float spawnedLootPileLifetime;

		[SerializeField]
		private RecRoomAudioClip[] lootPilePickupAudio;

		[SerializeField]
		private float smallPileLootValue;

		[SerializeField]
		private SerializedGuid smallPileEquipmentTypeId;

		[SerializeField]
		private float largePileLootValue;

		[SerializeField]
		private SerializedGuid lostLootEquipmentTypeId;

		[SerializeField]
		private int maxLostLootPileValue;

		[SerializeField]
		private RecRoomAudioClip lostLootPickupAudio;

		[SerializeField]
		private float lostLootPreviewSpawnSpeed;

		[SerializeField]
		private float smallChestLootValue;

		[SerializeField]
		private RecRoomAudioClip chestLootSpawnAudio;

		[SerializeField]
		private float enemyDeathLootDropRateDefault;

		[SerializeField]
		private float enemyLootValue;

		[SerializeField]
		private float breakableContainerLootDropRateDefault;

		[SerializeField]
		private float breakableContainerLootValue;

		[SerializeField]
		private float enemyLootMaxLinearSpeed;

		[SerializeField]
		private float enemyLootMaxAngularSpeed;

		[SerializeField]
		private float enemyLootMaxHorizontalSpawnRandomOffset;

		[SerializeField]
		private float enemyLootSpawnAudioDelay;

		[SerializeField]
		private RecRoomAudioClip enemyLootSpawnAudio;

		[SerializeField]
		private BGAKAKPNJHE lootStorageType;

		[SerializeField]
		private BFPALKJDPLP lootStorageStat;

		private float FDPLACOALAH;

		private float PDMIOPHEDDM;

		private float JHFOMDGBAON;

		private bool ODFLALCDILE;

		private float DBCFEJEEKEM;

		private bool IHOAABGEANN;

		private static LootManager EGAIHCNFOEN;

		private static List<EDOPCEGBHFP> HOBJIBPIEJK;

		private static readonly string LPFHPJMLGHI;

		private static readonly float JOAGKAJGJEO;

		private static readonly Vector3 JBLKFJECIEO;

		private static readonly string HIMOLOPFFGH;

		private static readonly float GBEBCCDIFCM;

private JBGFOIKBKED IBNBFKFFJGP
{
get 		{
			return JBGFOIKBKED.AC_UNIT;
		}

}

private JBGFOIKBKED INOBJBNIDNB
{
get 		{
			return JBGFOIKBKED.AC_UNIT;
		}

}

private float FIJMIFAKINN
{
get 		{
			return 0f;
		}

}

public static LootManager Instance
{
get 		{
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

		private void HDJBEAFJEHD()
		{
		}

		private void OHNBDLHJLBL()
		{
		}

		private void ADGHAPIFKOG()
		{
		}

		private void FOIIOKJOPFD()
		{
		}

		private void ADABFIMAEDL()
		{
		}

		private IEnumerator LNMPBODIDGD()
		{
			return null;
		}

		private IEnumerator JBPDCHJOPEB()
		{
			return null;
		}

		private IEnumerator MKMCKEHINFL()
		{
			return null;
		}

		private IEnumerator GCHJCMAPCIN(bool BFDNDCHDFIK)
		{
			return null;
		}

		private void EFEKEEAKLEE(LootTool DFGJDFEDFLH)
		{
		}

		private void KHAIMCEMILD(LootTool DFGJDFEDFLH)
		{
		}

		private void JLHGJKGHMNL(LootTool DFGJDFEDFLH)
		{
		}

		private LootTool KILPHPBELHL(JBGFOIKBKED CCOGHOKODAK, Vector3 ELGLOEDDKAJ, Quaternion FJKPMOAGDOI, float LGPIDIPODLD, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK, bool BGAGJCJCBNF)
		{
			return null;
		}

		private void IEEHHONMJGK(EquipmentSpawnerChest IEODCBDCDFF)
		{
		}

		public void SetEnemyLootDropRate(float CIAIAGKIGFK)
		{
		}

		public void ResetEnemyLootDropRate()
		{
		}

		public float GetDefaultEnemyLootDropRate()
		{
			return 0f;
		}

		private void KKALBOOJCFA(Enemy DPENEFKKNDN, DPMOPDDAJBJ NJDHAACHDKF)
		{
		}

		private void MDEPPMNHLHD(BreakablePointsContainer FMPHDMAKDKP)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnLootSpawn(Vector3 ELGLOEDDKAJ)
		{
		}

		private IEnumerator GKCCJEECJDI(Vector3 ELGLOEDDKAJ)
		{
			return null;
		}

		private bool EDJBEPLCJED(out float NBGOKOAPJGG)
		{
			NBGOKOAPJGG = default;
			return false;
		}

		private void CPMNPFPLFKJ()
		{
		}

		private void HNLDAIMKNOI(float CAPPNGIDEOK)
		{
		}

		private void KOJLMKBIMAJ(LootTool DFGJDFEDFLH, float CAPPNGIDEOK)
		{
		}

		private void PDKLDGKNLNN(LootTool DFGJDFEDFLH, CHILKDJABBF EKOFNPFCLMO, float KGDJLAJOBEP)
		{
		}

		[PBOMGCLBFHF]
		private void RpcMasterRequestAddLootAllPlayers(CHILKDJABBF CLAAKJAFDLA, LootTool DFGJDFEDFLH, int CAPPNGIDEOK)
		{
		}

		[PBOMGCLBFHF]
		private void RpcMasterRequestAddLootSinglePlayer(CHILKDJABBF EKOFNPFCLMO, LootTool DFGJDFEDFLH, int IPMIIEAGJKC)
		{
		}

		private bool NCAAHJANNHO()
		{
			return false;
		}

		private bool JPNHLIIHCPH(Vector3 MCNEIJMDFCJ)
		{
			return false;
		}

		[PBOMGCLBFHF]
		private void RpcMasterRequestLostLootSpawn(int JCOKHNJMDBO, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float NBGOKOAPJGG, Vector3 MCNEIJMDFCJ)
		{
		}

		private void IICMMCLCKNB()
		{
		}

		private bool LLNGHNHGEFN(out float KGDJLAJOBEP)
		{
			KGDJLAJOBEP = default;
			return false;
		}

		private void JOPPJDHBNKI()
		{
		}

		private void PCBJCJPFLFA(float EAMJAAKKEOM, Vector3 IDEIKAOFFFB, Quaternion ICEILNCDHGD)
		{
		}

		private bool MNDKIIMBPEF()
		{
			return false;
		}

		private int FPLGAPMHCDJ()
		{
			return 0;
		}

		private int GEBOJJNPPFO()
		{
			return 0;
		}

		private int APPFAKEIHDB(IPLNKMKGEFN KJAPODOABPN)
		{
			return 0;
		}

		private int DLOAPOECJPC(IPLNKMKGEFN KJAPODOABPN, bool AFNOEMBNLBI, int LEFGHLEOIHL)
		{
			return 0;
		}

		private bool OMPCNOCKLEK()
		{
			return false;
		}

		private void EBOMDLBFNCK(out IPLNKMKGEFN KJAPODOABPN)
		{
			KJAPODOABPN = default;
		}

		private void JEKCJBAPMMM(out IPLNKMKGEFN KJAPODOABPN, out bool AFNOEMBNLBI, out int LEFGHLEOIHL)
		{
			KJAPODOABPN = default;
			AFNOEMBNLBI = default;
			LEFGHLEOIHL = default;
		}

		private bool LBLJHNEPDAN()
		{
			return false;
		}

		private void MBJDEPLDOAB()
		{
		}

		private bool IIFNIOPMCLJ(float NBGOKOAPJGG)
		{
			return false;
		}

		[CompilerGenerated]
		private void PLGAKHJDEKJ(EGGNOENNPCA AELBDKCACOH)
		{
		}
	}
}
