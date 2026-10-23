using System;
using System.Collections.Generic;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Avatars;
using RecRoom.Avatars.Data.Runtime;
using RecRoom.Avatars.Data.Shared;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerAvatar : MonoBehaviourPun
{
	private sealed class COABHIAHIBB
	{
		public List<AvatarItemSelection> displayedItems;

		public PlayerAvatar _003C_003E4__this;

		internal bool _003CGetDisplayedItems_003Eg__IsSlotAvailableToDisplaySelection_007C0(AvatarItemSelection selection)
		{
			return false;
		}
	}

	private sealed class FPDLLAOIDFF
	{
		public PlayerAvatar _003C_003E4__this;

		public AvatarItem item;

		public AvatarItemSidednessEquipType sidednessEquipType;

		internal void _003CLocalEquipOutfitItemAndLoadHatData_003Eb__0()
		{
		}
	}

	public readonly EEANDDJEMJC SyncedPlayerAvatarChangedEvent;

	public static readonly global::HHOBPMOCKMJ<AvatarItemSelection> LocalPlayerEquippedAvatarItemEvent;

	public static readonly global::HHOBPMOCKMJ<AvatarItemSelection> LocalPlayerRemovedAvatarItemEvent;

	[SerializeField]
	private PlayerAvatarDisplay playerAvatarDisplay;

	[SerializeField]
	private Player player;

	[SerializeField]
	private PlayerAvatarFullBodyColliders playerAvatarFullBodyColliders;

	private global::EHOCIICLNGN<JHHDMDHLNGF> HBDDFPJAEEJ;

	private DCFGCHBJPOO BBJDNEMJCIL;

	private global::ADOKDOGIPIF<DCLIAIDLPOI> MHJLONPFIBG;

	private HHNIABKALDA JOJGDHBJCGL;

	[SerializeField]
	public GameObject[] floatingBeanObjects;

	[SerializeField]
	private AvatarSystemConfiguration avatarSystemConfiguration;

	[SerializeField]
	private Transform headIKEffector;

	[SerializeField]
	private Transform leftHandIKEffector;

	[SerializeField]
	private Transform rightHandIKEffector;

	private BBMELDINOFF BMBAEOKOGML;

	private LCKALFBDOEC LKPIKHHNKBD;

	[NonSerialized]
	public bool TeamOutfitColorEmissionEnabled;

	[NonSerialized]
	public float TeamOutfitColorEmissionAmount;

	private Color? GHHFOHBLGIE;

	private bool FBLJHFIBIAE;

	private Player.JLLGKBEJLOF KFOHEAEIHOC;

private DCFGCHBJPOO BFNHBAALLJH
{
get 	{
		return null;
	}

}

public DCLIAIDLPOI SyncedOutfitData
{
get 	{
		return null;
	}

private set {
	}
}

public bool UsesFullBodyAvatar
{
get 	{
		return false;
	}

}

private bool HMBFBAMHKDB
{
get 	{
		return false;
	}

}

public ColorVault.DAKHANMKKFJ HairPrimaryColor
{
get 	{
		return null;
	}

}

public ColorVault.DAKHANMKKFJ HairSecondaryColor
{
get 	{
		return null;
	}

}

public AvatarHairPattern HairPattern
{
get 	{
		return null;
	}

}

public ColorVault.DAKHANMKKFJ BeardPrimaryColor
{
get 	{
		return null;
	}

}

public ColorVault.DAKHANMKKFJ BeardSecondaryColor
{
get 	{
		return null;
	}

}

public AvatarHairPattern BeardPattern
{
get 	{
		return null;
	}

}

public ColorVault.DAKHANMKKFJ SkinColor
{
get 	{
		return null;
	}

}

public AvatarCustomizationSettings CustomizationSettings
{
get 	{
		return null;
	}

}

public List<AvatarItemSelection> PlayerSelectedOutfitItems
{
get 	{
		return null;
	}

}

public PlayerAvatarDisplay PlayerAvatarDisplay
{
get 	{
		return null;
	}

}

public BBMELDINOFF AvatarSystem
{
get 	{
		return null;
	}

}

public Color? TeamColor
{
get 	{
		return null;
	}

set {
	}
}

private bool AMBDJGGCAOE
{
get 	{
		return this.FBLJHFIBIAE;
	}

set {
	}
}

	public HHNIABKALDA GetDisplayedAvatarCopy()
	{
		return null;
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

	private void OAPJBNLEIPN(HHNIABKALDA APMFKLPFADE)
	{
	}

	private void BHBMEMGHLHM(HHNIABKALDA APMFKLPFADE)
	{
	}

	private void KMGFFHHHAGF()
	{
	}

	public void RebuildDisplayedMeshes(bool BBEMADABGJF = false)
	{
	}

	public List<AvatarItemSelection> GetDisplayedItems()
	{
		return null;
	}

	private bool BAFLPJPFHIG()
	{
		return false;
	}

	private void HJDMAGHEABK(PlayerVisualSettings GOBLPOPFLAJ)
	{
	}

	private void KKEJPKICMPO()
	{
	}

	private void EDMJBNMHGDH()
	{
	}

	public void SetDefaultItemOutfitFilter(Player.JLLGKBEJLOF EICNLGCAONF)
	{
	}

	public void ApplyLocalPlayerDyeTool(ColorVault.DAKHANMKKFJ HMCAFGCGFJF)
	{
	}

	public void LocalEquipOutfitItemAndLoadHatData(AvatarItem ONCGIPFNENB, AvatarItemSidednessEquipType FFAINMOOEOO = AvatarItemSidednessEquipType.Both)
	{
	}

	public void LocalEquipOutfitItemWithHatData(AvatarItem ONCGIPFNENB, AvatarItemSidednessEquipType FFAINMOOEOO = AvatarItemSidednessEquipType.Both, CLMEHHLKBJG NHCODCCFGBB = null, AnchorParams NMOONADGDFD = default(AnchorParams))
	{
	}

	private void ENILFHJFDGJ(LINLOKECLME LNKODFBLOKJ)
	{
	}

	private void OKHAEMMEJHG(LINLOKECLME LNKODFBLOKJ)
	{
	}

	private void GOEOGPLPCGK(Guid JGNABAMMKMP, bool JKCLPJJENFN = false)
	{
	}

	public void LocalUnequipOutfitItemAndReplaceWithLastSavedItem(AvatarItem EKPAHKBCOMI)
	{
	}

	public void LocalRevertAvatarItemsAndDyeColor(List<AvatarItem> MEJBBHFPCNJ, ColorVault.DAKHANMKKFJ PIKFCBPOHAB, HHNIABKALDA DMCAPLCFEMM = null)
	{
	}

	private void PPHNJJIOCHN(RecRoomAudioClip[] OLNLFLGIDJH, Player.NBPIPAJOGLC MKLOBAIKINA)
	{
	}

	public bool IsWearing(AvatarItem ONCGIPFNENB, Player.NBPIPAJOGLC? MKLOBAIKINA = null)
	{
		return false;
	}
}
