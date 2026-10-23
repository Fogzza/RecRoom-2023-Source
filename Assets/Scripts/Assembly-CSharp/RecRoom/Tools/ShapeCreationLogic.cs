using System;
using RecRoom.Core.Creation;
using UnityEngine;

namespace RecRoom.Tools
{
	[Serializable]
	public abstract class ShapeCreationLogic
	{
		protected static readonly Vector3 DefaultCreationViewportPosition;

		[SerializeField]
		private AnimationCurve pressureToThicknessCurveVive;

		[SerializeField]
		private AnimationCurve pressureToThicknessCurveOculus;

		[NonSerialized]
		protected AMEPDCGKFOG activeShapeType;

		[NonSerialized]
		private float lastCurveShapeControlPointAddTime;

		[NonSerialized]
		private float lastMeshShapeSizeSynchronizeTime;

		[NonSerialized]
		private Vector3 startMeshShapeCreationPosition;

		[NonSerialized]
		private Quaternion lastMeshShapeCreationRotation;

		[NonSerialized]
		private DKECPGBBCFA triggerHistory;

		private bool triggerHasBeenReleased;

		[NonSerialized]
		private bool continuingOnCurve;

		[NonSerialized]
		private Quaternion lastCurveShapeControlPointAddInputRotation;

		private const float MESH_SHAPE_SYNCHRONIZE_SIZE_MAX_TIME_INTERVAL = 0.1f;

		protected const float DEFAULT_CREATION_DISTANCE_FROM_CAMERA = 0.66f;

		protected const float PRIMITIVE_SHAPE_MIN_SIZE = 0.02f;

		private const float CURVE_SHAPE_ADD_CONTROL_POINT_MAX_TIME_INTERVAL = 0.1f;

		private const float CURVE_SHAPE_MIN_DIST_BETWEEN_CONTROL_POINTS = 0.01f;

		private const float CURVE_SHAPE_MIN_RADIUS = 0.005f;

		public readonly FCOHGGHPPMJ DefaultCurveShapeSettings;

		[NonSerialized]
		protected CreationContext context;

		[NonSerialized]
		protected MMMPKIMPKKC shapeContext;

		[NonSerialized]
		protected Func<float> normalizedInputProvider;

		public bool IsExtruding => false;

		protected abstract FCOHGGHPPMJ CurveShapeSettings { get; }

		protected abstract Vector3 PKEHJGBFFBC(bool FPBJDAEBBLG);

		protected Vector3 PKEHJGBFFBC(AMEPDCGKFOG NIFOGEBEDNG)
		{
			return default;
		}

		protected abstract Quaternion ONCHOJOOPDD(bool FPBJDAEBBLG);

		protected Quaternion ONCHOJOOPDD(AMEPDCGKFOG NIFOGEBEDNG)
		{
			return default;
		}

		protected abstract Transform FGGBNFHENFO();

		protected virtual bool PMLHLHHELLF()
		{
			return false;
		}

		protected virtual float HKFKOIKJLJC()
		{
			return 0f;
		}

		protected virtual bool EILMIGFECLG()
		{
			return false;
		}

		protected virtual void DGLBPFGEJKK(IONEOHGOAML CDNLFEOBNKB, string PEOLHGGDCPN, CHILKDJABBF FOILEMDKKCC)
		{
		}

		public virtual void IHEKMEOIBOI(CreationContext DELCOFCGDFF, MMMPKIMPKKC JHDDECPKLAN, Func<float> DNBMGMHBKAL)
		{
		}

		public bool KCHOHNMHAPF(bool GKBLDJOHELB = true)
		{
			return false;
		}

		public void PPHFKEKLDBC(AMEPDCGKFOG NIFOGEBEDNG, JLHLKDMLBPK HMCAFGCGFJF, MJGMBIJIKFH PMPDPBDKGPF, bool FMADCJFJKKL = false)
		{
		}

		public void PPHFKEKLDBC(AMEPDCGKFOG NIFOGEBEDNG, JLHLKDMLBPK HMCAFGCGFJF, MJGMBIJIKFH PMPDPBDKGPF, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, bool FMADCJFJKKL = false)
		{
		}

		public void IOOIPHCGLOO()
		{
		}

		public void JCMDCMCGNHF()
		{
		}

		protected virtual void KLCFCMDANGO(Guid GHLKBLAKLII)
		{
		}

		protected virtual Vector3 OMMHHOMKAPI(Vector3 CAPKFCHDLFA)
		{
			return default;
		}

		public virtual float OOOOBMJAKFG()
		{
			return 0f;
		}

		protected static bool IHCEODOHEOA(AMEPDCGKFOG NIFOGEBEDNG)
		{
			return false;
		}

		private float BBLHJCJMEOP()
		{
			return 0f;
		}

		private void IPCMFNELNGL(JLHLKDMLBPK HMCAFGCGFJF, MJGMBIJIKFH PMPDPBDKGPF, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, bool FMADCJFJKKL)
		{
		}

		private void JBKBDFBINPH()
		{
		}

		private void IAEIALHLNIO()
		{
		}

		private void BIBDAMHOBNG(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool GPMLHIIHHBK)
		{
		}

		private void HELACILGMPJ(Vector3 INLGLHIPOMC, Quaternion NCFBEJGEFEL, float NNLEGJGIGHA, bool DIPAJPIHMIJ, bool GPMLHIIHHBK)
		{
		}

		private bool OELPGEMHLJE(Vector3 OLGDEIEOHNE, Vector3 FFONNHECOGM, float NNLEGJGIGHA)
		{
			return false;
		}

		private void FABGKBEEFGA(out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH, out float NNLEGJGIGHA)
		{
			INLGLHIPOMC = default;
			HEGBBJCMANH = default;
			NNLEGJGIGHA = default;
		}

		public Quaternion HGCODPNALLC(Vector3 BKGFLCOJOPD, Vector3 MAKAGDCOCIB, Quaternion GDLDOIEMFLI, Quaternion IKAMOGCJCNE)
		{
			return default;
		}

		private void NAIHKNOFFEI(bool KMCHMHHFPCE)
		{
		}

		private void NLFANNHFPJF()
		{
		}
	}
}
