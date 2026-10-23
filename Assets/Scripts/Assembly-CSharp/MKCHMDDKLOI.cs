using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

[KALJIFHMJGE]
public class MKCHMDDKLOI : FLPGLADCKPI, ONIMCMMPJIP
{
	[Serializable]
	internal struct GoToRoomData
	{
		[JsonRequired]
		public string RoomName { get; internal set; }
	}

	[Serializable]
	internal struct ShowRoomDetailsData
	{
		[JsonRequired]
		public long RoomId { get; internal set; }
	}

	[Serializable]
	internal struct ShowAccountDetailsData
	{
		[JsonRequired]
		public int AccountId { get; internal set; }
	}

	[Serializable]
	internal struct ShowMessageData
	{
		[JsonRequired]
		public long MessageId { get; internal set; }
	}

	[Serializable]
	internal struct ShowStorefrontData
	{
		[JsonRequired]
		public string StorefrontUri { get; internal set; }
	}

	[Serializable]
	internal struct ShowPurchasableItemDetailsData
	{
		[JsonRequired]
		public int PurchasableItemId { get; set; }
	}

	[Serializable]
	internal struct ShowCustomAvatarItemStorePageData
	{
		[JsonRequired]
		public Guid CustomAvatarItemId { get; internal set; }
	}

	[Serializable]
	internal struct AcceptGameInviteData
	{
		[JsonRequired]
		public int FromAccountId { get; internal set; }
	}

	private sealed class MCIFLEOEKMB
	{
		public DMBFOKGBCAD action;

		public MKCHMDDKLOI _003C_003E4__this;

		public string data;

		public HHINBGJONJA entrypointData;

		internal LAHBDKNMNHN _003CPerformAction_003Eb__0()
		{
			return null;
		}
	}

	private sealed class DLJPJCLBAMG
	{
		public MKCHMDDKLOI _003C_003E4__this;

		public string roomName;

		public DBECJLAIPEL loadSceneSource;

		public bool isPrivate;

		internal void _003CGoToRoom_003Eb__0()
		{
		}

		internal LAHBDKNMNHN _003CGoToRoom_003Eb__1()
		{
			return null;
		}
	}

	private sealed class PIOBLMKPLBE
	{
		public DBIPHDIEBCM joinRoomPromise;

		internal void _003CGoToRoom_003Eb__2(ANAGHNCECEB result)
		{
		}
	}

	private sealed class MLOCIHHJDBK
	{
		public MKCHMDDKLOI _003C_003E4__this;

		public ShowRoomDetailsData data;

		public DBECJLAIPEL loadSceneSource;

		internal void _003CShowRoomDetails_003Eb__0(JCDPHCELKHI room)
		{
		}
	}

	private sealed class HNHNFMCNMEI
	{
		public ShowMessageData data;

		internal bool _003CShowMessage_003Eb__0(BJCIKFCDBFN m)
		{
			return false;
		}
	}

	private sealed class HOCJONAFNAE
	{
		public int fromAccountId;

		public MKCHMDDKLOI _003C_003E4__this;

		public Func<BJCIKFCDBFN, bool> _003C_003E9__1;

		internal LAHBDKNMNHN _003CAcceptGameInvite_003Eb__0()
		{
			return null;
		}

		internal bool _003CAcceptGameInvite_003Eb__1(BJCIKFCDBFN m)
		{
			return false;
		}
	}

	private sealed class COGPBJAHNLN
	{
		public BJCIKFCDBFN message;

		public HOCJONAFNAE CS_0024_003C_003E8__locals1;

		internal void _003CAcceptGameInvite_003Eb__3()
		{
		}

		internal LAHBDKNMNHN _003CAcceptGameInvite_003Eb__4()
		{
			return null;
		}
	}

	private sealed class MCHMPLMOIFI : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public MKCHMDDKLOI _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public MCHMPLMOIFI(int _003C_003E1__state)
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

	private sealed class MOAAPKEAMIB
	{
		public MKCHMDDKLOI _003C_003E4__this;

		public bool waitForWatch;

		internal bool _003CWaitForLoginNuxAndWatchTutorial_003Eb__0()
		{
			return false;
		}
	}

	private sealed class NEBJFGJDJGL : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public MKCHMDDKLOI _003C_003E4__this;

		public bool waitForWatch;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public NEBJFGJDJGL(int _003C_003E1__state)
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

	private sealed class IHOPANOINPI
	{
		private sealed class _003C_003CLaunchTargetHelper_003Eg__WaitForPlayerToLogin_007C4_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public IHOPANOINPI _003C_003E4__this;

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
			public _003C_003CLaunchTargetHelper_003Eg__WaitForPlayerToLogin_007C4_003Ed(int _003C_003E1__state)
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

		public Action setLaunchTargetFunc;

		public MKCHMDDKLOI _003C_003E4__this;

		public bool online;

		public Func<LAHBDKNMNHN> joinRoomFunc;

		internal LAHBDKNMNHN _003CLaunchTargetHelper_003Eg__ScheduleLaunchTargetLoadAfterLogin_007C0()
		{
			return null;
		}

		internal IEnumerator<EGGPGCCKPCO> _003CLaunchTargetHelper_003Eg__WaitForPlayerToLogin_007C4()
		{
			return null;
		}

		internal bool _003CLaunchTargetHelper_003Eb__5()
		{
			return false;
		}

		internal void _003CLaunchTargetHelper_003Eb__1(JBPMMJCDCHG.ODJCKKLLPME versionCheckResponse)
		{
		}

		internal void _003CLaunchTargetHelper_003Eb__2(string error)
		{
		}

		internal LAHBDKNMNHN _003CLaunchTargetHelper_003Eb__3()
		{
			return null;
		}
	}

	private readonly MPCPBBHOCIP BMPNKLOGNEA;

	private readonly GCGINIPBNAD GNJIMPJBHAO;

	private readonly CJBLEJIPCAP CHFFOIFKNEN;

	private readonly BHNJIBDJFAL NJPJBDDAEFH;

	private readonly ABLBCPBEONM JGEOGMFPMNL;

	private readonly NEPJJLMCFPM ANCKKHIAPJD;

	private readonly LHMPPJKHCJG KOCMHELAMME;

	private readonly LKDMDLACMHN KLPJCNPJHEA;

	private readonly DHAAAAKAFFD FDEMKJAIGKN;

	private readonly OHCCDNIDCMM BAKNOBPGKCE;

	private readonly FBDMPCDHLHH LDNDJAMEJDG;

	private readonly MMGNOMBNLOE HFHPAMIMIDL;

	private readonly CIBAFIDLLDB HOPPEIFHBAC;

	private readonly CJOBPJLKCLB NBNHAMKPOOO;

	private readonly KKMCCLAPGLL CCONPAMBIDE;

	private const string GMCJMCFHJHN = "MobileHomeNativePlaftormApi";

	[Preserve]
	internal MKCHMDDKLOI([NotNull] MPCPBBHOCIP BMPNKLOGNEA, [NotNull] GCGINIPBNAD GNJIMPJBHAO, [NotNull] CJBLEJIPCAP CHFFOIFKNEN, [NotNull] BHNJIBDJFAL NJPJBDDAEFH, [NotNull] ABLBCPBEONM JGEOGMFPMNL, [NotNull] NEPJJLMCFPM ANCKKHIAPJD, [NotNull] LHMPPJKHCJG KOCMHELAMME, [NotNull] LKDMDLACMHN KLPJCNPJHEA, [NotNull] DHAAAAKAFFD FDEMKJAIGKN, [NotNull] OHCCDNIDCMM BAKNOBPGKCE, [NotNull] FBDMPCDHLHH LDNDJAMEJDG, [NotNull] MMGNOMBNLOE HFHPAMIMIDL, [NotNull] CIBAFIDLLDB HOPPEIFHBAC, [NotNull] CJOBPJLKCLB NBNHAMKPOOO, [NotNull] KKMCCLAPGLL CCONPAMBIDE)
	{
	}

	private static void CPPCJDFOIOD(MNALHHOLFGL FMPHDMAKDKP)
	{
	}

	public LAHBDKNMNHN EHAEBOGFHAP(string IBKGKDECOEG, string PCPEJHIMHJJ, HHINBGJONJA MBEKGACHGAE)
	{
		return null;
	}

	public LAHBDKNMNHN EHAEBOGFHAP(DMBFOKGBCAD IBKGKDECOEG, string PCPEJHIMHJJ, HHINBGJONJA MBEKGACHGAE)
	{
		return null;
	}

	public LAHBDKNMNHN EHAEBOGFHAP(BMCGMLFFLBN ICDMMGNFMAF, HHINBGJONJA MBEKGACHGAE)
	{
		return null;
	}

	private LAHBDKNMNHN NCJNOBGABGJ(BMCGMLFFLBN ICDMMGNFMAF, HHINBGJONJA MBEKGACHGAE)
	{
		return null;
	}

	private LAHBDKNMNHN FMDBDMDPHPK(BMCGMLFFLBN ICDMMGNFMAF)
	{
		return null;
	}

	private LAHBDKNMNHN JDNOLEEKOBK()
	{
		return null;
	}

	private LAHBDKNMNHN AGMLHJOLAAA(BMCGMLFFLBN ICDMMGNFMAF)
	{
		return null;
	}

	private static bool NENGACHDOOO(DMBFOKGBCAD IBKGKDECOEG)
	{
		return false;
	}

	private LAHBDKNMNHN HJKDGGBOFFA(string NIABDMAOPHC, DBECJLAIPEL CFBNOKOADFB)
	{
		return null;
	}

	private LAHBDKNMNHN HJKDGGBOFFA(string LBGBFPDNKOL, DBECJLAIPEL CFBNOKOADFB, bool LPHLJGDKOND)
	{
		return null;
	}

	private LAHBDKNMNHN IDOCMNLDAOK(string NIABDMAOPHC, DBECJLAIPEL CFBNOKOADFB)
	{
		return null;
	}

	private LAHBDKNMNHN PBANINGIFMM(string NIABDMAOPHC)
	{
		return null;
	}

	private LAHBDKNMNHN BGNDFJFEBFJ(string NIABDMAOPHC)
	{
		return null;
	}

	private LAHBDKNMNHN JBCGFBALKNA(string NIABDMAOPHC, DBECJLAIPEL CFBNOKOADFB)
	{
		return null;
	}

	private LAHBDKNMNHN ELFNDJOCBOH(string NIABDMAOPHC, string IHAJMCMKENO, PJGPBJDBNEK.BDOPNLLKBPB OKAPDIKNLCA)
	{
		return null;
	}

	private LAHBDKNMNHN CMLACFEOFBP(string NIABDMAOPHC, string PGEIBONDJJP)
	{
		return null;
	}

	private LAHBDKNMNHN JEJGIBKAJHH(string NIABDMAOPHC, PJGPBJDBNEK.BDOPNLLKBPB OKAPDIKNLCA)
	{
		return null;
	}

	private LAHBDKNMNHN GGAGHEMIHNP(string NIABDMAOPHC)
	{
		return null;
	}

	private LAHBDKNMNHN GGAGHEMIHNP(int BFCFNCMBICC)
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> CILFEIGLNMO()
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> DJFHJIHJIML(bool OGBFBICPLGP)
	{
		return null;
	}

	private bool JBLEFJDHGMD<T>(string PCPEJHIMHJJ, out T MPHODIIJMEC)
	{
		MPHODIIJMEC = default;
		return false;
	}

	private static bool NCKCFINGFPB<T>(T PCPEJHIMHJJ, out string EDEOADKJLJK)
	{
		EDEOADKJLJK = null;
		return false;
	}

	private LAHBDKNMNHN GFECEOLMJHF(Action BJIJGCBAEFG, Func<LAHBDKNMNHN> EJPBIPEJBKM)
	{
		return null;
	}

	private void LOCMEEJEJAI(BMCGMLFFLBN ICDMMGNFMAF)
	{
	}

	void ONIMCMMPJIP.EHAEBOGFHAP(BMCGMLFFLBN ICDMMGNFMAF)
	{
		//ILSpy generated this explicit interface implementation from .override directive in LOCMEEJEJAI
		this.LOCMEEJEJAI(ICDMMGNFMAF);
	}

	[CompilerGenerated]
	private void OGEHIHJCGCD(DFDECAEJBIO ACBGBAAHOIM)
	{
	}

	[CompilerGenerated]
	private bool GCPIMDFIKLO()
	{
		return false;
	}
}
