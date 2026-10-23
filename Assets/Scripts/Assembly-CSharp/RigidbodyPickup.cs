using System;
using Photon.Pun;
using RecRoom;
using RecRoom.Core;
using UnityEngine;

[DisallowMultipleComponent]
public class RigidbodyPickup : MonoBehaviourPun
{
	protected enum LOEBFILEIAP
	{
		NONE = 0,
		PICKUP_DELAY = 1,
		INTERPOLATING_TO_TARGET = 2,
		FOLLOWING_TARGET_NORMAL = 3,
		FOLLOWING_TARGET_PROXY_PHYSICS = 4,
		ATTACH_JOINT = 5
	}

	public enum CAKFLICMCMA
	{
		WHILE_HELD = 0,
		ALWAYS = 1
	}

	[Serializable]
	public struct SpringSettings
	{
		public float SpringForce;

		public float Damper;

		public float MassMultiplier;

		public static SpringSettings Default;
	}

	[SerializeField]
	protected bool interpolateOnPickup;

	[SerializeField]
	protected ProxyPhysicsVisuals proxyPhysicsVisuals;

	[SerializeField]
	protected ProxyPhysicsCollision proxyPhysicsCollision;

	protected const float PDEMHHIPHFC = 0.06f;

	public const float PICKUP_IGNORE_COLLISIONS_DURATION = 0.1f;

	protected const float AHJPDFEJENG = 0.5f;

	private Action POBFEBOHKIM__BackingField;

	public static bool GlobalJointPickupEnabled;

	protected RigidbodyEx IDCFALFGPFP;

	protected NetworkTransform CHPJHOFAEHK;

	private ConfigurableJoint DJFDGPLADFP;

	private CollisionDetectionMode? JCGAFOIHNHK;

	protected RigidbodyEx FHLGNIKHPNF;

	private bool JGPOCAFMIFO;

	private IDisposable OBECBJCGHMB;

	private RigidbodyPickup FHFJGFHAEBH;

	private Vector3 CDIBFCONHHM;

	private Quaternion BPJAPCHDGFC;

	[NonSerialized]
	public bool PickupWithPhysicsJoint;

	protected Tool IEGMBEPJMGC;

	protected MDEJADHJOEJ GHOMHMHDFAD;

	private float KJPEFAPMPAI;

	private float DBMNLPAHMGF;

	private Quaternion OOFIIEKBKAE;

	private SpringSettings AAHKBNCLCEE;

	private bool KAHFDNIPALD;

public RigidbodyPickup HolderPickup
{
get 	{
		return null;
	}

set {
	}
}

public Vector3 HolderSpacePickupPosition
{
get 	{
		return default;
	}

set {
	}
}

public Quaternion HolderSpacePickupRotation
{
get 	{
		return default;
	}

set {
	}
}

public ProxyPhysicsCollision ProxyPhysicsCollision
{
get 	{
		return null;
	}

}

public virtual bool IsPickedUp
{
get 	{
		return false;
	}

}

public virtual Vector3 TargetPosition
{
get 	{
		return default;
	}

}

public virtual Quaternion TargetRotation
{
get 	{
		return default;
	}

set {
	}
}

public bool InterpolatingToTarget
{
get 	{
		return false;
	}

}

public virtual bool IsVisuallyHeld
{
get 	{
		return false;
	}

}

public SpringSettings PhysicsJointSpringSettings
{
get 	{
		return default;
	}

set {
	}
}

protected virtual CAKFLICMCMA ECEJKNPMEHH
{
get 	{
		return CAKFLICMCMA.WHILE_HELD;
	}

}

public bool ScaleWithHolder
{
get 	{
		return false;
	}

set {
	}
}

public event Action ReachedTargetEvent {
add {
	}
remove {
	}
}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	protected virtual void Start()
	{
	}

	private void JJGEEOBAPAI()
	{
	}

	private void ILBDBJLHOOB()
	{
	}

	protected virtual void ELLOMOBOGEE()
	{
	}

	private void HBFCDHKCCAF()
	{
	}

	public void Pickup(RigidbodyPickup LINPGKDBKNO, Vector3 NGNOMIEKCIC, Quaternion MGNHPIKLCID)
	{
	}

	public virtual void Pickup(RigidbodyEx EABDCKGLJEA, Vector3 NGNOMIEKCIC, Quaternion MGNHPIKLCID)
	{
	}

	public virtual void Release()
	{
	}

	public bool IsAttachedTo(RigidbodyPickup OENLCMEDCNI)
	{
		return false;
	}

	public bool IsAttachedTo(RigidbodyEx IDCFALFGPFP)
	{
		return false;
	}

	private void OCBIFDMGDAN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void KGDBPNOLGIO()
	{
	}

	private void PLKEHOFDNAI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void GFDAENFMABK()
	{
	}

	private void DOAAPJKMBJH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void AKEMFMBHKHH(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void OAMNBFOIDEO()
	{
	}

	private void AFMGBOMINEJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void IJMGLEHAANN(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void IPHKPPNPFBI()
	{
	}

	private void NGDEODMKMAD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void ANKJMHNBLJO(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void OIMHOMAJNND()
	{
	}

	private bool MBPJKFEHHML(RigidbodyEx ONAJJDPJPCG)
	{
		return false;
	}

	private bool EFKNMMGPNEN(RigidbodyEx ONAJJDPJPCG)
	{
		return false;
	}

	private void DKIOCFNGHIC()
	{
	}

	private void IAJBEICDMEI()
	{
	}

	protected void FENGAGAEHMM(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
	{
	}

	private void NPGBJIIDMDJ(Rigidbody JJPLCNDEHKB)
	{
	}

	private void PBCGIFFHOGN()
	{
	}

	private void CGPFCHELLLG(MonoBehaviour GNLNNDHBBDI, string NMEEMOHJBGJ)
	{
	}

	private void Reset()
	{
	}
}
