using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.CircuitsV2.GraphNodes;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class ParticleEmitterV2 : MonoBehaviourPun, GFLPAFBGELM, NEKJJEGPHFG, DJLCHGFCFAD, PJINIJOHANN
	{
		private sealed class LIAAIGCAMDJ : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public ParticleEmitterV2 _003C_003E4__this;

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
			public LIAAIGCAMDJ(int _003C_003E1__state)
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

		public const IALAJKBOKBN DEFAULT_COLLISION_LAYER = IALAJKBOKBN.DynamicPhysicsIgnoreDynamicPhysics;

		[SerializeField]
		private SandboxParticleEffect[] particleEffects;

		private PooledParticle IEDLLBKBEFJ;

		private Dictionary<string, MIBJNNKFLND> IPMOONFODKJ;

		private LKGILLBEJEK CBLBIEHEJMC;

		private CreationObject FOCLAAGDNOI;

		[SerializeField]
		private SandboxColorable sandboxColorable;

		[SerializeField]
		private ControlPanelCircuitObject controlPanelCircuitObject;

		[SerializeField]
		private CreationObject creationObject;

		[SerializeField]
		private SyncedComponentV2 syncComponent;

		private const string ANGEAOLECFD = "Emitter";

		private global::CDLJMENCODC<int> BIIDIKPEKFN;

		private global::CDLJMENCODC<bool> DHMILHOAGJP;

		private global::CDLJMENCODC<float> GPILNOPKILO;

		private global::CDLJMENCODC<float> IHDNCFKCCBH;

		private global::CDLJMENCODC<bool> KOINPHMBKNC;

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

public GMHHJCFIMML CV2CreationObject
{
get 		{
			return null;
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

		private void GFOCMFGOFNC(bool BLOCPPAOJDM)
		{
		}

		void PJINIJOHANN.SetSynchronizing(bool BLOCPPAOJDM)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GFOCMFGOFNC
			this.GFOCMFGOFNC(BLOCPPAOJDM);
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

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetColor(JEGAPHLGBJA GCBHEJANCJK, JLHLKDMLBPK HMCAFGCGFJF)
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
		private bool AGPIHKDIAEO()
		{
			return false;
		}

		[CompilerGenerated]
		private void AOLPNIIICDG(bool MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool OMIPIHDMHLD()
		{
			return false;
		}

		[CompilerGenerated]
		private bool LFGJGHHOGDD()
		{
			return false;
		}

		[CompilerGenerated]
		private float DOHLDNFHOFI()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void HOPAFAEDJAJ(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool NPAEOBCLLFH()
		{
			return false;
		}

		[CompilerGenerated]
		private float IHOCCDPDCJF()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void JFLBADKKFHO(float MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool KKJFCNHGKEJ()
		{
			return false;
		}
	}
}
