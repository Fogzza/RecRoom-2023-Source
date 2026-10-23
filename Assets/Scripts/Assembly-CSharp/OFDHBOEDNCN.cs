using System.Collections.Generic;
using System.Diagnostics;

public class OFDHBOEDNCN
{
	public class IBJDLHEHILB
	{
		public readonly string PALADLMJNAK;

		private readonly Stopwatch LKKCBBBBCOG = new Stopwatch();

		private readonly double BPEIOENPJMD;

public bool EBAOLHKJMKN
{
get 		{
			return this.LKKCBBBBCOG.IsRunning;
	}

}

public double LCNOGEENGDJ
{
get 		{
			return this.LKKCBBBBCOG.Elapsed.TotalSeconds + this.BPEIOENPJMD;
	}

}

		public IBJDLHEHILB(string KNOPFGAGMCN, double BPEIOENPJMD)
		{
			this.PALADLMJNAK = KNOPFGAGMCN;
			this.BPEIOENPJMD = BPEIOENPJMD;
	}

		public void OJFIFFKKFLH()
		{
			this.LKKCBBBBCOG.Start();
	}

		public void IGPCOAEGHAL()
		{
			this.LKKCBBBBCOG.Stop();
	}
	}

	private bool NDHNIJHFIOI;

	private Dictionary<string, IBJDLHEHILB> OEGCIGPEFGP = new Dictionary<string, IBJDLHEHILB>();

	private List<IBJDLHEHILB> JAAGBDPDCIE = new List<IBJDLHEHILB>();

	private readonly string OFMGPNLDCAB;

public IReadOnlyCollection<IBJDLHEHILB> LLPFMHHPAAP
{
get 	{
		return this.JAAGBDPDCIE.AsReadOnly();
	}

}

public bool HFHGOOINLDP
{
get 	{
		return this.NDHNIJHFIOI;
	}

set {
		this.NDHNIJHFIOI = value;
	}
}

	public OFDHBOEDNCN(string OFMGPNLDCAB)
	{
		this.OFMGPNLDCAB = OFMGPNLDCAB;
	}

	public void OJFIFFKKFLH(string KNOPFGAGMCN, float BPEIOENPJMD = 0f)
	{
		if (this.OEGCIGPEFGP.ContainsKey(KNOPFGAGMCN))
		{
			PNAABCMOHGM.NEGCNMACIEM(string.Concat("Item already exists: ", KNOPFGAGMCN), new HJDBOADFHMC?(HJDBOADFHMC.KAAIIIEPCIA));
			return;
		}
		var item = new IBJDLHEHILB(KNOPFGAGMCN, (double)BPEIOENPJMD);
		this.JAAGBDPDCIE.Add(item);
		this.OEGCIGPEFGP.Add(KNOPFGAGMCN, item);
		item.OJFIFFKKFLH();
		if (this.NDHNIJHFIOI) { /* Original Windows profiling callee is RET0. */ }
	}

	public void FHBILIJBOGI(string KNOPFGAGMCN)
	{
		IBJDLHEHILB item;
		if (this.OEGCIGPEFGP.TryGetValue(KNOPFGAGMCN, out item))
		{
			item.IGPCOAEGHAL();
			return;
		}
		PNAABCMOHGM.NEGCNMACIEM(string.Concat("Item doesn't exist: ", KNOPFGAGMCN), new HJDBOADFHMC?(HJDBOADFHMC.KAAIIIEPCIA));
	}

	public void NOMPIEABHOP(string KNOPFGAGMCN)
	{
		IBJDLHEHILB item;
		if (this.OEGCIGPEFGP.TryGetValue(KNOPFGAGMCN, out item))
		{
			item.OJFIFFKKFLH();
			return;
		}
		PNAABCMOHGM.NEGCNMACIEM(string.Concat("Item doesn't exist: ", KNOPFGAGMCN), new HJDBOADFHMC?(HJDBOADFHMC.KAAIIIEPCIA));
	}

	public void IGPCOAEGHAL(string KNOPFGAGMCN)
	{
		IBJDLHEHILB item;
		if (this.OEGCIGPEFGP.TryGetValue(KNOPFGAGMCN, out item))
		{
			item.IGPCOAEGHAL();
			this.OEGCIGPEFGP.Remove(KNOPFGAGMCN);
			if (this.NDHNIJHFIOI) { /* Original Windows profiling callee is RET0. */ }
			return;
		}
		PNAABCMOHGM.NEGCNMACIEM(string.Concat("Item doesn't exist: ", KNOPFGAGMCN), new HJDBOADFHMC?(HJDBOADFHMC.KAAIIIEPCIA));
	}

	public void ILBACJJBKKJ()
	{
		foreach (IBJDLHEHILB item in this.JAAGBDPDCIE)
		{
			if (item.EBAOLHKJMKN) item.IGPCOAEGHAL();
		}
		if (this.NDHNIJHFIOI) { /* Original Windows profiling callee is RET0. */ }
	}

	public void FPNMONCCAAE()
	{
		var text = new System.Text.StringBuilder();
		text.AppendLine(string.Concat("PerfClock: ", this.OFMGPNLDCAB));
		foreach (IBJDLHEHILB item in this.JAAGBDPDCIE)
		{
			string name = item.PALADLMJNAK;
			double seconds = item.LCNOGEENGDJ;
			text.AppendLine(string.Concat(name, ": ", seconds.ToString(), "s"));
		}
		PNAABCMOHGM.FPNMONCCAAE(text.ToString(), new HJDBOADFHMC?(HJDBOADFHMC.KAAIIIEPCIA));
	}
}
