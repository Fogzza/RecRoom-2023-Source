using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RecRoom.AGUI.Expresso
{
	public class ExpressoButton : MonoBehaviour
	{
		[Serializable]
		public class ExpressoButtonInteraction : UnityEvent
		{
		}

		public enum HKEDLPDLHOK
		{
			Disabled = -1,
			Idle = 0,
			Enter = 1,
			Stay = 2,
			Exit = 3
		}

		private sealed class OMAGNMKCMHA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ExpressoButton _003C_003E4__this;

			private float _003CstartTime_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public OMAGNMKCMHA(int _003C_003E1__state)
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
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private GameObject triggerVolume;

		[SerializeField]
		private BoxCollider interactionCollider;

		public bool CloseMenuOnInteraction;

		public ExpressoButtonInteraction OnInteractionEnter;

		public ExpressoButtonInteraction OnInteractionStay;

		public ExpressoButtonInteraction OnInteractionExit;

		public ExpressoButtonInteraction OnButtonActivated;

		public ExpressoButtonInteraction OnButtonDeactivated;

		public RecRoomAudioClip enterAudio;

		public RecRoomAudioClip stayAudio;

		public RecRoomAudioClip exitAudio;

		public float exitAnimationDuration;

		[SerializeField]
		private Image toggledIcon;

		[SerializeField]
		public MeshRenderer visualVolume;

		[SerializeField]
		private Image buttonIcon;

		[SerializeField]
		private Text buttonLabel;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private RectTransform UICanvasTransfrom;

		private ExpressoUIFlow AHMCPJDCMEF;

		private static readonly int HFOPKFPPJLM;

		[SerializeField]
		public string interactionNotification;

		private HKEDLPDLHOK ELMKPKCLHGE;

		private SFXAudioSource KKFMAKGDJDO;

		private Collider[] HOIDOJGDKJN;

		private bool KEHKNFIADOJ;

public bool Active
{
get 		{
			return false;
		}

set {
		}
}

public HKEDLPDLHOK ButtonState
{
get 		{
			return HKEDLPDLHOK.Idle;
		}

}

public GameObject TriggerVolume
{
get 		{
			return null;
		}

}

public Image Icon
{
get 		{
			return null;
		}

}

public Text Label
{
get 		{
			return null;
		}

}

public bool Toggled
{
get 		{
			return false;
		}

set {
		}
}

		private void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void FINBHHGMMBJ(ExpressoButtonInteraction FKLNMDHINDL)
		{
		}

		private void OEGMENAEEAE()
		{
		}

		protected virtual bool JJBHHLLEKNA()
		{
			return false;
		}

		private IEnumerator GIMKHLMEDDF()
		{
			return null;
		}
	}
}
