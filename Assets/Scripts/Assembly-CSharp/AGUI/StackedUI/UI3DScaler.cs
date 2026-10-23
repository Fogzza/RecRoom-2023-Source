using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AGUI.StackedUI
{
	[ExecuteInEditMode]
	public class UI3DScaler : UIBehaviour
	{
		[Serializable]
		public enum ZScaleMatch
		{
			NONE = 0,
			X = 1,
			Y = 2
		}

		[SerializeField]
		private RectTransform facePlaneTransform;

		[SerializeField]
		private Vector3 scaleModifier;

		[SerializeField]
		private Canvas _canvas;

		public ZScaleMatch zScaleMatch;

public Canvas ThisCanvas
{
get 		{
			return null;
		}

set {
		}
}

		public void FetchRootCanvas()
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		public void Refresh()
		{
		}

		private void KANNLKCLIOF()
		{
		}
	}
}
