using Photon.Pun;
using RecRoom.Core.GameManagement;
using RecRoom.DataStructures;
using UnityEngine;

public class PointsDropper : MonoBehaviourPun
{
	public delegate void LBJPMPIKJLC(PointsDropper CAMENOAPLLO, Vector3 INLGLHIPOMC, CHILKDJABBF[] EKJPLODFNKO, int KOMPMCPODJM, int AFALOODLEEP, GCKJBJPBEIG JBEFKFHGMNH, bool CAJKLOGPEID = false);

	[SerializeField]
	private GCKJBJPBEIG lootType;

	[SerializeField]
	private int minDropValue;

	[SerializeField]
	private int maxDropValue;

	[SerializeField]
	private float dropFeedbackOffset;

	[SerializeField]
	private SerializedGuid spawnEquipmentToolId;

	[SerializeField]
	private bool dontAddToCombatScore;

	private static LBJPMPIKJLC KLMNAILFDCC__BackingField;

private JBGFOIKBKED DJPDAKPBEMA
{
get 	{
		return JBGFOIKBKED.AC_UNIT;
	}

}

public int MinDropValue
{
get 	{
		return 0;
	}

}

public int MaxDropValue
{
get 	{
		return 0;
	}

}

public static event LBJPMPIKJLC PointsDropEvent {
add {
	}
remove {
	}
}

	public void DropPoints(CHILKDJABBF[] EKJPLODFNKO)
	{
	}

	public virtual void DropPoints(CHILKDJABBF[] EKJPLODFNKO, Vector3 PDFEDMAOMNH)
	{
	}

	private LootTool KILPHPBELHL(JBGFOIKBKED LKMPNJODPOE, Vector3 ELGLOEDDKAJ, Quaternion FJKPMOAGDOI, float LGPIDIPODLD, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK, bool BGAGJCJCBNF)
	{
		return null;
	}
}
