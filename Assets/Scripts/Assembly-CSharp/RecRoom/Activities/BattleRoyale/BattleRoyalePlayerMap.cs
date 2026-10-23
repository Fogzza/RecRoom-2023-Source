using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Activities.BattleRoyale
{
	public class BattleRoyalePlayerMap : MonoBehaviourPun
	{
		[Serializable]
		public class Pip
		{
			[NonSerialized]
			public Player player;

			public SpriteRenderer marker;

			public SpriteRenderer outlineMarker;

			public GameObject backgroundFiller;

			public Transform mainTransform;
		}

		private enum FPOELJBKEBH
		{
			COLLAPSED = 0,
			EXPANDED = 1
		}

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private GameObject collapsedRoot;

		[SerializeField]
		private GameObject expandedRoot;

		[SerializeField]
		private Vector2 expandedLocalSpaceDimensions;

		[SerializeField]
		private float zOffset;

		[SerializeField]
		private Transform lowerLeftMapTransform;

		[SerializeField]
		private Transform upperRightMapTransform;

		[SerializeField]
		private Pip[] pips;

		[SerializeField]
		private Sprite arrowSprite;

		[SerializeField]
		private Sprite downSprite;

		[SerializeField]
		private Sprite eliminatedSprite;

		[SerializeField]
		private RendererMaterialPair ringOverlayRenderer;

		private MDEJADHJOEJ KLOLMMOJNHJ;

		private CHILKDJABBF OMJNJILAKBP;

		private BattleRoyaleGearBag FKPBCPMCCIF;

		private Transform JGPELOMOINA;

		private static Dictionary<string, object> HGOEFCGCHHK;

		private static readonly int DFJGIFAONHF;

		private static readonly int JOKOHAAGEHO;

		private static readonly int AOMNLDFPEIK;

		private static readonly int JKNCJMJDCMN;

		private static readonly Color KCDJNAKLFKF;

		private static readonly Vector3 JGKDHHFKMJN;

		private static readonly Vector3 NHAKOKBHENK;

		private static readonly Vector3 CKCIMLGMLFK;

		private static readonly string HNJEEKLHMCP;

		private static readonly string EMKHJCKFLFO;

		private const float OMAOCOHMAJC = 3f;

		private const float HEBDHOOKOGB = 9f;

public Tool Tool
{
get 		{
			return null;
		}

}

public CHILKDJABBF PermanentOwnerPhotonPlayer
{
get 		{
			return null;
		}

}

public Transform OpenMapRoot
{
get 		{
			return null;
		}

}

public Vector3 OpenMapLocalSpaceDimensions
{
get 		{
			return default;
		}

}

public bool PermanentOwnerIsLocal
{
get 		{
			return false;
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

		public void ResetToBag()
		{
		}

		private void LFLGBEBCKIC(Tool IEGMBEPJMGC)
		{
		}

		private void CEBGBOFPOPL(Tool IEGMBEPJMGC)
		{
		}

		private void MBIOLEBFOOM(Tool IEGMBEPJMGC, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		private bool KIMOIOCBDDG(out Vector3 INLGLHIPOMC, out Quaternion POIOCLOKJGH)
		{
			INLGLHIPOMC = default;
			POIOCLOKJGH = default;
			return false;
		}

		private bool HAACEEMLLLJ(Tool IEGMBEPJMGC, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
		{
			return false;
		}

		private void ODPPIEECBAA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void JFEMDNHGOMO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void LIDHHEHKFJC()
		{
		}

		private void EEEKIDEPKIP(CHILKDJABBF FFDEPLCDBNA, bool OHDEKMCDIPE)
		{
		}

		private void FMGALDKFLGH()
		{
		}

		private void MDGOPDPGNEH()
		{
		}

		private void MOAFLIANHOP()
		{
		}

		public static BattleRoyalePlayerMap InstantiateForLocalPlayer(BattleRoyalePlayerMap GDEKLMNKJBC, BattleRoyaleGearBag AHIKPEGAOHN)
		{
			return null;
		}

		private bool KICAJPMGJMG(Player EKOFNPFCLMO)
		{
			return false;
		}
	}
}
