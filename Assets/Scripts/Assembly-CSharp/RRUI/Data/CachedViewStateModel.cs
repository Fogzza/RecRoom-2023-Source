using System;
using System.Collections.Generic;
using RRUI.Navigation;
using UnityEngine;

namespace RRUI.Data
{
	public class CachedViewStateModel : RRUIModel
	{
		[SerializeField]
		private int cachedPageCapacity;

		private global::PFCCOJONNHA<RRUI.Navigation.Uri, Dictionary<Guid, object>> LAJCNHFDBOE;

		public readonly global::HHOBPMOCKMJ<RRUI.Navigation.Uri> RemoveEvent;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		public void Set<T>(RRUI.Navigation.Uri FKFKJOJNCLM, Guid FDAIMOMOHIG, T IPMIIEAGJKC)
		{
		}

		public bool TryGet<T>(RRUI.Navigation.Uri FKFKJOJNCLM, Guid FDAIMOMOHIG, out T IPMIIEAGJKC)
		{
			IPMIIEAGJKC = default;
			return false;
		}

		public void Remove(RRUI.Navigation.Uri FKFKJOJNCLM)
		{
		}

		public void Remove(RRUI.Navigation.Uri FKFKJOJNCLM, Guid FDAIMOMOHIG)
		{
		}
	}
}
