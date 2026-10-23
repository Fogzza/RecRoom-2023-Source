using System;
using System.Collections.Generic;
using RecRoom;
using UnityEngine;

public class DynamicMeshTrail : CustomTrail
{
	private enum BHLIJLBCEAF
	{
		Up = 0,
		Forward = 1,
		Right = 2
	}

	private static readonly List<Vector3> LBKJNBHICML;

	private static readonly List<Color> EEMLKOCLMDD;

	private static readonly List<Vector2> FLEPIEHDCFN;

	private static readonly List<int> MNJMNIDHKPH;

	private static readonly int EIBEHEDBDPB;

	[SerializeField]
	private BHLIJLBCEAF tangentDirection;

	[NonSerialized]
	public bool CanAddPoints;

	private Mesh[] AAGNCKODHDF;

	private int HKEDFELGGNJ;

	private bool HKAJHEIHJIM;

	protected Vector3 BEEINBKHHBI;

	private bool FFGCGHPHKMF;

	private const float ONJBJBAIKNP = 2f;

	private float KIGCPMJMJPN;

	private RigidbodyEx IDCFALFGPFP;

	private int EJENHEGJIFD;

	private Color HMCAFGCGFJF;

	private Vector2 NFAANOHEHLK;

public bool AutoDisableOnSleep
{
get 	{
		return false;
	}

set {
	}
}

public float Opacity
{
get 	{
		return 0f;
	}

set {
	}
}

public int MaterialIndex
{
get 	{
		return 0;
	}

set {
	}
}

protected virtual Vector3 KDGMKBCPGIO
{
get 	{
		return default;
	}

}

private Mesh NNEMJIHPJBE
{
get 	{
		return null;
	}

}

public override Color Color
{
get 	{
		return default;
	}

set {
	}
}

public override Vector2 Widths
{
get 	{
		return default;
	}

set {
	}
}

protected override bool AJMPLJGMPDG
{
set {
	}
}

	protected override void Awake()
	{
	}

	private void OMPFMHJDHOC(RigidbodyEx ICHBECDKHOJ)
	{
	}

	private void OnDestroy()
	{
	}

	protected override void Update()
	{
	}

	protected override void OnEnable()
	{
	}

	protected override void FKBPKKDNDFL(Vector3 GACEEHCHKKI, Vector3 HIIGMPGIODD, float GNAACMHFLMG)
	{
	}

	protected override void MMBOMJPGECK()
	{
	}

	public void StartTrailFade()
	{
	}
}
