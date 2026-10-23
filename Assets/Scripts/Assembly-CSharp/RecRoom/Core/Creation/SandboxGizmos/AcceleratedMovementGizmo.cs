using System;
using System.Collections.Generic;
using System.Text;
using RecRoom.Core.Creation.CircuitsV1;
using UnityEngine;

namespace RecRoom.Core.Creation.SandboxGizmos
{
	public abstract class AcceleratedMovementGizmo : InfluencerGizmo
	{
		private struct LFDGGCKKBHP
		{
			public static readonly LFDGGCKKBHP FBJHBFFDBDJ;

			public Vector3 INLGLHIPOMC;

			public Quaternion HEGBBJCMANH;

			public Vector3 OIEPDFJCEHE;

			public Vector3 MEBJBANMPLK;
		}

		private struct FPCEONPNAOO
		{
			public Vector3 COPOILGLIAJ;

			public Vector3 HMKLOLJGHPK;

			public Vector3 FMHBCBCAMLB;

			public Vector3 IAMNIPPCMAL;
		}

		private const float CIAPHLDENLL = 9E-05f;

		private const float HCAACDBPPJM = 0.0001f;

		private const float KMGDINCNGJN = float.Epsilon;

		protected int IHHDFBGEJBA;

		protected int LLFNMHGMFDG;

		protected float MIGHHJANGLB;

		private float NKBFJIOFCGK;

		private LFDGGCKKBHP LCLOMNJDPEP;

		private FPCEONPNAOO AEIPPJMMCLE;

		private global::MOBDJNEDDKC<float> LBEHGKHGDNN;

		private global::MOBDJNEDDKC<bool> PJGDNPCGBNJ;

		[SerializeField]
		private CircuitEventNodeDisplay nodeDisplay;

		private IDisposable ENCMMDMADNN;

protected CircuitEventNodeDisplay JPAOKBCBFLN
{
get 		{
			return null;
		}

}

protected float HHEAIBFKBJL
{
get 		{
			return 0f;
		}

private set {
		}
}

protected bool FFFEMPAHADN
{
get 		{
			return false;
		}

private set {
		}
}

protected bool LLNINBLBFFN
{
get 		{
			return false;
		}

}

private RigidbodyEx HKAHNOCIENG
{
get 		{
			return null;
		}

}

		public void AddTorque(Vector3 HMKLOLJGHPK, ForceMode OJOAKAEAKAC = ForceMode.Force)
		{
		}

		public void AddTorqueLocal(Vector3 HMKLOLJGHPK, ForceMode OJOAKAEAKAC)
		{
		}

		public void AddForce(Vector3 COPOILGLIAJ, ForceMode OJOAKAEAKAC = ForceMode.Force)
		{
		}

		public void AddForceLocal(Vector3 COPOILGLIAJ, ForceMode OJOAKAEAKAC)
		{
		}

		public void ClearAngularVelocity()
		{
		}

		public void ClearLinearVelocity()
		{
		}

		public void ChangeInputs(Dictionary<EDBMANFHGGO, int> input)
		{
		}

		protected abstract void DPHIKDNCLDK();

		protected abstract void LDHMIPDLMND();

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override AKCHPHOMHLH MNECEOLGCKC()
		{
			return null;
		}

		protected override void OPBHAMDIMBE(Vector3 CPLLMPKBHAM, Quaternion IKEPGNGNPGC)
		{
		}

		private void GGBKANLJGCH(Tool IEGMBEPJMGC)
		{
		}

		private void JFGMIGPAJNO(Tool IEGMBEPJMGC)
		{
		}

		private void IINLBEOMLFM()
		{
		}

		private void MANOIOFDEEM(RigidbodyEx NEJMOIPCOAO, bool LDEEGDEKBLJ)
		{
		}

		private void FKOGAMBFPOM()
		{
		}

		private void DIMBCCBOEMA()
		{
		}

		private void JNLMCHGCDEC()
		{
		}

		private void LFEDAMEDMBJ()
		{
		}

		private void NFMOKONOEPA()
		{
		}

		private LFDGGCKKBHP FFPJFLPLNDJ(LFDGGCKKBHP DADHJJNJEFA, float OKBAJEAPIHG, bool ACPBAFDGGLP)
		{
			return default;
		}

		private void CDIALDCLPKL(in LFDGGCKKBHP DADHJJNJEFA)
		{
		}

		private bool ICGODKMNMKH(in LFDGGCKKBHP DADHJJNJEFA, out bool ACPBAFDGGLP)
		{
			ACPBAFDGGLP = default;
			return false;
		}

		private LFDGGCKKBHP BMADDNPHIGC()
		{
			return default;
		}

		private void HBIACIOKOFF(in LFDGGCKKBHP DADHJJNJEFA)
		{
		}

		private void ABMKCOLMEOD(in LFDGGCKKBHP DADHJJNJEFA, float BKPKOGBFMFG)
		{
		}

		private float GOLKCFKGGCF()
		{
			return 0f;
		}

		private void GJKMBOPHBMK(float DLEMNBPMGBG)
		{
		}

		private bool NGOMIMBNJIO()
		{
			return false;
		}

		private void HKFEALPCDDL(bool DLEMNBPMGBG)
		{
		}

		public override void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		public override void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}
	}
}
