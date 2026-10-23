using System;
using RecRoom.Core;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public class MakerPenToolManipulate_Shape : MakerPenTool
	{
		[NonSerialized]
		private bool hasSelectedHandle;

		[NonSerialized]
		private BNBHHAKFADP handleInfo;

		[NonSerialized]
		private CreationController.KCJLEJAHMEB rayOffset;

		[NonSerialized]
		private Quaternion penRotationOffset;

		[NonSerialized]
		private float lastSynchronizeTime;

		[NonSerialized]
		private const float MANIPULATION_SYNCHRONIZE_TIME_INTERVAL = 0.1f;

		[NonSerialized]
		private MKEEBKAGLIB shapeManipulationManager;

		[NonSerialized]
		private IFCBCACOLMJ pendingUndoEntry;

		[NonSerialized]
		private bool triggerSelectionNextFrame;

		public override string HudLabel => null;

		public override Sprite HudSprite => null;

		public override void IHEKMEOIBOI(HHNPLBOFAGE IACECANFEKI, FBEHJNCKJPN CIMCLAFMGFE)
		{
		}

		public override void BJDNGFKFKPK(JPAACPJFONC FFGKGJBJJIB, HHNPLBOFAGE HHOMFBOLLIJ)
		{
		}

		public override void EHMICKMBCPH()
		{
		}

		public override void KENBMBNOMKI(JPAACPJFONC FFGKGJBJJIB)
		{
		}

		public override bool GLDCPHODIFE(Ray HAAAJDJGEFF)
		{
			return false;
		}

		private void GKGHFLJNJEL()
		{
		}

		private void BLDKNEPNIBE()
		{
		}
	}
}
