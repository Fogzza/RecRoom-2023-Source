using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.CircuitsV2.Config
{
	[Serializable]
	public sealed class ChipConfig
	{
		[SerializeField]
		private Mesh[] meshes;

		[SerializeField]
		private float titleTextY;

		[SerializeField]
		private float selfPortY;

		[SerializeField]
		private float firstPortY;

		[SerializeField]
		private float titleTextXMargin;

		[SerializeField]
		private float titleTextLeftMargin;

		[SerializeField]
		private float titleTextRightMargin;

		[SerializeField]
		private float portXInset;

		[SerializeField]
		private float portTextXSpaceBetween;

		[SerializeField]
		private float minInputPortWidth;

		[SerializeField]
		private float minOutputPortWidth;

		[SerializeField]
		private float noPortsYAdjustment;

		[SerializeField]
		private float anyPortsYAdjustment;

		[SerializeField]
		private float minHeight;

		[SerializeField]
		private Vector3 axisOffset;

		[SerializeField]
		private Vector3 axisMargin;

		[SerializeField]
		private Vector3 meshRotation;

		[SerializeField]
		private bool overrideInnerContextIconTopRightMargin;

		[SerializeField]
		private Vector2 innerContextIconTopRightMarginOverride;

		[SerializeField]
		private bool overrideCustomIconTopLeftMargin;

		[SerializeField]
		private Vector2 customIconTopLeftMarginOverride;

		[SerializeField]
		private float functionHeaderHeight;

		[SerializeField]
		private float functionHeaderHorizontalPadding;

		[SerializeField]
		private bool showBusConfigButton;

		[SerializeField]
		private float boardBusConfigButtonYSize;

		public IReadOnlyList<Mesh> Meshes => null;

		public float TitleTextY => 0f;

		public float SelfPortY => 0f;

		public float FirstPortY => 0f;

		public float TitleTextXMargin => 0f;

		public float TitleTextLeftMargin => 0f;

		public float TitleTextRightMargin => 0f;

		public float PortXInset => 0f;

		public float PortTextXSpaceBetween => 0f;

		public float MinInputPortWidth => 0f;

		public float MinOutputPortWidth => 0f;

		public float NoPortsYAdjustment => 0f;

		public float AnyPortsYAdjustment => 0f;

		public float MinHeight => 0f;

		public Vector3 AxisOffset => default;

		public Vector3 AxisMargin => default;

		public Vector3 MeshRotation => default;

		public bool OverrideInnerContextIconTopRightMargin => false;

		public Vector2 InnerContextIconTopRightMarginOverride => default;

		public bool OverrideCustomIconTopLeftMargin => false;

		public Vector2 CustomIconTopLeftMarginOverride => default;

		public float FunctionHeaderHeight => 0f;

		public float FunctionHeaderHorizontalPadding => 0f;

		public bool ShowBusConfigButton => false;

		public float BoardBusConfigButtonYSize => 0f;
	}
}
