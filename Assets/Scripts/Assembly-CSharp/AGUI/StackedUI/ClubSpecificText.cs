using TMPro;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class ClubSpecificText : MonoBehaviour
	{
		public enum BHLFKGBELNM
		{
			Name = 0,
			Description = 1
		}

		[SerializeField]
		private BHLFKGBELNM clubPropertyToWatch;

		[SerializeField]
		private ClubSpecificUIBehaviour clubWatcher;

		[SerializeField]
		private TextMeshProUGUI text;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void KFDKLEHOFOG()
		{
		}
	}
}
