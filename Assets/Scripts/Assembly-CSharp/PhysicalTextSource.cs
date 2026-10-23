using System;
using TMPro;
using UnityEngine;

public abstract class PhysicalTextSource : MonoBehaviour
{
	[SerializeField]
	protected TMP_Text linkedTextField;

	[SerializeField]
	protected Renderer[] lodRenderers;

	[SerializeField]
	private bool useMinimumTextFieldWidth;

	[SerializeField]
	private bool useMinimumTextFieldHeight;

	[SerializeField]
	private bool updatePivot;

	private bool GMEKKCPLMOB;

	private float EMKPMLNBDEF;

	protected string DMBPFMPKAIL;

	protected Vector2 CEGBIPPKHJB;

protected string KKHKFIGPMMA
{
get 	{
		return null;
	}

}

public bool IsVisible
{
get 	{
		return false;
	}

set {
	}
}

public float Thickness
{
get 	{
		return 0f;
	}

set {
	}
}

public abstract bool SupportsThickness
{
get ;
}

public abstract event Action MeshUpdated;

	public abstract void Redraw(bool JCKJPDHHFPO = false, bool GLKBGPHMMNC = false);

	protected virtual void Awake()
	{
	}

	private void Start()
	{
	}

	public abstract bool TryGetMeshBounds(out Bounds DBPFJELGIGI);

	public bool UpdatePivot(GCNPLJCMHED GODHANJKGNI)
	{
		return false;
	}
}
