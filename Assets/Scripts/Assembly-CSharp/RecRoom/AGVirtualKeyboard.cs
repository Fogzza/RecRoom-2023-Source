using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom
{
	public class AGVirtualKeyboard : MonoBehaviour
	{
		private sealed class AIFLLKJOOMC : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public AGVirtualKeyboard _003C_003E4__this;

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
			public AIFLLKJOOMC(int _003C_003E1__state)
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

		private sealed class LFIMDBPHHNG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public AGVirtualKeyboard _003C_003E4__this;

			public Transform parent;

			public Vector3 localPosition;

			public Quaternion localRotation;

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
			public LFIMDBPHHNG(int _003C_003E1__state)
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

		private sealed class IACLICMFCNG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public AGVirtualKeyboard _003C_003E4__this;

			public bool immediate;

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
			public IACLICMFCNG(int _003C_003E1__state)
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

		private const float GKFMJECOAFG = 0.3f;

		private const string CHGCDBKPHBF = "KeyboardActive";

		private const float NJLODFFCGBH = 0.5f;

		[SerializeField]
		private Punchkeyboard punchkeyboard;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private GameObject keyboardRoot;

		[SerializeField]
		private float detachedDistance;

		[SerializeField]
		private float detachedHeightOffset;

		[SerializeField]
		private float detachedPitch;

		private FIHGBEHGLGB PHEAGIEJIEP;

		private object GHHKLKDKALG;

		private HENLAGEACNC ICJILAOFLJF;

		private Vector3 IFFALEBIKPP;

		private Transform AMPKDECJAOF;

		private IDisposable OHODPCAEANA;

		private IDisposable OBECBJCGHMB;

		private bool KLPIBGENBBE;

		private static Action NIAGGANPFDP__BackingField;

		private static Action EKBPHBEOKII__BackingField;

		private Action KCGJKOLPOCN__BackingField;

public bool CanOpenAutomatically
{
get 		{
			return false;
		}

}

public bool IsOpen
{
get 		{
			return false;
		}

private set {
		}
}

public bool KeysEnabled
{
get 		{
			return false;
		}

set {
		}
}

private bool HLJOHDAIHLB
{
get 		{
			return false;
		}

}

private Vector3 JAAIEOCELJP
{
get 		{
			return default;
		}

}

private Quaternion JECOAJGMFEH
{
get 		{
			return default;
		}

}

public static event Action OnKeyboardOpened {
add {
		}
remove {
		}
}

public static event Action OnKeyboardClosed {
add {
		}
remove {
		}
}

public event Action OnAnyKeyPressed {
add {
		}
remove {
		}
}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private IEnumerator<EGGPGCCKPCO> PCOACDLIALN()
		{
			return null;
		}

		private void GAHHBGJBCCA()
		{
		}

		private void FAILELCFHPM()
		{
		}

		private bool HFNBIHJGIHC(out HENLAGEACNC OBCJKGPLPPP)
		{
			OBCJKGPLPPP = null;
			return false;
		}

		public void DisableAutomaticOpening(object IALNODEHBNN)
		{
		}

		public void EnableAutomaticOpening(object IALNODEHBNN)
		{
		}

		public void ShowKeyboard(object IALNODEHBNN, Transform HNECJLNIOCG)
		{
		}

		public void ShowKeyboard(object IALNODEHBNN, Vector3 ADJINPMOILO, Quaternion LLJPMBHCKEE)
		{
		}

		private void JBJOKHOCDGP(object IALNODEHBNN, Transform HHFDFFDPCGO, Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI)
		{
		}

		public void HideKeyboard(object IALNODEHBNN, bool GLKBGPHMMNC = false)
		{
		}

		public void ForceHideKeyboard(bool GLKBGPHMMNC)
		{
		}

		private void KCHBFPMLCKJ(bool GLKBGPHMMNC)
		{
		}

		private IEnumerator<EGGPGCCKPCO> AJKCHKDOAHN(Transform HHFDFFDPCGO, Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI)
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> AKHGCEJPKMI(bool GLKBGPHMMNC)
		{
			return null;
		}

		private void NFOEDKPPHKK()
		{
		}
	}
}
