using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace RecRoom.Platforms.IOS
{
	public class IOSVRDeviceManager : VRDeviceManager
	{
		private sealed class OEBCFNFPLGO : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public OEBCFNFPLGO(int _003C_003E1__state)
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

		public static readonly string[] SUPPORTED_DEVICES;

		private const string FNAPNEKDICL = "iOS";

protected override IEnumerable<string> IKHFHMMJAHO
{
get 		{
			return null;
		}

}

protected override string GLDPEGBBFLC
{
get 		{
			return null;
		}

}

protected override bool MFPPFGPJBDH
{
get 		{
			return false;
		}

}

protected override bool FNDJHHHEENO
{
get 		{
			return false;
		}

}

protected override bool IJJCNFLENBL
{
get 		{
			return false;
		}

}

		protected override IEnumerator<EGGPGCCKPCO> NIHHKDMBJFM()
		{
			return null;
		}

		protected override void ELKBNLIOBOM(bool EGJEBAFNALL)
		{
		}

		protected override void OHKBILOMAHP()
		{
		}
	}
}
