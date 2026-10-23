using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class IOCPDIHFMFC
{
	[Flags]
	public enum IOOCNDBCNAB
	{
		None = 0,
		Began = 1,
		Moved = 2,
		Stationary = 4,
		Ended = 8,
		Canceled = 0x10,
		AnyActive = Began | Moved | Stationary
	}

	public delegate bool JIHIHFJJFOI(IOCPDIHFMFC CMIBPIHCNDH, Touch DCBELOGCCHD);

	private Rect GIJGAFNNOCK;

	private PNHHOJKFPON EEKDGBNBIKC;

	protected BBCKAEEHGMB INNNPEHODNN;

	protected List<Touch> IIJIOEBGHBM;

	private readonly List<IOCPDIHFMFC> EIEKCCDPPHN;

	private JIHIHFJJFOI KGHDFLBMNBL;

	private bool OHAEIBKKBGI;

	private readonly int CNOLPIFAMGC;

	private readonly bool MBNEHOJEEOA;

	[NonSerialized]
	public bool OKNMIKICIOB;

public IReadOnlyList<IOCPDIHFMFC> PJLLFLCHEKI
{
get 	{
		return null;
	}

}

public JIHIHFJJFOI PJBMACDDIBG
{
get 	{
		return null;
	}

set {
	}
}

public bool PGGFKGFJBNI
{
get 	{
		return false;
	}

set {
	}
}

public int LDHIBGALEDK
{
get 	{
		return 0;
	}

}

public bool OMHLAFDCLKI
{
get 	{
		return false;
	}

}

public abstract bool LIMEGDGKGGP
{
get ;
}

	public IOCPDIHFMFC(int LAGADKBKLAD, bool LKPFELINEDJ)
	{
	}

	public void NMGNDHMANAF(Vector2 PBBHLBBOJDN, Vector2 ENBHIPKCFKI, PNHHOJKFPON NBGOLMPJOHO = PNHHOJKFPON.RECT)
	{
	}

	public void OINOHNIGFDJ(Vector2 AELOJCNDNDH, Vector2 ENBHIPKCFKI, PNHHOJKFPON NBGOLMPJOHO = PNHHOJKFPON.RECT)
	{
	}

	private void FJILGFBMKPK(Vector2 BKEIHNKJPAG, Vector2 NMIJNEPBNIL, PNHHOJKFPON NBGOLMPJOHO)
	{
	}

	public void CDJHKCNAIKI(List<Touch> LFADFDBFOMJ, BBCKAEEHGMB MLGKPDLOMDO)
	{
	}

	public void LBDLDNPFOHP()
	{
	}

	protected abstract void EHMICKMBCPH();

	public void AALJKNMAKDL(IOCPDIHFMFC DBEHCHMJJJH)
	{
	}

	public void INDNCNKNBHH(IOCPDIHFMFC DBEHCHMJJJH)
	{
	}

	private void LEBMEAHAAML(IOCPDIHFMFC DBEHCHMJJJH)
	{
	}

	private void HPMNNBCPJOF(IOCPDIHFMFC DBEHCHMJJJH)
	{
	}

	public bool BOOLBLHLPIK(int LCCANPEBOHN)
	{
		return false;
	}

	protected bool AFCEKJELNJE(int LCCANPEBOHN)
	{
		return false;
	}

	protected bool ECGCMJNNNNO(int LCCANPEBOHN)
	{
		return false;
	}

	protected void OFMMDAGDCCA(int LCCANPEBOHN)
	{
	}

	protected bool DIIPOBPNNME(Touch DCBELOGCCHD, IOOCNDBCNAB FKOBEDAMGOK)
	{
		return false;
	}

	private IOOCNDBCNAB PFDIPINANDL(TouchPhase MGADLDPDPGK)
	{
		return IOOCNDBCNAB.None;
	}

	protected bool NPJGCDLHNIJ(int LCCANPEBOHN, out Touch DCBELOGCCHD)
	{
		DCBELOGCCHD = default;
		return false;
	}

	public bool FINOAGEOOEI(Touch DCBELOGCCHD)
	{
		return false;
	}

	public bool KPABCAGLNGL(Vector2 OFMPGDMPNLK)
	{
		return false;
	}

	private bool OCPHBGGOGPG(Vector2 OFMPGDMPNLK)
	{
		return false;
	}

	public bool JDGCFLBMEBF(Vector2 OFMPGDMPNLK)
	{
		return false;
	}

	public static Vector2 BJHMAKCLHCF(Vector2 BFPEPKAPNPG)
	{
		return default;
	}

	public static Vector2 JLBLDPJHJAJ(Vector2 AGHHPABLOOC)
	{
		return default;
	}

	protected Vector2 MOODLLNHOLP(Vector2 BFPEPKAPNPG)
	{
		return default;
	}

	protected Vector2 CIBEFBJKDLL(Vector2 AGHHPABLOOC)
	{
		return default;
	}

	protected Vector2 JAPKAHNKIEL(Vector2 KCPGDFHOHLH)
	{
		return default;
	}

	protected float BJNDKCBDOJG(float GABNCKGIEBH)
	{
		return 0f;
	}

	protected float COEBJNDFACF(float IFPCKEDEPPB)
	{
		return 0f;
	}

	protected float JHENDBGAGAH(in Touch DCBELOGCCHD)
	{
		return 0f;
	}
}
