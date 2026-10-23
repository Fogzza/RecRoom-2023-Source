using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextField3D : PhysicalTextSource
{
	private sealed class OBCJALNHIDK
	{
		public TextField3D _003C_003E4__this;

		public string currentText;

		public TMP_TextInfo info;
	}

	private sealed class GJHGOPDLJJH
	{
		public int lod;

		public OBCJALNHIDK CS_0024_003C_003E8__locals1;

		internal void _003CRedraw_003Eb__0()
		{
		}
	}

	[SerializeField]
	private Font3DSettings fontSettings;

	[SerializeField]
	private LODGroup lodGroup;

	private readonly List<CombineInstance> NGJKHEECLDM;

	private Mesh[] HOJJOABAPAD;

	private Mesh NGMKAPINGFE;

	private static readonly List<Vector2> JPMHNAJLLNN;

	private static readonly List<Vector4> DEMKBIHFLBA;

	private static readonly List<Vector3> DPGIOEFJPGH;

	private static readonly List<Vector3> GCIIIJBGLBJ;

	private Action FBHMDDGDAJI;

public override bool SupportsThickness
{
get 	{
		return false;
	}

}

public override event Action MeshUpdated {
add {
	}
remove {
	}
}

	protected override void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public override bool TryGetMeshBounds(out Bounds DBPFJELGIGI)
	{
		DBPFJELGIGI = default;
		return false;
	}

	public override void Redraw(bool JCKJPDHHFPO = false, bool GLKBGPHMMNC = false)
	{
	}

	private void IBOHCHAOCHE(string HLIGBKANEEA, int EMMLNOGJBFM, TMP_TextInfo IOKKLHMKGAH)
	{
	}
}
