using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RecRoom.Core.Creation.Holotars
{
	public class HolotarCV1 : HolotarBase
	{
		private sealed class MNAGLCMEIAF : IEnumerable<DGMPBIPKJEB>, IEnumerable, IEnumerator<DGMPBIPKJEB>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private DGMPBIPKJEB _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public HolotarCV1 _003C_003E4__this;

 DGMPBIPKJEB global::System.Collections.Generic.IEnumerator<global::DGMPBIPKJEB>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRRUI_002EData_002EIDynamicUIElementData_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public MNAGLCMEIAF(int _003C_003E1__state)
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
			private DGMPBIPKJEB System_002ECollections_002EGeneric_002EIEnumerator_003CRRUI_002EData_002EIDynamicUIElementData_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<DGMPBIPKJEB> IEnumerable<DGMPBIPKJEB>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[SerializeField]
		private HolotarCircuitNodeDisplay circuitDisplay;

		[SerializeField]
		private HolotarProjector projector;

		[SerializeField]
		private Renderer[] fxRenderers;

		[SerializeField]
		private GameObject[] fxGameObjects;

		private global::MOBDJNEDDKC<bool> DDANJKAOAJO;

		private HolotarCircuitNodeDisplay.KNFBMOGEJOK KKADKOIJHLO;

		private bool NEDDCCANNFE;

public bool HideProjector
{
get 		{
			return false;
		}

set {
		}
}

public override bool IsReadyForPlayback
{
get 		{
			return false;
		}

}

public override bool IsPlaybackStopped
{
get 		{
			return false;
		}

}

private ProjectorBase.DAOCECJKNIJ ILOLKGOCLJK
{
get 		{
			return ProjectorBase.DAOCECJKNIJ.Default;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected override IEnumerable<DGMPBIPKJEB> ONAJDNHGOJA()
		{
			return null;
		}

		protected override void JAJLGFPEAMP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected override void BIECDJOHMCP(ushort ANAKIMJNHMH, ushort KJLHJFEJJGM)
		{
		}

		protected override void CNGBCMDPFOH()
		{
		}

		protected override void FPDAMENHOML()
		{
		}

		protected void NJEINHLIFHB(ProjectorBase.DAOCECJKNIJ NODMBBGCLFD)
		{
		}

		protected override void HICMIPHDOHF()
		{
		}

		protected override void JDAOFNOOMFA(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
		{
		}

		private void ANFBAFHKCHE()
		{
		}

		private void DICLHJAALKP()
		{
		}

		private void LJKFHHJCJMJ(HolotarCircuitNodeDisplay.KNFBMOGEJOK DNLPIHIBJDP)
		{
		}

		private void LAFNGIMPPFA()
		{
		}

		protected override void GLJMBIOFPBG()
		{
		}

		protected override void MKEMEBAFJBH(PFMAFCHDGJL GEBEJEKEBJK)
		{
		}

		protected override void LIIIGKOOMHN(PFMAFCHDGJL GEBEJEKEBJK)
		{
		}

		protected override void OnDestroy()
		{
		}

		[CompilerGenerated]
		private bool IIIEELBHPEH()
		{
			return false;
		}

		[CompilerGenerated]
		private void MLBMIMELIMI(bool IPMIIEAGJKC)
		{
		}
	}
}
