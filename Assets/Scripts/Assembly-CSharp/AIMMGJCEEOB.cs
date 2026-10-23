using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIMMGJCEEOB<T> where T : class
{
	private struct CEHANGPFPDD
	{
		public T EGJKFMADELN;

		public Collider LNDKNKKNELC;
	}

	private BoxCollider BLGLFADIAJA;

	private Collider[] KHJMPEJCDKB;

	private HashSet<Collider> OBDJGHAHLOJ;

	public readonly Dictionary<T, List<Collider>> EPPMKEIDAEM;

	private List<CEHANGPFPDD> MBKELLMCHMH;

public int BGLHIKDHFFB
{
get 	{
		return 0;
	}

}

	public virtual void LJODMHLJPAD()
	{
	}

	public void DIHCJNJFOLB(BoxCollider ADMCDJKKCIA)
	{
	}

	public virtual bool LPCAFKJBOJH(Collider OMHJPAGFCMF, out T LKNLAAADBIK)
	{
		LKNLAAADBIK = null;
		return false;
	}

	public bool KJIIOMIMAGL(T FDAIMOMOHIG, Collider MPHJAGGPFED, out T DOLLBDGHNOA)
	{
		DOLLBDGHNOA = null;
		return false;
	}

	public virtual bool ONCKGNONFKI(Collider HCMLLICFMJE, out T DOLLBDGHNOA)
	{
		DOLLBDGHNOA = null;
		return false;
	}

	private bool ONCKGNONFKI(T FDAIMOMOHIG, Collider HCMLLICFMJE, out T DOLLBDGHNOA)
	{
		DOLLBDGHNOA = null;
		return false;
	}

	public bool LODNKOHJEBA(List<T> OBBJACNCNJD)
	{
		return false;
	}

	public virtual bool GBDGICMKPDP(T FDAIMOMOHIG)
	{
		return false;
	}

	public bool HMPGIJADBEJ(T FDAIMOMOHIG)
	{
		return false;
	}

	public virtual void NIPELDKGPDM(Action<T> OKMLMKPLCAG)
	{
	}

	protected abstract bool COPFDIDLDFB(Collider ADMCDJKKCIA, out T FKKDDNPADEJ);
}
