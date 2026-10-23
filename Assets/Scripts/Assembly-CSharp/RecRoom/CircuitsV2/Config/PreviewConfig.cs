using System;
using UnityEngine;

namespace RecRoom.CircuitsV2.Config
{
	[Serializable]
	public sealed class PreviewConfig
	{
		[SerializeField]
		private CreationPreview nodePreviewPrefab;

		public CreationPreview NodePreviewPrefab => null;
	}
}
