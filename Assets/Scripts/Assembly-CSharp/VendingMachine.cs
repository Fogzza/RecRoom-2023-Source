using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using RecRoom.Audio;
using UnityEngine;

public class VendingMachine : MonoBehaviourPun
{
	private sealed class APBBOOCMIGC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public VendingMachine _003C_003E4__this;

		public Tool productToRelease;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public APBBOOCMIGC(int _003C_003E1__state)
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
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private Transform productReleaseTransform;

	[SerializeField]
	private ToolPool productPool;

	[SerializeField]
	private float timeBeforeProductDrop;

	[SerializeField]
	private RecRoomAudioClip machineFunctionAudioClip;

	[SerializeField]
	private RecRoomAudioClip productDropAudioClip;

	[SerializeField]
	private RecRoomAudioClip machineEmptyAudioClip;

	private const float KJBBEFDKMMJ = 3f;

	private float IOEGNIMCIJP;

	private const float EMPOLCHNEKN = 5f;

	private float PPMLOJANLHM;

	private Animator CBCFEAPCGEO;

	private static readonly int[] HAEKJCHFKHC;

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void OnVendingButtonPressed(int buttonIndex)
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterRequestProductRelease()
	{
	}

	private IEnumerator GCMCCIMDKHE(Tool NCIMPKCDHEI)
	{
		return null;
	}

	[PBOMGCLBFHF]
	private void RpcOnProductRelease(bool EGJEBAFNALL)
	{
	}

	private void NMPMOGIBFJC(Tool GNKAHDKDIDE, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
	{
	}
}
