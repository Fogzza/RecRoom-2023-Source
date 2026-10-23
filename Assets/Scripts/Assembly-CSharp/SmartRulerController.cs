using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using RecRoom.Core.Creation;
using RecRoom.Core.FastLines;
using TMPro;
using UnityEngine;

public class SmartRulerController : MonoBehaviourPun, CCAIFMPHKJB
{
	private const float JJLIFCOFHOF = 0.075f;

	public CreationObject creationObject;

	[SerializeField]
	private float minIncrement;

	[SerializeField]
	private float maxIncrement;

	[SerializeField]
	private float defaultIncrement;

	private global::CDLJMENCODC<float> CLDBDIFPPHK;

	[SerializeField]
	private TMP_Text labelPrefab;

	private static Transform AJPIFNBCANH;

	private readonly List<TMP_Text> LNBOIFMKAGK;

	private readonly List<FJANNHOKEEM> AALBFHACMNA;

	private bool LKJCBNHIJHM;

	[SerializeField]
	private FastLineSettings lineSettings;

	[SerializeField]
	private Transform rulerSandboxDeformableTransform;

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	private void LateUpdate()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void HIBBPFFGMNI(Vector3 GADDGJANIGG)
	{
	}

	void CCAIFMPHKJB.OnMakerPenDeformed(Vector3 GADDGJANIGG)
	{
		//ILSpy generated this explicit interface implementation from .override directive in HIBBPFFGMNI
		this.HIBBPFFGMNI(GADDGJANIGG);
	}

	private void LHHAGCLJIDB()
	{
	}

	void CCAIFMPHKJB.OnMakerPenTranslated()
	{
		//ILSpy generated this explicit interface implementation from .override directive in LHHAGCLJIDB
		this.LHHAGCLJIDB();
	}

	private void JPNMLHDGOGL()
	{
	}

	void CCAIFMPHKJB.OnMakerPenRotated()
	{
		//ILSpy generated this explicit interface implementation from .override directive in JPNMLHDGOGL
		this.JPNMLHDGOGL();
	}

	private void MCIDIAIFIFM()
	{
	}

	void CCAIFMPHKJB.OnMakerPenScaled()
	{
		//ILSpy generated this explicit interface implementation from .override directive in MCIDIAIFIFM
		this.MCIDIAIFIFM();
	}

	public void DirtyDimensions()
	{
	}

	private void EOAPIHMANJL()
	{
	}

	private void JHAOIKLMJDD()
	{
	}

	private void DIHAPGHFIPM(int GMEHLIHLGEH, Vector3 BAGMHHCMNNF, string HLIGBKANEEA)
	{
	}

	private void CPHMGNOMMAF(int GMEHLIHLGEH, Vector3 BAGMHHCMNNF, float MNKGPEKFPKK)
	{
	}

	private void LIDIANFFAIC()
	{
	}

	[CompilerGenerated]
	private void HEGNBJAHDFK(Transform IHPJCBCPLCM)
	{
	}

	[CompilerGenerated]
	private float PGPCLHBDKGN()
	{
		return 0f;
	}

	[CompilerGenerated]
	private void KJCHFHOLOHA(float MLIPDLAHDHI)
	{
	}

	[CompilerGenerated]
	private bool GHCBNLIEOOD()
	{
		return false;
	}
}
