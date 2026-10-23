using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Players.Puppet;
using UnityEngine;

namespace RecRoom.Core.Creation.Holotars
{
	public class HolotarPoseRecorder : MonoBehaviour
	{
		private sealed class DPBGKGJLNNO : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public HolotarPoseRecorder _003C_003E4__this;

			private float _003CstartTime_003E5__2;

			private float _003CperSampleWait_003E5__3;

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
			public DPBGKGJLNNO(int _003C_003E1__state)
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
		private int framesPerSecond;

		[SerializeField]
		private Transform coordinateRootTransform;

		[SerializeField]
		private PlayerPuppet sourcePuppet;

		private FPDMEIABFON.BAGKGLJDBMA.DNKGILJELHJ CLOLACPGMFL;

		private Action<FPDMEIABFON.BAGKGLJDBMA.DNKGILJELHJ> ICDCPNAKEPK;

		private Coroutine LAPGJCOCJCM;

private bool JIDAKFLAKJB
{
get 		{
			return false;
		}

}

		public void StartRecording()
		{
		}

		public FPDMEIABFON.BAGKGLJDBMA.DNKGILJELHJ FinishRecording()
		{
			return null;
		}

		private IEnumerator NFMBOPMNKKL()
		{
			return null;
		}

		private FPDMEIABFON.BAGKGLJDBMA.DNKGILJELHJ PFJDGMBJGMA()
		{
			return null;
		}

		private void MBDLKIMLPJA(float HBPENBPHCKH)
		{
		}

		public static void AddSample(FPDMEIABFON.BAGKGLJDBMA.DNKGILJELHJ CLOLACPGMFL, FPDMEIABFON.BAGKGLJDBMA.MDDBCCFCDFJ BACHMLLDEEA, FPDMEIABFON.BAGKGLJDBMA.MDDBCCFCDFJ DAFLKHFKFJE, FPDMEIABFON.BAGKGLJDBMA.IGGEEFHHMED.JNCCHMNPGDD.MJPOPFPCAFJ GBHOAABLEKO, FPDMEIABFON.BAGKGLJDBMA.IGGEEFHHMED.JNCCHMNPGDD.MJPOPFPCAFJ BCLLPMALPJK)
		{
		}

		public static FPDMEIABFON.BAGKGLJDBMA.MDDBCCFCDFJ SampleTransform(Transform CIKPGBAJLCH, Transform DAHEJCAEGDC, float HBPENBPHCKH)
		{
			return null;
		}

		public static FPDMEIABFON.BAGKGLJDBMA.MDDBCCFCDFJ SampleTransform(JKKOCBGMDKF CIKPGBAJLCH, float HBPENBPHCKH)
		{
			return null;
		}

		public static FPDMEIABFON.BAGKGLJDBMA.IGGEEFHHMED.JNCCHMNPGDD.MJPOPFPCAFJ SampleHandPose(PlayerPuppetHand GGEKJLKGLLA, Transform DAHEJCAEGDC, float HBPENBPHCKH)
		{
			return null;
		}

		public static FPDMEIABFON.BAGKGLJDBMA.IGGEEFHHMED.JNCCHMNPGDD.MJPOPFPCAFJ SampleHandPose(HLLELILGEBM GGEKJLKGLLA, float HBPENBPHCKH)
		{
			return null;
		}
	}
}
