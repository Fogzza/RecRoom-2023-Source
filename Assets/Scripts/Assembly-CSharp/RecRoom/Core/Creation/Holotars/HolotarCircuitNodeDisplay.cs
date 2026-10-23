using System;
using System.Collections.Generic;
using Photon.Pun;
using RecRoom.CircuitsV1;
using RecRoom.Core.Creation.CircuitsV1;

namespace RecRoom.Core.Creation.Holotars
{
	public class HolotarCircuitNodeDisplay : CircuitNodeDisplay
	{
		public enum KNFBMOGEJOK
		{
			DEFAULT_DISCONNECTED = 0,
			DEFAULT_CONNECTED = 1,
			PLAY = 2,
			STOP = 3
		}

		private const EDBMANFHGGO DGNMGFFKGEA = EDBMANFHGGO.R;

		private const EDBMANFHGGO JNHNNGBCKEP = EDBMANFHGGO.G;

		private static readonly InputMetadata[] LMIJKMONNKE;

		private Action<KNFBMOGEJOK> ILCAJOKPDKE__BackingField;

public KNFBMOGEJOK CurrentPlayMode
{
get 		{
			return KNFBMOGEJOK.DEFAULT_DISCONNECTED;
		}

}

private bool MMLDGMEDLMC
{
get 		{
			return false;
		}

}

private bool ABMMBIILMAK
{
get 		{
			return false;
		}

}

public event Action<KNFBMOGEJOK> OnPlayModeChanged {
add {
		}
remove {
		}
}

		public override void OnCircuitNodeInitialized(BNOPDNILAFA KNBPIEINLIG)
		{
		}

		protected override void FLBLLLBEIHC(PhotonView CIPJGOKLPNK)
		{
		}

		private void GJHGCBIGIHB(Dictionary<EDBMANFHGGO, int> KLPFODAMNED)
		{
		}
	}
}
