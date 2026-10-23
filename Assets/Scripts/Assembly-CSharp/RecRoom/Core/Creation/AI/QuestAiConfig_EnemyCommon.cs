using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RecRoom.Core.AI;
using UnityEngine;

namespace RecRoom.Core.Creation.AI
{
	public class QuestAiConfig_EnemyCommon : QuestAiConfiguration
	{
		private const int MDJFKBHGICE = 1;

		private const int DIIEKNEKANC = 100000;

		private const float GEBGMDKEJGI = 1f;

		private const float JJGDGAIHIHK = 10f;

		private readonly Dictionary<string, MIBJNNKFLND> APBBEIIFKCO;

		private readonly Dictionary<string, MIBJNNKFLND> KLFNBCKFCKC;

		[SerializeField]
		private int maxHealth;

		[SerializeField]
		private float movementSpeed;

		[SerializeField]
		private Enemy.MDGCCBDJGBJ healthBarSetting;

		[SerializeField]
		private Enemy.JGNNBCGFCLN spawnState;

		[SerializeField]
		private bool preventAutoAggro;

		private global::MOBDJNEDDKC<int> KDBAGDPBKHN;

		private global::MOBDJNEDDKC<float> APHDJKLKKGG;

		private global::MOBDJNEDDKC<Enemy.MDGCCBDJGBJ> GFHEOHDADHB;

		private global::MOBDJNEDDKC<Enemy.JGNNBCGFCLN> FIKBIOOCGFI;

		private global::MOBDJNEDDKC<bool> CKGMIMLPAGD;

public int MaxHealth
{
get 		{
			return 0;
		}

set {
		}
}

public float MovementSpeed
{
get 		{
			return 0f;
		}

set {
		}
}

public Enemy.MDGCCBDJGBJ HealthBarSetting
{
get 		{
			return Enemy.MDGCCBDJGBJ.DEFAULT;
		}

set {
		}
}

public Enemy.JGNNBCGFCLN SpawnState
{
get 		{
			return Enemy.JGNNBCGFCLN.INVALID;
		}

set {
		}
}

public bool PreventAutoAggro
{
get 		{
			return false;
		}

set {
		}
}

		public override void SetupSynchronizedFields(JPEAKDKPCGM NEHBOBJIBEC)
		{
		}

		public override void AddInstantiationParams(Dictionary<string, object> HMJOKPKOPCN)
		{
		}

		public override int AddConfigurableSettings(CreationObject ICHBECDKHOJ, AKCHPHOMHLH POAGNGMDMGB, int LAGADKBKLAD)
		{
			return 0;
		}

		public override void DeserializeFrom(ACBOEIAGKJL GBJAJCMANGI, FBLAHKFEHNM LJFNCCMLIDM)
		{
		}

		public override void SerializeTo(ACBOEIAGKJL GBJAJCMANGI)
		{
		}

		[CompilerGenerated]
		private int ONAMBLAKMJN()
		{
			return 0;
		}

		[CompilerGenerated]
		private void AJKAPOGNJLD(int IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private float POPKMBLJPJB()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void FGDDNHLKNKN(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private int GEMGMLLFDGI()
		{
			return 0;
		}

		[CompilerGenerated]
		private void LFPENAOEJAG(int IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private int MDEJMDMFJBC()
		{
			return 0;
		}

		[CompilerGenerated]
		private void DPBEECLKOCB(int IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool FGHEPHAMOLO()
		{
			return false;
		}

		[CompilerGenerated]
		private void LLHLMMPPPBH(bool IPMIIEAGJKC)
		{
		}
	}
}
