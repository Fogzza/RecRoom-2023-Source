using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Debugging
{
	public class NetworkedPositionDebugger : NetworkedSingletonMonoBehaviour<NetworkedPositionDebugger>
	{
		public enum OMFFPHIKIPE
		{
			LOCAL = 0,
			REMOTE = 1
		}

		public delegate Vector3 BIBKLFKEDEL();

		private sealed class OFHPOBJDOHC : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public bool clear;

			public NetworkedPositionDebugger _003C_003E4__this;

			public string seriesName;

			public Color color;

			public float duration;

			public BIBKLFKEDEL positionProvider;

			public EGGPGCCKPCO schedule;

			private float _003CendTime_003E5__2;

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
			public OFHPOBJDOHC(int _003C_003E1__state)
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

		public const string PREFAB_NAME = "[NetworkedPositionDebugger]";

		[SerializeField]
		private bool clearAll;

		private static bool FOLKIINIGEE;

		private Dictionary<string, JLNKGBCHAOG> LBMOBCMGGDH;

		private Dictionary<string, LKGILLBEJEK> PCHDBIGPHNO;

public static bool IsEnabled
{
get 		{
			return false;
		}

private set {
		}
}

		public void StartRecordingPositions(string EOONHKFILMJ, BIBKLFKEDEL ECHPDNKGCGP, EGGPGCCKPCO FCIEJMLLMJO, Color HMCAFGCGFJF, float FGBPJMKCMAO = 10f)
		{
		}

		private IEnumerator<EGGPGCCKPCO> EILENDCKOFF(string EOONHKFILMJ, BIBKLFKEDEL ECHPDNKGCGP, EGGPGCCKPCO FCIEJMLLMJO, Color HMCAFGCGFJF, bool PFIMNLNCAFF, float FGBPJMKCMAO)
		{
			return null;
		}

		public void SetColor(string EOONHKFILMJ, Color HMCAFGCGFJF)
		{
		}

		[PBOMGCLBFHF]
		private void RpcNetworkedPositionDebuggerSetColor(string EOONHKFILMJ, Color HMCAFGCGFJF)
		{
		}

		private void EIIPALJDJAD(string EOONHKFILMJ, Color HMCAFGCGFJF, OMFFPHIKIPE GLLFHCCFIGK)
		{
		}

		public void AddDataPoint(string EOONHKFILMJ, Vector3 INLGLHIPOMC, bool PFIMNLNCAFF = false)
		{
		}

		[PBOMGCLBFHF]
		private void RpcNetworkedPositionDebuggerAddDataPoint(string EOONHKFILMJ, Vector3 INLGLHIPOMC, float OLCGLMMOFNE, int MOEJHNHJIEP, bool PFIMNLNCAFF)
		{
		}

		private void EDILEMBNHHB(string EOONHKFILMJ, Vector3 INLGLHIPOMC, float OLCGLMMOFNE, int MOEJHNHJIEP, bool PFIMNLNCAFF)
		{
		}

		public void AddSeriesEvent(string EOONHKFILMJ, string EGKGMAKPJHE, Vector3 INLGLHIPOMC, bool PFIMNLNCAFF = false)
		{
		}

		[PBOMGCLBFHF]
		private void RpcNetworkedPositionDebuggerAddSeriesEvent(string EOONHKFILMJ, string EGKGMAKPJHE, Vector3 INLGLHIPOMC, float OLCGLMMOFNE, int MOEJHNHJIEP, bool PFIMNLNCAFF)
		{
		}

		private void FDBDGMDJIHA(string EOONHKFILMJ, string EGKGMAKPJHE, Vector3 INLGLHIPOMC, float OLCGLMMOFNE, int MOEJHNHJIEP, bool PFIMNLNCAFF)
		{
		}

		public void RemoveSeries(string EOONHKFILMJ)
		{
		}

		[PBOMGCLBFHF]
		private void RpcNetworkedPositionDebuggerRemoveSeries(string EOONHKFILMJ)
		{
		}

		private void BKBPCLAIGIA(string EOONHKFILMJ)
		{
		}

		public bool SeriesExists(string EOONHKFILMJ)
		{
			return false;
		}

		public void Clear(string EOONHKFILMJ)
		{
		}

		[PBOMGCLBFHF]
		private void RpcNetworkedPositionDebuggerClear(string EOONHKFILMJ)
		{
		}

		private void LPBNNNGFPIF(string EOONHKFILMJ)
		{
		}

		public void ClearAll()
		{
		}

		[PBOMGCLBFHF]
		private void RpcNetworkedPositionDebuggerClearAll()
		{
		}

		private void PLMKGIAILFH()
		{
		}

		private void JAAOBDDGJCJ()
		{
		}
	}
}
