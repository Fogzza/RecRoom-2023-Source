using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using RRUI.Navigation;
using RecRoom.Utils.Image;
using UnityEngine;

namespace RecRoom.Sharing
{
	public class LinkManager : SingletonMonoBehaviour<LinkManager>
	{
		public enum CBMMDEJIIEM
		{
			ERROR = -1,
			UNSUPPORTED = 0,
			Event = 10,
			Image = 20,
			Room = 30,
			User = 40,
			FriendAdd = 50,
			Referral = 60,
			Meetup = 70,
			Club = 80,
			DeepLink = 90,
			StoreItem = 100,
			Invention = 110,
			StarterPack = 120,
			MobileHomeFeed = 130
		}

		public class OPICCOMKOOF
		{
			public PACKLJCNDPL.HCJJFFDEJFG FCHFGJNCJDG;

			public bool BCNFFDLODNF;

			public bool KBLNJGDHBKM;

			public HJIIMKJBOHI HPLPKKGNJCC;

			public bool PPNDJMFKDBO;

			public Action<DPKIGFPJMOG> CAJODKHFIGF;

			public Action FHPGJOMCGFA;

			public bool MJLBIKKMGIN;

			public Action<string> KDEMNGCACLF;

			public Action CIGLFDHALPM;

			public string AGDNKLPGBOA;

			public string IABDKGPKOFE;

			public Dictionary<string, string> KNIBODOOLGP;

			public string CBCPDPNKOMP;

			public string PCBDCKBIDPC;

			public PACKLJCNDPL.ShortLinkData OGOMNMEBAJD;

			public bool KHOHFBJMMCB;

			public Enum NIFOGEBEDNG;

public HJIIMKJBOHI FLKBLHPIKFB
{
get 			{
				return HJIIMKJBOHI.Friend;
			}

}

public string GIPGHINCOEC
{
get 			{
				return null;
			}

}

public bool CDNGCIBCJAN
{
get 			{
				return false;
			}

}

public bool MMJCIILKFIO
{
get 			{
				return false;
			}

}

public bool MNIOKFOAILO
{
get 			{
				return false;
			}

}

public bool AEPPIFJOPHJ
{
get 			{
				return false;
			}

}

			public static Dictionary<string, string> FGENAPHLJOP(string FFBADJKEOPF)
			{
				return null;
			}
		}

		public static class INGGKPCKMEP
		{
			public static readonly string CGNBGJIDNKB;

			public static readonly string KKIGPMELPGI;

			public static readonly string CFAPIGDOOOO;

			public static readonly string ABKBEADAIOF;

			public static readonly string BBMHHGAMAAF;

			public static readonly string PNALCIGJGNE;

			public static string AGLPABNKNFF(string NLJOHEKGNDH)
			{
				return null;
			}

			public static string LAHJBDKKPCJ(string KAEDAICECGN)
			{
				return null;
			}

			public static string ILJJPGMCNEG(string KAEDAICECGN, int CAPKFCHDLFA)
			{
				return null;
			}
		}

		public enum PPOMHHJHEFF
		{
			None = 0,
			Share = 1,
			Copy = 2,
			ShareAndCopy = 3
		}

		private sealed class GMBGGNAPOPF
		{
			public ActionCode[] components;

			internal ActionCode _003CAwake_003Eb__1(HJIIMKJBOHI t)
			{
				return null;
			}
		}

		private sealed class MAFNBJKFGHK
		{
			public HJIIMKJBOHI t;

			internal bool _003CAwake_003Eb__2(ActionCode c)
			{
				return false;
			}
		}

		private sealed class FIMJKIBCKHF
		{
			private sealed class _003C_003CGetPendingLaunchTarget_003Eg__GetPendingLaunchTargetCoroutine_007C0_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public FIMJKIBCKHF _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CGetPendingLaunchTarget_003Eg__GetPendingLaunchTargetCoroutine_007C0_003Ed(int _003C_003E1__state)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
				{
					return null;
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}
			}

			public BootSequence.NJIJPADHPEC launchTarget;

			internal IEnumerator<EGGPGCCKPCO> _003CGetPendingLaunchTarget_003Eg__GetPendingLaunchTargetCoroutine_007C0()
			{
				return null;
			}

			internal BootSequence.NJIJPADHPEC _003CGetPendingLaunchTarget_003Eb__1()
			{
				return null;
			}
		}

		private sealed class HDDFFMEAOBM
		{
			public LinkManager _003C_003E4__this;

			public string eventId;

			internal void _003CHandleBasicLinkEvent_003Eb__0(NCBAEFEDLMK eventDetails)
			{
			}

			internal string _003CHandleBasicLinkEvent_003Eb__1()
			{
				return null;
			}
		}

		private sealed class GIBOBCNDDHD
		{
			public LinkManager _003C_003E4__this;

			public string roomName;

			internal void _003CHandleBasicLinkRoom_003Eb__0(JCDPHCELKHI room)
			{
			}

			internal string _003CHandleBasicLinkRoom_003Eb__1()
			{
				return null;
			}
		}

		private sealed class KPHLCDGLNBK
		{
			public string storeItem;

			internal string _003CHandleBasicLinkStoreItem_003Eb__0(bool success)
			{
				return null;
			}
		}

		private sealed class FKAEOLCIIHD
		{
			public string invention;

			internal string _003CHandleBasicLinkInvention_003Eb__0(bool success)
			{
				return null;
			}
		}

		private sealed class JGEFALKFHKA
		{
			public string starterPack;

			internal string _003CHandleBasicLinkStarterPack_003Eb__0(bool success)
			{
				return null;
			}
		}

		private sealed class LGBEINFPBMC
		{
			public string itemTypeAndId;

			internal string _003CHandleBasicLinkMobileHomeFeed_003Eb__0(bool success)
			{
				return null;
			}
		}

		private sealed class GAGFCOLNFFO
		{
			public string userName;

			internal global::NCOKFFGPIJM<DFDECAEJBIO> _003CHandleBasicLinkUser_003Eb__0()
			{
				return null;
			}

			internal string _003CHandleBasicLinkUser_003Eb__2()
			{
				return null;
			}
		}

		private sealed class COAIHHKJAGG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public COAIHHKJAGG(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class DACMGOCKLCJ
		{
			public BHNJIBDJFAL prefManager;

			internal bool _003CWaitForLoginNuxAndWatch_003Eb__0()
			{
				return false;
			}
		}

		private sealed class AOPFDJINEDB : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public bool waitForWatchClosed;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public AOPFDJINEDB(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class LLDPEDKDABE
		{
			public DBIPHDIEBCM linkPromise;

			internal void _003CConsumeActionLinkIfValid_003Eb__0(EPFBKEBPJFB actionLink)
			{
			}
		}

		private sealed class MEJDDGNDCJF : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public LinkManager _003C_003E4__this;

			public Action finallyFunc;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public MEJDDGNDCJF(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class PDINILODAJH
		{
			public string id;

			public LinkManager _003C_003E4__this;

			internal void _003CWaitForLoginAndHandlePendingLink_003Eb__1(string message)
			{
			}

			internal void _003CWaitForLoginAndHandlePendingLink_003Eb__2()
			{
			}

			internal string _003CWaitForLoginAndHandlePendingLink_003Eg__TryParseShortLinkId_007C3(string url)
			{
				return null;
			}

			internal void _003CWaitForLoginAndHandlePendingLink_003Eb__4(string message)
			{
			}

			internal void _003CWaitForLoginAndHandlePendingLink_003Eb__5()
			{
			}

			internal void _003CWaitForLoginAndHandlePendingLink_003Eb__6(string message)
			{
			}

			internal void _003CWaitForLoginAndHandlePendingLink_003Eb__7(string key)
			{
			}
		}

		private sealed class MJJPHBAKOBP
		{
			public bool? validActionLink;

			public PDINILODAJH CS_0024_003C_003E8__locals1;

			internal void _003CWaitForLoginAndHandlePendingLink_003Eb__8(EPFBKEBPJFB dto)
			{
			}

			internal void _003CWaitForLoginAndHandlePendingLink_003Eb__9(string e)
			{
			}

			internal bool _003CWaitForLoginAndHandlePendingLink_003Eb__10()
			{
				return false;
			}
		}

		private sealed class CDOFDLNFPML
		{
			public bool expanding;

			internal void _003CWaitForLoginAndHandlePendingLink_003Eb__12()
			{
			}

			internal bool _003CWaitForLoginAndHandlePendingLink_003Eb__13()
			{
				return false;
			}
		}

		private sealed class PEOLBOKIPNA
		{
			public bool customDeepLinkProcessedSuccesfully;

			public PDINILODAJH CS_0024_003C_003E8__locals2;

			internal void _003CWaitForLoginAndHandlePendingLink_003Eb__14(string key)
			{
			}
		}

		private sealed class MOLGAOAIDBM : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public LinkManager _003C_003E4__this;

			private MJJPHBAKOBP _003C_003E8__1;

			private PDINILODAJH _003C_003E8__2;

			private PEOLBOKIPNA _003C_003E8__3;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public MOLGAOAIDBM(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class HALAMKOLMLL
		{
			private sealed class _003C_003CGetShortenedShareUrl_003Eg__SafeCreateShortLink_007C0_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public HALAMKOLMLL _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CGetShortenedShareUrl_003Eg__SafeCreateShortLink_007C0_003Ed(int _003C_003E1__state)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
				{
					return null;
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}
			}

			public string shareLink;

			internal IEnumerator<EGGPGCCKPCO> _003CGetShortenedShareUrl_003Eg__SafeCreateShortLink_007C0()
			{
				return null;
			}

			internal void _003CGetShortenedShareUrl_003Eb__2(string shortLinkId)
			{
			}

			internal string _003CGetShortenedShareUrl_003Eb__1()
			{
				return null;
			}
		}

		private sealed class HCJBFCNFHBE
		{
			public bool done;

			internal void _003CGetShortenedShareUrl_003Eb__3()
			{
			}

			internal bool _003CGetShortenedShareUrl_003Eb__4()
			{
				return false;
			}
		}

		private const string KKKJACNBDCN = "LinkManager.FreshInstallHandled";

		private const string CMAGCJDIPBC = "l";

		private const char CHHHPGKPGEE = '_';

		private static Dictionary<HJIIMKJBOHI, ActionCode> JLMCCMCHHDJ;

		private static bool JOIKMPKICDJ;

		private static DateTime? IINBCBIBOMN;

		private static bool HHPIIBAKHEP;

		private static OPICCOMKOOF EDDMIJOKMNC;

		private BHNJIBDJFAL NJPJBDDAEFH;

		private APGPNOKPLLL NKKHAEFBOLO;

		private GFKPAIPKOIG CCNAIJEHDML;

		[SerializeField]
		private Route actionCodeShareRoute;

		[SerializeField]
		private Route inviteRoute;

		private static BootSequence.NJIJPADHPEC GHOBNODAFDD;

		public const int ActionCodeMinLength = 4;

		private static readonly Regex BFIPMFLPPGF;

		public static readonly global::HHOBPMOCKMJ<Enum> OnPlatformShare;

public Route InviteRoute
{
get 		{
			return null;
		}

}

public static bool HasPendingLink
{
get 		{
			return false;
		}

}

public static bool HasPendingDeepLink
{
get 		{
			return false;
		}

}

public static BootSequence.NJIJPADHPEC LaunchGameTarget
{
get 		{
			return null;
		}

private set {
		}
}

public static string LastSuccessfulMeetupCode
{
get 		{
			return null;
		}

set {
		}
}

public static bool PlatformCanCopy
{
get 		{
			return false;
		}

}

public static bool PlatformCanShare
{
get 		{
			return false;
		}

}

public static PPOMHHJHEFF PlatformShareCapability
{
get 		{
			return PPOMHHJHEFF.None;
		}

}

public static string PlatformSharedText
{
get 		{
			return null;
		}

}

public static string PlatformShareText
{
get 		{
			return null;
		}

}

public static string ShareableRoomName
{
get 		{
			return null;
		}

}

private static string IMLJEELLEEN
{
get 		{
			return null;
		}

}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Start()
		{
		}

		public void ReceiveFirebaseDeepLink(string link)
		{
		}

		private void OIDHHDHAJLB(string PEDLJMJDBPA)
		{
		}

		private void EPENHHEBKBP(string FFBADJKEOPF)
		{
		}

		public static global::NCOKFFGPIJM<BootSequence.NJIJPADHPEC> GetPendingLaunchTarget()
		{
			return null;
		}

		public void HandleActionCode(string JIPMLIFNPCE, Action FHPGJOMCGFA, HJIIMKJBOHI DPHDPEDPAEE = HJIIMKJBOHI.Unknown, Action CIGLFDHALPM = null, Action<string> KDEMNGCACLF = null, bool HAAAAOFFLLD = true)
		{
		}

		private LAHBDKNMNHN MAJAOGJBLLP()
		{
			return null;
		}

		private global::NCOKFFGPIJM<string> CBLOHCELCMP()
		{
			return null;
		}

		private global::NCOKFFGPIJM<string> DENMJBEDIPK(string JJLIIOCLCNA)
		{
			return null;
		}

		private global::NCOKFFGPIJM<string> MKJPLEBOMKI(string LBGBFPDNKOL)
		{
			return null;
		}

		private global::NCOKFFGPIJM<string> NJGIKJFCHCK(string GKKELAGOHOK)
		{
			return null;
		}

		private global::NCOKFFGPIJM<string> GGCPNMOFGNN(string EGDOIKMDMJM)
		{
			return null;
		}

		private global::NCOKFFGPIJM<string> OFEAGPPFIKJ(string CDOAEDADFIJ)
		{
			return null;
		}

		private global::NCOKFFGPIJM<string> FBHEPLEIBFD(string ODPHNKDDPDN)
		{
			return null;
		}

		private global::NCOKFFGPIJM<string> DDAONBNDIDN(string KLJJFMEGFID)
		{
			return null;
		}

		private LAHBDKNMNHN FBIEBPOANIN()
		{
			return null;
		}

		private global::NCOKFFGPIJM<string> EIHCLHCJPIP()
		{
			return null;
		}

		private string PFABFGAMKPO(string PEDLJMJDBPA, string DEAMMIBGBAP)
		{
			return null;
		}

		private bool EAJNICMJJAI(string PEDLJMJDBPA, bool LNKFIDPGJGM = false)
		{
			return false;
		}

		public static ActionCode GetHandler(HJIIMKJBOHI NIFOGEBEDNG)
		{
			return null;
		}

		public static bool HasMeetupCode(EGGMEJDMHKF GPKOELKKOBP)
		{
			return false;
		}

		public static bool HasGroupLaunchCode(EGGMEJDMHKF GPKOELKKOBP)
		{
			return false;
		}

		private static bool GANCEHHKCBG(string IKPMEAIFENP)
		{
			return false;
		}

		private static void AGCIDMHMKBK(string OFCFPGACNJB)
		{
		}

		public static string GetWellFormattedActionCode(string FKKHPIMPJBP)
		{
			return null;
		}

		public static IEnumerator<EGGPGCCKPCO> WaitForLogin()
		{
			return null;
		}

		public static IEnumerator<EGGPGCCKPCO> WaitForLoginNuxAndWatch(bool NCHEOADEEJP = false, BootSequence.NJIJPADHPEC DBGKIJIDIGJ = null)
		{
			return null;
		}

		private LAHBDKNMNHN NPLFDHIGKNK(string IKHNIJKGJFD, int? LEGFOBBMIDP, HJIIMKJBOHI HDEEDHODCOE, bool DEODPCHAFKO, bool PBAFNPNEEID)
		{
			return null;
		}

		private void BBLDEJJKBKF(string KFBDHGKPJOF, bool EGJEBAFNALL, string PCBDCKBIDPC)
		{
		}

		private Match NNDJMHKAMCM(string PEDLJMJDBPA)
		{
			return null;
		}

		private void PDCIIANHAEJ(string PEDLJMJDBPA)
		{
		}

		private void GGDMKMCOICO()
		{
		}

		private void CABHMFGMNFL()
		{
		}

		private CBMMDEJIIEM DNBGLFIBOGA(string PEDLJMJDBPA, out string FDAIMOMOHIG)
		{
			FDAIMOMOHIG = null;
			return CBMMDEJIIEM.UNSUPPORTED;
		}

		private void DCOPLFPOHJB()
		{
		}

		private IEnumerator<EGGPGCCKPCO> HDKPPCIINIC(Action HNCAEKHEOAC)
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> KOPPOODCGHB()
		{
			return null;
		}

		private void OPFPIBEBODH()
		{
		}

		public LAHBDKNMNHN CreateAndShare(HJIIMKJBOHI NIFOGEBEDNG, bool GMEKLDALJKC = false, object ADCFFAJGNAM = null)
		{
			return null;
		}

		public static string GetAbsoluteShareUrl(string KDENKOIEIEI)
		{
			return null;
		}

		public static bool PlatformCopy(HJIIMKJBOHI HDEEDHODCOE, string FKKHPIMPJBP, string HLIGBKANEEA)
		{
			return false;
		}

		public static bool PlatformShare(Enum AKKAOAJPGOL, string FDAIMOMOHIG, string PEDLJMJDBPA, string HLIGBKANEEA, Texture2D LOHPLDOCFAN = null, bool PEINPGMGLKJ = false)
		{
			return false;
		}

		public static LAHBDKNMNHN PlatformShareImage(Texture LOHPLDOCFAN, string NPOEAPJKNFN)
		{
			return null;
		}

		public static LAHBDKNMNHN PlatformShareImage(ManagedTexture NAKAMFBOOLB, string NPOEAPJKNFN)
		{
			return null;
		}

		private static global::NCOKFFGPIJM<string> EEABMEBJPCG(string MOMBJBGIIGJ)
		{
			return null;
		}

		[CompilerGenerated]
		private void MKBKOIOPNEH(KEBDIFAAMLN JEECAOOPDDK)
		{
		}
	}
}
