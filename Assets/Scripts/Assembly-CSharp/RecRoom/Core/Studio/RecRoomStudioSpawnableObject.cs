using System;
using System.Text;
using RecRoom.CircuitsV2.GraphNodes;
using UnityEngine;

namespace RecRoom.Core.Studio
{
	[DisallowMultipleComponent]
	public class RecRoomStudioSpawnableObject : MonoBehaviour, DJLCHGFCFAD, GAAKCFPLMHN
	{
		private sealed class ODHLFGKFBGB
		{
			public string eventName;

			internal bool _003COnSendCircuitsEvent_003Eb__0(MBMMGLKOENP ced)
			{
				return false;
			}
		}

		[SerializeField]
		private ControlPanelCircuitObject controlPanelCircuitObject;

		[SerializeField]
		private RecRoomObjectPhysics recRoomObjectPhysics;

		[SerializeField]
		[HideInInspector]
		private SerializedGuid prefabId;

		[SerializeField]
		[HideInInspector]
		private string prefabName;

		[HideInInspector]
		[SerializeField]
		private GameObject contentTemplate;

		[SerializeField]
		[HideInInspector]
		private RecRoomObject contentInstance;

public Guid PrefabId
{
get 		{
			return default;
		}

set {
		}
}

public string PrefabName
{
get 		{
			return null;
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

		private void Awake()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		public void SetContentTemplate(GameObject AKIMFAIHICC)
		{
		}

		public void ResetObject()
		{
		}

		private void AMIPJMPBFCM()
		{
		}

		private void CABKPOPJBHG(RecRoomObject GLLFHCCFIGK, string EGKGMAKPJHE)
		{
		}

		public void SetupConnectionsToContent()
		{
		}

		private void EJAEFALJJGB()
		{
		}

		private void FHJFDFKMPKD()
		{
		}

		private void LAMHKPPNCJH()
		{
		}
	}
}
