using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using RecRoom.Core.Studio;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

[Preserve]
internal class NKNNEMACACE : BEMCDCJBEIK
{
	[StructLayout((LayoutKind)3)]
	private struct JGGINDANFJD : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public JEHGHDDHEEO bundleContent;

		public NKNNEMACACE _003C_003E4__this;

		public CancellationToken cancellationToken;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter<IReadOnlyList<GameObject>> _003C_003Eu__2;

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
	private struct APBKAJJIEOM : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public NKNNEMACACE _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<IReadOnlyList<GameObject>> _003C_003Eu__2;

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
	private struct IFEHPKJKBOF : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public CancellationToken cancellationToken;

		public NKNNEMACACE _003C_003E4__this;

		public JEHGHDDHEEO bundleContent;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<AssetBundle> _003C_003Eu__2;

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

	private sealed class PLCOOFAEBPL
	{
		public NKNNEMACACE _003C_003E4__this;

		public List<GameObject> rootObjects;

		public List<GameObject> allRootObjects;

		public Action<Scene> _003C_003E9__2;

		internal void _003CLoadAssetBundleScenes_003Eg__GatherRootObjects_007C0(Scene scene)
		{
		}

		internal void _003CLoadAssetBundleScenes_003Eb__2(Scene scene)
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct MDHMLKHPIFN : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<IReadOnlyList<GameObject>> _003C_003Et__builder;

		public NKNNEMACACE _003C_003E4__this;

		public CancellationToken cancellationToken;

		private PLCOOFAEBPL _003C_003E8__1;

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

	private sealed class HGDKFDCDGPO
	{
		public TaskCompletionSource<object> tcs;

		internal void _003CUnloadSceneAsync_003Eb__0(AsyncOperation _)
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct ODCGLJNGOLG : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public NKNNEMACACE _003C_003E4__this;

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
	private struct NBCDGBOAIFP : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public NKNNEMACACE _003C_003E4__this;

		private List<Scene>.Enumerator _003C_003E7__wrap1;

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

	private sealed class GPBDHMOHHEH
	{
		public int i;
	}

	private sealed class LIGKBPHCIIL
	{
		public MaterialMap.MaterialEntry entry;

		public GPBDHMOHHEH CS_0024_003C_003E8__locals1;

		internal object _003CApplyAssetBundleMaterialSettings_003Eb__0()
		{
			return null;
		}
	}

	private Scene HPMCNFCDAFC;

	private bool AEIIMDMNEOD;

	private JEHGHDDHEEO AFHCPOAKDCJ;

	private AssetBundle EKKGGCBOCPE;

	private readonly List<Scene> ICHBMMJKOMF;

	private readonly List<GameObject> BFHJEOAGEAO;

	private readonly HashSet<GameObject> EGIAGHPHLFP;

public bool IDELKOKENFJ
{
get 	{
		return false;
	}

}

public string KICEADEDNGD
{
get 	{
		return null;
	}

}

	private static void CPPCJDFOIOD(MNALHHOLFGL FMPHDMAKDKP)
	{
	}

	public void NMEKALIHHMI(Scene BJIMBCEIGGJ)
	{
	}

	public Task PLDIPGFHBAM(JEHGHDDHEEO MBEEEMIEAAD, CancellationToken NDKAKDJMDIF)
	{
		return null;
	}

	public Task ALNCBMAEPIO()
	{
		return null;
	}

	private void AIKEGDPBKKF()
	{
	}

	private void GJOHNBFLFFK()
	{
	}

	private Task<bool> ODDPDNODHPF(JEHGHDDHEEO MBEEEMIEAAD, CancellationToken NDKAKDJMDIF)
	{
		return null;
	}

	private Task<IReadOnlyList<GameObject>> KPBOOPAJNFM(CancellationToken NDKAKDJMDIF)
	{
		return null;
	}

	private Task EBBJMMJKHFE(Scene FEGPGPHCDJD)
	{
		return null;
	}

	private Task NBGJHGPKJGD()
	{
		return null;
	}

	private Task HIOLABPNLAB()
	{
		return null;
	}

	private void GCBGPHPLNJO(Scene BJIMBCEIGGJ)
	{
	}

	private void DEDAJKFEPAF(Scene BJIMBCEIGGJ)
	{
	}

	private void LPECAMEKPFL()
	{
	}

	private void BKNHECGDNIE()
	{
	}

	private void HIPLFJMNOHL(IReadOnlyList<GameObject> PDCFANDKENI)
	{
	}

	private void JHNPFJEPCGK(GameObject MMOJPADIJLF)
	{
	}

	private void BKBCAKBMPIB()
	{
	}

	private void OOKJADFMEGC()
	{
	}

	private void AECPDLNJADD(AudioMixer LLGIDJGIKNB, string PHMGIFEMLAK, HHOIEGJNNEC LAEAGAJDAFO)
	{
	}

	private void ENBHNCLGLFI(GameObject MMOJPADIJLF)
	{
	}

	private void KJPKKAAGGFF()
	{
	}

	private void NJAEEHLOLHO(IReadOnlyList<GameObject> PDCFANDKENI)
	{
	}
}
