using System;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class JigsawPuzzle : MonoBehaviour
	{
		[Serializable]
		private struct PieceData
		{
			public JigsawPuzzlePiece Piece;

			public Transform SolvedTransform;
		}

		[SerializeField]
		private PieceData[] pieces;

public bool Completed
{
get 		{
			return false;
		}

}

		private void Awake()
		{
		}
	}
}
