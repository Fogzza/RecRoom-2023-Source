using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom
{
	public class RecentImageProjector : MonoBehaviourPun
	{
		private sealed class EKLIEKNHLGH : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RecentImageProjector _003C_003E4__this;

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
			public EKLIEKNHLGH(int _003C_003E1__state)
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

		private sealed class EANPCGHLJGJ
		{
			public RecentImageProjector _003C_003E4__this;

			public DateTime? previousValidTill;

			internal void _003CUpdateImageListIfOutOfDate_003Eb__0(GDHOAGNFOBD.GAPIMFCDGMM slideshowInfo)
			{
			}
		}

		private sealed class EECFLPFBKAC : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float seconds;

			public RecentImageProjector _003C_003E4__this;

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
			public EECFLPFBKAC(int _003C_003E1__state)
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

		private sealed class OPMGEKGHAEC
		{
			public RecentImageProjector _003C_003E4__this;

			public string currImageName;

			internal void _003COnCurrentImageChanged_003Eb__0(Texture2D texture)
			{
			}

			internal void _003COnCurrentImageChanged_003Eb__1(string errorMsg)
			{
			}

			internal void _003COnCurrentImageChanged_003Eb__2(Texture2D texture)
			{
			}
		}

		private sealed class PFOHNOIBPJB : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public RecentImageProjector _003C_003E4__this;

			private float _003CanimDuration_003E5__2;

			private float _003CanimTime_003E5__3;

			private float _003CscaleAnimDurationPct_003E5__4;

			private float _003CfadeAnimDurationPct_003E5__5;

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
			public PFOHNOIBPJB(int _003C_003E1__state)
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

		[SerializeField]
		private MeshRenderer projecterRenderer;

		[SerializeField]
		private GameObject projectorDisplay;

		[SerializeField]
		private float photoDisplayTime;

		[SerializeField]
		private TextMeshPro usernameText;

		[SerializeField]
		private TextMeshPro roomNameText;

		[SerializeField]
		private BoxCollider viewingArea;

		[SerializeField]
		private Texture2D[] offlineImages;

		[SerializeField]
		private GameObject cheerFeedback;

		[SerializeField]
		private Image cheerFeedbackImage;

		[SerializeField]
		private float cheerFeedbackMinScale;

		[SerializeField]
		private float cheerFeedbackMaxScale;

		[SerializeField]
		private PhysicalButtonBase[] cheerButtons;

		[SerializeField]
		private PhysicalButtonBase[] visitButtons;

		[SerializeField]
		private Image[] cheerCounterImages;

		[SerializeField]
		private string amplitudeCommandContext;

		private const uint PBDHNJMONBG = 512u;

		private Material BDIPECHNHPO;

		private global::MOBDJNEDDKC<int> AGDMJAAIEMA;

		private global::MOBDJNEDDKC<string> NEHFFCHPKKG;

		private global::MOBDJNEDDKC<string> MGJEGNFOPLL;

		private global::MOBDJNEDDKC<long> JEGJHPAEMHI;

		private global::MOBDJNEDDKC<string> NPMCKNIEAFL;

		private global::MOBDJNEDDKC<string> POFNGLAENFL;

		private global::MOBDJNEDDKC<long> LDEHHACLMEF;

		private global::MOBDJNEDDKC<int> OABHIGEFPAD;

		private List<GDHOAGNFOBD.OOMPBFCDNGG> HELFDDGIAMB;

		private DateTime? ACODKJLBHDF;

		private DateTime? BMDEKBIIAOE;

		private float OHFGFEHGJGF;

		private Coroutine CECEFJGJHBN;

		private Coroutine MPDJOOKKOMO;

		private GDHOAGNFOBD.KEIAPDLHGPG HALAJOLIHAF;

		private GDHOAGNFOBD.KEIAPDLHGPG IKPINCKEHGM;

		private int MGAIJMMIOCI;

		private const int OJOGEKHKCON = 4;

		private bool BNIBGMIBJFJ;

		private LKGILLBEJEK IDPNKMABFOF;

private int AKNOGLKFAKD
{
get 		{
			return 0;
		}

set {
		}
}

private string AIMOLGHEDCB
{
get 		{
			return null;
		}

set {
		}
}

private long IBBLGEJLGOE
{
get 		{
			return 0L;
		}

set {
		}
}

private string EFEICOGJOBC
{
get 		{
			return null;
		}

set {
		}
}

private string CDFHEMKIJPI
{
get 		{
			return null;
		}

set {
		}
}

private string EOJJLNOFJJF
{
get 		{
			return null;
		}

set {
		}
}

private long EEPEJDNJKPP
{
get 		{
			return 0L;
		}

set {
		}
}

private int AALEBNDNGDH
{
get 		{
			return 0;
		}

set {
		}
}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private IEnumerator JMKCIJFAFON()
		{
			return null;
		}

		private void HCBCGJKKFHN()
		{
		}

		private IEnumerator JIKIBFHGPMG(float BGGBEMDBOHE)
		{
			return null;
		}

		private void MFBGJHABDFP()
		{
		}

		private void FCCGKNANNIP()
		{
		}

		private bool HPJFBNLCBJF()
		{
			return false;
		}

		private Texture2D CBEDALMNFOB()
		{
			return null;
		}

		private void EIKIDCIKJHJ()
		{
		}

		private void BHFNHKPFHGM()
		{
		}

		private void HMBAKNJKIBH()
		{
		}

		private void KFEEACIPEMD(Texture2D IECDHEIBMJN)
		{
		}

		private void NCHBAMBCHGN()
		{
		}

		private void OnMasterClientSwitched(CHILKDJABBF GKNDJIKLPKK)
		{
		}

		private void NHIEDGCBNIC()
		{
		}

		private IEnumerator<EGGPGCCKPCO> JEFPKFBLBCO()
		{
			return null;
		}

		private void MBECKBGKMBN(bool BFDBCMGIOBG)
		{
		}

		private void NJLEIMHKMMF(bool BFDBCMGIOBG)
		{
		}

		private void DNNHJPFILOA(long IPLCNNFIFHC)
		{
		}

		[PBOMGCLBFHF]
		private void RPCMasterCheerImage(long IPLCNNFIFHC)
		{
		}

		public void Button_VisitRoom()
		{
		}

		public void Button_CheerPhoto()
		{
		}

		private void MFJJJLIOKEH()
		{
		}

		private void AHLEIDEKENL(string OFCFPGACNJB)
		{
		}

		[CompilerGenerated]
		private void COEMMLMGHFE()
		{
		}

		[CompilerGenerated]
		private void KJDDCIIDOPJ(string OFCFPGACNJB)
		{
		}
	}
}
