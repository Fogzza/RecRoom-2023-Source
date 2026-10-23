using UnityEngine;

namespace RRUI.Data
{
	public abstract class ProgressBarControllerImpl<T> : ControllerImplementation<T> where T : class, NJIIBNCBBMK
	{
		[SerializeField]
		protected ProgressBar progressBar;
	}
}
