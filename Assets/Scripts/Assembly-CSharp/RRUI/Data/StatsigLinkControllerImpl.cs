using RRUI.Navigation;
using UnityEngine;

namespace RRUI.Data
{
	public abstract class StatsigLinkControllerImpl<T> : BaseLinkControllerImpl<T> where T : class, NJIIBNCBBMK
	{
		[SerializeField]
		private bool useLayerInsteadOfExperiment;

		[SerializeField]
		private string statsigExperimentName;

		[SerializeField]
		private string statsigLayerName;

		[SerializeField]
		private string statsigParameterName;

		[SerializeField]
		private bool parameterDefaultValue;

		[SerializeField]
		private Route parameterTrueRoute;

		[SerializeField]
		private Route parameterFalseRoute;

		private HAIDJDDBCPP statsigExperiment;

		private JCHCNCODBEK statsigLayer;

private bool IAOMJBDBKCL
{
get 		{
			return false;
		}

}

protected override Uri KMNLNGJJGGF
{
get 		{
			return null;
		}

}
	}
}
