using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core.Pools;
using TMPro;
using UnityEngine;

namespace RecRoom.Core
{
	public sealed class GiftBox : MonoBehaviourPun
	{
		private struct IMDJKJGPCKI
		{
			public Rigidbody NKEHGJNPKJI;

			public Vector3 KIJJFLMPGME;

			public Quaternion NELEDPLLGGE;
		}

		[Serializable]
		private struct RewardVisualsSettings
		{
			public float timeBeforeDerez;

			public float rewardTextHeight;

			public float rewardTextScale;

			public float rewardParticleRootHeight;
		}

		private sealed class POCHIBFLPGI : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GiftBox _003C_003E4__this;

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
			public POCHIBFLPGI(int _003C_003E1__state)
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

		public const float DEFAULT_CLOSE_TO_PLAYER_DISTANCE = 2.2f;

		private List<IMDJKJGPCKI> FCEJMFEKBLG;

		private Vector3 LMLFDGJMNLN;

		private static readonly Vector3 AJEOLPCJPKC;

		[SerializeField]
		private BaseOpenableChest chest;

		[SerializeField]
		private GiftBoxItemContainer toolContainer;

		[SerializeField]
		private PooledParticle xpBoxOpenedParticlePrefab;

		[SerializeField]
		private PooledParticle itemBoxOpenedParticlePrefab;

		[SerializeField]
		private Transform boxOpenedParticleRoot;

		[SerializeField]
		private Transform toolAnchor;

		[SerializeField]
		private TextMeshPro xpText;

		[SerializeField]
		private TextMeshPro messageText;

		[SerializeField]
		private TextMeshPro nameText;

		[SerializeField]
		private Animator toolAnchorAnimator;

		[SerializeField]
		private RecRoomAudioClip boxAppearAudio;

		[SerializeField]
		private RecRoomAudioClip[] boxOpenAudio;

		[SerializeField]
		private Renderer[] variantMaterialRenderers;

		private EDDPDJCKOBH.GMBCAMAAPMN JILJEPBFNBO;

		private CHILKDJABBF AIEDNIDIHFB;

		private PlayerSpawnedEquipment JAICPINNCOL;

		[SerializeField]
		private RewardVisualsSettings defaultVisualsSettings;

		private global::MOBDJNEDDKC<DKLKDCNIDLI> NDMBABBEBNF;

		private global::MOBDJNEDDKC<int> CHIKPLOAJKD;

		public float CloseToPlayerDistance;

		public Action<GiftBox> OnGiftBoxDestroyed;

		public static Action<GiftBox> OnLocalGiftBoxOpened;

public Vector3 spawnPosition
{
get 		{
			return default;
		}

set {
		}
}

public bool IsOwnerLocal
{
get 		{
			return false;
		}

}

public DKLKDCNIDLI BoxContents
{
get 		{
			return DKLKDCNIDLI.XP;
		}

private set {
		}
}

public int BoxContentViewId
{
get 		{
			return 0;
		}

private set {
		}
}

public bool CloseToPlayer
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		private void Update()
		{
		}

		private void KGGDICDLAOM()
		{
		}

		private void OCMJFABEGEI(EDDPDJCKOBH.GMBCAMAAPMN JILJEPBFNBO)
		{
		}

		private void AMMLAPNLCAE(EDDPDJCKOBH.GMBCAMAAPMN JILJEPBFNBO)
		{
		}

		private void HAMHIPAOINF(EDDPDJCKOBH.GMBCAMAAPMN JILJEPBFNBO)
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void AHPAIABLKOM()
		{
		}

		private void DDIFGCNKPFJ(PhotonView BKFJMCAAIKF)
		{
		}

		private void IEEHHONMJGK(BaseOpenableChest IEODCBDCDFF)
		{
		}

		private void KBGFPPDHLKF()
		{
		}

		private void NOBIPNAAOJN()
		{
		}

		private void DBCCJBHCKGB()
		{
		}

		private void KDNNDDIHBEK()
		{
		}

		private void ICADACDOPGG()
		{
		}

		private void IFCPFONJOGK()
		{
		}

		private void HGDDLCNPPOD(PlayerSpawnedEquipment JAICPINNCOL)
		{
		}

		private bool CNLCMLFPLFN(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
		{
			return false;
		}

		private void CPLKPKENFAF()
		{
		}

		private IEnumerator ONJIDNJPGJO()
		{
			return null;
		}

		[CompilerGenerated]
		private void NONGJMBNDLO(DFDECAEJBIO IGNHPEDCMJF)
		{
		}
	}
}
