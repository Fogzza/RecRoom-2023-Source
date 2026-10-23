using System;
using UnityEngine;

namespace AGUI.StackedUI
{
	public abstract class ResizableElementBase : MonoBehaviour
	{
		public abstract void Resize(OMNLIPPAPDI CAPKFCHDLFA);
	}
	public abstract class ResizableElementBase<T> : ResizableElementBase where T : ResizableElementBase<T>.SizeSettingsBase
	{
		[Serializable]
		public class SizeSettingsBase
		{
			public OMNLIPPAPDI size;
		}

protected abstract T[] LMACFJJCBOB
{
get ;
}

		public override void Resize(OMNLIPPAPDI CAPKFCHDLFA)
		{
		}

		protected abstract void FFEJFIHJFJF(T CAOIPCMMNMJ);
	}
}
