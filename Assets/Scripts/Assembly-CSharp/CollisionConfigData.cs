using System;
using RecRoom;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public struct CollisionConfigData
{
	public enum FPOKJDAFOMI
	{
		NONE = 0,
		PARTIALLY_ELASTIC_LINEAR_COLLISION_VELOCITY_CHANGE = 1,
		PARTIALLY_ELASTIC_LINEAR_COLLISION_POINT_IMPACT = 2,
		SIMPLE_VELOCITY_MULT = 3,
		PERFECTLY_INELASTIC_COMPLEX_COLLISION_EXPERIMENTAL = 4
	}

	public enum OHHKKHFIFIH
	{
		NONE = 0,
		VELOCITY_CHANGE = 1,
		POINT_IMPACT = 2
	}

	private const float MIN_OBJECT_MASS = 0.1f;

	public FPOKJDAFOMI CollisionModeAgainstHitObject;

	public float InitialForceMultiplier;

	public float SustainedForceMultiplier;

	public OHHKKHFIFIH CollisionModeRestitutionForce;

	public float InitialRestitutionForceMultiplier;

	public float SustainedRestitutionForceMultiplier;

	public bool RestitutionIgnoreUpwardsImpulse;

	public float SimplePhysicsVelocityMultiplier;

	public float InelasticityBias;

	public float RestitutionInelasticityBias;

	public float UpwardAngleBias;

	public bool KeepLateralForceMagnitudeWhenApplyingUpwardsBias;

	public bool IgnoreDownwardsImpulseComponent;

	public AnimationCurve CollisionRelativeVelocityForceMultiplier;

	public AnimationCurve CollisionAbsoluteVelocityForceMultiplier;

	public bool ProcessesAnyCollisions => false;

	private OHHKKHFIFIH ActiveRestitutionCollisionMode => OHHKKHFIFIH.NONE;

	public bool ShouldApplyRestitutionAtCenterOfMass => false;

	private bool CollisionModeSupportsCustomRestitution => false;

	private bool RestitutionEnabled => false;

	private bool SupportsVelocityMultipliers => false;

	private bool SupportsAngleBias => false;

	private bool LinearVelocityBasedCalculation => false;

	public bool CJMFJFKMAIB(bool MKOMMHIKNLJ)
	{
		return false;
	}

	public bool ANHNHIPOPML(Collider MGFNNDHFIMP, RigidbodyEx CPGEJBDBPFH, Vector3 PEHCOOOOFJI, Collider BKELGPGOMPE, Rigidbody HOBIKILLCDC, Vector3 DNBPPJGEBGN, Vector3 LLOBNBEGGND, Vector3 MCKFCCNKIND, bool OAKHENHGKPK, float OJDFIELPKHN, out Vector3 HJFBPALDKMF, out ForceMode KAFCKFKLNKN, out Vector3 JDFDODNOJOD, out ForceMode KFJDLGPKDAK)
	{
		HJFBPALDKMF = default;
		KAFCKFKLNKN = default;
		JDFDODNOJOD = default;
		KFJDLGPKDAK = default;
		return false;
	}

	private bool LEHLKBMPADN(Vector3 GCLOPAJOHFJ, Vector3 KGCHBOBLFIJ, Vector3 JGACLMJKIAL, out float KICCGNJACHA, out float LEJPMNICHGB)
	{
		KICCGNJACHA = default;
		LEJPMNICHGB = default;
		return false;
	}

	private static Vector3 OAHCMGLHHPN(Vector3 DEBGMOHFODM, Vector3 LAJJDLFACCC, Vector3 KDDBCMBFJNM, float3x3 KEKNLOPPELO, float3 NPACEIJMJBM, float LLHNKKMKAKN, Vector3 DBMJMLKDJNM, Vector3 BLJDCJPECPB, Vector3 FBJAOKHOMEO, float3x3 AOAPCPONFIC, float3 GNBFABLPIDH, float JDMOBNENFOO)
	{
		return default;
	}

	private bool PLGLCLEEPNH(float LLHNKKMKAKN, float JDMOBNENFOO, Vector3 GCLOPAJOHFJ, Vector3 KGCHBOBLFIJ, Vector3 JGACLMJKIAL, float HEEINPFODAG, out float KICCGNJACHA, out float LEJPMNICHGB, out float MCBPJDFLLOJ, out float IBJHDJKIDGH)
	{
		KICCGNJACHA = default;
		LEJPMNICHGB = default;
		MCBPJDFLLOJ = default;
		IBJHDJKIDGH = default;
		return false;
	}

	private static float3x3 KOOLGHEFMPB(float3 JMIGJNODJGE)
	{
		return default;
	}

	private static float3x3 KGCJCHMBIKN(float3 JMIGJNODJGE)
	{
		return default;
	}

	private bool MLPJFJOCGNN(Vector3 MCKFCCNKIND, Vector3 LLOBNBEGGND, Vector3 GNBFABLPIDH, float KNBIPECNNCO, float PPJCOHCJADG, out float EHCHCDHKPJM, out float BCCNJJLMIKH, out Vector3 FMNOPMLIKLG)
	{
		EHCHCDHKPJM = default;
		BCCNJJLMIKH = default;
		FMNOPMLIKLG = default;
		return false;
	}

	private static float EOMHCGEJIMG(Collider BKELGPGOMPE, Collider MGFNNDHFIMP, bool OAKHENHGKPK)
	{
		return 0f;
	}

	private float CFCADOCKHCH(float KNBIPECNNCO, float BINKGNPNPEP)
	{
		return 0f;
	}
}
