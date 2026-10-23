using System;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using RecRoom.Core.DataStructures;
using UnityEngine;

namespace RecRoom.Tools
{
	[DisallowMultipleComponent]
	public sealed class ToolEntity : MonoBehaviourPun, DJLCHGFCFAD, JICDMECOFLC
	{
		public enum PFINPDKHKEP
		{
			RESPAWN = 0,
			DISABLE = 1,
			DESTROY = 2
		}

		private static readonly List<ToolEntity> CHNHJOCPIAP;

		private static Action<ToolEntity> LGEDDKHMLGF__BackingField;

		private static Action<ToolEntity> GCDDHLBJEGN__BackingField;

		[SerializeField]
		private Tool mainTool;

		[SerializeField]
		private bool canBeHiddenDuringGames;

		[SerializeField]
		private bool defaultHiddenDuringGames;

		private global::MOBDJNEDDKC<bool> AIHBDAFBENH;

		[SerializeField]
		private ToolHierarchyCache toolHierarchyCache;

		private static global::AFHOAHNAMGF<PFINPDKHKEP> POJFLJOEOCH;

		private global::AFHOAHNAMGF<PFINPDKHKEP> LBOOOGHGFDK;

public static IReadOnlyList<ToolEntity> AllToolEntities
{
get 		{
			return null;
		}

}

public Tool MainTool
{
get 		{
			return null;
		}

}

public bool HiddenDuringGames
{
get 		{
			return false;
		}

set {
		}
}

public ToolHierarchyCache ToolHierarchyCache
{
get 		{
			return null;
		}

}

public static PFINPDKHKEP ActiveBrokenBehavior
{
get 		{
			return PFINPDKHKEP.RESPAWN;
		}

}

public PFINPDKHKEP MainToolActiveBrokenBehavior
{
get 		{
			return PFINPDKHKEP.RESPAWN;
		}

}

 bool global::DJLCHGFCFAD.BlockObjectPersistance
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

public static event Action<ToolEntity> ToolEntityAdded {
add {
		}
remove {
		}
}

public static event Action<ToolEntity> ToolEntityRemoved {
add {
		}
remove {
		}
}

		public IReadOnlyList<DGMPBIPKJEB> GetConfigurableDynamicUI(List<JICDMECOFLC> OKGFHDGAPBM = null)
		{
			return null;
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public static void AddBrokenBehavior(PFINPDKHKEP GNLNNDHBBDI, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public static void RemoveBrokenBehavior(object IALNODEHBNN)
		{
		}

		public void AddMainToolBrokenBehavior(PFINPDKHKEP GNLNNDHBBDI, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveMainToolBrokenBehavior(object IALNODEHBNN)
		{
		}

		public void MarkBroken()
		{
		}

		private bool NDFDNHFALGJ()
		{
			return false;
		}

		private void CLBJNIADJDB(bool IPMIIEAGJKC)
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

		private void Reset()
		{
		}
	}
}
