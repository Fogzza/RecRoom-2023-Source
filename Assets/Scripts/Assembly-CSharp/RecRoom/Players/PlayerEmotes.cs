using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.VFX;
using TMPro;
using UnityEngine;

namespace RecRoom.Players
{
	public class PlayerEmotes : MonoBehaviourPun
	{
		public enum PDHFIKBMGOD : short
		{
			None = -1,
			Happy = 0,
			Love = 1,
			Laugh = 2,
			TongueOut = 3,
			Wink = 4,
			Smirk = 5,
			SmileSweat = 10,
			Grimacing = 11,
			Shocked = 12,
			Thinking = 13,
			Sleeping = 14,
			Sad = 20,
			Angry = 21,
			Nauseated = 22,
			Flat = 23,
			Smile = 100
		}

		public class HKJPEMJJBKG
		{
			private const float HBAMDNOKGCB = 10f;

			public int GIJKOGICCME;

			public string AEOEHOEMLAH;

			public float IFPOPBDJNFF;

			public string OFCFPGACNJB;

			public FontStyles IECPKMLJDCJ;

			public Sprite AELLMDBMCBO;

			public float BJMEEKBCMPO;

public bool EKHHECKJIIO
{
get 			{
				return false;
			}

}

public bool DJDIOKGMOCG
{
get 			{
				return false;
			}

}

			public HKJPEMJJBKG(int GIJKOGICCME, string AEOEHOEMLAH, string OFCFPGACNJB = null, Sprite AELLMDBMCBO = null, FontStyles IECPKMLJDCJ = FontStyles.Normal, float IFPOPBDJNFF = 0f)
			{
			}

			public HKJPEMJJBKG(Player OICIEBNNHFC, string OFCFPGACNJB = null, Sprite AELLMDBMCBO = null, FontStyles IECPKMLJDCJ = FontStyles.Normal, float IFPOPBDJNFF = 0f)
			{
			}
		}

		private sealed class BHLNIMPPEMJ
		{
			public PlayerEmotes _003C_003E4__this;

			public Color cachedChatBubbleSpriteColor;

			public Color cachedChatBubbleTextColor;

			internal Color _003CRunShowChatMessage_003Eb__0()
			{
				return default;
			}

			internal void _003CRunShowChatMessage_003Eb__1(Color value)
			{
			}

			internal Color _003CRunShowChatMessage_003Eb__2()
			{
				return default;
			}

			internal void _003CRunShowChatMessage_003Eb__3(Color value)
			{
			}

			internal void _003CRunShowChatMessage_003Eb__4()
			{
			}
		}

		private sealed class CACLJDDIANI : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerEmotes _003C_003E4__this;

			public string message;

			public bool playAudioForLocalPlayer;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public CACLJDDIANI(int _003C_003E1__state)
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
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class JEEPIGNNLHP : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerEmotes _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public JEEPIGNNLHP(int _003C_003E1__state)
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
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class OPCKEOOKPAE
		{
			public PlayerEmotes _003C_003E4__this;

			public bool playAudioForLocalPlayer;

			internal void _003CSendChatEmoteCoroutine_003Eb__1(GMBCDOMHMFF.CNIHIHBNGBO purifyResult)
			{
			}
		}

		private sealed class DIFKOCJCMNE : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerEmotes _003C_003E4__this;

			public bool playAudioForLocalPlayer;

			public string message;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public DIFKOCJCMNE(int _003C_003E1__state)
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
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class OGCEMHGDLJE : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public PlayerEmotes _003C_003E4__this;

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
			public OGCEMHGDLJE(int _003C_003E1__state)
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

		private sealed class FINGBGCEPEJ
		{
			public int? playerId;

			internal bool _003COnRelationshipUpdated_003Eb__0(HKJPEMJJBKG entry)
			{
				return false;
			}
		}

		private const float NDNHAANNLOH = 30f;

		private const int GINBEGANGFA = 18;

		private static Regex DMGEBFDMBLP;

		public static readonly global::BPEPJJDICII<PDHFIKBMGOD, string> LocalSendChatEmoteEvent;

		private static Dictionary<PDHFIKBMGOD, Sprite> CABFDNEJHOP;

		[SerializeField]
		private GameObject chatBubble;

		[SerializeField]
		private JitteringTransform jitteringTransform;

		[SerializeField]
		private TMP_Text chatBubbleText;

		[SerializeField]
		private SpriteRenderer chatBubbleSprite;

		[SerializeField]
		private float chatBubbleDuration;

		[SerializeField]
		private float chatBubbleScaleUpTweenDuration;

		[SerializeField]
		private float chatBubbleFadeOutDuration;

		[SerializeField]
		private Color chatBubbleFadedOutColor;

		[SerializeField]
		private GameObject typingBubble;

		[SerializeField]
		private RecRoomAudioClip localChatSFX;

		[SerializeField]
		private RecRoomAudioClip chatSFX;

		[SerializeField]
		private AudioRolloff chatSFXCustomRolloff;

		[SerializeField]
		private RecRoomAudioClip[] typingSFXs;

		[SerializeField]
		private float minDelayBetweenTypingSFX;

		[SerializeField]
		private float maxDelayBetweenTypingSFX;

		[SerializeField]
		private float minTypingSFXPitchOffset;

		[SerializeField]
		private float maxTypingSFXPitchOffset;

		[SerializeField]
		private Player player;

		private bool NCIBNGDACPP;

		private global::AFHOAHNAMGF<int> CHJLPOOJBEB;

		private Vector3 DCMBDOMGFAA;

		private Coroutine JEIINLBKKIM;

		private Coroutine BFKHJIDOBLI;

		private int LDJDNPGDEHN;

		private KGLJAGOGBNM HCBBDNGKDCO;

		private global::MOBDJNEDDKC<bool> MNIHCHCLAMN;

		private Coroutine CNEPECGOANL;

		public const int CHAT_BUFFER_SIZE = 20;

		private static readonly List<HKJPEMJJBKG> ELILONODIKN;

		private static int IGFCOGKECOM;

		public static global::HHOBPMOCKMJ<int> PlayerMessagesScrubbedEvent;

private static Dictionary<PDHFIKBMGOD, Sprite> GHGLHKMAFPH
{
get 		{
			return null;
		}

}

public bool UsingEmoteBubble
{
get 		{
			return false;
		}

set {
		}
}

private int LAOAJMMPCFA
{
get 		{
			return 0;
		}

}

public bool IsSendChatOnCooldown
{
get 		{
			return false;
		}

}

private Vector3 KNAOOOHFEGL
{
get 		{
			return default;
		}

set {
		}
}

public bool IsTyping
{
get 		{
			return false;
		}

set {
		}
}

private bool IEGECDLHBGA
{
get 		{
			return false;
		}

}

public IReadOnlyList<HKJPEMJJBKG> ChatBuffer
{
get 		{
			return null;
		}

}

public static int TotalChatMessagesReceived
{
get 		{
			return 0;
		}

private set {
		}
}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void KEBGHBBEDCI()
		{
		}

		public void AddMaxMessagesPerTrackingPeriod(int IPMIIEAGJKC, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveMaxMessagesPerTrackingPeriod(object IALNODEHBNN)
		{
		}

		public void LocalEmote(PDHFIKBMGOD ABDDCLHIIHG = PDHFIKBMGOD.None, string DELCOFCGDFF = null)
		{
		}

		public void LocalSendChatMessage(string OFCFPGACNJB, bool FBKJMNAHODH, bool HBEABHHPBHH)
		{
		}

		private void KBBIAFCEGHN(string OFCFPGACNJB, bool FBKJMNAHODH)
		{
		}

		private IEnumerator EFGIEFLKEFA(string OFCFPGACNJB, bool FBKJMNAHODH)
		{
			return null;
		}

		private void NJGAJNJFBIH()
		{
		}

		private IEnumerator IJBGHLKIIDF()
		{
			return null;
		}

		private void INKJNBNKCNJ(string OFCFPGACNJB, bool FBKJMNAHODH)
		{
		}

		private IEnumerator MGBJIJOPHIE(string OFCFPGACNJB, bool FBKJMNAHODH)
		{
			return null;
		}

		private static string PKIOPGNEIAP(string MJNOINEGKPH)
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> FAMJALHMGDH()
		{
			return null;
		}

		private void CKJPMEMNMNO(ref string OFCFPGACNJB)
		{
		}

		[PBOMGCLBFHF]
		private void RpcChatMessage(string OFCFPGACNJB)
		{
		}

		private void ADLPLJDPNCH(string OFCFPGACNJB, bool FBKJMNAHODH)
		{
		}

		[PBOMGCLBFHF]
		private void RpcChatEmoji(int ABDDCLHIIHG)
		{
		}

		private void HEEPKPMNGGA(PDHFIKBMGOD ABDDCLHIIHG)
		{
		}

		public static void ClearRoomChatHistory()
		{
		}

		public void ReceiveBroadcastRoomChat(int PCKCPNGPNBJ, string KKMCHAOLGFB, PDHFIKBMGOD ABDDCLHIIHG, string OFCFPGACNJB)
		{
		}

		public void ReceiveRoomChat(HKJPEMJJBKG KLMCNEIFLMA)
		{
		}

		private void DMJCFAGGKOF()
		{
		}

		private void CDBBOHBGNNP(int? PCKCPNGPNBJ)
		{
		}
	}
}
