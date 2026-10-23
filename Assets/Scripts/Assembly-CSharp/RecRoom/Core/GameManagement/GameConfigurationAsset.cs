using RecRoom.DataStructures;
using RecRoom.Tools;
using UnityEngine;

namespace RecRoom.Core.GameManagement
{
	[CreateAssetMenu]
	public class GameConfigurationAsset : ScriptableObject
	{
		public string Name;

		public int LoadPriority;

		public GameStartRequirement ManualGameStartRequirement;

		public bool AutomaticGameStartSupported;

		public GameStartRequirement AutomaticGameStartRequirement;

		public bool PreGameVoiceOverSupported;

		public bool ResultsVoiceOverSupported;

		public bool CountdownVoiceOverSupported;

		public bool GameModeNotificationsSupported;

		public bool InGamePlayerNotificationsSupported;

		public bool EndGameWhenAllDead;

		public float GameStartDelay;

		public float EndGameResultsDuration;

		public bool RespawnOnGameStartSupported;

		public bool RespawnOnGameEndSupported;

		public bool JoinInProgressSupported;

		public bool ReloadInstanceAfterPostgameResults;

		public TeamConfiguration[] TeamConfigurations;

		public KMNCAMFDLFN TeamSelectionMethod;

		public bool EndGameIfStartRequirementsNotMet;

		public bool ExplicitTeamSelectionSupported;

		public bool GameRunningTeamChangeSupported;

		public bool RespawnOnGameRunningTeamChangeSupported;

		public bool SpectatingSupported;

		public bool ShowOpenSlotsOnScoreboard;

		public bool ClearTeamsAfterGame;

		public PlayerVisualSettings TeamPlayerVisualSettings;

		public bool TeamRadioSupported;

		public bool TeamRadioCrossteamSupported;

		public TeamRadioSettings TeamRadioSettings;

		public StatConfiguration[] StatConfigurations;

		public bool PersistStatsOnGameStart;

		public int MaxHealth;

		public int MaxShield;

		public bool SuppressWeaponDamage;

		public bool SuppressAllDamageToPlayer;

		public bool EnemiesIgnoreSpectators;

		public bool AutoHealSupported;

		public AutoHealSettings AutoHealSettings;

		public bool DownButNotOutSupported;

		public DownButNotOutSettings DownButNotOutSettings;

		public bool AutoRespawnSupported;

		public RespawnSettings RespawnSettings;

		public GameCombatManager.KIIMEBDDPIK ReviveMode;

		public ReviveSettings ReviveSettings;

		public bool HUDSupported;

		public FriendlyFireSettings FriendlyFireSettings;

		public PlayerCombatUISettings PlayerCombatUISettings;

		public EnemyCombatUISettings EnemyCombatUISettings;

		public bool DeadMonochromeEffectSupported;

		public bool DownButNotOutMonochromeEffectSupported;

		public bool DamageRedFlashEffectSupported;

		public bool DefaultHitFeedbackSupported;

		public bool DefaultReviveFeedbackSupported;

		public bool DefaultDownedOpponentFeedbackSupported;

		public bool DefaultDownedLocalPlayerFeedbackSupported;

		public bool DefaultDownedTeammateFeedbackSupported;

		public bool DeadPersistentNotificationSupported;

		public LNJAPFIKKCO SpawnPointSelectionMethod;

		public SerializedGuid MainHandToolId;

		public SerializedGuid OffHandToolId;

		public bool ResetToolsOnGameStartSupported;

		public ToolEntity.PFINPDKHKEP BrokenToolBehavior;

		public bool EquipmentBeaconsSupported;

		public bool WeaponInfiniteAmmoSupported;

		public bool TeleportBufferDistanceRetricted;

		public bool OutOfBoundsSupported;

		public bool OutOfBoundsSpectatorsSupported;

		public bool DownOutOfBoundsPlayers;

		public float OutOfBoundsGracePeriod;

		public float OutOfBoundsMaxDuration;

		public JBGFOIKBKED MainHandTool => JBGFOIKBKED.AC_UNIT;

		public JBGFOIKBKED OffHandTool => JBGFOIKBKED.AC_UNIT;

		public NDDHEBMNPCF HMAMCNGCJOH()
		{
			return null;
		}

		public void JDJNIKONDHF(NDDHEBMNPCF PCPEJHIMHJJ)
		{
		}
	}
}
