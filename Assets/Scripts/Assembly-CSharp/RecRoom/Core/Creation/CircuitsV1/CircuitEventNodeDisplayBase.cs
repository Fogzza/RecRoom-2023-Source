using System;
using System.Collections.Generic;
using Photon.Pun;
using RecRoom.CircuitsV1;
using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public abstract class CircuitEventNodeDisplayBase : CircuitNodeDisplay, LHGCLOHKAOA, CNDJGHOBHEC
	{
		[SerializeField]
		protected bool fireEventOnMasterOnly;

		public float eventRateLimitTime;

		protected float OJOKPFNOKLO;

		[SerializeField]
		private bool resendRateLimitedInputs;

		private IDisposable OBECBJCGHMB;

		private Dictionary<EDBMANFHGGO, int> AMKEHOLEHBB;

		private Dictionary<EDBMANFHGGO, int> IHAIAGLAHJG;

public abstract InputMetadata[] InputMeta
{
get ;
set ;
}

public virtual OutputMetadata[] OutputMeta
{
get 		{
			return null;
		}

set {
		}
}

		public override void OnCircuitNodeInitialized(BNOPDNILAFA KNBPIEINLIG)
		{
		}

		private void FFABLAKIGPO(float OKBAJEAPIHG)
		{
		}

		public void TryResendLatestOrDefaultInputs()
		{
		}

		protected override void FLBLLLBEIHC(PhotonView CIPJGOKLPNK)
		{
		}

		private void GJHGCBIGIHB(Dictionary<EDBMANFHGGO, int> KLPFODAMNED)
		{
		}

		protected abstract void BOIENBABEHB(Dictionary<EDBMANFHGGO, int> KLPFODAMNED);
	}
}
