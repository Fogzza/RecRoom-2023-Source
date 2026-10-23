using RecRoom.UI;
using UnityEngine;

namespace RecRoom.Inputs.Touch
{
	public class TouchRegion : IndexableScreenHUDDialog
	{
		public enum ILPDMJAHCNI
		{
			None = 0,
			AimAndWalk = 1,
			Custom = 2
		}

		[SerializeField]
		protected MIKAPGMDNAD inputType;

		[SerializeField]
		private GHGAFACIPLP priority;

		[SerializeField]
		private PNHHOJKFPON touchRegionShape;

		[SerializeField]
		protected bool useCustomTouchRegion;

		[SerializeField]
		private RectTransform customTouchRegion;

		[SerializeField]
		private bool blocksRaycasts;

		[SerializeField]
		private ILPDMJAHCNI friendlyRegionType;

		[SerializeField]
		private TouchRegion[] friendlyRegions;

		[SerializeField]
		protected bool deferredLock;

		[SerializeField]
		protected int maxTrackedFingerCount;

		[SerializeField]
		protected bool slideOver;

		[SerializeField]
		protected DHJAAKMJLMH.AABCFBOEMHD axisType;

		[SerializeField]
		protected UITransition activeInputTransition;

		[SerializeField]
		protected UITransition enabledTransition;

		private DHJAAKMJLMH JDHKMCLBHGM;

public MIKAPGMDNAD InputType
{
get 		{
			return MIKAPGMDNAD.AimRegion;
		}

}

public override int Index
{
get 		{
			return 0;
		}

}

public DHJAAKMJLMH Input
{
get 		{
			return null;
		}

private set {
		}
}

private RectTransform KDIJDGMCMDB
{
get 		{
			return null;
		}

}

		public void InitializeInput()
		{
		}

		private void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void LateUpdate()
		{
		}

		protected void BJGBFKAKGPK()
		{
		}
	}
}
