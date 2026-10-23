using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using AGUI.StackedUI;
using RecRoom.AGUI;
using UnityEngine;

namespace RecRoom.Core
{
	public class ScreenWorldSpaceUIAnchor : MonoBehaviour
	{
		private sealed class DCNPMMLLNEF
		{
			public MenuProjector menuProjector;

			public StackedUIBase uiBase;

			internal Vector2 _003CAttach_003Eg__GetWorldSizeFromProjector_007C0()
			{
				return default;
			}
		}

		private sealed class EGFCEHOINBM : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public ScreenWorldSpaceUIAnchor _003C_003E4__this;

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
			public EGFCEHOINBM(int _003C_003E1__state)
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

		private const float LEKEBOGLNLJ = 0.4f;

		private const float OHHBNHHMKBM = 0.2f;

		private const float INLAKKGLGPO = 4200f;

		private Camera ICIOFIAEPLI;

		private CameraIgnoreBubble ABAGLDAEEOK;

		private StackedUIBase EONCGBAFAIH;

		private GameObject CDLPNIKNKPB;

		private Transform FDAFGPLANAA;

		private Vector3 GIFDGICCHEF;

		private Quaternion MKOJNJBDJOJ;

		private Vector3 CJBJMCBGMPF;

		private Func<Vector2> KDGCONNKIEO;

		private Quaternion KAMDMKIOMOF;

		private bool ALBFLJNCMAD;

		private float FFOLAIDDHGI;

		private float DDBDMKMNPNH;

		private LKGILLBEJEK BCBOHAANHHN;

public StackedUIBase AttachedUI
{
get 		{
			return null;
		}

private set {
		}
}

public GameObject AttachedGameObject
{
get 		{
			return null;
		}

private set {
		}
}

private Quaternion NHIKICEPLMI
{
get 		{
			return default;
		}

}

		private Vector3 MGFPFGOPONO(Vector2 LGOFCCMAGBP)
		{
			return default;
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void Attach(StackedUIBase MKHLKCMEBLE, MenuProjector MKKCNJHGIGA, float FFOLAIDDHGI, float KICNGNINEBK = 0f, bool ALBFLJNCMAD = false)
		{
		}

		public void Attach(GameObject FGBMGGEJOEA, Func<Vector2> AOHNDEGNFCI, Quaternion IBHAEICNMJI, float FFOLAIDDHGI = 1f, float KICNGNINEBK = 0f, bool ALBFLJNCMAD = false)
		{
		}

		private void FANFPECLMPG(GameObject FGBMGGEJOEA, Transform MICHOEKGOII, Func<Vector2> AOHNDEGNFCI, Quaternion IBHAEICNMJI, float FFOLAIDDHGI, float KICNGNINEBK, bool ALBFLJNCMAD)
		{
		}

		public void Detach()
		{
		}

		private IEnumerator<EGGPGCCKPCO> JAHPHBDOHGK()
		{
			return null;
		}

		public bool TryUpdateAttachedPosition()
		{
			return false;
		}

		private void OnDrawGizmos()
		{
		}
	}
}
