using System;
using RecRoom.Core.Imposters;
using RecRoom.Players.Puppet;
using RecRoom.Utils.Image;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace RRUI.Data
{
	public class AnimatedPlayerPuppetRenderTextureModel : RRUIModel
	{
		public enum PuppetRenderConfigPriority
		{
			Default = 0,
			Flow = 10,
			CategoryFaceShape = 20,
			CategoryEyes = 21,
			CategoryMouths = 22,
			CategoryEars = 23,
			CategoryFacialHair = 24,
			CategoryGloves = 25,
			CategoryHair = 26,
			CategoryHeadGear = 27,
			PlayerHeight = 30,
			AdjustBeard = 34,
			AdjustEye = 35,
			AdjustHair = 36,
			AdjustHat = 37,
			AdjustMouth = 38,
			Complete = 40
		}

		private sealed class IBFNPPFOBIM
		{
			public AnimatedPlayerPuppetRenderTextureModel _003C_003E4__this;

			public Vector3 cameraPosition;

			public Quaternion cameraRotation;

			internal void _003CSaveSnapshotToProfilePhoto_003Eb__0()
			{
			}
		}

		[SerializeField]
		private ImposterRawImage.PJPAIKKGOPM size;

		[SerializeField]
		private int customSize;

		[SerializeField]
		private ImposterRenderConfig defaultImposterRenderConfig;

		[SerializeField]
		private float dynamicOffsetSmoothTime;

		[SerializeField]
		private bool applyInputYawToPuppet;

		[SerializeField]
		private ImposterRenderConfig snapshotRenderConfig;

		[SerializeField]
		private Texture2D snapshotBackgroundTexture;

		[SerializeField]
		private Material alphaBlitMaterial;

		private readonly ManagedTexture CLDHIMMHEGO;

		private RenderTexture OBPEAPBCCMM;

		private RenderTexture PGIEJDPEJLB;

		private IDisposable OBECBJCGHMB;

		private Camera MJGOLNMBJHA;

		private float JJKFKPMHBPH;

		private CNHEOBEGMKA PJPEPDOKOLF;

		private CNHEOBEGMKA LFCKHOHDIMD;

		private CGOBNNIEKLB HLAMPFHJOMF;

		private float JIMHMMPDBED;

		private float OFHFEOGCLPD;

		private readonly global::AFHOAHNAMGF<ImposterRenderConfig> ANOIDIJJHJJ;

		private readonly FIHGBEHGLGB BNBKBGNJKNP;

		private AnimatedPlayerPuppet FELEKMLMGMN;

		private RenderTexture NKOFODONEAH;

		private ImposterRenderConfig LHAJHALCJFD;

		private IRecRoomQualityConfigProvider DABJFKPDEIL;

		private float DKLIMFMEFIE;

public bool CanApplyUserInput
{
get 		{
			return false;
		}

}

public AnimatedPlayerPuppet Puppet
{
get 		{
			return null;
		}

set {
		}
}

public RenderTexture RenderTexture
{
get 		{
			return null;
		}

}

private int BFEBIJAHDHI
{
get 		{
			return 0;
		}

}

public ImposterRenderConfig HighestPriorityRenderConfig
{
get 		{
			return null;
		}

}

public ImposterRenderConfig OverrideRenderConfig
{
get 		{
			return null;
		}

set {
		}
}

public ImposterRenderConfig ActiveRenderConfig
{
get 		{
			return null;
		}

}

private int JNLNONJHEAC
{
get 		{
			return 0;
		}

}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

		protected override void DHHOMFCCFKP()
		{
		}

		private void KDELGLNBFAF(GHCCKFEJDOA ICHBECDKHOJ)
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		private void JEHJOLANBFH()
		{
		}

		private void ODKGCFEJOCF()
		{
		}

		public void AddRenderConfig(object IALNODEHBNN, ImposterRenderConfig FPJKGKBOAOA, int LAGADKBKLAD)
		{
		}

		public void RemoveRenderConfig(object IALNODEHBNN)
		{
		}

		public void AddApplyInputRotation(object IALNODEHBNN)
		{
		}

		public void RemoveApplyInputRotation(object IALNODEHBNN)
		{
		}

		public void AddCameraDeltaRotationDegrees(float HKFAOEEHOPH, float CENEPBPAKML)
		{
		}

		public void ResetInputAngles()
		{
		}

		public void SaveSnapshotToProfilePhoto()
		{
		}

		private void EFMCJLONAJD(float OKBAJEAPIHG)
		{
		}

		private void BFDIIDHKEKC(Quaternion ENAFKCFECPO, Vector3 DBGNCAACKOB, Quaternion LHNKPBJILBF, float NLIFLBODAJM, ImposterRenderConfig LOJBGHMAJBF, RenderTexture KAACGMLIKHK)
		{
		}

		private static void IGKAINPJGEH(Vector3 ELFBHMFHAKC, Vector3 CDIGAFNJHFG, Vector3 HDNDMKDFOFD, out Vector3 DBGNCAACKOB, out Quaternion LHNKPBJILBF)
		{
			DBGNCAACKOB = default;
			LHNKPBJILBF = default;
		}
	}
}
