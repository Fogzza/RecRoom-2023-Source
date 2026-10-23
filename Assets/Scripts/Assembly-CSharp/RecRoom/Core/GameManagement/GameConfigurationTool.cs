using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using AGUI.StackedUI;
using Photon.Pun;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.CircuitsV1;
using TMPro;
using UnityEngine;

namespace RecRoom.Core.GameManagement
{
	public sealed class GameConfigurationTool : MonoBehaviourPun, DJLCHGFCFAD
	{
		private class IPACAFJNIPC<T>
		{
			private readonly GameConfigurationTool IOLBBFJPLHJ;

			private readonly Func<T> GOIOJEGDINC;

			private readonly Action<T> FKHGIDOBCCH;

			public IPACAFJNIPC(GameConfigurationTool IOLBBFJPLHJ, Func<T> GOIOJEGDINC, Action<T> FKHGIDOBCCH)
			{
			}

			public T HHCPOGCCGNF()
			{
				return default;
			}

			public void PLCAKFAMFIL(T IPMIIEAGJKC)
			{
			}
		}

		private sealed class AGBCGKFOBOJ
		{
			public int index;

			public Func<bool> isStatValid;

			public GameConfigurationTool _003C_003E4__this;

			internal bool _003CAddConfigurableSettings_003Eb__159()
			{
				return false;
			}

			internal string _003CAddConfigurableSettings_003Eb__162()
			{
				return null;
			}

			internal void _003CAddConfigurableSettings_003Eb__163(string v)
			{
			}

			internal bool _003CAddConfigurableSettings_003Eb__164()
			{
				return false;
			}

			internal void _003CAddConfigurableSettings_003Eb__165(bool v)
			{
			}

			internal int _003CAddConfigurableSettings_003Eb__160()
			{
				return 0;
			}

			internal void _003CAddConfigurableSettings_003Eb__161(int v)
			{
			}
		}

		private sealed class KDAEKIOMLIC : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public GameConfigurationTool _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public KDAEKIOMLIC(int _003C_003E1__state)
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

		private const int CNDFGEBGAGP = 900;

		private const int BOLDHMFMFME = 100;

		private static readonly bool CGNEAGDIPGF;

		private static readonly bool DDKPEMMPBIG;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private TextMeshPro textMesh;

		[SerializeField]
		private ContinuousSourceNodeDisplay circuitSourceNode;

		[SerializeField]
		public GameConfigurationAsset defaultGameConfiguration;

		[SerializeField]
		public EditorGameRuleConfiguration defaultGameRuleConfiguration;

		private NDDHEBMNPCF KEKEIBKNLKD;

		private CreationObjectSettingIntUIControl CBHPCGGJNGG;

		public static EEANDDJEMJC StaticPostConfigurationAppliedEvent;

		public static EEANDDJEMJC StaticConfigurationCreatedEvent;

		private global::MOBDJNEDDKC<bool> IFFBLAIEAFO;

		private global::MOBDJNEDDKC<NDDHEBMNPCF> IKOGBCDBNEB;

		private static Dictionary<string, MIBJNNKFLND> HNFHJHDJDMM;

		private static Dictionary<string, MIBJNNKFLND> IOEEFBJGMPP;

		private static Dictionary<string, MIBJNNKFLND> EPIIPONCFGE;

		private static Dictionary<string, MIBJNNKFLND> FLPOOPHEGOC;

		private static Dictionary<string, MIBJNNKFLND> IABMBGPLCDK;

		private static Dictionary<string, MIBJNNKFLND> APEJMDAAMNM;

		private static Dictionary<string, MIBJNNKFLND> EJBGAGGPFFF;

		private static Dictionary<string, MIBJNNKFLND> PCFMMAHCMBE;

		private static Dictionary<string, MIBJNNKFLND> PEPNMMPNLED;

		private static List<GameConfigurationTool> DPNNMHDHGGL;

		private readonly List<BaseCreationObjectSettingPropertyUIControl> JPIGJHOPAKG;

		private NDDHEBMNPCF HOIJOHFMNPA;

public BNOPDNILAFA CircuitNode
{
get 		{
			return null;
		}

}

public int LoadPriority
{
get 		{
			return 0;
		}

}

public bool HasDefaultConfig
{
get 		{
			return false;
		}

}

public bool IsActive
{
get 		{
			return false;
		}

set {
		}
}

public NDDHEBMNPCF ConfigurationDataSync
{
get 		{
			return null;
		}

set {
		}
}

private static Dictionary<string, MIBJNNKFLND> CLDEFGIIPJI
{
get 		{
			return null;
		}

}

private static Dictionary<string, MIBJNNKFLND> ECODGLNGPNP
{
get 		{
			return null;
		}

}

private static Dictionary<string, MIBJNNKFLND> IKOPGDKHAFB
{
get 		{
			return null;
		}

}

private static Dictionary<string, MIBJNNKFLND> OEDKBICIIGN
{
get 		{
			return null;
		}

}

private static Dictionary<string, MIBJNNKFLND> JDDIJGDGCDC
{
get 		{
			return null;
		}

}

private static Dictionary<string, MIBJNNKFLND> ENEGFFMAAPC
{
get 		{
			return null;
		}

}

private static Dictionary<string, MIBJNNKFLND> CEHFMJFLPGA
{
get 		{
			return null;
		}

}

private static Dictionary<string, MIBJNNKFLND> AOKAGGPIBAL
{
get 		{
			return null;
		}

}

private static Dictionary<string, MIBJNNKFLND> AMGOFHOHDEM
{
get 		{
			return null;
		}

}

public static IReadOnlyList<GameConfigurationTool> AllGameConfigurations
{
get 		{
			return null;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void KDFAFLABJLD()
		{
		}

		public void MasterSetActive(bool FBHDABEFLKL)
		{
		}

		public void AuthorityApplyGameConfiguration(GameConfigurationAsset JGMICIDIILO)
		{
		}

		private void JNPJKOLOFEN()
		{
		}

		private void JLOJCBOALCA()
		{
		}

		private void HBBGIFAIKGK()
		{
		}

		private void NGDPMDLDPKB()
		{
		}

		private void IBEADLOBPCN()
		{
		}

		private void JICFECBLODD(AKCHPHOMHLH PPLLHFPPIPO)
		{
		}

		private NDDHEBMNPCF JEBELMODEPE()
		{
			return null;
		}

		private void AMPIBPGICIM(GameConfigurationAsset FPJKGKBOAOA, bool LIEPJABJLAD)
		{
		}

		private IEnumerator<EGGPGCCKPCO> IIHCHJLKOMC()
		{
			return null;
		}

		private int IHCHJHOJGBF()
		{
			return 0;
		}

		private void CIPKJIEICDC(int IPMIIEAGJKC)
		{
		}

		private int AKIPELODIGI()
		{
			return 0;
		}

		private void NMPJOCKGMBN(int IPMIIEAGJKC)
		{
		}

		private int MAOJFGPGGIL()
		{
			return 0;
		}

		private void JDGKKFGNMHE(int BFFJHKFEFPP)
		{
		}

		private int POLAPOEEPCD()
		{
			return 0;
		}

		private void KKCGOBAAKLO(int GOAPDEMOOEE)
		{
		}

		private void OPNBNIJIBOF(string HLIGBKANEEA, Func<string> GOIOJEGDINC, Action<string> FKHGIDOBCCH, AKCHPHOMHLH PPLLHFPPIPO, Func<bool> FPEOAKJKHMN = null)
		{
		}

		private void NJILADMEFAP(string HLIGBKANEEA, Func<bool> GOIOJEGDINC, Action<bool> FKHGIDOBCCH, AKCHPHOMHLH PPLLHFPPIPO, Func<bool> FPEOAKJKHMN = null)
		{
		}

		private void LNFDILICFKB(string HLIGBKANEEA, Func<float> GOIOJEGDINC, Action<float> FKHGIDOBCCH, AKCHPHOMHLH PPLLHFPPIPO)
		{
		}

		private void HGOLLJJOGMP(string HLIGBKANEEA, Func<int> GOIOJEGDINC, Action<int> FKHGIDOBCCH, AKCHPHOMHLH PPLLHFPPIPO)
		{
		}

		private void OEMIEELJEAJ(string HLIGBKANEEA, Dictionary<string, MIBJNNKFLND> DDFMLPNDINH, Func<int> GOIOJEGDINC, Action<int> FKHGIDOBCCH, AKCHPHOMHLH PPLLHFPPIPO, Func<bool> FPEOAKJKHMN = null, bool ILKHHHOIKCN = false)
		{
		}

		private CostInfo OBDEPBLIELC()
		{
			return default;
		}

		private IONEOHGOAML EPHINAHLLEM(CreationObject FHDPOGAOHBN)
		{
			return IONEOHGOAML.Success;
		}

		private void GGGFMELCEJE()
		{
		}

		private void DKPEOFODCHA()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		private void OHOGINEFLOE()
		{
		}

		[CompilerGenerated]
		private string JJHCHPDAAKP()
		{
			return null;
		}

		[CompilerGenerated]
		private void ELKPGPBLAKK(string MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private void CKCBLDKKNLB(int MLECAGAJCGO)
		{
		}

		[CompilerGenerated]
		private int KPFJFBJGKGP()
		{
			return 0;
		}

		[CompilerGenerated]
		private void KNPNCGJICDC(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int COEOMOIDHGD()
		{
			return 0;
		}

		[CompilerGenerated]
		private void MBHJHOLDGJD(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int PPKLNFDJBLB()
		{
			return 0;
		}

		[CompilerGenerated]
		private void FDBHNJJHLLB(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool MPHPKFLFKAP()
		{
			return false;
		}

		[CompilerGenerated]
		private void DDNBPOOMLBO(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int DLFMKGFCJEM()
		{
			return 0;
		}

		[CompilerGenerated]
		private void DOONJIHLEOL(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int OIKPNICPNHN()
		{
			return 0;
		}

		[CompilerGenerated]
		private void DPPMCANOGJH(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int GDJCAKGELIN()
		{
			return 0;
		}

		[CompilerGenerated]
		private void OABDPIDCNFJ(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool IFGPLLENKDD()
		{
			return false;
		}

		[CompilerGenerated]
		private void JEKPLAIPPEC(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool DHNIOPFBLDI()
		{
			return false;
		}

		[CompilerGenerated]
		private void KKPBCPPIHLL(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool ODIEDEIBIOJ()
		{
			return false;
		}

		[CompilerGenerated]
		private void KEMBGOPNOJI(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool HNODADICBLB()
		{
			return false;
		}

		[CompilerGenerated]
		private void LPHMHOPNBKK(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool EJOHHPJGIIG()
		{
			return false;
		}

		[CompilerGenerated]
		private void BLDOFKEHMDG(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float COCMOEIPNDN()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void GOPDNOKKMFE(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float PPOHJGHLKKI()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void EJLMCFACOLO(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool NJBLCOCEGLP()
		{
			return false;
		}

		[CompilerGenerated]
		private void AFFGKGMFAKD(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool AMMHADBABAA()
		{
			return false;
		}

		[CompilerGenerated]
		private void APBFCFKABFI(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool DMCKDAEGPDM()
		{
			return false;
		}

		[CompilerGenerated]
		private void BOLFDLFKNBE(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool IJLCDLAAMKG()
		{
			return false;
		}

		[CompilerGenerated]
		private void LFMDHCBLPLC(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool CELEKANAHAP()
		{
			return false;
		}

		[CompilerGenerated]
		private int DFBOODBEFCE()
		{
			return 0;
		}

		[CompilerGenerated]
		private void EOFHNLGJMML(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool PMAPJNOIADI()
		{
			return false;
		}

		[CompilerGenerated]
		private void LPGGKNHENNC(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool JCKAGIMNPDA()
		{
			return false;
		}

		[CompilerGenerated]
		private void BDAILCPDHFD(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool JPDECLICFGL()
		{
			return false;
		}

		[CompilerGenerated]
		private void OIOJLAHEJJO(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool KAOHCGIEOHE()
		{
			return false;
		}

		[CompilerGenerated]
		private void DJAMKDMJEGD(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool PKDNDHMNIIP()
		{
			return false;
		}

		[CompilerGenerated]
		private void NIJCKIMNIAB(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool OPFHGDIBECH()
		{
			return false;
		}

		[CompilerGenerated]
		private void HMMEMABHPIJ(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool IHPHBICLKNN()
		{
			return false;
		}

		[CompilerGenerated]
		private void IHFKLNKNAGN(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int CBMCLOGNBPE()
		{
			return 0;
		}

		[CompilerGenerated]
		private void FPNJINOPILP(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int KGMJGMEKEPP()
		{
			return 0;
		}

		[CompilerGenerated]
		private void DNEBFKEOCKO(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool DAKJLHBDDCG()
		{
			return false;
		}

		[CompilerGenerated]
		private void INOACKMHAKC(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float CEJKMBEKALB()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void DOMPDCPJKPO(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float BJPHGMENHHM()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void EIGDBOOECBD(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float AALPDJEIMOK()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void IJLIHLHLDMN(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool AADKKEDFDOI()
		{
			return false;
		}

		[CompilerGenerated]
		private void KDGPKJCKJNM(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int ICLCJGDODHJ()
		{
			return 0;
		}

		[CompilerGenerated]
		private void LHPANLCJNEA(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int ADDDENBNEMK()
		{
			return 0;
		}

		[CompilerGenerated]
		private void IODCIHJAHLI(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool HKKACDHDLKP()
		{
			return false;
		}

		[CompilerGenerated]
		private void GHJCEOLJKHD(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool MEHDNAJFEKK()
		{
			return false;
		}

		[CompilerGenerated]
		private void FIJACILLFLB(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool POCKBACEFHN()
		{
			return false;
		}

		[CompilerGenerated]
		private void NNPNGHNBJBJ(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float KBBHCKLPBGB()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void KLLEEDINHMA(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float IJCBCBMIMIE()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void IHHLCNBHEDK(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool LMMPDCGGFGC()
		{
			return false;
		}

		[CompilerGenerated]
		private void OOPJDMOPGGD(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float NHMOPDBHMFM()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void DKINMEIOPOG(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float DCNCDEOLCPE()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void AHMHKFJOOKL(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool MHFJHFNLGPD()
		{
			return false;
		}

		[CompilerGenerated]
		private void AIFDLAFFEFJ(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float CCNNPFINEGD()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void MFGJIDDPCOO(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool IBBJMFBFLBC()
		{
			return false;
		}

		[CompilerGenerated]
		private void CDKNLJIAIDK(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float AHMBGICJGOD()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void ENNLMBJPKJM(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int NJGJJJHPGAD()
		{
			return 0;
		}

		[CompilerGenerated]
		private void IKKIAABGNAB(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool GEGEMJJOPHE()
		{
			return false;
		}

		[CompilerGenerated]
		private void PFDOABMHIKJ(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float JFLOLMMMIBI()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void LLDKJHGIBLP(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float DMDGIHINNGD()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void LGMGIFLHNBI(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float GBMKLKOENHE()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void MAKHKKONOJH(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float AGMDFONBJNM()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void ABBMEBFJLGC(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool NFIINMBCGKD()
		{
			return false;
		}

		[CompilerGenerated]
		private void ACFDJCMAJBB(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float HHBPGJKIKJO()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void IHJOGIBGFDM(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float NJAMCJJDFMN()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void FIBBPFEEEMD(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float PKIGFADEHKD()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void FOPJAPICKFJ(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool PHEIBGCHIFD()
		{
			return false;
		}

		[CompilerGenerated]
		private void PPGFJJFNIGG(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool CCKEPKAGKFN()
		{
			return false;
		}

		[CompilerGenerated]
		private void PGHFFAMOJLA(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool GNLLDLPGGEO()
		{
			return false;
		}

		[CompilerGenerated]
		private void FEGGJFFLONG(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool AOMDFNJAJGJ()
		{
			return false;
		}

		[CompilerGenerated]
		private void OOFOKEJHONB(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool GLFOGFCMKAF()
		{
			return false;
		}

		[CompilerGenerated]
		private void GOMJDGGNGIG(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool EGNGAIEDNBE()
		{
			return false;
		}

		[CompilerGenerated]
		private void LGHBMNEFKCG(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool HLCPDAOJINK()
		{
			return false;
		}

		[CompilerGenerated]
		private void MFLFCNJAPGG(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool LJLEMLHIEPD()
		{
			return false;
		}

		[CompilerGenerated]
		private void OHEFABLJMCO(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool KEAFDALIAPL()
		{
			return false;
		}

		[CompilerGenerated]
		private void JMBFIAAGNDE(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool BHJGFNKHKKF()
		{
			return false;
		}

		[CompilerGenerated]
		private void IFNGHKGKPPK(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool HCFAOFJEEAI()
		{
			return false;
		}

		[CompilerGenerated]
		private void FOMDFCNFOEL(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool IKIINOFGGIO()
		{
			return false;
		}

		[CompilerGenerated]
		private void NJPMJPBDLLA(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool BEBMMPCICHF()
		{
			return false;
		}

		[CompilerGenerated]
		private void IHCOBFLAPPC(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int KFJJPBCGKFK()
		{
			return 0;
		}

		[CompilerGenerated]
		private void BFGMEOAIEOH(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool AOANELHAIPL()
		{
			return false;
		}

		[CompilerGenerated]
		private void DOOOCDMNJJK(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private int HAFJDNLMPFL()
		{
			return 0;
		}

		[CompilerGenerated]
		private void FDPMCHDMLKF(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool LMNDPGLLPAI()
		{
			return false;
		}

		[CompilerGenerated]
		private void AHNADFPLELI(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool BMDCDIBPKAE()
		{
			return false;
		}

		[CompilerGenerated]
		private void HBBKPHKOKJN(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool AEKFMGGIACC()
		{
			return false;
		}

		[CompilerGenerated]
		private void OMIACJKPPHK(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool KNHCPLPJLBD()
		{
			return false;
		}

		[CompilerGenerated]
		private void NPEGPPHDBKN(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float DMPCKFAFGHB()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void LCFHKHNAHLH(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float EPPNFGNFKIH()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void PFAHAFGOFNO(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool ECJNDNECEPL()
		{
			return false;
		}

		[CompilerGenerated]
		private void FCEJHBOHHDN(bool MLIPDLAHDHI)
		{
		}
	}
}
