using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom
{
	public class PoolTable : MonoBehaviourPun, GAAKCFPLMHN, DJLCHGFCFAD, KLCFHMGAPPO
	{
		private enum GDIGDEIGKCH
		{
			Standard8Ball = 0,
			Standard9Ball = 1
		}

		private sealed class MNNAIDEJAPP : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public PoolTable _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public MNNAIDEJAPP(int _003C_003E1__state)
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
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private static readonly List<PoolTable> HMHGHBLDOON;

		public const int NUM_BALLS = 16;

		private const float FKGAMIKOMKH = 0.35f;

		private const float GMICMLDAGPI = 1f;

		private const float EAEIMFGKMNO = 3f;

		private const float IPKJIJOCDAA = 9f;

		private const float JHPNHICPFEI = 0.001f;

		private const float NLJALOPOKGC = 0.3f;

		private const float GNOOPBOODMG = 1f;

		private static string[] FANLOPDEGMC;

		[SerializeField]
		private PoolBall poolBallPrefab;

		[SerializeField]
		private RecRoomAudioClip resetTableAudioClip;

		[SerializeField]
		private Transform surfaceCenter;

		[SerializeField]
		private Transform ballSurfaceCenter;

		[SerializeField]
		private Collider surfaceBoundingBox;

		[SerializeField]
		private Transform ballReturnPoint;

		[SerializeField]
		private Transform cueBallReturnPoint;

		[SerializeField]
		private Transform frontBallResetPoint;

		[SerializeField]
		private Transform cueBallResetPoint;

		[SerializeField]
		private Transform cueBallDropPoint;

		[SerializeField]
		private ChargePhysicalButton resetButton8Ball;

		[SerializeField]
		private ChargePhysicalButton resetButton9Ball;

		[SerializeField]
		private Tool tool;

		private PoolBall[] JECDNOLFDOL;

		private Vector3[] PCLEFEJCPAK;

		private global::BDOFFIKKMIO<int> LBEMCIDBFCL;

		private global::MOBDJNEDDKC<bool> LANNOJJAFEL;

		private NGJPBEEINBG BJHFGBFCCEO;

public Transform SurfaceCenter
{
get 		{
			return null;
		}

}

public Transform BallSurfaceCenter
{
get 		{
			return null;
		}

}

public Collider SurfaceBoundingBox
{
get 		{
			return null;
		}

}

public Tool Tool
{
get 		{
			return null;
		}

}

public PoolBall CueBall
{
get 		{
			return null;
		}

}

public bool IsBreakAssistActive
{
get 		{
			return false;
		}

set {
		}
}

public NGJPBEEINBG InteractionFilter
{
get 		{
			return default;
		}

}

 bool global::DJLCHGFCFAD.BlockObjectPersistance
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

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void KGEOIOGEAMI()
		{
		}

		private void OnCollisionEnter(Collision KDGCDLJEAMD)
		{
		}

		private void BLAGANBLLGC(RigidbodyEx IDCFALFGPFP)
		{
		}

		private void NGGOKABDDHB()
		{
		}

		private IEnumerator<EGGPGCCKPCO> IDLJBBMJGGI()
		{
			return null;
		}

		private void EIPLGJNOLLA(ChargePhysicalButton HHDMPJJAPJJ)
		{
		}

		private void EELCPFOBDIK(ChargePhysicalButton HHDMPJJAPJJ)
		{
		}

		private void EBOILHNNNAJ(GDIGDEIGKCH GAFCGPJFILJ)
		{
		}

		private void DFELHHECAPK(GDIGDEIGKCH GAFCGPJFILJ)
		{
		}

		public void ApplyBreakAssist(Collision KDGCDLJEAMD)
		{
		}

		private void NMBKNDFBPAH(ref Vector3[] PBIKLHHJHAB, GDIGDEIGKCH GAFCGPJFILJ)
		{
		}

		private void KMKJMNHHFOA(ref Vector3[] PBIKLHHJHAB, int CCCANJLMAAN, int[] EOLJKPKCDEJ)
		{
		}

		public void TakeOwnership()
		{
		}

		public void MoveBall(PoolBall PMFMNEJCNDJ, Vector3 INLGLHIPOMC)
		{
		}

		public void MoveBall(int EEDPPCEFFFH, Vector3 INLGLHIPOMC)
		{
		}

		public void DropCueBall()
		{
		}

		public bool IsPointOnTable(Vector3 COLMAMKJPJE)
		{
			return false;
		}

		public bool IsBallOnTable(int EEDPPCEFFFH)
		{
			return false;
		}

		public bool IsBallOnTable(PoolBall PMFMNEJCNDJ)
		{
			return false;
		}

		[PBOMGCLBFHF]
		private void RpcMasterResetPoolTable(GDIGDEIGKCH GAFCGPJFILJ)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnResetPoolTable()
		{
		}

		public static bool TryFindPoolTable(Vector3 CLCFHOIHAIG, float MFOGILMODNN, Vector3 OAEKEFIBDIH, out PoolTable CIIJLNENDFK)
		{
			CIIJLNENDFK = null;
			return false;
		}

		private static bool NANEAONOGLA(PoolTable GBDIHOGAGFP, Vector3 AIFIKEGOLKP, float EKBBFGEPAIJ, Vector3 MHMIACIGOBE, out float JOPOKBJLGOE)
		{
			JOPOKBJLGOE = default;
			return false;
		}

		public void ResetObject()
		{
		}

		private void JCFCLJLLBFB(NLOGDCDGECD FFILBGADKKN)
		{
		}

		void DJLCHGFCFAD.DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
			//ILSpy generated this explicit interface implementation from .override directive in JCFCLJLLBFB
			this.JCFCLJLLBFB(FFILBGADKKN);
		}

		private void NPJBEOAIFFL(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		void DJLCHGFCFAD.SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NPJBEOAIFFL
			this.NPJBEOAIFFL(ref FCJBDJOMIHI, ref JIEECFLEPDI, AAMCGPPJPFM);
		}

		private bool NHOHKALPOEN(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		bool KLCFHMGAPPO.ALJKCFGGOJH(CHILKDJABBF EKOFNPFCLMO)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NHOHKALPOEN
			return this.NHOHKALPOEN(EKOFNPFCLMO);
		}

		[CompilerGenerated]
		private void NJKFDGOLBLE()
		{
		}

		[CompilerGenerated]
		private void FJDJDKFNLBP()
		{
		}
	}
}
