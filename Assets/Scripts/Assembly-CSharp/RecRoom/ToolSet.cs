using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Photon.Pun;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom
{
	public class ToolSet : MonoBehaviourPun, EDJIOCIKNEJ, JMIIPNGAANF
	{
		[Serializable]
		public struct ToolPiece : JMIIPNGAANF
		{
			public Tool tool;

			public Vector3 initPosition;

			public Vector3 initRotationEuler;

			public Quaternion initRotation => default;

			public void AppendToHash(IncrementalHash NDFMMDHCKFC)
			{
			}
		}

		private sealed class FGHILMEKPPG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public ToolSet _003C_003E4__this;

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
			public FGHILMEKPPG(int _003C_003E1__state)
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

		private Action<List<Tool>> LEJHNACEEBJ__BackingField;

		private Action DMLBOPGIHNI__BackingField;

		[SerializeField]
		private ToolPiece[] _pieces;

		[SerializeField]
		private byte[] stableHash;

		[SerializeField]
		private byte[] seed;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private float deploymentDelayTime;

		[SerializeField]
		private RecRoomAudioClip onDeploySFX;

		[SerializeField]
		private AudioRolloff audioRolloff;

		private bool EPHPENAPEKE;

		private bool HCGADIOCGJG;

		private bool DFPFDAJGEBI;

		private bool PFOMEAMJLMC;

		private FIHGBEHGLGB AGGMCPIIEAP;

private bool ECGIJJJAEBB
{
get 		{
			return false;
		}

}

public byte[] StableHash
{
get 		{
			return null;
		}

set {
		}
}

public byte[] Seed
{
get 		{
			return null;
		}

set {
		}
}

public UnityEngine.Object Asset
{
get 		{
			return null;
		}

}

public event Action<List<Tool>> OnPiecesSpawned {
add {
		}
remove {
		}
}

public event Action OnToolSettledUpright {
add {
		}
remove {
		}
}

		private ToolPiece[] IMPIEHJNLOO()
		{
			return null;
		}

		public void AddDeploymentRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveDeploymentRestriction(object IALNODEHBNN)
		{
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

		private void GKKCIIOCJLM()
		{
		}

		private IEnumerator<EGGPGCCKPCO> ACODOEDPKAK()
		{
			return null;
		}

		private void JFGMIGPAJNO(Tool IEGMBEPJMGC)
		{
		}

		private void JFCPPEHPJGL(Tool IEGMBEPJMGC)
		{
		}

		protected void KMNKHOLDLHO()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public void AppendToHash(IncrementalHash NDFMMDHCKFC)
		{
		}

		[CompilerGenerated]
		private void AHMPCELIMJL(float GADDGJANIGG)
		{
		}
	}
}
