using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using RecRoom.Core.Creation.CircuitsV1;
using RecRoom.Persistence;
using UnityEngine;

namespace RecRoom.Core.Creation.SandboxGizmos
{
	public class AnimationGizmo : MonoBehaviourPun
	{
		public static readonly List<AnimationGizmo> All;

		private bool CPODDGKILJA;

		[SerializeField]
		private BigDataTrackedObject bigDataTrackedObject;

		[SerializeField]
		private PersistenceView persistenceView;

		[SerializeField]
		private Tool _tool;

		[SerializeField]
		private ConnectionPoint animatedObjectsConnectionPoint;

		private DGHMNBOOMCA JODFLKMLBBD;

		private KJBMDKDEOEM GBNLIMPJGAP;

		[SerializeField]
		private AnimatedObjectsGroup _animatedObjects;

		private bool? OHNAANJILMP;

		private CircuitNodeDisplay OPNGMCHEAGF;

public bool WaitingForData
{
get 		{
			return false;
		}

set {
		}
}

public BigDataTrackedObject BigDataTrackedObject
{
get 		{
			return null;
		}

}

public PersistenceView PersistenceView
{
get 		{
			return null;
		}

}

public Tool Tool
{
get 		{
			return null;
		}

}

public ConnectionPoint AnimatedObjectsConnectionPoint
{
get 		{
			return null;
		}

}

public DGHMNBOOMCA Data
{
get 		{
			return null;
		}

private set {
		}
}

public KJBMDKDEOEM Tracker
{
get 		{
			return null;
		}

private set {
		}
}

public AnimatedObjectsGroup AnimatedObjects
{
get 		{
			return null;
		}

}

		public Transform GetAnimRootTransform()
		{
			return null;
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected void Start()
		{
		}

		public void UpdateAnimation(bool CIHBPMGECCO, bool CIGAAOHAKOJ, bool NNEHKIFBJME)
		{
		}

		public void UpdateObjectTransforms(bool CEPPJBDCHEG, bool LDJKGPADLOL = false)
		{
		}

		public bool GetKeyFrameAt(int CFDAOCDCJEM, int DHNPIPEPHBL, float AJIDPJCLDFG, out Vector3 ENLGBNIAHIK, out Quaternion OPBOJKBGNOH)
		{
			ENLGBNIAHIK = default;
			OPBOJKBGNOH = default;
			return false;
		}

		public void InsertKeyFrame()
		{
		}

		public bool CanRemoveKeyFrame()
		{
			return false;
		}

		public void RemoveKeyFrame()
		{
		}

		public void CaptureKeyFrame()
		{
		}

		private void EEMKEEPNOBK()
		{
		}

		private void HBBCJNLKLLD()
		{
		}

		protected virtual void EKCDJIKBJJG(LMKFOACECEG? IEMMIFODLAI)
		{
		}

		private void IMMJONONJHO(ConnectionPoint PCJINKBIFLC, ConnectionPoint HLBJDAGMEND, ConnectionPoint.ININJKAJDDN ONAFALABHKI = null)
		{
		}

		public bool AddAnimatedObject(DHJLEHBOGBG ICHBECDKHOJ)
		{
			return false;
		}

		public bool RemoveAnimatedObject(DHJLEHBOGBG ICHBECDKHOJ)
		{
			return false;
		}

		public bool RequestAuthorityRemoveAnimatedObject(DHJLEHBOGBG ICHBECDKHOJ)
		{
			return false;
		}

		[PBOMGCLBFHF]
		public void AuthorityRemoveAnimatedObject(MonoBehaviour ANIDFMMGDIH)
		{
		}

		public void CircuitSignalUpdated(Dictionary<EDBMANFHGGO, int> signals)
		{
		}

		[PBOMGCLBFHF]
		private void RpcAnimationGizmoReset()
		{
		}

		public IMFIBJPNBHM Serialize()
		{
			return null;
		}

		public void LocalLoadAnimationData(IMFIBJPNBHM ABBIKMAKMJO, short AJMCKPPKOFJ)
		{
		}

		protected void MNECEOLGCKC()
		{
		}

		public void AuthoritySendData()
		{
		}

		public void AuthoritySendAllFrames()
		{
		}

		[PBOMGCLBFHF]
		protected void RpcSetAnimationData(OIFOGCPFPPB PCPEJHIMHJJ, short AJMCKPPKOFJ)
		{
		}

		[CompilerGenerated]
		private int EANLIIBPMFN()
		{
			return 0;
		}

		[CompilerGenerated]
		private void CAAHBMABKFL(int DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private int FJAILFNOGLB()
		{
			return 0;
		}

		[CompilerGenerated]
		private void EJJJNDLDLIE(int DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private bool JPGPNGKLPGA()
		{
			return false;
		}

		[CompilerGenerated]
		private void BCJJFJIFGCM(bool DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private bool HAOAOBAJBLB()
		{
			return false;
		}

		[CompilerGenerated]
		private void HKBHFDPFFHM(bool DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private bool DOGHFOFDHBH()
		{
			return false;
		}

		[CompilerGenerated]
		private void BIPFOOHEBFK(bool DGAGNFOEEIJ)
		{
		}
	}
}
