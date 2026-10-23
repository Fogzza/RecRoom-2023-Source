using System;
using System.Collections.Generic;
using Photon.Pun;
using RecRoom.Core.AI;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class VehicleCollisions : MonoBehaviourPun
	{
		private enum GDADMAOCBMC
		{
			INVALID = 0,
			NO_RIGIDBODY = 1,
			VEHICLE = 2,
			DYNAMIC_OBJECT = 3,
			ENEMY = 4,
			PLAYER = 5
		}

		private enum GBFDMJNMGLK
		{
			COLLISION = 0,
			COLLISION_OR_BOXCAST = 1,
			BOXCAST_AND_NOT_COLLISION = 2
		}

		private enum BCEEPJAPFPD
		{
			TAKE_FIRST = 0,
			AVERAGE_COLLIDERS = 2
		}

		private struct LNALJKLKCIM
		{
			public readonly Tool GBJKGIOJDMH;

			public readonly Vector3 CFLNDFOEDOH;

			public readonly GDADMAOCBMC ELNNKKDJAAK;

			public readonly Collider FFAHMIPOLIO;

			public readonly Collider FGHFEPKHIOC;

			private Vector3 NMFOKNCNGEF;

			private Vector3 DKODLOJELEI;

			private Vector3 HAJMDNKCHJK;

			private bool CADPOBPHCDP;

			private byte FJANNLDGCIH;

			private Vector3 LDDPBFHMNAD;

			private byte PEDNJKIHNGM;

			public JPOJBKKCIFJ.CKEDLDJCPAN EJDHAEJNKMP;

public bool FFHCICMKCDI
{
get 			{
				return false;
			}

private set {
			}
}

public byte DFGDOIGFNOH
{
get 			{
				return 0;
			}

private set {
			}
}

public Vector3 HBECEHKDNPM
{
get 			{
				return default;
			}

}

public Vector3 OOHNDCDCFIO
{
get 			{
				return default;
			}

}

public Vector3 ENELBGDEBFO
{
get 			{
				return default;
			}

}

			public LNALJKLKCIM(JPOJBKKCIFJ KDGCDLJEAMD, GDADMAOCBMC OEBDOJJPDMN)
			{
				GBJKGIOJDMH = null;
				CFLNDFOEDOH = default;
				ELNNKKDJAAK = GDADMAOCBMC.INVALID;
				FFAHMIPOLIO = null;
				FGHFEPKHIOC = null;
				NMFOKNCNGEF = default;
				DKODLOJELEI = default;
				HAJMDNKCHJK = default;
				CADPOBPHCDP = false;
				FJANNLDGCIH = 0;
				LDDPBFHMNAD = default;
				PEDNJKIHNGM = 0;
				EJDHAEJNKMP = JPOJBKKCIFJ.CKEDLDJCPAN.Collision;
			}

			public bool ANHNHIPOPML(GroundVehicle GFNJONFMHFK, VehicleCollisionConfigData CJNFDKOBOKG, out Vector3 NHFNLNAJLPC, out Vector3 OPNHNMDIEPD, out ForceMode ONPOIGPJBDF, out ForceMode ENLOAHEBMFJ, float NJJADGPKPLI = 1f)
			{
				NHFNLNAJLPC = default;
				OPNHNMDIEPD = default;
				ONPOIGPJBDF = default;
				ENLOAHEBMFJ = default;
				return false;
			}

			public void GCGHCPNAIDP(JPOJBKKCIFJ KDGCDLJEAMD, bool MKOMMHIKNLJ)
			{
			}
		}

		private struct LOMLAEIDEAI
		{
			private GDADMAOCBMC KEPJAEKMFIJ;

			private GroundVehicle PBAHEPEMFBN;

			private Player EMHIAGNIMKK;

			private Enemy MNKACOJEIKD;

			private BHHAHFFCKJO GGNPEACBJDN;

public GDADMAOCBMC MMMENNAAGAA
{
get 			{
				return GDADMAOCBMC.INVALID;
			}

private set {
			}
}

public GroundVehicle GAFCBCBDCKA
{
get 			{
				return null;
			}

private set {
			}
}

public Player BGGDDGNMNNE
{
get 			{
				return null;
			}

private set {
			}
}

public Enemy GIAMBANBFJJ
{
get 			{
				return null;
			}

private set {
			}
}

public BHHAHFFCKJO EDAAAINEPEH
{
get 			{
				return BHHAHFFCKJO.NORMAL;
			}

private set {
			}
}

			public static LOMLAEIDEAI NLDCFEDJILP()
			{
				return default;
			}

			public static LOMLAEIDEAI BDBJBEMIFNM()
			{
				return default;
			}

			public static LOMLAEIDEAI FEGJKDALAAI(Player EKOFNPFCLMO)
			{
				return default;
			}

			public static LOMLAEIDEAI HOKGIHIBLLM(GroundVehicle GFNJONFMHFK)
			{
				return default;
			}

			public static LOMLAEIDEAI HBBKEJCLPFH(Enemy DPENEFKKNDN, BHHAHFFCKJO MBKGKPOBHBB)
			{
				return default;
			}

			public static LOMLAEIDEAI OLPILELMLKO()
			{
				return default;
			}
		}

		private struct JPOJBKKCIFJ
		{
			public enum CKEDLDJCPAN
			{
				Collision = 0,
				Boxcast = 1
			}

			public readonly Collider LNDKNKKNELC;

			public readonly Rigidbody NKEHGJNPKJI;

			public readonly Collider FFAHMIPOLIO;

			public readonly Vector3 CFLNDFOEDOH;

			public readonly CKEDLDJCPAN DFFGLFMJPMI;

			public readonly Vector3 FELGDCNKGPK;

			public readonly Vector3 FGCFIKBDDKK;

			public readonly Vector3 KGEGAFEAIFJ;

			public bool EPLPLPBOIBH;

			public JPOJBKKCIFJ(Collision KDGCDLJEAMD, GroundVehicle GFNJONFMHFK)
			{
				LNDKNKKNELC = null;
				NKEHGJNPKJI = null;
				FFAHMIPOLIO = null;
				CFLNDFOEDOH = default;
				DFFGLFMJPMI = CKEDLDJCPAN.Collision;
				FELGDCNKGPK = default;
				FGCFIKBDDKK = default;
				KGEGAFEAIFJ = default;
				EPLPLPBOIBH = false;
			}

			public JPOJBKKCIFJ(RaycastHit KHFHAAMKDHD, float DIOOFNMNLBO, GroundVehicle GFNJONFMHFK, Collider KKDFABMCHPB)
			{
				LNDKNKKNELC = null;
				NKEHGJNPKJI = null;
				FFAHMIPOLIO = null;
				CFLNDFOEDOH = default;
				DFFGLFMJPMI = CKEDLDJCPAN.Collision;
				FELGDCNKGPK = default;
				FGCFIKBDDKK = default;
				KGEGAFEAIFJ = default;
				EPLPLPBOIBH = false;
			}
		}

		[Serializable]
		private struct ImpulseConfig
		{
			public bool CanImpulse;

			public float extraMomentumOnCollision;

			public float upwardAngleBias;

			public float minVehicleSpeedForImpulseTrigger;

			public bool NLDAKCFOAJJ(Vector3 OIEPDFJCEHE)
			{
				return false;
			}

			public bool NLDAKCFOAJJ(float DMIPMFMPLAP)
			{
				return false;
			}
		}

		[Serializable]
		private struct VehicleDamageConfig
		{
			public bool CanDamage;

			[SerializeField]
			private int minDamage;

			[SerializeField]
			private int maxDamage;

			[SerializeField]
			private float minVehicleSpeed;

			[SerializeField]
			private float maxVehicleSpeed;

			public int ANLHJCEJOII(float DMIPMFMPLAP)
			{
				return 0;
			}

			public bool BKPOPIALLJA(Vector3 OIEPDFJCEHE)
			{
				return false;
			}

			public bool BKPOPIALLJA(float DMIPMFMPLAP)
			{
				return false;
			}
		}

		[Serializable]
		private class VehicleCollisionConfigData
		{
			public GBFDMJNMGLK Condition;

			public CollisionConfigData DynamicObjectCollisionConfig;

			public bool DetectsCollisions => false;

			public bool DetectsBoxcasts => false;
		}

		private const float JKBOGHPHFJM = 0.5f;

		private const bool AILBONIFIDF = false;

		private const IALAJKBOKBN GJDJDFAMLJA = IALAJKBOKBN.VehiclePhysics;

		private const bool KMBCHDLGDFF = false;

		[SerializeField]
		private GroundVehicle vehicle;

		[SerializeField]
		private int boxcastPhysicsTicks;

		[SerializeField]
		private BoxCollider boxcastCollider;

		[SerializeField]
		private VehicleCollisionConfigData[] dynamicObjectCollisionConfigs;

		[SerializeField]
		private VehicleCollisionConfigData vehicleCollisionConfig;

		[SerializeField]
		private ImpulseConfig PlayerImpulseConfig;

		[SerializeField]
		private VehicleDamageConfig PlayerDamageConfig;

		[SerializeField]
		private float maxPlayerCollisionImpulseSpeed;

		[SerializeField]
		private ImpulseConfig EnemyImpulseConfig;

		[SerializeField]
		private VehicleDamageConfig EnemyDamageConfig;

		[SerializeField]
		private VehicleCollisionsAudio collisionAudio;

		[SerializeField]
		private VehicleVFX vehicleVFX;

		[SerializeField]
		private GameObject bodyCollisionRoot;

		private static readonly RaycastHit[] IBFIMJOMNIJ;

		private Collider[] HCOFKKDOEAN;

		private readonly Dictionary<int, float> JJEEKEPFEDP;

		private Dictionary<Enemy, float> JPKOBCFMCFM;

		private global::MOBDJNEDDKC<bool> MBIIMDAPPGH;

		private IDisposable NDJNOLAABAH;

		private readonly HashSet<Rigidbody> MMEEOBPDCAH;

		private Dictionary<Rigidbody, LOMLAEIDEAI> JBFLDNAPDFL;

		private Dictionary<Rigidbody, LNALJKLKCIM> CMGKDIOHLGO;

public bool AllCollisionEnabled
{
get 		{
			return false;
		}

set {
		}
}

public IDisposable UpdateToken
{
get 		{
			return null;
		}

set {
		}
}

		protected void FixedUpdate()
		{
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnCollisionEnter(Collision HNPEBINPOBO)
		{
		}

		private void HHBBJOJGBBN()
		{
		}

		private void OKKFIKGBFPG(Collision KDGCDLJEAMD, bool MKOMMHIKNLJ)
		{
		}

		private void LNNAELIJBPH(RaycastHit KHFHAAMKDHD, Collider KKDFABMCHPB, bool MKOMMHIKNLJ)
		{
		}

		private void ELGMPLDKHNE(JPOJBKKCIFJ KDGCDLJEAMD, bool MKOMMHIKNLJ)
		{
		}

		private LOMLAEIDEAI CGIHMKICDKA(JPOJBKKCIFJ HNPEBINPOBO, out bool PNMOCKCDKHK)
		{
			PNMOCKCDKHK = default;
			return default;
		}

		private bool OOMNIAEFNFD(VehicleCollisionConfigData CJNFDKOBOKG, LNALJKLKCIM ELHNONIIOCM)
		{
			return false;
		}

		private void KPJOOIKDAKL(Rigidbody FHKPFHJJOHK, LNALJKLKCIM ELHNONIIOCM, VehicleCollisionConfigData FPJKGKBOAOA)
		{
		}

		private void HAMFFFIFNBI(Enemy DPENEFKKNDN, BHHAHFFCKJO MBKGKPOBHBB, Vector3 IEPNAOFFAOE, Vector3 IOGCIJMPJJE, Vector3 KEMAFNKMJGH, float AAFOEDDPBCC)
		{
		}

		private void IDEDILIGIFG(float OKBAJEAPIHG)
		{
		}

		private void PLMIJMLBDNL(Player KJCCPIIFNGO, float GJAEBPEJGEM)
		{
		}

		private void IGIDBGOKONM(Rigidbody FHKPFHJJOHK, VehicleCollisionConfigData CJNFDKOBOKG, LNALJKLKCIM ELHNONIIOCM, Vector3 NHFNLNAJLPC, Vector3 OPNHNMDIEPD, ForceMode ONPOIGPJBDF, ForceMode ENLOAHEBMFJ, bool LCBNDFFGHEA, GDADMAOCBMC OEBDOJJPDMN)
		{
		}

		private void NOLCNMELEOF(float JLMEFELDDOO, Vector3 IOGCIJMPJJE, Vector3 MCKFCCNKIND, Collider LLKCFCIIGOB, bool EHNALEOKCCL, GDADMAOCBMC OEBDOJJPDMN)
		{
		}

		private void DEJLPAAMNJI(Collider LLKCFCIIGOB, Tool CCKOLGICDIP, Rigidbody FHKPFHJJOHK, float JLMEFELDDOO, Vector3 MCKFCCNKIND, Vector3 IOGCIJMPJJE, Vector3 NHFNLNAJLPC, ForceMode OJOAKAEAKAC, GDADMAOCBMC OEBDOJJPDMN, bool LCBNDFFGHEA = true)
		{
		}

		public void IgnoreMovementCollision(bool CHEHHIMIPCJ = true)
		{
		}

		private void BGCKGBBFDGF()
		{
		}

		private void CKAHAJPPHAJ()
		{
		}

		private void OKBHNDCANAF()
		{
		}

		private void NKGKBPKHDIN()
		{
		}

		private void BAFMDELCKOF()
		{
		}
	}
}
