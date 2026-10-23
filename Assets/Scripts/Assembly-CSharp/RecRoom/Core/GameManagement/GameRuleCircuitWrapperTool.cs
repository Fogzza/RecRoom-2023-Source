using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Photon.Pun;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.CircuitsV1;
using UnityEngine;

namespace RecRoom.Core.GameManagement
{
	public abstract class GameRuleCircuitWrapperTool : MonoBehaviourPun, DJLCHGFCFAD
	{
		private class FGNHHIFHBHL<T>
		{
			private readonly GameRuleCircuitWrapperTool BJLCMBOAAJD;

			private readonly Func<T> GOIOJEGDINC;

			private readonly Action<T> FKHGIDOBCCH;

			public FGNHHIFHBHL(GameRuleCircuitWrapperTool BJLCMBOAAJD, Func<T> GOIOJEGDINC, Action<T> FKHGIDOBCCH)
			{
			}

			public T HHCPOGCCGNF()
			{
				return default;
			}

			public void PLCAKFAMFIL(T IPMIIEAGJKC)
			{
			}
		}

		private sealed class JKCEOHGPIDN : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public GameRuleCircuitWrapperTool _003C_003E4__this;

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
			public JKCEOHGPIDN(int _003C_003E1__state)
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

		protected const int PNHMIACJMAB = 1000;

		private const EDBMANFHGGO KNHEPCLGNJE = EDBMANFHGGO.R;

		[SerializeField]
		protected Tool tool;

		[SerializeField]
		private CircuitEventNodeDisplay circuitEventNode;

		[SerializeField]
		private GameRuleManager gameRulePrefab;

		[SerializeField]
		private GameConfigurationTool autoConnectToConfig;

		[SerializeField]
		private GameConfigurationAsset autoApplyConfigurationOnConnect;

		private NHHLFODJEFP EDHFBOLKCIF;

		private bool DFJKPJBNJKD;

		private global::DAHHPCNLCBH<GameRuleManager> DHIIABHKOEF;

		private global::MOBDJNEDDKC<bool> IFFBLAIEAFO;

		public static List<GameRuleCircuitWrapperTool> AllGameRuleWrappers;

public GameRuleManager GameRuleManager
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsPoweredOn
{
get 		{
			return false;
		}

}

public bool IsActive
{
get 		{
			return false;
		}

set {
		}
}

public virtual NJOGGCOMCJG ModeType
{
get 		{
			return NJOGGCOMCJG.MODE_1;
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

		protected sealed override void Awake()
		{
		}

		protected abstract void AHIEHLEBIJI();

		protected virtual void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private IONEOHGOAML EPHINAHLLEM(CreationObject FHDPOGAOHBN)
		{
			return IONEOHGOAML.Success;
		}

		protected void LLJDKGIBFPB()
		{
		}

		private void BGFMEGIAHLD()
		{
		}

		private void HOPFOCBGOHI()
		{
		}

		private void DFAHPNCJNHB(GameRuleManager HDEADEMJOIM)
		{
		}

		protected virtual void LJNKMIOFLFO()
		{
		}

		private void LCJLPLLDGME()
		{
		}

		private void ILLFCBMDBBM(NHHLFODJEFP PCPEJHIMHJJ)
		{
		}

		protected virtual void JICFECBLODD()
		{
		}

		protected void EHFKEHOJKIO(string HLIGBKANEEA, Func<bool> GOIOJEGDINC, Action<bool> FKHGIDOBCCH, int LAGADKBKLAD, AKCHPHOMHLH PPLLHFPPIPO)
		{
		}

		protected void FNFPNNELJMJ(string HLIGBKANEEA, Func<float> GOIOJEGDINC, Action<float> FKHGIDOBCCH, int LAGADKBKLAD, AKCHPHOMHLH PPLLHFPPIPO)
		{
		}

		protected void KKOKMCGGEMK(string HLIGBKANEEA, Func<int> GOIOJEGDINC, Action<int> FKHGIDOBCCH, int LAGADKBKLAD, AKCHPHOMHLH PPLLHFPPIPO)
		{
		}

		protected void FIAHAFFAAHG(string HLIGBKANEEA, Type DMEJENAJNCG, Func<int> GOIOJEGDINC, Action<int> FKHGIDOBCCH, int LAGADKBKLAD, AKCHPHOMHLH PPLLHFPPIPO)
		{
		}

		private void FBGGKGJDBPL()
		{
		}

		private IEnumerator<EGGPGCCKPCO> CCDEDFEFJJA()
		{
			return null;
		}

		private void KFFPFPBFIDP()
		{
		}

		private void OGNLEPBOKKP()
		{
		}

		public void MasterDisconnectCircuitInput()
		{
		}

		private void HEBGLFNILCJ(BNOPDNILAFA KNBPIEINLIG, BHEOAPLBNIE HHOGFBCFGAB)
		{
		}

		private void DICLHJAALKP()
		{
		}

		private void GGAECFJGHDG()
		{
		}

		private void ODFBIOCDFLN()
		{
		}

		private void OnPhotonPlayerConnected(CHILKDJABBF DEODPCHAFKO)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcDeserializeRuleData(NHHLFODJEFP PCJACIABNOM)
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		protected virtual void DeserializeFrom(NHHLFODJEFP KHFMJCJDHHD)
		{
		}

		protected virtual void NNLIBKFFFJN(ref NHHLFODJEFP KHFMJCJDHHD)
		{
		}
	}
}
