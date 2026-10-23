using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RecRoom.Inputs
{
	public abstract class VRInputHandler
	{
		[Serializable]
		public class InputSprites
		{
			public Sprite WalkSprite;

			public Sprite TeleportSprite;

			public Sprite RotateLeftSprite;

			public Sprite RotateRightSprite;

			public Sprite DropSprite;

			public Sprite WatchMenuSprite;

			public Sprite OpenProfileSprite;

			public Sprite TriggerSprite;
		}

		public struct HGLAMAFCPPN
		{
			public GAEDOFGKFJA JDKBKAOCLIH;

			public GAEDOFGKFJA BJGGOPHAEKM;

			public GAEDOFGKFJA OMOPODDPDAI;

			public GAEDOFGKFJA MFAJNDBDJNH;

			public GAEDOFGKFJA DHIEACPLFLL;

			public Vector2 LDILLEJLMDF;

			public Vector2 ENCENFEPFDF;

			public Vector2 GOHAPAAGMNF;

			public Vector2 DBPKCHOPLIC;

			public Vector2 PCFLGLLIBAA;

			public Vector2 DMMBNHJINFL;

			public DLLIMLHNBON BDFHMKAOMMI;

			public DLLIMLHNBON LMJCBPALCHD;

			public DLLIMLHNBON MPJFCNACMJC;

			public DLLIMLHNBON IDOLMDHJCDP;

			public FBADPDBDBMF DFBKAOICFAP;

			public FBADPDBDBMF AGGGFEPOBBI;

			public FBADPDBDBMF HMECFPLJPEI;

			public FBADPDBDBMF GACEAPHOPFL;

			public FBADPDBDBMF LCLGPNIILDE;

			public FBADPDBDBMF FNKHAHEBHAK;

			public FBADPDBDBMF KNBLNBBDIHJ;

			public DLLIMLHNBON FAEFONEMIBB;

			public DLLIMLHNBON ACPJCFHFIPM;

			public DLLIMLHNBON GOBHDMHACHP;

			public DLLIMLHNBON KOIMMIAKACE;

			public DLLIMLHNBON DGKPGPDCFKL;

			public DLLIMLHNBON PGHNKOOGLPA;

			public DLLIMLHNBON KKBPMPPDABE;

			public DLLIMLHNBON OEBODABOJFB;

			public DLLIMLHNBON ENJAJCADBFD;

			public DLLIMLHNBON OHENDFMFACO;

			public DLLIMLHNBON FIEKIKKMAMD;

			public DLLIMLHNBON FCHBEPLLEAF;

			public DLLIMLHNBON MOMPJCOHKDN;

			public DLLIMLHNBON OGJHBMLLEDA;

			public Vector2 MKMADMOMLJG;

			public float AHIIEJOHFKE;

			public DLLIMLHNBON HHAFFOIHFPJ;
		}

		public enum JCFFMMKDGOA
		{
			None = 0,
			Walk = 1,
			Rotate = 2,
			GripRotate = 3,
			Scroll = 4,
			DedicatedMenuButton = 5,
			DedicatedMenuButtonShort = 6,
			OpenProfile = 7,
			QuickAccept = 8,
			SecondaryMenuButton = 9,
			SecondaryOpenProfile = 10,
			SecondaryQuickAccept = 11,
			MakerPenVRShortcuts = 12,
			COUNT = 13
		}

		protected struct LOOKDFCMGHD
		{
			public readonly int LDHIBGALEDK;

			public readonly AMBAFLLOFEA CCCBNEPNAAE;

			public LOOKDFCMGHD(int LAGADKBKLAD, AMBAFLLOFEA EBBNMKKOLJD)
			{
				LDHIBGALEDK = 0;
				CCCBNEPNAAE = AMBAFLLOFEA.Empty;
			}
		}

		private class NHJPNBDOMLE : VRInputHandler
		{
			protected override void OPMEDJKHIDF(ref HGLAMAFCPPN DADHJJNJEFA)
			{
			}

			public override bool MJKJHKJGCJM(JCFFMMKDGOA POINFDHCNCM)
			{
				return false;
			}
		}

		public delegate void FGMEDAHFLMC(VRInputHandler JLFMCCADIKH);

		private sealed class KOBEJMEJNCG : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public int milliseconds;

			public VRInputHandler _003C_003E4__this;

			public float intensity;

			public bool useTouchpad;

			private float _003CendTime_003E5__2;

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
			public KOBEJMEJNCG(int _003C_003E1__state)
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
		private Vector3 offsetPosition;

		[SerializeField]
		private Vector3 offsetRotation;

		[SerializeField]
		private float generalHapticIntensityModifier;

		[SerializeField]
		protected float AutoSprintWalkAxisDeadZone;

		[SerializeField]
		protected float AutoSprintWalkAxisMaxWalkSpeedZone;

		[SerializeField]
		protected InputSprites sprites;

		protected Transform rawTrackerTransform;

		private Transform offsetTrackerTransform;

		protected ControlSettings controlSettings;

		protected HOCAKIFHDHC autoSprintButton;

		protected readonly Dictionary<object, LOOKDFCMGHD>[] inputConsumerMaps;

		[CompilerGenerated]
		private FGMEDAHFLMC TransformUpdateEvent;

		private VRTrackedController.EGONEFPMCNI HandType;

		private bool IsConnected;

		private bool IsTracking;

		private float TimeLastUserActivity;

		private Vector3 previousRawLocalPosePosition;

		private Quaternion previousRawLocalPoseRotation;

		private float previousPoseTime;

		public const float MaxLinearVelocityMagnitude = 20f;

		public const float MaxAngularVelocityMagnitude = 25f;

		private Vector3 linearVelocity;

		private Vector3 angularVelocity;

		[NonSerialized]
		[HideInInspector]
		public float HandOpenCloseVelocity;

		private float LinearVelocityMultiplier;

		private float AngularVelocityMultiplier;

		private ControllerVelocitySettings.IONOMPNPLLB LinearVelocityAverageMethod;

		private ControllerVelocitySettings.IONOMPNPLLB AngularVelocityAverageMethod;

		private bool VelocityWaitForNextUpdate;

		private bool VelocityRollbackUsesFixedTimestep;

		private int DirectionRollbackStartFrame;

		private int DirectionRollbackEndFrame;

		private int MagnitudeRollbackStartFrame;

		private int MagnitudeRollbackEndFrame;

		private float HairTriggerButtonDownTime;

		private float HairTriggerButtonUpTime;

		private float HairPickupCombinedButtonDownTime;

		private float HairPickupCombinedButtonUpTime;

		private bool HairPickupCombinedButtonPressed;

		private bool hairPickupCombinedButtonDown;

		private bool hairPickupCombinedButtonUp;

		private bool HairPickupTriggerOnlyButtonDown;

		private bool HairPickupTriggerOnlyButtonPressed;

		private bool HairPickupTriggerOnlyButtonUp;

		private bool HairTriggerButtonDownConsumed;

		private bool HairTriggerButtonUpConsumed;

		private bool HairTriggerButtonPressed;

		private bool hairTriggerButtonDown;

		private bool hairTriggerButtonUp;

		protected Vector3 RCVirtualJoystickReferenceForward;

		protected Vector3 RCVirtualJoystickReferenceRight;

		protected Vector3 RCVirtualJoystickReferenceUp;

		private HGLAMAFCPPN state;

		private HOCAKIFHDHC pickupTriggerHairTrigger;

		private HOCAKIFHDHC capacitiveGripPickupHairTrigger;

		private HOCAKIFHDHC triggerHairTrigger;

public static VRInputHandler DPPJPBMGLNA
{
get 		{
			return null;
		}

}

public virtual bool SupportsAimWalkAndStickWalkSimultaneously
{
get 		{
			return false;
		}

}

public virtual bool SupportsNaturalGrip
{
get 		{
			return false;
		}

}

public virtual bool SupportsTouchpadTeleport
{
get 		{
			return false;
		}

}

public virtual bool SupportsTwoStageGrip
{
get 		{
			return false;
		}

}

public virtual bool RotateStrafeAndSelfScaleOverlap
{
get 		{
			return false;
		}

}

public virtual bool HasDedicatedMenuButton
{
get 		{
			return false;
		}

}

public virtual bool PMFOGPOGJPL
{
get 		{
			return false;
		}

}

public Vector3 CLFPLKOGNAP
{
get 		{
			return default;
		}

}

public Quaternion JDKNNNHNAMK
{
get 		{
			return default;
		}

}

public VRTrackedController.EGONEFPMCNI ENHOFIBGJJK
{
get 		{
			return VRTrackedController.EGONEFPMCNI.LeftHand;
		}

private set {
		}
}

public bool LCHGLCOLPPE
{
get 		{
			return false;
		}

set {
		}
}

public bool MGGJPLDOGMG
{
get 		{
			return false;
		}

set {
		}
}

public float INAEJPPDDDL
{
get 		{
			return 0f;
		}

set {
		}
}

protected Vector3 LNEKJIBCJLC
{
get 		{
			return default;
		}

private set {
		}
}

protected Quaternion IIEAEICOCAG
{
get 		{
			return default;
		}

private set {
		}
}

protected float CNKHLHGDGKN
{
get 		{
			return 0f;
		}

private set {
		}
}

public Vector3 JHEKFCANAOI
{
get 		{
			return default;
		}

set {
		}
}

public Vector3 EEAJIEJHCCI
{
get 		{
			return default;
		}

set {
		}
}

public float LFNFCKENDAD
{
get 		{
			return 0f;
		}

private set {
		}
}

public float AADJCMFAKLA
{
get 		{
			return 0f;
		}

private set {
		}
}

public ControllerVelocitySettings.IONOMPNPLLB DDKLLEOFGIO
{
get 		{
			return ControllerVelocitySettings.IONOMPNPLLB.AVERAGE_DIRECTION_AVERAGE_MAGNITUDE;
		}

private set {
		}
}

public ControllerVelocitySettings.IONOMPNPLLB NMMBMLKJBEC
{
get 		{
			return ControllerVelocitySettings.IONOMPNPLLB.AVERAGE_DIRECTION_AVERAGE_MAGNITUDE;
		}

private set {
		}
}

public bool GDIMKFLJIPD
{
get 		{
			return false;
		}

private set {
		}
}

public bool JDAGKOMDBGJ
{
get 		{
			return false;
		}

private set {
		}
}

public int IDOHNNAIOKJ
{
get 		{
			return 0;
		}

private set {
		}
}

public int MLPEICLGBID
{
get 		{
			return 0;
		}

private set {
		}
}

public int EHMCFLKMOKA
{
get 		{
			return 0;
		}

private set {
		}
}

public int CNFPNHMDCDG
{
get 		{
			return 0;
		}

private set {
		}
}

public bool JDIAMKBEHOJ
{
get 		{
			return false;
		}

}

public bool PLFNDKDEEKL
{
get 		{
			return false;
		}

}

public bool PCHODHDFJMM
{
get 		{
			return false;
		}

}

public bool KFNHLKFFJOF
{
get 		{
			return false;
		}

}

public bool BICFCBDAEJJ
{
get 		{
			return false;
		}

}

public bool BKKANHMGNKN
{
get 		{
			return false;
		}

}

public bool LIMIKOLPKGA
{
get 		{
			return false;
		}

}

public bool EOHKDNJLBOI
{
get 		{
			return false;
		}

}

public bool JBNMIGDAJJH
{
get 		{
			return false;
		}

}

public bool GKAJLBJEBNO
{
get 		{
			return false;
		}

}

public bool EKENBBHDDPO
{
get 		{
			return false;
		}

}

public bool PMEICJLFLKH
{
get 		{
			return false;
		}

}

public bool IGNKAHNHGIN
{
get 		{
			return false;
		}

}

public bool NADICGHBAGN
{
get 		{
			return false;
		}

}

public bool KEDAPIKCIAN
{
get 		{
			return false;
		}

}

public bool IBAJJJKGNLN
{
get 		{
			return false;
		}

}

public bool AEAGDCHKECB
{
get 		{
			return false;
		}

}

public bool JLGOLNHCDEJ
{
get 		{
			return false;
		}

}

public bool HHEDPDDCLMB
{
get 		{
			return false;
		}

}

public bool HINIKDPBJLO
{
get 		{
			return false;
		}

}

public bool DNECDEHJNBB
{
get 		{
			return false;
		}

}

public bool CPCCDPFAIME
{
get 		{
			return false;
		}

}

public bool PDIDMLFGBMF
{
get 		{
			return false;
		}

}

public bool ABEGPNOBLDO
{
get 		{
			return false;
		}

}

public bool CHJDKDJCLGL
{
get 		{
			return false;
		}

}

public bool CAFFJBDIDKL
{
get 		{
			return false;
		}

}

public bool MBIHLIMNLCM
{
get 		{
			return false;
		}

}

public bool AGFEKKOAKJJ
{
get 		{
			return false;
		}

}

public bool KBPHFJPDCKL
{
get 		{
			return false;
		}

}

public bool IABLLMMLLFN
{
get 		{
			return false;
		}

}

public bool MPNNKDMMBCF
{
get 		{
			return false;
		}

}

public DLLIMLHNBON FAIHKFOGOII
{
get 		{
			return default;
		}

}

public Vector2 DMMBNHJINFL
{
get 		{
			return default;
		}

}

public bool PNPGFDFMCNO
{
get 		{
			return false;
		}

}

public Vector2 GOHAPAAGMNF
{
get 		{
			return default;
		}

}

public Vector2 DBPKCHOPLIC
{
get 		{
			return default;
		}

}

public Vector2 PCFLGLLIBAA
{
get 		{
			return default;
		}

}

public bool IJEJEJDLOFF
{
get 		{
			return false;
		}

}

public bool MBJFPMPLGBB
{
get 		{
			return false;
		}

}

public bool BJGJNDEFLIG
{
get 		{
			return false;
		}

}

public bool JMPEFAGODEB
{
get 		{
			return false;
		}

}

public bool GEDEEAMHAOE
{
get 		{
			return false;
		}

}

public bool EJJANOKLGNA
{
get 		{
			return false;
		}

}

public bool NNCGOBJMHMO
{
get 		{
			return false;
		}

}

public bool DGCCHKMINCA
{
get 		{
			return false;
		}

}

public bool CDFCCMODELP
{
get 		{
			return false;
		}

}

public bool FLABIDIHEBB
{
get 		{
			return false;
		}

}

public bool JLOKDOJBEFJ
{
get 		{
			return false;
		}

}

public bool EOLNGPGKGAI
{
get 		{
			return false;
		}

}

public bool EGNMPNFPPHE
{
get 		{
			return false;
		}

}

public bool PKMPJMEEOKK
{
get 		{
			return false;
		}

}

public bool EPIAIBIJPIH
{
get 		{
			return false;
		}

}

public bool PCOKGOGDPOJ
{
get 		{
			return false;
		}

}

public float JDKBKAOCLIH
{
get 		{
			return 0f;
		}

}

public float BJGGOPHAEKM
{
get 		{
			return 0f;
		}

}

public float OMOPODDPDAI
{
get 		{
			return 0f;
		}

}

public float DHIEACPLFLL
{
get 		{
			return 0f;
		}

}

public float ENCENFEPFDF
{
get 		{
			return 0f;
		}

}

public bool FDIGEBFHHIF
{
get 		{
			return false;
		}

}

public bool CJADLBLCBHD
{
get 		{
			return false;
		}

}

public bool AGFDHPNEBJH
{
get 		{
			return false;
		}

}

public Vector2 LDILLEJLMDF
{
get 		{
			return default;
		}

}

public float MFAJNDBDJNH
{
get 		{
			return 0f;
		}

}

public bool NKEAOHNDMNF
{
get 		{
			return false;
		}

}

public bool LKGNCDBCOHM
{
get 		{
			return false;
		}

}

public bool IHAEIJPIOJP
{
get 		{
			return false;
		}

}

public float BECLOOMJMJG
{
get 		{
			return 0f;
		}

private set {
		}
}

public float BFJOMNIBAIM
{
get 		{
			return 0f;
		}

private set {
		}
}

public bool JEAJDJMMNEO
{
get 		{
			return false;
		}

}

public bool GOEKIAMAODA
{
get 		{
			return false;
		}

}

public bool HFFNHIJEGIJ
{
get 		{
			return false;
		}

}

public float IIPLCHPDGIG
{
get 		{
			return 0f;
		}

private set {
		}
}

public float JFBBNPEOCCH
{
get 		{
			return 0f;
		}

private set {
		}
}

public bool MNNDECNJNII
{
get 		{
			return false;
		}

private set {
		}
}

public bool PBKCEBCKEAF
{
get 		{
			return false;
		}

private set {
		}
}

public bool GMCHCEABOBL
{
get 		{
			return false;
		}

private set {
		}
}

public bool HEHEFEFINNK
{
get 		{
			return false;
		}

private set {
		}
}

public bool JFFJGHHDIJI
{
get 		{
			return false;
		}

private set {
		}
}

public bool BBAJBCGOCNM
{
get 		{
			return false;
		}

private set {
		}
}

public bool ODAOOGBLJAM
{
get 		{
			return false;
		}

set {
		}
}

public bool JHCIBGFCMAG
{
get 		{
			return false;
		}

set {
		}
}

public bool PJCBFDGJBEE
{
get 		{
			return false;
		}

private set {
		}
}

public bool FCANMCIMHPO
{
get 		{
			return false;
		}

private set {
		}
}

public bool HFECCGFIHHF
{
get 		{
			return false;
		}

private set {
		}
}

public DLLIMLHNBON CMJJOHEMNOP
{
get 		{
			return default;
		}

}

public float OPILABMLPKJ
{
get 		{
			return 0f;
		}

}

public Sprite CMMHOIGFMMN
{
get 		{
			return null;
		}

}

public Sprite FGLNFALKBMH
{
get 		{
			return null;
		}

}

public Sprite NPFEDNNPKPO
{
get 		{
			return null;
		}

}

public Sprite NJMDMNHKBHI
{
get 		{
			return null;
		}

}

public Sprite ANHGHLNPFPP
{
get 		{
			return null;
		}

}

public Sprite APEJBNEGFOE
{
get 		{
			return null;
		}

}

public Sprite AMODDMKPHFC
{
get 		{
			return null;
		}

}

public Sprite GLFCNJJAGDO
{
get 		{
			return null;
		}

}

public event FGMEDAHFLMC PIPBAPAOMNE {
add {
		}
remove {
		}
}

		public virtual void IHEKMEOIBOI(VRTrackedController.EGONEFPMCNI BNNHCJJILFB, VRTrackedController NHCFAMHGLAF, ControlSettings KBBHGALIPPI)
		{
		}

		public virtual void PPOCOGLBGFD()
		{
		}

		public virtual void HFCGCFAAAJP()
		{
		}

		protected virtual void PGLAHOCNCON(float DOEJGDJILAD, bool HIFDJFBEADN)
		{
		}

		protected virtual void LODEKFHNLFA(ref HGLAMAFCPPN HDOIGFKCPJG, ref HGLAMAFCPPN MMHIPBNEOHJ)
		{
		}

		protected abstract void OPMEDJKHIDF(ref HGLAMAFCPPN DADHJJNJEFA);

		public void CPCJOHCLPAL(JCFFMMKDGOA POINFDHCNCM, int LAGADKBKLAD, object IALNODEHBNN, AMBAFLLOFEA EBBNMKKOLJD = AMBAFLLOFEA.All)
		{
		}

		public void NKLBLBLNCBM(JCFFMMKDGOA POINFDHCNCM, object IALNODEHBNN)
		{
		}

		public abstract bool MJKJHKJGCJM(JCFFMMKDGOA POINFDHCNCM);

		public void BABCIGBAFPD()
		{
		}

		public void KOPGENHPDNF(VRInputHandler PCLOPKHDPLJ)
		{
		}

		public void LAFLPLEKLPK(ControllerVelocitySettings CAOIPCMMNMJ)
		{
		}

		public void AOCODEEPGKP(int HIJKHPMDNMK = 1, float DOEJGDJILAD = 1f)
		{
		}

		public void NCIDFFJKJCJ(int HIJKHPMDNMK = 1, float DOEJGDJILAD = 1f)
		{
		}

		public static bool DNDLMFEOEBE(VRInputHandler PGGPDMLNFLP, VRInputHandler FKGDJKOLCNN, ControllerWingspanSettings IOBLGJPOGOF, out Vector3 GHBLBGFLEBE)
		{
			GHBLBGFLEBE = default;
			return false;
		}

		protected void LHBMAMPMBAL()
		{
		}

		private void JJOFOCINAAE()
		{
		}

		protected virtual IEnumerator LJLEIHBODCE(int HIJKHPMDNMK, float DOEJGDJILAD, bool HIFDJFBEADN = false)
		{
			return null;
		}

		protected void PGOPOLOBKDD(Vector2 IEEEIKPPHEB, out Vector2 EJKPMNKCOCP, out DLLIMLHNBON EBPMAIJJBLG)
		{
			EJKPMNKCOCP = default;
			EBPMAIJJBLG = default;
		}
	}
}
