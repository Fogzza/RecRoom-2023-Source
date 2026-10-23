using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public abstract class DLIGKBDDNGN : MHKKPILDOGG, FNBHOCNOPGG
{
	private enum KHKOOKFMJKA
	{
		Unresolved = 0,
		Resolving = 1,
		Resolved = 2
	}

	private sealed class MCIEONKAPAN : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public bool force;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public MCIEONKAPAN(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
		{
			return null;
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private Action OIIOAJIONLL__BackingField;

	private Action<bool, string> ELDAJPOHFNP__BackingField;

	private Action DOAKMIDHEAI__BackingField;

	private Action CBMFDFHPCNJ__BackingField;

	private KHKOOKFMJKA DADHJJNJEFA;

	private bool ACBJDPGMBGA;

	private bool IBABHMOIOHG;

protected bool CLIFCOHLAMJ
{
get 	{
		return false;
	}

}

public abstract NHNKJMHGBBG MMMENNAAGAA
{
get ;
}

public bool FKPPMBLKFMO
{
get 	{
		return false;
	}

private set {
	}
}

public bool ACHNAADKDNH
{
get 	{
		return false;
	}

private set {
	}
}

 event Action global::MHKKPILDOGG.OIIOAJIONLL {
add {
	}
remove {
	}
}

 event Action<bool, string> global::MHKKPILDOGG.ELDAJPOHFNP {
add {
	}
remove {
	}
}

 event Action global::MHKKPILDOGG.DOAKMIDHEAI {
add {
	}
remove {
	}
}

 event Action global::FNBHOCNOPGG.CBMFDFHPCNJ {
add {
	}
remove {
	}
}

	public abstract void OJFIFFKKFLH();

	public abstract bool HFNBAGHABFO(long EPOBIFCHLNM, bool OBLINLFBJLP, bool DJKGPICBKBI);

	public abstract bool AOBGCIGADMA();

	public virtual bool DBIMJHINCOG()
	{
		return false;
	}

	public abstract global::NCOKFFGPIJM<FKCGPAFDHIN> FJKLOFAADGM();

	public abstract global::NCOKFFGPIJM<NBGHEOAONCI> HBKNCMEKIML();

	public abstract LAHBDKNMNHN COLOOIHOFKJ();

	public abstract void KKDAPOGKDBH();

	public abstract string JHKNNGKOKEJ();

	public abstract string DGJFBGFGGIG();

	public abstract BootSequence.NJIJPADHPEC PAGOIHDMGIM();

	public void OGOJCFOJILM()
	{
	}

	protected void NPHLDODKAOO()
	{
	}

	protected void IBOAFOPAJKI(bool EGJEBAFNALL, string PCBDCKBIDPC = null)
	{
	}

	protected void PACMNJLMECF()
	{
	}

	protected void LLCDLBKBIEF()
	{
	}

	protected void JHGABJGDAHB()
	{
	}

	protected IEnumerator<EGGPGCCKPCO> AENBIEFBBMP(bool COPOILGLIAJ)
	{
		return null;
	}
}
