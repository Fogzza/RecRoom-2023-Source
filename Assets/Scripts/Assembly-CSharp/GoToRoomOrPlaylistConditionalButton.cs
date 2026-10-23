using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using UnityEngine;

public class GoToRoomOrPlaylistConditionalButton : ConditionalButton<Button3D>
{
	public enum GGCBDLEMJOH
	{
		PublicInstance = 0,
		PrivateInstance = 1,
		AlwaysAsk = 2,
		PublicInstanceChooseEntrySubroom = 3
	}

	public enum NCALKDNGCAK
	{
		Disabled = 0,
		Room_DNE = 1,
		Join = 2,
		Full = 3
	}

	private sealed class JOMAGABJCFF
	{
		public GGCBDLEMJOH goToBehavior;

		public DBECJLAIPEL loadSceneSource;

		public Action done;

		public Action<HGKINAOMNIF> _003C_003E9__2;

		internal void _003CTryJoinRoom_003Eb__0(LCEKCFEIEGJ roomDetails)
		{
		}

		internal void _003CTryJoinRoom_003Eb__2(HGKINAOMNIF response)
		{
		}
	}

	private sealed class DOJOOEDANEL : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GoToRoomOrPlaylistConditionalButton _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public DOJOOEDANEL(int _003C_003E1__state)
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
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private GGCBDLEMJOH goToBehavior;

	[SerializeField]
	private GameObject notYetSupportedBanner;

	private LFGKKGANEIP FKBKDFKJJBI;

	private NCALKDNGCAK? KMKJIBBJBIA;

	public EEANDDJEMJC OnButtonAction;

	private OAHIIBBLMCD IJFBCMBOGLN;

	public DBECJLAIPEL LoadSceneSource;

	private Coroutine DMDJPOHPHAI;

public NCALKDNGCAK? ForcedButtonState
{
get 	{
		return null;
	}

set {
	}
}

public OAHIIBBLMCD TargetRoomOrPlaylist
{
get 	{
		return null;
	}

}

public bool AttractHighlighted
{
get 	{
		return false;
	}

set {
	}
}

	public void SetTarget(OAHIIBBLMCD FLJPFOJGNLA)
	{
	}

	protected override void OEGMENAEEAE()
	{
	}

	private void MHEHEKNMIII()
	{
	}

	protected override void IJBABHBJKGK()
	{
	}

	protected override bool FNINFCOHBOK()
	{
		return false;
	}

	protected override void GFCICHDHHJG()
	{
	}

	private void GCDEFPEEAKN()
	{
	}

	private void EDBHCKCKCIK(JCDPHCELKHI KPFNANKNKLE)
	{
	}

	public static void TryJoinRoom(JCDPHCELKHI KPFNANKNKLE, GGCBDLEMJOH DMNKEAGHENC, DBECJLAIPEL CFBNOKOADFB, Action AEFLANGPLDH = null)
	{
	}

	private IEnumerator GBBOJDOEAKM()
	{
		return null;
	}

	private string LKMKOMAGEHH(OAHIIBBLMCD EJMOCIAPCPJ)
	{
		return null;
	}

	[CompilerGenerated]
	private void PADFGBOBMJP(int? CDBKKOIFCBB)
	{
	}

	[CompilerGenerated]
	private void MFJOONMOKJL()
	{
	}

	[CompilerGenerated]
	private void GIGDDABALGK(HGKINAOMNIF GOJCEBCMFJK)
	{
	}
}
