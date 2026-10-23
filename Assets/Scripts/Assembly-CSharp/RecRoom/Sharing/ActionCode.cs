using System;
using System.Runtime.CompilerServices;
using RRUI.Navigation;
using RecRoom.Core;
using UnityEngine;

namespace RecRoom.Sharing
{
	public abstract class ActionCode : MonoBehaviour
	{
		public struct NMLEIPDLABI
		{
			private string ECHMDFHMHBP;

			private string HBIDFIGIJDB;

			private string PNNEAJPJJAO;

			private string AFNCEEPFLID;

			private object JEAGFEPMLIJ;

public string JLCBNMJJAHF
{
get 			{
				return null;
			}

private set {
			}
}

public string CPNCLEICIBO
{
get 			{
				return null;
			}

private set {
			}
}

public string DLOCINCHPOH
{
get 			{
				return null;
			}

private set {
			}
}

public string CBDKILFNMJD
{
get 			{
				return null;
			}

private set {
			}
}

public object DLFKMDFDAFO
{
get 			{
				return null;
			}

private set {
			}
}

			public NMLEIPDLABI(string FKKHPIMPJBP, string PEDLJMJDBPA, string KBLNJGDHBKM, string EMLJIHEPIFJ, object DELCOFCGDFF)
			{
				ECHMDFHMHBP = null;
				HBIDFIGIJDB = null;
				PNNEAJPJJAO = null;
				AFNCEEPFLID = null;
				JEAGFEPMLIJ = null;
			}

			public static NMLEIPDLABI KLHDAOHKDFO(string FKKHPIMPJBP)
			{
				return default;
			}

			public static NMLEIPDLABI LLGPLHAODOI(string PEDLJMJDBPA)
			{
				return default;
			}

			public void MCILFJKBPPF(string KDENKOIEIEI)
			{
			}

			public void GJGCAHOIBDP(string MOMBJBGIIGJ)
			{
			}

			public void HDPAMPLEGDF(string EMLJIHEPIFJ)
			{
			}

			public void HGDICLFFIHM(object DELCOFCGDFF)
			{
			}
		}

		[Serializable]
		public class Configuration
		{
			[SerializeField]
			private string name;

			[SerializeField]
			private HJIIMKJBOHI type;

			[SerializeField]
			private bool autoRenew;

			[SerializeField]
			private int maxUses;

			[SerializeField]
			private int validHours;

			[SerializeField]
			private string createText;

			[SerializeField]
			[TextArea]
			private string descriptionRTF;

			[SerializeField]
			private string fullName;

			[SerializeField]
			[TextArea]
			private string shareContent;

			[TextArea]
			[SerializeField]
			private string deepLinkShareContent;

			[SerializeField]
			[TextArea]
			private string shareDescription;

			public string Name => null;

			public HJIIMKJBOHI Type => HJIIMKJBOHI.Friend;

			public bool AutoRenew => false;

			public int? AutoRenewHours => null;

			public int? MaxUses => null;

			public int ValidHours => 0;

			public string CreateText => null;

			public string DescriptionRTF => null;

			public string FullName => null;

			public string ShareContent => null;

			public string DeepLinkShareContent => null;

			public string ShareDescription => null;

			public bool WellFormed => false;
		}

		private sealed class OCGKJDMDAOH
		{
			public WatchUI watch;

			public DFDECAEJBIO targetPlayerAccount;

			internal void _003CHandleFailedChatMessage_003Eb__0(HGKINAOMNIF response)
			{
			}
		}

		private sealed class DIGMDPCLFPJ
		{
			public int otherPlayerId;

			public string chatMessage;

			public string playerNotification;

			public string chatFailureTitle;

			public string chatFailureBody;

			public Func<OFPDFAGJKLH.CKHCGCPJFHH, global::NCOKFFGPIJM<AGBOKPJCFFK>> _003C_003E9__2;

			internal global::NCOKFFGPIJM<DFDECAEJBIO> _003COpenChatThreadScreenAndSendMessageToPlayer_003Eb__0()
			{
				return null;
			}

			internal void _003COpenChatThreadScreenAndSendMessageToPlayer_003Eb__1(DFDECAEJBIO account)
			{
			}

			internal global::NCOKFFGPIJM<AGBOKPJCFFK> _003COpenChatThreadScreenAndSendMessageToPlayer_003Eb__2(OFPDFAGJKLH.CKHCGCPJFHH message)
			{
				return null;
			}
		}

		private sealed class EPLJNBJEKAF
		{
			public WatchUI watch;

			public DFDECAEJBIO account;

			public DIGMDPCLFPJ CS_0024_003C_003E8__locals1;

			internal void _003COpenChatThreadScreenAndSendMessageToPlayer_003Eb__3(AGBOKPJCFFK result)
			{
			}

			internal void _003COpenChatThreadScreenAndSendMessageToPlayer_003Eb__4(string error)
			{
			}
		}

		private sealed class CEPFGKCOHJN
		{
			public DBIPHDIEBCM linkPromise;

			internal void _003CConsumeActionLinkIfValid_003Eb__0(EPFBKEBPJFB actionLink)
			{
			}
		}

		public const string QueryParameter = "a";

		public Configuration Config;

		private string NMOFJPGMDAK;

		private static NMLEIPDLABI CNIDPNGCMLJ;

public virtual bool SupportsShareWithCode
{
get 		{
			return false;
		}

}

public virtual OFPDFAGJKLH.BLBMLHFICJK MessageContentType
{
get 		{
			return OFPDFAGJKLH.BLBMLHFICJK.Text;
		}

}

public string ReadableError
{
get 		{
			return null;
		}

set {
		}
}

public static NMLEIPDLABI MostRecentCreatedLink
{
get 		{
			return default;
		}

private set {
		}
}

		public static bool PlatformShareOrCopy(ActionCode ODEFKCPHGJD, string FKKHPIMPJBP, string PEDLJMJDBPA, bool MHIOBEJKDFA)
		{
			return false;
		}

		public virtual bool SupportsDirectShareInChat(object DELCOFCGDFF)
		{
			return false;
		}

		public virtual string GetTitleText()
		{
			return null;
		}

		public virtual string GetDescriptionText()
		{
			return null;
		}

		public virtual OFPDFAGJKLH.DBGOCJDEIIN GetChatShareMessage(NMLEIPDLABI ABPFMLKOJAM, bool MHIOBEJKDFA)
		{
			return null;
		}

		public virtual string GetFullShareMessage(string FKKHPIMPJBP, string PEDLJMJDBPA, bool MHIOBEJKDFA)
		{
			return null;
		}

		public abstract global::NCOKFFGPIJM<NMLEIPDLABI> Create(object ADCFFAJGNAM);

		public abstract LAHBDKNMNHN CreateAndShare(Route JGMLNNDKOOH, bool GMEKLDALJKC, object ADCFFAJGNAM);

		public virtual void CreateButtonPressed()
		{
		}

		public string GetActionLinkData(object NJKAHCDCOED)
		{
			return null;
		}

		public abstract LAHBDKNMNHN Handle(LinkManager.OPICCOMKOOF EDDMIJOKMNC);

		public abstract void ModifyPreAuthLaunchTarget(BootSequence.NJIJPADHPEC DBGKIJIDIGJ, LinkManager.OPICCOMKOOF EDDMIJOKMNC);

		public T ParseExtraJson<T>(LinkManager.OPICCOMKOOF EDDMIJOKMNC)
		{
			return default;
		}

		protected static void FFGDBCLBOLF(string CPNJIJPBFHH, string OFNJCMLAPMK, DFDECAEJBIO JJFNDBDGBFO)
		{
		}

		protected static void JFGACADJOJE(int AFBGIPGHBMO, string EMLJIHEPIFJ, string MMPNJNNBJJC, string CPNJIJPBFHH, string OFNJCMLAPMK)
		{
		}

		protected static bool JACKPAPFGDD(Route JGMLNNDKOOH, HJIIMKJBOHI NIFOGEBEDNG, bool BNDIFGEHPHK, NMLEIPDLABI ABPFMLKOJAM, bool GMEKLDALJKC, Action<DPKIGFPJMOG> BIBFLPCEMOK = null, bool AEKBOALADNH = false)
		{
			return false;
		}

		protected bool MEJIEJEMPMB(LinkManager.OPICCOMKOOF EDDMIJOKMNC, long OLHPJHKBIBH)
		{
			return false;
		}

		public static string ActionCodeToUrl(string FKKHPIMPJBP)
		{
			return null;
		}

		public static string ActionUrlToCode(string PEDLJMJDBPA)
		{
			return null;
		}

		public static LAHBDKNMNHN ConsumeActionLinkIfValid(string IKHNIJKGJFD, int? LEGFOBBMIDP, HJIIMKJBOHI HDEEDHODCOE, bool DEODPCHAFKO, bool PBAFNPNEEID)
		{
			return null;
		}

		[CompilerGenerated]
		internal static string PGGMBDEJMFB(string PEDLJMJDBPA, string FDAIMOMOHIG, string IPMIIEAGJKC)
		{
			return null;
		}
	}
}
