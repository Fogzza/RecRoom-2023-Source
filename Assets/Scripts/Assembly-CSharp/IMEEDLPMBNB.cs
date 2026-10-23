using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Delaunay;
using UnityEngine;

public class IMEEDLPMBNB
{
	[StructLayout((LayoutKind)3)]
	private struct AJFAGIIHOBG<VertexT, T> where VertexT : Vertex<T>
	{
		public List<int> triangleIndices;

		public Dictionary<int, int> uniqueFaces;
	}

	[StructLayout((LayoutKind)3)]
	private struct KCAFIFIDBPK
	{
		public bool discardDuplicateMeshTriangles;

		public Dictionary<int, int> uniqueTriangles;

		public List<int> triangleIndices;
	}

	private const int PBMPINNCNME = 128;

	[NonSerialized]
	private int JLHJGHEMOKP;

	public void OGMJLGKGKMG<VertexT, T>(ref List<VertexT> EBMLPFHDHMP, out List<Tetrahedron> HNILNOJEPOG, out List<int> AHFEOGECEIG) where VertexT : Vertex<T>
	{
		HNILNOJEPOG = null;
		AHFEOGECEIG = null;
	}

	public bool GFEMHPDPHHD<VertexT, T>(Vector3 PDFEDMAOMNH, List<VertexT> EBMLPFHDHMP, List<Tetrahedron> HNILNOJEPOG, List<int> AHFEOGECEIG, out int BKJNELOHEFE, out int GICHLMGCIFL, out int CJAPDPKPMOJ, out int BBGAMJLKELF) where VertexT : Vertex<T>
	{
		BKJNELOHEFE = default;
		GICHLMGCIFL = default;
		CJAPDPKPMOJ = default;
		BBGAMJLKELF = default;
		return false;
	}

	public void OGJIANLONPA(List<Vector3> ADOJMNEGEFL, MeshFilter OEEGFOOBBLH, bool JBLPMLNIBFI = true)
	{
	}

	public static bool KBABGDBBBHH(Vector3 NNMPJECKECI, Vector3 EFNJCAIBDLA, Vector3 DHNNLHJMKIH, Vector3 ENDFPEOPAIK)
	{
		return false;
	}

	public static bool PJCCGNMNHLN(Vector3 COLMAMKJPJE, Vector3 NNMPJECKECI, Vector3 EFNJCAIBDLA, Vector3 DHNNLHJMKIH)
	{
		return false;
	}

	public static bool JOJHOGLLOCI(Vector3 COLMAMKJPJE, Vector3 NNMPJECKECI, Vector3 EFNJCAIBDLA, Vector3 DHNNLHJMKIH)
	{
		return false;
	}

	private static float BOINEOPEIKK(Vector3 COLMAMKJPJE, Vector3 NNMPJECKECI, Vector3 EFNJCAIBDLA, Vector3 DHNNLHJMKIH)
	{
		return 0f;
	}

	public static void NCPPPDFPGMH(Vector3 NNMPJECKECI, Vector3 EFNJCAIBDLA, Vector3 DHNNLHJMKIH, Vector3 ENDFPEOPAIK, out Vector3 PLKCNIBDCDC, out float JKCPOCDOCFE)
	{
		PLKCNIBDCDC = default;
		JKCPOCDOCFE = default;
	}

	public static void KLOJPFNADEK(Vector3 NNMPJECKECI, Vector3 EFNJCAIBDLA, Vector3 DHNNLHJMKIH, Vector3 ENDFPEOPAIK)
	{
	}

	[CompilerGenerated]
	private static void HIJANOEALPL<VertexT, T>(int LCEGDMEIEHA, int MNCDCAAHFJH, int NIHHJFOAMEK, ref AJFAGIIHOBG<VertexT, T> P_3) where VertexT : Vertex<T>
	{
	}

	[CompilerGenerated]
	private static void CABICCFFIAA(Vector3 NNMPJECKECI, Vector3 EFNJCAIBDLA, Vector3 DHNNLHJMKIH, Vector3 ENDFPEOPAIK, int HMJHJACHINH, int DDKHHIMFMCJ, int OJPAOEIFFDE, int DBDHBLDHCFK, ref KCAFIFIDBPK P_8)
	{
	}

	[CompilerGenerated]
	private static void CJINEBNJPCC(int HMJHJACHINH, int DDKHHIMFMCJ, int OJPAOEIFFDE, ref KCAFIFIDBPK P_3)
	{
	}

	[CompilerGenerated]
	private static void FLHJDPAHPOI(int HMJHJACHINH, int DDKHHIMFMCJ, int OJPAOEIFFDE, int EAHCIFJKBHC, int DPHHOFIGLHA, int FDPGJHJHCNA, ref KCAFIFIDBPK P_6)
	{
	}
}
