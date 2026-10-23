using System;
using UnityEngine;

[Serializable]
public class ExcelExample : ScriptableObject
{
	[SerializeField]
	[HideInInspector]
	public string SheetName;

	[SerializeField]
	[HideInInspector]
	public string WorksheetName;

	public ExcelExampleData[] dataArray;

	private void OnEnable()
	{
	}
}
