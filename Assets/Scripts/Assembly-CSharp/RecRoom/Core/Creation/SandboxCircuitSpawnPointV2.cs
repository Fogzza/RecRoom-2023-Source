using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.Systems.PlayerRoles;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class SandboxCircuitSpawnPointV2 : MonoBehaviourPun, GFLPAFBGELM, NEKJJEGPHFG, DJLCHGFCFAD, PJINIJOHANN
	{
		public const string PrimaryLabel = "Respawn Point";

		private const float BJKJCNBMNCL = 5f;

		private const int CHEHKNLIOKK = 200;

		private const float FEDJMMDJAIH = 0.3f;

		private const float FJBKGDFONMH = 0f;

		private const float EDBFMPMBMOL = 1f;

		private const float KJEBIPADADB = 5f;

		private const float GDLDLNOCANE = 0f;

		private const float GKMLLNPGACJ = 2f;

		private const float FLIFMENJGOB = 25f;

		private static readonly List<SandboxCircuitSpawnPointV2> BLGCHCDMOCN;

		[SerializeField]
		private CreationObject creationObject;

		[SerializeField]
		private GameObject spawnRegionObject;

		[SerializeField]
		private GameObject hazardRegionObject;

		[SerializeField]
		protected SyncedComponentV2 syncComponent;

		private string COBAABGEMJK;

		private string IGCEKFMGKLD;

		private global::CDLJMENCODC<float> EBKOBAKIDEJ;

		private global::CDLJMENCODC<bool> NAPNFCKPNCJ;

		private global::CDLJMENCODC<float> OMLKFOGGFAE;

		private global::CDLJMENCODC<float> NCGBFFJIMGP;

		private global::CDLJMENCODC<string[]> AIGOBHNCEDE;

		private HashSet<string> LIBNMBEHGIG;

		private global::CDLJMENCODC<string[]> JMFGDEEODOK;

		private HashSet<string> GJEEGAGCFFO;

		private global::CDLJMENCODC<string[]> OCNMMMEAMMH;

		private HashSet<Guid> CIBDPLELGBJ;

		private KLNOBKBCIEK DDCCGCIIKIE;

		private global::CDLJMENCODC<string[]> PMPHANCKOMB;

		private HashSet<Guid> IIHELCAMNNM;

		private KLNOBKBCIEK MFDFOCDMGKF;

private float FBLLOPGBCDK
{
get 		{
			return 0f;
		}

set {
		}
}

private static float HGBPDJOBCCO
{
get 		{
			return 0f;
		}

}

public bool SpawnPointActive
{
get 		{
			return false;
		}

set {
		}
}

public float SpawnRadius
{
get 		{
			return 0f;
		}

set {
		}
}

public float HazardRadius
{
get 		{
			return 0f;
		}

set {
		}
}

public string[] TagsToSpawn
{
get 		{
			return null;
		}

set {
		}
}

public string[] TagsToAvoid
{
get 		{
			return null;
		}

set {
		}
}

public string[] RoleGuidsToSpawn
{
get 		{
			return null;
		}

set {
		}
}

public KLNOBKBCIEK RoleIdToSpawn
{
get 		{
			return KLNOBKBCIEK.AG_EVERYONE;
		}

}

public string[] RoleGuidsToAvoid
{
get 		{
			return null;
		}

set {
		}
}

public KLNOBKBCIEK RoleIdToAvoid
{
get 		{
			return KLNOBKBCIEK.AG_EVERYONE;
		}

}

public global::MPNGGJINIEL<KGGKJGICJLE> ObjectDefinitionId
{
get 		{
			return default;
		}

}

public GMHHJCFIMML CV2CreationObject
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

		protected void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void GFOCMFGOFNC(bool BLOCPPAOJDM)
		{
		}

		void PJINIJOHANN.SetSynchronizing(bool BLOCPPAOJDM)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GFOCMFGOFNC
			this.GFOCMFGOFNC(BLOCPPAOJDM);
		}

		private void OLMLGEOOPCH()
		{
		}

		private void HIBCCCDAMDG()
		{
		}

		private void ODFKKHCPKEH()
		{
		}

		private void FNIAMOKGIFG()
		{
		}

		private void PGKIDEJNHAL()
		{
		}

		private void BILKFFAKHGP()
		{
		}

		private void NLLMKHHFIKO()
		{
		}

		private void GOLHALNMNHG()
		{
		}

		private void HMDOCIIBPOB()
		{
		}

		private static void NMKHDDKEJJH(Player CHJBEFJDENI, out List<SandboxCircuitSpawnPointV2> IBGLCCNBEOC, out List<(float, SandboxCircuitSpawnPointV2)> HAGGDLMDLOJ, out List<SandboxCircuitSpawnPointV2> IHOKPOEMFAE)
		{
			IBGLCCNBEOC = null;
			HAGGDLMDLOJ = null;
			IHOKPOEMFAE = null;
		}

		private bool ACBEPGDPJKL(Player EKOFNPFCLMO, GameRole ADKKJLEGCIA)
		{
			return false;
		}

		private bool KCHPLCOOGMH(out float KNGPKPLBCED)
		{
			KNGPKPLBCED = default;
			return false;
		}

		private static bool MDEFCOEHIPP(Vector3 PEGLFIHDCKE, out Vector3 FCNGMPHKHAE)
		{
			FCNGMPHKHAE = default;
			return false;
		}

		private static bool KDLGEBGBLEO(Vector3 INLGLHIPOMC)
		{
			return false;
		}

		private bool NOJAFFHDMAG(out Vector3 FCNGMPHKHAE)
		{
			FCNGMPHKHAE = default;
			return false;
		}

		public static bool TryFindAvailableSpawnPosition(Vector3 OHDBHFCEAKK, float IFJGBOLGKEA, out Vector3 FCNGMPHKHAE)
		{
			FCNGMPHKHAE = default;
			return false;
		}

		private global::FAIKNKAIPLB<OHAJOLBEFND> DCBNIOPDHIN(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		global::FAIKNKAIPLB<OHAJOLBEFND> GFLPAFBGELM.Self(JEGAPHLGBJA GCBHEJANCJK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DCBNIOPDHIN
			return this.DCBNIOPDHIN(GCBHEJANCJK);
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2AddSpawnRole(JEGAPHLGBJA GCBHEJANCJK, GameRole KLBONOOHBND)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2AddSpawnTag(JEGAPHLGBJA GCBHEJANCJK, string AHNIMJDLOPB)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2AddAvoidRole(JEGAPHLGBJA GCBHEJANCJK, GameRole KLBONOOHBND)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2AddAvoidTag(JEGAPHLGBJA GCBHEJANCJK, string AHNIMJDLOPB)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RemoveSpawnRole(JEGAPHLGBJA GCBHEJANCJK, GameRole KLBONOOHBND)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RemoveSpawnTag(JEGAPHLGBJA GCBHEJANCJK, string AHNIMJDLOPB)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RemoveAvoidRole(JEGAPHLGBJA GCBHEJANCJK, GameRole KLBONOOHBND)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RemoveAvoidTag(JEGAPHLGBJA GCBHEJANCJK, string AHNIMJDLOPB)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetSpawnPointActive(JEGAPHLGBJA GCBHEJANCJK, bool FBHDABEFLKL)
		{
			return default;
		}

		public static global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RespawnPlayer(JEGAPHLGBJA GCBHEJANCJK, Player CHJBEFJDENI, bool KBDPBKJKFGJ, bool LPKBKDOMDNB)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RespawnPlayerHere(JEGAPHLGBJA GCBHEJANCJK, Player CHJBEFJDENI, bool KBDPBKJKFGJ, bool LPKBKDOMDNB)
		{
			return default;
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		[CompilerGenerated]
		private bool NFFMFCCNBBJ()
		{
			return false;
		}

		[CompilerGenerated]
		private void LIHDLIOJBGP(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool LBIGBLKIMEG()
		{
			return false;
		}

		[CompilerGenerated]
		private float NGOGNINNHIP()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void AMGGAPJCFPH(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private float BPKGACEDHEM()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void KMPEAPPDAHC(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private IReadOnlyList<string> FJDMNHFMBKO()
		{
			return null;
		}

		[CompilerGenerated]
		private void IJHAOKLOHIJ(IReadOnlyList<string> MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private string GNMHLJNHFHB()
		{
			return null;
		}

		[CompilerGenerated]
		private void FJBKHJJFDMG(string MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private IReadOnlyList<string> FMHKDJKHHOI()
		{
			return null;
		}

		[CompilerGenerated]
		private void EEPDNMKOPML(IReadOnlyList<string> MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private string KGMNLINJMJF()
		{
			return null;
		}

		[CompilerGenerated]
		private void HFECBDDKJEG(string MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private HashSet<Guid> PHKGBLKIELG()
		{
			return null;
		}

		[CompilerGenerated]
		private void AFNBACPLAHB(IEnumerable<Guid> IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private HashSet<Guid> PIMGNDDHFPO()
		{
			return null;
		}

		[CompilerGenerated]
		private void ODDCHKNOGAG(IEnumerable<Guid> IPMIIEAGJKC)
		{
		}
	}
}
