using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom.Utils.Image;
using UnityEngine;

namespace RRUI.Data
{
	public class ClubAnnouncementCreationModel : ClubAnnouncementModel
	{
		public struct MIECNDJNDKA
		{
			public string CEPPDPAFBMB;

			public string AFCLNBLDKLB;

			public string KEBIFMKEGLL;

			public MKEKAHJCCEE.MetaData MAENJIODCCA;
		}

		private sealed class ADAKEDFPDPC
		{
			public ClubAnnouncementCreationModel _003C_003E4__this;

			public RRUI.Navigation.Uri redirectUri;

			internal void _003CCreate_003Eb__0(long announcementId)
			{
			}
		}

		private sealed class CPJJNHNKJDG
		{
			public long selectedRoomId;

			public ClubAnnouncementCreationModel _003C_003E4__this;

			public IReadOnlyList<JCDPHCELKHI> rooms;

			public global::PHLHFLLLDLK<MIECNDJNDKA?> announcementTargetPromise;

			public PickerDialogModel pickerDialog;

			public EHEJPNFKNAL selectButton;

			public Predicate<JCDPHCELKHI> _003C_003E9__8;

			internal void _003CSetAnnouncementRoomFromPickerDialog_003Eg__roomSelectClicked_007C0()
			{
			}

			internal bool _003CSetAnnouncementRoomFromPickerDialog_003Eb__6(JCDPHCELKHI r)
			{
				return false;
			}

			internal bool _003CSetAnnouncementRoomFromPickerDialog_003Eb__7()
			{
				return false;
			}

			internal void _003CSetAnnouncementRoomFromPickerDialog_003Eb__1(GameObject instance, int index, CardModel cardModel, RoomModel roomModel, JLOCLGGLOPP toCardController)
			{
			}

			internal int _003CSetAnnouncementRoomFromPickerDialog_003Eb__2()
			{
				return 0;
			}

			internal bool _003CSetAnnouncementRoomFromPickerDialog_003Eb__8(JCDPHCELKHI r)
			{
				return false;
			}

			internal void _003CSetAnnouncementRoomFromPickerDialog_003Eb__3(int index)
			{
			}

			internal bool _003CSetAnnouncementRoomFromPickerDialog_003Eb__4(string filter, int index)
			{
				return false;
			}

			internal void _003CSetAnnouncementRoomFromPickerDialog_003Eb__5(PickerDialogModel dialog)
			{
			}
		}

		private sealed class GAAENGFDECO
		{
			public long selectedInventionId;

			public ClubAnnouncementCreationModel _003C_003E4__this;

			public List<OEBAEGDPBLA> inventions;

			public global::PHLHFLLLDLK<MIECNDJNDKA?> announcementTargetPromise;

			public PickerDialogModel pickerDialog;

			public EHEJPNFKNAL selectButton;

			public Func<OEBAEGDPBLA, bool> _003C_003E9__7;

			public Predicate<OEBAEGDPBLA> _003C_003E9__8;

			internal void _003CSetAnnouncementInventionFromPickerDialog_003Eb__5()
			{
			}

			internal bool _003CSetAnnouncementInventionFromPickerDialog_003Eb__7(OEBAEGDPBLA i)
			{
				return false;
			}

			internal bool _003CSetAnnouncementInventionFromPickerDialog_003Eb__6()
			{
				return false;
			}

			internal void _003CSetAnnouncementInventionFromPickerDialog_003Eb__0(GameObject instance, int index, CardModel cardModel, InventionModel inventionModel, JLOCLGGLOPP toCardController)
			{
			}

			internal int _003CSetAnnouncementInventionFromPickerDialog_003Eb__1()
			{
				return 0;
			}

			internal bool _003CSetAnnouncementInventionFromPickerDialog_003Eb__8(OEBAEGDPBLA i)
			{
				return false;
			}

			internal void _003CSetAnnouncementInventionFromPickerDialog_003Eb__2(int index)
			{
			}

			internal bool _003CSetAnnouncementInventionFromPickerDialog_003Eb__3(string filter, int index)
			{
				return false;
			}

			internal void _003CSetAnnouncementInventionFromPickerDialog_003Eb__4(PickerDialogModel dialog)
			{
			}
		}

		private sealed class ABGLIAIMKDM
		{
			public long selectedEventId;

			public ClubAnnouncementCreationModel _003C_003E4__this;

			public IReadOnlyList<IMIJPHJKLIM> playerEvents;

			public global::PHLHFLLLDLK<MIECNDJNDKA?> announcementTargetPromise;

			public PickerDialogModel pickerDialog;

			public EHEJPNFKNAL selectButton;

			public Func<IMIJPHJKLIM, bool> _003C_003E9__7;

			public Predicate<IMIJPHJKLIM> _003C_003E9__11;

			internal void _003CSetAnnouncementEventFromPickerDialog_003Eb__5()
			{
			}

			internal bool _003CSetAnnouncementEventFromPickerDialog_003Eb__7(IMIJPHJKLIM e)
			{
				return false;
			}

			internal bool _003CSetAnnouncementEventFromPickerDialog_003Eb__6()
			{
				return false;
			}

			internal void _003CSetAnnouncementEventFromPickerDialog_003Eb__0(GameObject instance, int index, CardModel cardModel, EventModel eventModel, JLOCLGGLOPP toCardController)
			{
			}

			internal int _003CSetAnnouncementEventFromPickerDialog_003Eb__1()
			{
				return 0;
			}

			internal bool _003CSetAnnouncementEventFromPickerDialog_003Eb__11(IMIJPHJKLIM e)
			{
				return false;
			}

			internal void _003CSetAnnouncementEventFromPickerDialog_003Eb__2(int index)
			{
			}

			internal bool _003CSetAnnouncementEventFromPickerDialog_003Eb__3(string filter, int index)
			{
				return false;
			}

			internal void _003CSetAnnouncementEventFromPickerDialog_003Eb__4(PickerDialogModel dialog)
			{
			}
		}

		private sealed class KAGAPLAMBNN
		{
			public string announcementImageName;

			public MKEKAHJCCEE.MetaData metaData;

			public ABGLIAIMKDM CS_0024_003C_003E8__locals1;

			internal void _003CSetAnnouncementEventFromPickerDialog_003Eb__8(JCDPHCELKHI r)
			{
			}

			internal void _003CSetAnnouncementEventFromPickerDialog_003Eb__9()
			{
			}
		}

		private sealed class DJEEBDPPCCI
		{
			public CardModel cardModel;

			internal void _003CSetAnnouncementEventFromPickerDialog_003Eb__10(JCDPHCELKHI r)
			{
			}
		}

		private sealed class FGJALIAKHAC
		{
			public long selectedClubId;

			public ClubAnnouncementCreationModel _003C_003E4__this;

			public List<EPILDIJELPG> clubs;

			public global::PHLHFLLLDLK<MIECNDJNDKA?> announcementTargetPromise;

			public PickerDialogModel pickerDialog;

			public EHEJPNFKNAL selectButton;

			public Func<EPILDIJELPG, bool> _003C_003E9__7;

			public Predicate<EPILDIJELPG> _003C_003E9__8;

			internal void _003CSetAnnouncementClubFromPickerDialog_003Eb__5()
			{
			}

			internal bool _003CSetAnnouncementClubFromPickerDialog_003Eb__7(EPILDIJELPG c)
			{
				return false;
			}

			internal bool _003CSetAnnouncementClubFromPickerDialog_003Eb__6()
			{
				return false;
			}

			internal void _003CSetAnnouncementClubFromPickerDialog_003Eb__0(GameObject instance, int index, CardModel cardModel, ClubModel clubModel, JLOCLGGLOPP toCardController)
			{
			}

			internal int _003CSetAnnouncementClubFromPickerDialog_003Eb__1()
			{
				return 0;
			}

			internal bool _003CSetAnnouncementClubFromPickerDialog_003Eb__8(EPILDIJELPG c)
			{
				return false;
			}

			internal void _003CSetAnnouncementClubFromPickerDialog_003Eb__2(int index)
			{
			}

			internal bool _003CSetAnnouncementClubFromPickerDialog_003Eb__3(string filter, int index)
			{
				return false;
			}

			internal void _003CSetAnnouncementClubFromPickerDialog_003Eb__4(PickerDialogModel dialog)
			{
			}
		}

		private sealed class HPOMGEEPNLF
		{
			public int selectedAccountId;

			public ClubAnnouncementCreationModel _003C_003E4__this;

			public List<DFDECAEJBIO> accounts;

			public global::PHLHFLLLDLK<MIECNDJNDKA?> announcementTargetPromise;

			public PickerDialogModel pickerDialog;

			public EHEJPNFKNAL selectButton;

			public Func<DFDECAEJBIO, bool> _003C_003E9__7;

			public Predicate<DFDECAEJBIO> _003C_003E9__8;

			internal void _003CSetAnnouncementPlayerFromPickerDialog_003Eb__5()
			{
			}

			internal bool _003CSetAnnouncementPlayerFromPickerDialog_003Eb__7(DFDECAEJBIO a)
			{
				return false;
			}

			internal bool _003CSetAnnouncementPlayerFromPickerDialog_003Eb__6()
			{
				return false;
			}

			internal void _003CSetAnnouncementPlayerFromPickerDialog_003Eb__0(GameObject instance, int index, CardModel cardModel, AccountModel accountModel, JLOCLGGLOPP toCardController)
			{
			}

			internal int _003CSetAnnouncementPlayerFromPickerDialog_003Eb__1()
			{
				return 0;
			}

			internal bool _003CSetAnnouncementPlayerFromPickerDialog_003Eb__8(DFDECAEJBIO a)
			{
				return false;
			}

			internal void _003CSetAnnouncementPlayerFromPickerDialog_003Eb__2(int index)
			{
			}

			internal bool _003CSetAnnouncementPlayerFromPickerDialog_003Eb__3(string filter, int index)
			{
				return false;
			}

			internal void _003CSetAnnouncementPlayerFromPickerDialog_003Eb__4(PickerDialogModel dialog)
			{
			}
		}

		private sealed class NHJLNPPPEMI
		{
			public ClubAnnouncementCreationModel _003C_003E4__this;

			public string currentCode;

			public global::PHLHFLLLDLK<MIECNDJNDKA?> announcementTargetPromise;

			public MessageWithInputFieldDialogModel inputDialog;

			internal void _003CSetAnnouncementCodeFromInputDialog_003Eb__1()
			{
			}

			internal string _003CSetAnnouncementCodeFromInputDialog_003Eb__2()
			{
				return null;
			}

			internal void _003CSetAnnouncementCodeFromInputDialog_003Eb__3(string s)
			{
			}

			internal void _003CSetAnnouncementCodeFromInputDialog_003Eb__0(BaseDialogModel<EJBAHPMBHMO> dialog)
			{
			}
		}

		private sealed class KJIDDEAPPJL
		{
			public long selectedImageId;

			public ClubAnnouncementCreationModel _003C_003E4__this;

			public List<GDHOAGNFOBD.FPPNEFOBPMC> images;

			public global::PHLHFLLLDLK<MIECNDJNDKA?> announcementTargetPromise;

			public PickerDialogModel pickerDialog;

			public EHEJPNFKNAL selectButton;

			public Func<GDHOAGNFOBD.FPPNEFOBPMC, bool> _003C_003E9__6;

			public Predicate<GDHOAGNFOBD.FPPNEFOBPMC> _003C_003E9__7;

			internal void _003CSetAnnouncementImageFromPickerDialog_003Eb__4()
			{
			}

			internal bool _003CSetAnnouncementImageFromPickerDialog_003Eb__6(GDHOAGNFOBD.FPPNEFOBPMC c)
			{
				return false;
			}

			internal bool _003CSetAnnouncementImageFromPickerDialog_003Eb__5()
			{
				return false;
			}

			internal void _003CSetAnnouncementImageFromPickerDialog_003Eb__0(GameObject instance, int index, CardModel cardModel, ImageModel imageModel, JLOCLGGLOPP toCardController)
			{
			}

			internal int _003CSetAnnouncementImageFromPickerDialog_003Eb__1()
			{
				return 0;
			}

			internal bool _003CSetAnnouncementImageFromPickerDialog_003Eb__7(GDHOAGNFOBD.FPPNEFOBPMC i)
			{
				return false;
			}

			internal void _003CSetAnnouncementImageFromPickerDialog_003Eb__2(int index)
			{
			}

			internal void _003CSetAnnouncementImageFromPickerDialog_003Eb__3(PickerDialogModel dialog)
			{
			}
		}

		private MIECNDJNDKA? MPPNPLMPCFK;

		private readonly ManagedTexture PHDELAPLILN;

		protected IBBBLACMLDJ.CMFELPHLODK LOOIOLJEAEL;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public override bool HasAnnouncementAction
{
get 		{
			return false;
		}

}

public bool IsExistingAnnouncement
{
get 		{
			return false;
		}

}

public MIECNDJNDKA? AnnouncementCreationParameters
{
get 		{
			return null;
		}

private set {
		}
}

public MDBOJJGFLJC AnnouncementType
{
get 		{
			return MDBOJJGFLJC.Generic;
		}

set {
		}
}

public bool HasValidEditData
{
get 		{
			return false;
		}

}

public string Title
{
get 		{
			return null;
		}

set {
		}
}

public string Body
{
get 		{
			return null;
		}

set {
		}
}

public string ImageName
{
get 		{
			return null;
		}

set {
		}
}

		public void Set(GFDDIOFHFHI HLOGCBHNKIL)
		{
		}

		public void Set(long AFPHABFLEBN, MIECNDJNDKA? PBIOOLMNIAD = null)
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		public static char OnAnnouncementTitleValidate(string HLIGBKANEEA, int MLPMIFMIOKK, char EAAIEEDJAHD)
		{
			return '\0';
		}

		public static char OnAnnouncementBodyValidate(string HLIGBKANEEA, int MLPMIFMIOKK, char EAAIEEDJAHD)
		{
			return '\0';
		}

		public void TakePhotoForImage()
		{
		}

		public void RemoveImage()
		{
		}

		private void DNLNHCOLMEP(MIECNDJNDKA HMJOKPKOPCN)
		{
		}

		public void Edit()
		{
		}

		public void Create(RRUI.Navigation.Uri FJCDIOMHHBK)
		{
		}

		public void Cancel()
		{
		}

		private void MHPFKBHAKFB()
		{
		}

		public void SetAnnouncementType(MDBOJJGFLJC FDEDGHKJDDO)
		{
		}

		public string GetHeaderLabel()
		{
			return null;
		}

		public global::NCOKFFGPIJM<string> GetTargetLabel()
		{
			return null;
		}

		public global::NCOKFFGPIJM<string> GetPreviewActionLabel()
		{
			return null;
		}

		public global::NCOKFFGPIJM<MIECNDJNDKA?> ShowAnnouncementTargetPickerByAnnouncementType()
		{
			return null;
		}

		private global::NCOKFFGPIJM<MIECNDJNDKA?> IBEBNMOALGM(IReadOnlyList<JCDPHCELKHI> CECGEDKICOA)
		{
			return null;
		}

		private global::NCOKFFGPIJM<MIECNDJNDKA?> FIAJMIDLCMN(List<OEBAEGDPBLA> AMIAEMLONAO)
		{
			return null;
		}

		private global::NCOKFFGPIJM<MIECNDJNDKA?> JGAOMAAPPKI(IReadOnlyList<IMIJPHJKLIM> FAJAFJNJLLA)
		{
			return null;
		}

		private global::NCOKFFGPIJM<MIECNDJNDKA?> JHFKMLPOGMP(List<EPILDIJELPG> NDAEMCFLEJP)
		{
			return null;
		}

		private global::NCOKFFGPIJM<MIECNDJNDKA?> OBMFNLDNEIM(List<DFDECAEJBIO> AGIGKKMBEKN)
		{
			return null;
		}

		private global::NCOKFFGPIJM<MIECNDJNDKA?> JFLLBEIDDHA()
		{
			return null;
		}

		private global::NCOKFFGPIJM<MIECNDJNDKA?> CDFCJGHJGPB(List<GDHOAGNFOBD.FPPNEFOBPMC> CBLOLEAFFPC)
		{
			return null;
		}

		private global::NCOKFFGPIJM<PickerDialogModel> AMCDCABOFPD<TFromModel, TToCardControllerProvider>(string OFMGPNLDCAB, int MEPMFCLDDMG, EHEJPNFKNAL LDBMLFFGJJO, Action<GameObject, int, CardModel, TFromModel, JLOCLGGLOPP> PBOGCCJLCFP, Func<int> CCNCMDKICAL, Action<int> ADPABEABDCN, Func<string, int, bool> DAAGNHDMOFI = null, GameObject KCCLAKKGFJI = null) where TFromModel : ModelBase where TToCardControllerProvider : ControllerBase, AJFPIIJCIFO, DDIDMFFBNAE
		{
			return null;
		}

		[CompilerGenerated]
		private void BFLCHHNCLLM(MKEKAHJCCEE NONLILMOAPN)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<string> OJOMFJJKOAD(List<GDHOAGNFOBD.FPPNEFOBPMC> CBLOLEAFFPC)
		{
			return null;
		}

		[CompilerGenerated]
		private void AHHMIOOFFLA(string NPOEAPJKNFN)
		{
		}

		[CompilerGenerated]
		private void PJIJEIPMALA()
		{
		}

		[CompilerGenerated]
		private void CPFBMPAIODA()
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<MIECNDJNDKA?> AKHDGKGPEEC(IReadOnlyList<JCDPHCELKHI> CECGEDKICOA)
		{
			return null;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<MIECNDJNDKA?> GNBNGPOPIKI(List<OEBAEGDPBLA> AMIAEMLONAO)
		{
			return null;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<MIECNDJNDKA?> LGEGLMOKIIN(List<IMIJPHJKLIM> IAOPBOEHEOP)
		{
			return null;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<MIECNDJNDKA?> ICNIPKLIHLO(List<EPILDIJELPG> NDAEMCFLEJP)
		{
			return null;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<MIECNDJNDKA?> BLDNIGOADGJ(List<GDHOAGNFOBD.FPPNEFOBPMC> CBLOLEAFFPC)
		{
			return null;
		}
	}
}
