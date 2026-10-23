using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Audio
{
	public class MicAudioRecorder : MonoBehaviour
	{
		private interface LFENJIJMHKA : IDisposable
		{
			global::NCOKFFGPIJM<LDCCJDCBBPA> OHIFKOCBMCD();
		}

		private abstract class BFPFDHFHFOD<T> : LFENJIJMHKA, IDisposable
		{
			private sealed class AKHLJPIPIEG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public LDCCJDCBBPA inputStreamData;

				public BFPFDHFHFOD<T> _003C_003E4__this;

				public List<T> inputSamples;

				public global::PHLHFLLLDLK<LDCCJDCBBPA> completePromise;

				private BEBJIGHFAMA _003CopusEncoder_003E5__2;

				private int _003CframeSize_003E5__3;

				private int _003CframeCount_003E5__4;

				private List<byte> _003CcompressedData_003E5__5;

				private List<int> _003CcompressedPacketSizes_003E5__6;

				private T[] _003CcurrentFrame_003E5__7;

				private int _003Ci_003E5__8;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public AKHLJPIPIEG(int _003C_003E1__state)
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

			private List<T> CFAONKEMIEG;

			private int MBHAPJPKNFJ;

			private LDCCJDCBBPA IODLPGDEOBB;

			private LDCCJDCBBPA.HCMIPECOOIO.MKNOEEJBKOI JOALLMOAENA;

			private int LIHGKGJJKAP;

			private int HHPCFCMFLMK;

			private IDisposable LGHMKCMPDBP;

			private static int FCMEANONFMI(int IAKGPAAHECM)
			{
				return 0;
			}

			public BFPFDHFHFOD(LDCCJDCBBPA.HCMIPECOOIO.MKNOEEJBKOI JOALLMOAENA, float MHAAOONBMNJ, int APKLGIOPFOB, int HHPCFCMFLMK)
			{
			}

			public void JADDHPCBFHO(T[] DOEIKJEAMPB, int IPCNJDBKKDB, int AKPLFIBLHPE)
			{
			}

			public global::NCOKFFGPIJM<LDCCJDCBBPA> OHIFKOCBMCD()
			{
				return null;
			}

			public void Dispose()
			{
			}

			private IEnumerator<EGGPGCCKPCO> DBAGJPMPNLK(List<T> OMJLIDOKOBC, LDCCJDCBBPA IEOLNIEHFDO, global::PHLHFLLLDLK<LDCCJDCBBPA> JFIHJEIMDHP)
			{
				return null;
			}

			protected abstract void LJBDPHJMKOH(LDCCJDCBBPA HHKPCAENKBL, IReadOnlyList<T> OJJBEBECILJ);

			protected abstract ArraySegment<byte> CACBKLHKKHD(BEBJIGHFAMA BFBJJMGHFBN, T[] OJJBEBECILJ);
		}

		private class DAFALBBNCPM : BFPFDHFHFOD<float>
		{
			public DAFALBBNCPM(LDCCJDCBBPA.HCMIPECOOIO.MKNOEEJBKOI JOALLMOAENA, float MHAAOONBMNJ, int APKLGIOPFOB, int HHPCFCMFLMK) : base(JOALLMOAENA, MHAAOONBMNJ, APKLGIOPFOB, HHPCFCMFLMK)
			{
			}

			protected override void LJBDPHJMKOH(LDCCJDCBBPA HHKPCAENKBL, IReadOnlyList<float> CFAONKEMIEG)
			{
			}

			protected override ArraySegment<byte> CACBKLHKKHD(BEBJIGHFAMA BFBJJMGHFBN, float[] OJJBEBECILJ)
			{
				return default;
			}
		}

		private class IAAIOHGPJGK : BFPFDHFHFOD<short>
		{
			public IAAIOHGPJGK(LDCCJDCBBPA.HCMIPECOOIO.MKNOEEJBKOI JOALLMOAENA, float MHAAOONBMNJ, int APKLGIOPFOB, int HHPCFCMFLMK) : base(JOALLMOAENA, MHAAOONBMNJ, APKLGIOPFOB, HHPCFCMFLMK)
			{
			}

			protected override void LJBDPHJMKOH(LDCCJDCBBPA HHKPCAENKBL, IReadOnlyList<short> CFAONKEMIEG)
			{
			}

			protected override ArraySegment<byte> CACBKLHKKHD(BEBJIGHFAMA BFBJJMGHFBN, short[] OJJBEBECILJ)
			{
				return default;
			}
		}

		private sealed class LKPCOHKHCKD
		{
			public LFENJIJMHKA activeEncoder;

			internal void _003CFinishRecording_003Eb__0()
			{
			}
		}

		private const int JEIEHAFCLFD = 5000;

		[SerializeField]
		private LDCCJDCBBPA.HCMIPECOOIO.MKNOEEJBKOI format;

		[SerializeField]
		private DCJCIOFKFDI preferredSamplingRate;

		[SerializeField]
		private int compressedBitrate;

		private DAFALBBNCPM CCIOCEMOLDD;

		private IAAIOHGPJGK BCBNMLCPGNE;

		private bool LBAPJELMEBP;

public bool IsRecording
{
get 		{
			return false;
		}

private set {
		}
}

		private void OnDestroy()
		{
		}

		public void StartRecording(float MHAAOONBMNJ)
		{
		}

		public void CancelRecording()
		{
		}

		public global::NCOKFFGPIJM<LDCCJDCBBPA> FinishRecording()
		{
			return null;
		}

		private void PNMGAFEKGCA(ACMFCLCJBAO CDPFBDBELHI)
		{
		}

		private void KFFFPDNAFLM(GPLABFGBOAM CDPFBDBELHI)
		{
		}

		private void DAAAGCIGNHF()
		{
		}

		private void OPOACDKBGCC()
		{
		}
	}
}
