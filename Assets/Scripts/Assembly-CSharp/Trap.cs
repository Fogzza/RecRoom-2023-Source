using System.Collections.Generic;
using Photon.Pun;
using RecRoom;
using RecRoom.Core.AI;
using UnityEngine;

public class Trap : MonoBehaviourPun
{
	[SerializeField]
	protected int playerDamage;

	[SerializeField]
	protected int enemyDamage;

	[SerializeField]
	protected bool alwaysDisarmToolHits;

	[SerializeField]
	protected List<SceneSpawnPoint> customSpawnPoints;

	[SerializeField]
	protected bool penalizePlayerOnRespawn;

	[SerializeField]
	protected string damageVerb;

	protected Animator CBCFEAPCGEO;

	[SerializeField]
	protected RigidbodyEx rigidbodyEx;

	protected TrapCollider[] GHKNKHCKPII;

	private global::MOBDJNEDDKC<bool> NMNMONHBBFB;

	protected Vector3 FCNGMPHKHAE;

	protected Quaternion EIKMPMAOMIA;

public int PlayerDamage
{
get 	{
		return 0;
	}

}

public RigidbodyEx RigidbodyEx
{
get 	{
		return null;
	}

}

public bool IsEnabled
{
get 	{
		return false;
	}

private set {
	}
}

	protected override void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	public void MasterDisable()
	{
	}

	public virtual void MasterResetToSpawnPoint()
	{
	}

	protected virtual void IDIEHBILCLL()
	{
	}

	public virtual void AuthorityApplyDamage(DJBEHNDMJDL IKEDGLGPGEA, int FDDPFMJOHLO, Vector3 PDFEDMAOMNH, Vector3 CHEKLLFMKBP)
	{
	}

	public virtual void AuthorityOnDamageApplyForce(DJBEHNDMJDL IKEDGLGPGEA, Vector3 COPOILGLIAJ, Vector3 PDFEDMAOMNH)
	{
	}

	public void AuthorityClearVelocity()
	{
	}

	public virtual void AuthorityOnDamageChangeVelocity(DJBEHNDMJDL IKEDGLGPGEA, Vector3 OIEPDFJCEHE, Vector3 MEBJBANMPLK)
	{
	}

	public virtual void LocalPlayerCustomRespawn()
	{
	}

	protected void JHKCEGIAPPH(Tool IEGMBEPJMGC, NGLCDIDOEMK BNFNJFKJEOA)
	{
	}

	protected void JILIKIBHOEG(Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
	{
	}

	protected void KMHBBNPHPFP(Enemy DPENEFKKNDN, BHHAHFFCKJO MBKGKPOBHBB, DJBEHNDMJDL IKEDGLGPGEA, NGLCDIDOEMK BNFNJFKJEOA)
	{
	}

	protected void DPLLFDFPPHN(Trap AOCKEAPKNDE, DJBEHNDMJDL IKEDGLGPGEA, NGLCDIDOEMK BNFNJFKJEOA)
	{
	}
}
