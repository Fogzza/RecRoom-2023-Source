using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using UnityEngine;

public class ToolTrail : MonoBehaviour
{
	private sealed class EDEKBBHFNNK : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float duration;

		public ToolTrail _003C_003E4__this;

		public float maxTime;

		private float _003CtimeRemaining_003E5__2;

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
		public EDEKBBHFNNK(int _003C_003E1__state)
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
	private bool visibleWhileHeld;

	[SerializeField]
	private float heldTime;

	[SerializeField]
	private bool visibleUponRelease;

	[SerializeField]
	private float releaseTime;

	[SerializeField]
	private bool fadeOutUponRelease;

	[SerializeField]
	private float releaseFadeOutDuration;

	[SerializeField]
	private bool visibleAfterAttackApplied;

	[SerializeField]
	private float forceAppliedTime;

	[SerializeField]
	private bool fadeOutAfterForceApplied;

	[SerializeField]
	private float forceAppliedFadeOutDuration;

	private Tool PMEFICGEDFK;

	private TrailRenderer NDLLFNGCJJG;

	private Coroutine EIHIGOIPKPC;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void PLLGKABPABI(Tool PMEFICGEDFK, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
	{
	}

	private void JFGMIGPAJNO(Tool IEGMBEPJMGC)
	{
	}

	private void IEELJEBHDEI(Tool IEGMBEPJMGC)
	{
	}

	private void PIBDCBNAMLB(Tool PMEFICGEDFK, MonoBehaviourPun GLLFHCCFIGK, DJBEHNDMJDL IKEDGLGPGEA, Vector3 PDFEDMAOMNH, Vector3 COPOILGLIAJ, ForceMode OJOAKAEAKAC)
	{
	}

	private void AHLEJACELKF(float FGBPJMKCMAO, float JMGGBACJFPI)
	{
	}

	private void ODJJIGCGHEO()
	{
	}

	private IEnumerator KPGPGIMAFGF(float FGBPJMKCMAO, float JMGGBACJFPI)
	{
		return null;
	}

	private void FKDOGMAACPB()
	{
	}

	private void EKJCNJHFBND(float OOBOIODABDP)
	{
	}
}
