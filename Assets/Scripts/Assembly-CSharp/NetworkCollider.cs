using Photon.Pun;
using UnityEngine;

public class NetworkCollider : MonoBehaviourPun
{
	public delegate void OEKJDLGODEH(GameObject PPHGKFHCFAH, Tool LEBOKCEIKAO, Vector3 PDFEDMAOMNH);

	public delegate void MGKEBODNGJG(GameObject PPHGKFHCFAH, Player EKOFNPFCLMO, Player.NBPIPAJOGLC MKLOBAIKINA, Vector3 PDFEDMAOMNH);

	private const float HOCKCGFPJCA = 0.5f;

	private OEKJDLGODEH GPPKEIFLKOL__BackingField;

	private MGKEBODNGJG GIEBMLIIHKC__BackingField;

	private OEKJDLGODEH KECMCAGEOBO__BackingField;

	private MGKEBODNGJG NLAANKGHMPE__BackingField;

	public bool IsOnline;

	private Tool FKCMGALPHBD;

	private float GOJPMDIHCPF;

	private Player OOPPIDELKIM;

	private float JDPPLJIHGED;

public event OEKJDLGODEH ServerToolCollisionEnterEvent {
add {
	}
remove {
	}
}

public event MGKEBODNGJG ServerPlayerCollisionEnterEvent {
add {
	}
remove {
	}
}

public event OEKJDLGODEH ServerToolTriggerEnterEvent {
add {
	}
remove {
	}
}

public event MGKEBODNGJG ServerPlayerTriggerEnterEvent {
add {
	}
remove {
	}
}

	private void OnTriggerEnter(Collider ADMCDJKKCIA)
	{
	}

	private void OnCollisionEnter(Collision KDGCDLJEAMD)
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterToolCollisionEnterEvent(bool ANOLJBKAOJP, Tool IEGMBEPJMGC, Vector3 NCAHJMLLNDA)
	{
	}

	[PBOMGCLBFHF]
	public void RpcMasterPlayerCollisionEnterEvent(bool ANOLJBKAOJP, Player EKOFNPFCLMO, Player.NBPIPAJOGLC HLBENGKLBLD, Vector3 NCAHJMLLNDA)
	{
	}

	private void JACCBFDFICH(bool ANOLJBKAOJP, Tool LMEKFBDFCDN, Vector3 PDFEDMAOMNH)
	{
	}

	private void HHNEKLILBMG(bool ANOLJBKAOJP, Player KJCCPIIFNGO, Player.NBPIPAJOGLC MKLOBAIKINA, Vector3 PDFEDMAOMNH)
	{
	}
}
