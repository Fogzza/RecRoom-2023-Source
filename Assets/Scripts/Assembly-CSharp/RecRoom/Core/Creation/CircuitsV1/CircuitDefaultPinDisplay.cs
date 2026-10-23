using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RecRoom.Tools;
using TMPro;
using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public class CircuitDefaultPinDisplay : MonoBehaviour, IDHANFFPOIF
	{
		private struct DKCHGCPADHL
		{
			public object IALNODEHBNN;

			public DHJLEHBOGBG JDOODMHGNNE;

			public Action<CircuitDefaultPinDisplay> HOMOLPALDNE;

			public Func<bool> MBOEKGIBADF;

			public Func<string> ODIAFJHBBBL;

			public Action HJECFOLMPEH;
		}

		private static CircuitDefaultPinDisplay LDEKIKNPKHE;

		[SerializeField]
		private TextMeshPro[] valueDisplays;

		[SerializeField]
		private ToolCollider toolCollider;

		[SerializeField]
		private ConfigurableSubpiece configSubPiece;

		[SerializeField]
		private Renderer backgroundRenderer;

		private EDBMANFHGGO OHDOKMHEOCO;

		private Vector3 ACEPPAMDMBH;

		private Quaternion JMDALKJDKBF;

		private MaterialPropertyBlock HOOJEGOGAPE;

		private List<DKCHGCPADHL> NLJHNAOAIKA;

		private Action<string> JGKHNNDBKJA__BackingField;

		private CircuitNodeDisplay HKHECDDDMFO;

		private List<DGMPBIPKJEB> GIOPHJHDPJP;

		private bool JILJHLMJAFI;

public EDBMANFHGGO MyInputSlot
{
get 		{
			return EDBMANFHGGO.R;
		}

private set {
		}
}

public ToolCollider ToolCollider
{
get 		{
			return null;
		}

}

public string Title
{
get 		{
			return null;
		}

}

public string Subtitle
{
get 		{
			return null;
		}

}

public bool IsValid
{
get 		{
			return false;
		}

}

public CircuitNodeDisplay MyNodeDisplay
{
get 		{
			return null;
		}

private set {
		}
}

public IReadOnlyList<DGMPBIPKJEB> DynamicUIElements
{
get 		{
			return null;
		}

}

public event Action<string> ObjectSettingsToast {
add {
		}
remove {
		}
}

 event Action<IDHANFFPOIF> global::IDHANFFPOIF.CBAGNBFFBLE {
add {
		}
remove {
		}
}

 event Action<CLKEJFGKNDK, AMFPEDOFIGE> global::IDHANFFPOIF.ShowDialog {
add {
		}
remove {
		}
}

 event Action global::IDHANFFPOIF.DismissAllDialogs {
add {
		}
remove {
		}
}

		public static CircuitDefaultPinDisplay GetInstance()
		{
			return null;
		}

		public bool OnPreInitializeConfigScreen()
		{
			return false;
		}

		private void BEBKLOBIGCA()
		{
		}

		void IDHANFFPOIF.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in BEBKLOBIGCA
			this.BEBKLOBIGCA();
		}

		private void Awake()
		{
		}

		public void PushDisplayOverride(object IALNODEHBNN, DHJLEHBOGBG JDOODMHGNNE, Action<CircuitDefaultPinDisplay> HOMOLPALDNE, Func<bool> MBOEKGIBADF, Func<string> ODIAFJHBBBL, Action HJECFOLMPEH, bool BLLELCHFAFG)
		{
		}

		public void PopDisplayOverride(object IALNODEHBNN)
		{
		}

		public void ChangeDefaultValue(int DLEMNBPMGBG)
		{
		}

		public void DescriptionChanged(object IALNODEHBNN)
		{
		}

		private void PHHBALFIMME(DKCHGCPADHL DJEFCGHGEKL)
		{
		}

		private void GPOMFFPKCON(int GMEHLIHLGEH)
		{
		}

		private void KGFNKGKIAJD(int GMEHLIHLGEH, DKCHGCPADHL DJEFCGHGEKL)
		{
		}

		private DHJLEHBOGBG HHFOCOJONNP()
		{
			return null;
		}

		private int LODIJHIOICL(object IALNODEHBNN, out bool MDBMFDICGOJ)
		{
			MDBMFDICGOJ = default;
			return 0;
		}

		public void UpdateParentPositionScale(Transform FGNGGLFNLIP, Vector3 KMGLMGMHHOO, bool KJFGLPHOOOG)
		{
		}

		private void NBLADOAEFGD()
		{
		}

		private string FPCGDHJNBAB()
		{
			return null;
		}

		private void ODAOHIMFONA()
		{
		}

		public void UpdateColor(Color FMHCCJDJFBA)
		{
		}

		private void PMMOKOAIPHH()
		{
		}

		public void RegisterConfigurablePiece()
		{
		}

		public void RegisterToNodeDisplay(CircuitNodeDisplay FACDBINPLGK, EDBMANFHGGO OBONMNBJMLD)
		{
		}

		private void PIDKAEMHKFJ()
		{
		}

		public void OnCreationObjectWillDelete(DHJLEHBOGBG GADDGJANIGG)
		{
		}

		public void UnregisterAsDisplay()
		{
		}

		private void OnDestroy()
		{
		}

		private void DFNLNFCLIPO()
		{
		}

		private void MAMKNDPHPKM()
		{
		}

		private int BHKCFELOJBH()
		{
			return 0;
		}

		private MakerPen EBCEEPBNDKE()
		{
			return null;
		}

		public void RefreshVisibility()
		{
		}

		private void BGAOMEFNMME(MakerPen FEFPKDMNMMK)
		{
		}

		private void MOKLDKICINM(bool EDNLBLPBAJK)
		{
		}

		private void FIDBGNANPBO(int IPMIIEAGJKC)
		{
		}

		public void FireObjectSettingsToast(string FGFCBOHADKH)
		{
		}

		public void ConfigurableWillShow()
		{
		}

		[CompilerGenerated]
		private int BDEGKDDCMFJ()
		{
			return 0;
		}

		[CompilerGenerated]
		private void DIIODNMEEEH(int DLEMNBPMGBG)
		{
		}
	}
}
