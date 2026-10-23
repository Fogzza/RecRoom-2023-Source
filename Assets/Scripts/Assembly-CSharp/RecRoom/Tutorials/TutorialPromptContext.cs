using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RecRoom.Tutorials
{
	[Serializable]
	public class TutorialPromptContext
	{
		public enum AGKBKJJKKHH
		{
			WALK = 0,
			LOOK = 1,
			LOOK_AT = 2,
			JUMP = 3,
			WAVE = 4,
			DROP_ITEM = 5,
			TEST = 6,
			OPEN_WATCH_MENU = 7,
			DRIVE_STEERING_WHEEL_BUTTON_CONTROLS = 8,
			DRIVE_STEERING_WHEEL_MOTION_CONTROLS = 9,
			VIEW_PROFILE = 10,
			SWITCH_ROOMS = 11,
			INFO_TEXT = 12,
			LOOK_AT_MIRROR = 13,
			OPEN_MAKERPEN_MENU = 14,
			MAKERPEN_CREATE = 15
		}

		[Flags]
		public enum OGJHKPBPFAP
		{
			NONE = 0,
			RIGHT = 1,
			LEFT = 2,
			BOTH = RIGHT | LEFT
		}

		[Serializable]
		public class DropPromptContext
		{
			public enum LHPLDPHOHLP
			{
				HELD = 0,
				LOCKED = 1
			}

			[SerializeField]
			protected LHPLDPHOHLP screensHoldType;

			[SerializeField]
			protected LHPLDPHOHLP vrHoldType;

			public LHPLDPHOHLP HoldTypeToPrompt => LHPLDPHOHLP.HELD;
		}

		[Serializable]
		public class LookAtCompletionContext
		{
			[SerializeField]
			protected List<Tool> pickupList;

			public List<Tool> PickupList => null;
		}

		[Serializable]
		public class WaveCompletionContext
		{
			[SerializeField]
			protected OGJHKPBPFAP completionHand;

			public OGJHKPBPFAP CompletionHand => OGJHKPBPFAP.NONE;
		}

		[Serializable]
		public class TestPromptContext
		{
			[SerializeField]
			protected List<FMNJCGLEDJO> screenControlsToPrompt;

			[SerializeField]
			protected List<Sprite> vrSpritesToPrompt;

			public List<FMNJCGLEDJO> ScreenControlsToPrompt => null;

			public List<Sprite> VRSpritesToPrompt => null;
		}

		[Serializable]
		public class InfoTextContext
		{
			[SerializeField]
			private string text;

			public string Text => null;

			public void OPHOFEMOEEB(string MAFKLMLIAOD)
			{
			}
		}

		private sealed class KELKJAEODAD : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public TutorialPromptContext _003C_003E4__this;

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
			public KELKJAEODAD(int _003C_003E1__state)
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

		private sealed class KKCIEBCOBLG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public TutorialPromptContext _003C_003E4__this;

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
			public KKCIEBCOBLG(int _003C_003E1__state)
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

		private sealed class JOGEBHAGPJI
		{
			public AECAHLPIFOC inputHandler;

			public List<FMNJCGLEDJO> controlTypes;

			internal bool _003CInputDown_003Eb__0()
			{
				return false;
			}
		}

		public AGKBKJJKKHH promptType;

		[SerializeField]
		private InfoTextContext infoTextContext;

		[SerializeField]
		protected OGJHKPBPFAP promptHand;

		[SerializeField]
		protected DropPromptContext dropContext;

		[SerializeField]
		protected float gracePeriod;

		[SerializeField]
		protected float timeout;

		[SerializeField]
		private bool cancelOnTimeout;

		[SerializeField]
		protected float postActionDuration;

		[SerializeField]
		protected bool completeOnActionPerformance;

		[SerializeField]
		protected LookAtCompletionContext lookAtCompletionContext;

		[SerializeField]
		protected WaveCompletionContext waveCompletionContext;

		[SerializeField]
		protected bool debugLog;

		[SerializeField]
		[Space]
		protected TestPromptContext testPromptContext;

		public InfoTextContext InfoText => null;

		public float GracePeriod => 0f;

		public float Timeout => 0f;

		public float PostActionDuration => 0f;

		public bool CompleteOnActionPerformance => false;

		public bool DebugLog => false;

		public TestPromptContext TestContext => null;

		private bool EnableLookAtCompletionContext => false;

		private bool EnableWaveCompletionContext => false;

		private bool EnableInfoTextContext => false;

		public List<JKHCJAJHGAO> EBIDCPNNDMO()
		{
			return null;
		}

		private bool IIFFJNIJGAE()
		{
			return false;
		}

		public static bool IIFFJNIJGAE(AGKBKJJKKHH PDIGJADMKMI)
		{
			return false;
		}

		public OGJHKPBPFAP HKJNMNDAFEJ()
		{
			return OGJHKPBPFAP.NONE;
		}

		public OGJHKPBPFAP PJJIAPOKNBJ()
		{
			return OGJHKPBPFAP.NONE;
		}

		public List<FMNJCGLEDJO> MCHJIFAFFII(KLIMDPGKKGM GGNFFFABKNA)
		{
			return null;
		}

		private List<FMNJCGLEDJO> PMJCMIIDIHH(KLIMDPGKKGM GGNFFFABKNA)
		{
			return null;
		}

		private List<FMNJCGLEDJO> IGCBFBDAPNC()
		{
			return null;
		}

		public List<FMNJCGLEDJO> KOLKJJLFENN(KLIMDPGKKGM GGNFFFABKNA)
		{
			return null;
		}

		private List<FMNJCGLEDJO> GIGHMMLBDPJ(KLIMDPGKKGM GGNFFFABKNA)
		{
			return null;
		}

		private List<FMNJCGLEDJO> KHCGMLPAOJK()
		{
			return null;
		}

		private List<FMNJCGLEDJO> AOIHEBABMCE()
		{
			return null;
		}

		private List<FMNJCGLEDJO> IDDLOOFEJJI(KLIMDPGKKGM GGNFFFABKNA)
		{
			return null;
		}

		private JKHCJAJHGAO BGPGFEMLKHN(IEnumerator<EGGPGCCKPCO> PMFFOBGCJPE)
		{
			return null;
		}

		private JKHCJAJHGAO DBNLAECDBBI(IEnumerator<EGGPGCCKPCO> PMFFOBGCJPE)
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> OLDPKIPMHAB()
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> CAKEDEMFHGC()
		{
			return null;
		}

		private EGGPGCCKPCO JPIFMEDGDPP()
		{
			return null;
		}

		private EGGPGCCKPCO DMLCAEDEHLD()
		{
			return null;
		}

		private EGGPGCCKPCO KEBHANLDEAB()
		{
			return null;
		}

		private EGGPGCCKPCO KCKLDHABBEL()
		{
			return null;
		}

		private EGGPGCCKPCO PDCDPKCKENF()
		{
			return null;
		}

		private EGGPGCCKPCO JKLJOCDNBKJ()
		{
			return null;
		}

		private EGGPGCCKPCO KBDPONIBDMI()
		{
			return null;
		}

		private EGGPGCCKPCO LFKCDGKJMCC()
		{
			return null;
		}

		private static EGGPGCCKPCO NMBOIBMFDLK()
		{
			return null;
		}

		[CompilerGenerated]
		internal static bool FECIFCEODOG(PlayerHand PMNLJGLDMJN, DropPromptContext.LHPLDPHOHLP HHHOEGFPDAO)
		{
			return false;
		}

		[CompilerGenerated]
		private void ICDAOBCAPGM()
		{
		}

		[CompilerGenerated]
		private void PGCCLPNPKFF()
		{
		}

		[CompilerGenerated]
		private void PCDAOPPGJOP()
		{
		}

		[CompilerGenerated]
		private void ENDDODEAAMN()
		{
		}

		[CompilerGenerated]
		private bool MAGCDBPKLLK()
		{
			return false;
		}

		[CompilerGenerated]
		private bool FFGJMDDKPKA()
		{
			return false;
		}
	}
}
