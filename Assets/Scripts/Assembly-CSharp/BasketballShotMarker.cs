using System;
using TMPro;
using UnityEngine;

public class BasketballShotMarker : MonoBehaviour
{
	[Serializable]
	private class ModesDisplay
	{
		public DJLBPCHNIKO mode;

		public Color textColor;

		public bool OutlineEnabled;
	}

	public enum DJLBPCHNIKO
	{
		Recent = 0,
		Farthest = 1
	}

	private static readonly ModesDisplay DOGMAGFALOO;

	[SerializeField]
	private TextMeshPro playerNameText;

	[SerializeField]
	private TextMeshPro distanceText;

	[SerializeField]
	private ModesDisplay[] modesDisplays;

	private const float NEFIPAHLNCI = 0.133f;

	private DJLBPCHNIKO DNLPIHIBJDP;

	private float HBOEJOCNHAO;

public DJLBPCHNIKO Mode
{
get 	{
		return DJLBPCHNIKO.Recent;
	}

set {
	}
}

public float Distance
{
get 	{
		return 0f;
	}

private set {
	}
}

	private ModesDisplay POCDDNPKNEK()
	{
		return null;
	}

	public void UpdateForShot(string HLBEAMIJDFJ, Vector3 INLGLHIPOMC, float DAMOGGANOJL)
	{
	}
}
