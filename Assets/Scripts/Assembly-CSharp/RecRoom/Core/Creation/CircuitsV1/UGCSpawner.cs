using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Photon.Pun;
using RRUI.Data;
using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public class UGCSpawner : MonoBehaviourPun, DJLCHGFCFAD, GAAKCFPLMHN, DKKOHMDPPEO, LAIGEMPFAMG
	{
		private class LDOFJOFDJFG
		{
			private List<UGCSpawner> NOLLKEFDAIA;

			private int OPAAOKPOEAM;

public bool JLNIINMNEFI
{
get 			{
				return false;
			}

}

private int DFDJKIFHCAM
{
get 			{
				return 0;
			}

set {
			}
}

			public void CEKAKHFIEOD(UGCSpawner PGDBOCOHNBL)
			{
			}

			public void MKDMBOLMCEO(UGCSpawner PGDBOCOHNBL)
			{
			}

			public void MGPOLFLKODK(UGCSpawner PGDBOCOHNBL)
			{
			}

			public void IKIDIKIEDDE(UGCSpawner PGDBOCOHNBL)
			{
			}

			public bool PAOPIPKJFGC(UGCSpawner PGDBOCOHNBL)
			{
				return false;
			}
		}

		public class MBBEEAABLPL : IFCBCACOLMJ
		{
			private sealed class BJEGLDBEIOF
			{
				public MBBEEAABLPL _003C_003E4__this;

				public UGCSpawner spawner;

				internal void _003C_002Ector_003Eb__0(CreationManager.BFEKGCMDJNM result)
				{
				}
			}

			private LAHBDKNMNHN HEMJLOEDPMK;

public override string AGGOLNLHFBC
{
get 			{
				return null;
			}

}

			public MBBEEAABLPL(UGCSpawner PGDBOCOHNBL, global::NCOKFFGPIJM<CreationManager.BFEKGCMDJNM> EBPPGHGDBEG, JBGFOIKBKED DLEMNBPMGBG)
			{
			}

			protected override LAHBDKNMNHN EIMEGJHDHCP(GGHECEJBHPI LDLDJGEKMIM)
			{
				return null;
			}
		}

		private abstract class KHDEFCIFHIF : GLADODICDIE
		{
			private Guid HAIIGGOHBMA;

			public KHDEFCIFHIF(UGCSpawner PGDBOCOHNBL)
			{
				this.HAIIGGOHBMA = PGDBOCOHNBL.GetComponent<global::RecRoom.Core.Creation.CreationObject>().Guid;
			}

			public UGCSpawner JJLHPGKGNBN()
			{
				return null;
			}

			public override IONEOHGOAML PEHNKLOCMAJ(GGHECEJBHPI DELCOFCGDFF)
			{
				return IONEOHGOAML.Success;
			}
		}

		private class HCHKHNALLDN : KHDEFCIFHIF
		{
			private JBGFOIKBKED CKEPLIBLBFJ;

			public HCHKHNALLDN(UGCSpawner PGDBOCOHNBL, JBGFOIKBKED CKEPLIBLBFJ) : base(PGDBOCOHNBL)
			{
				this.CKEPLIBLBFJ = CKEPLIBLBFJ;
			}

			public override LAHBDKNMNHN FHGMMICFPPJ(GGHECEJBHPI DELCOFCGDFF)
			{
				return null;
			}
		}

		private class PGHIMDKHICF : KHDEFCIFHIF
		{
			private GAMIBKOFAAE GALPHDPIFCK;

			private JBGFOIKBKED CKEPLIBLBFJ;

			private long KBPFKPGOCFN;

			public PGHIMDKHICF(UGCSpawner PGDBOCOHNBL, GAMIBKOFAAE GALPHDPIFCK, JBGFOIKBKED CKEPLIBLBFJ, long KBPFKPGOCFN) : base(PGDBOCOHNBL)
			{
				this.GALPHDPIFCK = GALPHDPIFCK;
				this.CKEPLIBLBFJ = CKEPLIBLBFJ;
				this.KBPFKPGOCFN = KBPFKPGOCFN;
			}

			public override LAHBDKNMNHN FHGMMICFPPJ(GGHECEJBHPI DELCOFCGDFF)
			{
				return null;
			}
		}

		private sealed class CKIECHDGFNI : IDisposable
		{
			public delegate void GLPJLDDNBOG(IEnumerable<GEMEIEHGLIO> JNAAHMPCPAB, IReadOnlyList<bool> LKCAJHNIMJI);

			private sealed class CHNNCKEHNJI
			{
				public bool emptySearch;

				public CKIECHDGFNI _003C_003E4__this;

				internal bool _003COnSearchComplete_003Eb__0(BPHIANGHHIB x)
				{
					return false;
				}

				internal GEMEIEHGLIO _003COnSearchComplete_003Eb__1(BPHIANGHHIB i)
				{
					return null;
				}
			}

			private readonly IReadOnlyList<GEMEIEHGLIO> JNAAHMPCPAB;

			private readonly EGIIJEIOLHB EKIGECAEAKE;

			private readonly GLPJLDDNBOG PCIJELFFBJL;

			private string AOMCAFACKOF;

			public CKIECHDGFNI(IReadOnlyList<GEMEIEHGLIO> JNAAHMPCPAB, MonoBehaviour DELCOFCGDFF, GLPJLDDNBOG GGKGABPGHMO)
			{
			}

			public void OBGPEAFJDMB(string JDPGCELOKNO)
			{
			}

			private int NGPDJGKMDDB(IReadOnlyList<char> CEKPKBILNNE, int OCJOHBKGPHM, string OJKOOAMGPHC)
			{
				return 0;
			}

			private void BPECCLHFLEN(IReadOnlyList<BPHIANGHHIB> ILJGHKGMILC, IReadOnlyList<bool> LKCAJHNIMJI)
			{
			}

			public void Dispose()
			{
			}
		}

		private sealed class NGPDJMCKEPN
		{
			public UGCSpawner _003C_003E4__this;

			public JBGFOIKBKED newToolType;

			public long newInventionId;

			internal void _003CSafeSetAssetData_003Eb__0()
			{
			}
		}

		private sealed class MEEMFKAKMPM
		{
			public UGCSpawner _003C_003E4__this;

			public CostInfo totalCost;

			public JFOADMEPNEL spawnTransform;

			internal object _003CMasterTrySpawn_003Eb__0()
			{
				return null;
			}

			internal global::NCOKFFGPIJM<CreationManager.ALEFKNOEIAL> _003CMasterTrySpawn_003Eb__2(CreationManager.BFEKGCMDJNM serializeResult)
			{
				return null;
			}

			internal void _003CMasterTrySpawn_003Eb__3(CreationManager.ALEFKNOEIAL spawnResult)
			{
			}

			internal void _003CMasterTrySpawn_003Eb__4(string e)
			{
			}
		}

		private sealed class BCJJBGJOLOI
		{
			public GameObject previewGameObject;

			internal void _003CLocalSetupPreviewObject_003Eb__0(PhotonView ancestorPV)
			{
			}
		}

		private sealed class PIBAPPNFGEB
		{
			public UGCSpawner _003C_003E4__this;

			public GPPLMICNLLP data;

			internal object _003CDeserializeFrom_003Eb__0()
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct BKOJLEKJLMO : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public UGCSpawner _003C_003E4__this;

			private TaskAwaiter<CreationManager.BFEKGCMDJNM> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private sealed class JINAEDKCOAG
		{
			public KCOKPCOFDIM pickerDialogData;

			public UGCSpawner _003C_003E4__this;

			public Action<GameObject, int, CardModel, MakerPenPaletteSearchItemModel, JLOCLGGLOPP> _003C_003E9__1;

			public Func<int> _003C_003E9__2;

			public Action<int> _003C_003E9__3;

			internal void _003CUGCSpawnerSelectSpawnableToolRRUIGridPickerDialog_003Eb__0(int count)
			{
			}

			internal void _003CUGCSpawnerSelectSpawnableToolRRUIGridPickerDialog_003Eb__1(GameObject instance, int index, CardModel cardModel, MakerPenPaletteSearchItemModel fromModel, JLOCLGGLOPP toCardController)
			{
			}

			internal int _003CUGCSpawnerSelectSpawnableToolRRUIGridPickerDialog_003Eb__2()
			{
				return 0;
			}

			internal void _003CUGCSpawnerSelectSpawnableToolRRUIGridPickerDialog_003Eb__3(int value)
			{
			}
		}

		private sealed class DFECGOECFFP
		{
			public JBGFOIKBKED toolType;

			internal bool _003CUGCSpawnerSelectSpawnableToolRRUIGridPickerDialog_003Eb__4(GEMEIEHGLIO item)
			{
				return false;
			}

			internal bool _003CUGCSpawnerSelectSpawnableToolRRUIGridPickerDialog_003Eb__5(GEMEIEHGLIO item)
			{
				return false;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct NCJADNNPFJD : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public UGCSpawner _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private const int CPAIEOABEBF = 1000;

		private const int JCGMJIHEMBG = 200;

		private readonly Guid[] CMMPHFEKODB;

		public const string PreviewOnlyParam = "PreviewOnly";

		private static readonly string NNKIPIEBCKF;

		[SerializeField]
		protected GameObject UIRoot;

		[SerializeField]
		private GameObject defaultPreview;

		[SerializeField]
		private Transform visualRoot;

		[SerializeField]
		private Tool _tool;

		public Material PreviewMaterial;

		private static global::BPEPJJDICII<UGCSpawner, CreationObject> DHBMIIBKCEG;

		private static global::HHOBPMOCKMJ<UGCSpawner> IDEPFJKJLHE;

		private static global::HHOBPMOCKMJ<UGCSpawner> HLEIBIPPKPC;

		private global::CHJBFACEOHN<Tool> FNJMKMPKONK;

		private PBJALJMOJOB OLNHNLIPPHD;

		private global::MOBDJNEDDKC<int> OJDNFBLPJGH;

		private global::MOBDJNEDDKC<int> COMIIKIOIPH;

		private global::JPEBBAFCBEP<bool, Vector3> JLPOPILGCKC;

		private global::MOBDJNEDDKC<bool> KOPGNHJHLHP;

		private global::MOBDJNEDDKC<int> EHBFDINDCPO;

		private global::MOBDJNEDDKC<int> HOOMEAMEEOH;

		private NOAEABBGENK APGDDFFCINI;

		private global::JPEBBAFCBEP<JBGFOIKBKED, long> KLJFKOIFJNB;

		private global::MOBDJNEDDKC<Guid[]> MFNFMEOJBEP;

		private List<DHJLEHBOGBG> FMDHGHFFFEP;

		private List<ConfigurableSubpiece> GAJHMBPLHHN;

		private bool PPOHOKMIAGD;

		private global::MOBDJNEDDKC<bool> IIJOMDNBBFP;

		private bool OEJGCIEHELJ;

		private static LDOFJOFDJFG HOPFDDOFGGO;

		private global::MOBDJNEDDKC<int> BFEPEACCIGA;

		private CancellationTokenSource ONEBKIKMKLB;

		private bool FNOHECGECPC;

		private DBIPHDIEBCM ECJHNJODPIF;

		private GAMIBKOFAAE KNKDINCEBDO;

		private CreationManager.BFEKGCMDJNM COKFDFHNNPC;

		private global::NCOKFFGPIJM<CreationManager.BFEKGCMDJNM> PEBLAALIBDH;

		private Guid BOKMPEJBOKD;

		private CKIECHDGFNI EKIGECAEAKE;

		private List<GEMEIEHGLIO> HOPHONGOICE;

		private List<bool> NKEOAPODLDI;

		private string JJHLGKHAFNK;

		private global::PHLHFLLLDLK<int> OIJLDJEMJEJ;

private static int IHBDKGBKIAL
{
get 		{
			return 0;
		}

}

public static global::BEHMNCHGIOA<UGCSpawner, CreationObject> CreationObjectSpawned
{
get 		{
			return null;
		}

}

public static global::GEBDAEJFJCK<UGCSpawner> FinishedSpawningAllObjects
{
get 		{
			return null;
		}

}

public static global::GEBDAEJFJCK<UGCSpawner> AllSpawnedObjectsDestroyed
{
get 		{
			return null;
		}

}

public Tool Tool
{
get 		{
			return null;
		}

}

protected int ALKBOIKNPEF
{
get 		{
			return 0;
		}

set {
		}
}

protected int KMFHODPHADK
{
get 		{
			return 0;
		}

set {
		}
}

protected Vector3 PDLOOBOLAIO
{
get 		{
			return default;
		}

set {
		}
}

protected bool EAIAMLABKCJ
{
get 		{
			return false;
		}

set {
		}
}

protected PBJALJMOJOB FHCHLKMOCOB
{
get 		{
			return null;
		}

set {
		}
}

private int BGCIFFEGIKP
{
get 		{
			return 0;
		}

set {
		}
}

private int JNBDIEOKLGD
{
get 		{
			return 0;
		}

set {
		}
}

private bool BAPDGDBIMED
{
get 		{
			return false;
		}

}

private bool JMMDGJPMEIH
{
get 		{
			return false;
		}

set {
		}
}

public NOAEABBGENK CircuitGraph
{
get 		{
			return null;
		}

private set {
		}
}

protected bool OHDNCGGBOFE
{
get 		{
			return false;
		}

}

protected JBGFOIKBKED KFJMBMAANOI
{
get 		{
			return JBGFOIKBKED.AC_UNIT;
		}

}

protected long PMEFJDDHKCO
{
get 		{
			return 0L;
		}

}

private bool CMGDPOFOIME
{
get 		{
			return false;
		}

}

private Guid[] ABJOKJEAOAI
{
get 		{
			return null;
		}

set {
		}
}

protected bool FPAFFGLAIPM
{
get 		{
			return false;
		}

set {
		}
}

private int HAGECENNIPK
{
get 		{
			return 0;
		}

set {
		}
}

public bool IsQueued
{
get 		{
			return false;
		}

}

private BNOPDNILAFA NAAMILPIIEJ
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

private bool JLDGJGADCDE
{
get 		{
			return false;
		}

}

public Guid CircuitGraphId
{
get 		{
			return default;
		}

private set {
		}
}

		protected GameObject FHOCOKACMLD()
		{
			return null;
		}

		protected virtual void LEJCBPHKLMH(UGCSpawner IHPJCBCPLCM, CreationObject DJGCMHNEBOC)
		{
		}

		protected virtual void FAJDBFCCAGC(UGCSpawner IHPJCBCPLCM)
		{
		}

		protected virtual void MKDBFKABNOK(UGCSpawner IHPJCBCPLCM)
		{
		}

		protected IEnumerable<DHJLEHBOGBG> LNMPHMKKBBF()
		{
			return null;
		}

		private bool MOKHJCHIKOI(Guid[] DENFEGDJGCO)
		{
			return false;
		}

		protected LAHBDKNMNHN CKHDNDPKAAI(JBGFOIKBKED LANPGBFALBE, long GHDEFBEGOON)
		{
			return null;
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

		private void KBFNLIOFCIK(Tool ICHBECDKHOJ)
		{
		}

		private void CKGAGLCJFAN(Tool ICHBECDKHOJ)
		{
		}

		public static (Guid, bool) GetCircuitGraphInstantiationData(MonoBehaviourPun NEOCAENIDLL)
		{
			return default;
		}

		private void AIODKIEGOKC()
		{
		}

		protected void NLJCLDFHMME()
		{
		}

		private void DKNEHHMLCLP()
		{
		}

		private void LKICGGBBKBC()
		{
		}

		private void AHFIHODDJIM(Tool ICHBECDKHOJ)
		{
		}

		public void CircuitSignalUpdated(Dictionary<EDBMANFHGGO, int> signals)
		{
		}

		private void KNIOMPBDLGM()
		{
		}

		private void CGFLBLAIPBN()
		{
		}

		private void OJIMANEPNMN(int IKHNIJKGJFD)
		{
		}

		private void MHFKEBGLPGP()
		{
		}

		private void OFBDGBPCGPG()
		{
		}

		private void JEKLFMDHMEL()
		{
		}

		private void ABJDCLLOEKI()
		{
		}

		private bool KOOIHOFABLM(out Vector3 BAGMHHCMNNF, out Quaternion DNEFKBEHEEC, float JDFDFBKKBPO)
		{
			BAGMHHCMNNF = default;
			DNEFKBEHEEC = default;
			return false;
		}

		private void IILJEOALGPC(Tool LAKEAGALHHL)
		{
		}

		private void KKPDHCEKDAL(DHJLEHBOGBG BPEGJLIMPPJ)
		{
		}

		private void HMKKBEGCNIE()
		{
		}

		public LAHBDKNMNHN RequestMasterChangeSpawnerToTemplateData(GAMIBKOFAAE GALPHDPIFCK, JBGFOIKBKED CKEPLIBLBFJ, long KBPFKPGOCFN)
		{
			return null;
		}

		[PBOMGCLBFHF]
		public void RpcMasterChangeSpawnerToTemplateData(GAMIBKOFAAE GALPHDPIFCK, JBGFOIKBKED CKEPLIBLBFJ, long KBPFKPGOCFN)
		{
		}

		private void LJINJAPKMFA()
		{
		}

		private LAHBDKNMNHN LDENEAOCCFC(GAMIBKOFAAE GALPHDPIFCK)
		{
			return null;
		}

		private LAHBDKNMNHN ILOAOFAIKFG(Transform KPDGHDGLMHO, JBGFOIKBKED NIFOGEBEDNG)
		{
			return null;
		}

		private LAHBDKNMNHN HJPCGGDPEIK()
		{
			return null;
		}

		protected virtual void EKCDJIKBJJG(LMKFOACECEG? IEMMIFODLAI)
		{
		}

		private bool PPMGHGFEPKE()
		{
			return false;
		}

		private void NGIPDIEKECF()
		{
		}

		private void GJMOGCOPNAD(DHJLEHBOGBG JAAOKIBLGJD, ConfigurableSubpiece BHIINMHHHFH)
		{
		}

		protected virtual void PMONNMNJPIH()
		{
		}

		private Tool HOJHJPACMLO()
		{
			return null;
		}

		private void KHCKFACFAGH()
		{
		}

		private IFCBCACOLMJ BHKOLDHEOBH(GGHECEJBHPI DELCOFCGDFF, params object[] BHOKKEBBPNA)
		{
			return null;
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		public Task PreSerializeAsync(StringBuilder AAMCGPPJPFM, APFHIIGOAJG LJBOPGAFHIA, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		protected global::NCOKFFGPIJM<CreationManager.BFEKGCMDJNM> IDALLECMHNO()
		{
			return null;
		}

		protected virtual void MNECEOLGCKC()
		{
		}

		public void UGCSpawnerSelectSpawnableToolRRUIGridPickerDialog()
		{
		}

		private List<GEMEIEHGLIO> KFFMCLCDGKJ()
		{
			return null;
		}

		public void ResetObject()
		{
		}

		public void Bind(NOAEABBGENK JLPKCGOJDJN)
		{
		}

		public void TryRebuildSearchContext()
		{
		}

		private global::NCOKFFGPIJM<int> PMPDGPLFJOL(string JDPGCELOKNO)
		{
			return null;
		}

		private void BPECCLHFLEN(IEnumerable<GEMEIEHGLIO> JNAAHMPCPAB, IReadOnlyList<bool> LKCAJHNIMJI)
		{
		}

		[CompilerGenerated]
		private object BBKOIBCBHJC()
		{
			return null;
		}

		[CompilerGenerated]
		private object FFCPJJBILCL()
		{
			return null;
		}

		[CompilerGenerated]
		private Task HFGHHECMONE()
		{
			return null;
		}

		[CompilerGenerated]
		private object BJLPHALNKKO()
		{
			return null;
		}

		[CompilerGenerated]
		private object OLAPPEFPFHL()
		{
			return null;
		}

		[CompilerGenerated]
		private void AFIPNFGFMEJ()
		{
		}

		[CompilerGenerated]
		private object BIIHMIKKHJE()
		{
			return null;
		}

		[CompilerGenerated]
		private void GEGKIJLMBKP(CreationManager.ALEFKNOEIAL MJKJPIOJMID)
		{
		}

		[CompilerGenerated]
		private object FBHGOBCKBBJ()
		{
			return null;
		}

		[CompilerGenerated]
		private object HCPPJLEDPFF()
		{
			return null;
		}

		[CompilerGenerated]
		private LAHBDKNMNHN FPFAODMPBLO(GAMIBKOFAAE GALPHDPIFCK)
		{
			return null;
		}

		[CompilerGenerated]
		private void JNINBOAIJAE()
		{
		}

		[CompilerGenerated]
		private int CIKMANBPBBA()
		{
			return 0;
		}

		[CompilerGenerated]
		private void ICAGKDKAIFF(int DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private float HHPNHANAANK()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void IABHIJBCOHE(float DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private bool DKOCEGHONIO()
		{
			return false;
		}

		[CompilerGenerated]
		private void ENKEOLGDJKP(bool DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private object FDEACOIDADL()
		{
			return null;
		}
	}
}
