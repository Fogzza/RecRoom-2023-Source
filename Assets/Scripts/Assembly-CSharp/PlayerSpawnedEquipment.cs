using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerSpawnedEquipment : MonoBehaviourPun, DJLCHGFCFAD, GCLGKPAJPCP
{
	public delegate bool KPCKEKCNKCL();

	public enum NHMNGDFJFCC
	{
		None = 0,
		Backpack = 1,
		GiftBox = 2,
		Drawer = 3,
		Streaming = 4,
		ClothingCustomizerDrawingTool = 5
	}

	private const float JEJEJGNNEKK = 0.075f;

	private const float PJNOLBDCJMK = 3f;

	private const float GFAHENFJGNM = 15f;

	private const float IPCFBPBFOEC = 9f;

	private const float DLEOJJMHKAH = 225f;

	public KPCKEKCNKCL CustomShouldUseLongerDistanceForBackpackCleanup;

	public bool IgnoreDistanceForBackpackCleanupBehavior;

	public static List<PlayerSpawnedEquipment> All;

	private Action<PlayerSpawnedEquipment> LCINCDOKIEG__BackingField;

	private readonly EEANDDJEMJC NIBKHEKMJBK;

	private readonly EEANDDJEMJC KECKFEPNCDD;

	private readonly EEANDDJEMJC AHBPMNLNHDF;

	private bool ACCDAPEBJBO;

	private NHMNGDFJFCC FEPMIBCPBAB;

	private int NEPBMOFPHNB;

	private Player DDCAMLMJDLK;

	private ToolCleanup HAEOBPAFLHN;

	private bool IIDPJMIBHCG;

	private Tool GAPEICCMANI;

	private BHNJIBDJFAL NJPJBDDAEFH;

	private const int MKAGFIPBNBO = 1;

	private const int GMAEILOKCNH = 0;

	private Action<PlayerSpawnedEquipment, bool> MDNOPAHCMDD__BackingField;

	private bool OMAOAFPJILM;

	private bool KAEDDHNFMEB;

	private FIHGBEHGLGB EOHACHPNOKC;

	private OutfitToolUIControl FJIKNHBAJOB;

public EEANDDJEMJC OnDestroyed
{
get 	{
		return null;
	}

}

public EEANDDJEMJC OnEnabled
{
get 	{
		return null;
	}

}

public EEANDDJEMJC OnDisabled
{
get 	{
		return null;
	}

}

public bool IsActiveAndEnabled
{
get 	{
		return false;
	}

}

public new bool IsDestroyed
{
get 	{
		return false;
	}

private set {
	}
}

public NHMNGDFJFCC ToolPurpose
{
get 	{
		return NHMNGDFJFCC.None;
	}

set {
	}
}

public int SpawningPlayerId
{
get 	{
		return 0;
	}

private set {
	}
}

public Player SpawningPlayer
{
get 	{
		return null;
	}

private set {
	}
}

public bool IsMine
{
get 	{
		return false;
	}

private set {
	}
}

public Tool Tool
{
get 	{
		return null;
	}

private set {
	}
}

public string IS_NEW_PROPERTY
{
get 	{
		return null;
	}

}

public bool IsNew
{
get 	{
		return false;
	}

set {
	}
}

public bool IsPlatformLocked
{
get 	{
		return false;
	}

set {
	}
}

public bool IsFavorite
{
get 	{
		return false;
	}

set {
	}
}

public bool IsToolUIControlEnabled
{
get 	{
		return false;
	}

}

public OutfitToolUIControl ToolUIControl
{
get 	{
		return null;
	}

private set {
	}
}

 bool global::DJLCHGFCFAD.BlockObjectPersistance
{
get 	{
		return false;
	}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 	{
		return GKDCHLMLHBJ.RunForAuthorityOnly;
	}

}

public event Action<PlayerSpawnedEquipment> PickupAttemptEvent {
add {
	}
remove {
	}
}

public event Action<PlayerSpawnedEquipment, bool> OnIsNewChanged {
add {
	}
remove {
	}
}

	protected override void Awake()
	{
	}

	public void SetSpawningPlayer(Tool IEGMBEPJMGC, int NFOBMBJFHBJ, NHMNGDFJFCC LODOMOIPMIL)
	{
	}

	private void Start()
	{
	}

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void PDEONDIBLCO()
	{
	}

	private bool BMCFGMFALKG(Tool PMEFICGEDFK, Killzone FOOPALEAEGM)
	{
		return false;
	}

	private bool AEGFHJGBOII(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
	{
		return false;
	}

	public bool TryPickupSpawnedEquipment(Player EKOFNPFCLMO)
	{
		return false;
	}

	private void KNALNPOIOPN(Tool IEGMBEPJMGC)
	{
	}

	private void PLLGKABPABI(Tool FFDKLDFJBMF, Vector3 PFEPDCACLHL, Quaternion HOKBOKENLKE, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
	{
	}

	public void SetToolUIControlEnabled(bool IPMIIEAGJKC, object IALNODEHBNN)
	{
	}

	private void JHIEDKKODNM(CHILKDJABBF FBCDJHOIDJJ, string PEGANFDBJPA)
	{
	}

	private void KBJDBGPDPBF(string PEGANFDBJPA)
	{
	}

	private void GPHBJAPKPJL(int OFMKJBIBDCL)
	{
	}

	private void GPHBJAPKPJL(bool JBNIOBBJDJI = false)
	{
	}

	private void JCFCLJLLBFB(NLOGDCDGECD FFILBGADKKN)
	{
	}

	void DJLCHGFCFAD.DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
	{
		//ILSpy generated this explicit interface implementation from .override directive in JCFCLJLLBFB
		this.JCFCLJLLBFB(FFILBGADKKN);
	}

	private void NPJBEOAIFFL(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
	{
	}

	void DJLCHGFCFAD.SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
	{
		//ILSpy generated this explicit interface implementation from .override directive in NPJBEOAIFFL
		this.NPJBEOAIFFL(ref FCJBDJOMIHI, ref JIEECFLEPDI, AAMCGPPJPFM);
	}

	[CompilerGenerated]
	private void MDKCKCIAEMP(float GADDGJANIGG)
	{
	}
}
