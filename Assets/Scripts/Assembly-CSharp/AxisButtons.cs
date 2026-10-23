using System;
using UnityEngine;

[Serializable]
public abstract class AxisButtons
{
	public enum HAADGBAALBH
	{
		NONE = 0,
		LEFT = 1,
		RIGHT = 2,
		UP = 3,
		DOWN = 4
	}

	[Serializable]
	protected struct DirectionDescription
	{
		public HAADGBAALBH Direction;

		public float MinAngleDegrees;

		public float MaxAngleDegrees;
	}

	protected struct MDFBAFFEEPP
	{
		private bool NHHNGDEGJGO;

		private bool DLLPNCLLDMH;

		private bool OBHKJIBGCAE;

		private bool GJGENCAMOGD;

public bool HFDJPMBEIFA
{
get 		{
			return false;
		}

set {
		}
}

public bool IHFMHHDIEPB
{
get 		{
			return false;
		}

private set {
		}
}

public bool NFPJIOJOPHP
{
get 		{
			return false;
		}

private set {
		}
}

public bool IDPDNIOEOMM
{
get 		{
			return false;
		}

private set {
		}
}
	}

	[SerializeField]
	protected DirectionDescription[] possibleDirections;

	protected MDFBAFFEEPP[] directionStates;

	public AxisButtons()
	{
	}

	public abstract void CDJHKCNAIKI(Vector2 OJBODCOIDJO, bool BDPCDHJPONF, bool JLGCBKCLHLL = true);

	public bool IIOMJIOEDKA(HAADGBAALBH DOHDMPAOCIJ)
	{
		return false;
	}

	public bool OJHDOCMJPHO(HAADGBAALBH DOHDMPAOCIJ)
	{
		return false;
	}

	public bool AONPGAIOPJI(HAADGBAALBH DOHDMPAOCIJ)
	{
		return false;
	}

	protected HAADGBAALBH EEFEPPDLHGF(Vector2 OJBODCOIDJO)
	{
		return HAADGBAALBH.NONE;
	}
}
