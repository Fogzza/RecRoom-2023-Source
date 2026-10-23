using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Audio;
using RecRoom.Core;
using RecRoom.Core.Pools;
using UnityEngine;

public class GiftManager : SingletonMonoBehaviour<GiftManager>
{
	public delegate void BCGEAIHLKHB(EDDPDJCKOBH.GMBCAMAAPMN JILJEPBFNBO, string NLJOHEKGNDH);

	private sealed class NNGMDPJGIGF
	{
		public GiftManager _003C_003E4__this;

		public List<EDDPDJCKOBH.GMBCAMAAPMN> giftPackages;

		public bool useSpawnLocation;

		internal void _003CReceiveGifts_003Eb__3(GiftBox giftBox)
		{
		}
	}

	private sealed class LKCFPAPNPEJ
	{
		public EDDPDJCKOBH.GMBCAMAAPMN giftPackage;

		internal bool _003CReceiveGiftsFromQueue_003Eb__1(EDDPDJCKOBH.GMBCAMAAPMN gp)
		{
			return false;
		}

		internal bool _003CReceiveGiftsFromQueue_003Eb__2(EDDPDJCKOBH.GMBCAMAAPMN gp)
		{
			return false;
		}
	}

	private sealed class ANIOGCOMDKJ : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool useSpawnLocation;

		public GiftManager _003C_003E4__this;

		private LKCFPAPNPEJ _003C_003E8__1;

		private Vector3 _003CinitialPosition_003E5__2;

		private Quaternion _003CgiftRotation_003E5__3;

		private Vector3 _003CgiftPosition_003E5__4;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public ANIOGCOMDKJ(int _003C_003E1__state)
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

	private sealed class CGGJEFBMKMC : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public EDDPDJCKOBH.GMBCAMAAPMN currentGiftPackage;

		public GiftManager _003C_003E4__this;

		public Func<GiftPackageVariant, bool> createPackageFilter;

		public Vector3 boxPosition;

		public Quaternion boxRotation;

		public float closeToPlayerDistance;

		public Action<GiftBox> onGiftBoxDestroyed;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public CGGJEFBMKMC(int _003C_003E1__state)
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

	private sealed class GMPIDDEBFOO
	{
		public EDDPDJCKOBH.GMBCAMAAPMN giftPackage;

		internal bool _003CRunConsumeGift_003Eb__3(EDDPDJCKOBH.GMBCAMAAPMN g)
		{
			return false;
		}

		internal void _003CRunConsumeGift_003Eb__0()
		{
		}
	}

	private sealed class KHJCPJAAAKM
	{
		public string error;

		internal void _003CRunConsumeGift_003Eb__1(string e)
		{
		}
	}

	private sealed class FPMKAJLLLKA : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public EDDPDJCKOBH.GMBCAMAAPMN giftPackage;

		private KHJCPJAAAKM _003C_003E8__1;

		private GMPIDDEBFOO _003C_003E8__2;

		public bool trySaveLocalAvatarOnSuccess;

		public bool yieldOnAvatarItemUnlock;

		public GiftManager _003C_003E4__this;

		public MOKKNOCMELN.LELEMNMEFNC callback;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public FPMKAJLLLKA(int _003C_003E1__state)
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

	private sealed class LHBDDBCCFEA : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GiftManager _003C_003E4__this;

		public Vector3 giftPosition;

		private Vector3 _003CnotificationPosition_003E5__2;

		private Quaternion _003Crotation_003E5__3;

		private int _003Ci_003E5__4;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public LHBDDBCCFEA(int _003C_003E1__state)
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

	private sealed class CHBLEKIFCDD
	{
		public string equipmentModificationGuid;

		internal bool _003CIsEquipmentAvailableInGiftPackageQueue_003Eb__0(EDDPDJCKOBH.GMBCAMAAPMN g)
		{
			return false;
		}
	}

	private sealed class EFJGIOHHNJI
	{
		public string avatarItemDesc;

		internal bool _003CIsOutfitAvailableInGiftPackageQueue_003Eb__0(EDDPDJCKOBH.GMBCAMAAPMN g)
		{
			return false;
		}
	}

	private sealed class JMOPJIICBOE
	{
		public string avatarItemDesc;

		internal bool _003CIsHairDyeAvailableInGiftPackageQueue_003Eb__0(EDDPDJCKOBH.GMBCAMAAPMN g)
		{
			return false;
		}
	}

	private sealed class ACLHJLIODGO
	{
		public string equipmentModificationGuid;

		internal bool _003CTryGetGiftPackageContainingEquipment_003Eb__0(EDDPDJCKOBH.GMBCAMAAPMN g)
		{
			return false;
		}
	}

	private sealed class DPGKJGKOPAE
	{
		public string avatarItemDesc;

		internal bool _003CTryGetGiftPackageContainingAvatarItem_003Eb__0(EDDPDJCKOBH.GMBCAMAAPMN g)
		{
			return false;
		}
	}

	[SerializeField]
	private GiftPackageVariantMap variantMap;

	[SerializeField]
	private RarityColorMap rarityColorMap;

	[SerializeField]
	private float minGiftHeight;

	[SerializeField]
	private float maxGiftHeight;

	[SerializeField]
	private float minPlayerHeight;

	[SerializeField]
	private float maxPlayerHeight;

	[SerializeField]
	private float screenGiftOffset;

	[SerializeField]
	private PooledParticle celebrateParticlePrefab;

	[SerializeField]
	private float celebrateParticleSpacing;

	[SerializeField]
	private RecRoomAudioClip celebrationGiftAudio;

	[SerializeField]
	private WorldSpaceNotification celebrationNotification;

	private bool IGOKGCKLFGH;

	private Coroutine JMPAADINPHD;

	private Coroutine OOPDFMPOLNE;

	private List<EDDPDJCKOBH.GMBCAMAAPMN> APNEEKNLEPL;

	private GiftBox KCHMLCKJKFC;

	private readonly Dictionary<IIGLDDDANPN, GiftPackageVariant> BKLNCPKLECI;

	private readonly Dictionary<IIGLDDDANPN, GiftPackageVariant.GiftContextMapping> GFLIFBGINAL;

	private Action<EDDPDJCKOBH.GMBCAMAAPMN> BJADNJHBJBB__BackingField;

	private bool GJNAJAIMHDH;

	private LHMPPJKHCJG LDFABJFFKHN;

public Material DefaultGiftBoxMaterial
{
get 	{
		return null;
	}

}

public RarityColorMap RarityColorMap
{
get 	{
		return null;
	}

}

public GiftBox ActiveGiftBox
{
get 	{
		return null;
	}

}

public event Action<EDDPDJCKOBH.GMBCAMAAPMN> OnGiftOpened {
add {
	}
remove {
	}
}

	public void Initialize()
	{
	}

	private void NJLABJMKAFE()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void JINLPENCFJH(IBINLLOMNPN MHCOBIPKGNI)
	{
	}

	private void CNDOACMKIAM()
	{
	}

	private bool KLNGJKIFMKA()
	{
		return false;
	}

	public bool IsVariantMapValid()
	{
		return false;
	}

	private bool AFFCLLEAKKB(EDDPDJCKOBH.GMBCAMAAPMN JILJEPBFNBO)
	{
		return false;
	}

	private void APMGNPIJBHF(EDDPDJCKOBH.GMBCAMAAPMN JILJEPBFNBO)
	{
	}

	private void PCKIIPFEKHO(EDDPDJCKOBH.HJIJLBBPCKC ADCFFAJGNAM)
	{
	}

	public void ReceiveGifts(List<EDDPDJCKOBH.GMBCAMAAPMN> PFBAOAHFAIC, bool EKILBKBJENK, bool OAHMPAFOGBJ)
	{
	}

	public void StopReceivingGifts()
	{
	}

	private void KNFBEKPIMKB(bool EKILBKBJENK)
	{
	}

	private void OFNAGJMFKMJ()
	{
	}

	private IEnumerator NPPAHDPKCKF(bool EKILBKBJENK)
	{
		return null;
	}

	public IEnumerator<EGGPGCCKPCO> DequeueGift(EDDPDJCKOBH.GMBCAMAAPMN DACJJPNNLFA, Vector3 OCGGGIIFAJD, Quaternion ELOJPMEMIKL, Func<GiftPackageVariant, bool> HKMLJBGANKD, float ECLKDAINDPP = 2.2f, Action<GiftBox> BEBJGNALNIM = null)
	{
		return null;
	}

	public IEnumerator<EGGPGCCKPCO> RunConsumeGiftFromUI(EDDPDJCKOBH.GMBCAMAAPMN JILJEPBFNBO, MOKKNOCMELN.LELEMNMEFNC ONAFALABHKI)
	{
		return null;
	}

	public IEnumerator<EGGPGCCKPCO> RunConsumeGift(EDDPDJCKOBH.GMBCAMAAPMN JILJEPBFNBO, MOKKNOCMELN.LELEMNMEFNC ONAFALABHKI, bool IHIABGNNAHM = false, bool KDAEJFCMMFA = true)
	{
		return null;
	}

	private void DOIKDNPJIHG(Vector3 JKGJFALKBCA)
	{
	}

	private void LCJEMLDIHDI()
	{
	}

	private void CEHDNFPKJGC(GiftBox APADAOBMNDI)
	{
	}

	private IEnumerator BBJPNIOGBMJ(Vector3 JKGJFALKBCA)
	{
		return null;
	}

	private float HPOJHGEMHHC(Player EKOFNPFCLMO)
	{
		return 0f;
	}

	public GiftPackageVariantMap.NDFJGAOMJMK TryGetGiftPackageVariant(IIGLDDDANPN NLDFHOPLCAL, out GiftPackageVariant CEGOEJEDNME)
	{
		CEGOEJEDNME = null;
		return GiftPackageVariantMap.NDFJGAOMJMK.Ok;
	}

	public GiftPackageVariant.GiftContextMapping GetGiftContextMapping(IIGLDDDANPN DELCOFCGDFF)
	{
		return null;
	}

	public string GetDefaultMessageForGiftContext(IIGLDDDANPN DELCOFCGDFF)
	{
		return null;
	}

	public static void GetSpawnGiftPackageRotationPosition(Vector3 PEJEOHJJKBA, out Quaternion DICEJEPLBBA, out Vector3 JKGJFALKBCA)
	{
		DICEJEPLBBA = default;
		JKGJFALKBCA = default;
	}

	public static void SpawnGiftPackage(EDDPDJCKOBH.GMBCAMAAPMN FONCKAGCGLJ)
	{
	}

	public bool IsEquipmentAvailableInGiftPackageQueue(string GNMCKHPODDF)
	{
		return false;
	}

	public bool IsOutfitAvailableInGiftPackageQueue(string ELDKAMCLDON)
	{
		return false;
	}

	public bool IsHairDyeAvailableInGiftPackageQueue(string ELDKAMCLDON)
	{
		return false;
	}

	public bool TryGetGiftPackageContainingEquipment(string GNMCKHPODDF, out EDDPDJCKOBH.GMBCAMAAPMN OJNEMEDDHOO)
	{
		OJNEMEDDHOO = null;
		return false;
	}

	public bool TryGetGiftPackageContainingAvatarItem(string ELDKAMCLDON, out EDDPDJCKOBH.GMBCAMAAPMN OJNEMEDDHOO)
	{
		OJNEMEDDHOO = null;
		return false;
	}

	[CompilerGenerated]
	private void FHOFEOFCBDD(bool EGJEBAFNALL)
	{
	}
}
