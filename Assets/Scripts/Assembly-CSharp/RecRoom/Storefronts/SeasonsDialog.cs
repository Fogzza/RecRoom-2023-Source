using RecRoom.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.Storefronts
{
	public class SeasonsDialog : MonoBehaviour
	{
		[SerializeField]
		private Text titleText;

		[SerializeField]
		private Text descriptionText;

		public string SeasonsTitle;

		[TextArea]
		public string SeasonDetails;

		[TextArea]
		public string MemberSeasonDetails;

		[SerializeField]
		private RecRoomAudioClip popupAudio;

		[SerializeField]
		private RecRoomAudioClip buttonAudio;

public bool IsActive
{
get 		{
			return false;
		}

}

		public void ShowDialog()
		{
		}

		public void CloseDialog()
		{
		}
	}
}
