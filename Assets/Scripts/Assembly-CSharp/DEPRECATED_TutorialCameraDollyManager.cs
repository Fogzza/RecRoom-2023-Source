using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DEPRECATED_TutorialCameraDollyManager : MonoBehaviour
{
	public enum EJMKNAFNCIB
	{
		Stationary = 0,
		Linear = 1,
		Orbit = 2
	}

	private sealed class HICKIMFGOMK : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DEPRECATED_TutorialCameraDollyManager _003C_003E4__this;

		public float seconds;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public HICKIMFGOMK(int _003C_003E1__state)
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
	private Camera localCamera;

	public EJMKNAFNCIB mode;

	public float dollyTime;

	private GameObject IAONCPMGMDM;

	private Transform LLOLHOKFBIC;

	private GameObject IDDPMBDKMJB;

	private Transform MNPAGIJPEBB;

	private GameObject CMHGDAMKJJN;

	private Transform FLFHKIPJPNK;

	private bool LPAJDMBEPBO;

	private bool HILBAKPFAPJ;

	private bool CDLBACPEGBD;

	private bool HCNJBMGKNOB;

	private float HDGFHFCPNPD;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void SetSnapping(bool GNKOOOOLEIA)
	{
	}

	public void SetEasing(bool MNMFHMPGBIH)
	{
	}

	public void MakeVertical()
	{
	}

	public void SnapDollyStartToCamera()
	{
	}

	public void SnapDollyEndToCamera()
	{
	}

	public void StartMovingDelayed(float BGGBEMDBOHE)
	{
	}

	private IEnumerator AKHJGEGMGKN(float BGGBEMDBOHE)
	{
		return null;
	}

	public void StopMoving()
	{
	}

	private void EFJPHLAOMFE(float DPENACOGOGO, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH)
	{
		INLGLHIPOMC = default;
		HEGBBJCMANH = default;
	}

	public void TearDown()
	{
	}

	public void SharedSetup()
	{
	}

	public void SetupLinear()
	{
	}

	public void SetupOrbit()
	{
	}

	[CompilerGenerated]
	private void AEAPBPDEAPA()
	{
	}

	[CompilerGenerated]
	private void FBEGKDNEILF()
	{
	}

	[CompilerGenerated]
	private void BAFKMJBPELO()
	{
	}

	[CompilerGenerated]
	private void HIPNMHPLPLN()
	{
	}
}
