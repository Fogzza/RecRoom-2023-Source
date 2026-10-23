using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class SandboxSet : MonoBehaviourPun
	{
		[Serializable]
		public struct SandboxSetPiece
		{
			public SerializedGuid equipmentId;

			public Vector3 initPosition;

			public Quaternion initRotation;

			public JBGFOIKBKED equipment => JBGFOIKBKED.AC_UNIT;
		}

		[SerializeField]
		private SandboxSetPiece[] pieces;

		[SerializeField]
		private Tool _tool;

public Tool Tool
{
get 		{
			return null;
		}

}

public IEnumerable<SandboxSetPiece> PieceData
{
get 		{
			return null;
		}

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

		private void BMHLAECFNBF(CreationObject NJLMPBHEFML)
		{
		}

		private void JFGMIGPAJNO(Tool IEGMBEPJMGC)
		{
		}

		protected virtual IEnumerable<Tool> BELKEFLNPPG()
		{
			return null;
		}

		private void OnDrawGizmos()
		{
		}

		[CompilerGenerated]
		private void JDIDBBOENAA()
		{
		}
	}
}
