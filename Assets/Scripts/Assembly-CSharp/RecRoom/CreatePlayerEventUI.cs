using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using AGUI.StackedUI.Dialog;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom
{
	public class CreatePlayerEventUI : MonoBehaviour
	{
		private sealed class IDIPGKPLJBK
		{
			public CreatePlayerEventUI _003C_003E4__this;

			public GDCLLKJIJPJ response;

			public JCDPHCELKHI room;

			internal void _003CHandleCreateResponse_003Eb__0(NCBAEFEDLMK details)
			{
			}
		}

		private const int GPDKOOCPALE = 20;

		private Action HEGJIGKMGKC__BackingField;

		[SerializeField]
		private RawImage eventImage;

		[SerializeField]
		private InputField3D nameField;

		[SerializeField]
		private InputField3D descriptionField;

		[SerializeField]
		private TMP_Text tagsField;

		[SerializeField]
		private TextMeshProUGUI infoText;

		[SerializeField]
		private TextMeshProUGUI startDateButtonText;

		[SerializeField]
		private TextMeshProUGUI timeRangeButtonText;

		[SerializeField]
		private TextMeshProUGUI locationButtonText;

		[SerializeField]
		private Slider3D eventAccessibilitySlider;

		[SerializeField]
		private Button3D createButton;

		[SerializeField]
		private EventsScreen parentEventsScreen;

		[SerializeField]
		private UIDateSelectionDialog datePickerPrefab;

		[SerializeField]
		private TimeRangeSelectionDialog timeRangePickerPrefab;

		[SerializeField]
		private ChooseEventLocationDialog locationPickerPrefab;

		[SerializeField]
		private EditPlayerEventTagsDialog editTagsDialog;

		private DateTime? BKMCFILAAFM;

		private TimeRangeSelectionDialog.GLEGFFOOPGA DAPALPMGILG;

		private ChooseEventLocationDialog.KIMGKCKCMFO KJAPODOABPN;

		private long? AFPHABFLEBN;

		private string NPOEAPJKNFN;

		private GDHOAGNFOBD.KEIAPDLHGPG CCHMKKIAPPM;

		private readonly List<string> CMBMOBEBGIN;

public event Action CreatedEvent {
add {
		}
remove {
		}
}

		private void Awake()
		{
		}

		public void ClearDetails()
		{
		}

		private void OnDestroy()
		{
		}

		public void SetTargetEventClub(long? AFPHABFLEBN)
		{
		}

		private void PBKHJPPPNEE(GDCLLKJIJPJ MLDANHIGANI)
		{
		}

		private void BJFJAMMLFAE(string OFCFPGACNJB)
		{
		}

		public void Button_CreateEvent()
		{
		}

		private void HIPPCLBBLJE()
		{
		}

		public void Button_EditTags()
		{
		}

		public void Button_ChooseImage()
		{
		}

		public void Button_ChooseStartDate()
		{
		}

		public void Button_ChooseTimeRange()
		{
		}

		public void Button_ChooseLocation()
		{
		}

		private string MMIODCMDMGG()
		{
			return null;
		}

		[CompilerGenerated]
		private void AGDHCCPKBDK(string LOKKJFCDNHB)
		{
		}

		[CompilerGenerated]
		private void ABNGANGOGBM(List<string> CAAEKCPKGHN)
		{
		}

		[CompilerGenerated]
		private void IBEGBMJMPLP(string NPOEAPJKNFN)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<Texture2D> DAGNKDPHALD(GDHOAGNFOBD.KEIAPDLHGPG JFBFDAHGLDO)
		{
			return null;
		}

		[CompilerGenerated]
		private void BODENAGGNDF(Texture2D IECDHEIBMJN)
		{
		}

		[CompilerGenerated]
		private void BFMKHJNHHLK(string PEHCJFEPFJN)
		{
		}

		[CompilerGenerated]
		private void DJMAKBPKCOJ(DateTime? BEEAEBLMLIH)
		{
		}

		[CompilerGenerated]
		private void KKFKMPCDKAF(TimeRangeSelectionDialog.GLEGFFOOPGA BMHHMBOMICL)
		{
		}

		[CompilerGenerated]
		private void PJAPKCNHDFD(ChooseEventLocationDialog.KIMGKCKCMFO CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void EOMACGLPIDG(Texture2D CIONKGJFLOB)
		{
		}
	}
}
