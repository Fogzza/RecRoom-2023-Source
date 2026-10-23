using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RecRoom.CircuitsV2.GraphNodes
{
	public abstract class ControlPanelCircuitObjectBase : CircuitObject, ADDCDIBDJKJ, PHCICIGDDPA, BOALOIBLNEO
	{
		protected delegate void LNDJBKINLAJ(in Guid OLNCKNNJIPA, global::MPNGGJINIEL<IPGAKKHFLAO> NJHCIFCMCMI);

		private GFLPAFBGELM MBPIOOPACJF;

		protected bool EGBNEFIIPPG;

		private bool LOIOIBGNLBM;

		[SerializeField]
		private Transform controlPanelTetherPoint;

		private Guid BOKMPEJBOKD;

		private OEJOPFEPHFI APGDDFFCINI;

		private Transform LENOEFIFLLK;

		private Chip AACKHCAHIMF;

		private ControlPanelTransformSync OEAOEEGNMDD;

		private Action<Chip> EBMIHPCNKBF__BackingField;

		private Action<Chip> GIBGPMKKAEL__BackingField;

		private const float BGMGKEEGCBD = 0.001f;

public Transform TetherPoint
{
get 		{
			return null;
		}

}

public Guid CircuitGraphId
{
get 		{
			return default;
		}

private set {
		}
}

public OEJOPFEPHFI CircuitGraph
{
get 		{
			return null;
		}

set {
		}
}

protected override MIEKHIHLDEK CCJMJOCKDEL
{
get 		{
			return null;
		}

}

public Guid? NodeId
{
get 		{
			return null;
		}

}

public DAHGAHBLMAB ControlPanel
{
get 		{
			return null;
		}

}

public bool IsControlPanelSelected
{
get 		{
			return false;
		}

}

public EGCHDEINBLO ControlPanelTransform
{
get 		{
			return null;
		}

}

protected Transform EKFOIACGHCM
{
get 		{
			return null;
		}

private set {
		}
}

public Chip ControlPanelChip
{
get 		{
			return null;
		}

set {
		}
}

protected ControlPanelTransformSync LPMGIKLNJDI
{
get 		{
			return null;
		}

private set {
		}
}

protected abstract Transform NHHCIIKGFPE
{
get ;
}

protected abstract bool PEDMHGEFFCL
{
get ;
}

public abstract string Name
{
get ;
}

public global::MPNGGJINIEL<KGGKJGICJLE> ObjectDefinitionId
{
get 		{
			return default;
		}

}

public abstract bool AreCircuitsPersistable
{
get ;
}

public abstract bool IsBeta
{
get ;
}

public abstract bool IsDeveloperOnly
{
get ;
}

public event Action<Chip> VisualizationAcquiredEvent {
add {
		}
remove {
		}
}

public event Action<Chip> VisualizationReleasedEvent {
add {
		}
remove {
		}
}

		private void GLCIFLDAJAE()
		{
		}

		void PHCICIGDDPA.ALCBOOGGMHC()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GLCIFLDAJAE
			this.GLCIFLDAJAE();
		}

		private void LJEPIPPPFJL()
		{
		}

		protected override void Awake()
		{
		}

		private void OnPhotonPlayerConnected(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private void CAMNICJCONN()
		{
		}

		private void CMJOHDHKCKH(in Guid OLNCKNNJIPA, global::MPNGGJINIEL<IPGAKKHFLAO> NJHCIFCMCMI)
		{
		}

		protected abstract void POCNJIOKNDL(LNDJBKINLAJ FJBLCAGJCDO);

		protected override void OnDestroy()
		{
		}

		public void UpdateAttachPointIfAttached(bool HHLOAOKNDPO = false)
		{
		}

		protected void IBEFMJPFNDF(in Vector3 INLGLHIPOMC, in Quaternion HEGBBJCMANH, bool HHLOAOKNDPO = false)
		{
		}

		protected void OGHFFLEDFFD(Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI)
		{
		}

		[PBOMGCLBFHF]
		public void RpcUpdateAttachPoint(Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI)
		{
		}

		public void UpdateControlPanelTransformIfAttached()
		{
		}

		public void Publish(in Guid JJLIIOCLCNA, in IENGILMPFNE IECPCEEBGJM)
		{
		}

		private void OAIJIKLLMAG(bool JIOGPCBICOJ)
		{
		}

		void BOALOIBLNEO.BLEMFKPKIGA(bool JIOGPCBICOJ)
		{
			//ILSpy generated this explicit interface implementation from .override directive in OAIJIKLLMAG
			this.OAIJIKLLMAG(JIOGPCBICOJ);
		}

		private bool IDBIPHMCFHP(DHJLEHBOGBG HNPEBINPOBO)
		{
			return false;
		}

		bool BOALOIBLNEO.NKCBNDEBHIK(DHJLEHBOGBG HNPEBINPOBO)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IDBIPHMCFHP
			return this.IDBIPHMCFHP(HNPEBINPOBO);
		}

		private Transform GJDFAAJKFPC()
		{
			return null;
		}

		Transform BOALOIBLNEO.IPMPHFIAIJC()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GJDFAAJKFPC
			return this.GJDFAAJKFPC();
		}

		public global::FAIKNKAIPLB<OHAJOLBEFND> Self(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		public void RaiseOnReset()
		{
		}

		public virtual void Bind(OEJOPFEPHFI JLPKCGOJDJN)
		{
		}

		public virtual void Unbind()
		{
		}

		public virtual void OnVisualizationAcquired(object JJMNDCAFBDA)
		{
		}

		public virtual void OnVisualizationReleased(object JJMNDCAFBDA)
		{
		}

		public virtual void ConfigureAttachedObject()
		{
		}

		public void LogPositions(string DELCOFCGDFF)
		{
		}

		[CompilerGenerated]
		private object NLCMPJDBANB()
		{
			return null;
		}

		[CompilerGenerated]
		private object CPDLIMKGOHK()
		{
			return null;
		}

		[CompilerGenerated]
		private object JEANJOIJICG()
		{
			return null;
		}
	}
}
