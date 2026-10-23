using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RecRoom
{
	[ExecuteInEditMode]
	public abstract class UIRotator : MonoBehaviour
	{
		[Serializable]
		private class UIRotatorValueChangedEvent : UnityEvent<UIRotator>
		{
		}

		[SerializeField]
		protected Text selectorText;

		[SerializeField]
		protected Selectable focusableElement;

		[SerializeField]
		private UIRotatorValueChangedEvent valueChangedEvent;

		private int GMEHLIHLGEH;

		[SerializeField]
		protected int resetIndex;

public int Index
{
get 		{
			return 0;
		}

set {
		}
}

public abstract int Count
{
get ;
}

		private void Awake()
		{
		}

		public void Regen()
		{
		}

		public void Select()
		{
		}

		protected virtual void PDAKNAAMEGE(int NCIDBMNJNEG = -1)
		{
		}

		public void RandomValue()
		{
		}

		protected abstract void JGEDNNLPDKM();

		public void Reset()
		{
		}

		public virtual void Button_Next()
		{
		}

		public virtual void Button_Previous()
		{
		}

		[CompilerGenerated]
		private void EEGEKHKFIMC(UIRotatorValueChangedEvent GADDGJANIGG)
		{
		}
	}
}
