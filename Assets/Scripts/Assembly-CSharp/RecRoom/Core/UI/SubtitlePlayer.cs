using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

namespace RecRoom.Core.UI
{
	public class SubtitlePlayer : MonoBehaviour
	{
		private enum AHAGIIKICKB
		{
			SequenceNumber = 0,
			Time = 1,
			Text = 2
		}

		public class GDHDOPFCHHL
		{
			private int MACBNEBLEEA;

			private float NPNJOOLHELA;

			private float GFIMNPJHLJA;

			private string NFHEOKNPMIN;

public int NDNPPHIMGEO
{
get 			{
				return 0;
			}

private set {
			}
}

public float OHLMLNDNBAM
{
get 			{
				return 0f;
			}

private set {
			}
}

public float LLOPCFGMPDP
{
get 			{
				return 0f;
			}

private set {
			}
}

public string KKHKFIGPMMA
{
get 			{
				return null;
			}

private set {
			}
}

			public GDHDOPFCHHL(int KBECGKMBECC, float OBBCLKLAKLD, float DNDKNHBBLEK, string HLIGBKANEEA)
			{
			}
		}

		private sealed class AFBALEICKIF : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public SubtitlePlayer _003C_003E4__this;

			private List<GDHDOPFCHHL>.Enumerator _003C_003E7__wrap1;

			private GDHDOPFCHHL _003CsubtitleFrame_003E5__3;

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
			public AFBALEICKIF(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
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

		[StructLayout((LayoutKind)3)]
		private struct AJLPHMBBCBE
		{
			public LogType logType;
		}

		private sealed class MFGPMPKPBHG : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SubtitlePlayer _003C_003E4__this;

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
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public MFGPMPKPBHG(int _003C_003E1__state)
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

		private List<GDHDOPFCHHL> LFFOFOOIPHK;

		private LKGILLBEJEK OEFMLKOLJCL;

		private string MGECCPIIAIE;

		private float AHCHPFFOLOC;

		public LocalizedStringTable localizationTable;

		private StringTable AHGBFOMLFFF;

private float LDNHHNLMICI
{
get 		{
			return 0f;
		}

}

		public void Load(string MPANGDADLKN, string NPKOMACBEIC = null)
		{
		}

		public void Play()
		{
		}

		public void Stop()
		{
		}

		private IEnumerator<EGGPGCCKPCO> HEGKMOPCGBF()
		{
			return null;
		}

		public static List<GDHDOPFCHHL> ParseSrtText(string MPANGDADLKN, bool NNGMNIDIKOJ = false)
		{
			return null;
		}

		private void DHLOEEIBGHL(string MPANGDADLKN)
		{
		}

		private IEnumerator Start()
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		private void LANNFFDGHAI(StringTable GBDIHOGAGFP)
		{
		}

		private string GOCCMBGCHCL(GDHDOPFCHHL CDPFBDBELHI)
		{
			return null;
		}

		[CompilerGenerated]
		private static void CGGGJKPFAIP(string MANKFIKGIGJ, ref AJLPHMBBCBE P_1)
		{
		}
	}
}
