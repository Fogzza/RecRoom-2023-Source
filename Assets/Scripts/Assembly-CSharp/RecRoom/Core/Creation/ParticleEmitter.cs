using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.CircuitsV2.GraphNodes;
using RecRoom.Core.Creation.CircuitsV1;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class ParticleEmitter : MonoBehaviourPun, DJLCHGFCFAD, GFLPAFBGELM
	{
		private sealed class LHLELNDAPDA : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public ParticleEmitter _003C_003E4__this;

			private bool? _003CparticleSystemLooping_003E5__2;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public LHLELNDAPDA(int _003C_003E1__state)
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
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private const EDBMANFHGGO JFHNBHCKOBG = EDBMANFHGGO.C;

		private const EDBMANFHGGO PMNIIFGIDHJ = EDBMANFHGGO.M;

		private const EDBMANFHGGO OMJAMBPGLHI = EDBMANFHGGO.Y;

		private const EDBMANFHGGO HEOBPIPEBNB = EDBMANFHGGO.K;

		[SerializeField]
		private SandboxParticleEffect[] particleEffects;

		private PooledParticle IEDLLBKBEFJ;

		private Dictionary<string, MIBJNNKFLND> IPMOONFODKJ;

		private LKGILLBEJEK CBLBIEHEJMC;

		private CreationObject FOCLAAGDNOI;

		[SerializeField]
		private SandboxColorable sandboxColorable;

		[SerializeField]
		private CircuitEventNodeDisplay circuitNode;

		[SerializeField]
		private ControlPanelCircuitObject controlPanelCircuitObject;

		private global::CDLJMENCODC<int> BIIDIKPEKFN;

		private global::CDLJMENCODC<bool> DHMILHOAGJP;

		private global::CDLJMENCODC<int> CIKFMAEAFOK;

		private global::CDLJMENCODC<float> GPILNOPKILO;

		private global::CDLJMENCODC<float> IHDNCFKCCBH;

		private global::CDLJMENCODC<bool> KOINPHMBKNC;

		private global::MOBDJNEDDKC<bool> KNAFLNPMHGF;

public int CurrentEffectIndex
{
get 		{
			return 0;
		}

set {
		}
}

public bool CircuitOn
{
get 		{
			return false;
		}

set {
		}
}

public int CircuitColorId
{
get 		{
			return 0;
		}

set {
		}
}

public float EffectScaleFactor
{
get 		{
			return 0f;
		}

set {
		}
}

public float AnimationSpeed
{
get 		{
			return 0f;
		}

set {
		}
}

public bool SandboxLooping
{
get 		{
			return false;
		}

set {
		}
}

public bool UseSandboxRecolor
{
get 		{
			return false;
		}

set {
		}
}

public bool IsPlaying
{
get 		{
			return false;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

public bool IsCircuitsV2
{
get 		{
			return false;
		}

}

public global::MPNGGJINIEL<KGGKJGICJLE> ObjectDefinitionId
{
get 		{
			return default;
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

		private int PEFFBDDFFCO()
		{
			return 0;
		}

		private void KHMGPDLGFJO(int DLEMNBPMGBG)
		{
		}

		private bool CAACGDMFNOI()
		{
			return false;
		}

		private void NAABOGAMJDB(bool DLEMNBPMGBG)
		{
		}

		private bool LOIGPNAILLC()
		{
			return false;
		}

		private void LIJPMICGMBI(bool DLEMNBPMGBG)
		{
		}

		private void KGECHLHLFAB()
		{
		}

		private void DCMMKGBBNBF()
		{
		}

		private void CKBKNNIKLJA()
		{
		}

		private void ODPIFNFCODO()
		{
		}

		private int HPGMOFILNEG(Guid JMIFIJDBMNM)
		{
			return 0;
		}

		private void DHPAONNNCIM()
		{
		}

		private void PMEGMHMMBGL(bool HOAFHCNAGLB)
		{
		}

		private IEnumerator<EGGPGCCKPCO> IPJBDNLNHFL()
		{
			return null;
		}

		private void HPOPICGCACF()
		{
		}

		private void KDOJGMGJDAH()
		{
		}

		public void EmitSignalReceived(Dictionary<EDBMANFHGGO, int> updates)
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2Start(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2Stop(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetLooping(JEGAPHLGBJA GCBHEJANCJK, bool DHKKPOBDELG)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetSize(JEGAPHLGBJA GCBHEJANCJK, float CAPKFCHDLFA)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetSpeed(JEGAPHLGBJA GCBHEJANCJK, float DMIPMFMPLAP)
		{
			return default;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetColor(JEGAPHLGBJA GCBHEJANCJK, int HMCAFGCGFJF)
		{
			return default;
		}

		private global::FAIKNKAIPLB<OHAJOLBEFND> DCBNIOPDHIN(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		global::FAIKNKAIPLB<OHAJOLBEFND> GFLPAFBGELM.Self(JEGAPHLGBJA GCBHEJANCJK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DCBNIOPDHIN
			return this.DCBNIOPDHIN(GCBHEJANCJK);
		}

		[CompilerGenerated]
		private bool IBLHEJJDGKC()
		{
			return false;
		}

		[CompilerGenerated]
		private bool DMJFHDPNIPG()
		{
			return false;
		}
	}
}
