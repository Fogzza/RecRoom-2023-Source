using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Tools
{
	public class MakerPenAudioContent : ScriptableObject
	{
		public RecRoomAudioClip ExitEditModeSfx;

		public RecRoomAudioClip[] createObjectSfx;

		public DynamicAudioLoopContent shapeCreationAudioLoop;

		public DynamicAudioLoopContent curveExtrusionAudioLoop;

		public RecRoomAudioClip[] deleteObjectSfx;

		public RecRoomAudioClip[] cloneObjectSfx;

		public RecRoomAudioClip hoverObjectSfx;

		public RecRoomAudioClip selectObjectSfx;

		public RecRoomAudioClip deselectObjectSfx;

		public DynamicAudioLoopContent moveObjectAudioLoop;

		public DynamicAudioLoopContent rotateObjectAudioLoop;

		public DynamicAudioLoopContent scaleObjectAudioLoop;

		public RecRoomAudioClip[] pickupWithMakerPenSfx;

		public RecRoomAudioClip[] releaseWithMakerPenSfx;

		public RecRoomAudioClip xAxisHoverSfx;

		public RecRoomAudioClip yAxisHoverSfx;

		public RecRoomAudioClip zAxisHoverSfx;

		public RecRoomAudioClip xyPlaneHoverSfx;

		public RecRoomAudioClip xzPlaneHoverSfx;

		public RecRoomAudioClip yzPlaneHoverSfx;

		public RecRoomAudioClip multiAxisHoverSfx;

		public RecRoomAudioClip[] recolorObjectSfx;

		public RecRoomAudioClip[] genericChangeMaterialSfx;

		public MaterialChangeAudioClip[] specificMaterialChangeSfx;

		public DynamicAudioLoopContent wiringAudioLoop;

		public RecRoomAudioClip wiringCanceledSfx;

		public RecRoomAudioClip wiringConnectSfx;

		public RecRoomAudioClip wiringConnect2DSfx;

		public RecRoomAudioClip wiringConnectFailedSfx;

		public RecRoomAudioClip wiringDisconnectSfx;

		public RecRoomAudioClip wiringDisconnect2DSfx;

		public RecRoomAudioClip freezeObjectSfx;

		public RecRoomAudioClip unfreezeObjectSfx;

		public RecRoomAudioClip[] gridSnapTickSfx;

		public RecRoomAudioClip roomSaveSuccessSfx;
	}
}
