using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom.Core.Creation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class MakerPenHomeScreenMenuModel : MakerPenModelBase, IJEOFMGDCME, NJIIBNCBBMK, KGDCCAIMMGC, LOBCAJAIIJD
	{
		[OFENKFBEDDN]
		public enum KCFFDMFHIIB
		{
			CreateTool = 0,
			CreateTube = 1,
			EditMode = 2,
			Recolor = 3,
			Transform = 4,
			Rotate = 5,
			Select = 6,
			Clone = 7,
			GridSnap = 8,
			SurfaceSnap = 9,
			Gadget = 10,
			General = 11,
			Scale = 12,
			SelectFunction = 13,
			DevOnly = 14
		}

		private sealed class JOCHBAMDCHB
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_CloneToolSettingsDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_CloneToolSettingsDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class NFACFAMCGDN
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_CreateToolSettingsDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_CreateToolSettingsDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class LJLPGKGIIGN
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_CreateTubeSettingsDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_CreateTubeSettingsDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class AJJIKNBMENG
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_EditModeSettingsDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_EditModeSettingsDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class ADFPPKJKHAF
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_GeneralSettingsDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_GeneralSettingsDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class GMIAFBFICHM
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_RecolorToolSettingsDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_RecolorToolSettingsDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class MCONPDFOKNI
		{
			public ShapeSwatchInfo newSwatch;

			internal void _003Cget_RecolorToolSettingsDynamicUI_003Eb__10()
			{
			}
		}

		private sealed class IAAGCKNOCEK
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_RotateToolSettingsDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_RotateToolSettingsDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class AOLHKFBILBO
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_ScaleToolSettingsDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_ScaleToolSettingsDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class PHGDKIGIAEC
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_SelectToolSettingsDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_SelectToolSettingsDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class AKNCOLBCJIJ
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_SelectToolFunctionsDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_SelectToolFunctionsDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class JGELEJKFAMI
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_SnappingSettingsGridDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_SnappingSettingsGridDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class BBOOEKDLNCJ
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_SnappingSettingsSurfaceDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_SnappingSettingsSurfaceDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class HFJGEKJMMNL
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_TransformToolSettingsDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_TransformToolSettingsDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class CMNAJABLOAF
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_GadgetSettingsDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_GadgetSettingsDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class GOBGDJOBKJK
		{
			public KCFFDMFHIIB thisSetting;

			public MakerPenHomeScreenMenuModel _003C_003E4__this;

			internal bool _003Cget_DevOnlySettingsDynamicUI_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_DevOnlySettingsDynamicUI_003Eb__2(bool value)
			{
			}
		}

		private sealed class CMINOMNAPEP
		{
			public string input;

			public MessageWithInputFieldDialogModel messageDialogModel;

			public Action<float> callback;

			internal string _003CFloatDialog_003Eb__2()
			{
				return null;
			}

			internal void _003CFloatDialog_003Eb__3(string value)
			{
			}

			internal void _003CFloatDialog_003Eb__0(BaseDialogModel<EJBAHPMBHMO> dialogModel)
			{
			}

			internal void _003CFloatDialog_003Eg__Done_007C1()
			{
			}
		}

		private sealed class OKCJIJBIICC<T>
		{
			public List<T> source;

			public Func<T, string> itemToString;

			public Action<T> onClick;

			internal void _003CShowPickerDialog_003Eb__0(GameObject gameObject, int index, TextMeshProUGUI textMeshPro, Button button)
			{
			}
		}

		private sealed class LECMLJDLGPB<T>
		{
			public T item;

			public OKCJIJBIICC<T> CS_0024_003C_003E8__locals1;

			internal void _003CShowPickerDialog_003Eb__1()
			{
			}
		}

		[SerializeField]
		private Sprite inputDialogSprite;

		[SerializeField]
		private GameObject pickerButton;

		public const string EMPTY_TEXT = "-";

		[SerializeField]
		private Canvas contentCanvas;

		[SerializeField]
		private Route paletteClipboardRoute;

		[SerializeField]
		private Route paletteSwatchesRoute;

		[SerializeField]
		private Route paletteShapesRoute;

		private CGOPOAFDIDN FIJHCMLFKJH;

		private NNBAJLCGAOK FOBAEINAHEB;

		[SerializeField]
		private Sprite RepeatCloneIcon;

		[SerializeField]
		private Sprite CopyFunctionIcon;

		[SerializeField]
		private Sprite PasteRecentFunctionIcon;

		[SerializeField]
		private Sprite ClipboardFunctionIcon;

		[SerializeField]
		private Sprite CreateToolSettingsIcon;

		[SerializeField]
		private Sprite CreateTubeSettingsIcon;

		[SerializeField]
		private Sprite EditModeSettingsIcon;

		[SerializeField]
		private Sprite RecolorToolSettingsIcon;

		[SerializeField]
		private Sprite TransformToolSettingsIcon;

		[SerializeField]
		private Sprite RotateToolSettingsIcon;

		[SerializeField]
		private Sprite ScaleToolSettingsIcon;

		[SerializeField]
		private Sprite SelectToolSettingsIcon;

		[SerializeField]
		private Sprite CloneToolSettingsIcon;

		[SerializeField]
		private Sprite GridSnappingSettingsIcon;

		[SerializeField]
		private Sprite SurfaceSnappingSettingsIcon;

		[SerializeField]
		private Sprite GadgetSettingsIcon;

		[SerializeField]
		private Sprite GeneralSettingsIcon;

		[SerializeField]
		private Sprite DevOnlySettingsIcon;

		private bool ILNNNGONNAL;

		private static Dictionary<KCFFDMFHIIB, bool> GCKFDKNHJBK;

		private List<AKCHPHOMHLH> LIECCPKDGCK;

		private AKCHPHOMHLH LBOPGOBPJAA;

		private AKCHPHOMHLH LPLJJGABFDB;

		private AKCHPHOMHLH CJCACCPAGPL;

		private AKCHPHOMHLH HIPOAHAOKAE;

		private AKCHPHOMHLH HFMIPMMKKJC;

		private AKCHPHOMHLH PLDNLMMLNIG;

		private AKCHPHOMHLH OJMEEDGHEEI;

		private AKCHPHOMHLH HEEJAFDDBJO;

		private AKCHPHOMHLH FKABIJCKHDH;

		private AKCHPHOMHLH ENOBEKJLLJN;

		private AKCHPHOMHLH MNMMJHFGMMG;

		private AKCHPHOMHLH CHIEGAPLCPG;

		private AKCHPHOMHLH HNBJNOHGAIJ;

		private AKCHPHOMHLH HCABPMMDFOP;

		private AKCHPHOMHLH IJGGBFNDAII;

		private bool HNBGGPAMFEC;

public NNBAJLCGAOK Settings
{
get 		{
			return null;
		}

}

private bool KHOJFOMKAAA
{
get 		{
			return false;
		}

set {
		}
}

public bool ShowGadgetsToggle
{
get 		{
			return false;
		}

set {
		}
}

public bool WorldAxisActive
{
get 		{
			return false;
		}

set {
		}
}

public IReadOnlyList<DGMPBIPKJEB> Elements
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH CloneToolSettingsDynamicUI
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH CreateToolSettingsDynamicUI
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH CreateTubeSettingsDynamicUI
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH EditModeSettingsDynamicUI
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH GeneralSettingsDynamicUI
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH RecolorToolSettingsDynamicUI
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH RotateToolSettingsDynamicUI
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH ScaleToolSettingsDynamicUI
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH SelectToolSettingsDynamicUI
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH SelectToolFunctionsDynamicUI
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH SnappingSettingsGridDynamicUI
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH SnappingSettingsSurfaceDynamicUI
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH TransformToolSettingsDynamicUI
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH GadgetSettingsDynamicUI
{
get 		{
			return null;
		}

}

public AKCHPHOMHLH DevOnlySettingsDynamicUI
{
get 		{
			return null;
		}

}

public float AutoRefreshFrequency
{
get 		{
			return 0f;
		}

}

private int ANHCLGGIJAP
{
get 		{
			return 0;
		}

}

public bool AnimationSliderDirty
{
get 		{
			return false;
		}

set {
		}
}

public bool IsEditing
{
get 		{
			return false;
		}

}

public bool HasScope
{
get 		{
			return false;
		}

}

public bool HasParentScope
{
get 		{
			return false;
		}

}

public JNODIIINKKJ.PBDGIEELIHN SnappingMode
{
get 		{
			return JNODIIINKKJ.PBDGIEELIHN.NO_SNAPPING;
		}

set {
		}
}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

		private AKCHPHOMHLH BKHIKCAMNHN(KCFFDMFHIIB NEPEADDNBCL)
		{
			return null;
		}

		public void SetElementOpenStateBySettingsType(KCFFDMFHIIB NEPEADDNBCL, bool LNBOCMEBNEB)
		{
		}

		private void MMHPEMIKEFO()
		{
		}

		private bool BEKHEBEKJBO()
		{
			return false;
		}

		private DGMPBIPKJEB HPLLNNOGNMK()
		{
			return null;
		}

		private DGMPBIPKJEB[] LPOHOPKAGKP()
		{
			return null;
		}

		private void ANMEINLCPBO(Route NBCNOLJOIIM)
		{
		}

		public void SuspendContentCanvas()
		{
		}

		public void FloatDialog(string OFMGPNLDCAB, string BMIOOJNLJAO, Action<float> ONAFALABHKI)
		{
		}

		public global::NCOKFFGPIJM<BaseDialogModel<KCOKPCOFDIM>> ShowButtonPickerDialogFromEnum<T>(string OFMGPNLDCAB, Action<T> MCKKINPBDND, Func<T, string> LGPGEIGFGPC = null, bool HJFGHJCPJHP = false) where T : Enum
		{
			return null;
		}

		public global::NCOKFFGPIJM<BaseDialogModel<KCOKPCOFDIM>> ShowPickerDialog<T>(string OFMGPNLDCAB, List<T> GLLFHCCFIGK, Action<T> CCLGFCNAFEB, Func<T, string> DANEIMNDLBP = null)
		{
			return null;
		}

		private void ABAAMAGJLMG()
		{
		}

		private void ABAAMAGJLMG<T1, T2>(T1 ALAIPJIBDIK, T2 IIOMECOENII)
		{
		}

		public void StartEditing()
		{
		}

		public void StopEditing()
		{
		}

		public void ScopeOut()
		{
		}

		public void ClearScope()
		{
		}

		private void KBDIHHFIIBE()
		{
		}

		private void KBDIHHFIIBE<T>(T KAEDAICECGN)
		{
		}

		private void KBDIHHFIIBE<T1, T2>(T1 ALAIPJIBDIK, T2 IIOMECOENII)
		{
		}

		public INHOMKPMAGA.EGIGCJBGDNF GetMakerPenMenuModelData()
		{
			return null;
		}

		public void OnMakerPenBackingDataChanged(MakerPenMenuModel.IEKCDJICBLP LGCAHNMIPGB = MakerPenMenuModel.IEKCDJICBLP.Tools)
		{
		}

		protected override void IILPBDLFFKG()
		{
		}

		protected override void BJPPPBGBLAO()
		{
		}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF(RRUIModel.AAHMEOHNDKA KMDKPCPJKJH)
		{
			return null;
		}

		protected override void LPBNNNGFPIF()
		{
		}

		public void OnInstantiate()
		{
		}

		[CompilerGenerated]
		private bool IILNEKFPODL()
		{
			return false;
		}

		[CompilerGenerated]
		private JNODIIINKKJ.IGACCMOLGBK PGBFIGHFNHN()
		{
			return JNODIIINKKJ.IGACCMOLGBK.Off;
		}

		[CompilerGenerated]
		private void NKBEBIBJEKO(JNODIIINKKJ.IGACCMOLGBK IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private JNODIIINKKJ.AEILKDDEOJH NJNFAJHAGEG()
		{
			return JNODIIINKKJ.AEILKDDEOJH.Scale;
		}

		[CompilerGenerated]
		private void FPCGHHDMOEH(JNODIIINKKJ.AEILKDDEOJH IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool ODPCLCLICFC()
		{
			return false;
		}

		[CompilerGenerated]
		private void HIEPNPMGKMG(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool JDMNBHDBJLJ()
		{
			return false;
		}

		[CompilerGenerated]
		private void PDAIKOAICHM(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private void GCPDBJEHABC()
		{
		}

		[CompilerGenerated]
		private bool BAFDLBACLOP()
		{
			return false;
		}

		[CompilerGenerated]
		private float PJHHBJJDIGP()
		{
			return 0f;
		}

		[CompilerGenerated]
		private float HFEDKFGNNNJ()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void BJGNCHGJPLN(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private float NGLCLENMGKA()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void FPAFCCNMPPH(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private JNODIIINKKJ.LDMOGNMAHNL EBPMDMHKOHC()
		{
			return JNODIIINKKJ.LDMOGNMAHNL.Off;
		}

		[CompilerGenerated]
		private void AOBCIJLDNBB(JNODIIINKKJ.LDMOGNMAHNL IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool LLIFPBNPKOM()
		{
			return false;
		}

		[CompilerGenerated]
		private void BOFFMDONNNP(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool HDGLCPOFCKF()
		{
			return false;
		}

		[CompilerGenerated]
		private void EILFNADPPPP(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool FHLFFBMBIJA()
		{
			return false;
		}

		[CompilerGenerated]
		private bool KAGDCACHJMG()
		{
			return false;
		}

		[CompilerGenerated]
		private void KLBAPKPMPPB(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool DAEGBGNMPHM()
		{
			return false;
		}

		[CompilerGenerated]
		private bool MJKAIKLGIDJ()
		{
			return false;
		}

		[CompilerGenerated]
		private void BPGAGCGGGOB(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool PJMCLMGENIP()
		{
			return false;
		}

		[CompilerGenerated]
		private void CPKMBMOIJMB(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool NAHMKDCLEHM()
		{
			return false;
		}

		[CompilerGenerated]
		private void BLCCEOHCEBG(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool ACJJONMGLPL()
		{
			return false;
		}

		[CompilerGenerated]
		private void GGDGGANLIFE(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool ECGIOEPBFDO()
		{
			return false;
		}

		[CompilerGenerated]
		private void EGKGJCEPHLE(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool HHPIBCENMNC()
		{
			return false;
		}

		[CompilerGenerated]
		private void KGMHAKHAANE(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool PLALEPLDEBL()
		{
			return false;
		}

		[CompilerGenerated]
		private void BOBEOCFAELI(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool NPGFMJNFKJA()
		{
			return false;
		}

		[CompilerGenerated]
		private void BANLFLCJBKA(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool OHGGKEKIAEG()
		{
			return false;
		}

		[CompilerGenerated]
		private void IGKBPDBMJLA(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool JGGFMIDIJHM()
		{
			return false;
		}

		[CompilerGenerated]
		private void JGDDLEIGOBA(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool FJNNEOAKPAF()
		{
			return false;
		}

		[CompilerGenerated]
		private void NNGKMAOEOJH(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool KCJKGJIFEGD()
		{
			return false;
		}

		[CompilerGenerated]
		private void JEBJKPNKNKM(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool PBNHPIJAFFN()
		{
			return false;
		}

		[CompilerGenerated]
		private bool MEAEADJCJIP()
		{
			return false;
		}

		[CompilerGenerated]
		private void NLMPCIHJOHF(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private int IKDIHDBDMKH()
		{
			return 0;
		}

		[CompilerGenerated]
		private void HLMDBIMHLNI(int IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool GAGNCMMGJNK()
		{
			return false;
		}

		[CompilerGenerated]
		private bool KGDPIIFOMPH()
		{
			return false;
		}

		[CompilerGenerated]
		private void HKHKKIMIPDL(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool CAFNMJJDMDK()
		{
			return false;
		}

		[CompilerGenerated]
		private void JOBAPLKBDGG()
		{
		}

		[CompilerGenerated]
		private void GOMGCEKCJCI()
		{
		}

		[CompilerGenerated]
		private void HFJCCMNHDHL()
		{
		}

		[CompilerGenerated]
		private bool KGEJDPHKMGO()
		{
			return false;
		}

		[CompilerGenerated]
		private void NGDFPICIPLN(CLKEJFGKNDK NIFOGEBEDNG, AMFPEDOFIGE PCPEJHIMHJJ)
		{
		}

		[CompilerGenerated]
		private void JGLMAKDBNGK()
		{
		}

		[CompilerGenerated]
		private void PKGFFHFKCCH(int PMPDPBDKGPF)
		{
		}

		[CompilerGenerated]
		private void GFJCIEMOCFC(CLKEJFGKNDK NIFOGEBEDNG, KCOKPCOFDIM PCPEJHIMHJJ)
		{
		}

		[CompilerGenerated]
		private bool IIOMPAPFNOG()
		{
			return false;
		}

		[CompilerGenerated]
		private void AAMMEGOKOJG(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool JBDKIGOBHLO()
		{
			return false;
		}

		[CompilerGenerated]
		private void HELNPFDHBJK(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool ABNDCJFIFBP()
		{
			return false;
		}

		[CompilerGenerated]
		private bool NAPNGOKCBNP()
		{
			return false;
		}

		[CompilerGenerated]
		private void NFCHPMCIODG(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool GLIFHFOGMGF()
		{
			return false;
		}

		[CompilerGenerated]
		private JNODIIINKKJ.NGMJKOKKHNG OOLGNHLFPMH()
		{
			return JNODIIINKKJ.NGMJKOKKHNG.Precise;
		}

		[CompilerGenerated]
		private void MDAKEDIILJL(JNODIIINKKJ.NGMJKOKKHNG IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool KLKADMNBIGP()
		{
			return false;
		}

		[CompilerGenerated]
		private void LBGNAOCBOKE(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private void PJODKCMKOFJ()
		{
		}

		[CompilerGenerated]
		private void EPEGJAMPJLK()
		{
		}

		[CompilerGenerated]
		private bool BJOJGAJMNOB()
		{
			return false;
		}

		[CompilerGenerated]
		private void FIGFKCGGHOO(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool JKHCEABKPHE()
		{
			return false;
		}

		[CompilerGenerated]
		private float EELBMDMBABN()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void GCDGCLFFHCA(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private float NHDHIMEKNHF()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void EPLNGEECONI(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool EHNMNHEEFGK()
		{
			return false;
		}

		[CompilerGenerated]
		private void LMLPPFHNGLC(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool LPFANMEJCJO()
		{
			return false;
		}

		[CompilerGenerated]
		private void PGIDHNPJGCE(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool JHBGJPNOBNP()
		{
			return false;
		}

		[CompilerGenerated]
		private bool EOHKCOCEKDJ()
		{
			return false;
		}

		[CompilerGenerated]
		private void IPABMHPILDI(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private float GOCFJEIGICM()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void HOBCDLCGHKF(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool IDOFHAIELCC()
		{
			return false;
		}

		[CompilerGenerated]
		private bool LHABDIDPEJJ()
		{
			return false;
		}

		[CompilerGenerated]
		private void NEIKPLOIILK(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool CCBIDHGEDOE()
		{
			return false;
		}

		[CompilerGenerated]
		private void BPNEPEINMMB(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool NEDFBFCOPIL()
		{
			return false;
		}

		[CompilerGenerated]
		private void LJHBCIGKODJ(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool HBIBDGIILMN()
		{
			return false;
		}

		[CompilerGenerated]
		private float LEGKAHMPCBE()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void PCHCPCFOADP(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool ICENDHJKMJH()
		{
			return false;
		}

		[CompilerGenerated]
		private void ACCBEDGGOKI(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool OMNOCBNIJHJ()
		{
			return false;
		}

		[CompilerGenerated]
		private void MBCCDGLDABP(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool PECHBJCHMBI()
		{
			return false;
		}

		[CompilerGenerated]
		private void APFBGEDHFJM(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool NFPHHIDMDIC()
		{
			return false;
		}

		[CompilerGenerated]
		private void MAEJOHNECEO(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool MCOPAECIJEN()
		{
			return false;
		}

		[CompilerGenerated]
		private void AKPEAEPNDFG(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool HIPAGIBMGJC()
		{
			return false;
		}

		[CompilerGenerated]
		private void HENKBFOBPOD(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private int OAEDLOAJCBD()
		{
			return 0;
		}

		[CompilerGenerated]
		private void FPCHPPFDLNG(int IPCNJDBKKDB)
		{
		}

		[CompilerGenerated]
		private void NOFFIMDMMAK(CLKEJFGKNDK NIFOGEBEDNG, KCOKPCOFDIM PCPEJHIMHJJ)
		{
		}

		[CompilerGenerated]
		private void JFIBDMPIFAJ()
		{
		}

		[CompilerGenerated]
		private bool NJLOAPIAHCM()
		{
			return false;
		}

		[CompilerGenerated]
		private void NHFMHIHHPOC()
		{
		}

		[CompilerGenerated]
		private bool PKJJCIODPGP()
		{
			return false;
		}

		[CompilerGenerated]
		private bool BLJEGNFBGMA()
		{
			return false;
		}

		[CompilerGenerated]
		private void NGNNNMEHIBJ(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool HEKPHNEGPPH()
		{
			return false;
		}

		[CompilerGenerated]
		private void MOFAHEJADOD(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool BBIGNKOGHAK()
		{
			return false;
		}

		[CompilerGenerated]
		private void JIPAIODJNCD(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private float DEFFPMIGBIP()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void OKHJPBFEHMM(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private float EDOHBJJGDAL()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void FKJBIPMOBDC(float IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool BELCDCLEGDN()
		{
			return false;
		}

		[CompilerGenerated]
		private void BADIOCNIEAB(bool IPMIIEAGJKC)
		{
		}
	}
}
