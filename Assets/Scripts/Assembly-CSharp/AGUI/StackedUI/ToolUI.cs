using RecRoom.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public class ToolUI : StackedUIBase
	{
		[SerializeField]
		protected RecRoomAudioClip buttonDownAudio;

		[SerializeField]
		protected RecRoomAudioClip buttonUpAudio;

		[SerializeField]
		private RecRoomAudioClip menuOpenedAudio;

		[SerializeField]
		private BoxCollider menuBoxCollider;

		private Tool GAPEICCMANI;

		[SerializeField]
		private BasicInteractionRestriction basicInteractionRestriction;

		[SerializeField]
		private Image backgroundImage;

		[SerializeField]
		private bool GoToHomeScreenOnClose;

		private Material MMBCJODDBEN;

		private bool DOACIEGIINE;

		private SFXAudioSource EKHEADENGMK;

public BoxCollider MenuBoxCollider
{
get 		{
			return null;
		}

}

public Tool Tool
{
get 		{
			return null;
		}

set {
		}
}

public BasicInteractionRestriction BasicInteractionRestriction
{
get 		{
			return null;
		}

}

public bool Locked
{
get 		{
			return false;
		}

set {
		}
}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void SetBackgroundColors(Color PJELODKNJIN, Color GDNDCPPHFME)
		{
		}

		protected override void GGAKOMGHAGK(StackedUIFlowBase ELNPJBMKDAE)
		{
		}

		protected override void DGPFMFMJNEL(StackedUIFlowBase ELNPJBMKDAE)
		{
		}

		protected override bool NNJNFCGMJKG()
		{
			return false;
		}

		protected override void DNPOGCFJOAC()
		{
		}

		protected override void KHOACLMDKOG()
		{
		}

		protected override bool GKFDOKDBIBF()
		{
			return false;
		}

		public T GetStackedFlow<T>() where T : StackedUIFlowBase
		{
			return null;
		}
	}
}
