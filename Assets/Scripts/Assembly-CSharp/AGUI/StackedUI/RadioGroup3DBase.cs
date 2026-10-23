using System;
using System.Collections.Generic;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class RadioGroup3DBase<T> : MonoBehaviour where T : RadioButton3D
	{
		private sealed class MDIOCAGMJPP
		{
			public RadioButton3D pressedButton;

			internal bool _003COnButtonClicked_003Eb__0(RadioButton3D b)
			{
				return false;
			}
		}

		private Action ACKLEKNBLJJ__BackingField;

		[SerializeField]
		private List<T> buttonGroup;

public List<T> Buttons
{
get 		{
			return null;
		}

}

public event Action SelectionChanged {
add {
		}
remove {
		}
}

		private void Awake()
		{
		}

		internal void CAJJIMAIIHE()
		{
		}

		internal void CLNAAKBGFPA()
		{
		}

		public void AddButton(T PPMLMPHPLGO)
		{
		}

		public void AddButtons(List<T> CCIILICCHII)
		{
		}

		protected void BNFEJGHHHLO(RadioButton3D DJOEICHNNKP)
		{
		}

		public void SetSelectionStates(Func<RadioButton3D, bool> OLHFIPCKHNC)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
