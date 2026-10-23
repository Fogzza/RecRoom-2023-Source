using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using RecRoom.Utils.OverridableFields;
using UnityEngine;

namespace RecRoom.Systems.PlayerRoles
{
	[Serializable]
	public class GameRole : GOMIGOHHACK, global::AKONKDAAJPG<KLNOBKBCIEK, GameRole.EEGNMJMPIJJ, GameRole>, global::JCHALAAEDKN<KLNOBKBCIEK, GameRole.EEGNMJMPIJJ, GameRole>, global::NALCDCIGNGH<GameRole.EEGNMJMPIJJ>, global::DHKBMLGGKMJ<AIKGLCGDKBM, KLNOBKBCIEK>, ISerializationCallbackReceiver
	{
		public enum EEGNMJMPIJJ
		{
			INVALID = -1,
			TELEPORT_DELAY = 2,
			CAN_MOVE = 4,
			CAN_FLY = 8,
			IS_INVINCIBLE = 9,
			ITEM_PICKUP_RESTRICTIONS = 10,
			ITEM_PICKUP_ALLOWLIST = 11,
			ITEM_PICKUP_BLOCKLIST = 12,
			CAN_SWITCH_TEAMS = 13,
			MAX_TELEPORT_DISTANCE = 14,
			MAX_TELEPORT_DROP_HEIGHT = 15,
			VOICE_ROLLOFF_MAX_DISTANCE = 17,
			HIDES_NAME = 20,
			VR_WALK_SPEED = 21,
			VR_CAN_SPRINT = 22,
			SCREENS_WALK_SPEED = 24,
			SCREENS_CAN_SPRINT = 25,
			VR_CAN_JUMP = 28,
			VR_CAN_DODGE = 29,
			SCREENS_CAN_JUMP = 30,
			SCREENS_CAN_DODGE = 31,
			MAX_TELEPORT_ANGLE = 32,
			ENABLE_EQUIP_SLOT_HIP = 34,
			EQUIP_RESTRICTIONS_HIP = 35,
			EQUIP_HIP_ALLOWLIST = 36,
			EQUIP_HIP_BLOCKLIST = 37,
			EQUIP_RESTRICTIONS_SHOULDER = 39,
			EQUIP_SHOULDER_ALLOWLIST = 40,
			EQUIP_SHOULDER_BLOCKLIST = 41,
			SCREENS_DEFAULT_THIRD_PERSON_CONTROL_TYPE = 42,
			SCREENS_DEFAULT_FIRST_PERSON_CONTROL_TYPE = 43,
			VR_MAX_JUMP_HEIGHT = 44,
			SCREENS_MAX_JUMP_HEIGHT = 45,
			SCREENS_CAN_WALL_RUN = 48,
			VR_CAN_WALL_RUN = 49,
			VR_CAN_GET_PUSHED = 50,
			SCREENS_CAN_GET_PUSHED = 51,
			VR_CAN_RAM = 52,
			SCREENS_CAN_RAM = 53,
			VR_SPRINT_MAX_SPEED_WALK_SPEED_MULTIPLIER = 55,
			SCREENS_SPRINT_MAX_SPEED_WALK_SPEED_MULTIPLIER = 56,
			CAN_ALWAYS_SPRINT = 57,
			AIR_CONTROL_PARAMETER = 58,
			CAN_JUMP_CUTOFF = 59,
			CAN_CLAMBER = 60,
			WALL_RUN_DURATION = 61,
			WALL_RUN_DROP_RATE_PARAMETER = 62,
			WALL_RUN_START_SPEED_BOOST = 63,
			WALL_RUN_JUMP_HEIGHT = 64,
			WALL_RUN_JUMP_DIRECTION_PARAMETER = 65,
			WALL_RUN_JUMP_AIR_CONTROL_MULTIPLIER = 66,
			CAN_SLIDE = 67,
			CAN_SLIDE_DOWN_SLOPES = 68,
			SLIDE_MIN_DURATION = 69,
			SLIDE_STEERING_PARAMETER = 70,
			SLIDE_START_SPEED_BOOST = 71,
			SLIDE_AIR_CONTROL_MULTIPLIER = 72,
			CAN_WALL_CLIMB = 73,
			HIDES_AVATAR = 75,
			PLAYER_TAGS = 76,
			ADD_PLAYER_TAGS = 77,
			REMOVE_PLAYER_TAGS = 78,
			CAN_USE_MAKER_PEN = 80,
			CAN_SAVE_INVENTIONS = 81,
			CAN_SPAWN_INVENTIONS = 82,
			CAN_USE_ROOM_RESET_BUTTON = 83,
			CAN_USE_DELETE_ALL_BUTTON = 84,
			CREATION_RESTRICTIONS_APPLY = 85,
			CAN_CREATE_ROLE_ASSIGNMENT_CHIPS = 86,
			CAN_USE_PLAY_GIZMOS_TOGGLE = 87
		}

		public const int ROLE_VERSION = 33;

		[CompilerGenerated]
		private global::MDHJCOEBDEN<EEGNMJMPIJJ> OnRolePermissionUpdated;

		public static Dictionary<EEGNMJMPIJJ, string> FriendlyNames;

		[NonSerialized]
		private Guid roleGuid;

		[SerializeField]
		private KLNOBKBCIEK roleId;

		[SerializeField]
		private KLKONHGPFBD rank;

		[SerializeField]
		private string roleName;

		private string lowerRoleName;

		[SerializeField]
		private MutableOverridableObscuredFloat teleportDelay;

		[SerializeField]
		private MutableOverridableObscuredBool canMove;

		[SerializeField]
		private MutableOverridableObscuredFloat vrWalkSpeed;

		[SerializeField]
		private MutableOverridableObscuredBool vrCanSprint;

		[SerializeField]
		private MutableOverridableObscuredFloat vrSprintMaxSpeedWalkSpeedMultiplier;

		[SerializeField]
		private MutableOverridableObscuredBool vrCanJump;

		[SerializeField]
		private MutableOverridableObscuredFloat vrMaxJumpHeight;

		[SerializeField]
		private MutableOverridableObscuredBool vrCanDodge;

		[SerializeField]
		private MutableOverridableObscuredInt screensDefaultThirdPersonControlType;

		[SerializeField]
		private MutableOverridableObscuredFloat screensWalkSpeed;

		[SerializeField]
		private MutableOverridableObscuredBool screensCanSprint;

		[SerializeField]
		private MutableOverridableObscuredFloat screensSprintMaxSpeedWalkSpeedMultiplier;

		[SerializeField]
		private MutableOverridableObscuredBool screensCanJump;

		[SerializeField]
		private MutableOverridableObscuredFloat screensMaxJumpHeight;

		[SerializeField]
		private MutableOverridableObscuredBool screensCanDodge;

		[SerializeField]
		private MutableOverridableObscuredFloat maxTeleportDistance;

		[SerializeField]
		private MutableOverridableObscuredFloat maxTeleportDropHeight;

		[SerializeField]
		private MutableOverridableObscuredFloat maxTeleportAngle;

		[SerializeField]
		private MutableOverridableObscuredBool canFly;

		[SerializeField]
		private MutableOverridableObscuredBool isInvincible;

		[SerializeField]
		private MutableOverridablePickupRestrictionType itemPickupRestrictions;

		[SerializeField]
		private MutableOverridableListObscuredString itemPickupAllowlist;

		[SerializeField]
		private MutableOverridableListObscuredString itemPickupBlocklist;

		[SerializeField]
		private MutableOverridableObscuredBool canSwitchTeams;

		[SerializeField]
		private MutableOverridableObscuredInt voiceRolloffMaxDistance;

		[SerializeField]
		private MutableOverridableObscuredBool hidesName;

		[SerializeField]
		private MutableOverridableEquipSlotRestrictionType enableEquipSlotHip;

		[SerializeField]
		private MutableOverridablePickupRestrictionType equipRestrictionsHip;

		[SerializeField]
		private MutableOverridableListObscuredString equipHipAllowlist;

		[SerializeField]
		private MutableOverridableListObscuredString equipHipBlocklist;

		[SerializeField]
		private MutableOverridablePickupRestrictionType equipRestrictionsShoulder;

		[SerializeField]
		private MutableOverridableListObscuredString equipShoulderAllowlist;

		[SerializeField]
		private MutableOverridableListObscuredString equipShoulderBlocklist;

		[SerializeField]
		private MutableOverridableObscuredInt screensDefaultFirstPersonControlType;

		[SerializeField]
		private MutableOverridableObscuredBool screensCanWallRun;

		[SerializeField]
		private MutableOverridableObscuredBool vrCanWallRun;

		[SerializeField]
		private MutableOverridableObscuredBool vrCanGetPushed;

		[SerializeField]
		private MutableOverridableObscuredBool screensCanGetPushed;

		[SerializeField]
		private MutableOverridableObscuredBool vrCanRam;

		[SerializeField]
		private MutableOverridableObscuredBool screensCanRam;

		[SerializeField]
		private MutableOverridableObscuredBool canAlwaysSprint;

		[SerializeField]
		private MutableOverridableObscuredFloat airControlParameter;

		[SerializeField]
		private MutableOverridableObscuredBool canJumpCutoff;

		[SerializeField]
		private MutableOverridableObscuredBool canClamber;

		[SerializeField]
		private MutableOverridableObscuredFloat wallRunDuration;

		[SerializeField]
		private MutableOverridableObscuredFloat wallRunDropRateParameter;

		[SerializeField]
		private MutableOverridableObscuredFloat wallRunStartSpeedBoost;

		[SerializeField]
		private MutableOverridableObscuredFloat wallRunJumpHeight;

		[SerializeField]
		private MutableOverridableObscuredFloat wallRunJumpDirectionParameter;

		[SerializeField]
		private MutableOverridableObscuredFloat wallRunJumpAirControlMultiplier;

		[SerializeField]
		private MutableOverridableObscuredBool canSlide;

		[SerializeField]
		private MutableOverridableObscuredBool canSlideDownSlopes;

		[SerializeField]
		private MutableOverridableObscuredFloat slideMinDuration;

		[SerializeField]
		private MutableOverridableObscuredFloat slideSteeringParameter;

		[SerializeField]
		private MutableOverridableObscuredFloat slideStartSpeedBoost;

		[SerializeField]
		private MutableOverridableObscuredFloat slideAirControlMultiplier;

		[SerializeField]
		private MutableOverridableObscuredBool canWallClimb;

		[SerializeField]
		private MutableOverridableObscuredBool hidesAvatar;

		[SerializeField]
		private MutableOverridableListObscuredString playerTags;

		[SerializeField]
		private MutableOverridableObscuredBool addPlayerTags;

		[SerializeField]
		private MutableOverridableObscuredBool removePlayerTags;

		[SerializeField]
		private MutableOverridableObscuredBool creationRestrictionsApply;

		[SerializeField]
		private MutableOverridableDefaultableObscuredBool canUseMakerPen;

		[SerializeField]
		private MutableOverridableDefaultableObscuredBool canSaveInventions;

		[SerializeField]
		private MutableOverridableDefaultableObscuredBool canSpawnInventions;

		[SerializeField]
		private MutableOverridableDefaultableObscuredBool canUseRoomResetButton;

		[SerializeField]
		private MutableOverridableDefaultableObscuredBool canUseDeleteAllButton;

		[SerializeField]
		private MutableOverridableObscuredBool canCreateRoleAssignmentChips;

		[SerializeField]
		private MutableOverridableDefaultableObscuredBool canUsePlayGizmosToggle;

 bool global::GOMIGOHHACK.LCJHJDDHJKH
{
get => RecRoom_002ESystems_002EPlayerRoles_002EICreatorRole_002Eget_CreatorRoleCanUseMakerPen();
}

 bool global::GOMIGOHHACK.GLLAPDCJDAK
{
get => RecRoom_002ESystems_002EPlayerRoles_002EICreatorRole_002Eget_CreatorRoleCanSaveInventions();
}

 bool global::GOMIGOHHACK.NIEBHFGLGAG
{
get => RecRoom_002ESystems_002EPlayerRoles_002EICreatorRole_002Eget_CreatorRoleCanSpawnInventions();
}

 bool global::GOMIGOHHACK.IBNCKMIGEAP
{
get => RecRoom_002ESystems_002EPlayerRoles_002EICreatorRole_002Eget_CreatorRoleCanUseRoomResetButton();
}

 bool global::GOMIGOHHACK.HCBOMENMHIO
{
get => RecRoom_002ESystems_002EPlayerRoles_002EICreatorRole_002Eget_CreatorRoleCanUseDeleteAllButton();
}

 bool global::GOMIGOHHACK.KDLGKCDIAAE
{
get => RecRoom_002ESystems_002EPlayerRoles_002EICreatorRole_002Eget_CreatorRoleCanUsePlayGizmosToggle();
}

		public Guid RoleGuid
		{
			get
			{
				return default;
			}
			set
			{
			}
		}

		public KLNOBKBCIEK RoleId
		{
			get
			{
				return KLNOBKBCIEK.AG_EVERYONE;
			}
			private set
			{
			}
		}

		public bool CanMoveRole => false;

		public KLKONHGPFBD RoleRank
		{
			get
			{
				return KLKONHGPFBD.AG_BOTTOM_RANK_1;
			}
			set
			{
			}
		}

		public string RoleName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string LowerRoleName => null;

		public global::PKKINNENDEC<ObscuredFloat> TeleportDelay => null;

		public global::PKKINNENDEC<ObscuredBool> CanMove => null;

		public global::PKKINNENDEC<ObscuredFloat> VrWalkSpeed => null;

		public global::PKKINNENDEC<ObscuredBool> VrCanSprint => null;

		public global::PKKINNENDEC<ObscuredFloat> VrSprintMaxSpeedWalkSpeedMultiplier => null;

		public global::PKKINNENDEC<ObscuredBool> VrCanJump => null;

		public global::PKKINNENDEC<ObscuredFloat> VrMaxJumpHeight => null;

		public global::PKKINNENDEC<ObscuredBool> VrCanDodge => null;

		public global::PKKINNENDEC<ObscuredInt> ScreensDefaultThirdPersonControlType => null;

		public global::PKKINNENDEC<ObscuredFloat> ScreensWalkSpeed => null;

		public global::PKKINNENDEC<ObscuredBool> ScreensCanSprint => null;

		public global::PKKINNENDEC<ObscuredFloat> ScreensSprintMaxSpeedWalkSpeedMultiplier => null;

		public global::PKKINNENDEC<ObscuredBool> ScreensCanJump => null;

		public global::PKKINNENDEC<ObscuredFloat> ScreensMaxJumpHeight => null;

		public global::PKKINNENDEC<ObscuredBool> ScreensCanDodge => null;

		public global::PKKINNENDEC<ObscuredFloat> MaxTeleportDistance => null;

		public global::PKKINNENDEC<ObscuredFloat> MaxTeleportDropHeight => null;

		public global::PKKINNENDEC<ObscuredFloat> MaxTeleportAngle => null;

		public global::PKKINNENDEC<ObscuredBool> CanFly => null;

		public global::PKKINNENDEC<ObscuredBool> IsInvincible => null;

		public global::PKKINNENDEC<ObscuredRolePickupRestrictionType> ItemPickupRestrictions => null;

		public global::PKKINNENDEC<List<ObscuredString>> ItemPickupAllowlist => null;

		public global::PKKINNENDEC<List<ObscuredString>> ItemPickupBlocklist => null;

		public global::PKKINNENDEC<ObscuredBool> CanSwitchTeams => null;

		public global::PKKINNENDEC<ObscuredInt> VoiceRolloffMaxDistance => null;

		public global::PKKINNENDEC<ObscuredBool> HidesName => null;

		public global::PKKINNENDEC<ObscuredHipSlotEnableMode> EnableEquipSlotHip => null;

		public global::PKKINNENDEC<ObscuredRolePickupRestrictionType> EquipRestrictionsHip => null;

		public global::PKKINNENDEC<List<ObscuredString>> EquipHipAllowlist => null;

		public global::PKKINNENDEC<List<ObscuredString>> EquipHipBlocklist => null;

		public global::PKKINNENDEC<ObscuredRolePickupRestrictionType> EquipRestrictionsShoulder => null;

		public global::PKKINNENDEC<List<ObscuredString>> EquipShoulderAllowlist => null;

		public global::PKKINNENDEC<List<ObscuredString>> EquipShoulderBlocklist => null;

		public global::PKKINNENDEC<ObscuredInt> ScreensDefaultFirstPersonControlType => null;

		public global::PKKINNENDEC<ObscuredBool> ScreensCanWallRun => null;

		public global::PKKINNENDEC<ObscuredBool> VrCanWallRun => null;

		public global::PKKINNENDEC<ObscuredBool> VrCanGetPushed => null;

		public global::PKKINNENDEC<ObscuredBool> ScreensCanGetPushed => null;

		public global::PKKINNENDEC<ObscuredBool> VrCanRam => null;

		public global::PKKINNENDEC<ObscuredBool> ScreensCanRam => null;

		public global::PKKINNENDEC<ObscuredBool> CanAlwaysSprint => null;

		public global::PKKINNENDEC<ObscuredFloat> AirControlParameter => null;

		public global::PKKINNENDEC<ObscuredBool> CanJumpCutoff => null;

		public global::PKKINNENDEC<ObscuredBool> CanClamber => null;

		public global::PKKINNENDEC<ObscuredFloat> WallRunDuration => null;

		public global::PKKINNENDEC<ObscuredFloat> WallRunDropRateParameter => null;

		public global::PKKINNENDEC<ObscuredFloat> WallRunStartSpeedBoost => null;

		public global::PKKINNENDEC<ObscuredFloat> WallRunJumpHeight => null;

		public global::PKKINNENDEC<ObscuredFloat> WallRunJumpDirectionParameter => null;

		public global::PKKINNENDEC<ObscuredFloat> WallRunJumpAirControlMultiplier => null;

		public global::PKKINNENDEC<ObscuredBool> CanSlide => null;

		public global::PKKINNENDEC<ObscuredBool> CanSlideDownSlopes => null;

		public global::PKKINNENDEC<ObscuredFloat> SlideMinDuration => null;

		public global::PKKINNENDEC<ObscuredFloat> SlideSteeringParameter => null;

		public global::PKKINNENDEC<ObscuredFloat> SlideStartSpeedBoost => null;

		public global::PKKINNENDEC<ObscuredFloat> SlideAirControlMultiplier => null;

		public global::PKKINNENDEC<ObscuredBool> CanWallClimb => null;

		public global::PKKINNENDEC<ObscuredBool> HidesAvatar => null;

		public global::PKKINNENDEC<List<ObscuredString>> PlayerTags => null;

		public global::PKKINNENDEC<ObscuredBool> AddPlayerTags => null;

		public global::PKKINNENDEC<ObscuredBool> RemovePlayerTags => null;

		public global::PKKINNENDEC<ObscuredBool> CreationRestrictionsApply => null;

		public global::NEDFGPMADJN<ObscuredBool> CanUseMakerPen => null;

		public global::NEDFGPMADJN<ObscuredBool> CanSaveInventions => null;

		public global::NEDFGPMADJN<ObscuredBool> CanSpawnInventions => null;

		public global::NEDFGPMADJN<ObscuredBool> CanUseRoomResetButton => null;

		public global::NEDFGPMADJN<ObscuredBool> CanUseDeleteAllButton => null;

		public global::PKKINNENDEC<ObscuredBool> CanCreateRoleAssignmentChips => null;

		public global::NEDFGPMADJN<ObscuredBool> CanUsePlayGizmosToggle => null;

		public bool IsRoleActive { get; set; }

		public bool IsModifiedByPlayer { get; private set; }

public event global::MDHJCOEBDEN<EEGNMJMPIJJ> KHAIHIGFJHC {
add {
		}
remove {
		}
}

		private bool RecRoom_002ESystems_002EPlayerRoles_002EICreatorRole_002Eget_CreatorRoleCanUseMakerPen()
		{
			return false;
		}

		private bool RecRoom_002ESystems_002EPlayerRoles_002EICreatorRole_002Eget_CreatorRoleCanSaveInventions()
		{
			return false;
		}

		private bool RecRoom_002ESystems_002EPlayerRoles_002EICreatorRole_002Eget_CreatorRoleCanSpawnInventions()
		{
			return false;
		}

		private bool RecRoom_002ESystems_002EPlayerRoles_002EICreatorRole_002Eget_CreatorRoleCanUseRoomResetButton()
		{
			return false;
		}

		private bool RecRoom_002ESystems_002EPlayerRoles_002EICreatorRole_002Eget_CreatorRoleCanUseDeleteAllButton()
		{
			return false;
		}

		private bool RecRoom_002ESystems_002EPlayerRoles_002EICreatorRole_002Eget_CreatorRoleCanUsePlayGizmosToggle()
		{
			return false;
		}

		public GameRole()
		{
		}

		public GameRole(KLNOBKBCIEK KLBONOOHBND, GameRole OEJILPJHPPG = null, string EOJDBMEHCOF = null)
		{
		}

		public void PAKIMOKGMBI()
		{
		}

		public GameRole JGMLMOAPKAE(GameRole LLCICIBAEOC)
		{
			return null;
		}

		public void AFBHGNPCPMD(GameRole OEJILPJHPPG)
		{
		}

		public void IEAIPAAIHLM()
		{
		}

		public void OECNDDFGMPC()
		{
		}

		public byte[] EEMIIKLNPEK(EEGNMJMPIJJ HEGLKMIJHAM, bool FMMJFLMIBAO, object NKBIKBGEKGL)
		{
			return null;
		}

		public void IODABDBJNCA(EEGNMJMPIJJ HEGLKMIJHAM, byte[] IHBEKCJNCDP)
		{
		}

		public DCNHFDCKKPN BNFBODLMNKB(EEGNMJMPIJJ HEGLKMIJHAM)
		{
			return null;
		}

		public void AGCLNMICBDA(string EOJDBMEHCOF)
		{
		}

		public AIKGLCGDKBM EIEJLKMEIMJ()
		{
			return null;
		}

		public void GDDPOGDKNED(AIKGLCGDKBM OHCKIKAFICK, KLNOBKBCIEK? GEGBGOBCJPE = null)
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
