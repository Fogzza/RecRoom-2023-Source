using System;
using RecRoom.Audio;
using RecRoom.Core.AI;
using UnityEngine;

namespace RecRoom.Activities.Quest.RecRoom.Activities.Quest
{
	public class EnemyRopes : MonoBehaviour
	{
		private enum OHHDEMOOCIO
		{
			WHILE_SPAWNING = 0,
			WHILE_ALIVE = 1,
			ALWAYS = 2
		}

		[Serializable]
		public struct Rope
		{
			public Transform Root;

			public bool InvertY;
		}

		[SerializeField]
		private Enemy enemy;

		[SerializeField]
		public Rope[] allRopes;

		[SerializeField]
		private OHHDEMOOCIO ropeLifetime;

		[SerializeField]
		private RecRoomAudioClip onRopeSpawnAudio;

		[SerializeField]
		private RecRoomAudioClip onRopeRetractAudio;

		private const float GEEBJLAJLJO = 2f;

		private const float OFLHGCHAJIK = 3f;

		private bool JHEPGHIIGCJ;

		private bool MLHDJFEBNIG;

		private float DPPCFAOGDCM;

		private Vector3[] EEMFIDPJBII;

		private void Awake()
		{
		}

		private void DGPLOMNOGEN(Enemy DPENEFKKNDN)
		{
		}

		private void BHHJDJCHOPE(Enemy DPENEFKKNDN)
		{
		}

		private void KKALBOOJCFA(Enemy DPENEFKKNDN)
		{
		}

		private void LateUpdate()
		{
		}

		private void IOPNNMFNONP()
		{
		}

		private void NCMJFLFGAIA()
		{
		}

		private void HMKBDGKGPHB()
		{
		}

		private void HNGMEBOFHEL(GameObject GEDKKOONKPD, bool BFDBCMGIOBG)
		{
		}

		public void RemoveAllRopes()
		{
		}
	}
}
