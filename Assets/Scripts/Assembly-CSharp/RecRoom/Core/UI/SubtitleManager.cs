using System.Collections.Generic;
using RecRoom.Core.VR.UI;
using UnityEngine;

namespace RecRoom.Core.UI
{
	public class SubtitleManager : SingletonMonoBehaviour<SubtitleManager>
	{
		private class EAGEIKGBJPM : FKFMIDJJOOH
		{
			private class COOOCBFHFLI : NLPGHHBMMPG
			{
				private readonly bool PNNOAMOMOFJ;

				private readonly float FJKIDPPLMMJ;

				public COOOCBFHFLI(string HLIGBKANEEA, Sprite DDJJDDAMEFB, bool PNNOAMOMOFJ, float FJKIDPPLMMJ)
					: base(null, null)
				{
				}

				public bool FBNFGAFNEKD()
				{
					return false;
				}
			}

			private global::AFHOAHNAMGF<COOOCBFHFLI> FFCGJPPIICF;

private COOOCBFHFLI HEPCEONADIJ
{
get 			{
				return null;
			}

}

			public void BAKBEAHFHAD(object IALNODEHBNN, int LAGADKBKLAD, string OEEBIOPLOMG, float FGBPJMKCMAO, Sprite DDJJDDAMEFB = null)
			{
			}

			public void NHIGLBDAAFB(object IALNODEHBNN, int LAGADKBKLAD, string OEEBIOPLOMG, Sprite DDJJDDAMEFB = null)
			{
			}

			public void MILDLLFOGOM(object IALNODEHBNN)
			{
			}

			private bool AAHGLJKPODF()
			{
				return false;
			}

			public bool IPMPIICFPPL(out NLPGHHBMMPG OEEBIOPLOMG)
			{
				OEEBIOPLOMG = null;
				return false;
			}

			public void AMCIIGCCKMP()
			{
			}

			public void GLBPPAIACJF()
			{
			}
		}

		public const int DEFAULT_SUBTITLE_PRIORITY = 0;

		public const int DEFAULT_INDEFINITE_SUBTITLE_PRIORITY = -1;

		public const int FIRST_PARTY_QUEUE_PRIORITY = 0;

		public const int UGC_QUEUE_PRIORITY = 100;

		[SerializeField]
		private VRSubtitleDialog vrSubtitleDialog;

		public bool FirstPartySubtitlesEnabled;

		private SortedList<int, FKFMIDJJOOH> DBJHFIDHFHD;

		private EAGEIKGBJPM IMAHGHGBDLF;

public VRSubtitleDialog VRSubtitleDialog
{
get 		{
			return null;
		}

}

		public bool TryGetCurrentSubtitle(out string HLIGBKANEEA, out Sprite DDJJDDAMEFB)
		{
			HLIGBKANEEA = null;
			DDJJDDAMEFB = null;
			return false;
		}

		private void Update()
		{
		}

		public void AddQueue(FKFMIDJJOOH NOLLKEFDAIA, int LAGADKBKLAD)
		{
		}

		public bool RemoveQueue(FKFMIDJJOOH NOLLKEFDAIA)
		{
			return false;
		}

		public void ShowFirstPartyIndefinitely(object IALNODEHBNN, int LAGADKBKLAD, string OEEBIOPLOMG, Sprite DDJJDDAMEFB = null)
		{
		}

		public void ShowFirstParty(object IALNODEHBNN, int LAGADKBKLAD, string OEEBIOPLOMG, float FGBPJMKCMAO, Sprite DDJJDDAMEFB = null)
		{
		}

		public void HideFirstParty(object IALNODEHBNN)
		{
		}

		public void HideAllFirstParty()
		{
		}
	}
}
