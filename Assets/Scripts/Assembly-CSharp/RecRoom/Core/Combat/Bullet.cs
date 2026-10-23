using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Core.AI;
using UnityEngine;

namespace RecRoom.Core.Combat
{
	public class Bullet : MonoBehaviour
	{
		public enum MBFJEMFNNCK
		{
			Player = 0,
			Enemy = 1,
			Tool = 2,
			Trap = 3,
			Floor = 4,
			Wall = 5,
			Ceiling = 6
		}

		public delegate void NCIPEIJBCPC(Bullet NAIPJKGDKML, Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA);

		public delegate void CFNBCNKGNOH(Bullet NAIPJKGDKML, Enemy NJDDIIEPJDM, BHHAHFFCKJO MBKGKPOBHBB, NGLCDIDOEMK BNFNJFKJEOA);

		public delegate void HLBADGBCINE(Bullet NAIPJKGDKML, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA);

		public delegate void HPHBGDAPNFA(Bullet NAIPJKGDKML, Trap AOCKEAPKNDE, NGLCDIDOEMK BNFNJFKJEOA);

		public delegate void CMLEBIAFJLM(Bullet NAIPJKGDKML, NGLCDIDOEMK BNFNJFKJEOA);

		private sealed class OCOPIPMOKNI : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Bullet _003C_003E4__this;

			private float _003CstretchDistanceOnFinish_003E5__2;

			private float _003CstretchFinishDuration_003E5__3;

			private float _003CstretchDistanceOnImpact_003E5__4;

			private float _003Ctimer_003E5__5;

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
			public OCOPIPMOKNI(int _003C_003E1__state)
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

		[SerializeField]
		protected float colliderRadius;

		[SerializeField]
		private bool applyGravity;

		[SerializeField]
		private float gravityRatio;

		[SerializeField]
		private float airDrag;

		[SerializeField]
		public LLIOKBPEJMM destroyOnMask;

		[SerializeField]
		private float ignoreStaticCollisionsDuration;

		[SerializeField]
		private MBFJEMFNNCK[] reflectSurfaces;

		[SerializeField]
		private float minWallSlopeDegrees;

		[SerializeField]
		private int maxReflections;

		[SerializeField]
		private float restitution;

		[SerializeField]
		private bool supportsGravityAfterReflection;

		[SerializeField]
		private float selfDestructTime;

		[SerializeField]
		private float selfDestructDistance;

		[SerializeField]
		private bool enableInstancedVisualRendering;

		[SerializeField]
		private Renderer visualRenderer;

		[SerializeField]
		private string colorPropertyName;

		[SerializeField]
		private bool supportsDynamicColor;

		[SerializeField]
		private Color dynamicColor;

		[SerializeField]
		private bool supportsAnimatedDynamicColorBlending;

		[SerializeField]
		private Color animatedDynamicColorBlendingTargetColor;

		[SerializeField]
		private bool supportsDynamicColorDistanceFading;

		[SerializeField]
		private float maxFadeDistanceFromCamera;

		[SerializeField]
		private float minFadeDistanceFromCamera;

		[SerializeField]
		private float maxFadeDistanceAlpha;

		[SerializeField]
		private float minFadeDistanceAlpha;

		[SerializeField]
		private bool supportsVisualStretching;

		[SerializeField]
		protected Transform stretchTransform;

		[SerializeField]
		private float maxStretchDistance;

		[SerializeField]
		private bool calculateStretchFinishTime;

		[SerializeField]
		private float explicitStretchFinishTime;

		[SerializeField]
		private RecRoomAudioClip audioLoop;

		[SerializeField]
		private ParticleSystem particles;

		private static readonly int APIBCMEMPML;

		private const float PBGHEIKMADP = 9.8f;

		private int FEFIOGKFJKL;

		private bool EKOPPPJCCED;

		private JGPBDLMIGCH MNPNCLJPACM;

		private int LGLGMBCMEMB;

		private readonly DJIBCHKKBDJ CELCENMFAPE;

		private Vector3 OIEPDFJCEHE;

		private DJIBCHKKBDJ.MKEPPPJPDMB JHLEJMONOGI;

		private List<Collider> GEEGNLOGPDI;

		private float BHEFDILBFOI;

		private bool NMANDHBMNMF;

		private float LNCMDEJJJOM;

		private SFXAudioSource OBIMCHCLHEF;

		private Animator CBCFEAPCGEO;

		private UnityEngine.Animation ECBPKCIOODN;

		private TriggerToAnimationMapping PJFBMOJKBMH;

		protected float OOBOIODABDP;

		protected float DCMEJMPCMPM;

		protected bool HFKFLHFKJIF;

		protected GameObject DMGMDFOGEDM;

		protected BulletTrail DEAMKDNDKEM;

		protected byte IBEFDGKGLMD;

		private MaterialPropertyBlock HOOJEGOGAPE;

		private Vector3 EDGHCIEJHLG;

		private Action<Bullet> LNDMCKAEDDK__BackingField;

		private NCIPEIJBCPC NNGIDPFDOOJ__BackingField;

		private CFNBCNKGNOH PGHPEMJPIPD__BackingField;

		private HLBADGBCINE CJFAIHCGHIH__BackingField;

		private HPHBGDAPNFA BOIFECJJOGJ__BackingField;

		private CMLEBIAFJLM KEFHKOAMBJD__BackingField;

		private Vector3 LENMEDJPPFL;

		private float DGKOFGPFHLP;

		private float KGNFJHPJLMJ;

		private OKFEJNBJCBM IBNHJCCAGJN;

		private Color NBKKONBDLJP;

		private Player CHOPEMAAFLA;

		private Enemy MNKACOJEIKD;

		private Player EMHIAGNIMKK;

		protected float CIFIDIFMBND;

private Vector3 CDGNGEGFJLB
{
get 		{
			return default;
		}

set {
		}
}

protected float BIKKHJCNHLN
{
get 		{
			return 0f;
		}

set {
		}
}

protected float KDDJMBKBABP
{
get 		{
			return 0f;
		}

set {
		}
}

public OKFEJNBJCBM BulletGroup
{
get 		{
			return null;
		}

private set {
		}
}

public float GravityAcceleration
{
get 		{
			return 0f;
		}

}

public Color Color
{
get 		{
			return default;
		}

set {
		}
}

public Renderer VisualRenderer
{
get 		{
			return null;
		}

}

public ParticleSystem ParticleSystem
{
get 		{
			return null;
		}

}

public Player FiringPlayer
{
get 		{
			return null;
		}

private set {
		}
}

protected Enemy GIAMBANBFJJ
{
get 		{
			return null;
		}

private set {
		}
}

protected Player BGGDDGNMNNE
{
get 		{
			return null;
		}

private set {
		}
}

protected virtual Vector3 CCGKMEODAKB
{
get 		{
			return default;
		}

}

protected bool DADBGBEIHJF
{
get 		{
			return false;
		}

}

private float CMDHCCCPGJF
{
get 		{
			return 0f;
		}

set {
		}
}

public float SqrDistanceTraveled
{
get 		{
			return 0f;
		}

}

public float SelfdestructDistance
{
get 		{
			return 0f;
		}

}

public Vector3 Velocity
{
get 		{
			return default;
		}

}

public event Action<Bullet> DestroyEvent {
add {
		}
remove {
		}
}

public event NCIPEIJBCPC PlayerImpactEvent {
add {
		}
remove {
		}
}

public event CFNBCNKGNOH EnemyImpactEvent {
add {
		}
remove {
		}
}

public event HLBADGBCINE ToolImpactEvent {
add {
		}
remove {
		}
}

public event HPHBGDAPNFA TrapImpactEvent {
add {
		}
remove {
		}
}

public event CMLEBIAFJLM OtherImpactEvent {
add {
		}
remove {
		}
}

		public void Fire(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 KGIOBJMPLKI, float IKIAOEADGLL, float BHEFDILBFOI, List<Collider> GEEGNLOGPDI, DJIBCHKKBDJ.MKEPPPJPDMB JHLEJMONOGI, byte JNHGFONGOCO, bool FGFPPJJKHMN = false, float LNCMDEJJJOM = 1f, Player EKMGJPMBLCP = null)
		{
		}

		public virtual void Fire(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 KGIOBJMPLKI, float IKIAOEADGLL, float BHEFDILBFOI, List<Collider> GEEGNLOGPDI, DJIBCHKKBDJ.MKEPPPJPDMB JHLEJMONOGI, float PDGCNICBLGN, byte JNHGFONGOCO, bool FGFPPJJKHMN = false, float LNCMDEJJJOM = 1f, Player EKMGJPMBLCP = null)
		{
		}

		private void LOJMFIDCCOE()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void FixedUpdate()
		{
		}

		public virtual void Release(Vector3 PIGMAEFKNPK)
		{
		}

		protected bool GNDPENGDINA(Vector3 BEEINBKHHBI, Vector3 CDCEFBJHIAN, float NNLEGJGIGHA, int MPJGCPAKKKA, bool AAGOEMLOGCG = true)
		{
			return false;
		}

		private IEnumerator KONLBNAIDKL(Vector3 PIGMAEFKNPK)
		{
			return null;
		}

		protected void GADOPDKEFAD()
		{
		}

		protected void COBDKBCDBGH()
		{
		}

		private bool LIDNFJPGGAE(Vector3 ANFJCMMNHMA, out FDDLOCDBFDL KHFHAAMKDHD)
		{
			KHFHAAMKDHD = default;
			return false;
		}

		private Vector3 HEHEMHDPHBB(Vector3 CDCEFBJHIAN, int IOKJAGEDAOO)
		{
			return default;
		}

		protected virtual void JJKLAFOLJBI(FDDLOCDBFDL JJNEFKHCABA)
		{
		}

		private bool MOKDKKPMLGE(FDDLOCDBFDL KHFHAAMKDHD)
		{
			return false;
		}

		public void SetBulletGroup(OKFEJNBJCBM CIFHMNKCLNG)
		{
		}

		private void PFHCKKIBBAD(Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void BADNPOJDELK(Enemy NJDDIIEPJDM, BHHAHFFCKJO EKJJODPHDJK, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void HBALFKKDLMH(Tool IEGMBEPJMGC, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void DLOCFGGPHDO(Trap MBLENDJGFCI, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void ANNGGMANNPH(NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private bool KGGFOPIAFCP(GameObject DACMEDJANGO)
		{
			return false;
		}

		private bool HGNGLLCDKPI()
		{
			return false;
		}

		private void HHIKGDGEIEE(Color HMCAFGCGFJF)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
