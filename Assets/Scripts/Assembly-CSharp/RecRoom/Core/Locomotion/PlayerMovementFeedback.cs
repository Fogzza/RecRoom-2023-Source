using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Core.Locomotion
{
	public class PlayerMovementFeedback : MonoBehaviourPun
	{
		public delegate void GCOKJNJDOPD(Player EKOFNPFCLMO, Vector3 OJJNPNOEJDC, Vector3 NHOAENGJMLK);

		[Serializable]
		public struct WindLineVFXSettings
		{
			public float emissionRateMultiplier;

			public float startSpeed;

			public Color startColor;

			public float trailLifetime;

			public static WindLineVFXSettings LCPAMALNCPJ(WindLineVFXSettings BLFKABPCHLN, WindLineVFXSettings NPFMAENOPCH, float IHPJCBCPLCM)
			{
				return default;
			}

			public static void KNBEJMBKOGG(ParticleSystem BENMDFOMAME, WindLineVFXSettings CAOIPCMMNMJ)
			{
			}
		}

		private sealed class DGJEKLILLNG : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerMovementFeedback _003C_003E4__this;

			public float volume;

			public float spacing;

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
			public DGJEKLILLNG(int _003C_003E1__state)
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

		private sealed class FFHOAHJPAHL : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public PlayerMovementFeedback _003C_003E4__this;

			public float duration;

			private float _003CinitialVolume_003E5__2;

			private float _003CstartTime_003E5__3;

			private float _003CendTime_003E5__4;

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
			public FFHOAHJPAHL(int _003C_003E1__state)
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

		[SerializeField]
		private Player thisPlayer;

		[SerializeField]
		private CrossPlatformPlayerLocomotionFeedbackContent content;

		private PlayerTrail EMKDPFJMDKB;

		private float EFDGBDJNPEC;

		private float NDDJMBEKGLM;

		private float DDMODCGFNNL;

		private float BEDPHOLGHND;

		private SFXAudioSource CDNGGLPOPPP;

		private LKGILLBEJEK CDDHIGAEMNF;

		private bool BDPGHMFCNEE;

		private bool JFCHDPICFED;

		private bool DFPKIKFGDGL;

		private float NNJPGNJDPDG;

		private Vector3 NMEGIJFODAB;

		private Vector3 AGDAHMILJAF;

		private PooledParticle FNDOADLFPOE;

		private PooledParticle AKLPHBOEOOO;

		private PooledParticle OOIJFHLMLGN;

		private SFXAudioSource DAKMILCLLLE;

		private LKGILLBEJEK EDMMJMALAPI;

		private PooledParticle PFINIFGHNHG;

		private float ENHAHFPOCNE;

		private float NBJIGGEILCC;

		private SFXAudioSource OJCGCHMFAMB;

		private LKGILLBEJEK NKKMELKFPNP;

		public static global::CBEFDECGNBJ<Player, Vector3, Vector3> PlayerTeleportedEvent;

		public static EEANDDJEMJC LocalPlayerStartedTeleportEvent;

		public global::CBEFDECGNBJ<Player, Vector3, Vector3> TeleportEvent;

		private global::JPEBBAFCBEP<bool, Vector3> LADGGAFIEKM;

public bool IsTeleporting
{
get 		{
			return false;
		}

}

private bool ACHMDLKCHHM
{
get 		{
			return false;
		}

}

private AnimationCurve DBCFBONLHOB
{
get 		{
			return null;
		}

}

private AnimationCurve GFAILCLHKJO
{
get 		{
			return null;
		}

}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		public void OnPlayerDespawn()
		{
		}

		public void PlaySonicBoomSprintEffect()
		{
		}

		public void StopPlayingSonicBoomSprintEffect()
		{
		}

		private bool DDNJDJACNAC()
		{
			return false;
		}

		private bool ADEMGOBMOGG(float NIBGMBBACPK)
		{
			return false;
		}

		private void FHJEECABLLC()
		{
		}

		private void DEGLONLANNB()
		{
		}

		private void KGMNPGGBAFA()
		{
		}

		private IEnumerator EAOGPIHDDKL(float AEHHFJHAOAO, float COFONCKAJCK)
		{
			return null;
		}

		private void KCFFAJPDCHH()
		{
		}

		private void ADENKEDDNEM()
		{
		}

		private void GPDNGLBBNHJ()
		{
		}

		private IEnumerator<EGGPGCCKPCO> EFKPHANDKLF(float FGBPJMKCMAO)
		{
			return null;
		}

		private void PCFLLDJFJPE()
		{
		}

		private void DMMIODOPEDC()
		{
		}

		private void NHKGDIEFOCJ()
		{
		}

		private void CCKIPJLBAPJ()
		{
		}

		private void OHJINGEBGDJ(PooledParticle BLJHJFMKMJG)
		{
		}

		private WindLineVFXSettings CBBJJFJKFKF(float BNACDFFMPEO)
		{
			return default;
		}

		private void EMKBDJHNJFM()
		{
		}

		private bool EBDGEDMOCAA(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, out Vector3 INLGLHIPOMC, out Vector3 OLLJOPPFGKK)
		{
			INLGLHIPOMC = default;
			OLLJOPPFGKK = default;
			return false;
		}

		private float OFLFLEBMOFH(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
			return 0f;
		}

		private void CKOEFDHBKAE(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
		}

		private void IGHHKBOEIGM(Vector3 INLGLHIPOMC, Vector3 OLLJOPPFGKK)
		{
		}

		private void OLLKLEPCGKK(Vector3 DBKJILAFGCE, Vector3 LOCBBMCCODM, float HDGFHFCPNPD, float FJKIDPPLMMJ)
		{
		}

		private void NCODGGGOIDA(Vector3 DBKJILAFGCE, Vector3 LOCBBMCCODM)
		{
		}

		[PBOMGCLBFHF]
		private void RpcTeleport(Vector3 PIDPAMCLAIG, Vector3 BOAHDEKIAOF, float FGBPJMKCMAO)
		{
		}

		private void EKECGIODABA(Vector3 NIHLAGEHHJG, Vector3 NLLIFBDEKOJ)
		{
		}

		private void OOAIIGDKPDJ()
		{
		}

		private void EAPNBKENODB(Vector3 NIHLAGEHHJG, Vector3 NLLIFBDEKOJ)
		{
		}

		private void OCBEHPFKEGG()
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnJump()
		{
		}

		private void LCNMLDDHAGA()
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnLand()
		{
		}

		private void MIJGJMMFCPN()
		{
		}

		private void AEILPBKADBO(FCANHOEFNGD JOFPPIPFGKP)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnStateTransition(FCANHOEFNGD JOFPPIPFGKP)
		{
		}

		private void BCLMKICKDMO()
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnClamber()
		{
		}

		private void JHLBBGOEKJM(CHILKDJABBF LLAGNEBKMCA, Vector3 EGNKMIFIIDN)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnPushed(CHILKDJABBF LLAGNEBKMCA, Vector3 EGNKMIFIIDN)
		{
		}

		private void HJOJHHPOGJE(CHILKDJABBF PPGBJFMEBME)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnPushing(CHILKDJABBF PPGBJFMEBME)
		{
		}

		private void NAOGCIMNPHM()
		{
		}

		private void JOBEOHFHLFO()
		{
		}

		[CompilerGenerated]
		private void DIMPDFPOOGO()
		{
		}

		[CompilerGenerated]
		private void KICCMFGKEEB()
		{
		}
	}
}
