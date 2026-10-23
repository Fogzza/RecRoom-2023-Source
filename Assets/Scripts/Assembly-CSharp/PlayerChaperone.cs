using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerChaperone : MonoBehaviour
{
	private sealed class CLAMPILACFN
	{
		public Vector3[] borderCorners;

		internal void _003CBuildMesh_003Eb__0(Vector3[] c)
		{
		}
	}

	private sealed class KNBLJBJHGPF : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerChaperone _003C_003E4__this;

		private CLAMPILACFN _003C_003E8__1;

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
		public KNBLJBJHGPF(int _003C_003E1__state)
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
	private float lineThickness;

	[SerializeField]
	private Material material;

	[SerializeField]
	private MeshRenderer chaperoneBoundsRenderer;

	[SerializeField]
	private MeshRenderer chaperoneCenterRenderer;

	[SerializeField]
	private float centerRaycastDistance;

	private MeshFilter KDNGOCNPJIO;

	private Mesh JIBKBAILCEC;

	private Vector3[] EBMLPFHDHMP;

	private Player PGKEHBCKJKI;

	private bool LKOHGPPBJLE;

	[NonSerialized]
	public bool RoomCenterVisualEnabled;

	private static RaycastHit[] EACEAFFKCMI;

	private OHBPOABNLHE KDLABFIPIHH;

public bool ShowCurrentBounds
{
get 	{
		return false;
	}

set {
	}
}

	private void Awake()
	{
	}

	private OHBPOABNLHE OPGLJOMHIOK()
	{
		return null;
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	private static Vector3 GOHONPLFNBM(int BEBMLJIDPAP)
	{
		return default;
	}

	private void JJKKFGEKHOF(bool FBHDABEFLKL)
	{
	}

	private void OnEnable()
	{
	}

	private IEnumerator BALNKGHGAJI()
	{
		return null;
	}

	private void BHKLFBJLIIN(Vector3[] KECLAJGGJIG)
	{
	}

	public bool IsInBounds()
	{
		return false;
	}
}
