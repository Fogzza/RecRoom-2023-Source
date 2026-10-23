using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Photon.Voice.Unity;
using UnityEngine;

namespace ToxMod
{
	[DisallowMultipleComponent]
	public class ToxModVoiceComponent : VoiceComponent
	{
		private class MJLOAHKHFLD : global::BAINAIKPPHP<float>, IDisposable
		{
			private BCJKOFPMPDF AIBCLONGLEL;

			private int KMPMHHFCLHB;

			private int INHAHPNHLFC;

			public MJLOAHKHFLD(BCJKOFPMPDF AIBCLONGLEL, LOJCFCMAILG DLEEAJBNGFD)
			{
			}

			public float[] ICMBBDEOBAC(float[] AJCJOJDAPDK)
			{
				return null;
			}

			public void Dispose()
			{
			}
		}

		private class CPOBFBBCMDF : global::BAINAIKPPHP<short>, IDisposable
		{
			private BCJKOFPMPDF AIBCLONGLEL;

			private int KMPMHHFCLHB;

			private int INHAHPNHLFC;

			public CPOBFBBCMDF(BCJKOFPMPDF AIBCLONGLEL, LOJCFCMAILG DLEEAJBNGFD)
			{
			}

			public short[] ICMBBDEOBAC(short[] AJCJOJDAPDK)
			{
				return null;
			}

			public void Dispose()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct HJIDGHEDHEP : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public ToxModVoiceComponent _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct PLCMHJFOBLF : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public ToxModVoiceComponent _003C_003E4__this;

			public BJMNEPGAFDB photonVoiceCreatedParams;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[SerializeField]
		private KHOPPDEAIPI.NHCCJFDDDEO triageLevel;

		private bool BMKEKKACCNJ;

		[SerializeField]
		private Player player;

		private int AKPLFIBLHPE;

		private static JNKNMMDAHCF DHCLACKALOF;

		private const string MJMGBDCAHGL = "Tox Error setting Session Name";

		private Task<bool> CCIGKNCDGJL()
		{
			return null;
		}

		public static bool CanInitializeToxMod()
		{
			return false;
		}

		private void PhotonVoiceCreated(BJMNEPGAFDB BMAGHBDNEOJ)
		{
		}

		private void FBKKAMGDPGD()
		{
		}
	}
}
