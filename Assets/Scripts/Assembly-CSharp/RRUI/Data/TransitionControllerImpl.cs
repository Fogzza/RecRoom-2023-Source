using System;
using RRUI.Animation;
using UnityEngine;

namespace RRUI.Data
{
	public abstract class TransitionControllerImpl<T> : ControllerImplementation<T> where T : class, NJIIBNCBBMK
	{
		[SerializeField]
		private Transition activateTransition;

		[SerializeField]
		private Transition deactivateTransition;

		[NonSerialized]
		private bool cachedIsActive;

protected abstract bool IsActive
{
get ;
}

		protected override void IHEKMEOIBOI()
		{
		}

		protected override void AFELIDKEEFL()
		{
		}

		protected sealed override void NGFFCLPHKJN()
		{
		}
	}
}
