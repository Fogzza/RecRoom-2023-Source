using System;
using System.Collections.Generic;
using RecRoom.Core.AI;
using UnityEngine;

public class MeleeWeaponCollider : MonoBehaviour
{
	public delegate void GFGGJMJNPOO(MeleeWeaponCollider LLKCFCIIGOB, Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA);

	public delegate void BOOHHPHLNAI(MeleeWeaponCollider LLKCFCIIGOB, Enemy NJDDIIEPJDM, BHHAHFFCKJO EKJJODPHDJK, NGLCDIDOEMK BNFNJFKJEOA);

	public delegate void AJMKLDGFKKN(MeleeWeaponCollider LLKCFCIIGOB, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA);

	public delegate void ALBANAFMACL(MeleeWeaponCollider LLKCFCIIGOB, Trap AOCKEAPKNDE, NGLCDIDOEMK BNFNJFKJEOA);

	public delegate void GDKEDBECBIC(MeleeWeaponCollider LLKCFCIIGOB, NGLCDIDOEMK BNFNJFKJEOA);

	[SerializeField]
	private float radius;

	[SerializeField]
	public LLIOKBPEJMM includedMask;

	[SerializeField]
	public LLIOKBPEJMM excludedMask;

	private int GCELFEKLNIL;

	private Vector3 BEEINBKHHBI;

	private readonly DJIBCHKKBDJ CELCENMFAPE;

	[NonSerialized]
	public bool SupportsStationaryCollisionTests;

	[NonSerialized]
	public bool PerformCollisionChecks;

	private readonly List<Collider> GEEGNLOGPDI;

	private FDDLOCDBFDL[] AMOGAFEFLFF;

	private GFGGJMJNPOO NNGIDPFDOOJ__BackingField;

	private BOOHHPHLNAI PGHPEMJPIPD__BackingField;

	private AJMKLDGFKKN CJFAIHCGHIH__BackingField;

	private ALBANAFMACL BOIFECJJOGJ__BackingField;

	private GDKEDBECBIC KEFHKOAMBJD__BackingField;

	private GDKEDBECBIC EMGFDMDCJAD__BackingField;

public event GFGGJMJNPOO PlayerImpactEvent {
add {
	}
remove {
	}
}

public event BOOHHPHLNAI EnemyImpactEvent {
add {
	}
remove {
	}
}

public event AJMKLDGFKKN ToolImpactEvent {
add {
	}
remove {
	}
}

public event ALBANAFMACL TrapImpactEvent {
add {
	}
remove {
	}
}

public event GDKEDBECBIC OtherImpactEvent {
add {
	}
remove {
	}
}

public event GDKEDBECBIC AnyImpactEvent {
add {
	}
remove {
	}
}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	public void AddIgnoredColliders(IEnumerable<Collider> GHKNKHCKPII)
	{
	}

	public void AddIgnoredCollider(Collider ADMCDJKKCIA)
	{
	}

	public void RemoveIgnoredColliders(IEnumerable<Collider> GHKNKHCKPII)
	{
	}

	public void RemoveIgnoredCollider(Collider ADMCDJKKCIA)
	{
	}

	private void FixedUpdate()
	{
	}

	private bool BCCNJKFNCNM(int BEBMLJIDPAP, Vector3 OIEPDFJCEHE)
	{
		return false;
	}

	private void PFHCKKIBBAD(Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
	{
	}

	private void BADNPOJDELK(Enemy NJDDIIEPJDM, BHHAHFFCKJO EKJJODPHDJK, NGLCDIDOEMK BNFNJFKJEOA)
	{
	}

	private void HBALFKKDLMH(Tool IEGMBEPJMGC, NGLCDIDOEMK BNFNJFKJEOA)
	{
	}

	private void DLOCFGGPHDO(Trap MBLENDJGFCI, NGLCDIDOEMK BNFNJFKJEOA)
	{
	}

	private void ANNGGMANNPH(NGLCDIDOEMK BNFNJFKJEOA)
	{
	}

	private void OnDrawGizmosSelected()
	{
	}
}
