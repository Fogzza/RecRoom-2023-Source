using System;
using RecRoom.Core;
using RecRoom.Tools;
using UnityEngine;

public abstract class NENLBKDEKAE : IDisposable
{
	private bool IMGGIDAGJFN;

	private bool NJEFAGGFKBN;

public abstract Bounds LJGAEEGLFMO
{
get ;
}

public abstract Quaternion BFFEBCMOFHH
{
get ;
}

public abstract float EAFCCNDHBHA
{
get ;
}

public virtual bool MBCICKHLOIJ
{
get 	{
		return false;
	}

}

public virtual bool EBLHIJBCNPL
{
get 	{
		return false;
	}

}

public virtual bool IJOAMNGJIIB
{
get 	{
		return false;
	}

set {
	}
}

public bool JEPFHLKFGHO
{
get 	{
		return false;
	}

set {
	}
}

	protected NENLBKDEKAE(MakerPen BHCCDMJFHEO)
	{
	}

	public virtual void Dispose()
	{
	}

	public abstract LAHBDKNMNHN CCGLPNCJJMM(CreationController IJIAEDONGKE, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH);

	public abstract GJEAOEFGMJC DCHMAEHJMMD(CreationController IJIAEDONGKE, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH);

	public virtual void EFPNKMBLAPD(CreationController IJIAEDONGKE)
	{
	}

	public virtual void FJBCCJNFIEG(CreationController IJIAEDONGKE, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
	{
	}

	public virtual void MEBNEHKPHKE()
	{
	}

	public virtual void IDKOCHNDCMM(CreationController IJIAEDONGKE, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 CENMOCLLNLB)
	{
	}

	public abstract void NGNONKNDGGK(CreationController IJIAEDONGKE, Ray KJGMGHOAEMP, RaycastHit KNFIEECFHPI, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH);

	public virtual bool CACIJLCFLGM(Ray HAAAJDJGEFF, out RaycastHit KNFIEECFHPI)
	{
		KNFIEECFHPI = default;
		return false;
	}

	public void FAFNDFDEPGJ(CreationController IJIAEDONGKE, Ray KJGMGHOAEMP, RaycastHit KNFIEECFHPI, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH)
	{
		INLGLHIPOMC = default;
		HEGBBJCMANH = default;
	}

	public virtual Quaternion MKKKCJMGKND(MakerPen BHCCDMJFHEO, Quaternion HEGBBJCMANH)
	{
		return default;
	}

	public virtual Vector3 BMPJOMKJCHC(MakerPen BHCCDMJFHEO, Vector3 INLGLHIPOMC)
	{
		return default;
	}
}
