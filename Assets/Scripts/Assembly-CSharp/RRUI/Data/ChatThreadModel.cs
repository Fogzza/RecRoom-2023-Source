using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RecNet;
using RecRoom.Utils.Image;
using UnityEngine;

namespace RRUI.Data
{
	public class ChatThreadModel : RRUIModel<DAKMOAKIKIC>
	{
		private enum OCIENKGNIJE
		{
			Mine = 0,
			Popular = 1
		}

		private enum HJKFLGDLMKI
		{
			Mine = 0,
			Upcoming = 1
		}

		private class PCMAOOOAJLE
		{
			public OCIENKGNIJE DKICICBOOGM;

			public EPILDIJELPG PBJLICKJEJI;
		}

		private class LPLGFMCLLMC
		{
			public HJKFLGDLMKI DKICICBOOGM;

			public IMIJPHJKLIM MDNGKECNGKI;
		}

		private sealed class BPDEMLLKAAB
		{
			public ChatThreadModel _003C_003E4__this;

			public int refreshCounter;

			public Action<string> _003C_003E9__1;

			internal LAHBDKNMNHN _003CRefreshInternal_003Eb__0(FMEDMCFGHFM chatThread)
			{
				return null;
			}

			internal void _003CRefreshInternal_003Eb__1(string formattedMessage)
			{
			}
		}

		private sealed class ONCJLJJJGLI
		{
			public bool chatThreadImageNameFound;

			public string chatThreadImageName;

			internal string _003CGetDirectChatThread_003Eb__1(DFDECAEJBIO account)
			{
				return null;
			}
		}

		private sealed class GCFGLBDBHHO
		{
			public ChatThreadModel _003C_003E4__this;

			public HashSet<int> indicesToAddToChat;

			public List<DFDECAEJBIO> accountsPlayerCanMessage;

			public PickerDialogModel addFriendsToChatDialog;

			public EHEJPNFKNAL confirmButton;

			public Action<string> _003C_003E9__8;

			internal bool _003CShowAddPlayersToChatDialog_003Eb__0(DFDECAEJBIO a)
			{
				return false;
			}

			internal bool _003CShowAddPlayersToChatDialog_003Eb__5()
			{
				return false;
			}

			internal void _003CShowAddPlayersToChatDialog_003Eb__6()
			{
			}

			internal void _003CShowAddPlayersToChatDialog_003Eb__8(string err)
			{
			}

			internal void _003CShowAddPlayersToChatDialog_003Eb__1(GameObject instance, int index, CardModel cardModel, AccountModel accountModel, JLOCLGGLOPP toCardController)
			{
			}

			internal bool _003CShowAddPlayersToChatDialog_003Eb__2(string filter, int i)
			{
				return false;
			}

			internal void _003CShowAddPlayersToChatDialog_003Eb__3()
			{
			}

			internal void _003CShowAddPlayersToChatDialog_003Eb__4(BaseDialogModel<KCOKPCOFDIM> dialog)
			{
			}
		}

		private sealed class MEBGHCAHBPA
		{
			public DFDECAEJBIO account;

			public GCFGLBDBHHO CS_0024_003C_003E8__locals1;

			internal void _003CShowAddPlayersToChatDialog_003Eb__7(HEIHKKOLIID result)
			{
			}
		}

		private sealed class EKAEDFPAKCA
		{
			public KCIMFOOCLPN leaveChatFlow;

			public ChatThreadModel _003C_003E4__this;

			internal void _003CShowLeaveChatDialog_003Eb__4(HEIHKKOLIID result)
			{
			}

			internal void _003CShowLeaveChatDialog_003Eb__5(string error)
			{
			}
		}

		private sealed class IGCGFPJGOAH
		{
			public ChatThreadModel _003C_003E4__this;

			public long prevThreadId;

			internal void _003CFetchOlderMessages_003Eb__0(IList<ChatMessage> messages)
			{
			}
		}

		private sealed class GLPNKNDDBID
		{
			public ChatThreadModel _003C_003E4__this;

			public OFPDFAGJKLH.DBGOCJDEIIN messageDetails;

			public ABMCIGNLAMN analyticsData;

			internal void _003CTrySendMessage_003Eb__0()
			{
			}
		}

		private sealed class HICIIKMPALH
		{
			public ChatThreadModel _003C_003E4__this;

			public ABMCIGNLAMN analyticsData;

			public KCIMFOOCLPN sendMessageFlow;

			public ChatMessage pendingMessage;

			internal global::NCOKFFGPIJM<MMAPILLMEAH> _003CSendMessageInternal_003Eb__0(OFPDFAGJKLH.CKHCGCPJFHH packedChatMessage)
			{
				return null;
			}

			internal void _003CSendMessageInternal_003Eb__1(MMAPILLMEAH sendMessageResponse)
			{
			}

			internal void _003CSendMessageInternal_003Eb__2(string error)
			{
			}

			internal void _003CSendMessageInternal_003Eb__3()
			{
			}
		}

		private sealed class DOCGBIMCAJG
		{
			public ChatThreadModel _003C_003E4__this;

			public RoomPickerDialogModel roomPickerDialogModel;

			public EHEJPNFKNAL nextButton;

			internal void _003COpenRoomPickerDialog_003Eb__1()
			{
			}

			internal bool _003COpenRoomPickerDialog_003Eb__2()
			{
				return false;
			}

			internal void _003COpenRoomPickerDialog_003Eb__3(JCDPHCELKHI room)
			{
			}

			internal void _003COpenRoomPickerDialog_003Eb__0(BaseDialogModel<DAPFKAIPKPO> dialog)
			{
			}
		}

		private sealed class EPALNNNBDIB
		{
			public ChatThreadModel _003C_003E4__this;

			public int currentIndex;

			public EHEJPNFKNAL selectButton;

			internal void _003COpenClubPickerDialog_003Eb__3()
			{
			}

			internal bool _003COpenClubPickerDialog_003Eb__4()
			{
				return false;
			}

			internal bool _003COpenClubPickerDialog_003Eb__0(int index)
			{
				return false;
			}

			internal bool _003COpenClubPickerDialog_003Eb__1(int index)
			{
				return false;
			}

			internal void _003COpenClubPickerDialog_003Eb__5(GameObject instance, int index, CardModel cardModel, ClubModel clubModel, JLOCLGGLOPP toCardController)
			{
			}

			internal int _003COpenClubPickerDialog_003Eb__6()
			{
				return 0;
			}

			internal void _003COpenClubPickerDialog_003Eb__7(int id)
			{
			}

			internal void _003COpenClubPickerDialog_003Eb__2(BaseDialogModel<KCOKPCOFDIM> dialog)
			{
			}
		}

		private sealed class FENKECEBOMN
		{
			public int index;

			public EPALNNNBDIB CS_0024_003C_003E8__locals1;

			internal string _003COpenClubPickerDialog_003Eb__8()
			{
				return null;
			}

			internal string _003COpenClubPickerDialog_003Eb__9()
			{
				return null;
			}
		}

		private sealed class AHLIANJAGLL
		{
			public ChatThreadModel _003C_003E4__this;

			public EHEJPNFKNAL selectButton;

			public Predicate<LPLGFMCLLMC> _003C_003E9__10;

			internal void _003COpenEventPickerDialog_003Eb__3()
			{
			}

			internal bool _003COpenEventPickerDialog_003Eb__4()
			{
				return false;
			}

			internal bool _003COpenEventPickerDialog_003Eb__0(int index)
			{
				return false;
			}

			internal bool _003COpenEventPickerDialog_003Eb__1(int index)
			{
				return false;
			}

			internal void _003COpenEventPickerDialog_003Eb__5(GameObject instance, int index, CardModel cardModel, EventModel eventModel, JLOCLGGLOPP toCardController)
			{
			}

			internal int _003COpenEventPickerDialog_003Eb__6()
			{
				return 0;
			}

			internal bool _003COpenEventPickerDialog_003Eb__10(LPLGFMCLLMC e)
			{
				return false;
			}

			internal void _003COpenEventPickerDialog_003Eb__7(int id)
			{
			}

			internal void _003COpenEventPickerDialog_003Eb__2(BaseDialogModel<KCOKPCOFDIM> dialog)
			{
			}
		}

		private sealed class DPEHHIGLOGG
		{
			public int index;

			public AHLIANJAGLL CS_0024_003C_003E8__locals1;

			internal string _003COpenEventPickerDialog_003Eb__8()
			{
				return null;
			}

			internal string _003COpenEventPickerDialog_003Eb__9()
			{
				return null;
			}
		}

		private const int APHFHABPIHN = 3;

		private const int MFBPCMFHBPG = 25;

		private const int PKLFILHHLNM = 40;

		private const string EAOGHDAGHBH = "Photo Picker";

		private const string GGPIJAADEJN = "Room Picker";

		private const string GABHFIKNMAL = "Club Picker";

		private const string FGONGCMKFOL = "Event Picker";

		private readonly global::HHOBPMOCKMJ<ChatMessage> MFJJHBNPAPA;

		private readonly object MKIEMEFJIMJ;

		private int ACCIPJHKFMG;

		private readonly List<ChatMessage> CKECBEJCMHG;

		private AHJNDOAGBDE AJCHGBGGJFK;

		private ABHMLFLBAKD JPJJGBAKKNP;

		private DEEMBIEOJJH IOMOGJIIHEP;

		private DCCDAPLPICN IBDKAJJPLGA;

		private CDLILHDKGGD HEKDJDKMAPC;

		private FMEDMCFGHFM AKBAEHGOGCL;

		private string DCFOPEHPMEJ;

		private string BNOHGIGADKJ;

		private string[] IPCJPIKNGIJ;

		private long? AJGPCPPJOBD;

		private KEJOIDAKHLL? LFLJHOPHNLD;

		private bool GCFFNMLIFPE;

		private string GHAKGNKPNKI;

		private DCCDAPLPICN LKPLMCAEDAD;

		private CDLILHDKGGD GDPDKMDOBMH;

		[SerializeField]
		private bool alwaysMarkAsRead;

		private bool LMFOIHOJHEL;

		[SerializeField]
		private LFFKCMNFNAN chatTelemetrySource;

		private JCDPHCELKHI IHKKLOOELFM;

		private EPILDIJELPG OINOPFPJALM;

		private IMIJPHJKLIM ICJJEPGABMA;

		private readonly List<PCMAOOOAJLE> FBMBJEJNPCO;

		private readonly List<LPLGFMCLLMC> NDBGCPBBBBI;

		private LAHBDKNMNHN FFPBPBAKAAN;

		private LAHBDKNMNHN ICJAIDCAEBH;

		private PickerDialogModel DKIIJDODEMG;

		private ManagedTexture PHDELAPLILN;

		private long AFJHCFCJIKP;

		private bool MLOHFDMBINN;

		private bool PKIOBLNLHPB;

		private string JLFNOFNEKOC;

		private string POMBGAFIDDN;

		private EJBAHPMBHMO GJFGDNPPFDA;

		private MessageWithInputFieldDialogModel OAOPEEIPPPO;

		private EHEJPNFKNAL APPCIBJDJDD;

		private EHEJPNFKNAL EFKFMGIDFEK;

		private IPGOOJIFBAB DDNCFCIAFCD;

		private MessageDialogModel DKJPHOGCFKI;

		private EHEJPNFKNAL GBBLCGLMCNE;

		private EHEJPNFKNAL HDEEAIEPEOP;

		private bool IFMMIOHIFFF;

		private readonly List<ChatMessage> FDPCBHBOPDF;

		private const int BEJKBGLNDFG = 6;

		private const float ONPMEFDMGHF = 5f;

		private const float IGNOAPNEFNN = 60f;

		private MPBBNJKOEPO FKJILHAICPA;

		private string OFCFPGACNJB;

public global::HHOBPMOCKMJ<ChatMessage> ChatMessageToolbarActivated
{
get 		{
			return null;
		}

}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

protected override BMBBHLIOIIF CHGIJCOGJED
{
get 		{
			return default;
		}

}

public FMEDMCFGHFM ChatThread
{
get 		{
			return null;
		}

private set {
		}
}

public string ChatThreadName
{
get 		{
			return null;
		}

private set {
		}
}

public string ChatThreadImageName
{
get 		{
			return null;
		}

private set {
		}
}

public string[] GroupChatImageNames
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsUnread
{
get 		{
			return false;
		}

}

public bool IsSnoozed
{
get 		{
			return false;
		}

}

public bool IsFavorited
{
get 		{
			return false;
		}

}

public bool IsLong
{
get 		{
			return false;
		}

}

public bool IsClubChat
{
get 		{
			return false;
		}

}

public long? ClubId
{
get 		{
			return null;
		}

private set {
		}
}

public KEJOIDAKHLL? LocalClubMembershipType
{
get 		{
			return null;
		}

private set {
		}
}

public bool ShowMediaMenu
{
get 		{
			return false;
		}

private set {
		}
}

public bool ChatThreadHasSingleImage
{
get 		{
			return false;
		}

}

public string LastInputMethod
{
get 		{
			return null;
		}

private set {
		}
}

private DCCDAPLPICN PAAHLKLHMOL
{
get 		{
			return null;
		}

}

private CDLILHDKGGD FGFFCFFCEPN
{
get 		{
			return null;
		}

}

public long ChatThreadId
{
get 		{
			return 0L;
		}

private set {
		}
}

public bool FetchRecentMessages
{
get 		{
			return false;
		}

private set {
		}
}

public bool MarkAsRead
{
get 		{
			return false;
		}

private set {
		}
}

public string PreviewMessageText
{
get 		{
			return null;
		}

private set {
		}
}

public string PreviewMessageTimeSentString
{
get 		{
			return null;
		}

}

public IReadOnlyList<ChatMessage> ChatMessages
{
get 		{
			return null;
		}

}

public string Message
{
get 		{
			return null;
		}

set {
		}
}

		private int BGEPPLDHJIL()
		{
			return 0;
		}

		private bool AJAALAAHDMJ(int ECNGPJPBBGC)
		{
			return false;
		}

		public void UpdateLastInputMethod(string COANOKHNGFH)
		{
		}

		public void Set(long FFBALOOMPIB, bool FPBMILBKHIF, bool GHOKIEMFPLB = false, bool OCJIEBBBCLM = false, bool KAGIMFAPGOG = false)
		{
		}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		private void HCMKLHAIPPB(FMEDMCFGHFM AAMFKNLLGDC)
		{
		}

		private void LDOJKFDBJDH(ChatMessage OFCFPGACNJB)
		{
		}

		public void OnChatMessageToolbarActivated(ChatMessage OFCFPGACNJB)
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF(DAKMOAKIKIC MIEKCPMBJHD)
		{
			return null;
		}

		private LAHBDKNMNHN MNBEJHIEKFE()
		{
			return null;
		}

		private LAHBDKNMNHN CEKOHKCAILH()
		{
			return null;
		}

		private LAHBDKNMNHN NNEFOPFDKAD()
		{
			return null;
		}

		public void ShowAddPlayersToChatDialog()
		{
		}

		public void ShowRenameChatDialog()
		{
		}

		public void ToggleIsSnoozed()
		{
		}

		public void ToggleIsFavorited()
		{
		}

		public void ShowLeaveChatDialog()
		{
		}

		public void UnpackMessage(ChatMessage EMLJIHEPIFJ)
		{
		}

		public void FetchOlderMessages(int BFFJHKFEFPP = 8)
		{
		}

		public int GetUnreadMessageCount()
		{
			return 0;
		}

		private void PGBPBBGLBDJ()
		{
		}

		public bool CanSendTextMessage()
		{
			return false;
		}

		public bool CanSendMessage()
		{
			return false;
		}

		public bool CanSendMessage(OFPDFAGJKLH.DBGOCJDEIIN AEJFDELMCJN)
		{
			return false;
		}

		public bool TrySendTextMessage(ABMCIGNLAMN OAAHDHHOONB = null)
		{
			return false;
		}

		public bool TrySendMessage(OFPDFAGJKLH.DBGOCJDEIIN AEJFDELMCJN, ABMCIGNLAMN OAAHDHHOONB = null)
		{
			return false;
		}

		private void HNLCAOBNFNG(OFPDFAGJKLH.DBGOCJDEIIN AEJFDELMCJN, ABMCIGNLAMN OAAHDHHOONB)
		{
		}

		public void OpenPhotoPickerDialog()
		{
		}

		public void OpenRoomPickerDialog()
		{
		}

		private LAHBDKNMNHN EDGDJHJIPAI()
		{
			return null;
		}

		public void TryAddClubToChat()
		{
		}

		private void LFOIDFNKBCM()
		{
		}

		public void TryAddEventToChat()
		{
		}

		private LAHBDKNMNHN JBLLPMHIHCC()
		{
			return null;
		}

		private void NJGKDPIICNL()
		{
		}

		public void OpenPartyInviteConfirmationDialog()
		{
		}

		public void SetShowMediaMenu(bool DKEALENEDFB)
		{
		}

		[CompilerGenerated]
		private void GFAACDHMCHE(FJHBMHDECLE JDBHABEFGKF)
		{
		}

		[CompilerGenerated]
		private void CDLICKOCJBK(List<DFDECAEJBIO> AGIGKKMBEKN)
		{
		}

		[CompilerGenerated]
		private void KGAGBOPKCLF()
		{
		}

		[CompilerGenerated]
		private void IGOCBEDCBKD()
		{
		}

		[CompilerGenerated]
		private string PFDJCMEGGLM()
		{
			return null;
		}

		[CompilerGenerated]
		private void ODGPOODLGPJ(string IBALDFBGBGL)
		{
		}

		[CompilerGenerated]
		private void HDPBIDMNPMJ(BaseDialogModel<EJBAHPMBHMO> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void IOMMDGFPLMA(string DEDCJFPLNNP)
		{
		}

		[CompilerGenerated]
		private void IGDJLIMKLJB(HEIHKKOLIID CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void ACDHEPOCGON(HEIHKKOLIID CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void MLPFHGOPJNB(HEIHKKOLIID CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void GEKCIMNPOIP()
		{
		}

		[CompilerGenerated]
		private void FEILLLHACLF()
		{
		}

		[CompilerGenerated]
		private void IOOHDGCPHLM(BaseDialogModel<IPGOOJIFBAB> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void BKAEDHFMGFG()
		{
		}

		[CompilerGenerated]
		private void DPDMCEKFHOM(List<GDHOAGNFOBD.FPPNEFOBPMC> HELFDDGIAMB)
		{
		}

		[CompilerGenerated]
		private void FAFODLKNGAB(string NPOEAPJKNFN)
		{
		}

		[CompilerGenerated]
		private void EIJCGPOAEFM(GDHOAGNFOBD.FPPNEFOBPMC IECDHEIBMJN)
		{
		}

		[CompilerGenerated]
		private void AOFCDNECCDG(List<EPILDIJELPG> NDAEMCFLEJP)
		{
		}

		[CompilerGenerated]
		private void CIMJBELHLLP(EPILDIJELPG APMHMCKALGG)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<List<IKHILDIPMEJ>> NDFCEGHEDEB(List<string> CMBMOBEBGIN)
		{
			return null;
		}

		[CompilerGenerated]
		private IKHILDIPMEJ BFCBJBFHLBD(IKHILDIPMEJ CDNLFEOBNKB)
		{
			return null;
		}

		[CompilerGenerated]
		private void DHLCBLPAGMO(EPILDIJELPG APMHMCKALGG)
		{
		}

		[CompilerGenerated]
		private void NJLPPNHIHBJ()
		{
		}

		[CompilerGenerated]
		private void JHCDMBFDMMB()
		{
		}

		[CompilerGenerated]
		private void INGCCPKCFGG(List<IMIJPHJKLIM> IAOPBOEHEOP)
		{
		}

		[CompilerGenerated]
		private void GLKFMDPHBJG(List<IMIJPHJKLIM> IAOPBOEHEOP)
		{
		}

		[CompilerGenerated]
		private void CPCMLCFBIIC(OFPDFAGJKLH.DBGOCJDEIIN OFCFPGACNJB)
		{
		}
	}
}
