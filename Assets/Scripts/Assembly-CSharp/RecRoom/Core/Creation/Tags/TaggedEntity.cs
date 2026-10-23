using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;

namespace RecRoom.Core.Creation.Tags
{
	public abstract class TaggedEntity : MonoBehaviourPun, DJLCHGFCFAD
	{
		private sealed class OFNCBBNLGLB
		{
			public IEnumerable<int> tagsToDelete;

			internal bool _003CMasterRemoveTags_003Eb__1(int i)
			{
				return false;
			}
		}

		private sealed class ILPDDAGJJKF : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public TaggedEntity _003C_003E4__this;

			public int[] tagIds;

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
			public ILPDDAGJJKF(int _003C_003E1__state)
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

		public static readonly string SPAWN_TAGS_PARAM;

		public const int MAX_TAGS = 5;

		private bool LNLFHPHPGPP;

		private int[] OJMMIMDBIKF;

		private int[] DBGOKKIOMMC;

		private global::MOBDJNEDDKC<int[]> JNMCNFNMPKO;

		private string[] IHBOHJFOHAL;

		protected string KFOOKDLMDFM;

private int[] NCIKPFEDOKN
{
get 		{
			return null;
		}

set {
		}
}

public IReadOnlyList<string> DisplayTags
{
get 		{
			return null;
		}

}

public virtual string PortName
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

		protected virtual void Start()
		{
		}

		protected abstract int[] FEBLFFDFGPG();

		protected override void OnDestroy()
		{
		}

		private void NBMABGKKKKO()
		{
		}

		public bool HasTag(string AHNIMJDLOPB)
		{
			return false;
		}

		private bool JDMLGIFMNKM(string AHNIMJDLOPB, out int MEHAGOHFJCK)
		{
			MEHAGOHFJCK = default;
			return false;
		}

		public void RequestAddTag(string AHNIMJDLOPB)
		{
		}

		private string[] IDIPCIHIKEM(IEnumerable<string> CMBMOBEBGIN, out int NLDDKDCOLAG)
		{
			NLDDKDCOLAG = default;
			return null;
		}

		public void RequestAddTags(IEnumerable<string> CMBMOBEBGIN)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RequestAddTags(JEGAPHLGBJA GCBHEJANCJK, List<string> CMBMOBEBGIN)
		{
			return default;
		}

		private string[] JAABDKHGPGC(IEnumerable<string> CMBMOBEBGIN)
		{
			return null;
		}

		public void RequestRemoveTags(IEnumerable<string> CMBMOBEBGIN)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RequestRemoveTags(JEGAPHLGBJA GCBHEJANCJK, IEnumerable<string> CMBMOBEBGIN)
		{
			return default;
		}

		public void ResetTags()
		{
		}

		public void RemoveTag(string AHNIMJDLOPB)
		{
		}

		protected virtual void AOEBHOLJOOG(int[] NCILFPAEEFF, int[] NLFNGFDOCCP)
		{
		}

		public void CopyTags(TaggedTool CKOEFCDNGOI)
		{
		}

		private bool CFOAFOKJDOD(string AHNIMJDLOPB)
		{
			return false;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RequestAddTag(JEGAPHLGBJA GCBHEJANCJK, string AHNIMJDLOPB)
		{
			return default;
		}

		[PBOMGCLBFHF]
		protected void RpcMasterCV2AddTag(string AHNIMJDLOPB)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RequestRemoveTag(JEGAPHLGBJA GCBHEJANCJK, string AHNIMJDLOPB)
		{
			return default;
		}

		[PBOMGCLBFHF]
		protected void RpcMasterCV2RemoveTag(string AHNIMJDLOPB)
		{
		}

		[PBOMGCLBFHF]
		protected void MasterAddTags(string[] CMBMOBEBGIN)
		{
		}

		[PBOMGCLBFHF]
		protected void MasterRemoveTags(string[] CMBMOBEBGIN)
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

		private IEnumerator<EGGPGCCKPCO> KJCIKOPKLPD(int[] DAJKDEBKGKK)
		{
			return null;
		}

		private void NPJBEOAIFFL(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		void DJLCHGFCFAD.SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NPJBEOAIFFL
			this.NPJBEOAIFFL(ref FCJBDJOMIHI, ref JIEECFLEPDI, AAMCGPPJPFM);
		}

		[CompilerGenerated]
		private bool CLMAIPCOCBE()
		{
			return false;
		}
	}
}
