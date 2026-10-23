using System;
using RecRoom.Audio;
using UnityEngine;

[Serializable]
public class DefaultAudioConfig : ScriptableObject
{
	public RecRoomAudioClip GameOnVO;

	public RecRoomAudioClip GameOverVO;

	public RecRoomAudioClip GameOverSFX;

	public RecRoomAudioClip GameTieVO;

	public RecRoomAudioClip YouWinVO;

	public RecRoomAudioClip YouLoseVO;

	public RecRoomAudioClip OneMinuteRemainingVO;

	public RecRoomAudioClip TenSecondsRemainingVO;

	public RecRoomAudioClip FiveSecondsRemainingVO;

	public RecRoomAudioClip FourSecondsRemainingVO;

	public RecRoomAudioClip ThreeSecondsRemainingVO;

	public RecRoomAudioClip TwoSecondsRemainingVO;

	public RecRoomAudioClip OneSecondRemainingVO;

	public RecRoomAudioClip WaitingForPlayersOnePlayerVO;

	public RecRoomAudioClip WaitingForPlayersTwoPlayersVO;

	public RecRoomAudioClip WaitingForPlayersThreePlayersVO;

	public RecRoomAudioClip WaitingForPlayersFourPlayersVO;

	public RecRoomAudioClip YouHaveCreatedACustomRoomVO;

	public RecRoomAudioClip CanNameAndPublishViaThisRoom;

	public RecRoomAudioClip GameReadyToStartVO;

	public RecRoomAudioClip GameReadyToStartReminderVO;

	public RecRoomAudioClip ToolPickupSFX;

	public RecRoomAudioClip[] ActivityTitleJingleSFX;

	public RecRoomAudioClip[] PlayerEventTitleJingleSFX;
}
