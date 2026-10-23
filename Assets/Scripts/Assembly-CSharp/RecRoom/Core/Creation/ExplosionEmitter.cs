using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.CircuitsV2.GraphNodes;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class ExplosionEmitter : MonoBehaviourPun, GFLPAFBGELM, NEKJJEGPHFG, DJLCHGFCFAD
	{
		public const string PrimaryLabel = "Explosion";

		private const float KMANFIBNECK = 1.6f;

		[SerializeField]
		private float radius;

		[SerializeField]
		private int damage;

		[SerializeField]
		private float maximumExplosionRate;

		[SerializeField]
		private PooledParticle explosionParticles;

		[SerializeField]
		private RecRoomAudioClip explosionAudio;

		private BCKPMPNCEOO GBNGMEEHPCB;

		protected float KPLOLOBPAMO;

		[SerializeField]
		private CreationObject creationObject;

		[SerializeField]
		private ControlPanelCircuitObject controlPanelCircuitObject;

		private global::CDLJMENCODC<int> AFAFPEJHBGE;

		private global::CDLJMENCODC<float> NCEGKCCOIKI;

		private global::CDLJMENCODC<int> CEKAHJBOPBJ;

		private global::CDLJMENCODC<bool> GAEENMGMBIN;

public bool IsOnCooldown
{
get 		{
			return false;
		}

}

public float TimeSinceLastExplosion
{
get 		{
			return 0f;
		}

}

public int CurrentExplosionColor
{
get 		{
			return 0;
		}

set {
		}
}

protected Color KGFJLEBJJED
{
get 		{
			return default;
		}

}

public float CurrentExplosionRadius
{
get 		{
			return 0f;
		}

set {
		}
}

public int CurrentExplosionDamage
{
get 		{
			return 0;
		}

set {
		}
}

public bool SFXToggle
{
get 		{
			return false;
		}

set {
		}
}

public global::MPNGGJINIEL<KGGKJGICJLE> ObjectDefinitionId
{
get 		{
			return default;
		}

}

public GMHHJCFIMML CV2CreationObject
{
get 		{
			return null;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected void JKKNCLHDAAD(Vector3 PDFEDMAOMNH)
		{
		}

		private void MGKPHCBKLEN(Player EKOFNPFCLMO, Player.NBPIPAJOGLC MKLOBAIKINA, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		public global::FAIKNKAIPLB<OHAJOLBEFND> Self(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2TryExplode(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetExplosionRadius(JEGAPHLGBJA GCBHEJANCJK, float DMIPMFMPLAP)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetDamage(JEGAPHLGBJA GCBHEJANCJK, int FHOPIFJDLJM)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetColor(JEGAPHLGBJA GCBHEJANCJK, int HMCAFGCGFJF)
		{
			return default;
		}

		private void DDJBANECENI(CHILKDJABBF KJCCPIIFNGO, int AAEAKJPHADF, int FDDPFMJOHLO, in Vector3 OGENEKOENLC, in Vector3 OMGOEKPFJCM)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		[PBOMGCLBFHF]
		protected void RpcAllCV2TryExplode(Vector3 PDFEDMAOMNH)
		{
		}

		public virtual void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public virtual void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		[CompilerGenerated]
		private int APPMIFHCFKJ()
		{
			return 0;
		}

		[CompilerGenerated]
		private void OINFLLHDEMD(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool JHLHKHMDAON()
		{
			return false;
		}

		[CompilerGenerated]
		private float EDOELJGPABF()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void FKOJDEHABPL(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool CICKNAJOCPF()
		{
			return false;
		}

		[CompilerGenerated]
		private int DFAFHBPCEGH()
		{
			return 0;
		}

		[CompilerGenerated]
		private void OCIMJHHBNGF(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool FKIKJCHPHKD()
		{
			return false;
		}

		[CompilerGenerated]
		private void KKFKDKDIJCC(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool KJFGHCHLCJD()
		{
			return false;
		}
	}
}
