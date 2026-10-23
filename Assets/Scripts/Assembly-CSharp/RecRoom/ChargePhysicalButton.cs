using System.Collections.Generic;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom
{
	[DisallowMultipleComponent]
	public class ChargePhysicalButton : PhysicalButtonBase
	{
		public delegate void KFNEEOFKMON(ChargePhysicalButton HHDMPJJAPJJ);

		private enum KDHNLOHEPBC
		{
			Emissive = 0,
			EmissiveAndAlbedo = 1
		}

		public delegate bool MJGEMOBPPBI(ChargePhysicalButton FGEAOFEFHIE, CHILKDJABBF GFGBFAAOLIH, PlayerHand DPFFFKMKJME);

		private enum OCONPPLKCGH
		{
			DEACTIVATED = 0,
			ACTIVATED = 1
		}

		private enum IEJIOCOJDJD
		{
			UNPRESSED = 0,
			CHARGING = 1,
			DISCHARGING = 2,
			CHARGED = 3
		}

		private KFNEEOFKMON DKJDFBEOCHJ__BackingField;

		[SerializeField]
		private Transform unpressedTransform;

		[SerializeField]
		private Transform pressedTransform;

		[SerializeField]
		private Interpolator interpolator;

		[SerializeField]
		private bool canOnlyPushLocally;

		[SerializeField]
		private Renderer[] buttonRenderers;

		[SerializeField]
		private TextMesh buttonLabelTextMesh;

		[SerializeField]
		private Renderer buttonLabelTextRenderer;

		[SerializeField]
		private TextMesh labelTextMesh;

		[SerializeField]
		private KDHNLOHEPBC buttonColorType;

		[SerializeField]
		private Color defaultActivatedButtonColor;

		[SerializeField]
		private Color defaultActivatedButtonLabelTextColor;

		[SerializeField]
		private Color deactivatedButtonColor;

		[SerializeField]
		private Color deactivatedButtonLabelTextColor;

		[SerializeField]
		private bool hideChargeDisplayWhenDeactivated;

		[SerializeField]
		private bool hideChargeDisplayWhenUnpressed;

		[SerializeField]
		private Transform progressRoot;

		[SerializeField]
		private Transform fill;

		[SerializeField]
		private float defaultChargeDuration;

		[SerializeField]
		private float defaultDischargeDuration;

		[SerializeField]
		private float vibrationIntensity;

		[SerializeField]
		private RecRoomAudioClip chargeAudio;

		[SerializeField]
		private RecRoomAudioClip dischargeAudio;

		[SerializeField]
		private RecRoomAudioClip successAudio;

		private static readonly int HEKGONPDMOB;

		private static readonly int MPIMKEPDFMB;

		private static readonly int DFAADHNBELD;

		private readonly MDEJADHJOEJ BGBIFFLGANM;

		private CHILKDJABBF DOIFOLOLMMC;

		private PlayerHand NJKLPCDKFJG;

		private SFXAudioSource JLHBHKCNIIP;

		private SFXAudioSource MPOABKABMJJ;

		private float CMJEEHLJGLD;

		private RectTransform HLCNFOFOBPJ;

		private readonly List<MJGEMOBPPBI> IAIGHKEPLOJ;

		private float? BDNLCOIPBGL;

		private float? BOPFPDBNFEK;

		private Color? NEKPDHKEMBD;

		private Color? AFPPJINKGJE;

		private Color? MEMKLADGPGA;

		private float CCBKHGNINCF;

		private KLCFHMGAPPO HHOEMJCPBKI;

public float ChargeDuration
{
get 		{
			return 0f;
		}

set {
		}
}

public float DischargeDuration
{
get 		{
			return 0f;
		}

set {
		}
}

public Color ButtonColor
{
get 		{
			return default;
		}

set {
		}
}

public Color DeactivatedButtonColor
{
get 		{
			return default;
		}

set {
		}
}

public Color ButtonTextColor
{
get 		{
			return default;
		}

set {
		}
}

public float EmissivePower
{
get 		{
			return 0f;
		}

set {
		}
}

public string ButtonLabelText
{
set {
		}
}

public string LabelText
{
set {
		}
}

public bool Activated
{
get 		{
			return false;
		}

set {
		}
}

public float ChargeAmount
{
get 		{
			return 0f;
		}

set {
		}
}

public bool IsPressing
{
get 		{
			return false;
		}

}

private float ONEEGNKHMHP
{
set {
		}
}

public RecRoomAudioClip SuccessAudio
{
get 		{
			return null;
		}

set {
		}
}

public KLCFHMGAPPO InteractionFilter
{
get 		{
			return null;
		}

set {
		}
}

public event KFNEEOFKMON ChargedEvent {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		private void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnTriggerEnter(Collider ADMCDJKKCIA)
		{
		}

		public override bool IsButtonEnabledForPlayer(CHILKDJABBF FBCDJHOIDJJ)
		{
			return false;
		}

		public override bool PlayerPushedButton(CHILKDJABBF LLAGNEBKMCA)
		{
			return false;
		}

		public override bool PlayerReleasedButton(CHILKDJABBF LLAGNEBKMCA)
		{
			return false;
		}

		private void Update()
		{
		}

		private void MNKHGBOHGJL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void CKKPKLALKMO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void EDHCFDJHGOC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void BFDGHIPGDDD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void DJIMDCAJGNG()
		{
		}

		private void PPPEKKBOHGF(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void PEGGCNLJGNJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void FOCMDCAFIBO()
		{
		}

		private void EIKEKMEPBKD(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void NIGMLEBMKFN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void DNJAHICLBCI()
		{
		}

		private void OCBFMMEBCDN()
		{
		}

		private void JOEGIAMHMEM()
		{
		}

		private void EJILONGJFGK()
		{
		}

		private void FMFNFGINLAF()
		{
		}

		private void HPFFAOBFGNO()
		{
		}

		private void LNDMBBPOIGD(Material PMPDPBDKGPF, Color HMCAFGCGFJF)
		{
		}

		private void BCAKILJAEBC()
		{
		}

		public void AddCustomChargeCondition(MJGEMOBPPBI NHJPBHJLFOD)
		{
		}

		public void RemoveCustomChargeCondition(MJGEMOBPPBI NHJPBHJLFOD)
		{
		}

		private bool KGMIGGBHIOM(CHILKDJABBF EKOFNPFCLMO, PlayerHand BJBDPCNDCLN)
		{
			return false;
		}
	}
}
