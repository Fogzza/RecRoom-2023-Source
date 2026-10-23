using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Core.AI
{
	[DisallowMultipleComponent]
	public class EnemyAudio : MonoBehaviour
	{
		[SerializeField]
		private RecRoomAudioClip[] spawnVOs;

		[SerializeField]
		private EnemyAudioClip movingSound;

		[SerializeField]
		private EnemyAudioClip[] attackSounds;

		[SerializeField]
		private RecRoomAudioClip[] attackVOs;

		[SerializeField]
		private RecRoomAudioClip chargeAttackSFX;

		[SerializeField]
		private RecRoomAudioClip[] takeDamageVOs;

		[SerializeField]
		private RecRoomAudioClip onDamageSound;

		[SerializeField]
		private RecRoomAudioClip onShieldedDamageSound;

		[SerializeField]
		private RecRoomAudioClip onCriticalHitDamageSound;

		[SerializeField]
		private RecRoomAudioClip[] deathVOs;

		[SerializeField]
		private RecRoomAudioClip onDeathSound;

		[SerializeField]
		private RecRoomAudioClip onCriticalHitKill;

		[SerializeField]
		private RecRoomAudioClip charge;

		[SerializeField]
		private RecRoomAudioClip explosion;

		private Enemy JMBOIKNLKPH;

		private SFXAudioSource CGONHGFGAFJ;

		private SFXAudioSource JLHBHKCNIIP;

		private SFXAudioSource HBCOIALHELB;

		private SFXAudioSource PPOGELMDCDE;

		private bool KLLJNIDEKGP;

		private bool FNCCNMMKFLO;

		private bool KEMPGKDONBM;

public bool MovingSoundVolumeDrivenBySteeringSpeed
{
get 		{
			return false;
		}

set {
		}
}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public void OnAggro()
		{
		}

		public void StartMoving()
		{
		}

		public void StopMoving()
		{
		}

		public void OnAttack()
		{
		}

		public void OnChargeAttack()
		{
		}

		public void OnTakeDamage(BHHAHFFCKJO GFHNJGJNNCK, Vector3 EPGAOLNDLII, bool KICPDIHAFMC)
		{
		}

		public void OnKill(BHHAHFFCKJO GFHNJGJNNCK, Vector3 EPGAOLNDLII, bool KICPDIHAFMC)
		{
		}

		public void StartCharge(bool CDLBACPEGBD)
		{
		}

		public void StopCharge()
		{
		}

		public void OnExplode()
		{
		}

		private RecRoomAudioClip FIJJBDJBOAN(BHHAHFFCKJO GFHNJGJNNCK)
		{
			return null;
		}

		private RecRoomAudioClip GINIIBCPPGK(BHHAHFFCKJO GFHNJGJNNCK)
		{
			return null;
		}

		private void AENEBMLGBFM()
		{
		}

		private void OJFLHOMDOAD()
		{
		}

		private void LAPOLJHKAHF(bool CDLBACPEGBD)
		{
		}

		private void DDCALNPPFBN()
		{
		}

		private void ENKIIMHIDGK(Enemy DPENEFKKNDN)
		{
		}

		private void FLJOEKGMGPO(SFXAudioSource GLLFHCCFIGK)
		{
		}

		private void EDNOMACNKOB(SFXAudioSource GLLFHCCFIGK)
		{
		}

		private void IHBHIEMIDIA(SFXAudioSource GLLFHCCFIGK)
		{
		}

		private void CJKLNNPMJGC(SFXAudioSource GLLFHCCFIGK)
		{
		}
	}
}
