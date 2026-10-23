using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google.Protobuf;
using RecRoom.Systems.PlayerRoles;

public struct NGJPBEEINBG
{
	private sealed class ILMPFIKKILK
	{
		public Func<byte> filterModeGetter;

		public Action<byte> filterModeSetter;

		public Func<KLNOBKBCIEK> filteredRolesGetter;

		public Action<KLNOBKBCIEK> filteredRolesSetter;

		internal int _003CGetDynamicUIElementDataFromSettings_003Eb__4()
		{
			return 0;
		}

		internal void _003CGetDynamicUIElementDataFromSettings_003Eb__5(int value)
		{
		}

		internal void _003CGetDynamicUIElementDataFromSettings_003Eb__6(IEnumerable<GameRole> value)
		{
		}

		internal string _003CGetDynamicUIElementDataFromSettings_003Eg__GetDialogTitle_007C0()
		{
			return null;
		}

		internal IEnumerable<GameRole> _003CGetDynamicUIElementDataFromSettings_003Eg__GetSelectedGameRoles_007C2()
		{
			return null;
		}

		internal void _003CGetDynamicUIElementDataFromSettings_003Eg__SetSelectedGameRoles_007C3(IEnumerable<GameRole> gameRoles)
		{
		}
	}

	private sealed class EOGNAPCFOCL : IEnumerable<KLNOBKBCIEK>, IEnumerable, IEnumerator<KLNOBKBCIEK>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private KLNOBKBCIEK _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private KLNOBKBCIEK gameRoleIdFlags;

		public KLNOBKBCIEK _003C_003E3__gameRoleIdFlags;

		private PlayerGameRoleManager _003Cmanager_003E5__2;

		private IReadOnlyList<KLNOBKBCIEK> _003CallGameRoleIds_003E5__3;

		private int _003Ci_003E5__4;

		private int _003Cn_003E5__5;

 KLNOBKBCIEK global::System.Collections.Generic.IEnumerator<global::KLNOBKBCIEK>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ESystems_002EPlayerRoles_002EGameRoleId_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public EOGNAPCFOCL(int _003C_003E1__state)
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
		private KLNOBKBCIEK System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ESystems_002EPlayerRoles_002EGameRoleId_003E_002Eget_Current()
		{
			return KLNOBKBCIEK.AG_EVERYONE;
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}

		[DebuggerHidden]
		IEnumerator<KLNOBKBCIEK> IEnumerable<KLNOBKBCIEK>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	private static readonly Dictionary<string, MIBJNNKFLND> NPODNNHIGDO;

	private static readonly BGMIHEHEHNF BNGIODOMKKD;

	private readonly global::MOBDJNEDDKC<byte> CBHLFHBHKMB;

	private readonly global::MOBDJNEDDKC<KLNOBKBCIEK> MCHKCLFEEBC;

public MPBKCJHALJD PDLPCFLDBEP
{
get 	{
		return MPBKCJHALJD.EnabledForRole;
	}

set {
	}
}

public KLNOBKBCIEK GDGMLOAEOAB
{
get 	{
		return KLNOBKBCIEK.AG_EVERYONE;
	}

set {
	}
}

public bool PJMDAHNGEIN
{
get 	{
		return false;
	}

}

public bool BFAFHHNJDGF
{
get 	{
		return false;
	}

}

public bool LICFCPHOANC
{
get 	{
		return false;
	}

}

public bool GMKFCLEHMPC
{
get 	{
		return false;
	}

}

public bool FPKABOPHGCO
{
get 	{
		return false;
	}

}

	public NGJPBEEINBG(JPEAKDKPCGM DELCOFCGDFF, string FDAIMOMOHIG, DILMPKDFOOO OBGIDDDNPCM, Action ONAFALABHKI = null)
	{
		CBHLFHBHKMB = null;
		MCHKCLFEEBC = null;
	}

	public DGMPBIPKJEB CPFPFJKOHOA(Action<CLKEJFGKNDK, KCOKPCOFDIM> GFNPBKFLPEB, string OFMGPNLDCAB = "Interaction Filter", Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null)
	{
		return null;
	}

	public static DGMPBIPKJEB NBEEFHOLHJG(Func<byte> GKIHKPEBCCO, Action<byte> ONPFPHLJKFA, Func<KLNOBKBCIEK> IFKDINNKOKD, Action<KLNOBKBCIEK> GDGHDJLEOPO, Action<CLKEJFGKNDK, KCOKPCOFDIM> GFNPBKFLPEB, string OFMGPNLDCAB = "Interaction Filter", Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null)
	{
		return null;
	}

	public bool ALJKCFGGOJH(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	public static bool FCCGHFMLPLD(MPBKCJHALJD PHHCPCADEEM, KLNOBKBCIEK AKGJELEIMAD, bool LJMLLJKEPDD, CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	public void BBCFAILGGHN(DKKJDAJBGGJ PCPEJHIMHJJ)
	{
	}

	public DKKJDAJBGGJ IIADKJHBOIN()
	{
		return null;
	}

	public static Guid[] JKOEPECADGK(KLNOBKBCIEK AKGJELEIMAD)
	{
		return null;
	}

	public static ByteString ENJFIGHINPK(Guid[] EJOCLPIJNHL)
	{
		return null;
	}

	public static Guid[] IBJJJOEKKBH(ByteString KPEMNJPDMIK)
	{
		return null;
	}

	private static void JODGAEMNMMI(ByteString EAJEPHGIKOJ, int AFEPAGBHLLE, byte[] CHAIEAFFHGK)
	{
	}

	private static IEnumerable<KLNOBKBCIEK> MKONPAHGONP(KLNOBKBCIEK AKGJELEIMAD)
	{
		return null;
	}

	[CompilerGenerated]
	internal static IEnumerable<GameRole> AGFECIJAGOP()
	{
		return null;
	}
}
