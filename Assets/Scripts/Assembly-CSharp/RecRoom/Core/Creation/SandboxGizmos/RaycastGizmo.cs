using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using AGUI.StackedUI;
using Photon.Pun;
using RecRoom.Core.Creation.CircuitsV1;
using UnityEngine;

namespace RecRoom.Core.Creation.SandboxGizmos
{
	public sealed class RaycastGizmo : MonoBehaviourPun, DJLCHGFCFAD
	{
		private enum FOGOGBFPCIH
		{
			Millimeters = -1,
			Centimeters = 0,
			Meters = 1
		}

		private static class KKCOIJABMEE
		{
			private sealed class NIHOFNDOCGE : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				private int _003CupdateCounter_003E5__2;

				private int _003Ci_003E5__3;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public NIHOFNDOCGE(int _003C_003E1__state)
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

			private const int LGMEIDANAEI = 32;

			private static readonly List<RaycastGizmo> AGHKAOEBLIM;

			private static LAHBDKNMNHN AABEMDPNMNA;

			static KKCOIJABMEE()
			{
			}

			private static void LCLFGLJDADP()
			{
			}

			private static IEnumerator<EGGPGCCKPCO> COGHMAILHBF()
			{
				return null;
			}

			public static void CPCILMEHKPA(RaycastGizmo NINPGCMMNIL)
			{
			}

			public static void MILDLLFOGOM(RaycastGizmo NINPGCMMNIL)
			{
			}
		}

		private struct GHONMMMAMCA
		{
			public float HPBJKBAJPJD;

			public int AIABLOJDPKA;
		}

		private struct BLJGDOODDDJ
		{
			public float HPBJKBAJPJD;

			public int KHGOHMOMMCH;
		}

		private sealed class MFBNFECLJCJ
		{
			public RaycastGizmo _003C_003E4__this;

			public string value;

			internal void _003Cset_FilterTag_003Eb__0(GMBCDOMHMFF.HLMOCMHMIEN response)
			{
			}
		}

		private const EDBMANFHGGO PDGGKLLMDIP = EDBMANFHGGO.R;

		private const EDBMANFHGGO MPEFJFHFNLO = EDBMANFHGGO.G;

		private const BHEOAPLBNIE MHNDOFJIJAC = BHEOAPLBNIE.R;

		private const BHEOAPLBNIE GAMEHDIFHDI = BHEOAPLBNIE.G;

		private const BHEOAPLBNIE NGPHCJOPGDD = BHEOAPLBNIE.B;

		private const int AIBPCCJINKG = 999;

		[SerializeField]
		private CreationObject _creationObject;

		[SerializeField]
		private CircuitEventNodeDisplay _circuitEventNodeDisplay;

		[SerializeField]
		private LineRenderer _lineRenderer;

		[SerializeField]
		private MeshRenderer _endPointMeshRenderer;

		[SerializeField]
		private CircuitInputConnectionPoint _maxDistanceConnectionPoint;

		private RaycastHit CGDIMJKOMFK;

		private KLNOBKBCIEK EMNHDJFDNOH;

		private GHONMMMAMCA DNPBKEIDHEI;

		private BLJGDOODDDJ BEKDNNIIJLA;

		private float AGLJFLHFIME;

		private NNBAJLCGAOK JGEGKOOCOEH;

		private float OMAANDNLJCC;

		private global::MOBDJNEDDKC<bool> JKFMJCKOBND;

		private global::MOBDJNEDDKC<FOGOGBFPCIH> FOMNLONOGAD;

		private global::MOBDJNEDDKC<int> BCDBKAAFJBO;

		private global::MOBDJNEDDKC<bool> PDOCAJAKIAO;

		private global::MOBDJNEDDKC<bool> JJFMPMKOLNM;

		private global::MOBDJNEDDKC<string> OPKLKPBMCNG;

		private global::MOBDJNEDDKC<Guid> LPKJCDIJEDA;

		private global::MOBDJNEDDKC<bool> JDEGANEDJBM;

		private static readonly Dictionary<string, MIBJNNKFLND> FOHLBPPJJIF;

		private BaseCreationObjectSettingPropertyUIControl LNJNGJHBIND;

		private RoleGuidEditableUIControl EJPEMEFODME;

		private static readonly JPMBLKCPNAG IMMOCIFKHPK;

		private static readonly RaycastHit[] MKLOEEOKGFF;

		private static readonly int OMLIEEFMHAF;

		private static readonly int NFIEGLFJGCK;

private BNOPDNILAFA PNCDMGLEGBD
{
get 		{
			return null;
		}

}

private DKLDPOLAKPN JELNHBBMNDM
{
get 		{
			return null;
		}

}

private BPLKOGLLIDK HEGGPDCINMI
{
get 		{
			return null;
		}

}

private int NBJCEBLBFOJ
{
set {
		}
}

private int BDLCLIIGGOI
{
set {
		}
}

private bool LHNCBDFGGKN
{
get 		{
			return false;
		}

set {
		}
}

private FOGOGBFPCIH JCKPJLMDDEJ
{
get 		{
			return FOGOGBFPCIH.Centimeters;
		}

set {
		}
}

private int LCGJIEKPBKI
{
get 		{
			return 0;
		}

set {
		}
}

private float BLHPOBEHCAJ
{
get 		{
			return 0f;
		}

}

private bool MOKCHAIHLPN
{
get 		{
			return false;
		}

set {
		}
}

private bool PNHIDDKGAJK
{
get 		{
			return false;
		}

set {
		}
}

private string LKMFOEIJCBL
{
get 		{
			return null;
		}

set {
		}
}

private Guid GDOHELEFBOM
{
get 		{
			return default;
		}

set {
		}
}

private bool JFKJPLIDCEE
{
get 		{
			return false;
		}

set {
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

		private void LCLFGLJDADP()
		{
		}

		private void HDNAHJDIOMN(Dictionary<EDBMANFHGGO, int> KLPFODAMNED)
		{
		}

		private void MBGBFNKBHOB()
		{
		}

		private void FLDANJADDHN()
		{
		}

		private void CLCJAGEIHLL()
		{
		}

		private void PJOKBDIFPEP()
		{
		}

		private void OIIMHLOPACC()
		{
		}

		private void IJAPDJBIDMC()
		{
		}

		private void ILCALOBDADK()
		{
		}

		private void CPLGDBKFKBN()
		{
		}

		private void GEEMBMLGJCC()
		{
		}

		private void LEOINMECHPD()
		{
		}

		private void JCFCLJLLBFB(NLOGDCDGECD FFILBGADKKN)
		{
		}

		void DJLCHGFCFAD.DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
			//ILSpy generated this explicit interface implementation from .override directive in JCFCLJLLBFB
			this.JCFCLJLLBFB(FFILBGADKKN);
		}

		private void NPJBEOAIFFL(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		void DJLCHGFCFAD.SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NPJBEOAIFFL
			this.NPJBEOAIFFL(ref FCJBDJOMIHI, ref JIEECFLEPDI, AAMCGPPJPFM);
		}

		private static float PPGAJCELCJJ(FOGOGBFPCIH PHIGIMEIKPF, float IPMIIEAGJKC)
		{
			return 0f;
		}

		private static float CJBBLLCHOHJ(FOGOGBFPCIH PHIGIMEIKPF, float JOKOEKOMFHF)
		{
			return 0f;
		}

		private static bool MPBOMNFDNEM(Tool IEGMBEPJMGC, string AHNIMJDLOPB)
		{
			return false;
		}

		private static bool JCNMEONLBCN(Player EKOFNPFCLMO, KLNOBKBCIEK GEHNEOOGNLP)
		{
			return false;
		}

		[CompilerGenerated]
		private int DAKFPJNAECL()
		{
			return 0;
		}

		[CompilerGenerated]
		private void EPDNLBFHIIF(int IPMIIEAGJKC)
		{
		}
	}
}
