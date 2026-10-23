using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom
{
	public class SpawnableCollectible : MonoBehaviour, HICMCNIDBOB
	{
		public delegate void CLEOKDBIABG(SpawnableCollectible BJFOGOHFGAM);

		private sealed class KAIDFJJLKBP : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public int totalGroupValue;

			public int individualCollectibleValue;

			public float spawnDuration;

			public SpawnableCollectible prefab;

			public Player targetPlayer;

			public Vector3 spawnPosition;

			public float updateDelay;

			public bool automaticallyPickup;

			public Vector3? targetPosition;

			public Action onFinishedSpawning;

			private int _003CcollectibleCount_003E5__2;

			private int _003CvalueRemainder_003E5__3;

			private float _003CdeltaDuration_003E5__4;

			private int _003Ci_003E5__5;

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
			public KAIDFJJLKBP(int _003C_003E1__state)
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
		private float spawnForce;

		[SerializeField]
		private float upWeight;

		[SerializeField]
		private float sideWeight;

		[SerializeField]
		private float torqueOffset;

		[SerializeField]
		private OENDEJENMFH collectibleType;

		[SerializeField]
		private float attractDistance;

		[SerializeField]
		private float stayOnFloorDistance;

		[SerializeField]
		private float collectDistance;

		[SerializeField]
		private float maxCollectionDuration;

		[SerializeField]
		private float minAttractSpeed;

		[SerializeField]
		private float maxAttractSpeed;

		[SerializeField]
		private float attractSmoothTime;

		[SerializeField]
		private float playerHeadTargetOffset;

		[SerializeField]
		private float attractRotationSpeed;

		[SerializeField]
		private RecRoomAudioClip[] pickupAudio;

		public static global::HHOBPMOCKMJ<SpawnableCollectible> CollectedEvent;

		public const int DEFAULT_PRE_ALLOCATE_SIZE = 10;

		private static Transform JADDIGFKBKO;

		private static Dictionary<OENDEJENMFH, List<SpawnableCollectible>> JGODGIFFJBI;

		[SerializeField]
		private Rigidbody rigidbody;

		private bool MBIFIIPHENJ;

		private float OKGDJHHECDF;

		private bool LAOGAGAKNHI;

		private float IGFNMDGBMCP;

		private Vector3 OIEPDFJCEHE;

		private Vector3 BHLNFEDMJDE;

		private Vector3? INKGHPCDMCG;

		private Player CBDPEOAABOH;

		private bool DACNHFGDIBL;

		private bool BHDAEDCJFBM;

		private float FHFDDKOBFLG;

		private float PPHOKIJCFMB;

		private int ABGNFCJCFOH;

private static Transform OKEBBNJJIJI
{
get 		{
			return null;
		}

}

public int Value
{
get 		{
			return 0;
		}

set {
		}
}

		public void Reset(int IPMIIEAGJKC, Vector3 INLGLHIPOMC, Vector3 JGACLMJKIAL, Player CBDPEOAABOH, float FHFDDKOBFLG = 0f, bool DACNHFGDIBL = false)
		{
		}

		public void Reset(int IPMIIEAGJKC, Vector3 INLGLHIPOMC, Vector3 JGACLMJKIAL, Vector3? INKGHPCDMCG, float FHFDDKOBFLG = 0f, bool BHDAEDCJFBM = true)
		{
		}

		private void CLIDANOMCFK(int IPMIIEAGJKC, Vector3 INLGLHIPOMC, Vector3 JGACLMJKIAL)
		{
		}

		private void Update()
		{
		}

		public void OnCollect()
		{
		}

		public static void PreAllocateCollectibles(SpawnableCollectible GDEKLMNKJBC, int BFFJHKFEFPP = 10)
		{
		}

		public static void SpawnCollectibleGroup(SpawnableCollectible GDEKLMNKJBC, int EBIPJBHFPLP, int EGLDBBOCOJE, Vector3 FCNGMPHKHAE, Player CBDPEOAABOH, bool DACNHFGDIBL, float IMLIMANOLJN = 0f)
		{
		}

		public static void SpawnCollectibleGroup(SpawnableCollectible GDEKLMNKJBC, int EBIPJBHFPLP, int EGLDBBOCOJE, Vector3 FCNGMPHKHAE, Vector3 INKGHPCDMCG, float IMLIMANOLJN = 0f)
		{
		}

		private static void DOIIJNDAKPP(SpawnableCollectible GDEKLMNKJBC, int EBIPJBHFPLP, int EGLDBBOCOJE, Vector3 FCNGMPHKHAE, Vector3? INKGHPCDMCG, Player CBDPEOAABOH, bool DACNHFGDIBL, float IMLIMANOLJN)
		{
		}

		public static IEnumerator SpawnStaggeredCollectibleGroup(SpawnableCollectible GDEKLMNKJBC, int EBIPJBHFPLP, int EGLDBBOCOJE, Vector3 FCNGMPHKHAE, Player CBDPEOAABOH, bool DACNHFGDIBL, float IMLIMANOLJN = 1f, Action HMHNCAKJJBJ = null)
		{
			return null;
		}

		private static IEnumerator EHDKKKADAAL(SpawnableCollectible GDEKLMNKJBC, int EBIPJBHFPLP, int EGLDBBOCOJE, Vector3 FCNGMPHKHAE, Vector3? INKGHPCDMCG, Player CBDPEOAABOH, bool DACNHFGDIBL, float AEAFALJKIDI, float IMLIMANOLJN, Action HMHNCAKJJBJ)
		{
			return null;
		}

		public static SpawnableCollectible GetNextCollectible(SpawnableCollectible GDEKLMNKJBC)
		{
			return null;
		}

		public static void ReturnCollectible(SpawnableCollectible LJJMELANGBO)
		{
		}

		public static void ReturnAllCollectibles()
		{
		}

		private static SpawnableCollectible GKMDJHDIPAL(SpawnableCollectible GDEKLMNKJBC)
		{
			return null;
		}

		private static List<SpawnableCollectible> LIFMANCIAIB(SpawnableCollectible GDEKLMNKJBC)
		{
			return null;
		}
	}
}
