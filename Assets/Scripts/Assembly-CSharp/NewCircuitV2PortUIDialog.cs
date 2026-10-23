using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using AGUI.StackedUI.Dialog;
using RecRoom.Tools;
using TMPro;
using UnityEngine;

public class NewCircuitV2PortUIDialog : UIDialog<MakerPen, bool, NewCircuitV2PortUIDialog.NDEGCIBOOFI>
{
	public struct NDEGCIBOOFI
	{
		public readonly HGKINAOMNIF IAMHCABOCOA;

		public readonly string IAJEONPOPFN;

		public readonly BHANLMJAEPJ MMMENNAAGAA;

		public NDEGCIBOOFI(HGKINAOMNIF MLDANHIGANI, string CPENBNANCJL, BHANLMJAEPJ NIFOGEBEDNG)
		{
			IAMHCABOCOA = HGKINAOMNIF.Cancel;
			IAJEONPOPFN = null;
			MMMENNAAGAA = null;
		}
	}

	private sealed class BMHJPIPKOHL : IEnumerable<BHANLMJAEPJ>, IEnumerable, IEnumerator<BHANLMJAEPJ>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private BHANLMJAEPJ _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private bool canAddExec;

		public bool _003C_003E3__canAddExec;

		private IEnumerator<BHANLMJAEPJ> _003C_003E7__wrap1;

 BHANLMJAEPJ global::System.Collections.Generic.IEnumerator<global::BHANLMJAEPJ>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CCircuits_002EStatic_002ECore_002ETypeSystem_002ECircuitType_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public BMHJPIPKOHL(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		private BHANLMJAEPJ System_002ECollections_002EGeneric_002EIEnumerator_003CCircuits_002EStatic_002ECore_002ETypeSystem_002ECircuitType_003E_002Eget_Current()
		{
			return null;
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}

		[DebuggerHidden]
		IEnumerator<BHANLMJAEPJ> IEnumerable<BHANLMJAEPJ>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	[SerializeField]
	private CreationObjectSettingStringUIControl portNameField;

	[SerializeField]
	private CreationObjectSettingFriendlyIntControl portTypeField;

	[SerializeField]
	private TextMeshProUGUI errorText;

	[SerializeField]
	private Button3D createButton;

	private string AHJNLKFCGAF;

	private BHANLMJAEPJ CMALADOOGIL;

	private BHANLMJAEPJ[] OIFDGFIJDKD;

	private List<string> GGIFGBLNKDO;

	private Dictionary<string, MIBJNNKFLND> NKFKMDBKPNN;

	private static IEnumerable<BHANLMJAEPJ> EOEAHDLBMOE()
	{
		return null;
	}

	public static IEnumerable<BHANLMJAEPJ> GetTypeOptions(bool GDJHKJELLAM)
	{
		return null;
	}

	private void DNPOAPCLFIA(bool GDJHKJELLAM)
	{
	}

	public override global::NCOKFFGPIJM<NDEGCIBOOFI> ShowDialog(MakerPen BHCCDMJFHEO, bool GDJHKJELLAM)
	{
		return null;
	}

	private void JIJCIHGJDGL()
	{
	}

	public override void ForceCancel(bool EDLFMMEDNGP)
	{
	}

	public void Button_Create()
	{
	}

	[CompilerGenerated]
	private int KFGAMABOEPN()
	{
		return 0;
	}

	[CompilerGenerated]
	private void JFBJAPMADIJ(int DLEMNBPMGBG)
	{
	}

	[CompilerGenerated]
	private string NDCJJDENPKM()
	{
		return null;
	}

	[CompilerGenerated]
	private void MKIBGGEALFN(string DLEMNBPMGBG)
	{
	}
}
