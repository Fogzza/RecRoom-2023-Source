using System;
using AGUI.StackedUI;
using AGUI.StackedUI.Dialog;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.AGUI.ToolUIs
{
	public class MakerPenPaletteUI : ToolUI
	{
		private sealed class GJGKFPLCOAI
		{
			public TextInputUIDialog.FGHGFIFENNB showParams;

			internal global::NCOKFFGPIJM<TextInputUIDialog.FOBELBLMBDE> _003CShowTextInputDialog_003Eb__0(TextInputUIDialog dialog)
			{
				return null;
			}
		}

		private sealed class KFLKNCOEEKC<DialogType, ResponseType> where DialogType : UIDialog<ResponseType>
		{
			public DialogType newDialog;

			internal void _003CShowTemporaryDialog_003Eb__0()
			{
			}
		}

		private sealed class NDAFIHPHJKD<T1, R>
		{
			public T1 param;

			internal global::NCOKFFGPIJM<R> _003CShowTemporaryDialog_003Eb__0(UIDialog<T1, R> dialogInstance)
			{
				return null;
			}
		}

		private sealed class NLOPDHALFOH<T1, T2, R>
		{
			public T1 param;

			public T2 param2;

			internal global::NCOKFFGPIJM<R> _003CShowTemporaryDialog_003Eb__0(UIDialog<T1, T2, R> dialogInstance)
			{
				return null;
			}
		}

		private sealed class PLIGMPAFFLP<DialogType, R> where DialogType : UIDialog
		{
			public GameObject dialogGameObject;

			internal void _003CShowTemporaryDialogInternal_003Eb__0()
			{
			}
		}

		private sealed class HLKIGPMOAMF<T1, R>
		{
			public T1 param;

			internal global::NCOKFFGPIJM<R> _003CShowTemporaryDialog_003Eb__0(UIDialog<T1, R> inst)
			{
				return null;
			}
		}

		private sealed class JILOOPICLPB<T1, T2, R>
		{
			public T1 param;

			public T2 param2;

			internal global::NCOKFFGPIJM<R> _003CShowTemporaryDialog_003Eb__0(UIDialog<T1, T2, R> inst)
			{
				return null;
			}
		}

		private sealed class PNBJGJDDFEG<T1>
		{
			public ConfirmUIDialog<T1> newDialog;

			internal void _003CShowTemporaryConfirmationDialog_003Eb__0()
			{
			}
		}

		public const string SIZE_CONFIG_KEY = "MAKER_PEN_PALETTE";

		[SerializeField]
		private TextInputUIDialog textInputDialogPrefab;

		[SerializeField]
		private NewCircuitV2PortUIDialog newCircuitV2PortUIDialog;

		[SerializeField]
		private GameObject moveButtonsRoot;

		[SerializeField]
		private Button3D moveUpButton;

		[SerializeField]
		private Button3D moveDownButton;

		[SerializeField]
		private Button3D moveLeftButton;

		[SerializeField]
		private Button3D moveRightButton;

		private Action<MoveableToolMenu.EBPGMFDOKPN> PNLAJDHJFHB__BackingField;

protected override string NPNGNBNICFF
{
get 		{
			return null;
		}

}

public event Action<MoveableToolMenu.EBPGMFDOKPN> MoveRequested {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowConfirmationDialog(string BOGCJKAMALE, string HGIIJBKEGMK)
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowConfirmationDialog(UIConfirmationDialog.EPIGOMCICOG HNPFAOFHHII, string BOGCJKAMALE, string HGIIJBKEGMK, string EMBGGBCIFOI, string JLCJLNNHFLO = "No")
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowConfirmationDialog(UIConfirmationDialog.EPIGOMCICOG HNPFAOFHHII, string BOGCJKAMALE, string HGIIJBKEGMK, string EMBGGBCIFOI, string JLCJLNNHFLO, string ADMBJPIEGBI)
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowConfirmationDialog(UIConfirmationDialog.EPIGOMCICOG HNPFAOFHHII, string BOGCJKAMALE, string HGIIJBKEGMK, string EMBGGBCIFOI, string JLCJLNNHFLO, string ADMBJPIEGBI, out UIConfirmationDialog MBKNEEPPNMC)
		{
			MBKNEEPPNMC = null;
			return null;
		}

		public global::NCOKFFGPIJM<TextInputUIDialog.FOBELBLMBDE> ShowTextInputDialog(TextInputUIDialog.FGHGFIFENNB DKHKBDFAJAK)
		{
			return null;
		}

		public global::NCOKFFGPIJM<ResponseType> ShowTemporaryDialog<DialogType, ResponseType>(DialogType HAAJEFICEGC, Func<DialogType, global::NCOKFFGPIJM<ResponseType>> NBDEDGNGODF) where DialogType : UIDialog<ResponseType>
		{
			return null;
		}

		public global::NCOKFFGPIJM<R> ShowTemporaryDialog<T1, R>(UIDialog<T1, R> HAAJEFICEGC, T1 AKPPKIEAJHD)
		{
			return null;
		}

		public global::NCOKFFGPIJM<R> ShowTemporaryDialog<T1, T2, R>(UIDialog<T1, T2, R> HAAJEFICEGC, T1 AKPPKIEAJHD, T2 OPFJELBCIBE)
		{
			return null;
		}

		private global::NCOKFFGPIJM<R> OIHBOCLBMMK<DialogType, R>(DialogType HAAJEFICEGC, Func<DialogType, global::NCOKFFGPIJM<R>> DGOMGMFAOFG, out DialogType LCPOJOKEPGJ) where DialogType : UIDialog
		{
			LCPOJOKEPGJ = null;
			return null;
		}

		public global::NCOKFFGPIJM<R> ShowTemporaryDialog<T1, R>(UIDialog<T1, R> HAAJEFICEGC, T1 AKPPKIEAJHD, out UIDialog<T1, R> LCPOJOKEPGJ)
		{
			LCPOJOKEPGJ = null;
			return null;
		}

		public global::NCOKFFGPIJM<R> ShowTemporaryDialog<T1, T2, R>(UIDialog<T1, T2, R> HAAJEFICEGC, T1 AKPPKIEAJHD, T2 OPFJELBCIBE, out UIDialog<T1, T2, R> LCPOJOKEPGJ)
		{
			LCPOJOKEPGJ = null;
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowTemporaryConfirmationDialog<T1>(ConfirmUIDialog<T1> HAAJEFICEGC, T1 FMLCCJGJPCD)
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> ShowTemporaryConfirmationDialog<T1>(ConfirmUIDialog<T1> HAAJEFICEGC, T1 FMLCCJGJPCD, out UIDialog<HGKINAOMNIF> LCPOJOKEPGJ)
		{
			LCPOJOKEPGJ = null;
			return null;
		}

		public void ShowNodeGroupConfigureMenu(CCFFIDBNKOF JJMNDCAFBDA, IAFGPKMBMBF BJFCMDBPAIN)
		{
		}

		public global::NCOKFFGPIJM<NewCircuitV2PortUIDialog.NDEGCIBOOFI> ShowNewPortDialog(bool GDJHKJELLAM)
		{
			return null;
		}

		public void SetMoveButtonVisibility(bool ICJJBCGNNOI)
		{
		}

		public Selectable TryGetMoveRequestUI(MoveableToolMenu.EBPGMFDOKPN HLFIBIDOLEF)
		{
			return null;
		}

		public void Button_MoveUp()
		{
		}

		public void Button_MoveDown()
		{
		}

		public void Button_MoveLeft()
		{
		}

		public void Button_MoveRight()
		{
		}
	}
}
