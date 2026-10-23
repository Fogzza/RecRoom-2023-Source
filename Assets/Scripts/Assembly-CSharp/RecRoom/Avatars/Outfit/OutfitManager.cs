using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using JetBrains.Annotations;
using RecRoom.Audio;
using RecRoom.Avatars.Data.Runtime;
using RecRoom.Avatars.Data.Shared;
using RecRoom.Avatars.Face;
using UnityEngine;

namespace RecRoom.Avatars.Outfit
{
	public class OutfitManager : NetworkedSingletonMonoBehaviour<OutfitManager>, EDJIOCIKNEJ, JMIIPNGAANF
	{
		public class AvatarItemMetadata
		{
			public bool IsNew;

			public string FriendlyName;

			public string Tooltip;

			public DOOBOJIHNDF Rarity;

			public List<string> TagList;

			public int AvatarItemId;

			public string ThumbnailFilename;

			public string GetItemStarRarityString()
			{
				return null;
			}

			public static List<string> ParseTagList(string tagList)
			{
				return null;
			}
		}

		private sealed class DJPACLHHABD
		{
			public OutfitManager _003C_003E4__this;

			public List<EDDPDJCKOBH.JBANAMGBBAP> details;

			internal LAHBDKNMNHN _003CDownloadUnlockedCustomAvatarItems_003Eb__0(List<EDDPDJCKOBH.JBANAMGBBAP> baseAvatarItemDetails)
			{
				return null;
			}

			internal global::NCOKFFGPIJM<List<EDDPDJCKOBH.JBANAMGBBAP>> _003CDownloadUnlockedCustomAvatarItems_003Eb__1(IReadOnlyList<LINLOKECLME> customAvatarItems)
			{
				return null;
			}
		}

		private sealed class HOIPDDFKLEB
		{
			public List<string> avatarItemDescs;

			public OutfitManager _003C_003E4__this;

			internal global::NCOKFFGPIJM<List<EDDPDJCKOBH.JBANAMGBBAP>> _003CDownloadLockedAvatarItemDetailsByDesc_003Eb__0(List<EDDPDJCKOBH.JBANAMGBBAP> details)
			{
				return null;
			}
		}

		private sealed class EGGGAJBOPJP
		{
			public IEnumerable<string> detailDescs;

			public List<EDDPDJCKOBH.JBANAMGBBAP> details;

			public HOIPDDFKLEB CS_0024_003C_003E8__locals1;

			internal bool _003CDownloadLockedAvatarItemDetailsByDesc_003Eb__3(string desc)
			{
				return false;
			}

			internal global::NCOKFFGPIJM<List<EDDPDJCKOBH.JBANAMGBBAP>> _003CDownloadLockedAvatarItemDetailsByDesc_003Eb__5(IEnumerable<LINLOKECLME> customAvatarItems)
			{
				return null;
			}
		}

		private sealed class HLELGOKGJJB
		{
			public AvatarItem avatarItem;

			internal bool _003CDownloadLockedAvatarItemDetailsByDesc_003Eb__7(LINLOKECLME c)
			{
				return false;
			}
		}

		private sealed class GKFMJJIEDLA
		{
			public string avatarItemDesc;

			public OutfitManager _003C_003E4__this;

			public bool trySaveLocalAvatarOnSuccess;

			public Predicate<EDDPDJCKOBH.JBANAMGBBAP> _003C_003E9__2;

			internal bool _003CUnlockAvatarItemAndMarkNew_003Eb__2(EDDPDJCKOBH.JBANAMGBBAP uai)
			{
				return false;
			}
		}

		private sealed class LLHOCAKCPJM
		{
			public AvatarItemMetadata metadata;

			public GKFMJJIEDLA CS_0024_003C_003E8__locals1;

			internal void _003CUnlockAvatarItemAndMarkNew_003Eb__0(List<EDDPDJCKOBH.JBANAMGBBAP> unlockedAvatarItems)
			{
			}
		}

		private sealed class NODJGONPIEM
		{
			public bool usingFullBodyAvatar;

			internal bool _003CGetRandomInitialOutfit_003Eg__FilterItem_007C0(AvatarItem item, OutfitType outfitType)
			{
				return false;
			}

			internal bool _003CGetRandomInitialOutfit_003Eb__1(AvatarItem item)
			{
				return false;
			}

			internal bool _003CGetRandomInitialOutfit_003Eb__2(AvatarItem item)
			{
				return false;
			}

			internal bool _003CGetRandomInitialOutfit_003Eb__3(AvatarItem item)
			{
				return false;
			}

			internal bool _003CGetRandomInitialOutfit_003Eb__4(AvatarItem item)
			{
				return false;
			}
		}

		private sealed class DLAIEHFPAEJ
		{
			public bool useFullBodyAvatarItems;

			internal bool _003CTryGetDefaultTorsoItem_003Eg__FilterTorsoItem_007C0(AvatarItemData itemData)
			{
				return false;
			}

			internal bool _003CTryGetDefaultTorsoItem_003Eb__1(AvatarItem item)
			{
				return false;
			}

			internal bool _003CTryGetDefaultTorsoItem_003Eb__2(AvatarItem item)
			{
				return false;
			}
		}

		private static readonly List<string> MJEEBJAOLJE;

		private static readonly List<string> KGLOCGJIFBN;

		private readonly Dictionary<AvatarItem, DIGIMEFFGDC> HEIMKMIEKCC;

		private readonly List<DIGIMEFFGDC> DJEODOHENLB;

		public static readonly EEANDDJEMJC BrowsableItemsChangedEvent;

		public const int InvalidAvatarItemID = 0;

		private static readonly List<AvatarItem> OPAIJGGLAJH;

		private Action<AvatarItem> MNDCGLPGFFB__BackingField;

		public readonly EEANDDJEMJC UnlockedAvatarItemsChangedEvent;

		private Dictionary<OutfitType, List<AvatarItem>> AILEEOMPGNA;

		private Dictionary<int, AvatarItem> PNOFAMPPFJK;

		private readonly HashSet<AvatarItem> JPACMELHHBN;

		private Dictionary<string, AvatarItem> GFMJINMEOFB;

		private Lazy<DCFGCHBJPOO> BBJDNEMJCIL;

		private readonly Dictionary<AvatarItem, AvatarItemMetadata> MJMPINMOCLJ;

		public AvatarFaceShapeVault FaceShapeVault;

		public FaceStyleSet FaceStyleSet;

		public AvatarBodyShapeVault BodyShapeVault;

		public SkinColorVault SkinColorVault;

		public HairColorVault HairColorVault;

		public HairPatternVault HairPatternVault;

		public HairPatternVault BeardPatternVault;

		[SerializeField]
		private GameObject outfitToolPrefab;

		[SerializeField]
		private OutfitToolUIControl outfitToolUIControlPrefab;

		[SerializeField]
		private PermanentHairDyeTool hairDyeToolPrefab;

		[SerializeField]
		private RecRoomAudioClip[] equipSounds;

		[SerializeField]
		private RecRoomAudioClip lockedOutfitToolClip;

		public PlayerAvatarDisplay debugDummyPrefab;

		[SerializeField]
		private byte[] stableHash;

		[SerializeField]
		private byte[] seed;

public IReadOnlyCollection<AvatarItem> UnlockedAvatarItems
{
get 		{
			return null;
		}

}

private DCFGCHBJPOO BFNHBAALLJH
{
get 		{
			return null;
		}

}

public RecRoomAudioClip[] EquipSounds
{
get 		{
			return null;
		}

}

public RecRoomAudioClip LockedOutfitToolClip
{
get 		{
			return null;
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

public event Action<AvatarItem> OnAvatarItemUnlocked {
add {
		}
remove {
		}
}

		public DIGIMEFFGDC GetBrowsableAvatarItem(AvatarItem JJCIIGBLIJF)
		{
			return null;
		}

		public DIGIMEFFGDC GetBrowsableAvatarItemByDesc(string ELDKAMCLDON)
		{
			return null;
		}

		public bool TryGetBrowsableAvatarItemByAvatarDesc(string ELDKAMCLDON, out DIGIMEFFGDC ONCGIPFNENB)
		{
			ONCGIPFNENB = null;
			return false;
		}

		public global::NCOKFFGPIJM<List<DIGIMEFFGDC>> GetBrowsableAvatarItemsByDesc(List<string> DALIJHKIMCD)
		{
			return null;
		}

		public global::NCOKFFGPIJM<IReadOnlyList<string>> GetFilteredAvatarItemDescs(string BGIIPFDGLHA, bool GCHINIIIGEN, DIGIMEFFGDC.DBKMGOBDOOH NKLHIJNJHAP, DIGIMEFFGDC.DBCAKOOBLMA PNEPPNKHMIM)
		{
			return null;
		}

		private void DBLCDNKJPKF(bool KJDHPOBBJON)
		{
		}

		private LAHBDKNMNHN JJKPEJMPAML()
		{
			return null;
		}

		private void NBFKGHIPBKK(AvatarItem JJCIIGBLIJF)
		{
		}

		private DIGIMEFFGDC OFFGLCNMGHB(AvatarItem JJCIIGBLIJF)
		{
			return null;
		}

		private void ECJAMONANCK(AvatarItem JJCIIGBLIJF, EOKBGGOAFLF OBIIENMBMLH)
		{
		}

		private void CKJIFBPLHFI(DIGIMEFFGDC IJOCDPJCPEK)
		{
		}

		private static DBFJJLIGAFA AKFJFFDGKBM(EOKBGGOAFLF OBIIENMBMLH)
		{
			return null;
		}

		private string OIKNJCANEMJ(string JMIFIJDBMNM)
		{
			return null;
		}

		private DOOBOJIHNDF IBLBMIPLPAH(string JMIFIJDBMNM)
		{
			return DOOBOJIHNDF.Common;
		}

		private bool PCJJEIJDKBO(string JMIFIJDBMNM)
		{
			return false;
		}

		private long? KLPBMGPJKFC(string JMIFIJDBMNM)
		{
			return null;
		}

		private int BNHKJNMLMBP(string JMIFIJDBMNM)
		{
			return 0;
		}

		private void BGEHJJHMINJ(List<string> FKAGAMPDIEK, DIGIMEFFGDC.DBKMGOBDOOH NKLHIJNJHAP)
		{
		}

		private void BKFELONFECH(List<string> ILJGHKGMILC, string BGIIPFDGLHA, bool GCHINIIIGEN, DIGIMEFFGDC.DBKMGOBDOOH NKLHIJNJHAP, DIGIMEFFGDC.DBCAKOOBLMA PNEPPNKHMIM)
		{
		}

		protected virtual void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void IDMJEDNPCAL(LINLOKECLME LNKODFBLOKJ)
		{
		}

		private void MPPGLLGJDPJ(LINLOKECLME GADDGJANIGG)
		{
		}

		public LAHBDKNMNHN DownloadDefaultAvatarItems()
		{
			return null;
		}

		public LAHBDKNMNHN DownloadUnlockedAvatarItems()
		{
			return null;
		}

		private global::NCOKFFGPIJM<List<EDDPDJCKOBH.JBANAMGBBAP>> HLBCOLFEKKK(List<EDDPDJCKOBH.JBANAMGBBAP> JDBHABEFGKF)
		{
			return null;
		}

		public global::NCOKFFGPIJM<List<EDDPDJCKOBH.JBANAMGBBAP>> DownloadLockedAvatarItemDetailsByDesc(List<string> DALIJHKIMCD)
		{
			return null;
		}

		private List<EDDPDJCKOBH.JBANAMGBBAP> CAKDOMNJAMI(IEnumerable<LINLOKECLME> NEOKALHDEAH)
		{
			return null;
		}

		private void GKEMHBPBOFO(List<EDDPDJCKOBH.JBANAMGBBAP> OPMEHLGGOOM)
		{
		}

		private void ILPHODAELOG(List<EDDPDJCKOBH.JBANAMGBBAP> JLMIFNPAILP, bool KJDHPOBBJON)
		{
		}

		private void OINMBMJFGHP(AvatarItem JJCIIGBLIJF, EDDPDJCKOBH.JBANAMGBBAP DFFBNKDGECN)
		{
		}

		private void AFMHLJCEEBG(AvatarItem JJCIIGBLIJF, EDDPDJCKOBH.JBANAMGBBAP GABIGIMCAPD)
		{
		}

		public global::NCOKFFGPIJM<bool> UnlockAvatarItemAndMarkNew(string ELDKAMCLDON, bool KDAEJFCMMFA = true)
		{
			return null;
		}

		public void AddAvatarItemToLookupCache(AvatarItem JJCIIGBLIJF)
		{
		}

		public bool TryGetAvatarItemFromId(int IPIBKPKEMNN, out AvatarItem JJCIIGBLIJF)
		{
			JJCIIGBLIJF = default;
			return false;
		}

		public void MarkNotNew(AvatarItem ONCGIPFNENB)
		{
		}

		public void MarkGiftPackageItemAvailable(string ELDKAMCLDON)
		{
		}

		public bool IsAvatarItemUnlocked(AvatarItem JJCIIGBLIJF)
		{
			return false;
		}

		public bool IsAvatarItemUnlocked(string ELDKAMCLDON)
		{
			return false;
		}

		public bool IsAvatarItemAlreadyPurchased(AvatarItem JJCIIGBLIJF)
		{
			return false;
		}

		public bool IsAvatarItemAlreadyPurchased(string ELDKAMCLDON)
		{
			return false;
		}

		public bool GetItemIsNew(AvatarItem ONCGIPFNENB)
		{
			return false;
		}

		public string GetItemFriendlyName(AvatarItem ONCGIPFNENB)
		{
			return null;
		}

		public string GetItemTooltip(AvatarItem ONCGIPFNENB)
		{
			return null;
		}

		public DOOBOJIHNDF GetItemRarity(AvatarItem ONCGIPFNENB)
		{
			return DOOBOJIHNDF.Common;
		}

		public List<string> GetItemTagList(AvatarItem ONCGIPFNENB)
		{
			return null;
		}

		public int GetItemAvatarItemId(AvatarItem ONCGIPFNENB)
		{
			return 0;
		}

		public AvatarItemMetadata GetItemMetadata(AvatarItem ONCGIPFNENB)
		{
			return null;
		}

		public bool TryGetItemThumbnail(AvatarItem ONCGIPFNENB, out string JEHAEBJGEIN)
		{
			JEHAEBJGEIN = null;
			return false;
		}

		private void GPHBOIFHDIL()
		{
		}

		public List<AvatarItemSelection> GetRandomUnlockedOutfit()
		{
			return null;
		}

		public List<AvatarItemSelection> GetRandomInitialOutfit(bool AHGAHMFCHBN = false)
		{
			return null;
		}

		public static bool TryGetRandomItem(IEnumerable<AvatarItem> AIGABOIEDPP, Func<AvatarItem, bool> HNGJGPJCNBJ, out AvatarItem MFMMFEMACAL)
		{
			MFMMFEMACAL = default;
			return false;
		}

		public bool TryGetRandomUnlockedItem(Func<AvatarItem, bool> HNGJGPJCNBJ, out AvatarItem MFMMFEMACAL)
		{
			MFMMFEMACAL = default;
			return false;
		}

		public bool TryGetDefaultTorsoItem(out AvatarItem ENBNPCNCADO, bool KEEGFBHMHHH = false)
		{
			ENBNPCNCADO = default;
			return false;
		}

		public bool TryGetDefaultLegsItem(out AvatarItem ENBNPCNCADO)
		{
			ENBNPCNCADO = default;
			return false;
		}

		public bool TryGetDefaultShoesItem(out AvatarItem ENBNPCNCADO)
		{
			ENBNPCNCADO = default;
			return false;
		}

		public AvatarBodyShape FindBodyShape(string AFNHHMKOGGL)
		{
			return null;
		}

		public AvatarFaceShape FindFaceShape(string ABLGCAHPLCD)
		{
			return null;
		}

		public AvatarCustomizationSettings GetRandomCustomizationSettings()
		{
			return null;
		}

		public ColorVault.DAKHANMKKFJ FindHairColor(string LEMGOHCPHLK, bool BBAJABKEECC = true)
		{
			return null;
		}

		public ColorVault.DAKHANMKKFJ FindSkinColor(string NBPODFFLIHF, bool BBAJABKEECC = true)
		{
			return null;
		}

		private ColorVault.DAKHANMKKFJ NCAAGNJJDAJ(ColorVault KDGMJKAPENH, string FINPDEFINEN, bool BBAJABKEECC = true)
		{
			return null;
		}

		public AvatarHairPattern FindHairPattern(string JMIFIJDBMNM, bool BBAJABKEECC = true)
		{
			return null;
		}

		public AvatarHairPattern FindBeardPattern(string JMIFIJDBMNM, bool BBAJABKEECC = true)
		{
			return null;
		}

		private AvatarHairPattern PMKGMBHEBKP(HairPatternVault KDGMJKAPENH, string JMIFIJDBMNM, bool BBAJABKEECC = true)
		{
			return null;
		}

		[CanBeNull]
		public OutfitTool SpawnOutfitToolForLocalPlayer(AvatarItem JJCIIGBLIJF, PlayerSpawnedEquipment.NHMNGDFJFCC LODOMOIPMIL)
		{
			return null;
		}

		[CanBeNull]
		public Tool SpawnHairDyeToolForLocalPlayer(string ILJHGJGEMDE, PlayerSpawnedEquipment.NHMNGDFJFCC LODOMOIPMIL)
		{
			return null;
		}

		public OutfitToolUIControl SpawnOutfitUIControl()
		{
			return null;
		}

		public void AppendToHash(IncrementalHash NDFMMDHCKFC)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<List<DIGIMEFFGDC>> EHLKPCIJJFD(List<EDDPDJCKOBH.JBANAMGBBAP> JDBHABEFGKF)
		{
			return null;
		}

		[CompilerGenerated]
		private void AFJBGGHAALK(FFGPLFHAGKC ACODBONBCFO)
		{
		}

		[CompilerGenerated]
		private void FKDJMIDMFII(List<EDDPDJCKOBH.JBANAMGBBAP> JNAAHMPCPAB)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<List<EDDPDJCKOBH.JBANAMGBBAP>> KGHACHHMFOC(List<EDDPDJCKOBH.JBANAMGBBAP> JDBHABEFGKF)
		{
			return null;
		}

		[CompilerGenerated]
		private void FPMALHNADAG(List<EDDPDJCKOBH.JBANAMGBBAP> JDBHABEFGKF)
		{
		}

		[CompilerGenerated]
		internal static bool OGPCCDBNGOF(AvatarItemData KHHGBBNODJN)
		{
			return false;
		}

		[CompilerGenerated]
		internal static bool JIACKBAHKNJ(AvatarItemData KHHGBBNODJN)
		{
			return false;
		}
	}
}
