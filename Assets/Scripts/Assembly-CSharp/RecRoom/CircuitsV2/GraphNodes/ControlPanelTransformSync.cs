using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Core.FastLines;
using UnityEngine;

namespace RecRoom.CircuitsV2.GraphNodes
{
	public sealed class ControlPanelTransformSync : MonoBehaviour, NKHKPBPHIEG, GEGJOMIDKCJ, CCAIFMPHKJB, CIDPCLPIFAH
	{
		private static class FMAEEPDMMJA
		{
			private sealed class DLFCLDAGPGC : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				private int _003CupdateCounter_003E5__2;

				private int _003Ci_003E5__3;

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
				public DLFCLDAGPGC(int _003C_003E1__state)
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

			private const int LGMEIDANAEI = 256;

			private static readonly List<ControlPanelTransformSync> PONFOHOLJHI;

			private static LAHBDKNMNHN GFBCHDKAFNN;

			private static IEnumerator<EGGPGCCKPCO> FIOACFBKONL()
			{
				return null;
			}

			public static void CPCILMEHKPA(ControlPanelTransformSync CMDPMJBEBAB)
			{
			}

			public static void MILDLLFOGOM(ControlPanelTransformSync CMDPMJBEBAB)
			{
			}
		}

		private bool AMPOILCCANN;

		private Chip FAEEPBJLCEA;

		private ControlPanelCircuitObjectBase EENCHKHCHIA;

		private bool BAAIHNDHLAF;

		private bool NPDMNMEPJKG;

		private int EHOHOADPMML;

		private FJANNHOKEEM NLLJIKNMOJK;

		private FastLineSettings IFADLBPHCJE;

public bool IsControlPanelSelected
{
get 		{
			return false;
		}

private set {
		}
}

public ControlPanelCircuitObjectBase ControlPanelCircuitObject
{
get 		{
			return null;
		}

}

		public static ControlPanelTransformSync AddComponent(Chip JJMNDCAFBDA, ControlPanelCircuitObjectBase EENCHKHCHIA)
		{
			return null;
		}

		public static void RemoveComponent(Chip JJMNDCAFBDA)
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void NMHEIJOMMLF()
		{
		}

		public void OnObjectSelected()
		{
		}

		public void OnObjectDeselected()
		{
		}

		private void IBEFMJPFNDF(bool HHLOAOKNDPO = false)
		{
		}

		private void ELHGNHCCNMN()
		{
		}

		void GEGJOMIDKCJ.OnMakerPenTranslateStart()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ELHGNHCCNMN
			this.ELHGNHCCNMN();
		}

		private void IIOONPALLPM()
		{
		}

		void GEGJOMIDKCJ.OnMakerPenRotateStart()
		{
			//ILSpy generated this explicit interface implementation from .override directive in IIOONPALLPM
			this.IIOONPALLPM();
		}

		private void HHBBMHJAOOM()
		{
		}

		void GEGJOMIDKCJ.OnMakerPenScaleStart()
		{
			//ILSpy generated this explicit interface implementation from .override directive in HHBBMHJAOOM
			this.HHBBMHJAOOM();
		}

		private void CPFFBPPHIHN()
		{
		}

		void GEGJOMIDKCJ.OnMakerPenDeformStart()
		{
			//ILSpy generated this explicit interface implementation from .override directive in CPFFBPPHIHN
			this.CPFFBPPHIHN();
		}

		private void LHHAGCLJIDB()
		{
		}

		void CCAIFMPHKJB.OnMakerPenTranslated()
		{
			//ILSpy generated this explicit interface implementation from .override directive in LHHAGCLJIDB
			this.LHHAGCLJIDB();
		}

		private void JPNMLHDGOGL()
		{
		}

		void CCAIFMPHKJB.OnMakerPenRotated()
		{
			//ILSpy generated this explicit interface implementation from .override directive in JPNMLHDGOGL
			this.JPNMLHDGOGL();
		}

		private void MCIDIAIFIFM()
		{
		}

		void CCAIFMPHKJB.OnMakerPenScaled()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MCIDIAIFIFM
			this.MCIDIAIFIFM();
		}

		private void HIBBPFFGMNI(Vector3 GADDGJANIGG)
		{
		}

		void CCAIFMPHKJB.OnMakerPenDeformed(Vector3 GADDGJANIGG)
		{
			//ILSpy generated this explicit interface implementation from .override directive in HIBBPFFGMNI
			this.HIBBPFFGMNI(GADDGJANIGG);
		}

		private void BAIHLHDCHPC()
		{
		}

		void CIDPCLPIFAH.OnMakerPenTranslateFinished()
		{
			//ILSpy generated this explicit interface implementation from .override directive in BAIHLHDCHPC
			this.BAIHLHDCHPC();
		}

		private void HNBBOLCADAA()
		{
		}

		void CIDPCLPIFAH.OnMakerPenRotateFinished()
		{
			//ILSpy generated this explicit interface implementation from .override directive in HNBBOLCADAA
			this.HNBBOLCADAA();
		}

		private void DIHOBPGGFLJ()
		{
		}

		void CIDPCLPIFAH.OnMakerPenScaleFinished()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DIHOBPGGFLJ
			this.DIHOBPGGFLJ();
		}

		private void NMEEFGCCNKG()
		{
		}

		void CIDPCLPIFAH.OnMakerPenDeformFinished()
		{
			//ILSpy generated this explicit interface implementation from .override directive in NMEEFGCCNKG
			this.NMEEFGCCNKG();
		}

		private void JOLNLLPLLDL()
		{
		}

		private void NPMDJGBGEMC()
		{
		}

		private void BEDODCEMOGO()
		{
		}

		private void POBIBPABPKK()
		{
		}

		void NKHKPBPHIEG.OnSelected()
		{
			//ILSpy generated this explicit interface implementation from .override directive in POBIBPABPKK
			this.POBIBPABPKK();
		}

		private void DOGPKLNNNPA()
		{
		}

		void NKHKPBPHIEG.OnDeselected()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DOGPKLNNNPA
			this.DOGPKLNNNPA();
		}
	}
}
