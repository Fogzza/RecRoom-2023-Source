using System;
using RecRoom.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.Storefronts
{
	public class StorefrontConfirmationDialog : MonoBehaviour
	{
		[Flags]
		public enum HLJDGHBNINP
		{
			YES_NO = 3,
			YES_ONLY = 1,
			NO_ONLY = 2,
			YES_NO_GIFT = 7,
			NO_GIFT = 6
		}

		public interface DELJNAJOKBB
		{

 bool CDJAEBDDBOI
{
get ;
}

 int IAMHCABOCOA
{
get ;
}

 Action<int> IPODPHPFBBD
{
get ;
set ;
}

			void FGJGBDJKHBC(int MLDANHIGANI);
		}

		private sealed class AOPIAACHHPN : DELJNAJOKBB
		{
			private bool CPHIOIEEHGI;

			private int KDLHCFJOOCF;

			private Action<int> FMBGAFEJMID;

public bool CDJAEBDDBOI
{
get 			{
				return false;
			}

private set {
			}
}

public int IAMHCABOCOA
{
get 			{
				return 0;
			}

private set {
			}
}

public Action<int> IPODPHPFBBD
{
get 			{
				return null;
			}

set {
			}
}

			public void FGJGBDJKHBC(int MLDANHIGANI)
			{
			}
		}

		private const int ANKJFFOEHIL = 1;

		private const int EDHLPDHANOH = 2;

		private const int BLLLOCECIBI = 4;

		[SerializeField]
		private Text questionText;

		[SerializeField]
		private Text yesText;

		[SerializeField]
		private Button yesButton;

		[SerializeField]
		private Text noText;

		[SerializeField]
		private Button noButton;

		[SerializeField]
		private Button giftButton;

		[SerializeField]
		private RecRoomAudioClip popupAudio;

		[SerializeField]
		private RecRoomAudioClip buttonAudio;

		private DELJNAJOKBB EAHMPNLDMBP;

public bool IsActive
{
get 		{
			return false;
		}

}

protected DELJNAJOKBB LGCIKKGGPIB
{
get 		{
			return null;
		}

private set {
		}
}

		protected DELJNAJOKBB DKPODJBMLKC()
		{
			return null;
		}

		public void Button_Affirmative()
		{
		}

		public void Button_Negative()
		{
		}

		public void Button_Gift()
		{
		}

		public virtual void Cancel(bool OANFJFDMNOM)
		{
		}

		protected void FGJGBDJKHBC(int MLDANHIGANI, bool GADABDFHINB)
		{
		}

		public DELJNAJOKBB ShowDialog(HLJDGHBNINP HNPFAOFHHII, string KEMAPPJCGEA, string JINHPNDAHKP = "Yes", string ABONDMLCNBK = "No")
		{
			return null;
		}
	}
}
