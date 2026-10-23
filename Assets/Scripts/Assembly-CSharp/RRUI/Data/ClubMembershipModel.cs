using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using RRUI.Navigation;
using UnityEngine;

namespace RRUI.Data
{
	public class ClubMembershipModel : AccountModel
	{
		private sealed class CMHHLGHBMIF
		{
			public long clubId;

			public ClubMembershipModel _003C_003E4__this;

			public int accountId;

			public DAKMOAKIKIC refreshType;

			internal LAHBDKNMNHN _003CRefreshInternal_003Eb__0(LCFAELDOGBB membership)
			{
				return null;
			}

			internal LAHBDKNMNHN _003CRefreshInternal_003Eb__1(KEJOIDAKHLL membershipType)
			{
				return null;
			}

			internal void _003CRefreshInternal_003Eb__2(FJHBMHDECLE details)
			{
			}
		}

		private sealed class AAEMMPAJCFP
		{
			public ClubMembershipModel _003C_003E4__this;

			public ObscuredString displayName;

			internal void _003CChangeMemberType_003Eb__0()
			{
			}

			internal void _003CChangeMemberType_003Eb__1()
			{
			}
		}

		private sealed class NCLOFHAOGBN
		{
			public long removedFromClubId;

			public int removedAccountId;

			internal bool _003CRedirectAndRemoveHistory_003Eb__0(RRUI.Navigation.Uri uri)
			{
				return false;
			}
		}

		private static Dictionary<KEJOIDAKHLL, KCAECILAJLI> HKNBBJDEAJE;

		private bool EFCHGPAGNLL;

		[SerializeField]
		private Route redirectRoute;

		private long AJGPCPPJOBD;

		private FJHBMHDECLE IGNJFMPGKHH;

		private HJLGEHHNFGJ COEPPMIGODE;

		private KEJOIDAKHLL KOLGIAAOGFI;

		private KEJOIDAKHLL JBEOBENCPEO;

		private DateTime DFDBOFCNHKP;

		private bool FCPAHEPENEP;

		private List<KEJOIDAKHLL> INGJCKOPKHG;

public bool ICanModifyMembership
{
get 		{
			return false;
		}

}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public long ClubId
{
get 		{
			return 0L;
		}

private set {
		}
}

public FJHBMHDECLE ClubDetails
{
get 		{
			return null;
		}

private set {
		}
}

public HJLGEHHNFGJ MyPermissions
{
get 		{
			return null;
		}

private set {
		}
}

public KEJOIDAKHLL MembershipType
{
get 		{
			return KEJOIDAKHLL.None;
		}

private set {
		}
}

public KEJOIDAKHLL MembershipTypeBackingData
{
get 		{
			return KEJOIDAKHLL.None;
		}

private set {
		}
}

public DateTime CreatedAt
{
get 		{
			return default;
		}

private set {
		}
}

public bool ShouldUpdateMembershipChangeDropdownOptions
{
get 		{
			return false;
		}

private set {
		}
}

		public static KCAECILAJLI GetMaskForMembershipType(KEJOIDAKHLL IIDIPBJDGKB)
		{
			return (KCAECILAJLI)0;
		}

		public void Set(long AFPHABFLEBN, int EJIHLJJMOBD, bool EFCHGPAGNLL = false, bool BFNPOCBNJFB = false)
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF(DAKMOAKIKIC MIEKCPMBJHD)
		{
			return null;
		}

		public List<KEJOIDAKHLL> GetChangeMembershipTypes()
		{
			return null;
		}

		public int GetDropdownDefaultValue()
		{
			return 0;
		}

		public void SetMembershipTypeByDropdownIndex(int GMEHLIHLGEH)
		{
		}

		public void ChangeMemberType()
		{
		}

		public void ConfirmRemoveMember()
		{
		}

		private void GFNECILPEGO()
		{
		}

		public void ConfimBanAccount()
		{
		}

		private void GEHEGJOHMFB()
		{
		}

		private void IKJAJGKNEFC(long JANJFPFFCCD, int JLFGIINMAHO)
		{
		}

		private void FFNOAAPABKE()
		{
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private LAHBDKNMNHN NBECFFIAJMM(DAKMOAKIKIC KMDKPCPJKJH)
		{
			return null;
		}

		[CompilerGenerated]
		private bool PJMFOHOLNJD(KEJOIDAKHLL CJHEDPFOCKO)
		{
			return false;
		}

		[CompilerGenerated]
		private void GOINPIOEPBE()
		{
		}

		[CompilerGenerated]
		private void IBEEINLGIBO()
		{
		}
	}
}
