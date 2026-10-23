using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Photon.Pun;
using RecRoom.Persistence;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class ObjectGroup : MonoBehaviourPun, DJLCHGFCFAD, LEJOPAFDMEE, DKKOHMDPPEO, AHCBMDMIAAM
	{
		[SerializeField]
		private PersistenceView persistenceView;

		[SerializeField]
		private CreationObject creationObject;

		private DHJLEHBOGBG BMDDJIDADKN;

		private List<Guid> HCPBGJBNJMH;

		protected List<DHJLEHBOGBG> NJIAGGMALFE;

		private List<PersistenceView> DLAEALAIMHE;

		private static readonly HashSet<DHJLEHBOGBG> PFBPGLPPMKL;

		private ObjectGroup MBKHPBPLDBC;

public PersistenceView PersistenceView
{
get 		{
			return null;
		}

}

public DHJLEHBOGBG CreationContextObject
{
get 		{
			return null;
		}

}

public ObjectGroup ParentObjectGroup
{
get 		{
			return null;
		}

set {
		}
}

public IEnumerable<DHJLEHBOGBG> CreationObjectsInGroup
{
get 		{
			return null;
		}

}

public virtual bool AllowUndoOnChildren
{
get 		{
			return false;
		}

}

public virtual bool DeleteChildrenWhenGroupIsDeleted
{
get 		{
			return false;
		}

}

public virtual bool AllowNestedGroups
{
get 		{
			return false;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public virtual GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

public AHCBMDMIAAM ParentGroup
{
get 		{
			return null;
		}

}

public bool IncludeChildrenInTemplate
{
get 		{
			return false;
		}

}

public IEnumerable<DHJLEHBOGBG> ObjectsInGroup
{
get 		{
			return null;
		}

}

public bool SupportsExtractingToParent
{
get 		{
			return false;
		}

}

		protected virtual void MGJAHJFDEDJ()
		{
		}

		public bool AddToGroup(DHJLEHBOGBG BPEGJLIMPPJ, bool HNPCPEMIKNB)
		{
			return false;
		}

		public virtual bool AddCreationObjectToGroup(DHJLEHBOGBG BPEGJLIMPPJ, bool HNPCPEMIKNB)
		{
			return false;
		}

		public virtual bool AddCreationObjectsToGroup(IEnumerable<DHJLEHBOGBG> DGCKCDACDNM, bool LAEPMFGPFIC)
		{
			return false;
		}

		[PBOMGCLBFHF]
		protected void RpcAddToGroup(MonoBehaviour ANIDFMMGDIH, bool HNPCPEMIKNB)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcAddListToGroup(List<MonoBehaviour> GMOEAJEOJBG, bool LAEPMFGPFIC)
		{
		}

		protected virtual void HLANMBNHGMJ(DHJLEHBOGBG BPEGJLIMPPJ, bool HNPCPEMIKNB)
		{
		}

		protected virtual void HHPNCBDPCMC(DHJLEHBOGBG BPEGJLIMPPJ, bool HNPCPEMIKNB)
		{
		}

		public virtual bool ExtractCreationObjectToParentGroupOrRoot(DHJLEHBOGBG BPEGJLIMPPJ)
		{
			return false;
		}

		public virtual bool ExtractCreationObjectsToParentGroupOrRoot(IEnumerable<DHJLEHBOGBG> DGCKCDACDNM)
		{
			return false;
		}

		[PBOMGCLBFHF]
		protected void RpcExtractToParentGroupOrRoot(MonoBehaviour ANIDFMMGDIH)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcExtractListToParentGroupOrRoot(List<MonoBehaviour> GMOEAJEOJBG)
		{
		}

		protected void MCECHJBEBNN()
		{
		}

		protected virtual void ALHGNEJNDIJ(DHJLEHBOGBG BPEGJLIMPPJ)
		{
		}

		public virtual bool RemoveCreationObjectFromAllGroups(DHJLEHBOGBG BPEGJLIMPPJ)
		{
			return false;
		}

		public virtual bool RemoveCreationObjectsFromAllGroups(IEnumerable<DHJLEHBOGBG> DGCKCDACDNM)
		{
			return false;
		}

		public virtual void RemoveAllObjectsFromGroup()
		{
		}

		public virtual void DeleteAllObjectsInGroup()
		{
		}

		public virtual void PrepForSerialization()
		{
		}

		protected virtual bool DDGKJEBOBNJ(DHJLEHBOGBG BPEGJLIMPPJ, bool HNPCPEMIKNB, out string LOKKJFCDNHB)
		{
			LOKKJFCDNHB = null;
			return false;
		}

		protected virtual bool MJIJEOKPFHN(DHJLEHBOGBG BPEGJLIMPPJ, out string LOKKJFCDNHB)
		{
			LOKKJFCDNHB = null;
			return false;
		}

		protected virtual void JEIABLCFFHE(DHJLEHBOGBG BPEGJLIMPPJ)
		{
		}

		protected virtual void OMFACCPMLAJ(DHJLEHBOGBG BPEGJLIMPPJ)
		{
		}

		protected void HNEBLODMFFM(DHJLEHBOGBG ICHBECDKHOJ, ObjectGroup DLPJOIPNLKG)
		{
		}

		public virtual void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		protected void JBNHDPNNNAD(IMFIBJPNBHM IJPJHBPHBJO)
		{
		}

		public virtual void PostDeserialize(GNFJMCHKBIK ALCJDCGEBLM)
		{
		}

		protected virtual void KAEOCFDMLDI()
		{
		}

		public Task PreSerializeAsync(StringBuilder AAMCGPPJPFM, APFHIIGOAJG LJBOPGAFHIA, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		public virtual void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		protected IMFIBJPNBHM JMKFJPKBAOE()
		{
			return null;
		}

		private bool MJCGEFAHDBM(IEnumerable<DHJLEHBOGBG> DGCKCDACDNM)
		{
			return false;
		}

		public DHJLEHBOGBG AsContextObject()
		{
			return null;
		}

		public virtual bool Contains(DHJLEHBOGBG GLHOACNHHMF)
		{
			return false;
		}

		public virtual void OnGroupPushed()
		{
		}

		public virtual void OnGroupPopped()
		{
		}

		public void OnObjectsInGroupWillBeDeleted(IEnumerable<DHJLEHBOGBG> JNCAMPHBDNO)
		{
		}

		public bool ExtractToParentGroupOrRoot(DHJLEHBOGBG GLHOACNHHMF)
		{
			return false;
		}

		public bool ExtractToParentGroupOrRoot(IEnumerable<DHJLEHBOGBG> JNCAMPHBDNO)
		{
			return false;
		}

		public void RenderWorldFadeMask()
		{
		}
	}
}
