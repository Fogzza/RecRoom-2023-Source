using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace AGUI.StackedUI.Dialog
{
	public abstract class BaseTextInputUIDialog<TShowParams, TResponse> : UIDialog<TShowParams, TResponse>
	{
		public delegate bool EIOGFODBKNI(TextMeshProUGUI HADMIMJGCHD, string KAEDAICECGN);

		private sealed class FMHJOMDBAMC : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BaseTextInputUIDialog<TShowParams, TResponse> _003C_003E4__this;

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
			public FMHJOMDBAMC(int _003C_003E1__state)
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
		private TextMeshProUGUI titleText;

		[SerializeField]
		private TextMeshProUGUI bodyText;

		[SerializeField]
		private TextMeshProUGUI okText;

		[SerializeField]
		private TextMeshProUGUI infoText;

		[SerializeField]
		private TextMeshProUGUI characterCountText;

		[SerializeField]
		private string purifyContext;

		[SerializeField]
		private NCCCMIHAKMG purifyRuleset;

		private bool BCNOOIABPKG;

		private EIOGFODBKNI DPOBBOINDJO;

		private Coroutine MEMGJLMAHID;

		private bool AMDJBMBPDNA;

protected abstract ValidatedButtonInputField GODJGJEIGPH
{
get ;
}

protected abstract TResponse KEJCDHMONAL
{
get ;
}

		public override global::NCOKFFGPIJM<TResponse> ShowDialog(TShowParams ADCFFAJGNAM)
		{
			return null;
		}

		public override void ForceCancel(bool EDLFMMEDNGP)
		{
		}

		public void Button_Submit()
		{
		}

		public void Button_Cancel()
		{
		}

		private void LAKDHCDAHMN(string HLIGBKANEEA)
		{
		}

		private void LAKDHCDAHMN()
		{
		}

		public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		protected abstract void FFEAMMPGNLP(TShowParams ADCFFAJGNAM);

		protected abstract TResponse DEBNCJMABEH(string LDGLHPBNCMH);

		protected void NKCPMBHGMDJ(string BOGCJKAMALE, string HGIIJBKEGMK, string NMLDDBBKEBD, string JINHPNDAHKP, TMP_InputField.ContentType PANLMPDMCKG, int MPPKBKCGBKL, bool BCNOOIABPKG, EIOGFODBKNI DPOBBOINDJO, Func<string, bool> IECKGIBPFHD, TMP_InputField.CharacterValidation LCFHBGGAHLO, string AHJAJMMOJAL, bool LLKBDECFCMO)
		{
		}

		private IEnumerator PNJPDEDPPCO()
		{
			return null;
		}

		[CompilerGenerated]
		private void KLEEBKJPBLO(GMBCDOMHMFF.HLMOCMHMIEN MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void ANHEEBLNAEI(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void ELPOBBIHLNI()
		{
		}
	}
}
