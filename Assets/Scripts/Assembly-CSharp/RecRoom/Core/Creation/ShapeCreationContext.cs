using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RecRoom.Core.Creation.Shapes;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class ShapeCreationContext : ShapeCreationContextBase
	{
		private class OPOPCCFKDOK
		{
			public global::PHLHFLLLDLK<BJIJHMNPDCH> BOJDPAGLBLI;

			public float IINCEJGCDCH;
		}

		[StructLayout((LayoutKind)3)]
		private struct ILGFEDENIPH : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public ShapeCreationContext _003C_003E4__this;

			private HLNFDOBEGJO _003CroomManager_003E5__2;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

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

		private sealed class FCJPKBGDFJA
		{
			public BJIJHMNPDCH cachedSelectedContainer;

			public ShapeCreationContext _003C_003E4__this;

			public global::PHLHFLLLDLK<BJIJHMNPDCH> promise;

			internal void _003CTrySplitSelectedShapes_003Eb__0(Tool tool)
			{
			}

			internal void _003CTrySplitSelectedShapes_003Eb__1(string e)
			{
			}
		}

		[SerializeField]
		private CreationShapeContainer creationShapeContainer;

		private const float OCCFIDLPBJG = 2f;

		private OPOPCCFKDOK GLALIGMILCJ;

public override BKAOBFNMILE CreationShapeContainer
{
get 		{
			return null;
		}

}

		protected override void Start()
		{
		}

		private void LOMIJDBKDHG()
		{
		}

		protected override global::NCOKFFGPIJM<BJIJHMNPDCH> HEGKHDGNINK()
		{
			return null;
		}

		private global::NCOKFFGPIJM<BJIJHMNPDCH> GMCNFPHLAOH()
		{
			return null;
		}

		private void NBBEBAKLAOK(CHILKDJABBF OJMKLBPAANP)
		{
		}

		private IONEOHGOAML KMPIEBBNLIO(CHILKDJABBF OJMKLBPAANP, out ShapeContainer FJLOEANNMHK)
		{
			FJLOEANNMHK = null;
			return IONEOHGOAML.Success;
		}

		private void EKPJLCOKBJG(BJIJHMNPDCH MOFGFAAHLIF, IONEOHGOAML CDNLFEOBNKB)
		{
		}

		private void APDJIPNLIFB(BJIJHMNPDCH MOFGFAAHLIF)
		{
		}

		private void CHDHDODNIIO(BJIJHMNPDCH MOFGFAAHLIF)
		{
		}

		private void MOELLABOMJM()
		{
		}

		private void DLHLIEOAKOP(DHJLEHBOGBG ICHBECDKHOJ, bool FPMKKJKAHFN)
		{
		}

		public override global::NCOKFFGPIJM<BJIJHMNPDCH> TrySplitSelectedShapes()
		{
			return null;
		}

		[PBOMGCLBFHF]
		private void RpcMasterRequestNewShapeContainer(GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnNewShapeContainerRequestResult(ShapeContainer MOFGFAAHLIF, IONEOHGOAML CDNLFEOBNKB)
		{
		}

		public override DHJLEHBOGBG ToCreationContextObject(Guid ICHBECDKHOJ)
		{
			return null;
		}

		public override Guid FromCreationContextObject(DHJLEHBOGBG ICHBECDKHOJ)
		{
			return default;
		}

		[CompilerGenerated]
		private void KCNECCHOBDO(BJIJHMNPDCH FMPHDMAKDKP)
		{
		}

		[CompilerGenerated]
		private void LIKCKPEKIJG()
		{
		}
	}
}
