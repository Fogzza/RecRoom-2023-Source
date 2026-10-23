using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI.StackedUI.Dialog;
using RRUI.Data;
using UnityEngine;

namespace RecRoom
{
	public abstract class ShowcasePosterTypeController : MonoBehaviour, ALCGFACOHOF, IDisposable
	{
		private sealed class HMIHCLJLPGJ
		{
			public ShowcasePosterTypeController _003C_003E4__this;

			public Action<CLKEJFGKNDK, KCOKPCOFDIM> showPickerDialog;

			public Func<long, global::NCOKFFGPIJM<string>> _003C_003E9__5;

			public Func<long, global::NCOKFFGPIJM<string>> _003C_003E9__6;

			public Action<GameObject, int, CardModel, SearchResultViewModel, JLOCLGGLOPP> _003C_003E9__2;

			public Func<int> _003C_003E9__3;

			public Action<int> _003C_003E9__1;

			internal void _003CGetDynamicLinkTargetConfigurableSetting_003Eb__0()
			{
			}

			internal void _003CGetDynamicLinkTargetConfigurableSetting_003Eb__1(int count)
			{
			}

			internal void _003CGetDynamicLinkTargetConfigurableSetting_003Eb__2(GameObject instance, int index, CardModel cardModel, SearchResultViewModel fromModel, JLOCLGGLOPP toCardController)
			{
			}

			internal global::NCOKFFGPIJM<string> _003CGetDynamicLinkTargetConfigurableSetting_003Eb__5(long id)
			{
				return null;
			}

			internal global::NCOKFFGPIJM<string> _003CGetDynamicLinkTargetConfigurableSetting_003Eb__6(long id)
			{
				return null;
			}

			internal int _003CGetDynamicLinkTargetConfigurableSetting_003Eb__3()
			{
				return 0;
			}
		}

		private sealed class ECOFJDMCCJC
		{
			public KCOKPCOFDIM pickerDialogData;

			public HMIHCLJLPGJ CS_0024_003C_003E8__locals1;

			internal void _003CGetDynamicLinkTargetConfigurableSetting_003Eb__4(int value)
			{
			}
		}

		private sealed class BPOLKMGPBHJ
		{
			public global::PHLHFLLLDLK<string> promise;

			internal void _003CGetNameAsync_003Eb__0(string x)
			{
			}

			internal void _003CGetNameAsync_003Eb__1(string x)
			{
			}
		}

		private sealed class BIAMEPLDDLD
		{
			public global::PHLHFLLLDLK<string> promise;

			internal void _003CGetImageNameAsync_003Eb__0(string name)
			{
			}

			internal void _003CGetImageNameAsync_003Eb__1(string x)
			{
			}
		}

		public const string MissingContentTargetName = "Missing";

		public const string NotConfiguredContentTargetName = "Configure";

		public const string DefaultPosterName = "";

		[SerializeField]
		public GameObject DefaultDisplay;

		[SerializeField]
		private Transform targetDisplay;

		[SerializeField]
		private Sprite targetIcon;

		private Action<long> CAOPEJKAHKE__BackingField;

		private Action PLJADAADHNP__BackingField;

		private bool IGCNICDIEAM;

		protected long GHIEHEOOCPN;

		protected GDHOAGNFOBD.KEIAPDLHGPG CDOODAKHDKC;

		private readonly List<long> HOPHONGOICE;

		private string JJHLGKHAFNK;

private static Texture2D BNMAFEPIJPB
{
get 		{
			return null;
		}

}

public Transform TargetDisplay
{
get 		{
			return null;
		}

}

public Sprite TargetIcon
{
get 		{
			return null;
		}

}

public abstract NHGKMDCGGIM ContentType
{
get ;
}

public abstract string ContentTypeDisplayName
{
get ;
}

public bool HasValidTarget
{
get 		{
			return false;
		}

set {
		}
}

public virtual float ContentTargetImageAspectRatio
{
get 		{
			return 0f;
		}

}

public abstract Dictionary<string, MIBJNNKFLND> DisplayFlagOptions
{
get ;
}

protected abstract string IBDDHKJKCPG
{
get ;
}

protected abstract string DILEJPCNFCO
{
get ;
}

protected abstract string DEALKAOCFOA
{
get ;
}

public event Action<long> ContentTargetIdChanged {
add {
		}
remove {
		}
}

public event Action ContentTargetDetailsUpdated {
add {
		}
remove {
		}
}

		protected virtual void OnDestroy()
		{
		}

		public DGMPBIPKJEB GetDynamicLinkTargetConfigurableSetting(Action<CLKEJFGKNDK, KCOKPCOFDIM> DHIELHGFHKK)
		{
			return null;
		}

		public global::NCOKFFGPIJM<string> GetNameAsync()
		{
			return null;
		}

		public global::NCOKFFGPIJM<string> GetNameAsync(long IKHNIJKGJFD)
		{
			return null;
		}

		public global::NCOKFFGPIJM<string> GetImageNameAsync(out float GDMKKLNFDOP)
		{
			GDMKKLNFDOP = default;
			return null;
		}

		public global::NCOKFFGPIJM<string> GetImageNameAsync(long IKHNIJKGJFD, out float GDMKKLNFDOP)
		{
			GDMKKLNFDOP = default;
			return null;
		}

		public virtual void SetUIBehaviourElement(long PACFOLBJLAK)
		{
		}

		public virtual void ToggleContentTypeDisplay(bool FBHDABEFLKL)
		{
		}

		public void FollowLink()
		{
		}

		private void FOLEKFHHCAP(long IKHNIJKGJFD)
		{
		}

		protected void AHDNNHGMEFF()
		{
		}

		public virtual void SetActive(bool FBHDABEFLKL)
		{
		}

		public void SetContentTargetId(long IKHNIJKGJFD)
		{
		}

		public void Dispose()
		{
		}

		public abstract void OnContentTargetIdChanged();

		public abstract void SetDisplayType(out float MAPNJIMLAMD, out GameObject CECLGJEOAPE, NFMBFHFPDOA LMCPAOHFDNH);

		protected global::NCOKFFGPIJM<int> PMPDGPLFJOL(string ADGIOFAMOGF)
		{
			return null;
		}

		protected abstract global::NCOKFFGPIJM<IEnumerable<long>> AOPEMKIPMAJ(string ADGIOFAMOGF);

		protected abstract global::NCOKFFGPIJM<string> PCBMJNFAFPN(long IKHNIJKGJFD);

		protected abstract global::NCOKFFGPIJM<string> GGLLGLKLGNA(long IKHNIJKGJFD);

		protected abstract void CKPBINIPHDM(long IKHNIJKGJFD);

		protected abstract void KBDCEJBHCIA();

		[CompilerGenerated]
		private void JCLDJPEANBM(IEnumerable<long> ILJGHKGMILC)
		{
		}

		[CompilerGenerated]
		private int HDLABMECLMN(IEnumerable<long> GADDGJANIGG)
		{
			return 0;
		}
	}
}
