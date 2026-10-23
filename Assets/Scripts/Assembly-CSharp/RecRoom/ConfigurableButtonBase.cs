using Photon.Pun;
using RecRoom.Core.Creation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom
{
	public class ConfigurableButtonBase : MonoBehaviourPun
	{
		public const string NOT_CONFIGURED_NAME = "Configure";

		protected const int LJDFDGABJJF = -1;

		[SerializeField]
		protected Tool tool;

		private readonly bool LIDLPBBMGMJ;

		[SerializeField]
		protected PhysicalButtonBase button;

		[SerializeField]
		private SandboxColorable colorable;

		[SerializeField]
		protected TMP_Text labelText;

		[SerializeField]
		protected Image buttonIcon;

		[SerializeField]
		private Renderer[] activatedRenderers;

		[SerializeField]
		private Transform activatedButtonRoot;

		[SerializeField]
		private Renderer[] deactivatedRenderers;

		[SerializeField]
		private Transform deactivatedButtonRoot;

		[SerializeField]
		private Color deactivatedColor;

		[SerializeField]
		protected Sprite notConfiguredIcon;

		[SerializeField]
		protected Sprite configuredIcon;

		private MaterialPropertyBlock HOOJEGOGAPE;

		private float FGPJHKCLEEG;

public virtual bool IsActivated
{
get 		{
			return false;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

public PhysicalButtonBase Button
{
get 		{
			return null;
		}

}

protected virtual bool MAOHEBDCGLF
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected virtual void CMJJKMHKDCD(bool FIODJAALKDO)
		{
		}

		private void CFHPPDHBAPL()
		{
		}

		private void EJPLAOOFPBN()
		{
		}

		private void HPKHJNPKMCJ()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
