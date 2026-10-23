using System;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class VehicleEngineAudio : VehicleAudio
	{
		[Serializable]
		private class AudioGear
		{
			public string label;

			public Vector2 rpmRange;

			public Vector2 pitchRange;

			public Vector2 velocityRange;

			public AnimationCurve rpmToPitchNormalizedCurve;
		}

		private enum NFPLJAEPEFD
		{
			ENGINE_IDLE = 0,
			ENGINE_ACCEL = 1,
			ENGINE_ONESHOT = 2,
			GEAR_ONESHOT = 3
		}

		[SerializeField]
		private Transform engineAudioFollowTransform;

		[SerializeField]
		private Transform gearAudioFollowTransform;

		[SerializeField]
		private RecRoomAudioClip engineStartSFX;

		[SerializeField]
		private RecRoomAudioClip engineIdleSFX;

		[SerializeField]
		private RecRoomAudioClip engineTurnOffSFX;

		[SerializeField]
		private RecRoomAudioClip engineAccelerateSFX;

		[SerializeField]
		private RecRoomAudioClip engineReverseAccelerateSFX;

		[SerializeField]
		private RecRoomAudioClip engineGearShiftSFX;

		[SerializeField]
		private AudioGear[] engineAudioGearList;

		[SerializeField]
		private float gearShiftWindow;

		[SerializeField]
		private float accelerationSFXVolumeSmoothTime;

		[SerializeField]
		private float loopingSFXVolumeSmoothTime;

		[SerializeField]
		private float loopingSFXPitchSmoothTime;

		[SerializeField]
		private RecRoomAudioClip throttleEngageSFX;

		[SerializeField]
		private float throttleSFXTriggerSpeedCap;

		[SerializeField]
		private bool muteAllEngineAudio;

		private const float DHNFINCKDOG = 0.02f;

		private int LMLHABJCHMC;

		private int OADCGBLNDKI;

		private float FMOEFLKEHFC;

		private bool FECADEBEGJO;

		private float LLGIIAJLMKH;

		private float GLEDKEMBJLM;

		private float BEOPOMKLOIC;

		private float PPDPOKJNBEG;

		private float JFFKPJADNEM;

		private float CCEKFOIIAJL;

		private float BNFFDGEHNAO;

		private float NGAOCAJIJPJ;

		private float NIJDIBJHLME;

		private float LDKGCPHHOAA;

		private float ENDPBIINOHM;

		private float GLBLFDBLLML;

		private SFXAudioSource DBEFIENBMAP;

		private SFXAudioSource IAEHMKDDIEP;

		private float PMBEDLALPOA;

		public const float ENGINE_SFX_START2IDLE_DELAY = 0.12f;

		private void Update()
		{
		}

		public void ThrottleEngage(float MLNHNNFOHNP, float PBFDDKOEKPJ)
		{
		}

		public void StartEngine()
		{
		}

		public void StopEngine()
		{
		}

		public void EnterIdle()
		{
		}

		public void ExitIdle()
		{
		}

		public void EnterAccelerate(float PBFDDKOEKPJ, bool FGAMLBKJMNG)
		{
		}

		public void UpdateAccelerate(float PBFDDKOEKPJ, float ONOALGGFKKG, bool FGAMLBKJMNG, bool NFFHPMBKJGP)
		{
		}

		public void EnterSlowingDown(float PBFDDKOEKPJ)
		{
		}

		public void UpdateSlowingDown(float PBFDDKOEKPJ, float ONOALGGFKKG, bool FGAMLBKJMNG, bool NFFHPMBKJGP)
		{
		}

		private void LJPLIBHGPDN(RecRoomAudioClip OCCKBMENBDI, bool KPNLPFPAHOE = false)
		{
		}

		private void FFLKPDKFFHI(ref SFXAudioSource PLIJJENJJOP, RecRoomAudioClip OCCKBMENBDI)
		{
		}

		private void LEIBMEBLBEL(SFXAudioSource PLIJJENJJOP)
		{
		}

		private void IFNBEPAHEHA()
		{
		}

		private void BBLGNJDNONL()
		{
		}

		private void OBJJONGOEKH()
		{
		}

		private void MDBPPNCGJKI(float ONOALGGFKKG, int LMLHABJCHMC, bool GDBHKKAADHM, bool FGAMLBKJMNG)
		{
		}

		private void LODADFDCCOF()
		{
		}

		private void DOCOIBGKKJE(float PBFDDKOEKPJ)
		{
		}

		private int NFCGGFHIBHF(float AHJIJFDGDDG, int LMLHABJCHMC)
		{
			return 0;
		}

		private void BMHHLDANBNG(bool JKMFAAMFFDJ, float JDBNLCGDLEG, float BBCKLMIHKNI)
		{
		}

		private void KEFOOCANBCD(bool JKMFAAMFFDJ, float JDBNLCGDLEG)
		{
		}

		private void NNFGPINADJM(bool JKMFAAMFFDJ, float BBCKLMIHKNI)
		{
		}

		private void HAOJJNMFNLH(ref SFXAudioSource PLIJJENJJOP, float JDBNLCGDLEG)
		{
		}

		private float LAKFNEIBIBP(float GOPIFNBPGBD, AudioGear EJHBBEPLPDN)
		{
			return 0f;
		}
	}
}
