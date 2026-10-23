using System;
using AGUI.StackedUI;
using UnityEngine;

public abstract class EnumSlider<T> : MonoBehaviour where T : struct, IConvertible
{
	[SerializeField]
	private Slider3D slider;

	[SerializeField]
	private T[] options;

public T Value
{
get 	{
		return default;
	}

set {
	}
}

public bool Interactable
{
get 	{
		return false;
	}

set {
	}
}
}
