using RRUI;
using TMPro;
using UnityEngine;

namespace RecRoom.UI
{
	public class ScreenHUDBadge : MonoBehaviour
	{
		public struct PKNIACPIPPO
		{
			public readonly string KKHKFIGPMMA;

			public PKNIACPIPPO(string HLIGBKANEEA)
			{
				KKHKFIGPMMA = null;
			}
		}

		[SerializeField]
		private TMP_Text text;

		[SerializeField]
		private CanvasPositioner positioner;

		private Matrix4x4 ODBONJLIKAJ;

		private RectTransform JPNOBFPEDDI;

		public static bool TryFindBadge(GameObject PHGLLMEHMAJ, out ScreenHUDBadge JNDJIGEKDCM)
		{
			JNDJIGEKDCM = null;
			return false;
		}

		public void ShowOrUpdate(RectTransform HHFDFFDPCGO, CanvasPositioner.CanvasPositionerPlacement FDMFGPCFPKA, PKNIACPIPPO GJNKHFLDKHK, bool MAPHDCHLOKB = false)
		{
		}

		public void Hide()
		{
		}
	}
}
