using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class BecomeMemberToPurchaseItemScreen : WatchUIFlow
	{
		private sealed class LIGMMCEFNPH : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public BecomeMemberToPurchaseItemScreen _003C_003E4__this;

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
			public LIGMMCEFNPH(int _003C_003E1__state)
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

		private sealed class IDGOGPJPLJC
		{
			public DBFJJLIGAFA membersItem;

			internal void _003CDisplayDetached_003Eb__0(BecomeMemberToPurchaseItemScreen screen)
			{
			}
		}

		[SerializeField]
		private TextMeshProUGUI itemName;

		[SerializeField]
		private Transform prefabRoot;

		[SerializeField]
		private float localImposterRadius;

		[SerializeField]
		private float imposterParentNormalSize;

		[SerializeField]
		private float imposterParentLargeSize;

		[SerializeField]
		private Quaternion imposterStartingRotation;

		[SerializeField]
		private float imposterRotationSpeed;

		private EOKBGGOAFLF AIBBKGGHCIJ;

		private DBFJJLIGAFA HKCDCHLOELB;

		private CancellationTokenSource BGAGMFECJMM;

public EOKBGGOAFLF PurchasableGiftDrop
{
get 		{
			return null;
		}

set {
		}
}

public DBFJJLIGAFA CurrentItem
{
get 		{
			return null;
		}

private set {
		}
}

		public override void Initialize(StackedUIBase MKHLKCMEBLE)
		{
		}

		public override void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
		{
		}

		private void OnEnable()
		{
		}

		private IEnumerator<EGGPGCCKPCO> AECCKNFLDFB()
		{
			return null;
		}

		private void OnDisable()
		{
		}

		public void SetItem(DBFJJLIGAFA OOOJNBODGPI)
		{
		}

		private void CFGPPNILKFF(OMNLIPPAPDI CAPKFCHDLFA)
		{
		}

		public static void DisplayDetached(global::LPOCMKDAPMN<BecomeMemberToPurchaseItemScreen> ELNPJBMKDAE, string LDPCFDMCJLH, DBFJJLIGAFA AGKLCBDBLIO)
		{
		}

		public void Button_UpgradePlan()
		{
		}

		[CompilerGenerated]
		private Task<GameObject> FGAKKOFIBMH(CancellationToken IALNODEHBNN)
		{
			return null;
		}
	}
}
