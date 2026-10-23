using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace RecRoom.Players
{
	[DisallowMultipleComponent]
	public class PlayerBackpack : MonoBehaviour
	{
		private class KPIJDLIHODB : global::INEAOPIKBME<Tool>
		{
			private readonly Tool IEGMBEPJMGC;

			public KPIJDLIHODB(Tool IEGMBEPJMGC)
			{
			}

			private void JFABBDIHHBN()
			{
			}

			private void HEBGJGMCHEK(Tool IEGMBEPJMGC)
			{
			}

			private void MBIOLEBFOOM(Tool PMEFICGEDFK, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
			{
			}

			private void NHKAEEIGGNO(Tool IHPJCBCPLCM)
			{
			}

			private void FADINDBDBGA(Tool OCAGBEKHKKH)
			{
			}

			[CompilerGenerated]
			private void DFAOJFFHECE(string JDDIAEIMOBB)
			{
			}
		}

		private sealed class FDJCHPPAIOM
		{
			public Tool tool;

			internal void _003CSetupBackpackTool_003Eb__0()
			{
			}
		}

		private sealed class NNBHGFEKAIN : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public float seconds;

			public Action function;

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
			public NNBHGFEKAIN(int _003C_003E1__state)
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

		private const string PJIHLBIILNP = "BACKPACK_FAVORITE_TOOL";

		private static readonly Vector3 KPKMPMGLFPD;

		private Dictionary<BKMDFCCNPGE, Tool> FJCHAOOPCND;

		[NonSerialized]
		public Player LocalPlayer;

		public global::KAJFMPHPBGO<Tool, BKMDFCCNPGE, bool, bool> BackpackToolEnabledChange;

		public global::HHOBPMOCKMJ<BKMDFCCNPGE> BackpackFavoriteToolChange;

		public global::HHOBPMOCKMJ<BKMDFCCNPGE> BackpackToolGrabbed;

		private FIHGBEHGLGB HGNBDDDHABK;

		private IDisposable CNAGCKBFLOE;

		private Tool FKNLABMGPCM;

		private BKMDFCCNPGE FFFAAIJAFGC;

		private BHNJIBDJFAL NJPJBDDAEFH;

private Tool IBAGCOEEALB
{
get 		{
			return null;
		}

set {
		}
}

public BKMDFCCNPGE FavoriteToolType
{
get 		{
			return BKMDFCCNPGE.SHARE_CAM;
		}

}

		private void Awake()
		{
		}

		private void NMANBJJJCNA()
		{
		}

		private void MIKDKFMNGOP()
		{
		}

		private void JBDNKMNFNBD()
		{
		}

		private Task OHEMEIEGBCI(AHDBIFJNDCH ADCFFAJGNAM, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private Task OAGKFDBKKAJ(AHDBIFJNDCH ADCFFAJGNAM, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private void KIIOBICCLKK()
		{
		}

		private BKMDFCCNPGE LHKPLOJJNCE()
		{
			return BKMDFCCNPGE.SHARE_CAM;
		}

		private void LAHIEKELFKN(PlayerBackpackToolConfig.Config FPJKGKBOAOA, Dictionary<string, object> GGNINCPGCFF)
		{
		}

		private static Dictionary<string, object> COBHDBKBOCP()
		{
			return null;
		}

		private void LBPGCFLPPOA(BKMDFCCNPGE CKEPLIBLBFJ, Tool IEGMBEPJMGC)
		{
		}

		private void OPIJCEHJEDB()
		{
		}

		private void OnDestroy()
		{
		}

		private IEnumerator<EGGPGCCKPCO> LPJLHLCPGBD(float BGGBEMDBOHE, Action CFEEHGJEDHI)
		{
			return null;
		}

		public bool IsInBackpack(Tool IEGMBEPJMGC)
		{
			return false;
		}

		public Tool GetBackpackTool(BKMDFCCNPGE CKEPLIBLBFJ)
		{
			return null;
		}

		public BKMDFCCNPGE GetBackpackToolType(Tool IEGMBEPJMGC)
		{
			return BKMDFCCNPGE.SHARE_CAM;
		}

		private void FHPKGBEDANF(Tool IEGMBEPJMGC)
		{
		}

		private void MNJOMAJAKLD(Tool DNAAANDCNJC)
		{
		}

		private void HOAINHMPMOO(Tool BCFIEBGFAFB)
		{
		}

		public void AddDisableFavoriteToolSelection(object IALNODEHBNN)
		{
		}

		public void RemoveDisableFavoriteToolSelection(object IALNODEHBNN)
		{
		}

		public Tool TryGetFavoriteToolForPickup()
		{
			return null;
		}

		public void SetFavoriteTool(BKMDFCCNPGE CKEPLIBLBFJ)
		{
		}

		public bool IsInUse(BKMDFCCNPGE CKEPLIBLBFJ)
		{
			return false;
		}

		public bool UseTool(BKMDFCCNPGE CKEPLIBLBFJ, bool DMNAJJGFEMK = false)
		{
			return false;
		}

		public bool UseToolImmediately(BKMDFCCNPGE CKEPLIBLBFJ)
		{
			return false;
		}

		public bool UseTool(BKMDFCCNPGE CKEPLIBLBFJ, out global::CMMFENAKLIN<Tool> ABGFNLFGOIJ, bool DMNAJJGFEMK = false)
		{
			ABGFNLFGOIJ = null;
			return false;
		}

		public void RecallTool(BKMDFCCNPGE CKEPLIBLBFJ)
		{
		}

		public void RecallTool(Tool IEGMBEPJMGC)
		{
		}

		public void RecallAllTools()
		{
		}

		public static bool CanLocalPlayerEnableTool(BKMDFCCNPGE CKEPLIBLBFJ)
		{
			return false;
		}

		private void DCHGOFGBCEI(BKMDFCCNPGE CKEPLIBLBFJ)
		{
		}

		private bool HAIHJKGGDLH(Tool IEGMBEPJMGC, BKMDFCCNPGE CKEPLIBLBFJ, bool HJLPDLGIFHE, bool OENLCMEDCNI)
		{
			return false;
		}

		private void KJPAJICDMNC(Tool IEGMBEPJMGC, BKMDFCCNPGE CKEPLIBLBFJ)
		{
		}
	}
}
