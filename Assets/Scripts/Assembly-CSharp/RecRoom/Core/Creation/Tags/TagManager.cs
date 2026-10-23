using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ExitGames.Client.Photon;
using JetBrains.Annotations;

namespace RecRoom.Core.Creation.Tags
{
	public class TagManager : NetworkedSingletonMonoBehaviour<TagManager>, OJIHDJHLFFI
	{
		private class CJIINPNIJJP : IDisposable
		{
			private readonly List<TaggedTool> DJFFNALDGBC;

			private readonly List<TaggedPlayer> ODKJOCGBBLK;

			private readonly int MEHAGOHFJCK;

public bool CLLOAIMMOFB
{
get 			{
				return false;
			}

}

			public CJIINPNIJJP(int MEHAGOHFJCK)
			{
			}

			public void EECCNEJCKAF(TaggedPlayer EKOFNPFCLMO)
			{
			}

			public bool EMINEMIBJPG(TaggedPlayer EKOFNPFCLMO)
			{
				return false;
			}

			public void NBJJCFKNOHP(TaggedTool IEGMBEPJMGC)
			{
			}

			public bool ALPDHAGGMDE(TaggedTool IEGMBEPJMGC)
			{
				return false;
			}

			public TaggedTool BPFFCDHHPAF()
			{
				return null;
			}

			private void IFDNMKLGBBB(Tool PMEFICGEDFK)
			{
			}

			private void IEEMPDGOMKG(TaggedTool CMBMOBEBGIN)
			{
			}

			public IReadOnlyList<TaggedTool> MDDHNGGKCKD()
			{
				return null;
			}

			public IReadOnlyList<TaggedPlayer> FKFNMJIKNHB()
			{
				return null;
			}

			public void Dispose()
			{
			}
		}

		private sealed class PACKCNLGPKA
		{
			public GMJGFOEIDJB map;

			internal object _003CCreateTagIndicesList_003Eb__0()
			{
				return null;
			}
		}

		private sealed class IPLHMGOIFPN
		{
			public global::IDEIBFFIHHC<string>.PMJFLPOGIBH[] tagPairs;

			internal object _003CRemoteSetRuntimeTags_003Eb__0()
			{
				return null;
			}
		}

		private sealed class ABNPENIGPHJ
		{
			public global::IDEIBFFIHHC<string>.PMJFLPOGIBH tagFromMaster;

			internal object _003CRemoteSetRuntimeTags_003Eb__1()
			{
				return null;
			}
		}

		private sealed class LDLBNHGKIJP : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public TagManager _003C_003E4__this;

			private float _003Ctimeout_003E5__2;

			private float _003CnextLog_003E5__3;

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
			public LDLBNHGKIJP(int _003C_003E1__state)
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

		public const int MAX_TAG_NAME_LENGTH = 25;

		private const int JAEKDOEBFBF = 12;

		private static readonly List<TaggedTool> NMLNKFOGOEE;

		private static readonly List<TaggedPlayer> NNKOCLFIJNC;

		private int ANECHPELMKA;

		private GMJGFOEIDJB KHBODHOAHHH;

		private readonly Dictionary<int, CJIINPNIJJP> IBDPMKOODNK;

		private global::MOBDJNEDDKC<int> LFKADEMLHCF;

		private bool MFAFCOGHMMA;

		private LKDMDLACMHN KLPJCNPJHEA;

		private LKGILLBEJEK GIPNPNJPOOF;

		[NotNull]

private GMJGFOEIDJB HJMJBDDGCAE
{
get 		{
			return null;
		}

}

public int MasterTagManagerHash
{
get 		{
			return 0;
		}

set {
		}
}

public int LocalTagManagerHash
{
get 		{
			return 0;
		}

}

public GKDCHLMLHBJ PersistableRunFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

		protected override void Awake()
		{
		}

		public void MarkReady()
		{
		}

		private void HADBNNANGFK()
		{
		}

		private static GMJGFOEIDJB CLINFEPINLJ(out int MHFIMEMBPFB)
		{
			MHFIMEMBPFB = default;
			return null;
		}

		protected override void OnDestroy()
		{
		}

		public global::IDEIBFFIHHC<string>.PMJFLPOGIBH[] GetRuntimeTagDelta()
		{
			return null;
		}

		private void OnPhotonPlayerConnected(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private void OnMasterClientSwitched(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		public static string FormatTag(string AHNIMJDLOPB)
		{
			return null;
		}

		public string GetTag(int MEHAGOHFJCK)
		{
			return null;
		}

		public int GetTagId(string AHNIMJDLOPB)
		{
			return 0;
		}

		public int GetTagOrAssumeMasterAndAddTag(string AHNIMJDLOPB)
		{
			return 0;
		}

		private int CDHKGLPCAFJ(string AHNIMJDLOPB)
		{
			return 0;
		}

		private void DELOKFONDGJ(string AHNIMJDLOPB, int IKHNIJKGJFD)
		{
		}

		public TaggedTool GetLeastRecentlyUsedTool(string AHNIMJDLOPB)
		{
			return null;
		}

		public TaggedTool GetLeastRecentlyUsedTool(int MEHAGOHFJCK)
		{
			return null;
		}

		public IReadOnlyList<TaggedTool> GetToolsWithTag(string AHNIMJDLOPB)
		{
			return null;
		}

		public IReadOnlyList<TaggedTool> GetToolsWithTag(int IKHNIJKGJFD)
		{
			return null;
		}

		public IReadOnlyList<TaggedPlayer> GetPlayersWithTag(string AHNIMJDLOPB)
		{
			return null;
		}

		public IReadOnlyList<TaggedPlayer> GetPlayersWithTag(int IKHNIJKGJFD)
		{
			return null;
		}

		public void AddTagUsage(TaggedEntity LHCPLOHKBCE, int IKHNIJKGJFD)
		{
		}

		public void RemoveTagUsage(TaggedEntity LHCPLOHKBCE, int IKHNIJKGJFD)
		{
		}

		private CJIINPNIJJP CDDNAKENMOA(int MEHAGOHFJCK, bool MKMGFBMPMFJ)
		{
			return null;
		}

		[PBOMGCLBFHF]
		private void RemoteAddTag(string AHNIMJDLOPB, int IKHNIJKGJFD)
		{
		}

		[PBOMGCLBFHF]
		private void RemoteSetRuntimeTags(global::IDEIBFFIHHC<string>.PMJFLPOGIBH[] ODOOHJAKHIE, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		public static short SerializeTagPair(StreamBuffer HLHADAOGCMN, object NKGPKKEPKLJ)
		{
			return 0;
		}

		public static object DeserializeTagPair(StreamBuffer FAMJGEFEDDM, short MNKGPEKFPKK)
		{
			return null;
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

		private void NHCECJOIBHK()
		{
		}

		private void JBCEMBFKLHF()
		{
		}

		private IEnumerator<EGGPGCCKPCO> DJBHOPGGJPA()
		{
			return null;
		}

		[CompilerGenerated]
		private bool OBFMPFDMNLE(global::IDEIBFFIHHC<string>.PMJFLPOGIBH IHPJCBCPLCM)
		{
			return false;
		}
	}
}
