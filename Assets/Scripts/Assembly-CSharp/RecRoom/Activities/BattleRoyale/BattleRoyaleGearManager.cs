using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using RecRoom.Core.GameManagement;
using UnityEngine;

namespace RecRoom.Activities.BattleRoyale
{
	public class BattleRoyaleGearManager : MonoBehaviourPun
	{
		private sealed class ECOOHPAPPNK : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EquipmentSpawnerChest chest;

			public BattleRoyaleGearManager _003C_003E4__this;

			private FKGDGKFOCIE _003CspawnedWeaponType_003E5__2;

			private float _003CdeltaArcAngle_003E5__3;

			private bool _003CweaponSpawnSuccess_003E5__4;

			private WaitForSeconds _003Cwait_003E5__5;

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
			public ECOOHPAPPNK(int _003C_003E1__state)
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

		private static BattleRoyaleGearManager EGAIHCNFOEN;

		[SerializeField]
		private BattleRoyaleGearBag bagPrefab;

		[SerializeField]
		private BattleRoyalePlayerMap mapPrefab;

		[SerializeField]
		private TextAsset arsenalBlob;

		[SerializeField]
		private float chestEnabledPercentage;

		private BattleRoyaleGearBag BEAGPFCDAJL;

		private NOOHFOPONNB MFIEJIOKINB;

		private global::OFIKOABIHEL<global::OFIKOABIHEL<int>> DFHEKDIAOOL;

		private global::OFIKOABIHEL<int> HEHMMMMAGFK;

		private global::OFIKOABIHEL<int> AONCCANIPCH;

		private int[] DMJNEBCJDIO;

		private Dictionary<int, global::MOBDJNEDDKC<int[]>> BKOIBIAKHCB;

		private const float DDLIIAGKEKD = 0.05f;

		private const float EMKAFPEMCGC = 4f;

		private const float JFGOGOPKJHF = 720f;

public static BattleRoyaleGearManager Instance
{
get 		{
			return null;
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

		protected override void OnDestroy()
		{
		}

		private void DNNOOOGOPID()
		{
		}

		private void IEEHHONMJGK(EquipmentSpawnerChest IEODCBDCDFF)
		{
		}

		private IEnumerator HHGANCPILDB(EquipmentSpawnerChest IEODCBDCDFF)
		{
			return null;
		}

		public int GetFieldAmmo(CHILKDJABBF EKOFNPFCLMO, FKGDGKFOCIE BPHCEBGFDCF)
		{
			return 0;
		}

		public void SetFieldAmmo(CHILKDJABBF EKOFNPFCLMO, FKGDGKFOCIE BPHCEBGFDCF, int AGOOKINFCAI)
		{
		}

		private void ILBBGIDLHIG()
		{
		}

		private global::MOBDJNEDDKC<int[]> JIHMBNFOLEK(CHILKDJABBF EKOFNPFCLMO)
		{
			return null;
		}

		private void OMEALBLGBKJ(BattleRoyaleAmmo CPGMKGHBPLO)
		{
		}

		private void HDJBEAFJEHD()
		{
		}

		private void MLPDKFLLLCP(CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Weapon PLOGNHIJBNB, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, int FDDPFMJOHLO, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
		{
		}

		private void NIMAMFAOJFA(Enemy NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
		{
		}

		private void LJGOMIDAPJH()
		{
		}

		private void AOFJEBLKPPA(CHILKDJABBF NLGCGEFCFNA)
		{
		}

		private void IHGLNDIFFNA()
		{
		}

		private bool MFOPEEHHNPM(Vector3 ELGLOEDDKAJ, Quaternion FJKPMOAGDOI, float LGPIDIPODLD, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK, out FKGDGKFOCIE NMMPPECOHOE)
		{
			NMMPPECOHOE = default;
			return false;
		}

		private void AIHMNGAHJNP(Vector3 ELGLOEDDKAJ, Quaternion FJKPMOAGDOI, float LGPIDIPODLD, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK)
		{
		}

		private void KKDAOJGFODE(Vector3 ELGLOEDDKAJ, Quaternion FJKPMOAGDOI, float LGPIDIPODLD, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK)
		{
		}

		private void CHCCIJKLOOH(FKGDGKFOCIE ILHLOODELFM, Vector3 ELGLOEDDKAJ, Quaternion FJKPMOAGDOI, float LGPIDIPODLD, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK)
		{
		}

		private bool CCKAGNDOMLJ(int IFLNAAMCDOE, Vector3 ELGLOEDDKAJ, Quaternion FJKPMOAGDOI, float LGPIDIPODLD, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK)
		{
			return false;
		}

		private void FEJEKDDPHPD(SpawnableTool CKAPBBGHJEC)
		{
		}
	}
}
