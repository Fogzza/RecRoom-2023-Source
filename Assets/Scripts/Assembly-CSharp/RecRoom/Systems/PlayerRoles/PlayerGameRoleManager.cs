using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeStage.AntiCheat.ObscuredTypes;
using JetBrains.Annotations;
using Photon.Pun;
using RecRoom.Core.Creation;
using UnityEngine;

namespace RecRoom.Systems.PlayerRoles
{
	public class PlayerGameRoleManager : RoleManagerBase<KLNOBKBCIEK, GameRole.EEGNMJMPIJJ, GameRole, AIKGLCGDKBM, ELGJDNJECLB>
	{
		private class KIJIHGIPLJF : BOMHDJABLNJ
		{
			private readonly global::MOBDJNEDDKC<ObscuredInt> CNHACMKKAMB;

public override string DMABHJFKLPH
{
get 			{
				return null;
			}

}

			public KIJIHGIPLJF(MonoBehaviourPun DELCOFCGDFF, CHILKDJABBF FBCDJHOIDJJ, int BIFCGGMKNDF)
				: base((CHILKDJABBF)null)
			{
			}

			protected override int LJACLCKKEAA()
			{
				return 0;
			}

			protected override void AIKACFDHMFC(int PIBNPPAEMEN)
			{
			}
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct DGLMPEIHMGM : IDisposable
		{
			public void Dispose()
			{
			}
		}

		private sealed class OPEJOOJFDBK
		{
			public GameRole role;

			internal bool _003CMasterSpawnMissingGameRoleNodes_003Eb__0(GameRoleNodeWrapper grn)
			{
				return false;
			}
		}

		public const int GAME_ROLE_MANAGER_PRIORITY = 10000;

		private readonly global::AFHOAHNAMGF<GameRole> PKEDOJCEGJO;

		[SerializeField]
		private GameRole defaultInGameRole;

		[SerializeField]
		private GameRole eliminatedRole;

		private static readonly KLNOBKBCIEK[] JJDJIPBGMAO;

		private static readonly int[] FKGMOGFLLNE;

		public static readonly int[] RoleVoiceRolloffDistances;

		public static global::HHOBPMOCKMJ<KLNOBKBCIEK> OnCreationRestrictionRemovedEvent;

		private global::MOBDJNEDDKC<ObscuredBool> DOJHAKIEMAK;

		private IDisposable KMMDNNPDDMC;

		private CGOPOAFDIDN AAKFKPKFDJJ;

		private static readonly KLNOBKBCIEK[] IBHPMBKJKPO;

		private global::PHLHFLLLDLK<bool> MOJFEJLJMBL;

		private const string LBGODNDGFIH = "(Clone)";

		public static readonly Guid AG_EVERYONE_GUID;

		public static readonly Guid AG_IN_GAME_GUID;

		public static readonly Guid AG_ELIMINATED_GUID;

		public static readonly Guid AG_ROLE_3_GUID;

		public static readonly Guid AG_ROLE_4_GUID;

		public static readonly Guid AG_ROLE_5_GUID;

		public static readonly Guid AG_ROLE_6_GUID;

		public static readonly Guid AG_ROLE_7_GUID;

		public static readonly Guid AG_ROLE_8_GUID;

		public static readonly Guid AG_ROLE_9_GUID;

		public static readonly Guid AG_ROLE_10_GUID;

		public static readonly Guid AG_ROLE_11_GUID;

		private static readonly Dictionary<KLNOBKBCIEK, Guid> MFPLNLCBFIL;

		private bool HBFEFBJNIJG;

public new static PlayerGameRoleManager Instance
{
get 		{
			return null;
		}

}

private GameRole JBFNCOPODCJ
{
get 		{
			return null;
		}

}

public bool LocalRoomAllowsCreationRestrictedRoles
{
get 		{
			return false;
		}

}

public IReadOnlyList<KLNOBKBCIEK> AllGameRoleIds
{
get 		{
			return null;
		}

}

protected override int[] MGBICHKPPLO
{
get 		{
			return null;
		}

}

protected static string EDJOHDJEAFE
{
get 		{
			return null;
		}

}

protected override string MEDNJPBFPHJ
{
get 		{
			return null;
		}

}

protected override bool KAHBGMLIBFH
{
get 		{
			return false;
		}

}

		public void AddInGameRoleDefinition(GameRole IPMIIEAGJKC, object IALNODEHBNN, HOPIACLIGJO LAGADKBKLAD)
		{
		}

		public void RemoveInGameRoleDefition(object IALNODEHBNN)
		{
		}

		public static int FindClosestRolloffDistance(float FLPHJMGNEHH, out int GMEHLIHLGEH)
		{
			GMEHLIHLGEH = default;
			return 0;
		}

		protected override void INCIIIOGJDD(LDIFNONEEOF NDFMMDHCKFC, GameRole BGFEOMKGGDI)
		{
		}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OKGMAPGPPPJ()
		{
		}

		private List<KLNOBKBCIEK> DMPLAIGJOCI(CHILKDJABBF EKOFNPFCLMO)
		{
			return null;
		}

		protected override BOMHDJABLNJ AMMCIDBFDCB(CHILKDJABBF EKOFNPFCLMO)
		{
			return null;
		}

		protected override void MPMAGNADBEI()
		{
		}

		protected override void CIAHKKLLLJM(ref List<GameRole> NKIPFILGHKL)
		{
		}

		private void MJGPHBGDHDJ(Player EKOFNPFCLMO)
		{
		}

		protected override GameRole CJODINCHEEE(int CJFOLKFCHOA, GameRole OEJILPJHPPG, string EOJDBMEHCOF = null)
		{
			return null;
		}

		public override bool IsPlayerDefinedRole(KLNOBKBCIEK GEHNEOOGNLP)
		{
			return false;
		}

		protected override void MMOEIHIDECD(KLNOBKBCIEK KMMLJACCLKF)
		{
		}

		public global::NCOKFFGPIJM<bool> RequestEnableCreationRestrictedRoles(bool OBFHBDLKFPA)
		{
			return null;
		}

		[PBOMGCLBFHF]
		private void RpcMasterRequestEnableCreationRestrictedRoles(bool OBFHBDLKFPA, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnRequestEnableCreationRestrictionRolesReceived(bool EGJEBAFNALL)
		{
		}

		private void MKFIFCKMFMA()
		{
		}

		public bool CanPlayerModifyCreationRoleSetting(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		public override bool PlayerCanModifyRoleDefinition(CHILKDJABBF OONACCDEFKJ, KLNOBKBCIEK GEHNEOOGNLP)
		{
			return false;
		}

		public override bool PlayerCanModifyRolePermission(CHILKDJABBF OONACCDEFKJ, KLNOBKBCIEK GEHNEOOGNLP, GameRole.EEGNMJMPIJJ HEGLKMIJHAM)
		{
			return false;
		}

		protected override bool EMHMEBMKOMP(CHILKDJABBF OONACCDEFKJ)
		{
			return false;
		}

		protected override bool NJDNOPOGCGL(CHILKDJABBF MCEGNOOCBCN, GameRole AGEFIBONJHH, GameRole LLCICIBAEOC)
		{
			return false;
		}

		public override bool PlayerCanAssignRole(CHILKDJABBF EMKHMGLLFIH, CHILKDJABBF FMEPFGGKBIL, KLNOBKBCIEK GEHNEOOGNLP)
		{
			return false;
		}

		public bool TryGetActiveRoleByGuid(Guid JKHAGFEKALE, out KLNOBKBCIEK GEHNEOOGNLP)
		{
			GEHNEOOGNLP = default;
			return false;
		}

		public bool TryGetActiveRoleDefinitionByGuid(Guid JKHAGFEKALE, out GameRole KLBONOOHBND)
		{
			KLBONOOHBND = null;
			return false;
		}

		protected override int NNOCEPGBMCN(KLNOBKBCIEK GEHNEOOGNLP)
		{
			return 0;
		}

		protected override KLNOBKBCIEK PILEMGJCONO(int GEHNEOOGNLP)
		{
			return KLNOBKBCIEK.AG_EVERYONE;
		}

		protected override int[] GLAPBDDPFAH(KLNOBKBCIEK[] KOMLMPMKKAC)
		{
			return null;
		}

		protected override bool BEIKFGGJCKL(int GEHNEOOGNLP)
		{
			return false;
		}

		protected override ELGJDNJECLB CDHPFHNPMNF(KHMOHFAFGBI KGMPBFBAMCF)
		{
			return null;
		}

		protected override ELGJDNJECLB PEMJBNHNHJC(byte[] EPPJDIHKINL)
		{
			return null;
		}

		protected override void HMGNFOKBOKA(KHMOHFAFGBI KGMPBFBAMCF)
		{
		}

		protected override void CEIFOCHDGLI(ELGJDNJECLB ADDBCAECLPO)
		{
		}

		protected override void IOOOBCEGAEO(KHMOHFAFGBI KGMPBFBAMCF)
		{
		}

		public void MasterSpawnMissingGameRoleNodes()
		{
		}

		private void CJCGAGNNLAH(Guid IGPABPDIFEM)
		{
		}

		protected override void GBAHJDOBMPO(ref KHMOHFAFGBI KGMPBFBAMCF)
		{
		}

		protected override ELGJDNJECLB LADEHPLDIBE()
		{
			return null;
		}

		protected override void OKPFLCNHDEN(ref KHMOHFAFGBI KGMPBFBAMCF, ELGJDNJECLB ADDBCAECLPO)
		{
		}

		protected override void BLPKFCDFBLF(CHILKDJABBF FBCDJHOIDJJ, GameRole KFLOFFHNINA)
		{
		}

		private void PMHECPBIJKC(Player EKOFNPFCLMO, global::PKKINNENDEC<ObscuredInt> NBOBKOGPOEJ)
		{
		}

		protected override void DJBNPCBJIFC()
		{
		}

		public static bool CanPickupTool(Player FOCKAEINGKG, Tool IEGMBEPJMGC)
		{
			return false;
		}

		public static bool CanPickupTool(CHILKDJABBF FBCDJHOIDJJ, Tool IEGMBEPJMGC)
		{
			return false;
		}

		private bool BPPDDCOOHAJ(CHILKDJABBF FBCDJHOIDJJ, Tool IEGMBEPJMGC)
		{
			return false;
		}

		private bool ODPFFNEOKBC(GameRole EEEEDBEAPLM, Tool IEGMBEPJMGC)
		{
			return false;
		}

		private bool LALJFFOOBOE(GameRole EEEEDBEAPLM, Tool IEGMBEPJMGC)
		{
			return false;
		}

		public bool RemapSpawnedRoleNodes(GAMIBKOFAAE KDOHOHMMADB, global::PHLHFLLLDLK<CreationManager.ALEFKNOEIAL> BOJDPAGLBLI, [CanBeNull] out List<OELBDAKHAFC> FJINHFNOCIF, [CanBeNull] out List<GameRole> DJAMPGEGOAB)
		{
			FJINHFNOCIF = null;
			DJAMPGEGOAB = null;
			return false;
		}

		public static bool TryGetPredefinedRoleGuid(KLNOBKBCIEK HGBHOJBMCCA, out Guid FFCOAFGMJML)
		{
			FFCOAFGMJML = default;
			return false;
		}

		public static Guid BackCompatStringGuidParse(KLNOBKBCIEK HGBHOJBMCCA, [CanBeNull] string DBMEIKJOBJN)
		{
			return default;
		}

		public void MasterUpdateRoleDefinition(KLNOBKBCIEK IGPABPDIFEM, AIKGLCGDKBM AOEBHAKBIPH, Guid? IHPBMOEDOHG = null)
		{
		}

		[CompilerGenerated]
		private void GKAALDPMIKM()
		{
		}
	}
}
