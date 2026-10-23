using System;
using System.Collections.Generic;
using Photon.Voice.Unity;
using UnityEngine;

namespace RecRoom.Audio
{
	public class AgPhotonMicListener : MonoBehaviour
	{
		public enum DBLMHIPJKEC
		{
			INVALID = -1,
			FLOAT = 0,
			SHORT = 1
		}

		public abstract class BBOOILGLEAK<T> : global::BAINAIKPPHP<T>, IDisposable
		{
			protected AgPhotonMicListener GDMDNJEACCO;

			public void ALKNKAMGFLC(bool OEGHCCKCOGE)
			{
			}

			public T[] ICMBBDEOBAC(T[] AJCJOJDAPDK)
			{
				return null;
			}

			public abstract void PHBPELBNIKK(T[] AJCJOJDAPDK);

			public void Dispose()
			{
			}
		}

		public class FMPDPJKMKOH : BBOOILGLEAK<float>
		{
			public FMPDPJKMKOH(AgPhotonMicListener GDMDNJEACCO)
			{
			}

			public override void PHBPELBNIKK(float[] AJCJOJDAPDK)
			{
			}
		}

		public class MPNGDEGCBJN : BBOOILGLEAK<short>
		{
			public MPNGDEGCBJN(AgPhotonMicListener GDMDNJEACCO)
			{
			}

			public override void PHBPELBNIKK(short[] AJCJOJDAPDK)
			{
			}
		}

		[SerializeField]
		private Recorder voiceRecorder;

		private FMPDPJKMKOH GPHIFMLHKEL;

		private MPNGDEGCBJN GEFJHFMAAPK;

		private int PKCCODLIECK;

		private int IPCNJDBKKDB;

		private readonly Dictionary<object, Action<ACMFCLCJBAO>> HJPMCHLGMOE;

		private readonly Dictionary<object, Action<GPLABFGBOAM>> EMKKICPPBCF;

		private DBLMHIPJKEC FBCLIDLPHCD;

		private bool OEGHCCKCOGE;

public bool IsListening
{
get 		{
			return false;
		}

}

public DBLMHIPJKEC FrameType
{
get 		{
			return DBLMHIPJKEC.FLOAT;
		}

private set {
		}
}

public bool ProcessWhileMuted
{
set {
		}
}

		public void StartListening(object IALNODEHBNN, Action<ACMFCLCJBAO> ONAFALABHKI)
		{
		}

		public void StartListening(object IALNODEHBNN, Action<GPLABFGBOAM> ONAFALABHKI)
		{
		}

		public void StopListening(object IALNODEHBNN)
		{
		}

		private void LJMOGOONPAA(ACMFCLCJBAO CDPFBDBELHI)
		{
		}

		private void IKGKNJIIGIB(GPLABFGBOAM CDPFBDBELHI)
		{
		}

		private void PhotonVoiceCreated(BJMNEPGAFDB p)
		{
		}
	}
}
