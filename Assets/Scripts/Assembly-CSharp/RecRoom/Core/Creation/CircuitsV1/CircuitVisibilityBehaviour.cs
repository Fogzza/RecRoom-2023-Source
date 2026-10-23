using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public abstract class CircuitVisibilityBehaviour : MonoBehaviour
	{
		private static List<CircuitVisibilityBehaviour> KKKDICCFPHB;

		private static readonly FIHGBEHGLGB BBBNPJOEDJB;

		private NNBAJLCGAOK JGEGKOOCOEH;

		[SerializeField]
		private bool preventNavMeshGeneration;

		[SerializeField]
		private CreationObject creationObject;

		[SerializeField]
		private bool observesScope;

		private static bool PBICJCCCDOH;

		private bool DEJMDOODBPK;

		private bool PFBONBKCNIG;

protected CreationObject JIOFMOMHIAA
{
get 		{
			return null;
		}

}

private DHJLEHBOGBG NLHNGNDKONI
{
get 		{
			return null;
		}

}

public static bool HideForLocalPlayer
{
get 		{
			return false;
		}

set {
		}
}

public bool ForceDisabled
{
get 		{
			return false;
		}

set {
		}
}

protected static bool OMBMGHPCCDG
{
get 		{
			return false;
		}

}

protected virtual bool HIKOFBKIJOM
{
get 		{
			return false;
		}

}

		public static bool ShouldBeVisible(NNBAJLCGAOK JGEGKOOCOEH)
		{
			return false;
		}

		public static bool HasPlayerAllowedGadgetVisibilityWithoutMakerPen(NNBAJLCGAOK JGEGKOOCOEH)
		{
			return false;
		}

		public static void CircuitVisibilityChanged()
		{
		}

		public static void AddForceShowGadgetToken(Object IALNODEHBNN)
		{
		}

		public static void RemoveForceShowGadgetToken(Object IALNODEHBNN)
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		private void OnEnable()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected void AHABDCHNEAE()
		{
		}

		protected abstract void AHABDCHNEAE(bool GMEKKCPLMOB);

		private OBIIECHNFJK KMNDAGHAGDM()
		{
			return OBIIECHNFJK.NotSupported;
		}

		private static bool JDIHCMMFHDC()
		{
			return false;
		}
	}
}
