using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using RecRoom.Core;
using UnityEngine;

namespace RecRoom.Tools
{
	public class FlagTool : MonoBehaviourPun
	{
		public delegate void IPGPGKAPCGB(FlagTool HGMIOJAFADH, GIBEGHKMCIE FMOKAADPMDE, Player NGHIMLOOILF);

		public delegate void BCGHFJLNJEL(FlagTool HGMIOJAFADH, Player DGNDAEPILMF);

		public delegate void HIFLHFAEJBD(FlagTool HGMIOJAFADH, Player CLAAKJAFDLA);

		public delegate void PKACAKELOOK(FlagTool HGMIOJAFADH, Player EJCJDCBJCLP);

		public delegate void LJBFOCLJNNM(FlagTool HGMIOJAFADH);

		private sealed class NFKDMOCCMJA
		{
			public FlagTool _003C_003E4__this;

			public Tool tool;

			internal void _003COnPostPickup_003Eb__0()
			{
			}
		}

		private static readonly List<FlagTool> PCLBMFCGDNO;

		private static readonly int EIBEHEDBDPB;

		[SerializeField]
		private GIBEGHKMCIE team;

		[SerializeField]
		private Renderer beamRenderer;

		[SerializeField]
		private TeamColorRenderer teamColor;

		[SerializeField]
		private PaintballVisibilityBehaviour visibilityBehaviour;

		[SerializeField]
		private int settingsPriority;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private GenericPortal returnPortal;

		[SerializeField]
		private Transform goalAttachPoint;

		private global::MOBDJNEDDKC<bool> GHPBMEDLECD;

		private global::MOBDJNEDDKC<GIBEGHKMCIE> EEINBJGENJE;

		public IPGPGKAPCGB FlagAtGoalEvent;

		public BCGHFJLNJEL FlagReleaseEvent;

		public HIFLHFAEJBD FlagPickupEvent;

		public PKACAKELOOK FlagReturnEvent;

		public LJBFOCLJNNM FlagResetEvent;

		private bool EEMJNOBIAAF;

		private IDisposable INABJMPOAPA;

public static IReadOnlyList<FlagTool> AllFlags
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

public GenericPortal ReturnPortal
{
get 		{
			return null;
		}

}

public Transform GoalAttachTransform
{
get 		{
			return null;
		}

}

public PaintballVisibilityBehaviour VisibilityBehaviour
{
get 		{
			return null;
		}

}

public bool AtHomeGoal
{
get 		{
			return false;
		}

private set {
		}
}

public bool AtHomeGoalByDistance
{
get 		{
			return false;
		}

}

public GIBEGHKMCIE Team
{
get 		{
			return GIBEGHKMCIE.TEAM_1;
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

		private void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void GAHHBGJBCCA(float OKBAJEAPIHG)
		{
		}

		private void LateUpdate()
		{
		}

		private void KNALNPOIOPN(Tool IEGMBEPJMGC)
		{
		}

		private void MNPLCFMNCJL(Tool IEGMBEPJMGC)
		{
		}

		private void PLLGKABPABI(Tool PMEFICGEDFK, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		private bool HBOILJCEDJJ(IEnumerable<FlagGoal> PNKCGNOKBOJ, out GIBEGHKMCIE GBDNNLECLGO)
		{
			GBDNNLECLGO = default;
			return false;
		}

		private void MJODCEKKOJM(GenericPortal KNAPEFNAOGE, Player EKOFNPFCLMO)
		{
		}

		private bool PNHCIEHBACL(out Vector3 INLGLHIPOMC)
		{
			INLGLHIPOMC = default;
			return false;
		}

		private void JJIMKDAGKKD()
		{
		}

		private void DAIDHEPEHFE()
		{
		}

		private void LOOCPCHDKMI(int IPMIIEAGJKC)
		{
		}

		private void CPIPNODJDHK()
		{
		}

		[CompilerGenerated]
		private int IBLHEJJDGKC()
		{
			return 0;
		}
	}
}
