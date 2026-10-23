using System;
using UnityEngine;

public class SphericalConstraintRigidbodyPickup : RigidbodyPickup
{
	public enum NACLEFIHPDO
	{
		LOCKED = 0,
		LIMITED = 1,
		FREE = 2
	}

	public enum AOKJBCELJLC
	{
		SPHERE_SURFACE = 0,
		SPHERE_VOLUME = 1
	}

	[Serializable]
	public struct AngularMovementConstraint
	{
		public NACLEFIHPDO Mode;

		public float MinLimitedAngle;

		public float MaxLimitedAngle;

		public static AngularMovementConstraint Default;
	}

	public Transform sphereOrigin;

	public AOKJBCELJLC positionConstraint;

	public bool automaticallyCalculateSphereRadius;

	public float sphereRadius;

	public AngularMovementConstraint yawConstraint;

	public AngularMovementConstraint pitchConstraint;

	public AngularMovementConstraint rollConstraint;

public override Vector3 TargetPosition
{
get 	{
		return default;
	}

}

public override Quaternion TargetRotation
{
get 	{
		return default;
	}

}

	protected override void Awake()
	{
	}

	public void GetCurrentNormalizedPitchYaw(out float AMBIBIKJBIF, out float PDOAEDKCDIA)
	{
		AMBIBIKJBIF = default;
		PDOAEDKCDIA = default;
	}

	public float GetAbsoluteYawFromNormalizedYaw(float PDOAEDKCDIA)
	{
		return 0f;
	}

	public float GetAbsolutePitchFromNormalizedPitch(float AMBIBIKJBIF)
	{
		return 0f;
	}

	public float GetNormalizedYawFromAbsoluteYaw(float LNABCKIIGLA)
	{
		return 0f;
	}

	public float GetNormalizedPitchFromAbsolutePitch(float HGPAKDBGHGJ)
	{
		return 0f;
	}

	public void AuthoritySetNormalizedPitchYaw(float IFJIHPGFJGG, float KLFGCHPADEN)
	{
	}

	public Quaternion GetRotationFromNormalizedYawPitch(float BGDOABDEINM, float NDKMLDIANOK)
	{
		return default;
	}

	public void GetTransformFromNormalizedYawPitch(float IFJIHPGFJGG, float KLFGCHPADEN, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH)
	{
		INLGLHIPOMC = default;
		HEGBBJCMANH = default;
	}

	private void GBDHONGJIFE(Vector3 EGJKEDKNNAD, out float ONJEDBFDBNP, out float ICFCNKNGFKM, out float NNLEGJGIGHA)
	{
		ONJEDBFDBNP = default;
		ICFCNKNGFKM = default;
		NNLEGJGIGHA = default;
	}

	private Vector3 OFHNAMCKNPJ(float ONJEDBFDBNP, float ICFCNKNGFKM, float NNLEGJGIGHA)
	{
		return default;
	}

	private void HFIGPKLECHP(ref float ONJEDBFDBNP, ref float ICFCNKNGFKM, ref float NNLEGJGIGHA)
	{
	}

	private float OFMBCAABPPC(float MILGOCGHFJG, AngularMovementConstraint COOGLODBLDF)
	{
		return 0f;
	}

	private float LLMNJMIJHPG(float MILGOCGHFJG)
	{
		return 0f;
	}

	private float CJKHLDJJHIE(float MILGOCGHFJG, AngularMovementConstraint COOGLODBLDF)
	{
		return 0f;
	}

	private float MGFDEGEMBFH(float NNFGEJOMBFG, AngularMovementConstraint COOGLODBLDF)
	{
		return 0f;
	}

	private float HMPNNDLJGFE(float DMAJCBAPNFK, AOKJBCELJLC COOGLODBLDF)
	{
		return 0f;
	}
}
