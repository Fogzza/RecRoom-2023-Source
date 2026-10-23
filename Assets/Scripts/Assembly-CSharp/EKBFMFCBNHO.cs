using RecRoom;
using UnityEngine;

public class EKBFMFCBNHO
{
	public enum DHBDCBHOHHJ
	{
		INVALID = 0,
		STATIONARY = 1,
		TELEPORT = 2,
		STAND = 3,
		CROUCH = 4,
		PRONE = 5,
		SPRINT = 6,
		SLIDE = 7,
		AUTOMATIC_WALL_CLIMB = 8,
		MANUAL_WALL_CLIMB = 9,
		FLY = 10,
		PAUSE = 11,
		PAUSE_CROUCH = 12,
		PAUSE_PRONE = 13,
		PAUSE_STATIONARY = 14,
		PAUSE_FLY = 15,
		FREEZE = 16,
		SIT = 17
	}

	public enum CNEPFNGCGHH
	{
		INVALID = 0,
		GROUND = 1,
		FALL = 2,
		CLAMBER = 3,
		WALL_RUN = 4,
		INITIALIZE = 5,
		ONGOING = 6
	}

	private struct ENHHHAEPAKJ
	{
		public RigidbodyEx HHFDFFDPCGO;

		public Vector3 KLMPOMAKNFL;

		public Vector3 JBFIOKLDODK;

		public bool FFNKPDNKBLO;

		public bool MAIEKELLCOE;

		public bool NJILOFCLDOP;

		public bool EDCMOHDOPPH;

		public FCANHOEFNGD ENMDLHBFEIE;

		public bool BJJNAIIDIEO;

		public bool BMPEKJKMBNE;

		public bool AFNFNKDFGNK;

		public bool CAPCOMJPHHM;

		public bool CCKKHDPNKNF;

		public bool PJFLGPGMJPF;

		public bool BOLPODMABDP;

		public bool DEMFDAMKICM;

		public bool IEIKIIAIJNG;

		public bool MBNAPOCLFEE;

		public bool AJJFEGALDMG;

		public bool GADMCPJPBEP;

		public bool NAKLLGKCNNO;

		public bool HJEIOHOKFEM;
	}

	private const float IAHJJLBIAHC = 0.01f;

	private const float CPKKAODHJOD = 0.0001f;

	private const float EEIIFACCGNH = 0.1f;

	private const float FDPHNJIDEJI = 0.010000001f;

	public const float BNLECLOIFHI = 0.5f;

	private const float PPBNNHOJOMD = 0.001f;

	private const float IDDIEPEOPEF = 0.15f;

	private MDEJADHJOEJ BGBIFFLGANM;

	private MNKHLCPAPMI PNEOKDGMMID;

	private HKJLAFBFCKJ MIBIBEJKPGP;

	private FMMHKNJODAC IPKONLFOPAK;

	private HOOOFBIFNOE KLGCLJBOLPG;

	private LAOELDLIJOM CAFKAMABDBN;

	private float GBGLKDLNHOP;

	private float NNJFIFIPANM;

	private Vector3 AKNMNAEKJPG;

	private Vector3 AGNEDLJNLBB;

	private Vector3 BOPKOHBDBJP;

	private Vector3 LBDOBKGNNIF;

	private bool HBICNKKPODN;

	private bool ADCFKGDJNMF;

	private bool FBCPGMECMJA;

	private bool CHEELMKBGCN;

	private bool FHIAMAMIOII;

	private bool DJNBACGNEEL;

	private Vector3 OCINHDLPPBM;

	private bool AKGAIEGGEBA;

	private float PALEKFCHEKI;

	private Vector3 LBEKHHNJCDM;

	private Vector3 GMOELNECPNC;

	private Collider BDBOJLMFDKA;

	private bool JIPCIFKBIDN;

	private Vector3 FGMHGELJPPC;

	private float KJHLDHMJAEH;

	private float ICPEHAKKKIA;

	private bool NAMCCIOBKPN;

	private bool HHMDIACANPD;

	private bool EHLJEOKOMEF;

	private bool COMJDJBGCAM;

	private bool BIEIJPHOEDE;

	private float JOLLDINLBDL;

	private float PFNHANNKNJN;

	private float NBAMGDACNJB;

	private float EOEMBKDOGMA;

	private float JDJGNFJFILK;

	private float FIKKKDJIKHG;

	private bool ADECCKBFHGF;

	private float PHAELKHBLGP;

	private float PDILCMMHGLG;

	private Vector3 JIOJBOADJOG;

	private Vector3 CCLDJMHINML;

	private Vector3 AMPFJOKAAPP;

	private Vector3 OIPEJBMKICI;

	private Vector3 FKGHCPBOIBJ;

	private bool GAIAEGHDKBM;

	private float HBLLLPIMPIF;

	private bool IGJEFFKGLND;

	private bool NHOGNIPKOEP;

	private PELFKPIGEBK LMCFCDELCMG;

	private bool JDLCAPMODFO;

	private float CKILLNLKAEF;

	private float GPJCEAPKJJL;

	private Vector3 KCIMLBFOPOC;

	private bool JNABNLCNNHE;

	private HPPFPPPIMOG HOGCPCNEICB;

	private bool MFFHMDCIEJH;

	private HPPFPPPIMOG DGOKICOHEPD;

	private bool GPMKOCMCLBH;

	private Vector3 MHOMPMNJFEB;

	private bool COJHAEJLBCA;

	private float CJGLKIKDCEO;

	private float OGPEPFCJMEA;

	private float AHPANKAHEFO;

	private Vector3 AKIMAGMABDA;

	private Vector3 ECJEOLDEIHM;

	private JHIKPIHAJLC ECNBMKCCEDB;

	private CIILFFLGMCL MNHIFDLADHG;

	private Vector3 HOMCAHJOFBN;

	private bool FEPPMMNAAEO;

	private bool ADFLPPFIEKN;

	private float JACNDHAJLCG;

	private float GGBODNCAGEH;

	private float JOKEJPLGMIF;

	private ENHHHAEPAKJ MLNJLJBOIBA;

	private const string HJAOIBCJAJP = "Seated";

	private KCIBJJDCPBO PCBGMLKNBAG;

	private float MNIMGKGNLFH;

	public void IHEKMEOIBOI()
	{
	}

	public AFNCKIAIPKL CDJHKCNAIKI(in MNKHLCPAPMI GDKJDDCKGLO, in HKJLAFBFCKJ CAOIPCMMNMJ, in FMMHKNJODAC CJNFDKOBOKG, in HOOOFBIFNOE CPLDCIPPHON, RigidbodyEx HHFDFFDPCGO, LAOELDLIJOM JMABNFLOAPM, float GGEPGCNHMDB, float OKBAJEAPIHG)
	{
		return default;
	}

	public bool BGDAFMEMEFF(Collider MACBOMEMMFB)
	{
		return false;
	}

	public bool ABGGBEMPOAH(Collider MACBOMEMMFB)
	{
		return false;
	}

	public bool CBFLEJBAJON(Collider MACBOMEMMFB)
	{
		return false;
	}

	private bool APALCJEFOFP(Collider ADMCDJKKCIA)
	{
		return false;
	}

	private static bool BDPBBOGLEMH(Collider ADMCDJKKCIA)
	{
		return false;
	}

	private void AHINGCKLKJN()
	{
	}

	private void PGDPECCENGC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void IKOOJGHBANB(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void ODMBMBEBDJH()
	{
	}

	private bool PGKHCLJNAOD(Vector3 PKDNPLAABCK, float OHBOCNDPHFA, Vector3 INMFILPLPNK, Vector3 IEKPGBFHOMP, int MPJGCPAKKKA, DCACHBJGDMC.KFCPKPOOIKD DEABFFHHODC)
	{
		return false;
	}

	private bool BBKFEPNHADI()
	{
		return false;
	}

	private void ACAJBNINDFL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void EDBNHHGJMLF()
	{
	}

	private bool FGHHEDEEPNP(DHBDCBHOHHJ DADHJJNJEFA)
	{
		return false;
	}

	private void EBAKILDPMFL()
	{
	}

	private void GBEPINCNMNI()
	{
	}

	private void HFOBFEDFDIC(Vector3 EDCANBIPEGG, float OJMFBKHIOFM, float PCNDFIKAABC = 1f)
	{
	}

	private void FILBJCHOLDG(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void NNJJLEGGIAP(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void BCNAANKJHGC()
	{
	}

	private void PCMLAGPAIDG()
	{
	}

	private void MOPMDHFEIMK(Vector3 EDCANBIPEGG, float OJMFBKHIOFM, float PCNDFIKAABC = 1f)
	{
	}

	private void FHLBMAAFCHF(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void HCIKPNPEDNK(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void FDAFLMBDDAA()
	{
	}

	private void BDFHHOICLEJ()
	{
	}

	private void IIJAFENOGKC(Vector3 EDCANBIPEGG, float OJMFBKHIOFM, float PCNDFIKAABC = 1f)
	{
	}

	private void JMECEIDJFMA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void EOGFAFDJIEH(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void LDCEHOCIHDP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void DNEBJIDHGMK()
	{
	}

	private void KHONMODNGLA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void BDFDBNBDDCA(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void OEDGNKJGCFM()
	{
	}

	private void IPBJNGHLAIH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void PJJDABAMPEB()
	{
	}

	private void PLIJEMJANEJ(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void INKIJGKDKMB(Vector3 EDCANBIPEGG, float JEFDIJMDBOF, float PCNDFIKAABC)
	{
	}

	private float OIOILAGFILF()
	{
		return 0f;
	}

	private bool OHOOMKNBEJP()
	{
		return false;
	}

	private bool OAJDGKJKAKH(bool NMIFNPLCBHG)
	{
		return false;
	}

	private bool KJBLEAGGMFC()
	{
		return false;
	}

	private bool BEKFHHBFPCM(float OJMFBKHIOFM)
	{
		return false;
	}

	private float EIONFCBGDLL(Vector3 EDCANBIPEGG, Vector3 EEPAMGLMMJE)
	{
		return 0f;
	}

	private void ANEIKHMOAJH()
	{
	}

	private void GEKNNGMNKEN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void AAADHCCLIFG(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void MDBDFAKLLCF()
	{
	}

	private void FKKJHGLLDOC(out Vector3 CFHEIAHGBIH, out float GNJNDJEFNCI)
	{
		CFHEIAHGBIH = default;
		GNJNDJEFNCI = default;
	}

	private void AFHOJPHDKPB(Vector3 CFHEIAHGBIH, float GNJNDJEFNCI)
	{
	}

	private void BDIOKIMGNFL(Vector3 KIDBLHDPKMI, Vector3 EJCHJGLEECL, Vector3 GJOCEGMFHMC, float GNLGKCMDICI, out Vector3 GBGHDBIFIGI, out Vector3 KMDPODINOAD)
	{
		GBGHDBIFIGI = default;
		KMDPODINOAD = default;
	}

	private void COBONABCNFC(Vector3 KIDBLHDPKMI, float OGLJCOJNGKI, Vector3 EJCHJGLEECL, float GNLGKCMDICI, ref float GJDFIHBPOFE, out Vector3 GBGHDBIFIGI, out Vector3 KMDPODINOAD)
	{
		GBGHDBIFIGI = default;
		KMDPODINOAD = default;
	}

	private void OFMBGPCEABC(Vector3 CFHEIAHGBIH, float GNJNDJEFNCI, Vector3 KIDBLHDPKMI, out Vector3 GBGHDBIFIGI, out Vector3 KMDPODINOAD)
	{
		GBGHDBIFIGI = default;
		KMDPODINOAD = default;
	}

	private void BDGACFNLGFK(Vector3 LLOBNBEGGND, ref Vector3 JMIGJNODJGE)
	{
	}

	private float OJKLMAPAELF(float OAMOLFDLCDC)
	{
		return 0f;
	}

	private void CBJHMPIBNOP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void LIIJLFEBMNL()
	{
	}

	private void NIHCJDMCAJO(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void EEELDACGGAJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void GEJAHIGKEGN()
	{
	}

	private void NKIKFDGFDFM(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private Vector3 DMEPCMEKDHC(Vector3 OIEPDFJCEHE, Vector3 OLLJOPPFGKK)
	{
		return default;
	}

	private bool HJENEOLPPJM(bool HAACMLABJOP)
	{
		return false;
	}

	private bool GMCPEDHANEK(HPPFPPPIMOG FGIFGEHKBOO)
	{
		return false;
	}

	private bool HCCNBBCEOKK(Vector3 OLLJOPPFGKK)
	{
		return false;
	}

	private bool CDCBKMNIJDN(Vector3 OLLJOPPFGKK, Vector3 NLMFENPCJOM)
	{
		return false;
	}

	private void BDHBPPNNCKG(out Vector3 EDCANBIPEGG, out float OJMFBKHIOFM)
	{
		EDCANBIPEGG = default;
		OJMFBKHIOFM = default;
	}

	private void KMEPAOEDPNL(bool AGKGKNPIJFB, Vector3 EDCANBIPEGG, float OJMFBKHIOFM)
	{
	}

	private void GBALKGOOCPH(Vector3 CFHEIAHGBIH, Vector3 OLLJOPPFGKK)
	{
	}

	private PELFKPIGEBK DEGFHLMFACK(Vector3 OLLJOPPFGKK, Vector3 DBGAPCBPBFA)
	{
		return PELFKPIGEBK.NONE;
	}

	private void HEKCDALBEEM(Vector3 OLLJOPPFGKK, Vector3 EGNIOBLNMAC)
	{
	}

	private void KKGCDGFIEFG(Vector3 OLLJOPPFGKK, Vector3 EGNIOBLNMAC)
	{
	}

	private void MPJOKNCLIDB(Vector3 OLLJOPPFGKK)
	{
	}

	private Vector3 IJJAKJGHEGD(Vector3 GLJHNAEMBFL, Vector3 NLMFENPCJOM, Vector3 EDCANBIPEGG, float GBMPNIONAFH, float BBGNJMKOHPL)
	{
		return default;
	}

	private void NAGKGODBDGA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void MHLPMMLBMIO()
	{
	}

	private void NCJDKKIOOFA(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void LLHKLGKHOAD(out Collider LBNMCGHPGDP, out Vector3 ODHILINMKOG)
	{
		LBNMCGHPGDP = null;
		ODHILINMKOG = default;
	}

	private void IBMLGPIALJN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void BJHNDAJLPAC()
	{
	}

	private void MGNMPKIGIHG(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void MEJJODLCMGF(out bool PHAFKEGNDBM, out bool MGHELLNLDJP)
	{
		PHAFKEGNDBM = default;
		MGHELLNLDJP = default;
	}

	private void MKHBNPJGJCA()
	{
	}

	private void HHPDAIGBDCH(bool PHAFKEGNDBM, bool MGHELLNLDJP)
	{
	}

	private void PKPHPMLLLOA()
	{
	}

	private Vector3 ODAIKLJIKCE(bool DCBPCJLFLME, bool NBIIGNOCHOL, Vector3 LOPELAGELCJ, Vector3 NIPDPGEFIOB)
	{
		return default;
	}

	private void OBGKPDKBAEA()
	{
	}

	private void JDGPJDEOJAB(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void NCMLLFEGGLH()
	{
	}

	private void DDGPHECPBPN(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void AHGIFBDJLBG(Vector3 EDCANBIPEGG, float BPLDBOOAMCO, bool EIDEJBDOOLD)
	{
	}

	private void FFPPLMEAAEL(Vector3 EDCANBIPEGG, float BPLDBOOAMCO)
	{
	}

	private void HCAKMPNLHAO(Vector3 EDCANBIPEGG, float BPLDBOOAMCO)
	{
	}

	private void MAGHFPGIMNG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void LBBNCJMEDMG()
	{
	}

	private void JIAFHLHFIPK(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private bool ABGHLOLIPPH()
	{
		return false;
	}

	private void DBDCNFLACIK(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void MLMIDCJEHFA()
	{
	}

	private bool AJAHKGLBBMB()
	{
		return false;
	}

	private bool BOMEFFGMCHB()
	{
		return false;
	}

	private bool OIGPBDCKEBI(Vector3 CFHEIAHGBIH, bool PLDOJPKBBHC)
	{
		return false;
	}

	private bool IALPDHGALLN()
	{
		return false;
	}

	private bool OOOAKFGIHKG()
	{
		return false;
	}

	private bool CEBHFCALNMA(Vector3 CHEKLLFMKBP)
	{
		return false;
	}

	private bool BMFLOOPBAJN(Vector3 OLLJOPPFGKK, Vector3 IKLIHEPAINA)
	{
		return false;
	}

	private void FAPCCMHKEFC(float IDIJGAPPMBP)
	{
	}

	private void GGOJLODKGOM(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void PFHICNIKGEM()
	{
	}

	private void DDBLJCKKIGH(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void MKAIACJIOMD(float IDIJGAPPMBP)
	{
	}

	private void HPPCAGHHLKD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void OPGGAACGKPH()
	{
	}

	private void ELDKKCGDJDM()
	{
	}

	private void OMLNOFBCEIH()
	{
	}

	private void INNJHCDOFND(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void JKFAELNONAA()
	{
	}

	private void GFLBJKAJNPP()
	{
	}

	private void GONOGFCPHBB()
	{
	}

	private void JALCLHEIGBC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void FCGNPNAFOAG()
	{
	}

	private void PLLKHEGEOCA()
	{
	}

	private void LIOKEGNIBAE()
	{
	}

	private void DDOCCOIINIO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void JMJOFMDDHGA()
	{
	}

	private void JBCDBGFGHNF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void IDFFBIDKHHJ()
	{
	}

	private void JIPBCGJKDIJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void AEDCKJJFGDF()
	{
	}

	private AFNCKIAIPKL FIHNLBGGOAH()
	{
		return default;
	}

	private Vector3 GMIACIOMNGO(Vector3 GJODHPCIBLK)
	{
		return default;
	}

	private Vector3 BOLJGFKONOH(Vector3 DLOLGDANPLJ)
	{
		return default;
	}

	private void FLDDHIHAEIP()
	{
	}

	private void OJEAGIPINHM()
	{
	}

	private void GNBGDPDMJNM()
	{
	}

	private void MBALPNANOFC(Collider ADMCDJKKCIA, Vector3 GJOCEGMFHMC)
	{
	}

	private void MBALPNANOFC(RigidbodyEx MAHEHHLNFNJ)
	{
	}

	private bool KBKLGAKBCNF(RigidbodyEx MAHEHHLNFNJ)
	{
		return false;
	}

	private void MBALPNANOFC(RigidbodyEx MAHEHHLNFNJ, Vector3 GJOCEGMFHMC)
	{
	}

	private void KMKFNCFPKME(out Vector3 EDCANBIPEGG, out float OJMFBKHIOFM)
	{
		EDCANBIPEGG = default;
		OJMFBKHIOFM = default;
	}

	private void EKANKPPOGPN(out Vector3 EDCANBIPEGG, out float OJMFBKHIOFM)
	{
		EDCANBIPEGG = default;
		OJMFBKHIOFM = default;
	}

	private void BKHJMACLGIM(out Vector3 EDCANBIPEGG, out float OJMFBKHIOFM)
	{
		EDCANBIPEGG = default;
		OJMFBKHIOFM = default;
	}

	private void KJGAGILBDCN()
	{
	}

	private void PHHBJGBOHII(Vector3 OLLJOPPFGKK)
	{
	}

	private Vector3 PIEELEAPDKL(Vector3 OIEPDFJCEHE, Vector3 GJOCEGMFHMC)
	{
		return default;
	}

	private Vector3 CHGGIEEJKDF(Vector3 HLFIBIDOLEF, Vector3 GJOCEGMFHMC)
	{
		return default;
	}

	private void AKHEJDMACDM(Vector3 CMIEPONGLMO, float JNJHPFJPBAC)
	{
	}

	private bool GIDHIIMCHGK()
	{
		return false;
	}

	private bool LGOELNBGEOG()
	{
		return false;
	}

	private bool JJJBEEMODCO()
	{
		return false;
	}

	private bool MFOIIEPCKLJ(float BKKPAOOFKDC, DCACHBJGDMC.KFCPKPOOIKD DEABFFHHODC)
	{
		return false;
	}

	private bool MFOIIEPCKLJ(LAOELDLIJOM JMABNFLOAPM, DCACHBJGDMC.KFCPKPOOIKD DEABFFHHODC)
	{
		return false;
	}

	private bool EGIKBPLDHIE(LAOELDLIJOM JMABNFLOAPM, DCACHBJGDMC.KFCPKPOOIKD DEABFFHHODC, out float GJCKBBAPFEH)
	{
		GJCKBBAPFEH = default;
		return false;
	}

	private void MFDGNJLDCGL()
	{
	}

	private void DGIBBEAMKOC()
	{
	}

	private void LNBFAAGHGMN()
	{
	}

	private void BGMIGMDJPLG()
	{
	}

	private void CGEOLDHFGJG()
	{
	}

	private void JHMGDOCHIAB(Vector3 OLLJOPPFGKK, float PCNDFIKAABC)
	{
	}

	private void GHHIJNKFBNM()
	{
	}

	private void MMJJFCOAEMH(Vector3 OLLJOPPFGKK)
	{
	}

	private void LFCCHMCOMKG(float FCLANJOKBKF, Vector3 ADEFDNJFODJ, bool OFFFGCOCPHJ)
	{
	}

	private void ADNHLMPBHKH()
	{
	}

	private void NEEDPODBLJH(Vector3 OIEPDFJCEHE, Vector3 CHEKLLFMKBP, out Vector3 KGBDNFMMAEI, out Vector3 FBFBBCCDGJA)
	{
		KGBDNFMMAEI = default;
		FBFBBCCDGJA = default;
	}

	private Vector3 OLFIPMIDKDA(Vector3 BFDILLKIGKI, Vector3 CMIEPONGLMO, float JNJHPFJPBAC)
	{
		return default;
	}

	private bool CHMMKNDFKPA(Vector3 GJOCEGMFHMC)
	{
		return false;
	}

	private void NPAMIHIBENM()
	{
	}

	private void DGPDPOGHJPP()
	{
	}

	private void KKAACCCBJEJ()
	{
	}

	private void ANENKGLLGEH(Vector3 OLLJOPPFGKK)
	{
	}

	private float IBHIFOAKIPB()
	{
		return 0f;
	}

	private bool AKNJABGFFFC(out Vector3 OLLJOPPFGKK, out Collider MACBOMEMMFB)
	{
		OLLJOPPFGKK = default;
		MACBOMEMMFB = null;
		return false;
	}

	private bool IKEMAMLFKHN(out Vector3 OLLJOPPFGKK, out Collider MACBOMEMMFB)
	{
		OLLJOPPFGKK = default;
		MACBOMEMMFB = null;
		return false;
	}

	private bool JJCIIIDODON()
	{
		return false;
	}
}
