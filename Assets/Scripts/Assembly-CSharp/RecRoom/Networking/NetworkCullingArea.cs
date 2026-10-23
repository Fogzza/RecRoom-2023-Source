using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Networking
{
	public class NetworkCullingArea : SingletonMonoBehaviour<NetworkCullingArea>, KJPEOPLMDMF
	{
		public enum NJEIMFKBBEG
		{
			Global = 0,
			Low = 1,
			High = 2
		}

		public const int MAX_CELL_INDEX = 250;

		public const int MAX_CELL_COUNT = 249;

		public const byte FIRST_GROUP_ID = 1;

		public readonly int[] SUBDIVISION_FIRST_LEVEL_ORDER;

		public readonly int[] SUBDIVISION_SECOND_LEVEL_ORDER;

		public readonly int[] SUBDIVISION_THIRD_LEVEL_ORDER;

		private const double OKAPBNKENHF = 0.0001;

		public ICENLMEELBA.LMNBKADDPDK VisualizationType;

		private InterestGroupMember AMLLGKONKMC;

		private List<InterestGroupMember> GHBPHGBDOKN;

		public float MinimumCellSize;

		public bool UpdateDynamically;

		public float DynamicUpdateFrequency;

		public int NumberOfSubdivisions;

		private int FMBEJEAGPOP;

		private GLPBGPCBBCO JJKIGFGPEPI;

		public Vector2[] Subdivisions;

		private Bounds GJIMLIEDOMF;

		private IDisposable CKFAHBNEKNH;

public InterestGroupMember InterestGroupManager
{
get 		{
			return null;
		}

set {
		}
}

public List<InterestGroupMember> InterestGroupMembers
{
get 		{
			return null;
		}

private set {
		}
}

public bool CullingEnabled
{
get 		{
			return false;
		}

}

public int CellCount
{
get 		{
			return 0;
		}

private set {
		}
}

public GLPBGPCBBCO CellTree
{
get 		{
			return null;
		}

private set {
		}
}

		protected void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void OnDrawGizmos()
		{
		}

		public NJEIMFKBBEG GetInterestRegion(Vector3 INLGLHIPOMC)
		{
			return NJEIMFKBBEG.Global;
		}

		public void GetNearbyCells(Vector3 INLGLHIPOMC, float PNKOGPFDBHL, float EDKANNBNEEJ, ref List<byte> ILJGHKGMILC)
		{
		}

		public void GetExactCells(Vector3 INLGLHIPOMC, List<byte> ILJGHKGMILC)
		{
		}

		public byte GetGroup(ref int FGKIDCPFEDO, List<byte> GMIDPICKIDL)
		{
			return 0;
		}

		public bool IsInHighInterestRegion(Vector3 INLGLHIPOMC)
		{
			return false;
		}

		public void RecomputeCullingAreaBounds(float OKBAJEAPIHG)
		{
		}

		private Vector2 AEABCONBMLJ()
		{
			return default;
		}

		private bool JHBLNJJFGID()
		{
			return false;
		}
	}
}
