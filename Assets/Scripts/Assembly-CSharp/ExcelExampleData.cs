using System;
using UnityEngine;

[Serializable]
public class ExcelExampleData
{
	[SerializeField]
	private int id;

	[SerializeField]
	private string name;

	[SerializeField]
	private float strength;

	[SerializeField]
	private ONCKLNCCGIA difficulty;

	public int Id
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public string Name
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float Strength
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public ONCKLNCCGIA DIFFICULTY
	{
		get
		{
			return ONCKLNCCGIA.Easy;
		}
		set
		{
		}
	}
}
