using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DistanceFadeManager : SingletonMonoBehaviour<DistanceFadeManager>
{
	private struct OEBDJBFNPMO
	{
		public DistanceFadeController GAKBGNBOOPG;

		public Collider LNDKNKKNELC;

		public Renderer CDLDAEEIHLI;

		public float LILCNLFLACA;

		public bool KDBBIJBDKNO;
	}

	private sealed class INFCNLEFOKI : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public DistanceFadeManager _003C_003E4__this;

		private JNDHCGAMLML _003Cschedule_003E5__2;

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
		public INFCNLEFOKI(int _003C_003E1__state)
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

	private readonly HashSet<DistanceFadeController> BILAJOFEMCM;

	private readonly List<OEBDJBFNPMO> JGHJLJLPGMC;

	private readonly Dictionary<string, Material> MIEKHBICPCA;

	public static readonly int MinFadeDistancePropertyId;

	public static readonly int MaxFadeDistancePropertyId;

	private void Start()
	{
	}

	private IEnumerator<EGGPGCCKPCO> GAHHBGJBCCA()
	{
		return null;
	}

	public void Register(DistanceFadeController IJIAEDONGKE, IEnumerable<Renderer> KJJMMGMBOFO, Collider ADMCDJKKCIA)
	{
	}

	public void Unregister(DistanceFadeController IJIAEDONGKE)
	{
	}
}
