using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Core.Combat
{
	public class ProjectileTool : MonoBehaviourPun
	{
		public delegate void JGCNNLBBMKO(ProjectileTool PMEFICGEDFK, Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA);

		public delegate void EPJGEEDFEHF(ProjectileTool PMEFICGEDFK, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA);

		public delegate void ILLJLPFGPFB(ProjectileTool PMEFICGEDFK, Enemy NJDDIIEPJDM, BHHAHFFCKJO GFHNJGJNNCK, NGLCDIDOEMK BNFNJFKJEOA);

		public delegate void OFEKNIPEFIB(ProjectileTool PMEFICGEDFK, Trap AOCKEAPKNDE, NGLCDIDOEMK BNFNJFKJEOA);

		public delegate void FJEDLNPHJFH(ProjectileTool PMEFICGEDFK, NGLCDIDOEMK BNFNJFKJEOA);

		public delegate void LLFMEPPKGBB(ProjectileTool PMEFICGEDFK, Vector3 PDFEDMAOMNH, bool AANGHIPHJFD);

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private float projectileForce;

		[SerializeField]
		private float defaultMaxLifetime;

		[SerializeField]
		private bool useGravity;

		[SerializeField]
		private bool canBePickedUp;

		[SerializeField]
		private bool faceVelocity;

		[SerializeField]
		private PooledParticle timeoutParticlesPrefab;

		[SerializeField]
		private RecRoomAudioClip timeoutAudio;

		private JGCNNLBBMKO NNGIDPFDOOJ__BackingField;

		private EPJGEEDFEHF CJFAIHCGHIH__BackingField;

		private ILLJLPFGPFB PGHPEMJPIPD__BackingField;

		private FJEDLNPHJFH KEFHKOAMBJD__BackingField;

		private LLFMEPPKGBB HFELOMLMBKE__BackingField;

		private BulletTrail DEAMKDNDKEM;

		private HONEDBECDOK PBGDDCKLHOH;

public Tool Tool
{
get 		{
			return null;
		}

}

public event JGCNNLBBMKO PlayerImpactEvent {
add {
		}
remove {
		}
}

public event EPJGEEDFEHF ToolImpactEvent {
add {
		}
remove {
		}
}

public event ILLJLPFGPFB EnemyImpactEvent {
add {
		}
remove {
		}
}

public event FJEDLNPHJFH OtherImpactEvent {
add {
		}
remove {
		}
}

public event LLFMEPPKGBB FinishEvent {
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

		protected override void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		public void AuthorityFire(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 KGIOBJMPLKI)
		{
		}

		public void AuthorityFire(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 KGIOBJMPLKI, float OOBOIODABDP)
		{
		}

		public void AuthorityFinish(bool AANGHIPHJFD = false)
		{
		}

		private void MBIOLEBFOOM(Tool PMEFICGEDFK, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		[PBOMGCLBFHF]
		private void RpcFinish(Vector3 FNGPLHKBMNN, Quaternion DNECFFPAGKG, bool AANGHIPHJFD, Vector3 AJCPOIGIDNH)
		{
		}

		private void OnCollisionEnter(Collision KDGCDLJEAMD)
		{
		}
	}
}
