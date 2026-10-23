using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
	private sealed class HDNKPCCKEOG : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public HealthBar _003C_003E4__this;

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
		public HDNKPCCKEOG(int _003C_003E1__state)
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

	private sealed class JOADNECCNFK : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public HealthBar _003C_003E4__this;

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
		public JOADNECCNFK(int _003C_003E1__state)
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

	private sealed class PCGFKCMBLNA : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public HealthBar _003C_003E4__this;

		public float initialAlpha;

		public float finalAlpha;

		public float duration;

		private float _003Ctimer_003E5__2;

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
		public PCGFKCMBLNA(int _003C_003E1__state)
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

	private static int NPDMGGIEFOG;

	[SerializeField]
	private GameObject backgroundVisualGroup;

	[SerializeField]
	private GameObject mainHealthVisual;

	[SerializeField]
	private float damageHealthChangeDelay;

	[SerializeField]
	private Color healthColor;

	[SerializeField]
	private GameObject damagedHealthVisual;

	[SerializeField]
	private GameObject damagedHealthTransform;

	[SerializeField]
	private float damagedHealthChangeTime;

	[SerializeField]
	private Color damageColor;

	[SerializeField]
	private float fadeInDuration;

	[SerializeField]
	private float fadeOutDuration;

	[SerializeField]
	private bool onlyShowWhenDamaged;

	[SerializeField]
	private bool supportsViewFading;

	[SerializeField]
	private float fullyOpaqueDistance;

	[SerializeField]
	private float fullyTransparentDistance;

	[SerializeField]
	private float localDamageVisibleDuration;

	[SerializeField]
	private float localDamageFadingDuration;

	[NonSerialized]
	public bool AlwaysViewVisible;

	private Renderer PJCDHKMAICD;

	private Renderer BODCKCEODNG;

	private Renderer PDFCOHAFFKD;

	private MaterialPropertyBlock BEKDCEKAMAO;

	private MaterialPropertyBlock IOEIOJPELGF;

	private MaterialPropertyBlock NAIFIENLOFK;

	private float FJKJIMNOLNJ;

	private float KMOCGLLHJOI;

	private float NIEDFCCLPAB;

	private float DAJMGDFMKBO;

	private Coroutine KHKAEJAIMKC;

	private bool EEHNOCAINAP;

	private Renderer[] KJJMMGMBOFO;

	private float HKLJKDEJENN;

	private float DEPBJOJKFGP;

	private float BEMJBKHCKJO;

	private bool LBKPJIPPFCD;

public float Alpha
{
get 	{
		return 0f;
	}

}

private float HMDBDODNFLG
{
get 	{
		return 0f;
	}

set {
	}
}

private float AJBKFAGEOCM
{
get 	{
		return 0f;
	}

set {
	}
}

private float AJGPBCJIACN
{
get 	{
		return 0f;
	}

set {
	}
}

private float DGEOODOLMEO
{
get 	{
		return 0f;
	}

}

private float NEJDLHDGEMC
{
get 	{
		return 0f;
	}

}

	private void Awake()
	{
	}

	private void LKGDLJCPKIB(GameObject FPHCJAKJEPB, out Renderer LPCBHIEOFOB, out MaterialPropertyBlock ECEFLJDFNBM, Color HMCAFGCGFJF)
	{
		LPCBHIEOFOB = null;
		ECEFLJDFNBM = null;
	}

	private void Update()
	{
	}

	public void SetBarColor(Color HMCAFGCGFJF)
	{
	}

	public void SetAnimated(bool LBKPJIPPFCD)
	{
	}

	public void ResetHealth(float KMCHOFBADKI, float EMDIPCIPFBF)
	{
	}

	private void NDCBCOBPKIH(GameObject ICHBECDKHOJ, float IPMIIEAGJKC)
	{
	}

	public void OnBarUpdate(float IPMIIEAGJKC, float AFALOODLEEP, bool ELBDICCFGGN = false)
	{
	}

	private void MOKLDKICINM(bool BMGEHFPFCBJ)
	{
	}

	private void KNKGPPLJNPH()
	{
	}

	private void KAEGHCEKJJP(Renderer LPCBHIEOFOB, MaterialPropertyBlock ECEFLJDFNBM, float PCGNMAOFNEF = 1f)
	{
	}

	public void FadeIn()
	{
	}

	public void FadeOut()
	{
	}

	private IEnumerator IAFDHJADHMN()
	{
		return null;
	}

	private IEnumerator GEOGANJLDJI()
	{
		return null;
	}

	private IEnumerator BEKOHPHLLGJ(float FGBPJMKCMAO, float OPHLBJJMFCK, float JIGEEOEJODE)
	{
		return null;
	}

	private void JBPOPBADMHP()
	{
	}

	private void GLHDHHKCKFA()
	{
	}

	private void MMHFPAIFJPL()
	{
	}
}
