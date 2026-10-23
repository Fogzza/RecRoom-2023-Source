using RecRoom.Core.Creation;
using TMPro;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	public class MakerPenPinInfo : MakerPenPinInfoBase
	{
		public enum CHNJGMNEPOO
		{
			Wire = 0,
			Delete = 1,
			Invalid = 2,
			ConnectObject = 3,
			ConnectGizmo = 4,
			Configure = 5,
			Play = 6,
			None = 7
		}

		public GameObject wireOperationVisuals;

		public GameObject deleteOperationVisuals;

		public GameObject invalidOperationVisuals;

		public GameObject connectGizmoOperationVisuals;

		public GameObject connectObjectOperationVisuals;

		public GameObject playOperationVisuals;

		public GameObject textRoot;

		public GameObject operationRoot;

		public TMP_Text valueText;

		private CHNJGMNEPOO FBNCIMJJJAE;

		private ConnectionPoint BMBOEJJJMGL;

protected override TMP_Text[] COEFOJHBFCC
{
get 		{
			return null;
		}

}

public virtual CHNJGMNEPOO CurrentOperation
{
get 		{
			return CHNJGMNEPOO.Wire;
		}

set {
		}
}

public virtual bool IsCV2
{
get 		{
			return false;
		}

}

public virtual ConnectionPoint connection
{
get 		{
			return null;
		}

set {
		}
}

		public virtual void SetOperation(CHNJGMNEPOO NOLBAAIMOCO)
		{
		}

		public virtual void Init(ConnectionPoint HOFDCJAAGMA)
		{
		}

		protected virtual void GEMHIHIOHJG(in Vector3 BAGMHHCMNNF, Camera PIDJEEEAKCF)
		{
		}

		public virtual void UpdateInfo(in Vector3 BAGMHHCMNNF, Camera PIDJEEEAKCF = null)
		{
		}
	}
}
