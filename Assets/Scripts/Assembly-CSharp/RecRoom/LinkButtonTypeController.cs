using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI.StackedUI.Dialog;
using RRUI.Data;
using UnityEngine;

namespace RecRoom
{
	public abstract class LinkButtonTypeController : MonoBehaviour, JFJHEFBLEFL, IDisposable
	{
		private sealed class BMMAJLOEJIF
		{
			public global::PHLHFLLLDLK<string> promise;

			internal void _003CGetNameAsync_003Eb__0(string x)
			{
			}

			internal void _003CGetNameAsync_003Eb__1(string x)
			{
			}
		}

		private sealed class PHHKBEBMDCC
		{
			public global::PHLHFLLLDLK<string> promise;

			internal void _003CGetImageNameAsync_003Eb__0(string name)
			{
			}

			internal void _003CGetImageNameAsync_003Eb__1(string x)
			{
			}
		}

		private sealed class DPPADKMGNCF
		{
			public LinkButtonTypeController _003C_003E4__this;

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

		private sealed class NBGIDNDENEO
		{
			public KCOKPCOFDIM pickerDialogData;

			public DPPADKMGNCF CS_0024_003C_003E8__locals1;

			internal void _003CGetDynamicLinkTargetConfigurableSetting_003Eb__4(int value)
			{
			}
		}

		public const string MissingLinkTargetName = "Missing";

		[SerializeField]
		private Sprite buttonIcon;

		private Action<long> DJOCIJFJFBF__BackingField;

		private Action ACHALFNCENJ__BackingField;

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

public Sprite ButtonIcon
{
get 		{
			return null;
		}

}

public abstract EFODFBBCBFH LinkType
{
get ;
}

public abstract string LinkTypeDisplayName
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

public virtual float LinkTargetImageAspectRatio
{
get 		{
			return 0f;
		}

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

public event Action<long> LinkTargetIdChanged {
add {
		}
remove {
		}
}

public event Action LinkTargetDetailsUpdated {
add {
		}
remove {
		}
}

		protected virtual void OnDestroy()
		{
		}

		public virtual void SetActive(bool FBHDABEFLKL)
		{
		}

		public void SetLinkTargetId(long IKHNIJKGJFD)
		{
		}

		public global::NCOKFFGPIJM<string> GetNameAsync()
		{
			return null;
		}

		public global::NCOKFFGPIJM<string> GetNameAsync(long IKHNIJKGJFD)
		{
			return null;
		}

		protected abstract global::NCOKFFGPIJM<string> PCBMJNFAFPN(long IKHNIJKGJFD);

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

		protected abstract global::NCOKFFGPIJM<string> GGLLGLKLGNA(long IKHNIJKGJFD);

		public DGMPBIPKJEB GetDynamicLinkTargetConfigurableSetting(Action<CLKEJFGKNDK, KCOKPCOFDIM> DHIELHGFHKK)
		{
			return null;
		}

		public abstract void OnLinkTargetIdChanged();

		public void FollowLink()
		{
		}

		protected abstract void CKPBINIPHDM(long IKHNIJKGJFD);

		protected global::NCOKFFGPIJM<int> PMPDGPLFJOL(string ADGIOFAMOGF)
		{
			return null;
		}

		protected abstract global::NCOKFFGPIJM<IEnumerable<long>> AOPEMKIPMAJ(string ADGIOFAMOGF);

		protected void FOLEKFHHCAP(long IKHNIJKGJFD)
		{
		}

		protected void JMHGCENHJKB()
		{
		}

		public void Dispose()
		{
		}

		protected abstract void KBDCEJBHCIA();

		[CompilerGenerated]
		private void DGOFHOGAOCI(IEnumerable<long> ILJGHKGMILC)
		{
		}

		[CompilerGenerated]
		private int MHEDAFOBNHE(IEnumerable<long> GADDGJANIGG)
		{
			return 0;
		}
	}
}
