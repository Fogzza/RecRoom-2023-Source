using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RecRoom.Core.Creation.CircuitsV1;
using UnityEngine;

namespace RecRoom
{
	public class CircuitsV1Manager : NetworkedSingletonMonoBehaviour<CircuitsV1Manager>, NGBABCGHAAA
	{
		private sealed class ICIGOBBLHFA
		{
			public BNOPDNILAFA node;

			internal bool _003COnNodeDestroyed_003Eb__0(MGDPGGECAAB link)
			{
				return false;
			}
		}

		public static EEANDDJEMJC PreEvaluateEvent;

		private Action CLCHAIGDPMP__BackingField;

		private const float GKAAJMBOOOE = 0.1f;

		private const float JONMEDJNKNK = 0.01f;

		[SerializeField]
		private CircuitLinkVisual circuitLinkVisualPrefab;

		[HideInInspector]
		[SerializeField]
		private string sceneNodeGraphs;

		private bool GAAKAADHKGE;

		private bool NKEEJKJHEAF;

		private IDisposable CNAGCKBFLOE;

		private Dictionary<int, CircuitNodeDisplay> DPHIGABPEFD;

		private Dictionary<MGDPGGECAAB, CircuitLinkVisual> OAIKKLHFMNH;

		private HashSet<CircuitGroupInterfaceNode> MDEKBNOJPAP;

		private bool AMKNNMLMJPO;

		private float GFGEFIOEGAB;

		private float? GEPPBDEGBFK;

		private float HILGKDOADOF;

		private float MOHMCFDNHKH;

		private NNBAJLCGAOK JGEGKOOCOEH;

		private INBDIKIJLGF GBIFNANKKKC;

		private bool BDFNGEAPEIF;

		private Vector3[] GEDGLGJNMEM;

public CircuitLinkVisual CircuitLinkVisualPrefab
{
get 		{
			return null;
		}

}

public bool IsNetworkPaused
{
get 		{
			return false;
		}

}

public int NumLinks
{
get 		{
			return 0;
		}

}

public event Action CircuitVisiblityChanged {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private ILODPOPFPAH FFBDGACNKHN()
		{
			return null;
		}

		private Task JOENGPJNKOD(AHDBIFJNDCH GADDGJANIGG, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private Task NAIMMPHPDPN(AHDBIFJNDCH GADDGJANIGG, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private void MMPHPEHPABP()
		{
		}

		private void Update()
		{
		}

		private void HICJGMAPGJF()
		{
		}

		private void NEICIJPGDPC()
		{
		}

		private void GDDJDMPFEPF(CircuitLinkVisual LIHAJOLNINC, bool HPBAGAPILEH, CircuitGroupInterfaceNode.MJEEMHOJNLI PJKFHOLLGLC, Vector3 INLGLHIPOMC)
		{
		}

		private bool OKKLCHKCFLM()
		{
			return false;
		}

		private void LBPDKPFKDBF()
		{
		}

		[PBOMGCLBFHF]
		protected void RpcUpdateRuntimeState(byte[] NGCJDIPIHFA, byte[] EJKOFADCAKO, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		public void PauseNetworking()
		{
		}

		public void UnpauseNetworking()
		{
		}

		public void SetVisualFor(BNOPDNILAFA KNBPIEINLIG, CircuitNodeDisplay FACDBINPLGK)
		{
		}

		public void RemoveVisualFor(BNOPDNILAFA KNBPIEINLIG)
		{
		}

		public T VisualFor<T>(BNOPDNILAFA KNBPIEINLIG) where T : CircuitNodeDisplay
		{
			return null;
		}

		public void RequestMasterInstantiateNode(Type KGNLILIOCJG, int? KAKEPHABFEE = null)
		{
		}

		public void RequestMasterInstantiateNode(CircuitNodeType KGNLILIOCJG, int? KAKEPHABFEE = null)
		{
		}

		public void RequestMasterInstantiateNode(Guid KGNLILIOCJG, int? KAKEPHABFEE = null)
		{
		}

		[PBOMGCLBFHF]
		private void RpcMasterInstantiateNode(Guid KGNLILIOCJG, int? KAKEPHABFEE)
		{
		}

		[PBOMGCLBFHF]
		private void RpcInstantiateNode(Guid KGNLILIOCJG, int KKBFAENPLID, Guid PBBNJJGAIEO, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		public void MasterLocalInstantiateNode(Type KGNLILIOCJG, int? KAKEPHABFEE = null)
		{
		}

		private void HGMNPCOPBCK(Guid KGNLILIOCJG, int KKBFAENPLID, Guid PBBNJJGAIEO)
		{
		}

		public void RequestMasterDestroyNode(int KKBFAENPLID)
		{
		}

		public void MasterCopyNodeSettings(int KKBFAENPLID, CANDFFOJGBI CBNCDFCAELE)
		{
		}

		[PBOMGCLBFHF]
		private void CopyNodeSettings(int KKBFAENPLID, byte[] FIKJHCKNAAI)
		{
		}

		[PBOMGCLBFHF]
		private void RpcMasterDestroyNode(int KKBFAENPLID)
		{
		}

		[PBOMGCLBFHF]
		private void RpcDestroyNode(int KKBFAENPLID, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		public void MasterLocalDestroyNode(int KKBFAENPLID)
		{
		}

		private bool GIEHBGEHBFO(int KKBFAENPLID)
		{
			return false;
		}

		public void RequestMasterConnectNodes(int MBBMGOLELPG, BHEOAPLBNIE IHOMJCBGMCM, int HMCFONJGLDA, EDBMANFHGGO OBONMNBJMLD)
		{
		}

		[PBOMGCLBFHF]
		private void RpcMasterConnectNodes(int MBBMGOLELPG, BHEOAPLBNIE IHOMJCBGMCM, int HMCFONJGLDA, EDBMANFHGGO OBONMNBJMLD)
		{
		}

		[PBOMGCLBFHF]
		private void RpcConnectNodes(int MBBMGOLELPG, BHEOAPLBNIE IHOMJCBGMCM, int HMCFONJGLDA, EDBMANFHGGO OBONMNBJMLD, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		public void MasterLocalConnectNodes(int MBBMGOLELPG, BHEOAPLBNIE IHOMJCBGMCM, int HMCFONJGLDA, EDBMANFHGGO OBONMNBJMLD)
		{
		}

		private bool LLFACHCJPBH(int MBBMGOLELPG, BHEOAPLBNIE IHOMJCBGMCM, int HMCFONJGLDA, EDBMANFHGGO OBONMNBJMLD)
		{
			return false;
		}

		public void RequestMasterDisconnectNode(int KKBFAENPLID, EDBMANFHGGO OBONMNBJMLD)
		{
		}

		[PBOMGCLBFHF]
		private void RpcMasterDisconnectNode(int KKBFAENPLID, EDBMANFHGGO OBONMNBJMLD)
		{
		}

		[PBOMGCLBFHF]
		private void RpcDisconnectNode(int KKBFAENPLID, EDBMANFHGGO OBONMNBJMLD, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		public void MasterLocalDisconnectNodes(int HMCFONJGLDA, EDBMANFHGGO OBONMNBJMLD)
		{
		}

		private bool IFJCNOPOMHE(int KKBFAENPLID, EDBMANFHGGO OBONMNBJMLD)
		{
			return false;
		}

		public void RequestMasterModifyNode(int KKBFAENPLID, Dictionary<object, object> IKIGEFOFODE)
		{
		}

		[PBOMGCLBFHF]
		private void RpcMasterModifyNode(int KKBFAENPLID, Dictionary<object, object> IKIGEFOFODE)
		{
		}

		[PBOMGCLBFHF]
		private void RpcModifyNode(int KKBFAENPLID, Dictionary<object, object> IKIGEFOFODE, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		public void MasterLocalModifyNode(int KKBFAENPLID, Dictionary<object, object> IKIGEFOFODE)
		{
		}

		private void EABJFKPGLCL(int KKBFAENPLID, Dictionary<object, object> IKIGEFOFODE)
		{
		}

		public void Reinitialize(NDMKJLIFAHM PCPEJHIMHJJ)
		{
		}

		public void InitializeNewGraph(MJFHAAEBBJF PCPEJHIMHJJ, out Dictionary<int, int> DOPIHIJLOLC)
		{
			DOPIHIJLOLC = null;
		}

		public void RunPreInitializationMigration(FBLAHKFEHNM LPHOOGCBMKE, NDMKJLIFAHM JKIOMNICANF)
		{
		}

		private void AGLKEEPHLOB()
		{
		}

		private void CFOECGAGIJC(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		[PBOMGCLBFHF]
		private void RpcReinitializeCircuits(NDMKJLIFAHM EBGAPPCHICB, byte[] NGCJDIPIHFA, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		public void NotifyCircuitVisibilityChanged()
		{
		}

		private void OnPhotonPlayerConnected(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private void OnMasterClientSwitched(CHILKDJABBF GKNDJIKLPKK)
		{
		}

		private void GIFMNPPBNMD(BNOPDNILAFA PLIEMABBEPA, BNOPDNILAFA JADNCKHDFHA, EDBMANFHGGO OBONMNBJMLD, BHEOAPLBNIE IHOMJCBGMCM)
		{
		}

		private void OAEDPLGGCIN(BNOPDNILAFA PLIEMABBEPA, BNOPDNILAFA JADNCKHDFHA, EDBMANFHGGO OBONMNBJMLD, BHEOAPLBNIE IHOMJCBGMCM)
		{
		}

		private void DCFKNJOLPFJ(BNOPDNILAFA KNBPIEINLIG)
		{
		}

		private void FHKCAFKAFKJ(BNOPDNILAFA KNBPIEINLIG)
		{
		}

		public void RequestVisualsForGroupInterfaceNode(CircuitGroupInterfaceNode NAELAKOHGCA, bool AKIJMEDLPMA)
		{
		}

		public void RelinquishAllVisualsForGroupInterfaceNode(CircuitGroupInterfaceNode NAELAKOHGCA)
		{
		}

		public static Color ColorFromOutput(BHEOAPLBNIE IHOMJCBGMCM)
		{
			return default;
		}

		public static Color ColorFromInput(EDBMANFHGGO OBONMNBJMLD)
		{
			return default;
		}

		private void CBHPMGOACKC()
		{
		}

		private void ENDGKBMDABJ(FOAJLJFCOEL OFMKJBIBDCL, string OFCFPGACNJB)
		{
		}

		private void NLFEHFEIOEE(Exception GCBHEJANCJK, string OFCFPGACNJB)
		{
		}
	}
}
