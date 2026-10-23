using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using JetBrains.Annotations;
using UnityEngine;

namespace RecRoom.Consumable
{
	public class ConsumableManager : NetworkedSingletonMonoBehaviour<ConsumableManager>, EDJIOCIKNEJ, JMIIPNGAANF
	{
		public enum ALNBFPPACFD
		{
			Invalid = -1,
			Usage = 0,
			Time = 1,
			RealWorldTime = 2
		}

		private struct BLJAOLKECJK
		{
			public IELGHJEOPKB KIJHICGIKFM;

			public float JIJCKCGHLCF;
		}

		private sealed class MJKJODIAJJP : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ConsumableManager _003C_003E4__this;

			private List<IELGHJEOPKB>.Enumerator _003C_003E7__wrap1;

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
			public MJKJODIAJJP(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class HGJEJNONOJA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ConsumableManager _003C_003E4__this;

			private List<HMJFJMPLFEO>.Enumerator _003C_003E7__wrap1;

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
			public HGJEJNONOJA(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class IICDGGEHHKL
		{
			public IELGHJEOPKB consumable;

			internal bool _003CRemoveFromActiveTimedConsumableQueue_003Eb__0(BLJAOLKECJK c)
			{
				return false;
			}
		}

		private sealed class GFEMNHOLMJO : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ConsumableManager _003C_003E4__this;

			private BLJAOLKECJK _003CtimedItem_003E5__2;

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
			public GFEMNHOLMJO(int _003C_003E1__state)
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

		private sealed class OMMAJCOMMPK
		{
			public ConsumableManager _003C_003E4__this;

			public int creatorId;

			internal List<IELGHJEOPKB> _003CGetAllTransferableConsumableTypesByCreatorId_003Eb__2(List<IELGHJEOPKB> consumables)
			{
				return null;
			}
		}

		private sealed class PKGABBCBEEJ
		{
			public string consumableType;

			public ConsumableManager _003C_003E4__this;

			public int creatorId;

			public Func<IELGHJEOPKB, bool> _003C_003E9__2;

			internal bool _003CGetTransferableConsumablesOfTypeByCreatorId_003Eb__0(IELGHJEOPKB c)
			{
				return false;
			}

			internal List<IELGHJEOPKB> _003CGetTransferableConsumablesOfTypeByCreatorId_003Eb__1(List<IELGHJEOPKB> consumables)
			{
				return null;
			}

			internal bool _003CGetTransferableConsumablesOfTypeByCreatorId_003Eb__2(IELGHJEOPKB c)
			{
				return false;
			}
		}

		private sealed class PLIKINFOJOB
		{
			public string consumableType;

			internal bool _003CGetLatestNonActiveNonTransferableConsumableByType_003Eb__0(IELGHJEOPKB pc)
			{
				return false;
			}
		}

		private sealed class HICELAINJIH
		{
			public IELGHJEOPKB consumable;

			internal bool _003CGetRemainingCount_003Eb__0(BLJAOLKECJK ct)
			{
				return false;
			}
		}

		private sealed class HCDMPOMKGKD
		{
			public long consumableId;

			internal bool _003CGetConsumableById_003Eb__0(IELGHJEOPKB pc)
			{
				return false;
			}
		}

		private sealed class HCHLOHHILLC
		{
			public HMJFJMPLFEO category;

			internal bool _003CGetLatestPurchasedNonTransferableConsumablesInCategory_003Eb__0(IELGHJEOPKB c)
			{
				return false;
			}
		}

		private sealed class BHFGBINPGJH
		{
			public string type;

			internal bool _003CGetAllPurchasedNonTransferableConsumablesOfType_003Eb__0(IELGHJEOPKB c)
			{
				return false;
			}
		}

		private sealed class LGDIIKHFNDH
		{
			public long consumableId;

			public IELGHJEOPKB consumable;

			internal bool _003CConsumables_OnConsumableRemoved_003Eb__0(IELGHJEOPKB c)
			{
				return false;
			}

			internal bool _003CConsumables_OnConsumableRemoved_003Eb__1(IELGHJEOPKB pc)
			{
				return false;
			}
		}

		private Action<IELGHJEOPKB, bool> OOLNPOEFCJA__BackingField;

		private Action<IELGHJEOPKB, bool> HNKADFIPEMM__BackingField;

		[SerializeField]
		private ConsumableTool defaultConsumableToolPrefab;

		[SerializeField]
		private byte[] stableHash;

		[SerializeField]
		private byte[] seed;

		private List<IELGHJEOPKB> AEOBIGNANDM;

		private Dictionary<HMJFJMPLFEO, IELGHJEOPKB> EHJFDFLPEFO;

		private Dictionary<int, List<IELGHJEOPKB>> KNLDHFGMCIO;

		private const float NCGEOMKHHII = 60f;

		private LinkedList<BLJAOLKECJK> AEJGDBIJFFF;

public List<IELGHJEOPKB> PurchasedNonTransferableConsumables
{
get 		{
			return null;
		}

private set {
		}
}

public Dictionary<HMJFJMPLFEO, IELGHJEOPKB> ActiveConsumables
{
get 		{
			return null;
		}

private set {
		}
}

private Dictionary<int, List<IELGHJEOPKB>> CGPOOEKMPMJ
{
get 		{
			return null;
		}

set {
		}
}

public byte[] StableHash
{
get 		{
			return null;
		}

set {
		}
}

public byte[] Seed
{
get 		{
			return null;
		}

set {
		}
}

public UnityEngine.Object Asset
{
get 		{
			return null;
		}

}

public event Action<IELGHJEOPKB, bool> OnActiveConsumableChanged {
add {
		}
remove {
		}
}

public event Action<IELGHJEOPKB, bool> OnPurchasedConsumableChanged {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private IEnumerator Start()
		{
			return null;
		}

		public void DeactivateConsumableOfCategory(HMJFJMPLFEO JNKJFJLJKNJ, bool LIEPJABJLAD)
		{
		}

		public void ActivateConsumable(IELGHJEOPKB CMKFINMJJEI, bool LIEPJABJLAD)
		{
		}

		private IEnumerator PFHAGMHDGML()
		{
			return null;
		}

		public LAHBDKNMNHN DownloadPurchasedConsumables()
		{
			return null;
		}

		public LAHBDKNMNHN UseConsumable(IELGHJEOPKB KIJHICGIKFM, int BMGEEHKMMDG)
		{
			return null;
		}

		public void TryApplyConsumableEffect(ConsumableEffect HAJBKPNDEDG)
		{
		}

		[CanBeNull]
		public Tool SpawnConsumableForLocalPlayer(string CLBIBFPJLLP, long? GFGAKKMOHON, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float JDFDFBKKBPO, PlayerSpawnedEquipment.NHMNGDFJFCC LODOMOIPMIL)
		{
			return null;
		}

		private void OHNNFJODOBA(IELGHJEOPKB KIJHICGIKFM)
		{
		}

		private IEnumerator ADOPOOEKEPF()
		{
			return null;
		}

		private void NOEAFOCEJGO(IELGHJEOPKB KIJHICGIKFM)
		{
		}

		public global::NCOKFFGPIJM<List<IELGHJEOPKB>> GetAllTransferableConsumableTypesByCreatorId(int FKJJKDJPBOD)
		{
			return null;
		}

		public global::NCOKFFGPIJM<List<IELGHJEOPKB>> GetTransferableConsumablesOfTypeByCreatorId(string CLBIBFPJLLP, int FKJJKDJPBOD)
		{
			return null;
		}

		public IELGHJEOPKB GetLatestNonActiveNonTransferableConsumableByType(string CLBIBFPJLLP)
		{
			return null;
		}

		public int GetRemainingCount(IELGHJEOPKB KIJHICGIKFM)
		{
			return 0;
		}

		public IELGHJEOPKB GetConsumableById(long GFGAKKMOHON)
		{
			return null;
		}

		public bool IsConsumableOfTypeActive(string NIFOGEBEDNG)
		{
			return false;
		}

		public List<IELGHJEOPKB> GetLatestPurchasedNonTransferableConsumables()
		{
			return null;
		}

		public List<IELGHJEOPKB> GetLatestPurchasedNonTransferableConsumablesInCategory(HMJFJMPLFEO JNKJFJLJKNJ)
		{
			return null;
		}

		public List<IELGHJEOPKB> GetAllPurchasedNonTransferableConsumablesOfType(string NIFOGEBEDNG)
		{
			return null;
		}

		public IELGHJEOPKB GetActiveConsumableInCategory(HMJFJMPLFEO JNKJFJLJKNJ)
		{
			return null;
		}

		public bool IsHairDyeConsumableActive(string FINPDEFINEN)
		{
			return false;
		}

		public HMJFJMPLFEO GetConsumableCategory(string NKDPOGNOBEG)
		{
			return HMJFJMPLFEO.CameraFilter;
		}

		public void InvalidateTransferableConsumablesByCreatorId(int FKJJKDJPBOD)
		{
		}

		public void GetActiveCouponConsumableByType(FHPHMBKPLCC NJCNIFJHLNK, GKPEKOLBBJL HLFOMOKJKAM, out CouponConsumableInfo CJLCLGLDOOB, out IELGHJEOPKB NDBBLMDPOGI)
		{
			CJLCLGLDOOB = null;
			NDBBLMDPOGI = null;
		}

		public void GetActiveWatchStoreTokenCouponConsumable(out CouponConsumableInfo CJLCLGLDOOB, out IELGHJEOPKB NDBBLMDPOGI)
		{
			CJLCLGLDOOB = null;
			NDBBLMDPOGI = null;
		}

		private void CDDHGKOHFLH(IELGHJEOPKB KIJHICGIKFM, bool GNGKKJPOAPJ)
		{
		}

		private void NEMADCADBAO(IELGHJEOPKB KIJHICGIKFM, bool FEAFMCKIFHC)
		{
		}

		private void EMAFIKOEBID()
		{
		}

		private void GPEMJDKABPM(IELGHJEOPKB KIJHICGIKFM)
		{
		}

		private void MAMJBOKGFKH(long GFGAKKMOHON)
		{
		}

		public void AppendToHash(IncrementalHash NDFMMDHCKFC)
		{
		}

		[CompilerGenerated]
		private void LLIIHNCCNNB(List<IELGHJEOPKB> DOKKHPBAEKE)
		{
		}
	}
}
