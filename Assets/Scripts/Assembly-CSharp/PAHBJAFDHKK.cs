using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Systems.PlayerRoles;

public static class PAHBJAFDHKK
{
	private sealed class APICDOEPICC : IEnumerable<GameRole>, IEnumerable, IEnumerator<GameRole>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private GameRole _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private KLNOBKBCIEK gameRoleIdFlags;

		public KLNOBKBCIEK _003C_003E3__gameRoleIdFlags;

		private PlayerGameRoleManager _003Cmanager_003E5__2;

		private IReadOnlyList<KLNOBKBCIEK> _003CallGameRoleIds_003E5__3;

		private int _003Ci_003E5__4;

		private int _003Cn_003E5__5;

		GameRole IEnumerator<GameRole>.Current
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
		public APICDOEPICC(int _003C_003E1__state)
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

		[DebuggerHidden]
		IEnumerator<GameRole> IEnumerable<GameRole>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	private sealed class FHKNLNMBMFA : IEnumerable<Guid>, IEnumerable, IEnumerator<Guid>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Guid _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private KLNOBKBCIEK gameRoleIdFlags;

		public KLNOBKBCIEK _003C_003E3__gameRoleIdFlags;

		private PlayerGameRoleManager _003Cmanager_003E5__2;

		private IReadOnlyList<KLNOBKBCIEK> _003CallGameRoleIds_003E5__3;

		private int _003Ci_003E5__4;

		private int _003Cn_003E5__5;

		Guid IEnumerator<Guid>.Current
		{
			[DebuggerHidden]
			get
			{
				return default;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public FHKNLNMBMFA(int _003C_003E1__state)
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

		[DebuggerHidden]
		IEnumerator<Guid> IEnumerable<Guid>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	private sealed class HAHAKCEPGOE
	{
		public Func<KLNOBKBCIEK> getGameRole;

		public Action<KLNOBKBCIEK> setGameRole;

		internal IEnumerable<GameRole> _003CGetMakerPenInteractionFilterDynamicUI_003Eb__2()
		{
			return null;
		}

		internal void _003CGetMakerPenInteractionFilterDynamicUI_003Eb__3(IEnumerable<GameRole> value)
		{
		}
	}

	public static bool FAFDOAEDKGE(KLNOBKBCIEK AKGJELEIMAD, CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	public static IEnumerable<GameRole> DGCKNDBONBP(KLNOBKBCIEK AKGJELEIMAD)
	{
		return null;
	}

	public static IEnumerable<Guid> IFPEKNLDIEL(KLNOBKBCIEK AKGJELEIMAD)
	{
		return null;
	}

	public static KLNOBKBCIEK BJMJMNIJLLD(KLNOBKBCIEK AKGJELEIMAD)
	{
		return KLNOBKBCIEK.AG_EVERYONE;
	}

	public static KLNOBKBCIEK GGJNLLKCGPL(IEnumerable<Guid> PDIFJLOMIBN)
	{
		return KLNOBKBCIEK.AG_EVERYONE;
	}

	public static KLNOBKBCIEK IALEAPELHCE(IEnumerable<Guid> PDIFJLOMIBN, out List<Guid> BJFNOBIAEPO)
	{
		BJFNOBIAEPO = null;
		return KLNOBKBCIEK.AG_EVERYONE;
	}

	public static KLNOBKBCIEK GGJNLLKCGPL(IEnumerable<GameRole> EAAPMGPCLNO)
	{
		return KLNOBKBCIEK.AG_EVERYONE;
	}

	public static DGMPBIPKJEB IPINOJGEHBP(Action<CLKEJFGKNDK, KCOKPCOFDIM> GFNPBKFLPEB, Func<KLNOBKBCIEK> FJCBDNLIMNI, Action<KLNOBKBCIEK> MCGFLBCPMEI)
	{
		return null;
	}
}
