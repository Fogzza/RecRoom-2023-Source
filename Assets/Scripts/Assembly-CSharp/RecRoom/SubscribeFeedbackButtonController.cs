using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom
{
	public class SubscribeFeedbackButtonController : MonoBehaviour
	{
		private sealed class DPIOEMKCKLN : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SubscribeFeedbackButtonController _003C_003E4__this;

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
			public DPIOEMKCKLN(int _003C_003E1__state)
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

		private sealed class GAHBHLICEGF
		{
			public List<int> owners;

			public SubscribeFeedbackButtonController _003C_003E4__this;

			internal void _003COnSeeAllCreatorsButtonPushed_003Eb__1(PlayerListScreen flow)
			{
			}
		}

		[SerializeField]
		private RoomOrPlaylistSpecificUIBehaviour roomDetailsProvider;

		[SerializeField]
		private AccountSpecificUIBehaviour creatorDetailsProvider;

		[SerializeField]
		private Transform subscribeToCreatorsRoot;

		[SerializeField]
		private TMP_Text subscribeLabel;

		[SerializeField]
		private Image subscribeIconImage;

		[SerializeField]
		private ChargePhysicalButton subscribeToCreatorButton;

		[SerializeField]
		private PhysicalButtonLocalToggleAdapter subscribeToCreatorToggleButton;

		[SerializeField]
		private Sprite toggledOffSprite;

		[SerializeField]
		private Sprite toggledOnSprite;

		[SerializeField]
		private string toggledOffLabel;

		[SerializeField]
		private string toggledOnLabel;

		[SerializeField]
		private Transform viewAllCreatorsRoot;

		[SerializeField]
		private PhysicalButtonBase viewAllCreatorsButton;

		[SerializeField]
		private string amplitudeEventContextLabel;

		private readonly global::LPOCMKDAPMN<PlayerListScreen> OHEKLFDCFNC;

		private void Awake()
		{
		}

		private IEnumerator OGNMJMCEIEO()
		{
			return null;
		}

		private void DNFKAIIHMHG()
		{
		}

		private void OEGMENAEEAE()
		{
		}

		private void ENGIMCOBPLG(RoomOrPlaylistSpecificUIBehaviour.EBIKMOHGHOJ JDBHABEFGKF, RoomOrPlaylistSpecificUIBehaviour.OPBALFHHAFF BFFCGPJEHGB, BNKIKFBACEL NIFOGEBEDNG)
		{
		}

		private void FPHNOMFOHPN()
		{
		}

		private static bool ALEOFGPCIJJ(ChargePhysicalButton FGEAOFEFHIE, CHILKDJABBF GFGBFAAOLIH, PlayerHand DPFFFKMKJME)
		{
			return false;
		}

		private void BCCENLLJOJK(ChargePhysicalButton HHDMPJJAPJJ)
		{
		}

		private void GKMHECIMMCF(PhysicalButtonBase FGEAOFEFHIE, Player LLAGNEBKMCA)
		{
		}

		private void OnDestroy()
		{
		}

		[CompilerGenerated]
		private void FBOEKPPFNIK(bool HCCPLOHLPCJ)
		{
		}
	}
}
