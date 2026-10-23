using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;

namespace RecRoom
{
	public class MClusterManagerBehaviour : SingletonMonoBehaviour<MClusterManagerBehaviour>
	{
		[StructLayout((LayoutKind)3)]
		private struct NFCBKGAFMEH : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public MClusterManagerBehaviour _003C_003E4__this;

			public CancellationToken externalToken;

			public global::FKCKMADGELN<string>.PPKAMDIDPFK stackTimer;

			private CancellationTokenSource _003C_003E7__wrap1;

			private global::FKCKMADGELN<string>.PPKAMDIDPFK _003C_003E7__wrap2;

			private global::FKCKMADGELN<string>.PPKAMDIDPFK _003CwaitForShapesTimer_003E5__4;

			private TaskAwaiter _003C_003Eu__1;

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
		private struct IOOFKPODKDN : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			private TaskAwaiter _003C_003Eu__1;

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

		private readonly BJFFMFCOKNA INEBFFIBHDO;

		private IDisposable PLBEAMIACLE;

		private INBDIKIJLGF GBIFNANKKKC;

		private bool MGGLPJGBKFH;

		private bool GJKELLFJAHL;

		private bool FGOOENHNDNG;

		private CancellationToken NDKAKDJMDIF;

		private CancellationTokenSource HMHGCNBJGDN;

		private GameObject GMGPGLAHHOG;

		private MeshRenderer EHLPBGGNFOL;

		private Camera NMEBHKCNOLK;

		private Material KDCAMIIINJF;

		public void UpdateBindTarget()
		{
		}

		private void CBIDBNNNJOP()
		{
		}

		public void Start()
		{
		}

		private void Update()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void MJNKIGLGIIC(ScriptableRenderContext DELCOFCGDFF, Camera[] IHFAPCEAHEL)
		{
		}

		private void KPBNOMFGFBE(ScriptableRenderContext DELCOFCGDFF, Camera[] IHFAPCEAHEL)
		{
		}

		private void GBAHFFOCFGB()
		{
		}

		private ILODPOPFPAH FFBDGACNKHN()
		{
			return null;
		}

		public Task RoomLoad(global::FKCKMADGELN<string>.PPKAMDIDPFK GLOICACPAOF, CancellationToken MFMBGLNBFDO)
		{
			return null;
		}

		public static void SafeDestroy(UnityEngine.Object ICHBECDKHOJ)
		{
		}

		[CompilerGenerated]
		internal static Task LMFEPDJJPLP(AHDBIFJNDCH PCPEJHIMHJJ, CancellationToken IALNODEHBNN)
		{
			return null;
		}
	}
}
