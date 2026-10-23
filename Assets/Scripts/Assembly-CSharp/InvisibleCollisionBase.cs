using System.Text;
using Photon.Pun;
using UnityEngine;

public abstract class InvisibleCollisionBase : MonoBehaviourPun, DJLCHGFCFAD
{
	private enum IMFJFIGOIDI
	{
		Enabled = 0,
		Disabled = 1
	}

	[SerializeField]
	protected Tool tool;

	[SerializeField]
	private BoxCollider mainCollider;

	[SerializeField]
	private Renderer[] volumeRenderers;

	[SerializeField]
	private Material enabledMaterial;

	[SerializeField]
	private Material disabledMaterial;

	[SerializeField]
	protected int settingsPriority;

	protected LocomotionSettings CIEEFNAILGB;

public virtual bool CollisionDisabled
{
get 	{
		return false;
	}

}

public virtual bool CollideWithPlayers
{
get 	{
		return false;
	}

}

public virtual bool CollideWithObjects
{
get 	{
		return false;
	}

}

public virtual bool CollideWithProjectiles
{
get 	{
		return false;
	}

}

public virtual bool OccludesTargeting
{
get 	{
		return false;
	}

}

public bool BlockObjectPersistance
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

	protected override void Awake()
	{
	}

	protected abstract void FPIABBEAHMK();

	protected override void OnDestroy()
	{
	}

	private void Start()
	{
	}

	protected void KPNFIBBBJKD()
	{
	}

	protected abstract void GGFANHCLFJG();

	protected void KJCKBFCPPNC()
	{
	}

	private void LPIAGIANIGK(bool EPDJDCDHLMP)
	{
	}

	protected abstract bool JCBBKAFICPB(CHILKDJABBF EKOFNPFCLMO);

	private void AOLBIDBILLF()
	{
	}

	private void LBEEBBAHOIC(IALAJKBOKBN KOADGMIKBAB)
	{
	}

	private void KEAADIGLHCK(IMFJFIGOIDI CLFAHPDMPHI)
	{
	}

	private void ILCMMDNEBBH()
	{
	}

	protected virtual void JLCBHPIOGJE()
	{
	}

	public abstract void DeserializeFrom(NLOGDCDGECD FFILBGADKKN);

	public abstract void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM);

	private bool KICAJPMGJMG(Player EKOFNPFCLMO)
	{
		return false;
	}
}
