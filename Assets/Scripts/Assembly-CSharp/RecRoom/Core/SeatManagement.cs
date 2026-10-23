using System.Collections.Generic;
using Photon.Pun;
using RecRoom.Core.DataStructures;
using UnityEngine;

namespace RecRoom.Core
{
	public class SeatManagement : MonoBehaviourPun
	{
		public delegate bool FDMADKNOFCI(CHILKDJABBF EKOFNPFCLMO, SeatManagement HGHEJNOMIJN);

		private sealed class HHMCEFOCDOA
		{
			public Vector3 lookDirectionOnPlane;

			internal int _003CGetExitPosition_003Eg__ExitDirectionComparer_007C0(Vector3 a, Vector3 b)
			{
				return 0;
			}
		}

		private const float JDPHGLOHPML = 0.25f;

		private const float LGGDJEDJOLK = 0.25f;

		public EEANDDJEMJC LocalPlayerStartedSitting;

		public EEANDDJEMJC LocalPlayerStoppedSitting;

		public global::CBEFDECGNBJ<SeatManagement, Player, Player> SeatedPlayerChangeEvent;

		[SerializeField]
		private SeatPortal seatPortal;

		[SerializeField]
		private float preferredExitDistance;

		[SerializeField]
		private bool sittingEnabledDefault;

		[SerializeField]
		private FHADGLMJMBB.LFELNCBPKCP.MNKMFCHLIFD postureDefault;

		[SerializeField]
		private bool cameraSmoothingEnabledDefault;

		[SerializeField]
		private bool cameraRecenteringEnabledDefault;

		private readonly List<FDMADKNOFCI> FCJJFBPGGHG;

		protected global::JCAAOOPEEAM<CHILKDJABBF, CHILKDJABBF> IDEIAJBMBJI;

		private bool GADOKJMIOFB;

		protected global::CDLJMENCODC<bool> ICAHOPHBMBC;

		protected global::CDLJMENCODC<bool> HKNLLEFFAEF;

		private global::MOBDJNEDDKC<bool> AEAOJNIELPD;

		private global::MOBDJNEDDKC<FHADGLMJMBB.LFELNCBPKCP.MNKMFCHLIFD> LKMDHIFIKIC;

		private global::MOBDJNEDDKC<bool> AGHMDHOBICJ;

		private global::MOBDJNEDDKC<bool> BPDAMNFHHLL;

public CHILKDJABBF SeatedPlayer
{
get 		{
			return null;
		}

private set {
		}
}

public CHILKDJABBF LastSeatedNonNullPlayer
{
get 		{
			return null;
		}

}

public bool IsRapidlyAccelerating
{
get 		{
			return false;
		}

private set {
		}
}

public bool HasSeatedPlayer
{
get 		{
			return false;
		}

}

public virtual bool CanAnyPlayerSit
{
get 		{
			return false;
		}

}

public bool LockPlayersOut
{
get 		{
			return false;
		}

private set {
		}
}

public bool LockPlayersIn
{
get 		{
			return false;
		}

set {
		}
}

public RigidbodyEx ParentingRigidbodyEx
{
get 		{
			return null;
		}

}

public ReferencePoint AnchorPoint
{
get 		{
			return null;
		}

}

public bool SittingEnabled
{
get 		{
			return false;
		}

set {
		}
}

public FHADGLMJMBB.LFELNCBPKCP.MNKMFCHLIFD Posture
{
get 		{
			return FHADGLMJMBB.LFELNCBPKCP.MNKMFCHLIFD.Sitting;
		}

set {
		}
}

public bool CameraSmoothingEnabled
{
get 		{
			return false;
		}

set {
		}
}

public bool CameraRecenteringEnabled
{
get 		{
			return false;
		}

set {
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

		public virtual bool CanPlayerSit(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		public bool CanPlayerLeaveSeat(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		public bool TrySetSeatedPlayer(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		public bool TryRemoveSeatedPlayer(CHILKDJABBF GFOKHNPOAEI, bool ILFKAPMMBGF = false)
		{
			return false;
		}

		public void AddCustomSeatRestriction(FDMADKNOFCI LAJHMOFNACN)
		{
		}

		public void RemoveCustomSeatRestriction(FDMADKNOFCI LAJHMOFNACN)
		{
		}

		public void SetRapidAcceleration(bool DDDNOPONLBI)
		{
		}

		private void OJJBMHJKBOG()
		{
		}

		public Vector3 GetExitPosition()
		{
			return default;
		}

		private static bool NNDIIMGDPMD(float GHAEJDCDBBB, float IJHMKEIOKHN, float PIENCEOOIDI = 0.25f)
		{
			return false;
		}

		private bool GEJNFMKELHN(Vector3 PEJEOHJJKBA, ref Vector3 AMFIGFLDJNJ, out float JOPOKBJLGOE)
		{
			JOPOKBJLGOE = default;
			return false;
		}

		private bool LLGHCFBKBDJ(Vector3 PEJEOHJJKBA, Vector3 AMFIGFLDJNJ, int LPOCBHANIMD)
		{
			return false;
		}

		private bool DNIBEEPLDHD(Collider ADMCDJKKCIA)
		{
			return false;
		}

		protected virtual void AGEEFCKONMC()
		{
		}

		private void NPBBLFBLLEB()
		{
		}

		private void OnPhotonPlayerDisconnected(CHILKDJABBF MFINCDBKKOB)
		{
		}

		private void NEFDMMHDGEJ()
		{
		}

		private void ALAHPDEFKLI()
		{
		}

		protected void CJLJLEPGFHA()
		{
		}
	}
}
