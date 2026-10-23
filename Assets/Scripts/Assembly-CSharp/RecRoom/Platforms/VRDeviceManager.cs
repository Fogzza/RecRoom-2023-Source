using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RecRoom.Localization;
using UnityEngine;
using UnityEngine.XR.Management;

namespace RecRoom.Platforms
{
	public abstract class VRDeviceManager : SingletonMonoBehaviour<VRDeviceManager>
	{
		public enum MJLGKDDJCLF
		{
			None = 0,
			Screens = 1,
			VR = 2
		}

		[StructLayout((LayoutKind)3)]
		private struct KIHIKKEFCIB
		{
			public List<XRLoader> activeLoaders;
		}

		private sealed class DEIAMBDAEIE : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public VRDeviceManager _003C_003E4__this;

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
			public DEIAMBDAEIE(int _003C_003E1__state)
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
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class GBJNJACAPBL : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public VRDeviceManager _003C_003E4__this;

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
			public GBJNJACAPBL(int _003C_003E1__state)
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
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class PMCHPAAAGHM : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public VRDeviceManager _003C_003E4__this;

			public bool setupAgain;

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
			public PMCHPAAAGHM(int _003C_003E1__state)
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
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class MLKADMCAABH : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public VRDeviceManager _003C_003E4__this;

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
			public MLKADMCAABH(int _003C_003E1__state)
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
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private const string PHBIMAPIAFG = "+forcemode:";

		private const string HJNDLCGJNBH = "+mode:";

		private const string PBCMBCFPAIE = "screen";

		private const string NKBMBKHMOFF = "vr";

		private static bool OGJIEIOJJOH;

		protected const string DONJBAMLGJK = "None";

		private LKGILLBEJEK KPILOCDJDEO;

		private Action KMEBIFMFCGE;

		private bool MJNMBIEENEF;

		public Texture ProgressBarTextureFull;

		public Texture ProgressBarTextureEmpty;

		protected string BACHEJNPPIH;

		protected float GANNFLJMAFN;

		protected RenderTexture KAACGMLIKHK;

		private const string DCKMILMMEPG = "SKIPS_USER_PRESENCE_CHECK";

		private bool? ANHHCIPBIEP;

		private bool DKJMDPBAFIH;

		private bool COPNPCKCAFA;

		private BHNJIBDJFAL NJPJBDDAEFH;

		protected bool ACKIBBCPLKM;

		public FallbackTableReference loadingScreenTable;

private bool CJCFBFMHHFH
{
get 		{
			return false;
		}

}

public static string ActiveDeviceModelName
{
get 		{
			return null;
		}

}

protected abstract IEnumerable<string> IKHFHMMJAHO
{
get ;
}

protected abstract string GLDPEGBBFLC
{
get ;
}

protected abstract bool MFPPFGPJBDH
{
get ;
}

public virtual bool HMDExists
{
get 		{
			return false;
		}

}

protected abstract bool FNDJHHHEENO
{
get ;
}

public virtual bool UserInHMD
{
get 		{
			return false;
		}

}

protected abstract bool IJJCNFLENBL
{
get ;
}

protected bool FPBKIIPDGKN
{
get 		{
			return false;
		}

}

protected bool KIFDNANABAJ
{
get 		{
			return false;
		}

}

protected bool HECMEIMEPPN
{
get 		{
			return false;
		}

}

private bool GLEPBGMFEJN
{
get 		{
			return false;
		}

}

private bool OMJIIFCMOHG
{
get 		{
			return false;
		}

}

private bool MFDEDJGPCHP
{
get 		{
			return false;
		}

set {
		}
}

public bool VRActive
{
get 		{
			return false;
		}

private set {
		}
}

		[RuntimeInitializeOnLoadMethod]
		private static void UpdateXRLoaders()
		{
		}

		protected override void Awake()
		{
		}

		public static MJLGKDDJCLF GetCommandLineMode()
		{
			return MJLGKDDJCLF.None;
		}

		protected virtual void Start()
		{
		}

		protected virtual IEnumerator<EGGPGCCKPCO> AJKPHDKEEAN()
		{
			return null;
		}

		private void OAANNDLHBEO()
		{
		}

		private void NGPMPJJAMKC()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected void HKMPHKBLPFI()
		{
		}

		protected void NAGLCOFPPKB()
		{
		}

		private static bool GCCGGGOGEFF()
		{
			return false;
		}

		private void GMMFAJGPPBE()
		{
		}

		private IEnumerator<EGGPGCCKPCO> JFCANJDNHIP()
		{
			return null;
		}

		protected void FIIAHGOBKGD()
		{
		}

		protected void GANAJEKPNGH()
		{
		}

		private IEnumerator<EGGPGCCKPCO> BJBGJHPHIGE(bool JFJJCFEINHK)
		{
			return null;
		}

		public void SuspendCompositorRender(bool GLCOFONMDAO)
		{
		}

		protected virtual void EIFAMCBHHAP()
		{
		}

		protected virtual void FNBJJJNKNHM()
		{
		}

		protected abstract IEnumerator<EGGPGCCKPCO> NIHHKDMBJFM();

		protected abstract void ELKBNLIOBOM(bool EGJEBAFNALL);

		protected abstract void OHKBILOMAHP();

		private void IOIDLBEMCDK(IEnumerator<EGGPGCCKPCO> DHPEHMGKDMB)
		{
		}

		private void OnApplicationQuit()
		{
		}

		private void LNANHOAJOBI()
		{
		}

		public virtual void SetLoadingScreenProgress(float DDKCONDPEJF)
		{
		}

		public virtual void SetLoadingScreenLabel(string IEACNHGAIIE)
		{
		}

		protected void CPGCLCLNNEF()
		{
		}

		[CompilerGenerated]
		private static void JIAABBIOKJM(List<XRLoader> HHBCBDDGAJA, string NENINLIEGOC, ref KIHIKKEFCIB P_2)
		{
		}

		[CompilerGenerated]
		internal static MJLGKDDJCLF AJANHLNPEJA(string BCMJPJPBGOG)
		{
			return MJLGKDDJCLF.None;
		}

		[CompilerGenerated]
		private IEnumerator<EGGPGCCKPCO> ACEBFGGNOON()
		{
			return null;
		}

		[CompilerGenerated]
		private bool KDJHLPFCMBK()
		{
			return false;
		}

		[CompilerGenerated]
		private void BBFGIBEANLI()
		{
		}

		[CompilerGenerated]
		private void OCPGIJALOIO()
		{
		}
	}
}
