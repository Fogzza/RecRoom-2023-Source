using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Inputs
{
	[Serializable]
	public class PS4MoveVRInputHandler : VRInputHandler
	{
		[Serializable]
		public class Map
		{
			public IILNGCKFGBN DedicatedMenuButton;

			public IILNGCKFGBN SecondaryButton;

			public IILNGCKFGBN SlideButton;

			public IILNGCKFGBN SelfScalingButton;

			public IILNGCKFGBN SprintButton;

			public IILNGCKFGBN PrimaryButton;

			public IILNGCKFGBN PushToTalkButton;

			public IILNGCKFGBN RotateLeftButton;

			public IILNGCKFGBN RotateRightButton;

			public IILNGCKFGBN[] RCMainButtons;

			public DeprecatedAxisSettings TriggerSettings;
		}

		public enum MGLLNOFJGII
		{
			None = 0,
			PrimaryButton = 1,
			SecondaryButton = 2,
			MenuButton = 3
		}

		private sealed class GGIGFMPHOCG : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PS4MoveVRInputHandler _003C_003E4__this;

			public float intensity;

			public int milliseconds;

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
			public GGIGFMPHOCG(int _003C_003E1__state)
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
		private Map map;

		private PS4MoveInput ps4MoveInput;

		private FPNJBMCMCIG discreteAxis;

		private readonly Dictionary<JCFFMMKDGOA, (MGLLNOFJGII, MHIBEFMDHNN)> ControlToPSVRInputMap;

		private readonly global::FDAEEPIALBA<JCFFMMKDGOA, MGLLNOFJGII> inputConsumerMap;

		public override bool RotateStrafeAndSelfScaleOverlap => false;

		public override bool HasDedicatedMenuButton => false;

		public override bool MJKJHKJGCJM(JCFFMMKDGOA POINFDHCNCM)
		{
			return false;
		}

		private void GHANJDEJDOF()
		{
		}

		public override void PPOCOGLBGFD()
		{
		}

		public override void HFCGCFAAAJP()
		{
		}

		private void FLAIHAECBIG()
		{
		}

		protected override void OPMEDJKHIDF(ref HGLAMAFCPPN DADHJJNJEFA)
		{
		}

		protected override IEnumerator LJLEIHBODCE(int HIJKHPMDNMK, float DOEJGDJILAD, bool HIFDJFBEADN = false)
		{
			return null;
		}

		private DLLIMLHNBON HDPFFNBBDMN(IILNGCKFGBN FDAIMOMOHIG, KBJKDKFNFIA LIJGJGIGLOD, float DKBDBCGPCCH)
		{
			return default;
		}

		private DLLIMLHNBON NNHNHEKAKHI(IILNGCKFGBN FDAIMOMOHIG, out bool ICHOFOKGCEN, JCFFMMKDGOA POINFDHCNCM = JCFFMMKDGOA.None)
		{
			ICHOFOKGCEN = default;
			return default;
		}

		private DLLIMLHNBON NNHNHEKAKHI(IILNGCKFGBN[] LLNNCEMACKC)
		{
			return default;
		}

		private GAEDOFGKFJA BCLOEHFCHDC()
		{
			return default;
		}
	}
}
