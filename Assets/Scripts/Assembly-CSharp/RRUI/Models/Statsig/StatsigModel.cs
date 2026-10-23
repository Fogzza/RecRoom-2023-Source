using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using RRUI.Data;
using UnityEngine;

namespace RRUI.Models.Statsig
{
	public class StatsigModel : RRUIModel
	{
		[Serializable]
		public struct StatsigSortableTransform
		{
			public Transform Transform;

			public string StatsigTransformName;

			public bool ExcludeFromRandomSort;
		}

		private sealed class HKDHPELGCAJ
		{
			public System.Random rng;

			internal int _003CGetRandomizedDisplayOrder_003Eb__0(string x)
			{
				return 0;
			}
		}

		private const string HOIBOMKMPDJ = "randomize_order";

		private FEIKFKAICHC JINHNPGMCMC;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		public static int TryGetSiblingIndexOfParentStatsigComponent(GameObject KJOBILIAJFD)
		{
			return 0;
		}

		public bool IsFeatureGateActive(string DNFIOLEHDGI)
		{
			return false;
		}

		public bool IsExperimentParameterActive(string BJJDBMNFODL, string JLAOKGCHIKF)
		{
			return false;
		}

		public T GetLayerParameter<T>(string GFAMFLKGNLI, string JLAOKGCHIKF, T GFLAEOLMKMC)
		{
			return default;
		}

		public HAIDJDDBCPP GetExperiment(string BJJDBMNFODL)
		{
			return null;
		}

		public JCHCNCODBEK GetLayer(string GFAMFLKGNLI)
		{
			return null;
		}

		public void SortTransformsForExperiment(string BJJDBMNFODL, string CHJJLIDPGDI, string JLAOKGCHIKF, Dictionary<string, StatsigSortableTransform> LPDCKADABDG)
		{
		}

		public void SortTransformsForLayer(string GFAMFLKGNLI, string JLAOKGCHIKF, Dictionary<string, StatsigSortableTransform> LPDCKADABDG)
		{
		}

		private void HDKOGMKMDEM(List<string> HMFOBINIDDE, bool BDMMNJEPKOJ, Dictionary<string, StatsigSortableTransform> LPDCKADABDG)
		{
		}

		public List<string> TryGetDisplayOrder(JToken IALNODEHBNN)
		{
			return null;
		}

		private List<string> DELEPOAIIDP(List<string> OJGHGBDJKAF, Dictionary<string, StatsigSortableTransform> EDPIJECELAJ)
		{
			return null;
		}
	}
}
