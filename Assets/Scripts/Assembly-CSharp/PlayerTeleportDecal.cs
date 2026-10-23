using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportDecal : MonoBehaviour
{
	public enum MEAKPKNGNAK
	{
		NONE = 0,
		TOOL_HIT = 1,
		BASE_ONLY = 2,
		BASE_AND_BEAM = 3
	}

	public enum FGECMMKMMPP
	{
		VALID = 0,
		INVALID = 1
	}

	private static MaterialPropertyBlock FFJMIFGCCEC;

	[SerializeField]
	private Transform baseVisual;

	[SerializeField]
	private Transform beamVisual;

	[SerializeField]
	private TeleportChargeVisual toolHitVisual;

	[SerializeField]
	private Material validMaterial;

	[SerializeField]
	private Material invalidMaterial;

	[HideInInspector]
	public List<Renderer> Renderers;

	private static readonly int OJGKDBBFDPB;

	private static readonly int LMEIMBAAMMN;

	private static readonly int DEPPIMJJJDP;

	private static readonly int BKBMCJGOBCJ;

	private static readonly int JPACDMDLPPB;

	private Animator CBCFEAPCGEO;

	private Material EJGPINBDAGG;

	private MEAKPKNGNAK AMPGIOIJEJA;

	private FGECMMKMMPP LBIAJDDCOKA;

	private Color NBKKONBDLJP;

	private static Color? IHBAAGAKCDI;

private Material APJBCPNMMDF
{
get 	{
		return null;
	}

}

private Material PBMIINCHBMO
{
get 	{
		return null;
	}

}

public MEAKPKNGNAK VisibilityMode
{
get 	{
		return MEAKPKNGNAK.NONE;
	}

set {
	}
}

public FGECMMKMMPP TargetValidity
{
get 	{
		return FGECMMKMMPP.VALID;
	}

set {
	}
}

public Color Color
{
get 	{
		return default;
	}

set {
	}
}

public static Color? DefaultColor
{
get 	{
		return null;
	}

private set {
	}
}

	private void Awake()
	{
	}

	private void BNDMCDLJLAJ()
	{
	}

	public void UpdatePosition(Vector3 DEOJEICGBBP, Vector3 LMCCJBKCDLN)
	{
	}

	public void UpdateCharge(float DHKEJJCLBKC)
	{
	}

	public void UpdateToolHitDecal(bool BFDBCMGIOBG, float DHKEJJCLBKC, Vector3 PEENEFMKNAC, Vector3 AGIHGFLNIHK)
	{
	}

	private void PEMGHJLMOLN()
	{
	}

	private void JEFPBGANIOA()
	{
	}
}
