using System;
using System.Collections.Generic;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.Inputs
{
	public class ScreenPlayerActionInputMap : ScriptableObject
	{
		[Serializable]
		public class ActionInputBinding
		{
			public SerializedGuid actionTypeId;

			public NBBJGMFGNIL keyboardMouseInputType;

			public KCPKKLFAKBP gamepadInputType;

			public MNIBEKANKFF.BHLMACIFHKC actionType => MNIBEKANKFF.BHLMACIFHKC.None;
		}

		private sealed class FHLBEJPKNCM
		{
			public Dictionary<Guid, ActionInputBinding> testBindings;

			internal bool _003CRemoveBaseOverrides_003Eb__0(ActionInputBinding binding)
			{
				return false;
			}
		}

		public ScreenPlayerActionInputMap baseActionInputMap;

		public string key;

		public KLIMDPGKKGM[] supportedInputMethods;

		public string controlSchemeName;

		[TextArea]
		public string controlSchemeDescription;

		public bool devOnly;

		public PlayerHand.ICBKGDOJNDN mkbDominantHand;

		public bool defaultSwitchMouseButtonsWhileDualWielding;

		public bool defaultHoldToAimDownSights;

		[SerializeField]
		private ActionInputBinding[] actionInputBindings;

		public ActionInputBinding[] JGHICAEFPED()
		{
			return null;
		}

		private void EDGKLHJLNAH()
		{
		}

		private void JOADJJDILCL()
		{
		}
	}
}
