using RecRoom.Avatars;

namespace RRUI.Data
{
	public class HatCustomizationModel : AvatarCustomizationDependentModel
	{
		public enum HatAdjustmentType
		{
			UV = 0,
			PositionOffset = 1,
			RotationOffset = 2,
			Legacy = 3,
			HelmetHair = 4
		}

		public enum UVPositionAxis
		{
			U = 0,
			V = 1
		}

		public enum RotationOffsetAxis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		public enum PositionOffsetAxis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private const int DDONGHHDHCI = 10;

		private readonly global::ADIBECMODCM<DCLIAIDLPOI> CMCOGOFJIDF;

		private HatAdjustmentType GANBKCHLDEO;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public bool UsingHelmetHair
{
get 		{
			return false;
		}

}

public bool WearingHelmet
{
get 		{
			return false;
		}

}

public HatAdjustmentType AdjustmentCategory
{
get 		{
			return HatAdjustmentType.UV;
		}

set {
		}
}

public CLMEHHLKBJG HatAnchorRestrictions
{
get 		{
			return null;
		}

}

public AnchorParams HatAnchorParams
{
get 		{
			return default;
		}

}

public bool HatSupportsCustomization
{
get 		{
			return false;
		}

}

public bool CanUndo
{
get 		{
			return false;
		}

}

public bool CanRedo
{
get 		{
			return false;
		}

}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		protected override void IILPBDLFFKG()
		{
		}

		protected override void BJPPPBGBLAO()
		{
		}

		public void SetHatUVPosition(UVPositionAxis NKFDCHLHILD, float LICLDFNBHPJ)
		{
		}

		public float GetCurrentHatUVPositionNormalized(UVPositionAxis NKFDCHLHILD)
		{
			return 0f;
		}

		public void SetHatRotationOffset(RotationOffsetAxis JCNODEKFPOK, float LICLDFNBHPJ)
		{
		}

		public float GetHatRotationOffsetNormalizedZeroToOne(RotationOffsetAxis JCNODEKFPOK)
		{
			return 0f;
		}

		private float BGEJMLADGLM(float IFPPBNLHCCM, float LIODLDNGDIO, float IOEFLEFDDGP, bool OAKGBBCFDHM)
		{
			return 0f;
		}

		public void SetHatPositionOffset(PositionOffsetAxis KBLNCPJFKIN, float LICLDFNBHPJ)
		{
		}

		public float GetHatPositionOffsetNormalizedZeroToOne(PositionOffsetAxis KBLNCPJFKIN)
		{
			return 0f;
		}

		public void ResetToDefault(bool DJLIONNFGLF)
		{
		}

		public void UpdateHelmetHair(bool DADHJJNJEFA)
		{
		}

		public void Undo()
		{
		}

		public void Redo()
		{
		}

		public void AddUndoStack()
		{
		}
	}
}
