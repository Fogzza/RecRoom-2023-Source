using UnityEngine;

public abstract class CustomTrail : MonoBehaviour
{
	protected const int PBMPINNCNME = 128;

	[SerializeField]
	protected Material[] materials;

	[SerializeField]
	protected bool castShadows;

	[SerializeField]
	protected bool receiveShadows;

	[SerializeField]
	protected float lifetime;

	[SerializeField]
	protected Vector2 alphas;

	[SerializeField]
	protected Vector2 widths;

	[SerializeField]
	protected float minSpacing;

	[SerializeField]
	protected bool displayStartCap;

	[SerializeField]
	protected Renderer startCap;

	[SerializeField]
	protected bool displayEndCap;

	[SerializeField]
	protected Renderer endCap;

	protected float OIPNGKDHODA;

	protected float EGLPNCOMCJI;

	protected float BDGGFNOGBNC;

	protected bool HDDMEGMIIND;

	protected global::DOMOOLBLFAH<float> NBBFIHIECEN;

	protected global::DOMOOLBLFAH<Vector3> DIFMOMFKPOF;

	protected global::DOMOOLBLFAH<Vector3> NPAMCJHPJAH;

	protected global::DOMOOLBLFAH<float> OMOOPIPPNNB;

	private float IHHAIFGABLE;

protected bool ABGDHPBLJIN
{
get 	{
		return false;
	}

}

public abstract Color Color
{
get ;
set ;
}

public abstract Vector2 Widths
{
get ;
set ;
}

public float Lifetime
{
get 	{
		return 0f;
	}

set {
	}
}

public bool Running
{
get 	{
		return false;
	}

}

public float Length
{
get 	{
		return 0f;
	}

}

public Material[] Materials
{
get 	{
		return null;
	}

set {
	}
}

public float WidthScale
{
get 	{
		return 0f;
	}

set {
	}
}

protected virtual bool ACPIIPLJIHN
{
get 	{
		return false;
	}

}

protected virtual bool AJMPLJGMPDG
{
set {
	}
}

	protected abstract void MMBOMJPGECK();

	public virtual void Clear()
	{
	}

	protected virtual void Awake()
	{
	}

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
	}

	protected virtual void Update()
	{
	}

	protected void LDMOJLIIGDM()
	{
	}

	protected virtual void FKBPKKDNDFL(Vector3 GACEEHCHKKI, Vector3 HIIGMPGIODD, float GNAACMHFLMG)
	{
	}
}
