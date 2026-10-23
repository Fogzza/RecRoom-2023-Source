using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using UnityEngine;
using UnityEngine.Localization;

namespace RRUI.Data
{
	public class FriendImportModel : RRUIModel, LIHJONGLFEC, NJIIBNCBBMK, KGDCCAIMMGC
	{
		private sealed class HLDMPBPONPL
		{
			public JJGPKBPPDHH friend;

			public FriendImportModel _003C_003E4__this;

			internal void _003COnShowInternal_003Eg__OnPlatformImage_007C7(Texture platformImage)
			{
			}

			internal void _003COnShowInternal_003Eg__OnPlatformName_007C8(string platformName)
			{
			}

			internal void _003COnShowInternal_003Eb__9(string imageError)
			{
			}

			internal void _003COnShowInternal_003Eb__10(string nameError)
			{
			}
		}

		public static readonly global::HHOBPMOCKMJ<int> OnFriendsImported;

		private List<int> PNHILOECLKG;

		private LoadingDialogModel IJMIJLCIGJD;

		private Dictionary<int, JJGPKBPPDHH> GKKMGENNPNI;

		private Dictionary<int, Texture> FMBNMLEBOOD;

		private Dictionary<int, string> IBBCMIEGELO;

		public LocalizedString ADD_ALL_FRIENDS;

		public LocalizedString ADD_N_FRIENDS;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public bool IsEmpty
{
get 		{
			return false;
		}

}

public IReadOnlyList<int> PlatformFriendRrAccountIds
{
get 		{
			return null;
		}

}

public int NumberOfSelectedAccounts
{
get 		{
			return 0;
		}

}

		protected override void IILPBDLFFKG()
		{
		}

		protected override void BJPPPBGBLAO()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		private void GBEILGJPHID()
		{
		}

		public void AddSelectedFriends()
		{
		}

		public void ToggleIsAccountSelectedForImport(int EJIHLJJMOBD)
		{
		}

		public bool IsAccountSelectedForImport(int EJIHLJJMOBD)
		{
			return false;
		}

		public Texture GetPlatformImageByAccountId(int EJIHLJJMOBD)
		{
			return null;
		}

		public string GetPlatformNameByAccountId(int EJIHLJJMOBD)
		{
			return null;
		}

		public string GetPlatformIdByAccountId(int EJIHLJJMOBD)
		{
			return null;
		}

		[CompilerGenerated]
		private void PGPBHHODIDN(LoadingDialogModel GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void ENMJJIJNIFM(List<JJGPKBPPDHH> MKACDMNEGNA)
		{
		}

		[CompilerGenerated]
		private void GCGDGIOAPCC(string GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		private void FAONDDANBMK()
		{
		}
	}
}
