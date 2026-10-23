using System;
using RecRoom.Inputs;
using UnityEngine;

namespace RecRoom
{
	[Serializable]
	public class VRTitleScreenController : PlayerController
	{
		[SerializeField]
		private FakePlayerHand leftHandPrefab;

		[SerializeField]
		private FakePlayerHand rightHandPrefab;

		[SerializeField]
		private float maxPushButtonInteractionDistance;

		private FakePlayerHand leftHand;

		private FakePlayerHand rightHand;

		private VRInputHandler leftHandInput;

		private VRInputHandler rightHandInput;

		private bool isActive;

		public VRInputHandler LeftHandInput => null;

		public VRInputHandler RightHandInput => null;

		private static VRTitleScreenController ActiveInstance { get; set; }

		public override bool HasInputThisFrame => false;

		public override void IHEKMEOIBOI(LocalPlayerController HOIIBHDNAJI)
		{
		}

		public override void FCCAJFNJBLH()
		{
		}

		public override void LIDHELJBOFC()
		{
		}

		public override void HAFMJAPFCGD()
		{
		}

		public override void GIHKGIMINNE()
		{
		}

		public override void AKFBGKGEGGF()
		{
		}

		public override void HADBNNANGFK()
		{
		}

		public override void NMJKIJBBDKO(Player MHCOBIPKGNI)
		{
		}

		public override void JMHMIEACMHH(LoginScreenSpawnPoint FPDAFHFAEIC)
		{
		}

		public override Player JPAGHPDCEFL(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
		{
			return null;
		}

		private void NOPKIKHBCKM()
		{
		}

		private void NIKAJCCJFHO()
		{
		}

		private void LADOAPFFEBF(VRInputHandler KAEDAICECGN)
		{
		}

		private void JHBJNDBPJNL(VRInputHandler KAEDAICECGN)
		{
		}

		private void HLKEKIFDEKC(LoginScreenSpawnPoint FPDAFHFAEIC)
		{
		}

		public static FakePlayerHand FGNPMIIGBIN(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
			return null;
		}

		private void JAJGKBEPEEK()
		{
		}

		private void NAKEDJELIMB(int GCIGKHLKGGE, FakePlayerHand PMNLJGLDMJN, VRInputHandler KAEDAICECGN)
		{
		}
	}
}
