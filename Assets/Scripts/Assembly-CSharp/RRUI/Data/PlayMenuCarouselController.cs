using System;
using System.Collections.Generic;
using UnityEngine;

namespace RRUI.Data
{
	public class PlayMenuCarouselController : ModelController<PlayMenuCarouselModel>
	{
		[Serializable]
		private class HideIfNotInDisplayOrderConfigImpl : HideableControllerImpl<PlayMenuCarouselModel>
		{
			private Dictionary<string, int> _priorityMap;

			[SerializeField]
			private string id;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DisplayOrderPriorityImpl : ControllerImplementation<PlayMenuCarouselModel>
		{
			private struct CLEEOILPGNA
			{
				public Transform DHGHIDOLKGM;

				public int LDHIBGALEDK;
			}

			[Serializable]
			private struct TransformId
			{
				public Transform Transform;

				public string Id;
			}

			private sealed class OEBAGJGGMKP
			{
				public Transform child;

				internal bool _003COnModelChanged_003Eb__1(TransformId x)
				{
					return false;
				}
			}

			[SerializeField]
			private TransformId[] transformIds;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
