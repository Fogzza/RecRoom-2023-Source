using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using AGUI.StackedUI.Dialog;
using CodeStage.AntiCheat.ObscuredTypes;
using RecNet;
using UnityEngine;

namespace RecRoom
{
	public class FeedbackManager : NetworkedSingletonMonoBehaviour<FeedbackManager>
	{
		public delegate void PNGKMPDOEIL(long EPOBIFCHLNM, long? FJGKDBAFAGH);

		private struct EILAAFJDKIG
		{
			internal uint CCDOFJIBKBL;

			internal long CLFEFELBBMO;

			internal bool MBDNGCPNMAB;

			internal bool DACHMLEENIN;
		}

		private struct JCJHNDNOADE
		{
			internal RoomComment DOFALOMFBML;

			internal RoomCommentView ACGNMMNNNHH;

			internal bool GCMCNOKCMHC;
		}

		private sealed class GLCCBNGLDNO
		{
			public FeedbackManager _003C_003E4__this;

			public long roomId;

			public long? subRoomId;

			internal void _003CViewComments_003Eb__0(List<RoomComment> newComments)
			{
			}

			internal IEnumerable<RoomComment> _003CViewComments_003Eb__1()
			{
				return null;
			}
		}

		private sealed class KHAFNPGNCIP
		{
			public FeedbackManager _003C_003E4__this;

			public Vector3? commentPosition;

			public Action<long> _003C_003E9__3;

			public Action<RoomCommentInputUIDialog.FEOELPHFMGC> _003C_003E9__1;

			internal void _003CTryShowCreateCommentDialog_003Eb__0(RoomCommentInputUIDialog flow)
			{
			}

			internal void _003CTryShowCreateCommentDialog_003Eb__1(RoomCommentInputUIDialog.FEOELPHFMGC r)
			{
			}

			internal void _003CTryShowCreateCommentDialog_003Eb__3(long commentId)
			{
			}
		}

		private sealed class DNKLEKLHOBH
		{
			public RoomCommentInputUIDialog.FEOELPHFMGC r;

			public KHAFNPGNCIP CS_0024_003C_003E8__locals1;

			internal void _003CTryShowCreateCommentDialog_003Eb__2()
			{
			}
		}

		private sealed class DKGPEBAKPAD
		{
			public long roomId;

			public RoomComment.LDMAFFPGJCL style;

			public Vector3? position;

			public FeedbackManager _003C_003E4__this;

			public long subRoomId;

			internal void _003CCreateComment_003Eb__0(RoomComment comment)
			{
			}
		}

		private sealed class GLELCLOLALL
		{
			public FeedbackManager _003C_003E4__this;

			public long roomId;

			public long? subRoomId;

			public long id;

			internal void _003CDeleteComment_003Eb__0()
			{
			}
		}

		private sealed class CBKKLCFGKMN
		{
			public DFDECAEJBIO account;

			public RoomComment model;

			public FeedbackManager _003C_003E4__this;

			internal void _003CReportComment_003Eb__0(ReportWatchUIFlow reportFlow)
			{
			}

			internal void _003CReportComment_003Eb__2()
			{
			}
		}

		private sealed class OOAJGFNAFGL
		{
			public DFDECAEJBIO account;

			internal void _003CCheerComment_003Eb__0(CheerPlayerWatchUIFlow flow)
			{
			}
		}

		private sealed class PJCJIBGMJHE
		{
			public DFDECAEJBIO account;

			internal void _003CShowCommenterInfo_003Eb__0(RRUIRootScreen flow)
			{
			}
		}

		private sealed class HGJLMANIDMO
		{
			public FeedbackManager _003C_003E4__this;

			public long roomId;

			internal uint _003CGetUnreadCommentsCount_003Eb__0()
			{
				return 0u;
			}
		}

		private sealed class APOIBJAHHPF
		{
			public RoomComment comment;

			public FeedbackManager _003C_003E4__this;

			public Action<ANAGHNCECEB> _003C_003E9__2;

			public Action<LCEKCFEIEGJ> _003C_003E9__1;

			internal void _003CTeleportToComment_003Eb__0(HGKINAOMNIF confirmLeaveRoomResponse)
			{
			}

			internal void _003CTeleportToComment_003Eb__1(LCEKCFEIEGJ roomDetails)
			{
			}

			internal void _003CTeleportToComment_003Eb__2(ANAGHNCECEB result)
			{
			}
		}

		private sealed class KFAHPFJPDBM
		{
			public long roomId;

			internal bool _003CGetCachedComments_003Eb__0(KeyValuePair<long, JCJHNDNOADE> x)
			{
				return false;
			}
		}

		private sealed class LKBBJEPIBGD
		{
			public FeedbackManager _003C_003E4__this;

			public RoomComment comment;

			public bool notify;

			internal void _003COnCommentCreated_003Eb__0()
			{
			}
		}

		private sealed class PBHCOBABIKE
		{
			public long roomId;

			internal bool _003COnCommentsReceived_003Eb__0(BJCIKFCDBFN m)
			{
				return false;
			}
		}

		private sealed class BKMEAPLMHBL
		{
			public long roomId;

			internal bool _003COnRoomDetailsUpdated_003Eb__0(KeyValuePair<long, JCJHNDNOADE> kvp)
			{
				return false;
			}

			internal bool _003COnRoomDetailsUpdated_003Eb__1(KeyValuePair<long, JCJHNDNOADE> kvp)
			{
				return false;
			}
		}

		private sealed class NPDDOMKELFO
		{
			public RoomComment comment;

			public FeedbackManager _003C_003E4__this;

			public RoomCommentView view;

			internal bool _003CTeleportAndViewComment_003Eb__0()
			{
				return false;
			}

			internal void _003CTeleportAndViewComment_003Eb__1()
			{
			}

			internal bool _003CTeleportAndViewComment_003Eb__2()
			{
				return false;
			}
		}

		private sealed class FKKALKIKBCJ : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public RoomComment comment;

			public FeedbackManager _003C_003E4__this;

			private NPDDOMKELFO _003C_003E8__1;

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
			public FKKALKIKBCJ(int _003C_003E1__state)
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

		private const int ABHEFFDKJGF = 5;

		[SerializeField]
		private FeedbackSettings settings;

		private PNGKMPDOEIL GBLEAKJKIOK__BackingField;

		private readonly Dictionary<long, EILAAFJDKIG> CECGEDKICOA;

		private Dictionary<long, JCJHNDNOADE> FKFOCGIKMOK;

		private long? NLOPLMMCEKK;

		private global::HBBHKKBNKHE<long, long?> BNBCBHNLJBB;

		private LAHBDKNMNHN ELIBFFFIENO;

		private long? EPNJGMMOKEA;

		private readonly global::LPOCMKDAPMN<RRUIRootScreen> GPBPNBCOHGG;

		private readonly global::LPOCMKDAPMN<ReportWatchUIFlow> PKIPMAIEAJI;

		private readonly global::LPOCMKDAPMN<CheerPlayerWatchUIFlow> OKMIHCINICL;

		private readonly global::LPOCMKDAPMN<RoomCommentInputUIDialog> CLDADDLBPLG;

		private MPBBNJKOEPO MBLPGKKGAIA;

		private LKGILLBEJEK OIKEDIODNEF;

public FeedbackSettings Settings
{
get 		{
			return null;
		}

}

public bool IsShowingRoomCommentDialog
{
get 		{
			return false;
		}

}

public event PNGKMPDOEIL RoomCommentsUpdated {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		public global::NCOKFFGPIJM<IEnumerable<RoomComment>> ViewComments(long EPOBIFCHLNM, long? FJGKDBAFAGH = null, bool KAGIMFAPGOG = false)
		{
			return null;
		}

		public void TryShowCreateCommentDialog(Vector3? FKDLGKMIKJM, string LDPCFDMCJLH)
		{
		}

		public global::NCOKFFGPIJM<long> CreateComment(long EPOBIFCHLNM, long FJGKDBAFAGH, string OFCFPGACNJB, RoomComment.LDMAFFPGJCL IECPKMLJDCJ, Vector3? INLGLHIPOMC)
		{
			return null;
		}

		public void DeleteComment(long IKHNIJKGJFD)
		{
		}

		public void ReportComment(long HCCCNNLPPIG, string LDPCFDMCJLH)
		{
		}

		public void CheerComment(long HCCCNNLPPIG, string LDPCFDMCJLH)
		{
		}

		public void ShowCommenterInfo(long HCCCNNLPPIG, string LDPCFDMCJLH)
		{
		}

		public RoomCommentView GetCommentViewById(long IKHNIJKGJFD)
		{
			return null;
		}

		public bool TryGetCachedUnreadCommentsCount(long EPOBIFCHLNM, out uint MDMENAADBFB)
		{
			MDMENAADBFB = default;
			return false;
		}

		public global::NCOKFFGPIJM<uint> GetUnreadCommentsCount(long EPOBIFCHLNM)
		{
			return null;
		}

		public static bool IsLocalPlayerCommentRecipient(long EPOBIFCHLNM)
		{
			return false;
		}

		public bool CanPlayerViewRoomComment(int EJIHLJJMOBD, long HCCCNNLPPIG)
		{
			return false;
		}

		public static bool AreCommentsEnabledInRoom(long EPOBIFCHLNM, out string CKHHGBNHHCK)
		{
			CKHHGBNHHCK = null;
			return false;
		}

		public static bool CanLocalPlayerViewOrCreateComments(long EPOBIFCHLNM, out string CKHHGBNHHCK)
		{
			CKHHGBNHHCK = null;
			return false;
		}

		public bool CanLocalPlayerTeleportToComment(long HCCCNNLPPIG)
		{
			return false;
		}

		public void TeleportToComment(long HCCCNNLPPIG)
		{
		}

		public void EquipFeedbackTool()
		{
		}

		internal static void JCBEJCHIJFI()
		{
		}

		private IEnumerable<RoomComment> DAPKNJLMOEL(long EPOBIFCHLNM)
		{
			return null;
		}

		private static IEnumerable<ObscuredInt> IFMNKMKMBPH(long EPOBIFCHLNM)
		{
			return null;
		}

		private void HJMDOEAALNG(RoomComment EBGODOGHKGD, bool EGLELFEBFKC, bool GLKBGPHMMNC)
		{
		}

		private void CGBEIPDKBLM(RoomComment EBGODOGHKGD, bool EGLELFEBFKC)
		{
		}

		private void CAHPHKKONNK(RoomCommentView AIJGHMFIACN)
		{
		}

		private void OAGOKAJACJG(long HCCCNNLPPIG, bool EGLELFEBFKC)
		{
		}

		private void DLKHIDNBIIB(long HCCCNNLPPIG)
		{
		}

		private void LFKDDPKIIPJ(long EPOBIFCHLNM, long? FJGKDBAFAGH, IReadOnlyCollection<RoomComment> APHIMJPLDDK)
		{
		}

		private EILAAFJDKIG IJBDMNALEPC(long EPOBIFCHLNM)
		{
			return default;
		}

		private JCJHNDNOADE BGIOCPGBGPE(long HCCCNNLPPIG)
		{
			return default;
		}

		private LAHBDKNMNHN JHNGDLOBKJL()
		{
			return null;
		}

		private static void BPEIEKHMLKO()
		{
		}

		private void ENGIMCOBPLG(long EPOBIFCHLNM)
		{
		}

		private static bool PDHNILHELMI()
		{
			return false;
		}

		private static void PJLIJEAAFDC()
		{
		}

		private bool IBHNFBAJPHC(DMAIEODHOGA OFCFPGACNJB)
		{
			return false;
		}

		private void IDKAANCLEMG()
		{
		}

		private void ACDMIKKLIKB(long HCCCNNLPPIG)
		{
		}

		private IEnumerator<EGGPGCCKPCO> BCOLACLIONE(RoomComment EBGODOGHKGD)
		{
			return null;
		}

		private static Vector3 CKKNOFNCGDE(Vector3 FKDLGKMIKJM, float FBEFGKCAHCL)
		{
			return default;
		}

		private void GBEILGJPHID()
		{
		}

		protected override void OnDestroy()
		{
		}

		[PBOMGCLBFHF]
		private void RpcCommentCreated(RoomComment EBGODOGHKGD)
		{
		}

		[PBOMGCLBFHF]
		private void RpcCommentDeleted(long HCCCNNLPPIG)
		{
		}

		[CompilerGenerated]
		private void AKMKBNHGHCC(Dictionary<long, uint> IENFNJLMHAN)
		{
		}
	}
}
