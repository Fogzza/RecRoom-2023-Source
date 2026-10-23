using System.Collections.Generic;
using UnityEngine;

namespace RRUI
{
	public class WorldCanvasViewHider : MonoBehaviour
	{
		public enum GCNOHCNBNGP
		{
			ShowingCloseHideables = 0,
			ShowingFarHideables = 1,
			HidingAll = 2
		}

		[SerializeField]
		private List<Hideable> hideablesToShowWhenClose;

		[SerializeField]
		private List<Hideable> hideablesToShowAtDistance;

		[SerializeField]
		private Transform canvasRoot;

		[SerializeField]
		private int updateRateInHz;

		[SerializeField]
		private float backFaceAngleThreshold;

		[SerializeField]
		private float behindCanvasBias;

		[SerializeField]
		private float defaultCanvasScale;

		[SerializeField]
		private float distanceThresholdMultiplier;

		private float MPFHPFDDBEH;

		private GCNOHCNBNGP GFHLGNGPOBF;

public GCNOHCNBNGP State
{
get 		{
			return GCNOHCNBNGP.ShowingCloseHideables;
		}

private set {
		}
}

		private void Awake()
		{
		}

		private void FKIHCIICKNN(float OKBAJEAPIHG)
		{
		}

		private void MGMJHLIMCKH(GCNOHCNBNGP HAPBFHNPHLL)
		{
		}
	}
}
