using UnityEngine;

namespace RecRoom.Tools.Groups
{
	public class PlayingCard : ToolGroupElement
	{
		public enum JCKHOIOKIEE
		{
			ACE = 0,
			TWO = 1,
			THREE = 2,
			FOUR = 3,
			FIVE = 4,
			SIX = 5,
			SEVEN = 6,
			EIGHT = 7,
			NINE = 8,
			TEN = 9,
			JACK = 10,
			QUEEN = 11,
			KING = 12
		}

		public enum BMBNCFFNGPI
		{
			HEARTS = 0,
			SPADES = 1,
			CLUBS = 2,
			DIAMONDS = 3
		}

		[SerializeField]
		private BMBNCFFNGPI suit;

		[SerializeField]
		private JCKHOIOKIEE value;

		private global::MOBDJNEDDKC<BMBNCFFNGPI> GNEMDEEBKLK;

		private global::MOBDJNEDDKC<JCKHOIOKIEE> BIGNGMCLNPI;

		private PlayingCardSprite DLADPCHJMME;

		private ToolGroupElement IFEGGHLFIFJ;

		private bool DNLBACKHKBP;

public BMBNCFFNGPI Suit
{
get 		{
			return BMBNCFFNGPI.HEARTS;
		}

set {
		}
}

public JCKHOIOKIEE Value
{
get 		{
			return JCKHOIOKIEE.ACE;
		}

set {
		}
}

protected override string CAJNEPLOHBK
{
get 		{
			return null;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected override void Update()
		{
		}

		public override bool CanAddTool(ToolGroupElement IEGMBEPJMGC)
		{
			return false;
		}

		public override void DisplayAddToolHighlight(ToolGroupElement JMHFDNPLCEM)
		{
		}

		private bool LOHCJLFODLI(ToolGroupElement BCMAIOPEGFC)
		{
			return false;
		}

		private void INJNAGIKFFJ()
		{
		}

		private void HOMGIJGCHEL()
		{
		}
	}
}
