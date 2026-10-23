using System;
using RecRoom;
using RecRoom.Core.Screens.PlayerController;
using RecRoom.Players.Puppet;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class AnimatedPlayerPuppetAvatarModelController : ModelController<AnimatedPlayerPuppetAvatarModel>
	{
		[Serializable]
		private class PlayAnimationButtonImpl : ButtonControllerImpl<AnimatedPlayerPuppetAvatarModel>
		{
			[SerializeField]
			private PlayerAnimation animation;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AnimatedPlayerPuppetToRenderTextureModelImpl : ControllerImplementation<AnimatedPlayerPuppetAvatarModel>
		{
			[SerializeField]
			private AnimatedPlayerPuppetRenderTextureModel renderTextureModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AvatarCustomizationAnimationsImpl : ControllerImplementation<AnimatedPlayerPuppetAvatarModel>
		{
			[SerializeField]
			private AvatarCustomizationAnimationContent animationContent;

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void PNNLFADLAOK()
			{
			}

			private void HNHKCKLFGLP()
			{
			}

			private void GHDLNHIEBPP()
			{
			}

			private void CJGIPOGLGCO()
			{
			}

			private void GMFMCBHCMOI(PlayerAnimationAsset[] JAAGBDPDCIE)
			{
			}
		}

		[Serializable]
		private class PlayAnimationWhileEnabledImpl : ControllerImplementation<AnimatedPlayerPuppetAvatarModel>
		{
			[SerializeField]
			private bool playOnEnable;

			[SerializeField]
			private bool playOnDisable;

			[SerializeField]
			private bool stopOnDisable;

			[SerializeField]
			private bool loop;

			[SerializeField]
			private PlayerAnimationAsset[] animations;

			private AnimatedPlayerPuppet cachedPuppet;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			private void GKIGOJFAJEA()
			{
			}
		}

		[Serializable]
		private class PlayAnimationWhileInputFieldFocusedImpl : ControllerImplementation<AnimatedPlayerPuppetAvatarModel>
		{
			[SerializeField]
			private PlayerAnimationAsset[] animations;

			[SerializeField]
			private TMP_InputField inputField;

			[SerializeField]
			private float loopingAnimationFadeTime;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			private void JKMEKLPNHEE(string HLIGBKANEEA)
			{
			}

			private void IKNKHDNPLMH(string HLIGBKANEEA)
			{
			}
		}
	}
}
