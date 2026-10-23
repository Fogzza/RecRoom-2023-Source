using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

namespace RecRoom.Core
{
	public class PlayerToolEquipSlot : MonoBehaviour
	{
		public delegate void FGOHMKPIFOJ(Tool IEGMBEPJMGC, PlayerToolEquipSlot HHOGFBCFGAB);

		public delegate bool CLMFEDMEMGK(Tool IEGMBEPJMGC, PlayerToolEquipSlot EMMDJFJKOLJ);

		public delegate bool HOMGHKLEFHO(Tool IEGMBEPJMGC, PlayerToolEquipSlot EMMDJFJKOLJ);

		public delegate bool JCJMCGGAMDO(Tool IEGMBEPJMGC, PlayerToolEquipSlot EMMDJFJKOLJ);

		private sealed class BMGNDFJJICC : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerHand droppingHand;

			public PlayerToolEquipSlot _003C_003E4__this;

			public Tool tool;

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
			public BMGNDFJJICC(int _003C_003E1__state)
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

		[SerializeField]
		private Player thisPlayer;

		[SerializeField]
		private SimpleVolume volume;

		[SerializeField]
		private CHNLCOIEBMH.FJPCKOJNOFJ slotType;

		[SerializeField]
		private Transform attachBodyTransform;

		[NonSerialized]
		public bool SupportsPreviewVisuals;

		[NonSerialized]
		public bool AutomaticallyEquipToolOnDrop;

		private PBLPNHLJOPL IJLHLOFLJEC;

		private List<ObscuredString> CBIMPMKENAI;

		private List<ObscuredString> MEOAIPGHMHF;

		private CHNLCOIEBMH JMEEAMAPEDC;

		public global::HHOBPMOCKMJ<bool> EnabledChanged;

		public EEANDDJEMJC EquipRestrictionsChanged;

		private readonly List<CLMFEDMEMGK> CCDMFMJELDJ;

		private readonly List<HOMGHKLEFHO> HLIFOPDIALK;

		private const int POAHHDEJMNK = 100;

		public global::BPEPJJDICII<Tool, PlayerToolEquipSlot> ToolEquipEvent;

		public global::BPEPJJDICII<Tool, PlayerToolEquipSlot> ToolUnequipEvent;

		public JCJMCGGAMDO CustomEquipBehavior;

public bool HotSwapToolOnDrop
{
set {
		}
}

public Vector3 AttachPositionWorldSpace
{
get 		{
			return default;
		}

}

public Quaternion AttachRotationWorldSpace
{
get 		{
			return default;
		}

}

public bool IsFull
{
get 		{
			return false;
		}

}

public Tool EquippedTool
{
get 		{
			return null;
		}

}

public CHNLCOIEBMH.FJPCKOJNOFJ SlotType
{
get 		{
			return CHNLCOIEBMH.FJPCKOJNOFJ.Hip;
		}

}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		private Tool NFGGLAKENFI(PlayerHand PMNLJGLDMJN)
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public bool TryEquipTool(Tool IEGMBEPJMGC, PlayerHand MDGEOKOCENN, bool EDNCELKHKEF = true, bool EIPIGMJNLJE = true)
		{
			return false;
		}

		public void CV2ForceDropTool()
		{
		}

		public void DropTool()
		{
		}

		public void AddCustomDropCondition(HOMGHKLEFHO NHJPBHJLFOD)
		{
		}

		public void RemoveCustomDropCondition(HOMGHKLEFHO NHJPBHJLFOD)
		{
		}

		public bool IsHandInSelectionVolume(Vector3 KLCDCMHPFFF)
		{
			return false;
		}

		public bool CanEquipTool(Tool IEGMBEPJMGC, PlayerHand LEMICAFFLGG, bool EIPIGMJNLJE = true)
		{
			return false;
		}

		public bool CanEquipTool(Tool IEGMBEPJMGC)
		{
			return false;
		}

		private void EMOAPKCJCMO(Tool BCFIEBGFAFB)
		{
		}

		private IEnumerator NAPLJIJCCBP(Tool IEGMBEPJMGC, PlayerHand LEMICAFFLGG)
		{
			return null;
		}

		private void GDEIKEAJJLG(Tool NDDJJBFNILI, CHNLCOIEBMH HHOGFBCFGAB)
		{
		}

		private void LMILHDNFBOH(Tool EPAANJHGANA, CHNLCOIEBMH HHOGFBCFGAB)
		{
		}

		private bool OMCKMDPCAMP(Tool IEGMBEPJMGC, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool GDONMHOKGEL)
		{
			return false;
		}

		public void ChangeEquipRestrictions(PBLPNHLJOPL FGCFMOGBPFL, List<ObscuredString> JDEHLOHILKH, List<ObscuredString> KGILBGACCBF)
		{
		}
	}
}
