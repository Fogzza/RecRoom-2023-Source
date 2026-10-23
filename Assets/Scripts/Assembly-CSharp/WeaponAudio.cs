using RecRoom.Audio;
using UnityEngine;

public class WeaponAudio : MonoBehaviour
{
	[SerializeField]
	private RecRoomAudioClip onFire;

	[SerializeField]
	private RecRoomAudioClip onFireSoft;

	[SerializeField]
	private RecRoomAudioClip onReload;

	[SerializeField]
	private RecRoomAudioClip onLastRoundSpent;

	[SerializeField]
	private RecRoomAudioClip onOutOfAmmoFire;

	[SerializeField]
	private RecRoomAudioClip onMisfire;

	[SerializeField]
	private RecRoomAudioClip onCharge;

	[SerializeField]
	private RecRoomAudioClip onFullyChargedLoop;

	[SerializeField]
	private RecRoomAudioClip onSwing;

	[SerializeField]
	private RecRoomAudioClip onHitPlayer;

	[SerializeField]
	private RecRoomAudioClip onHitEnvironment;

	[SerializeField]
	private RecRoomAudioClip onEnemyHit;

	[SerializeField]
	private RecRoomAudioClip onEnemyHitHard;

	[SerializeField]
	private RecRoomAudioClip onEnemyHitShield;

	[SerializeField]
	private RecRoomAudioClip onEnemySecondaryDamage;

	private SFXAudioSource BMMKLAHKMEG;

	private SFXAudioSource IAILABMBOIN;

	private float GIOOMAMFMHG;

	private float LAMBJLLAEFI;

	private float LEBOMJPIKEK;

	private float FBINDOPGNMG;

	private float JBFBMNNNNCJ;

	private float EAJGFCHIOIF;

	private const float FNNMAEFNHCA = 0.1f;

public bool IsLoopingFullyChargedAudio
{
get 	{
		return false;
	}

}

	public void CopyFrom(WeaponAudio HNPEBINPOBO)
	{
	}

	public void OnFireHard()
	{
	}

	public void OnFireSoft()
	{
	}

	public void OnCharge(float PENGDDHNPIK = 0f)
	{
	}

	private void PBKIFJDFNBA(SFXAudioSource EECCJHGJDIE)
	{
	}

	public void OnStopCharge()
	{
	}

	public void OnFullyChargedLoopStart()
	{
	}

	public void OnFullyChargedLoopStop()
	{
	}

	public void OnLastRoundSpent()
	{
	}

	public void OnReload()
	{
	}

	public void OnOutOfAmmoFire()
	{
	}

	public void OnMisfire()
	{
	}

	public void OnSwing(Transform CMPMFOJMCAP)
	{
	}

	public void OnPlayerImpact(Vector3 INLGLHIPOMC)
	{
	}

	public void OnEnemyHit(Vector3 INLGLHIPOMC)
	{
	}

	public void OnEnemyHitHard(Vector3 INLGLHIPOMC)
	{
	}

	public void OnEnemyShieldHit(Vector3 INLGLHIPOMC)
	{
	}

	public void OnEnemySecondaryDamage(Vector3 INLGLHIPOMC)
	{
	}

	public void OnEnvironmentImpact(Vector3 INLGLHIPOMC)
	{
	}

	private bool BOPOEKIGBFA(ref float BGHEDFEEIEF)
	{
		return false;
	}

	private void OnDestroy()
	{
	}
}
