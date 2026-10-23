using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class AttachedHandle : VehicleControl
{
	private sealed class DLAIKDKOEFJ : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public AttachedHandle _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public DLAIKDKOEFJ(int _003C_003E1__state)
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

	[SerializeField]
	protected Tool tool;

	private readonly string LGKMOEHCOOP;

public Tool Tool
{
get 	{
		return null;
	}

}

protected virtual string EKJCBGGAFCG
{
get 	{
		return null;
	}

}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	protected override void GLNCBIJEHEI(CHILKDJABBF HIGOLKPFBPL)
	{
	}

	public override void Release()
	{
	}

	private bool GBGNFDAOLMP(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
	{
		return false;
	}

	public void DelayedReleaseTool()
	{
	}

	private IEnumerator<EGGPGCCKPCO> CONKMGBJOEI()
	{
		return null;
	}
}
