using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CodeStage.AntiCheat.ObscuredTypes;
using Google.Protobuf;
using JetBrains.Annotations;
using UnityEngine;

namespace RecRoom.Systems.PlayerRoles
{
	public abstract class RoleManagerBase<RoleIdType, RolePermissionType, RoleDefinitionType, RoleProtobufType, RoleCollectionProtobufType> : NetworkedSingletonMonoBehaviour<RoleManagerBase<RoleIdType, RolePermissionType, RoleDefinitionType, RoleProtobufType, RoleCollectionProtobufType>>, OJIHDJHLFFI where RoleIdType : struct where RolePermissionType : struct where RoleDefinitionType : class, global::AKONKDAAJPG<RoleIdType, RolePermissionType, RoleDefinitionType>, global::DHKBMLGGKMJ<RoleProtobufType, RoleIdType>, new() where RoleProtobufType : IMessage<RoleProtobufType> where RoleCollectionProtobufType : IMessage<RoleCollectionProtobufType>
	{
		public delegate RoleDefinitionType LMDDCBGDOBO(int GEHNEOOGNLP, RoleDefinitionType OEJILPJHPPG);

		protected abstract class BOMHDJABLNJ
		{
			protected readonly CHILKDJABBF FBCDJHOIDJJ;

			private const float CEAKNHPNJBF = -1f;

			private double PLJIGGDHPHM;

			private Action<CHILKDJABBF, int> OBPGGJDALJG__BackingField;

public abstract string DMABHJFKLPH
{
get ;
}

public int PJIMJIGLPKH
{
get 			{
				return 0;
			}

}

public event Action<CHILKDJABBF, int> OBPGGJDALJG {
add {
			}
remove {
			}
}

			protected BOMHDJABLNJ(CHILKDJABBF FBCDJHOIDJJ)
			{
			}

			protected abstract int LJACLCKKEAA();

			public void FFCEGNOJJPO(int PIBNPPAEMEN)
			{
			}

			protected abstract void AIKACFDHMFC(int PIBNPPAEMEN);

			public bool DNGNJEHMDKM(int KLBONOOHBND)
			{
				return false;
			}

			internal bool BBIKMCDMKBE(int IONHDNGPMKD)
			{
				return false;
			}

			internal bool IJBIDKEOCAF(int KMMLJACCLKF)
			{
				return false;
			}

			internal bool COEBOJFHLPE(int[] LIBJCAGDOIK, int[] FNPJCDEDLLG)
			{
				return false;
			}

			internal bool KHHLKBAPECH(int HGBKLDMPIMA)
			{
				return false;
			}

			internal void GLBPPAIACJF()
			{
			}

			protected void FHAKCBOGNAN()
			{
			}

			private static string MGBCLJBOCJF(int LGEIKKCKJHH)
			{
				return null;
			}

			public override string ToString()
			{
				return null;
			}
		}

		public delegate bool ALPGGJMGKNA(RoleDefinitionType DGNFCCOMMEL);

		private sealed class NODMDDLNNHG
		{
			public RoleManagerBase<RoleIdType, RolePermissionType, RoleDefinitionType, RoleProtobufType, RoleCollectionProtobufType> _003C_003E4__this;

			public int everyoneRoleId;

			internal bool _003CUpdatePredefinedRoles_003Eb__0(RoleDefinitionType r)
			{
				return false;
			}
		}

		private sealed class HMJIFKOELJM
		{
			public bool reverseOrder;

			internal int _003CGetSortedActiveRoles_003Eb__0(RoleDefinitionType roleA, RoleDefinitionType roleB)
			{
				return 0;
			}
		}

		private sealed class FKBLCCCACAJ : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public RoleManagerBase<RoleIdType, RolePermissionType, RoleDefinitionType, RoleProtobufType, RoleCollectionProtobufType> _003C_003E4__this;

			private int _003ChitCount_003E5__2;

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
			public FKBLCCCACAJ(int _003C_003E1__state)
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

		private sealed class EHHKJCFBGDC
		{
			public KLKONHGPFBD rank;

			public int indexOffset;

			internal bool _003CGetNextRole_003Eb__1(RoleDefinitionType r)
			{
				return false;
			}
		}

		public static global::HHOBPMOCKMJ<RoleDefinitionType> OnRoleDefinitionUpdatedEvent;

		public static EEANDDJEMJC OnRoleOrdersChangedEvent;

		public static global::BPEPJJDICII<CHILKDJABBF, RoleDefinitionType> OnPlayerRoleDefinitionUpdatedEvent;

		[SerializeField]
		private RoleDefinitionType _defaultRoleDefinition;

		private readonly global::AFHOAHNAMGF<RoleDefinitionType> LCMLEAGBCJL;

		private readonly Dictionary<CHILKDJABBF, RoleDefinitionType> DPFFHDHAFGJ;

		private readonly Dictionary<RoleIdType, RoleDefinitionType> DICLJEBEKAA;

		protected bool LHEENDCGLJD;

		private readonly Dictionary<int, BOMHDJABLNJ> PGABNEAKKBC;

		[SerializeField]
		[EFEFIKFHIDK]
		private List<RoleDefinitionType> localPlayerSortedRoleDefinitions;

		[SerializeField]
		[EFEFIKFHIDK]
		private RoleDefinitionType _cachedLocalPlayerRoleDefinition;

		[SerializeField]
		[EFEFIKFHIDK]
		protected List<RoleDefinitionType> allSortedActiveRoleDefinitions;

		private global::JPEBBAFCBEP<bool, int> HHMEFGPJBCC;

		private ObscuredLong MIDHNDGKEIG;

		private LKDMDLACMHN KLPJCNPJHEA;

		private LKGILLBEJEK GIPNPNJPOOF;

		private bool MONGPNCOGFA;

		private readonly Dictionary<int, global::JPEBBAFCBEP<bool, int>> PNAKECLOJMN;

private static IILDCCEMGBA DAFPCOCAEOE
{
get 		{
			return null;
		}

}

protected abstract string MEDNJPBFPHJ
{
get ;
}

protected abstract int[] MGBICHKPPLO
{
get ;
}

public RoleDefinitionType DefaultRoleDefinition
{
get 		{
			return null;
		}

}

private RoleDefinitionType OFBOJLELFGJ
{
get 		{
			return null;
		}

}

protected abstract bool KAHBGMLIBFH
{
get ;
}

public RoleDefinitionType CachedLocalPlayerRoleDefinition
{
get 		{
			return null;
		}

private set {
		}
}

public int? CurrentSyncedAuthorityHash
{
get 		{
			return null;
		}

}

public int? CurrentLocalHash
{
get 		{
			return null;
		}

}

public GKDCHLMLHBJ PersistableRunFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

		public void AddEveryoneRoleDefinition(RoleDefinitionType IPMIIEAGJKC, object IALNODEHBNN, HOPIACLIGJO LAGADKBKLAD)
		{
		}

		public void RemoveEveryoneRoleDefinition(object IALNODEHBNN)
		{
		}

		protected abstract int NNOCEPGBMCN(RoleIdType GEHNEOOGNLP);

		protected abstract RoleIdType PILEMGJCONO(int GEHNEOOGNLP);

		protected abstract int[] GLAPBDDPFAH(RoleIdType[] GEHNEOOGNLP);

		protected abstract bool BEIKFGGJCKL(int GEHNEOOGNLP);

		protected abstract RoleDefinitionType CJODINCHEEE(int CJFOLKFCHOA, RoleDefinitionType OEJILPJHPPG, string EOJDBMEHCOF = null);

		private bool LOPGPMOPAHI(CHILKDJABBF EKOFNPFCLMO, out BOMHDJABLNJ KLBONOOHBND)
		{
			KLBONOOHBND = null;
			return false;
		}

		protected abstract BOMHDJABLNJ AMMCIDBFDCB(CHILKDJABBF EKOFNPFCLMO);

		protected virtual RoleIdType MFGFFOAPBKA(CHILKDJABBF EKOFNPFCLMO)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RequestAddRole(JEGAPHLGBJA GCBHEJANCJK, CHILKDJABBF EKOFNPFCLMO, RoleIdType KLBONOOHBND)
		{
			return default;
		}

		[PBOMGCLBFHF]
		protected void RpcPlayerCV2AddRole(int KLBONOOHBND)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RequestRemoveRole(JEGAPHLGBJA GCBHEJANCJK, CHILKDJABBF EKOFNPFCLMO, RoleIdType KLBONOOHBND)
		{
			return default;
		}

		[PBOMGCLBFHF]
		protected void RpcPlayerCV2RemoveRole(int KLBONOOHBND)
		{
		}

		public void RequestAddRole(CHILKDJABBF EKOFNPFCLMO, RoleIdType LDDMEHOCGJB)
		{
		}

		public void RequestRemoveRole(CHILKDJABBF EKOFNPFCLMO, RoleIdType KJAANJAJJOF)
		{
		}

		public void RequestToggleRoles(CHILKDJABBF EKOFNPFCLMO, RoleIdType? LDDMEHOCGJB, RoleIdType? KJAANJAJJOF)
		{
		}

		public void RequestToggleRoles(CHILKDJABBF EKOFNPFCLMO, RoleIdType[] LIBJCAGDOIK, RoleIdType[] FNPJCDEDLLG)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcLocalPlayerToggleRoles(int[] LIBJCAGDOIK, int[] FNPJCDEDLLG)
		{
		}

		protected void GFBPFPJBMFP(RoleIdType PIBNPPAEMEN)
		{
		}

		public void InitializeRoles()
		{
		}

		protected virtual void MPMAGNADBEI()
		{
		}

		public void UpdatePredefinedRoles(List<RoleDefinitionType> INAGMPPHFDI = null)
		{
		}

		protected virtual void CIAHKKLLLJM(ref List<RoleDefinitionType> NKIPFILGHKL)
		{
		}

		private void MBJJANCBHGF(int DELLMPMKLHA, RoleDefinitionType DGNFCCOMMEL)
		{
		}

		protected virtual void OBPGGJDALJG(CHILKDJABBF FBCDJHOIDJJ, int CDBFDJOJHOP)
		{
		}

		public List<RoleDefinitionType> GetSortedActiveRoles(bool HLCLEBMPNME = false)
		{
			return null;
		}

		private void DLFPPDCDNEE()
		{
		}

		public List<RoleDefinitionType> GetSortedActiveRolesForPlayer(CHILKDJABBF EKOFNPFCLMO, bool HLCLEBMPNME = false)
		{
			return null;
		}

		private List<RoleDefinitionType> MJPHJOKFEPP(CHILKDJABBF FBCDJHOIDJJ, bool HLCLEBMPNME)
		{
			return null;
		}

		private List<RoleDefinitionType> HACIELDFMLA()
		{
			return null;
		}

		protected void PBDEOHPOADD()
		{
		}

		protected void PHPNPDKCKIB()
		{
		}

		protected RoleDefinitionType HEICCGCCJPO(CHILKDJABBF EKOFNPFCLMO)
		{
			return null;
		}

		protected abstract void BLPKFCDFBLF(CHILKDJABBF EKOFNPFCLMO, RoleDefinitionType EEEEDBEAPLM);

		public RoleDefinitionType GetEveryoneRoleDefinition()
		{
			return null;
		}

		public RoleDefinitionType GetLocalPlayerRoleDefinition()
		{
			return null;
		}

		public RoleDefinitionType GetPlayerRoleDefinition(CHILKDJABBF EKOFNPFCLMO)
		{
			return null;
		}

		public bool PlayerHasRole(CHILKDJABBF FBCDJHOIDJJ, RoleIdType KLBONOOHBND)
		{
			return false;
		}

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected abstract void DJBNPCBJIFC();

		private global::JPEBBAFCBEP<bool, int> PPAFALIOHCO(CHILKDJABBF EKOFNPFCLMO)
		{
			return null;
		}

		private void OHAHNOOKIEB()
		{
		}

		private IEnumerator<EGGPGCCKPCO> PJKIMJPNKGM()
		{
			return null;
		}

		private bool NOLJDGEOFID(int BEBMLJIDPAP)
		{
			return false;
		}

		private bool LIOEBJOEGGP(int BEBMLJIDPAP)
		{
			return false;
		}

		protected void AIMFIEDFLMH()
		{
		}

		public int CalculateCheckHash()
		{
			return 0;
		}

		protected virtual void INCIIIOGJDD(LDIFNONEEOF NDFMMDHCKFC, RoleDefinitionType BGFEOMKGGDI)
		{
		}

		protected static void NCEOOGKPKCL(LDIFNONEEOF NDFMMDHCKFC, global::PKKINNENDEC<ObscuredBool> GDILAAFFOMI)
		{
		}

		public void RequestPlayerAddRoleToOtherPlayer(CHILKDJABBF EMKHMGLLFIH, CHILKDJABBF FMEPFGGKBIL, RoleIdType LDDMEHOCGJB)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcPlayerAddRoleToLocalPlayer(CHILKDJABBF EMKHMGLLFIH, int LDDMEHOCGJB)
		{
		}

		public void RequestPlayerRemoveRoleFromOtherPlayer(CHILKDJABBF EMKHMGLLFIH, CHILKDJABBF FMEPFGGKBIL, RoleIdType KJAANJAJJOF)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcPlayerRemoveRoleFromLocalPlayer(CHILKDJABBF EMKHMGLLFIH, int KJAANJAJJOF)
		{
		}

		public bool LocalRequestModifyRoleName(RoleIdType GEHNEOOGNLP, string INIOBIJJMJP)
		{
			return false;
		}

		public bool PlayerCanChangeRoleName(CHILKDJABBF EKOFNPFCLMO, RoleIdType GEHNEOOGNLP)
		{
			return false;
		}

		[PBOMGCLBFHF]
		protected void RpcMasterRequestModifyRoleName(RoleIdType GEHNEOOGNLP, string INIOBIJJMJP, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcModifyRoleName(RoleIdType GEHNEOOGNLP, string INIOBIJJMJP, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		public bool LocalRequestModifyRolePermission(RoleIdType GEHNEOOGNLP, RolePermissionType HEGLKMIJHAM, bool FMMJFLMIBAO, object NKBIKBGEKGL)
		{
			return false;
		}

		[PBOMGCLBFHF]
		protected void RpcMasterRequestModifyRoleDefinition(RoleIdType GEHNEOOGNLP, RolePermissionType HEGLKMIJHAM, byte[] HFKIFIEMCKE, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcModifyRoleDefinition(RoleIdType GEHNEOOGNLP, RolePermissionType OAHMEFCIJFN, byte[] HFKIFIEMCKE, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		protected virtual void DKBICFMOECN(RoleDefinitionType KLBONOOHBND, RolePermissionType MIDIGHHKNHJ)
		{
		}

		public void PlayerRequestMoveRole(CHILKDJABBF MCEGNOOCBCN, RoleIdType EJNEHOCOOAD, bool FHKGPLLJFNJ)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcMasterRequestMoveRole(RoleIdType EJNEHOCOOAD, bool FHKGPLLJFNJ, RoleIdType PNBJIHPFGBL, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcSwapRoleOrder(RoleIdType EJNEHOCOOAD, RoleIdType PPLPNNHKDKA, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		public bool CanMoveRole(CHILKDJABBF MCEGNOOCBCN, RoleIdType EJNEHOCOOAD, bool FHKGPLLJFNJ, out RoleDefinitionType LLCICIBAEOC)
		{
			LLCICIBAEOC = null;
			return false;
		}

		public bool TryGetSortedAvailablePlayerRoles(int ALOALHOFNEL, out List<global::HBBHKKBNKHE<RoleIdType, KLKONHGPFBD>> JPDPCLIPFDC)
		{
			JPDPCLIPFDC = null;
			return false;
		}

		private RoleDefinitionType CEKDEHFCDNJ(RoleDefinitionType LBGOJFBCLFI, bool FHKGPLLJFNJ)
		{
			return null;
		}

		protected virtual bool NJDNOPOGCGL(CHILKDJABBF MCEGNOOCBCN, RoleDefinitionType AGEFIBONJHH, RoleDefinitionType LLCICIBAEOC)
		{
			return false;
		}

		public bool MasterForceCreateRole(out Guid HMDBJAAAEHG, out RoleIdType IFEDLMAABPB)
		{
			HMDBJAAAEHG = default;
			IFEDLMAABPB = default;
			return false;
		}

		public bool MasterTryForceCreateRoleWithGuidAndRoleId(Guid HMDBJAAAEHG, RoleIdType PCDEMDBJDNB, out RoleIdType GMDPJAOPNJL)
		{
			GMDPJAOPNJL = default;
			return false;
		}

		public bool RoleGuidExists(Guid JKHAGFEKALE, out RoleIdType DPKMEEGECFL)
		{
			DPKMEEGECFL = default;
			return false;
		}

		[PBOMGCLBFHF]
		protected void RpcAddNewPlayerRole(string DPCMNOBDEDM, RoleIdType GEHNEOOGNLP, Guid JKHAGFEKALE)
		{
		}

		protected virtual bool EMHMEBMKOMP(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		private bool GADLGHNCBEI(out RoleDefinitionType GGKOODHCDNK)
		{
			GGKOODHCDNK = null;
			return false;
		}

		public bool PlayerCanDeleteRole(RoleIdType KMMLJACCLKF, CHILKDJABBF FBCDJHOIDJJ)
		{
			return false;
		}

		public bool LocalRequestDeleteRole(RoleIdType KMMLJACCLKF)
		{
			return false;
		}

		protected virtual void MMOEIHIDECD(RoleIdType KMMLJACCLKF)
		{
		}

		public bool MasterForceDeleteRole(RoleIdType KMMLJACCLKF)
		{
			return false;
		}

		[PBOMGCLBFHF]
		protected void RpcMasterRequestDeleteRole(RoleIdType KMMLJACCLKF, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcDeletePlayerRole(RoleIdType KMMLJACCLKF, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		public abstract bool IsPlayerDefinedRole(RoleIdType GEHNEOOGNLP);

		public bool AnyRole(ALPGGJMGKNA NFBEECABDPJ)
		{
			return false;
		}

		protected void AJKEINIPMEA()
		{
		}

		public RoleDefinitionType FindActiveRoleByName(string DPCMNOBDEDM)
		{
			return null;
		}

		public RoleDefinitionType FindActiveRoleByNameNonAlloc(string DPCMNOBDEDM)
		{
			return null;
		}

		[NotNull]
		public RoleDefinitionType GetRoleDefinition(RoleIdType GEHNEOOGNLP)
		{
			return null;
		}

		public virtual bool PlayerCanModifyRoleDefinition(CHILKDJABBF OONACCDEFKJ, RoleIdType GEHNEOOGNLP)
		{
			return false;
		}

		public virtual bool PlayerCanModifyRolePermission(CHILKDJABBF OONACCDEFKJ, RoleIdType GEHNEOOGNLP, RolePermissionType HEGLKMIJHAM)
		{
			return false;
		}

		public virtual bool PlayerCanAssignRole(CHILKDJABBF EMKHMGLLFIH, CHILKDJABBF FMEPFGGKBIL, RoleIdType GEHNEOOGNLP)
		{
			return false;
		}

		protected KLKONHGPFBD GCDONAHDJMK(CHILKDJABBF EKOFNPFCLMO)
		{
			return KLKONHGPFBD.AG_BOTTOM_RANK_1;
		}

		public KLKONHGPFBD FindRoleRank(RoleIdType GEHNEOOGNLP)
		{
			return KLKONHGPFBD.AG_BOTTOM_RANK_1;
		}

		public string GetAllRolesDebugString(out bool CBIBKIDLPBL)
		{
			CBIBKIDLPBL = default;
			return null;
		}

		private void OnPhotonPlayerConnected(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private void OnPhotonPlayerDisconnected(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private void DHCLMPPFKNJ(int DDDNKOGMKEC)
		{
		}

		private void KJJDGEKIMDK(int DDDNKOGMKEC)
		{
		}

		private void LMOJPGAIODE(CHILKDJABBF MMHMLFJPMDC)
		{
		}

		public void MasterReinitializeRoles()
		{
		}

		[PBOMGCLBFHF]
		protected void RpcReinitializeRoles(byte[] EPPJDIHKINL, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		protected abstract RoleCollectionProtobufType CDHPFHNPMNF(KHMOHFAFGBI KGMPBFBAMCF);

		protected abstract void OKPFLCNHDEN(ref KHMOHFAFGBI KGMPBFBAMCF, RoleCollectionProtobufType ADDBCAECLPO);

		protected void PMCIHFBPKFG(RoleCollectionProtobufType ADDBCAECLPO)
		{
		}

		protected abstract RoleCollectionProtobufType PEMJBNHNHJC(byte[] EPPJDIHKINL);

		protected abstract void CEIFOCHDGLI(RoleCollectionProtobufType ADDBCAECLPO);

		protected abstract RoleCollectionProtobufType LADEHPLDIBE();

		protected virtual void IOOOBCEGAEO(KHMOHFAFGBI KGMPBFBAMCF)
		{
		}

		protected virtual void HMGNFOKBOKA(KHMOHFAFGBI KGMPBFBAMCF)
		{
		}

		protected virtual void GBAHJDOBMPO(ref KHMOHFAFGBI KGMPBFBAMCF)
		{
		}

		private Task CDDPDMKAEJF(KHMOHFAFGBI KGMPBFBAMCF, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		Task OJIHDJHLFFI.DeserializeFrom(KHMOHFAFGBI KGMPBFBAMCF, CancellationToken NDKAKDJMDIF)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CDDPDMKAEJF
			return this.CDDPDMKAEJF(KGMPBFBAMCF, NDKAKDJMDIF);
		}

		private void PEMFPEGCDBN(ref KHMOHFAFGBI KGMPBFBAMCF)
		{
		}

		void OJIHDJHLFFI.SerializeTo(ref KHMOHFAFGBI KGMPBFBAMCF)
		{
			//ILSpy generated this explicit interface implementation from .override directive in PEMFPEGCDBN
			this.PEMFPEGCDBN(ref KGMPBFBAMCF);
		}

		[CompilerGenerated]
		private string KIIHPAFFIDJ(CHILKDJABBF COLMAMKJPJE)
		{
			return null;
		}
	}
}
