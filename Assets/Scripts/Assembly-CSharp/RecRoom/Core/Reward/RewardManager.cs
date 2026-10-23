using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RecRoom.Core.Reward
{
	public class RewardManager : SingletonMonoBehaviour<RewardManager>
	{
		private sealed class EFIGCEKFKLD
		{
			public RewardManager _003C_003E4__this;

			public IIGLDDDANPN giftContext;

			public Vector3 spawnLocation;

			public Quaternion spawnRotation;

			public DBIPHDIEBCM promise;

			public Action _003C_003E9__3;

			public Action<string> _003C_003E9__4;

			internal void _003CRequestQuestRewardAsync_003Eb__0(EDDPDJCKOBH.GMBCAMAAPMN gift)
			{
			}

			internal void _003CRequestQuestRewardAsync_003Eb__1(EDDPDJCKOBH.GMBCAMAAPMN gift)
			{
			}

			internal void _003CRequestQuestRewardAsync_003Eb__2(string e)
			{
			}

			internal void _003CRequestQuestRewardAsync_003Eb__3()
			{
			}

			internal void _003CRequestQuestRewardAsync_003Eb__4(string s)
			{
			}
		}

		private sealed class EPHMMNELBEP : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public RewardManager _003C_003E4__this;

			private OFOJMMEANHP.GNBEMBCEKHE _003CrewardSelection_003E5__2;

			private DateTime _003CexpiresAt_003E5__3;

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
			public EPHMMNELBEP(int _003C_003E1__state)
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

		private sealed class MIJDJIPEJJP
		{
			public OFOJMMEANHP.GNBEMBCEKHE rewardSelection;

			public global::PHLHFLLLDLK<int?> promise;

			public RewardManager _003C_003E4__this;

			internal void _003CShowRewardSelectionScreen_003Eb__1(long rewardSelectionId, int? selected)
			{
			}

			internal LAHBDKNMNHN _003CShowRewardSelectionScreen_003Eb__0(int? selected)
			{
				return null;
			}
		}

		private const string FOGMKKFIIAD = "Rewards.UseRewardSelection";

		private const string DINIFPJBADK = "Rewards.SelectionTimeout";

		private static readonly Dictionary<OFOJMMEANHP.FMDBPNFFJAH, string> IJOLJMALFNG;

		private IILDCCEMGBA LCPOIILBNLD;

		private BHNJIBDJFAL NJPJBDDAEFH;

		[SerializeField]
		private float timeBetweenMenuScreens;

		private LKGILLBEJEK HGOBKKIPHEE;

		private bool EKNOFAKJMKP;

		private static bool? MHDEFKEDDPP;

		private static int? MNCONPMDMOB;

public bool UseRewardSelection
{
get 		{
			return false;
		}

}

public int RewardSelectionTimeout
{
get 		{
			return 0;
		}

}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void NNAKELHEGML(UnityEngine.SceneManagement.Scene FEGPGPHCDJD, LoadSceneMode FFDKLDFJBMF)
		{
		}

		private void KKJEGDFFILL(UnityEngine.SceneManagement.Scene PBLCKBNCAFM)
		{
		}

		public LAHBDKNMNHN RequestDailyChallengesCompleteRewardAsync()
		{
			return null;
		}

		public LAHBDKNMNHN RequestFirstActivityOfTheDayRewardAsync()
		{
			return null;
		}

		public LAHBDKNMNHN RequestGameRewardAsync(IIGLDDDANPN? NLDFHOPLCAL)
		{
			return null;
		}

		public LAHBDKNMNHN RequestQuestRewardAsync(IIGLDDDANPN NLDFHOPLCAL, IIGLDDDANPN? PEHPBOANIIP, GiftBoxSpawnPoint ELGLOEDDKAJ)
		{
			return null;
		}

		public LAHBDKNMNHN RequestQuestRewardAsync(IIGLDDDANPN NLDFHOPLCAL, IIGLDDDANPN? PEHPBOANIIP, Vector3 KNDDKFDPANO, Quaternion EIKMPMAOMIA)
		{
			return null;
		}

		private LAHBDKNMNHN NPLBFBBCEMF(OFOJMMEANHP.FMDBPNFFJAH OFBKHHAOBNO, IIGLDDDANPN? NLDFHOPLCAL)
		{
			return null;
		}

		private void PHJPBNPECLN(IIGLDDDANPN GELEIHMGBKN, EDDPDJCKOBH.GMBCAMAAPMN OANMAEFEHOF, Vector3 KNDDKFDPANO, Quaternion EIKMPMAOMIA)
		{
		}

		private void JIOPJAEGACK()
		{
		}

		private void JKDBDNOJEFC()
		{
		}

		private IEnumerator<EGGPGCCKPCO> IJLCNHHJLJP()
		{
			return null;
		}

		private LAHBDKNMNHN BIBBHHCBMFP(OFOJMMEANHP.GNBEMBCEKHE HCIBGFPNHCJ, DateTime KBCMAEIAAPA)
		{
			return null;
		}

		private LAHBDKNMNHN MDPBGGEMCLI(OFOJMMEANHP.GNBEMBCEKHE HCIBGFPNHCJ, int? FAKOICJDABG)
		{
			return null;
		}

		public static string GetMessageForReward(OFOJMMEANHP.FMDBPNFFJAH OFBKHHAOBNO, IIGLDDDANPN? NLDFHOPLCAL)
		{
			return null;
		}

		private bool BDLCGHPMDEN()
		{
			return false;
		}

		[CompilerGenerated]
		private bool MFPBCGKHNLG()
		{
			return false;
		}
	}
}
