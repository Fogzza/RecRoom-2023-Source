using System;

namespace AGUI.StackedUI
{
	public abstract class CreationObjectSettingPropertyUIControl<T, UIControlType> : BaseCreationObjectSettingPropertyUIControl where UIControlType : CreationObjectSettingPropertyUIControl<T, UIControlType>
	{
		public Action<T> PropertySetter;

		public Func<bool> InteractibleGetter;

		public Func<T> PropertyGetter;

		public Action<UIControlType> UpdateControlFunction;

		private Action OLBNEJNKAOH__BackingField;

		private Action OANBCKHCBIE__BackingField;

		private Action HLKACPCENJB__BackingField;

		public Func<T, T, IFCBCACOLMJ> UndoEntryProvider;

public bool ActiveInHierarchy
{
get 		{
			return false;
		}

}

public event Action OnDestroyEvent {
add {
		}
remove {
		}
}

public event Action OnEnableEvent {
add {
		}
remove {
		}
}

public event Action OnDisableEvent {
add {
		}
remove {
		}
}

		protected virtual void JDJFOLOFJGL(T DLEMNBPMGBG)
		{
		}

		public sealed override void UpdateControl()
		{
		}

		protected virtual void NGPGENCCLNA()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}
	}
}
