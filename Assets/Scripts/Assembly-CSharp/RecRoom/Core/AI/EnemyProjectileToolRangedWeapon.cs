using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core.Combat;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Core.AI
{
	public class EnemyProjectileToolRangedWeapon : EnemyRangedWeaponBase
	{
		public enum ICCGEAFMOFE
		{
			TO_ENEMY_SUCCESS = 0,
			TO_ENEMY_FAIL = 1,
			TO_PLAYER = 2
		}

		public delegate void IOPBPLKOFHF(ProjectileTool PPKCLLBILPJ, ICCGEAFMOFE LCOBMGBHOJJ, Vector3 PDFEDMAOMNH, Vector3 FJEIPCCFKEB);

		public delegate void LGBNGMGHIAG(ProjectileTool HKEPPKCNEPN, Enemy JMBOIKNLKPH, Enemy NJDDIIEPJDM, BHHAHFFCKJO ALOJEPEGILE, NGLCDIDOEMK BNFNJFKJEOA);

		private sealed class KBPAHLIGMGH : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EnemyProjectileToolRangedWeapon _003C_003E4__this;

			public Tool hitTool;

			public ProjectileTool thisProjectile;

			public NGLCDIDOEMK impact;

			private int _003Ci_003E5__2;

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
			public KBPAHLIGMGH(int _003C_003E1__state)
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

		private sealed class EDIGEGHAFJB : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EnemyProjectileToolRangedWeapon _003C_003E4__this;

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
			public EDIGEGHAFJB(int _003C_003E1__state)
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
		private ProjectileTool projectilePrefab;

		[SerializeField]
		private float defaultProjectileSpeed;

		[SerializeField]
		private float maxReturnSpeed;

		[SerializeField]
		private float failReturnSpeed;

		[SerializeField]
		private float successReturnLifetime;

		[SerializeField]
		private float failReturnLifetime;

		[SerializeField]
		private bool canBeReflectedByAttacks;

		[SerializeField]
		private DJBEHNDMJDL[] damageTypesThatAlwaysReflect;

		[SerializeField]
		private Transform reflectionTarget;

		[SerializeField]
		private PooledParticle reflectionParticlesPrefab;

		[SerializeField]
		private RecRoomAudioClip reflectionToEnemyAudio;

		[SerializeField]
		private RecRoomAudioClip reflectionToEnemyFailAudio;

		[SerializeField]
		private RecRoomAudioClip reflectionToPlayerAudio;

		private const int AEMDGGPENJK = 1;

		private const float IEABGFILPEC = 2f;

		private const float DAGDNEOADMI = 90f;

		private global::MOBDJNEDDKC<int> ABJOBIMIHOG;

		private float MDJBMEJLKJF;

		private Coroutine BDOJPENCKJN;

		private Coroutine JMOLGLMBNPJ;

		private bool PKAOPMIHLGH;

		private IOPBPLKOFHF CHCCHBGNOGJ__BackingField;

		private ProjectileTool HJAIPHGMEIN;

		private LGBNGMGHIAG NAIAAGDDNKH;

public ProjectileTool ProjectileTool
{
get 		{
			return null;
		}

private set {
		}
}

public LGBNGMGHIAG CustomProjectileEnemyImpactResolution
{
get 		{
			return null;
		}

set {
		}
}

private Vector3 EMADABPFADD
{
get 		{
			return default;
		}

}

public event IOPBPLKOFHF ReflectionEvent {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		protected void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override float JNGEHFIOODP(float JEFDIJMDBOF)
		{
			return 0f;
		}

		protected override void HDMBFJDNMEM(Vector3 GFCPAMJILIO, float DMIPMFMPLAP)
		{
		}

		private void BNHNAOOIMLE()
		{
		}

		private void DPNPCEFCGJL(Tool IEGMBEPJMGC)
		{
		}

		private void PBFDNALJNNG()
		{
		}

		private void EBAECJCMMCM(ProjectileTool PPKCLLBILPJ, Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void HDHIAOLNBPE(ProjectileTool PPKCLLBILPJ, Enemy NJDDIIEPJDM, BHHAHFFCKJO ALOJEPEGILE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void KLNPMEHDJFD(ProjectileTool PPKCLLBILPJ, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void DGPLBLIAFDB(ProjectileTool PPKCLLBILPJ, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void BAJGMBHPIDC(ProjectileTool PPKCLLBILPJ, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void HALIELBDAEL(ProjectileTool HKEPPKCNEPN, Vector3 PDFEDMAOMNH, bool AANGHIPHJFD)
		{
		}

		public void AuthorityReflect(Vector3 GFCPAMJILIO, float DMIPMFMPLAP, ICCGEAFMOFE LCOBMGBHOJJ = ICCGEAFMOFE.TO_PLAYER)
		{
		}

		public void AuthorityReflect(Vector3 GFCPAMJILIO, float DMIPMFMPLAP, Vector3 CDCEFBJHIAN, Quaternion GDHHCIKHKAJ, ICCGEAFMOFE LCOBMGBHOJJ = ICCGEAFMOFE.TO_PLAYER)
		{
		}

		public void AuthorityReflect(Vector3 GFCPAMJILIO, float DMIPMFMPLAP, float OOBOIODABDP, ICCGEAFMOFE LCOBMGBHOJJ = ICCGEAFMOFE.TO_PLAYER)
		{
		}

		public void AuthorityReflect(Vector3 GFCPAMJILIO, float DMIPMFMPLAP, float OOBOIODABDP, Vector3 CDCEFBJHIAN, Quaternion GDHHCIKHKAJ, ICCGEAFMOFE LCOBMGBHOJJ = ICCGEAFMOFE.TO_PLAYER)
		{
		}

		private void KJKLPJEHEBD(MeleeWeapon PBFOIPMNIMM)
		{
		}

		private bool FAAGCEBIMLO(DJBEHNDMJDL IKEDGLGPGEA)
		{
			return false;
		}

		private void DOBPLHDDHIF(Tool CKLECOHPAEN, MonoBehaviourPun GLLFHCCFIGK, DJBEHNDMJDL IKEDGLGPGEA, Vector3 PDFEDMAOMNH, Vector3 COPOILGLIAJ, ForceMode OJOAKAEAKAC)
		{
		}

		private void DLFBIJOJHED(ICCGEAFMOFE LCOBMGBHOJJ)
		{
		}

		private void DOHOOKOJBIB(ref Vector3 COPOILGLIAJ, Vector3 PDFEDMAOMNH, ForceMode OJOAKAEAKAC, DJBEHNDMJDL IKEDGLGPGEA)
		{
		}

		private void DNMNJFJJKJA(ref Vector3 MCBCBMFBKCA, ref Vector3 MEBJBANMPLK, Vector3 PDFEDMAOMNH)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnReflection(ICCGEAFMOFE LCOBMGBHOJJ, Vector3 PDFEDMAOMNH, Vector3 FJEIPCCFKEB)
		{
		}

		private void LNFHKDFGOEL(ProjectileTool PPKCLLBILPJ, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void ENKOCJOMGHL()
		{
		}

		private IEnumerator IINFACOHOBF(ProjectileTool PPKCLLBILPJ, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
			return null;
		}

		private void MKLFGHLPCDD()
		{
		}

		private void ONMFODGDFEL()
		{
		}

		private IEnumerator OADEMBIABLE()
		{
			return null;
		}
	}
}
