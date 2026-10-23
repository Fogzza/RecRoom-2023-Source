using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

public class KNBDGFKMGCP
{
	public enum NJGEEBKEJOH : uint
	{
		Success = 0u,
		ProviderUnknown = 2148204545u,
		ActionUnknown = 2148204546u,
		SubjectFormUnknown = 2148204547u,
		SubjectNotTrusted = 2148204548u,
		FileNotSigned = 2148204800u,
		SubjectExplicitlyDistrusted = 2148204817u,
		SignatureOrFileCorrupt = 2148098064u,
		SubjectCertExpired = 2148204801u,
		SubjectCertificateRevoked = 2148204812u,
		UntrustedRoot = 2148204809u
	}

	[StructLayout((LayoutKind)0, CharSet = CharSet.Unicode)]
	private class JNLLBLJBGBA : IDisposable
	{
		private uint GPDOFBGLJDP;

		private IntPtr NEPICPFBGMC;

		private IntPtr DKHBLLBEAIF;

		private IntPtr HNLLLGDKFGH;

		public JNLLBLJBGBA(string BNNNNJOGGCJ)
		{
		}

		public void Dispose()
		{
		}
	}

	[StructLayout((LayoutKind)0, CharSet = CharSet.Unicode)]
	private class KLCNJEMBCIG : IDisposable
	{
		private uint GPDOFBGLJDP;

		private IntPtr NCAKOLNPGGN;

		private IntPtr BGBCDJJADNO;

		private uint BCLJBHIEPII;

		private uint MBEFPDAOFLJ;

		private uint MBIKMDLAHGH;

		private IntPtr LPBFPOHLMEK;

		private uint MECNAFPOJGD;

		private IntPtr MKPDGKLEGNM;

		private string AIJFFOOAIJK;

		private uint EFNANIODNON;

		private uint GHMKLJBKMHD;

		public KLCNJEMBCIG(JNLLBLJBGBA MLPFPBACLKL)
		{
		}

		public KLCNJEMBCIG(KGOGPOONAKC PHJNNELKHHN)
		{
		}

		public void Dispose()
		{
		}
	}

	[StructLayout((LayoutKind)0)]
	public class KGOGPOONAKC : IDisposable
	{
		public uint OOFCELCDPAN;

		public uint DBDEKDJABBB;

		public IntPtr LMEFMKBNOKO;

		public IntPtr NDJAPOIHHJD;

		public IntPtr KECNPGCOGKG;

		public IntPtr JENJPAJLCDJ;

		public IntPtr FHGHMJECMII;

		public uint FOFNFHDKGIF;

		public IntPtr NHLBECPBOOJ;

		public IntPtr JIBDLDCMPBK;

		public KGOGPOONAKC(string BFNIABAGHEG, IntPtr COPNLCENIGE, IntPtr NDFMMDHCKFC, uint OLIGJMFEFMG)
		{
		}

		public void Dispose()
		{
		}
	}

	public delegate void AOFOBEKFHCF(string NPKOMACBEIC, string DCEGKFAGGEK, NJGEEBKEJOH CIEAPDLHMGN);

	private sealed class KNOOGBBMHCA
	{
		public string driverPath;

		public byte[] managedArray;

		public NJGEEBKEJOH result;

		public KNBDGFKMGCP _003C_003E4__this;

		internal void _003CScanForUnsignedDrivers_003Eb__0()
		{
		}
	}

	private static readonly IntPtr GKKCFJEMJGP;

	private const string BLJMHGLKCNP = "{00AAC56B-CD44-11d0-8CC2-00C04FC295EE}";

	private const string IBMJAGOBBOC = "{F750E6C3-38EE-11d1-85E5-00C04FC295EE}";

	private const int BFOBINPNGEA = 64;

	private const int DPGEGALBMIC = 1024;

	private static KNBDGFKMGCP EGAIHCNFOEN;

	private AOFOBEKFHCF ONAFALABHKI;

	private long[] LGFIHECNAED;

	private Thread KNMILELNMFH;

	private CancellationTokenSource FFLGFKMIOID;

public static KNBDGFKMGCP OFDKPDDLIJC
{
get 	{
		return null;
	}

private set {
	}
}

	[PreserveSig]
	private static extern bool AAEPLCHCEAK(long[] JHPDGBDKNFA, uint MOCHNIJHKBN, out uint KAHKMFGAHLC);

	[PreserveSig]
	private static extern int BKNOABHHMAL(long NPHEHNJCAON, [Out] StringBuilder KDFHPAHDPGK, uint MHAKGEELGAF);

	[PreserveSig]
	private static extern IntPtr ICFKLLKJOHP([In] string NPKOMACBEIC, uint CCPOLKGGNHA, uint JAFEGNNPHDM, IntPtr IEIFCHIHIIC, uint BLDKHJEAHLB, uint NMLBFMIDFGI, IntPtr EFJDILBAEKM);

	[PreserveSig]
	private static extern bool OJKMEAFDDFK([In] IntPtr OEMKMFONAHG);

	[PreserveSig]
	private static extern bool EDECBLLDBIJ(IntPtr DKHBLLBEAIF, ref uint MFJOIBMEFIC, IntPtr NHKPGCHCHKH, uint IAGOPBEKMDG = 0u);

	[PreserveSig]
	private static extern bool AMHABMJENHE(out IntPtr JAGBGPFBFKN, in Guid OAEKKOOOONK, uint IAGOPBEKMDG = 0u);

	[PreserveSig]
	private static extern IntPtr NGLOBCDKBAK(IntPtr JIBDLDCMPBK, IntPtr NHKPGCHCHKH, uint JFFMGIOEFMH, [Optional] uint IAGOPBEKMDG, ref IntPtr LLMBCIGMAPI);

	[PreserveSig]
	private static extern bool LFFOAFEJFDB(IntPtr KDJNGKNKFDH, IntPtr KMGHFPNBNPB, uint IAGOPBEKMDG = 0u);

	[PreserveSig]
	private static extern bool AHDFHJDLAPO(IntPtr JIBDLDCMPBK, IntPtr KDJNGKNKFDH, uint IAGOPBEKMDG = 0u);

	[PreserveSig]
	private static extern bool CPLDBNBDJIE(IntPtr JIBDLDCMPBK, uint IAGOPBEKMDG = 0u);

	[PreserveSig]
	private static extern NJGEEBKEJOH DLHPCKIHJKB([In] IntPtr HOMDJOPMGNA, [In] Guid DJBLOKINDLH, [In] KLCNJEMBCIG IKPIBKOHGFN);

	static KNBDGFKMGCP()
	{
	}

	public void IHEKMEOIBOI(AOFOBEKFHCF FMBJCMIJNBM)
	{
	}

	private void COBOLGBMDGE()
	{
	}

	private void HJEJONDDOGE()
	{
	}

	private void AFIBHNBDDHP()
	{
	}
}
