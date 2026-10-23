using System;
using System.Collections.Generic;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class BaseCreationObjectSettingFriendlyGuidControl<UIControlType> : CreationObjectSettingPropertyUIControl<Guid, UIControlType> where UIControlType : CreationObjectSettingPropertyUIControl<Guid, UIControlType>
	{
		private sealed class GFGHIOLOGIN
		{
			public Guid? overriddenValue;

			public BaseCreationObjectSettingFriendlyGuidControl<UIControlType> _003C_003E4__this;

			public bool interactible;

			internal bool _003CUpdateButtons_003Eb__0(RadioButton3D b)
			{
				return false;
			}
		}

		[SerializeField]
		private FriendlyGuidPagedGrid friendlyGuidPagedGrid;

		[SerializeField]
		private RadioGroup3D radioGroup;

		private void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void SetOptions(Dictionary<string, FriendlyGuidButton.LJECGMLHJAB> PAEGNAAIGON, Guid KCAPLJEHMMI)
		{
		}

		private void AGOODNEGOEM()
		{
		}

		private void FENHKPKABFC(Guid? LIOPFOFEGIL)
		{
		}
	}
}
