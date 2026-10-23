using System;
using System.Collections.Generic;
using Circuits.Shared.Utilities;
using RecRoom.Core.Creation;
using RecRoom.Tools.MakerPenTools;
using UnityEngine;

namespace RecRoom.CircuitsV2.Experience
{
	public sealed class ChipConnectionPoint : ConnectionPoint, IDHANFFPOIF
	{
		[SerializeField]
		private BoxCollider defaultValueCollider;

		[EFEFIKFHIDK]
		[SerializeField]
		private Port portVisual;

		private float KJPNPFKOMJC;

		private Chip JJMNDCAFBDA;

		private DGNNDGAENKL ENHLCLCJKEC;

		private IOKind FNHCAJMGKEP;

		private int MPEGLNBIMPL;

		private Action<string> JGKHNNDBKJA__BackingField;

		private Action<CLKEJFGKNDK, AMFPEDOFIGE> NEJPHEFJCKD__BackingField;

		private Action IAFHLFDPFKJ__BackingField;

		private List<DGMPBIPKJEB> GIOPHJHDPJP;

public BoxCollider DefaultValueCollider
{
get 		{
			return null;
		}

}

public float DefaultValueColliderPositionX
{
get 		{
			return 0f;
		}

private set {
		}
}

public DGNNDGAENKL Port
{
get 		{
			return null;
		}

private set {
		}
}

public override bool ImmediateStartConnection
{
get 		{
			return false;
		}

}

public override bool CanSelfConnect
{
get 		{
			return false;
		}

}

public override bool SelfConnectIsConfigure
{
get 		{
			return false;
		}

}

public override bool IsCV2
{
get 		{
			return false;
		}

}

public override bool Blocked
{
get 		{
			return false;
		}

}

public string TypeName
{
get 		{
			return null;
		}

}

public override DHJLEHBOGBG CreationContextObject
{
get 		{
			return null;
		}

}

public override MakerPenPinInfo.CHNJGMNEPOO DefaultPinOperationType
{
get 		{
			return MakerPenPinInfo.CHNJGMNEPOO.Wire;
		}

}

public IReadOnlyList<DGMPBIPKJEB> DynamicUIElements
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

 bool global::IDHANFFPOIF.IsValid
{
get 		{
			return false;
		}

}

public override Vector3 WireDirection
{
get 		{
			return default;
		}

}

public override Color ConnectionColor
{
get 		{
			return default;
		}

}

public override bool IsCircuitPoint
{
get 		{
			return false;
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

public event Action<CLKEJFGKNDK, AMFPEDOFIGE> ShowDialog {
add {
		}
remove {
		}
}

public event Action DismissAllDialogs {
add {
		}
remove {
		}
}

		private void OnValidate()
		{
		}

		protected override void Awake()
		{
		}

		public void Bind(Chip JJMNDCAFBDA, DGNNDGAENKL KNPJEMEMOEF, IOKind FNHCAJMGKEP)
		{
		}

		public void Unbind()
		{
		}

		private bool PAIMDFGKHEB()
		{
			return false;
		}

		public override void ConnectionEnd(ConnectionCreationContext DELCOFCGDFF, ConnectionPoint PCJINKBIFLC, ConnectionPoint HLBJDAGMEND, EBNPGOBCABE IFEOGBCJEBI, ININJKAJDDN LOHCFFGPEAA = null)
		{
		}

		private static (Guid, int, int, Guid, int, int)? CDNOFNAFDEL(IOKind ILKJEPIIBNH, DGNNDGAENKL DIECOKGIDJM, IOKind IFONHKGPFDF, DGNNDGAENKL POEPFCBHGON)
		{
			return null;
		}

		private static void ADINPIJNHHJ(LEPCMENIFGP JLEDPPDNANO, in Guid GLLFFIFLOAG, IOKind ILKJEPIIBNH, DGNNDGAENKL DIECOKGIDJM, IOKind IFONHKGPFDF, DGNNDGAENKL POEPFCBHGON, int PCKCPNGPNBJ)
		{
		}

		private static void EPLEHJDMLAM(LEPCMENIFGP JLEDPPDNANO, IOKind KCIAKHCIGFA, DGNNDGAENKL FAHEJHOHAFA)
		{
		}

		public override bool OperationOnSelect()
		{
			return false;
		}

		public override void ConfigureHoverPinInfoDisplay(MakerPenPinInfo JLGDNNNOAPD, in Vector3 HJODBKHINKL)
		{
		}

		public override void ConfigureStartPinInfoDisplay(MakerPenPinInfo JLGDNNNOAPD, in Vector3 HJODBKHINKL, bool FMFJDHJAJKN, EBNPGOBCABE IFEOGBCJEBI)
		{
		}

		public override void ConfigureEndPinInfoDisplay(MakerPenPinInfo EPHIEPMKION, in Vector3 HJODBKHINKL, ConnectionPoint FLFPHDAAGNM)
		{
		}

		public void RunExecPort()
		{
		}

		public void ConfigureDisplayValue(CV2MakerPenPinInfo JLGDNNNOAPD)
		{
		}

		private void LKPDKDIPFOH(CLKEJFGKNDK HNPFAOFHHII, AMFPEDOFIGE CIFKJLJDLOP)
		{
		}

		private void ANEFFBGPAAN()
		{
		}

		public bool OnPreInitializeConfigScreen()
		{
			return false;
		}

		public void FireObjectSettingsToast(string FGFCBOHADKH)
		{
		}

		private void BEBKLOBIGCA()
		{
		}

		void IDHANFFPOIF.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in BEBKLOBIGCA
			this.BEBKLOBIGCA();
		}

		public IDHANFFPOIF GetParentConfigurable()
		{
			return null;
		}

		public bool TryAutoConnectToChip(Chip JBIPKAJCLPL)
		{
			return false;
		}

		public void ConfigurableWillShow()
		{
		}
	}
}
