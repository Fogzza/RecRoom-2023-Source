using System;
using RecRoom.Activities;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using RecRoom.Core.DataStructures;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class Whip : ExplosiveRangedWeapon
	{
		public enum BJCHMCHJNOB
		{
			Primed = 0,
			Uncoiling = 1,
			Hooked = 2,
			Cracking = 3,
			Coiling = 4
		}

		[Serializable]
		public struct IntervalContainer
		{
			public float min;

			public float max;

			public float CONCMILKFON(float NIEDFCCLPAB)
			{
				return 0f;
			}
		}

		public static readonly Collider[] instantaneousOverlapResults;

		[SerializeField]
		private float popperReleaseVelocityMultiplier;

		[SerializeField]
		private float popperCollisionForgivenessTime;

		[SerializeField]
		private float maxLengthReachedForgivenessTime;

		[SerializeField]
		private FloatValueCurve powerOverDistance;

		[SerializeField]
		private IntervalContainer blastRadiusOverDistance;

		[SerializeField]
		private float coilingTime;

		[SerializeField]
		private MeshRenderer coiledThongMeshRenderer;

		[SerializeField]
		private ReferencePoint thongAttachPoint;

		[SerializeField]
		private ReferencePoint popperPrimedPosition;

		[SerializeField]
		private PooledParticle weakCrackParticleEffect;

		[SerializeField]
		private PooledParticle strongCrackParticleEffect;

		[SerializeField]
		private Vector3 minRopeFirstHandle;

		[SerializeField]
		private Vector3 maxRopeFirstHandle;

		[SerializeField]
		private Vector3 minRopeSecondHandle;

		[SerializeField]
		private Vector3 maxRopeSecondHandle;

		[SerializeField]
		private float minToMaxInterpolationDistance;

		[SerializeField]
		private RecRoomAudioClip weakCrackAudioClip;

		[SerializeField]
		private RecRoomAudioClip strongCrackAudioClip;

		[SerializeField]
		private float strongCrackPowerThreshold;

		[SerializeField]
		private float strongThrowSpeedThreshold;

		[SerializeField]
		private float whipGestureStartSpeed;

		[SerializeField]
		private float whipGestureCrackSpeed;

		[SerializeField]
		private float whipGestureReleaseTime;

		[SerializeField]
		private AnimationCurve toolPullArcTimeByDistance;

		[SerializeField]
		private AnimationCurve toolPullAccuracyByAimAccuracy;

		[SerializeField]
		private float hookMagnetDistance;

		[SerializeField]
		private LayerMask hookMagnetLayers;

		[SerializeField]
		private float hookMagnetMinDistance;

		private const float GJKONPCPKDF = 0.6f;

		private const float MBKMDJHGBCL = 3.5f;

		private const int FOJLDIBHNCB = 20;

		private JOJOABLFOBA NFFDOCOKNKL;

		private global::MOBDJNEDDKC<bool> IMAMNCJJKIO;

		private Vector3 HKHIDEEDHJF;

		private Vector3 KGKAKIPPJKE;

		private Vector3 CBBFFOCHINJ;

		private float DGEGHMECODL;

		[NonSerialized]
		public bool GestureWhipping;

		private bool FACIEBECDBN;

		private float KNNIPHDEFJK;

		private bool DAEOHBOIJBL;

		private global::MOBDJNEDDKC<int> JADMFFLFKOK;

		private WhipInteractable EGADHNLKEHI;

		[SerializeField]
		private WhipPopper popper;

		private float EGGNBCOAKGF;

		private float GGKMCECEJPB;

		private float FNPLMPNHAFG;

		[SerializeField]
		private LineRenderer ropeRenderer;

		private Vector3[] NJELECCAOLL;

		private KKGCOBPPLHO NNHPFJJKFGO;

public BJCHMCHJNOB CurrentWhipState
{
get 		{
			return BJCHMCHJNOB.Primed;
		}

private set {
		}
}

public bool DisablePopperGravity
{
get 		{
			return false;
		}

set {
		}
}

public bool PopperHitSomething
{
get 		{
			return false;
		}

private set {
		}
}

private WhipInteractable AEFOPAOOHNP
{
get 		{
			return null;
		}

set {
		}
}

protected override Color EGOOKBNKAEM
{
get 		{
			return default;
		}

}

public Vector3 PopperPrimedPosition
{
get 		{
			return default;
		}

}

		protected override void Awake()
		{
		}

		private void GAHHBGJBCCA(float ICHBECDKHOJ)
		{
		}

		private void LateUpdate()
		{
		}

		private void FixedUpdate()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void BADDDAJMOCB(Bullet HCLJODLNCNE)
		{
		}

		private void IEELJEBHDEI(Tool IEGMBEPJMGC)
		{
		}

		private void JFGMIGPAJNO(Tool IEGMBEPJMGC)
		{
		}

		private void GENLBDDFFIN(Tool IEGMBEPJMGC, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK)
		{
		}

		private void AOJEOHLFLDC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void FBGFNLJALMA()
		{
		}

		private void CHGGDFAKHGM(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void JPNKPJIKONE()
		{
		}

		private void LLMGHNNFGEC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void JFDMMKHAJJG(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void NAOKCBLIOPJ()
		{
		}

		private void BLKGBALNANK(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void HGOJECIGPDD()
		{
		}

		private void HBNJKDOHHCG(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void CHPHLBPLLJF()
		{
		}

		private void EIKBIKLMGMA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void NJNFOFDKCLM()
		{
		}

		private void OCBAGDNJHPG()
		{
		}

		public void UpdateWhippingGesture(Vector3 FJEIPCCFKEB)
		{
		}

		public void AuthorityManualUncoil(Vector3 HKHIDEEDHJF)
		{
		}

		public void AuthorityManualCrack(Vector3 CAKJBMCCMOP)
		{
		}

		protected override Bullet LIPKDHINPGF(Bullet GDEKLMNKJBC = null)
		{
			return null;
		}

		protected override void MPNCIDCFDNM(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 OIEPDFJCEHE, float BHEFDILBFOI, bool GHCPLAPAGHB, byte CMBCNFBLLNI)
		{
		}

		protected override void KAONGFGOMNK(float FHFDDKOBFLG, Vector3 INLGLHIPOMC, float NNLEGJGIGHA, float BHEFDILBFOI)
		{
		}

		private void ILCMOOKMKDA(Bullet NAIPJKGDKML, Enemy NJDDIIEPJDM, BHHAHFFCKJO MBKGKPOBHBB, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void LJJEJDFHIAD(Bullet NAIPJKGDKML, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void PNMBBLBHOLB(Bullet NAIPJKGDKML, Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void BOBGDFBMPKJ(Bullet NAIPJKGDKML, Trap AOCKEAPKNDE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void FMJJENEGHBN(Bullet NAIPJKGDKML, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void MHOBAKIOGEE(NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void LBCNCAJOOJJ(Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void KBOFMAGIGAE(Enemy NJDDIIEPJDM, BHHAHFFCKJO GFHNJGJNNCK, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void BAPNMFLDAFL(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void BGACPKCBJKB(Trap AOCKEAPKNDE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
