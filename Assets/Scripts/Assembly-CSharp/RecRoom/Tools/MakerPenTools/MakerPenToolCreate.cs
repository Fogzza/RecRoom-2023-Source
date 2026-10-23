using System;
using System.Runtime.CompilerServices;
using RecRoom.Core.Creation;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public abstract class MakerPenToolCreate<T> : MakerPenTool
	{
		private sealed class GPHPFHHJFOG
		{
			public MakerPenToolCreate<T> _003C_003E4__this;

			public Vector3 position;

			public Quaternion rotation;

			public CreationContext creationContext;

			internal void _003CCreateObject_003Eb__0()
			{
			}

			internal void _003CCreateObject_003Eb__1(string error)
			{
			}

			internal void _003CCreateObject_003Eb__2()
			{
			}
		}

		protected const float DEFORMABLE_RADIUS = 0.02f;

		private const float SNAP_SMOOTH_TIME = 0.03f;

		private const float SNAP_ROTATION_LERP_VAL = 0.4f;

		protected LAHBDKNMNHN activeCreationRequest;

		private bool creationAssetDirty;

		private bool waitForTriggerRelease;

		private bool forceDragStateToContinue;

		private FBEHJNCKJPN toolModeToSwitchTo;

		private Vector3 previewPos;

		private Vector3 previewPosVel;

		private Quaternion previewRot;

		private readonly KFFPADCMOAJ rotatedBoundsCollision;

		protected virtual bool IsCreateInputPressed => false;

		protected bool TriggerReadyForCreate => false;

		protected NENLBKDEKAE CreationAsset { get; private set; }

		protected GJEAOEFGMJC ActiveDragState { get; set; }

		public override Sprite HudSprite => null;

		protected abstract NENLBKDEKAE INEHLHCFPPG();

		protected void PNNKAILNMFL()
		{
		}

		public void APKFGAPMIEG(FBEHJNCKJPN CIMCLAFMGFE)
		{
		}

		public void HCBMJBFIMBN(FBEHJNCKJPN CIMCLAFMGFE)
		{
		}

		public void NEDFGKNAJNE(bool COPOILGLIAJ)
		{
		}

		private void NAHLJBEMCCD()
		{
		}

		protected virtual bool CCGLPNCJJMM(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
		{
			return false;
		}

		public override void BJDNGFKFKPK(JPAACPJFONC FFGKGJBJJIB, HHNPLBOFAGE HHOMFBOLLIJ)
		{
		}

		public override void EHMICKMBCPH()
		{
		}

		public override void KENBMBNOMKI(JPAACPJFONC FFGKGJBJJIB)
		{
		}

		private void GNMGBJEDKKF(bool FNJHIAIPLHJ)
		{
		}

		protected virtual void KJIPFGNEEBJ()
		{
		}

		private void AJOHIDOHDPP()
		{
		}

		private void MKEDOBIOHGI()
		{
		}

		protected virtual void AHJKOOJHKHM(out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH)
		{
			INLGLHIPOMC = default;
			HEGBBJCMANH = default;
		}

		protected void NKFFBEJKCKO(out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH)
		{
			INLGLHIPOMC = default;
			HEGBBJCMANH = default;
		}

		protected Vector3 JDBEGKDPEJF(Quaternion EIKMPMAOMIA)
		{
			return default;
		}

		protected virtual float PHIOEGBFLGO()
		{
			return 0f;
		}

		protected Quaternion LBAOOPPJPFC(bool INHMCEGELDJ = true)
		{
			return default;
		}

		protected virtual Quaternion LIMALKKILOO(Quaternion EIKMPMAOMIA)
		{
			return default;
		}

		protected virtual Quaternion MIFENKGGKNF(Quaternion EIKMPMAOMIA)
		{
			return default;
		}

		[CompilerGenerated]
		private bool BEHCLHCJFPE(Collider ICJEAFIANIA)
		{
			return false;
		}
	}
}
