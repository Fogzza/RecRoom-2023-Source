using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using UnityEngine;

public class DiscGolfDisc : MonoBehaviourPun
{
	public delegate void GMIMFFBAPPE(DiscGolfDisc ENECPPAOOCM, CHILKDJABBF CLAAKJAFDLA, CHILKDJABBF MOPBJCCBLNM);

	public delegate void BGDOPIHJLJF(DiscGolfDisc ENECPPAOOCM, CHILKDJABBF PELNHNOCCDO);

	public delegate void CBPDOMOEEPO(DiscGolfDisc ENECPPAOOCM, DiscGolfGoal PDIBMCIEHIJ, CHILKDJABBF LAKIEOJMCKM);

	public delegate void JHLGBNDIJLB(DiscGolfDisc ENECPPAOOCM, Killzone FBLHHLJIGHM, CHILKDJABBF LAKIEOJMCKM);

	public delegate void JNAMJKAALOM(DiscGolfDisc ENECPPAOOCM, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ);

	public delegate void MJMLGPILELJ(DiscGolfDisc ENECPPAOOCM, CHILKDJABBF PELNHNOCCDO);

	public delegate void CIMANCHBJLK(DiscGolfDisc ENECPPAOOCM, Collider ABFFPEJKIMC, CHILKDJABBF LAKIEOJMCKM);

	private sealed class OGAMHHNFDOO : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DiscGolfDisc _003C_003E4__this;

		public Collider hitCollider;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public OGAMHHNFDOO(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public static readonly float MaxAngularVelocity;

	public static readonly float MaxVelocity;

	public AnimationCurve ThrowAssistCurve;

	public float ThrowAssistMultiplier;

	[SerializeField]
	private float airLiftModifier;

	[SerializeField]
	private FloatValueCurve linearToAngularVelocity;

	[SerializeField]
	private float minAngularVelocityForLift;

	[SerializeField]
	private float angularStabilityModifier;

	[SerializeField]
	private float angularStabilityPercent;

	[SerializeField]
	private float angularStabilitySpeed;

	[SerializeField]
	private float curveScaleFactor;

	[SerializeField]
	private Renderer beamRenderer;

	[SerializeField]
	private Vector3 beamRotationOffset;

	[SerializeField]
	private GIBEGHKMCIE team;

	[SerializeField]
	private bool calculatesTelemetry;

	[SerializeField]
	private Tool _tool;

	public const float CATCH_NOTIFICATION_OFFSET_DISTANCE = 0.35f;

	public const float CATCH_NOTIFICATION_DURATION = 3f;

	private DiscGolfDiscTrail[] EFAHPKIHAJD;

	private TeamColorRenderer BNLLLOGKPGN;

	private bool AGHIAEGBAKF;

	private float FPLILPCLNHG;

	private float NNBFKFKGIPC;

	private Vector3 OJOIJAPOFFD;

	[NonSerialized]
	public bool BeamEnabled;

	private PBBHHHPEGKA AGHEKHOGJBO;

	private bool DPOLPKMGLMK;

	private bool HAMENBMHNNF;

	private Vector3 LPEMHCCNKLE;

	private Vector3 EDCKFGNIGOP;

	private float JMOEIHDCDAE;

	private float NBEMOPACAED;

	private float MBGDMHFFHAI;

	private float NBIKCIHGLDK;

	private float CDPMHFLBGNI;

	private float JMOOBKOALJA;

	private float LEBCNBNEFOH;

	private float GIKEAEBPAOP;

	private float LFNGJBLNGKF;

	private float NABNJAKICEJ;

	private float BJKFAFJKLPD;

	private float EDDLKKDFNFD;

	private GMIMFFBAPPE EMLBBJENBCM__BackingField;

	private BGDOPIHJLJF BBLJKICBFEO__BackingField;

	private CBPDOMOEEPO AOKLOEBFKAG__BackingField;

	private JHLGBNDIJLB MODFMDJKOPN__BackingField;

	private JNAMJKAALOM BBFLDOAJKOM__BackingField;

	private MJMLGPILELJ LIIBPCGKLEG__BackingField;

	private CIMANCHBJLK EJEMKIDOBOP__BackingField;

	private global::MOBDJNEDDKC<int> AMKGDAEKJLB;

	private global::MOBDJNEDDKC<int> OFBKEPBJBKJ;

	private global::MOBDJNEDDKC<Vector3> BOGBOMNFJAG;

	private global::MOBDJNEDDKC<bool> CMAKKPJOBHC;

	private global::MOBDJNEDDKC<int> NDEJMHLGIBL;

	private Coroutine AHLGNBPHNPB;

public Tool Tool
{
get 	{
		return null;
	}

}

public float DifferenceZ
{
get 	{
		return 0f;
	}

private set {
	}
}

public GIBEGHKMCIE Team
{
get 	{
		return GIBEGHKMCIE.TEAM_1;
	}

}

public float AirLiftModifier
{
get 	{
		return 0f;
	}

}

public Vector3 LastReleasePosition
{
get 	{
		return default;
	}

private set {
	}
}

public float LastThrowInitialSpeed
{
get 	{
		return 0f;
	}

private set {
	}
}

public float LastThrowMaxHeight
{
get 	{
		return 0f;
	}

private set {
	}
}

public float LastThrowDistance
{
get 	{
		return 0f;
	}

private set {
	}
}

public float LastThrowMaxCurveDeviation
{
get 	{
		return 0f;
	}

private set {
	}
}

public float LastThrowMaxSpeed
{
get 	{
		return 0f;
	}

private set {
	}
}

public float MaxThrowInitialSpeed
{
get 	{
		return 0f;
	}

private set {
	}
}

public float MaxThrowHeight
{
get 	{
		return 0f;
	}

private set {
	}
}

public float MaxThrowDistance
{
get 	{
		return 0f;
	}

private set {
	}
}

public float MaxThrowCurveDeviation
{
get 	{
		return 0f;
	}

private set {
	}
}

public float MaxThrowSpeed
{
get 	{
		return 0f;
	}

private set {
	}
}

public CHILKDJABBF Thrower
{
get 	{
		return null;
	}

set {
	}
}

public DiscGolfCheckpoint CurrentCheckpoint
{
get 	{
		return null;
	}

set {
	}
}

public Vector3 SyncedLastPickupPosition
{
get 	{
		return default;
	}

set {
	}
}

public bool Hazarded
{
get 	{
		return false;
	}

set {
	}
}

public int ConsecutiveCatches
{
get 	{
		return 0;
	}

set {
	}
}

public bool TrailEnabled
{
get 	{
		return false;
	}

set {
	}
}

public Vector3 CurveForce
{
get 	{
		return default;
	}

}

public event GMIMFFBAPPE DiscPickupEvent {
add {
	}
remove {
	}
}

public event BGDOPIHJLJF DiscThrowEvent {
add {
	}
remove {
	}
}

public event CBPDOMOEEPO DiscScoreEvent {
add {
	}
remove {
	}
}

public event JHLGBNDIJLB DiscHazardEvent {
add {
	}
remove {
	}
}

public event JNAMJKAALOM DiscResetEvent {
add {
	}
remove {
	}
}

public event MJMLGPILELJ DiscStopMovingEvent {
add {
	}
remove {
	}
}

public event CIMANCHBJLK CollidedWithSolid {
add {
	}
remove {
	}
}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void FixedUpdate()
	{
	}

	private void PLLGKABPABI(Tool PMEFICGEDFK, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
	{
	}

	public void UpdateTeamColor()
	{
	}

	private void KNALNPOIOPN(Tool IEGMBEPJMGC)
	{
	}

	private void MNPLCFMNCJL(Tool IEGMBEPJMGC)
	{
	}

	private void FNCKPMMKKOM()
	{
	}

	private void CBGDJBMJMJG()
	{
	}

	public Vector3 GetLiftAcceleration(float EDGDGMAMLAC)
	{
		return default;
	}

	private void LCDDPAHMJBO()
	{
	}

	private void INGJKPBBBNB()
	{
	}

	private void OnCollisionEnter(Collision KDGCDLJEAMD)
	{
	}

	private IEnumerator IAGBJKFIFHM(Collider LPGAJGPGKFM)
	{
		return null;
	}

	private bool DMPAGFFJLOO(Tool PMEFICGEDFK, Killzone FOOPALEAEGM)
	{
		return false;
	}
}
