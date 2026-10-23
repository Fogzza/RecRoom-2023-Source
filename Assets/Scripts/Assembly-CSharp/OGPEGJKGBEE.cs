using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;

public class OGPEGJKGBEE
{
	private abstract class DGIDIDOOCNO
	{
		public float LDGLFPIJPCE;

		private readonly int CNOLPIFAMGC;

		private bool MPKLEANOFEG;

		protected RecRoomAudioClip PLCJAPIHKHN;

		protected bool FODAGELEEBM;

		protected bool LCIPFMLCGFN;

		protected OGPEGJKGBEE PHHEGDAFFNC;

		protected bool PDJHPHIKODJ;

		protected bool NKLGILDLDHG;

		protected bool ADMMEJAKCJG;

		protected float MPONMIJJJIF;

		protected float HDGFHFCPNPD;

public int LDHIBGALEDK
{
get 		{
			return 0;
		}

}

public abstract bool PFDCMICECFJ
{
get ;
}

public bool OODAJPNJAOC
{
get 		{
			return false;
		}

private set {
		}
}

public bool PKCKOBAJOCG
{
get 		{
			return false;
		}

}

public bool JMPPEEGGKCI
{
get 		{
			return false;
		}

}

		public DGIDIDOOCNO(int LAGADKBKLAD, OGPEGJKGBEE PHHEGDAFFNC, bool PDJHPHIKODJ, bool NKLGILDLDHG, bool ADMMEJAKCJG)
		{
			this.PHHEGDAFFNC = PHHEGDAFFNC;
			this.MPKLEANOFEG = false;
			this.MPONMIJJJIF = 0f;
			this.CNOLPIFAMGC = LAGADKBKLAD;
			this.NKLGILDLDHG = NKLGILDLDHG;
			this.PDJHPHIKODJ = PDJHPHIKODJ;
			this.ADMMEJAKCJG = ADMMEJAKCJG;
		}

		public void LOKFMEJHKAO()
		{
		}

		public void JNBCCJJGDLO()
		{
		}

		public void NOIOGEDNFDJ()
		{
		}

		public void FHBILIJBOGI()
		{
		}

		public void ILDDJKOCGGA()
		{
		}

		public virtual void CDJHKCNAIKI()
		{
		}

		protected abstract void KJGBLNAKENC();

		protected void KLKPLMIDMLI()
		{
		}

		private void NLILPPLIKLN(float FKFKDGPEKNI)
		{
		}
	}

	private class FMNGEALLGDG : DGIDIDOOCNO
	{
		private global::MKJNCDLHHNA<RecRoomAudioClip> ALHAJOOMJFP = new global::MKJNCDLHHNA<RecRoomAudioClip>();

public override bool PFDCMICECFJ
{
get 		{
			return false;
		}

}

		public FMNGEALLGDG(int LAGADKBKLAD, OGPEGJKGBEE PHHEGDAFFNC, bool PDJHPHIKODJ, bool NKLGILDLDHG, bool ADMMEJAKCJG) : base(LAGADKBKLAD, PHHEGDAFFNC, PDJHPHIKODJ, NKLGILDLDHG, ADMMEJAKCJG)
		{
		}

		public void LBJIHBPMAKP(RecRoomAudioClip LOHCKBEDAKF, object IALNODEHBNN)
		{
		}

		public void KDKJKGOCGKO(object IALNODEHBNN)
		{
		}

		protected override void KJGBLNAKENC()
		{
		}
	}

	private class EBHJNODLNLB : DGIDIDOOCNO
	{
		private global::MKJNCDLHHNA<ExtendedRecRoomAudioClips> ALHAJOOMJFP = new global::MKJNCDLHHNA<ExtendedRecRoomAudioClips>();

public override bool PFDCMICECFJ
{
get 		{
			return false;
		}

}

		public EBHJNODLNLB(int LAGADKBKLAD, OGPEGJKGBEE PHHEGDAFFNC, bool NKLGILDLDHG, bool ADMMEJAKCJG) : base(LAGADKBKLAD, PHHEGDAFFNC, true, NKLGILDLDHG, ADMMEJAKCJG)
		{
		}

		public void LBJIHBPMAKP(ExtendedRecRoomAudioClips LOHCKBEDAKF, object IALNODEHBNN)
		{
		}

		public void KDKJKGOCGKO(object IALNODEHBNN)
		{
		}

		public override void CDJHKCNAIKI()
		{
		}

		protected override void KJGBLNAKENC()
		{
		}
	}

	private sealed class APAIDECEAEL : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public float previousTrackFadeoutDuration;

		public RecRoomAudioClip newTrack;

		public float scrubTime;

		public bool newTrackLoops;

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
		public APAIDECEAEL(int _003C_003E1__state)
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

	private LKGILLBEJEK BJDAJGPJBKE;

	private List<DGIDIDOOCNO> JJOLLMOOLPD;

	private FMNGEALLGDG OCFPNAKBNEL;

	private EBHJNODLNLB GLLEDHDGHDC;

	private FMNGEALLGDG PPGBGHDHMOE;

	private FMNGEALLGDG GMOIPCJEJLM;

	private FMNGEALLGDG KFLAMAHMOCA;

	private FMNGEALLGDG AMEIDEGLEGJ;

	public void CDJHKCNAIKI()
	{
	}

	public void OCLKLKCICHF(RecRoomAudioClip DLMNMOFOKJE, object IALNODEHBNN)
	{
	}

	public void CBMPLCIJGBM(object IALNODEHBNN)
	{
	}

	public void JHAJLGBHDKB()
	{
	}

	public void DMJHIHEHNDI()
	{
	}

	public void EGICBFHBCIP(RecRoomAudioClip PLMHEDCEOLJ, object IALNODEHBNN)
	{
	}

	public void NBICOKEHHNA(object IALNODEHBNN)
	{
	}

	public void IMHJKPEDOGC()
	{
	}

	public void FFAKEPNKBBA()
	{
	}

	public void FLMECCPCGOK(ExtendedRecRoomAudioClips FOPPKEDBILB, object IALNODEHBNN)
	{
	}

	public void NPDHAHHMIMM(object IALNODEHBNN)
	{
	}

	public void KALDPOCOCHL()
	{
	}

	public void LKFEELGCGPC()
	{
	}

	public void PHBBEMMOFJB(RecRoomAudioClip INNHKDPENGJ, object IALNODEHBNN)
	{
	}

	public void DANJHNABFLI(object IALNODEHBNN)
	{
	}

	public void MNIBIMIFLEM()
	{
	}

	public void NNABKCLJIAN()
	{
	}

	public void DLOAFOEFHOL(RecRoomAudioClip HCMJCLDPJAM, object IALNODEHBNN)
	{
	}

	public void JDMKKKPLHBL(object IALNODEHBNN)
	{
	}

	public void INLFOGOJNKI()
	{
	}

	public void HLMAPIDIOJN()
	{
	}

	public void KLONHIOFINL(RecRoomAudioClip FCFBNONJHBH, object IALNODEHBNN)
	{
	}

	public void BFCCLHOOPLA(object IALNODEHBNN)
	{
	}

	public void BNDBEEIHCLL()
	{
	}

	public void GHFIAPAGGDE()
	{
	}

	public void LAIIOFJCJDG()
	{
	}

	public void PIOHBJKBAIF(float ENIIFDEFCGG)
	{
	}

	public void GEBAHNGCBEN(float ENIIFDEFCGG)
	{
	}

	public void BEKEEOMGLGP(float ENIIFDEFCGG)
	{
	}

	private void MIKCHMMPPBG(RecRoomAudioClip LFJIFGPOJCB, bool JJIHGDDEEIK, float MPONMIJJJIF, float AMNDGLDIENL)
	{
	}

	private void PFOPPNPDJFM()
	{
	}

	private IEnumerator<EGGPGCCKPCO> FINANGLPNLP(RecRoomAudioClip LFJIFGPOJCB, bool JJIHGDDEEIK, float MPONMIJJJIF, float AMNDGLDIENL)
	{
		return null;
	}

	internal void BNPIMFMBMMO(RecRoomAudioClip IKHLHJGMNGO, bool JJIHGDDEEIK, float AMNDGLDIENL)
	{
	}

	internal void BNPIMFMBMMO(RecRoomAudioClip IKHLHJGMNGO, bool JJIHGDDEEIK, float MPONMIJJJIF, float AMNDGLDIENL)
	{
	}

	private void LLAKAHPGJOH(float LFJNMLGJBFD)
	{
	}

	private void BGPOJLGIEDJ(DGIDIDOOCNO AKGANGPHNBK, bool LMJEMENNMFL = false)
	{
	}

	private void JMGGELAMLCK(DGIDIDOOCNO AKGANGPHNBK)
	{
	}

	private void ILBLNAALOBL()
	{
	}
}
