using Photon.Pun;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Tools
{
	public abstract class DrawingToolBase : MonoBehaviourPun
	{
		private const float PAGNHJDLDPC = 0.02f;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private DrawingSurface.KMBMNLIAFCM _drawingSurfaceType;

		[SerializeField]
		private Transform _brushTip;

		[SerializeField]
		protected float maxDrawingOffset;

		[SerializeField]
		protected float minControlPointDistance;

		[SerializeField]
		private AnimationCurve vibrationCurve;

		[SerializeField]
		private float minVelocityForVibrate;

		[SerializeField]
		private Material _drawingMaterial;

		[SerializeField]
		private float soundVelocityThreshold;

		[SerializeField]
		private RecRoomAudioClip brushDownClip;

		[SerializeField]
		private RecRoomAudioClip brushLoopClip;

		private global::MOBDJNEDDKC<bool> LLIFEIJKBAO;

		private DrawingSurface DNOPDCLPHKP;

		private bool GFOCAHLBPEB;

		private Vector2 MLKLALOKDHO;

		private PFPHHBKDIOO EKFBFHPJHMO;

		private Vector3 OKNDPPJBELE;

		private Material KDJHNDJKJHE;

		private SFXAudioSource BPLEHDLNKKP;

		private float DBFGDBCEMFB;

private bool IAHPKHFCBII
{
get 		{
			return false;
		}

set {
		}
}

public Tool Tool
{
get 		{
			return null;
		}

}

public DrawingSurface CurrentSurface
{
get 		{
			return null;
		}

set {
		}
}

public bool AutomaticDrawingEnabled
{
get 		{
			return false;
		}

set {
		}
}

public Transform BrushTip
{
get 		{
			return null;
		}

}

public Material DrawingMaterial
{
get 		{
			return null;
		}

}

public DrawingSurface.KMBMNLIAFCM DrawingSurfaceType
{
get 		{
			return DrawingSurface.KMBMNLIAFCM.None;
		}

}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void MNPLCFMNCJL(Tool IEGMBEPJMGC)
		{
		}

		public void UpdateManualDrawing(Vector3 HHJBPKBGBDF, Quaternion CMMMBDGBMEE, float MAMLEPJHFDG)
		{
		}

		public void FinishManualDrawing()
		{
		}

		protected abstract void PFCAMPAKHPH(DrawingSurface BGAIAAOKCNI, Vector3 OPKCDLOHCOL, Quaternion PFAHJLMBDNJ, Vector2 IMGIINHLHBH, float MAMLEPJHFDG);

		protected abstract void IECLFMCEFHJ();

		private void EGJAGFFIOKG()
		{
		}

		private void NFKCCAFHOCI()
		{
		}

		private bool DOEHCFIPPNF(Vector3 HHJBPKBGBDF, out Vector2 JLBANBKOAJD, out bool CPDFHOENGNF, out float BLPKFMKPBHC)
		{
			JLBANBKOAJD = default;
			CPDFHOENGNF = default;
			BLPKFMKPBHC = default;
			return false;
		}

		private float OIDFJDILBAI(float DDPPCAIAJBA)
		{
			return 0f;
		}

		private bool KDCEPIMECBE(Vector3 LBIKDHHJNFA, Quaternion JMKDGFLACIJ, Vector2 EGKFEKABEJK, float MAMLEPJHFDG, out Vector3 DMOJHMOJMMI)
		{
			DMOJHMOJMMI = default;
			return false;
		}

		private void MCDFMBEKNKJ()
		{
		}

		private void KBEHEOIPBJP()
		{
		}

		private void IHNPECNDHPD()
		{
		}

		private void GMMEPOAEGNA()
		{
		}
	}
	public abstract class DrawingToolBase<ControlPointType> : DrawingToolBase where ControlPointType : class, global::DCHKNLBDGLD<ControlPointType>
	{
		protected global::PJBFANJFIEG<ControlPointType> OAGJKJONMPN;

		protected global::PJBFANJFIEG<ControlPointType> NJACJMHNGPN(DrawingSurface FAMNKOFMEAL, ControlPointType FIPKDOGDEHA, bool BCFJHEBBJFF)
		{
			return null;
		}

		protected abstract ControlPointType FLHLAKBCCEH(Vector3 BLNDKIPIIID, Quaternion IAIGMCHLMIE, float MAMLEPJHFDG);

		private void AALLKLIACPA(DrawingSurface CDDEDCBDPEE, ControlPointType BLPFLFCNBNE, int ALBDIOBGBHM)
		{
		}

		private void FEIMFJMCMMD()
		{
		}

		protected override void PFCAMPAKHPH(DrawingSurface CDDEDCBDPEE, Vector3 OPKCDLOHCOL, Quaternion PFAHJLMBDNJ, Vector2 IMGIINHLHBH, float MAMLEPJHFDG)
		{
		}

		protected override void IECLFMCEFHJ()
		{
		}

		[PBOMGCLBFHF]
		protected void RpcAddControlPoint(DrawingSurface CDDEDCBDPEE, ControlPointType KCIHBJCPBAI, int ALBDIOBGBHM)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcFinishStroke()
		{
		}
	}
}
