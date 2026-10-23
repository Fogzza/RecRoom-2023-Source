using System;
using RecRoom;
using UnityEngine;

public class GearShiftHandle : AttachedHandle
{
	[Serializable]
	public class GearRepresentation
	{
		public Transform TargetTransform;

		public GameObject EnableWhileInGear;

		public void PINAOAPFFJN(RetargettableAttachedRigidbodyPickup OENLCMEDCNI = null)
		{
		}

		public void MCENFMDEJOC()
		{
		}
	}

	[Serializable]
	public sealed class GearRepresentationDictionary : EditableSerializedDictionary<VehicleControls.GBIMGPLFCJD, GearRepresentation, GearRepresentationDictionary.Kvp>
	{
		[Serializable]
		public sealed class Kvp : SerializedKeyVal<VehicleControls.GBIMGPLFCJD, GearRepresentation>
		{
		}
	}

	[SerializeField]
	private RetargettableAttachedRigidbodyPickup retargettablePickup;

	[SerializeField]
	private GearRepresentationDictionary gearRepresentations;

	[SerializeField]
	private RigidbodyEx parentRigidbodyEx;

	private VehicleControls.GBIMGPLFCJD HFKEDMLOJKI;

public VehicleControls.GBIMGPLFCJD CurrentGear
{
get 	{
		return VehicleControls.GBIMGPLFCJD.Drive;
	}

set {
	}
}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	public bool CanPickupGearShift(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
	{
		return false;
	}

	private void IEELJEBHDEI(Tool IEGMBEPJMGC)
	{
	}

	protected override void CBPOMCILEML(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected override void OGLHAOIFBNC(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected override void AAPJPKCBCCE(ref VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected override void HJGEJOJNJJJ(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}

	protected override void CIIBOPFIPGJ(VehicleControls.OMDHEGMMAIK CIPFGHFHANF)
	{
	}
}
