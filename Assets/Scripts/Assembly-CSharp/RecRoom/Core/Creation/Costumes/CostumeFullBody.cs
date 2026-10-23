using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Core.Creation.Costumes
{
	public class CostumeFullBody : Costume, BDLODHHJLKM
	{
		private enum DACBEELAGLH
		{
			T_Pose = 0,
			Idle = 1,
			Sit = 2,
			Hero = 3,
			A_Pose = 4,
			Crouch = 5,
			Jump = 6,
			Lean_Forward = 7,
			Lean_Backward = 8,
			Lean_Left = 9,
			Lean_Right = 10,
			Hero_Fly = 11,
			Hero_Land = 12,
			X_Pose = 13,
			Dab = 14
		}

		private sealed class AJHKFLAFAHJ : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public CostumeFullBody _003C_003E4__this;

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
			public AJHKFLAFAHJ(int _003C_003E1__state)
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

		private const int GGACMJAOOFM = 2;

		private const int GNIBBPIEMCK = 3;

		private const int JBJAIFONGDF = 4;

		private const int IOIIBCPMDCO = 0;

		private const int NJGPBCPCLHP = 1;

		private const int KIGONJLPOOD = 5;

		private const int KLLBFCEEFIB = 6;

		private const int LLLKBPDICJN = 8;

		private const int BCGDABMJGEL = 9;

		private const int NACCNGHOPLE = 11;

		private const int HOFLDKKAAOB = 12;

		private const int KAAOCPIDBOD = 14;

		private const int PENGGHMMLLE = 15;

		private const int LNGOMAEMJPF = 15;

		private static readonly Dictionary<string, MIBJNNKFLND> IBMNMGIDPIF;

		[SerializeField]
		private CostumePiece[] orderedPieces;

		[SerializeField]
		private GameObject dummyLimbs;

		[SerializeField]
		private GameObject dummyBendyTorso;

		[SerializeField]
		private Transform singleBodyRef;

		[SerializeField]
		private Animator costumeAnimator;

		[SerializeField]
		private SandboxColorable sandboxColorable;

		private Vector3 FEOCNOPALEE;

		private Quaternion MODIFGAJDHI;

		private Vector3 BFPOIOENKAL;

		private Quaternion AIDDGJJOELL;

		private Vector3 GAIKCEHEKLA;

		private Quaternion KBBJBLMIEIM;

		private AMEFHJFMPIO FMMLKGMCHBE;

		private global::MOBDJNEDDKC<int> AGKLNKPFBIE;

protected bool MMMGCBNKJKF
{
get 		{
			return false;
		}

}

protected override int CGACJNDMIBH
{
get 		{
			return 0;
		}

set {
		}
}

protected override int DGAIKEPONLM
{
get 		{
			return 0;
		}

}

protected override bool NKKCBOJFJOE
{
get 		{
			return false;
		}

}

public override bool UseSkinning
{
get 		{
			return false;
		}

}

public int NumBones
{
get 		{
			return 0;
		}

}

public Transform AttachTransform
{
get 		{
			return null;
		}

}

public bool IsFirstPerson
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void Start()
		{
		}

		private void HHALNFEEBCP()
		{
		}

		private void BHKOLDHEOBH()
		{
		}

		protected override void NLHFKBFPHAB(AKCHPHOMHLH PPLLHFPPIPO)
		{
		}

		private IEnumerator<EGGPGCCKPCO> CHDOPEHJHIK()
		{
			return null;
		}

		public override Transform GetTransformFromBoneIndex(int GMEHLIHLGEH)
		{
			return null;
		}

		protected override void LHLALHKGGBO()
		{
		}

		private void PADGMPFHBCI()
		{
		}

		protected override void HJAMGJGIHNA()
		{
		}

		protected override void PNCNHIGGGPH()
		{
		}

		protected override void KIHNKLKHIAA(bool GMJGLPNAENI)
		{
		}

		private void PODGNJAJAMN()
		{
		}

		private void GKOFMDJFDBL()
		{
		}

		public override void RemoveSkinning()
		{
		}

		private void BPDAJOBPENI(Player EKOFNPFCLMO = null)
		{
		}

		protected void Update()
		{
		}

		private void MKPOBCCKENH(Player EKOFNPFCLMO)
		{
		}

		public MDAFPBCOHEN GetBone(int ODCMHGAKLKH)
		{
			return default;
		}

		public bool IsPartOfFirstPersonSkin(int ODCMHGAKLKH)
		{
			return false;
		}

		public override void AssertCostumePlacedCorrectly()
		{
		}
	}
}
