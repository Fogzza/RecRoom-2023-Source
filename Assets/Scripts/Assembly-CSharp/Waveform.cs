using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Waveform : MonoBehaviour
{
	private sealed class POJGBELHJKC
	{
		public float normalizer;

		internal void _003CGenerateWaveformFromAudioClip_003Eb__0(float n)
		{
		}
	}

	private sealed class NCAKPPODKAL : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AudioClip clip;

		public Waveform _003C_003E4__this;

		private POJGBELHJKC _003C_003E8__1;

		private float[] _003Cwaveform_003E5__2;

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
		public NCAKPPODKAL(int _003C_003E1__state)
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

	private sealed class JIPIFDELBBM : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Waveform _003C_003E4__this;

		public AudioClip clip;

		public int resolution;

		public float[] waveform;

		public Action<float> normalizera;

		private float[] _003Csamples_003E5__2;

		private int _003CframeSize_003E5__3;

		private float _003Cmax_003E5__4;

		private int _003Ci_003E5__5;

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
		public JIPIFDELBBM(int _003C_003E1__state)
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

	private sealed class KLLJGFBBFCB
	{
		public float normalizer;

		internal void _003CGenerateWaveformFromData_003Eb__0(float n)
		{
		}
	}

	private sealed class JGKKFFINKLF : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float[] sampleArray;

		public Waveform _003C_003E4__this;

		private KLLJGFBBFCB _003C_003E8__1;

		private float[] _003Cwaveform_003E5__2;

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
		public JGKKFFINKLF(int _003C_003E1__state)
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

	private sealed class NHEANNFBLHC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Waveform _003C_003E4__this;

		public int sampleLength;

		public float[] waveform;

		public float[] clipSamples;

		public Action<float> normalizera;

		private int _003CframeSize_003E5__2;

		private float _003Cmax_003E5__3;

		private int _003Ci_003E5__4;

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
		public NHEANNFBLHC(int _003C_003E1__state)
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

	private sealed class PEDIFMFHBHI : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector2Int resolution;

		public float normalizer;

		public Waveform _003C_003E4__this;

		public float[] waveform;

		public Action<Texture2D> result;

		private Texture2D _003Ctex_003E5__2;

		private int _003Cx_003E5__3;

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
		public PEDIFMFHBHI(int _003C_003E1__state)
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

	private sealed class GCPFHHMGNIG : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Waveform _003C_003E4__this;

		private int _003Cx_003E5__2;

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
		public GCPFHHMGNIG(int _003C_003E1__state)
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
	private RawImage rawImage;

	[SerializeField]
	private bool renderHalf;

	[SerializeField]
	private Color waveColor;

	[SerializeField]
	private Color backgroundColor;

	[SerializeField]
	private TMP_Text loadingText;

	[SerializeField]
	private GameObject waveformDisplay;

	[SerializeField]
	private Vector2Int resolution;

	private Texture2D EDPNGGBBEPG;

	private Stopwatch LKKCBBBBCOG;

	private const int MMDEALCNIED = 10;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void LoadingWaveform(bool FPDJJELEBMD, string HLIGBKANEEA = "")
	{
	}

	public IEnumerator GenerateWaveformFromAudioClip(AudioClip DLLECDOAMDE)
	{
		return null;
	}

	private void EFFNFMNCPHE(bool MIMHIECKAEG, string HLIGBKANEEA = "")
	{
	}

	private IEnumerator JIIFOHBCEPP(AudioClip DLLECDOAMDE, int NDECALNLBGD, float[] JGHMFINMHOA, Action<float> INMLHDJNLAF)
	{
		return null;
	}

	public IEnumerator GenerateWaveformFromData(float[] CIMKDLAPKIP)
	{
		return null;
	}

	public IEnumerator GetWaveformFromRawData(float[] FAOBNJHEOAH, int MHGGMDKJNLA, float[] JGHMFINMHOA, Action<float> INMLHDJNLAF)
	{
		return null;
	}

	private IEnumerator CECPPBLNAAH(float[] JGHMFINMHOA, float AIADOGGADGA, Vector2Int NDECALNLBGD, Action<Texture2D> CDNLFEOBNKB)
	{
		return null;
	}

	private IEnumerator JBKOOGEJJKK()
	{
		return null;
	}

	[CompilerGenerated]
	private void LJOIILNILCF(Texture2D IHPJCBCPLCM)
	{
	}

	[CompilerGenerated]
	private void EDMPLBAOGPM(Texture2D IHPJCBCPLCM)
	{
	}
}
