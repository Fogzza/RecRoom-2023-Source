using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public class SetLeaderboardStatNode : MonoBehaviourPun, DJLCHGFCFAD
	{
		public enum MFKBKFCGHOG
		{
			Unset = -1,
			SetAlways = 0,
			Increment = 1,
			SetIfGreater = 2,
			SetIfLess = 3
		}

		private sealed class JIJCDGAAAFJ
		{
			public long roomIdWhenCallIssued;

			public SetLeaderboardStatNode _003C_003E4__this;

			public int statChannel;

			internal void _003CSetStat_003Eb__0(int newValue)
			{
			}
		}

		private const EDBMANFHGGO JNJAFJEAKPO = EDBMANFHGGO.R;

		private const EDBMANFHGGO PFLEJLJPOFI = EDBMANFHGGO.G;

		private const EDBMANFHGGO IKOFOFGHGAP = EDBMANFHGGO.B;

		[SerializeField]
		private CircuitEventNodeDisplay nodeDisplay;

		[SerializeField]
		private CreationObject creationObject;

		[SerializeField]
		private SpriteRenderer statusIcon;

		[SerializeField]
		private Sprite unsetIcon;

		[SerializeField]
		private Sprite setAlwaysIcon;

		[SerializeField]
		private Sprite incrementIcon;

		[SerializeField]
		private Sprite setIfGreaterIcon;

		[SerializeField]
		private Sprite setIfLessIcon;

		[SerializeField]
		private Color validColor;

		[SerializeField]
		private Color invalidColor;

		private global::MOBDJNEDDKC<MFKBKFCGHOG> DBPHOKDNLIA;

public MFKBKFCGHOG SetMode
{
get 		{
			return MFKBKFCGHOG.SetAlways;
		}

set {
		}
}

private long HBODJBBGFJE
{
get 		{
			return 0L;
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

		protected void Start()
		{
		}

		private int OPOGAJFFBBP()
		{
			return 0;
		}

		private void LNKMLCGEOEJ(int IPMIIEAGJKC)
		{
		}

		public void OnSignalUpdate(Dictionary<EDBMANFHGGO, int> newInputs)
		{
		}

		private void JKHJMGPKEKC(int PCKCPNGPNBJ, int DCJAJKOBFJJ, int IPMIIEAGJKC)
		{
		}

		private Sprite JOAIBENOKMP(MFKBKFCGHOG DNLPIHIBJDP)
		{
			return null;
		}

		private void DCBGDENHNJL()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}
	}
}
