using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Consumable;
using RecRoom.Core;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Tools
{
	public class DrinkableBottle : MonoBehaviourPun
	{
		public delegate void JNIEJCANKLH(DrinkableBottle IHJLCMGGPDD, CHILKDJABBF POHGAFHJGJF);

		private sealed class IKIHHKCLFJL : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public DrinkableBottle _003C_003E4__this;

			private float _003ClifeRemaining_003E5__2;

			private float _003CnextPourTime_003E5__3;

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
			public IKIHHKCLFJL(int _003C_003E1__state)
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

		private JNIEJCANKLH INCANDOMDOH__BackingField;

		private Action<DrinkableBottle> GNKHBHIIJHL__BackingField;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private ParticleSystem[] waterParticles;

		[SerializeField]
		private ParticleEventListener eventListener;

		[SerializeField]
		private Transform liquidRendererRoot;

		[SerializeField]
		private bool keepIsEmptyStateOnReset;

		[SerializeField]
		private RecRoomAudioClip uncorkAudio;

		[SerializeField]
		private GameObject cork;

		[SerializeField]
		private float lifeSpan;

		[SerializeField]
		private bool onlyPourWhileHeld;

		[SerializeField]
		private RecRoomAudioClip pourAudio;

		[SerializeField]
		private float emptyPourPitchShift;

		[SerializeField]
		private float pourInterval;

		[SerializeField]
		private float drinkInterval;

		[SerializeField]
		private RecRoomAudioClip[] drinkAudioClips;

		[SerializeField]
		private PooledParticle drinkSplashPrefab;

		[SerializeField]
		private Transform capTransform;

		[SerializeField]
		private SphereCollider mouthTrigger;

		[SerializeField]
		private float particleDrinkRadius;

		[SerializeField]
		private float intersectionDrinkRadius;

		[SerializeField]
		private ShakeAudio shakeAudio;

		private LKGILLBEJEK BDLMLHJLMDK;

		private bool KEOEMFJHNOI;

		private bool NFFNJDAHHOF;

		private float EMENBPJNLPN;

		private Transform LPFHKENKHDF;

		private CHILKDJABBF EFFCJEKOEBM;

		private global::MOBDJNEDDKC<string> NNDNDJAPMEK;

		private global::MOBDJNEDDKC<string> OCEJFLHACGO;

		private global::MOBDJNEDDKC<bool> MKALPCDGAHJ;

		private global::MOBDJNEDDKC<bool> GGJIINDNOBD;

private string LANPLMLJMPJ
{
get 		{
			return null;
		}

set {
		}
}

private string LJNKEPIHFJF
{
get 		{
			return null;
		}

set {
		}
}

public bool IsEmpty
{
get 		{
			return false;
		}

set {
		}
}

private bool KGGGJCCFFCJ
{
get 		{
			return false;
		}

set {
		}
}

public bool IsEmitting
{
get 		{
			return false;
		}

}

private bool BIHDKNNFEMA
{
get 		{
			return false;
		}

}

public event JNIEJCANKLH DrunkEvent {
add {
		}
remove {
		}
}

public event Action<DrinkableBottle> IsEmptyChangeEvent {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void GAHHBGJBCCA(float OKBAJEAPIHG)
		{
		}

		private void AIEIOCOLKFK(float OKBAJEAPIHG)
		{
		}

		private void OnTriggerEnter(Collider HNPEBINPOBO)
		{
		}

		private void OnTriggerExit(Collider HNPEBINPOBO)
		{
		}

		public void AuthorityMarkEmpty()
		{
		}

		public void SetConsumableInfo(ConsumableInfo AKOKILEPANJ)
		{
		}

		private void NHNECKBMKEG()
		{
		}

		private void MBIOLEBFOOM(Tool PMEFICGEDFK, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		private void BOGLMPCCMDC(Tool PMEFICGEDFK)
		{
		}

		private void CKMDAPFFMAD(ParticleEventListener NFCDBEKMGLP, Collider PAKCCEOOEJB, IEnumerable<ParticleCollisionEvent> LKLOMDKCAPK)
		{
		}

		private void GIALDCIOAOD()
		{
		}

		private void ENKKGPENDCJ()
		{
		}

		private void BGEOOOGANOG()
		{
		}

		private IEnumerator<EGGPGCCKPCO> IPOPBFOAPDD()
		{
			return null;
		}

		private void IIMAGAMFFKN(bool OPNFHMHGPJH)
		{
		}

		private bool KDALLBKMEFD(Collider PAKCCEOOEJB)
		{
			return false;
		}

		private void CPLLOKGACJO(Vector3 ADJINPMOILO, float HBFONGAGADM)
		{
		}

		private void NIELJMNCAHE(bool KBOBBDBAAMB)
		{
		}

		[CompilerGenerated]
		private bool MLEBJDEKPJM()
		{
			return false;
		}
	}
}
