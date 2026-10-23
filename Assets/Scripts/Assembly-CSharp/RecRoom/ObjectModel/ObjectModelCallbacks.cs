using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Photon.Pun;
using Unity.Collections;
using UnityEngine;

namespace RecRoom.ObjectModel
{
	public class ObjectModelCallbacks : MLOAKDLKONO, IDisposable, CMLEAAEGAAL
	{
		[StructLayout((LayoutKind)3)]
		private struct IKLOBKGLPCB : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ObjectModelCallbacks _003C_003E4__this;

			private TaskAwaiter<BCDAPDDMMEO> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct IGFOPKDCKMD : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ObjectModelCallbacks _003C_003E4__this;

			private Player _003ClocalPlayer_003E5__2;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

			private CEMPCLLNDGG _003CstackTimer_003E5__3;

			private TaskAwaiter<Player> _003C_003Eu__3;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private sealed class OOCCIGBNPAB
		{
			public Action<HPHBHAKAACD, int> callback;

			public HPHBHAKAACD localId;

			internal void _003CRegisterAuthorityChangeCallback_003Eb__0(CHILKDJABBF p)
			{
			}
		}

		private static readonly HDHIMOFHFJL AHADDDAMGKE;

		private string NJDFFJMPJJA;

		private float LKCBINFGHAH;

		private readonly Dictionary<string, object> FLGIBOOJCBO;

		private readonly List<ICGNGPIIFOH> GJJJBEELBPB;

		private readonly Dictionary<GameObject, LNIAAMEHKAH> BBOFNGCIOKC;

		private readonly ObjectModelNetworking GCOGGHDIHNM;

		private readonly EmbodiedObject DALACGBHDAE;

		private LKANKDBMEPH OPMONFEOPPL;

public AJPGDEKAKGN GNFIABACBAC
{
get 		{
			return null;
		}

}

public PLKCJIPEDIM BDBLDIONDCG
{
get 		{
			return null;
		}

}

public bool APAOPCKHKHM
{
get 		{
			return false;
		}

set {
		}
}

public bool NCGOKJIJEBE
{
get 		{
			return false;
		}

set {
		}
}

public string HFDFHBFHLAE
{
get 		{
			return null;
		}

}

public bool IDCJFNFFACN
{
get 		{
			return false;
		}

}

public bool ACCFFPJFKPI
{
get 		{
			return false;
		}

}

public int JKHPBEIJPLF
{
get 		{
			return 0;
		}

}

public bool KMHDMCEGGLI
{
get 		{
			return false;
		}

}

public int NDPCDHIDLHB
{
get 		{
			return 0;
		}

}

		public void PACELKAFLHO(BLBDINABANB LBBJCIBEDFD)
		{
		}

		public void Dispose()
		{
		}

		public void NJOGHHKGALA(bool EBEJHBCBEKC)
		{
		}

		public void JLBICJLGLBP()
		{
		}

		private void IPJBIIBAEBL(GameObject HKPJJHILEBG, NOIGDGIHCIC.CKEBFKEEANI HDHNMJDIGCM)
		{
		}

		public bool AGKPBHGPHJP(GameObject BMNLOPDIJGF, out HCIIHJLICJK MIBPNJCOIHL)
		{
			MIBPNJCOIHL = default;
			return false;
		}

		public bool IPHAEAAMEDL(GameObject BMNLOPDIJGF, out bool CHDIJKEIIDO)
		{
			CHDIJKEIIDO = default;
			return false;
		}

		public bool NJCOAJBLBCB(GameObject BMNLOPDIJGF, out int GKAPDGEAPAN, out CNKGPKGDJHD FNGBDAJENGB)
		{
			GKAPDGEAPAN = default;
			FNGBDAJENGB = default;
			return false;
		}

		public int ACAKHENDGNL(GameObject BMNLOPDIJGF)
		{
			return 0;
		}

		public void NPIMCOFBLHG(object GFCPAMJILIO)
		{
		}

		public void JNPPMFBFKML(object GFCPAMJILIO)
		{
		}

		public void OCKMJLDPNOJ(GameObject BMNLOPDIJGF, bool DHIHGJKBLHN, bool KFAOIJBOEPG)
		{
		}

		public void CKJLOOOHIHJ(object KHKGGNHOCOE)
		{
		}

		public void NMFFBDKGIGE(object KHKGGNHOCOE)
		{
		}

		public bool ANLEABHGKAM(object BBBOEOJJCHM, object OHHMJDNAEKG)
		{
			return false;
		}

		public bool IABILDGNNKA(object FDAIMOMOHIG, out object IPMIIEAGJKC)
		{
			IPMIIEAGJKC = null;
			return false;
		}

		public void CGIAPJOCPMM(GameObject BMNLOPDIJGF)
		{
		}

		public HCIIHJLICJK GNEHKEABMGP(Guid OHILEMGCIHI)
		{
			return default;
		}

		public bool IKANJGBCHOA(IEnumerable<GKJFAKANILO> GDKJDDCKGLO)
		{
			return false;
		}

		public ACPBHPEJKKH MGECIAIDCLM(GKJFAKANILO BEODCPFFPCC)
		{
			return null;
		}

		public ACPBHPEJKKH MGECIAIDCLM(string PEGANFDBJPA, HCIIHJLICJK MIBPNJCOIHL, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JDFDFBKKBPO)
		{
			return null;
		}

		private void IGOOADCKLLF(HCIIHJLICJK MIBPNJCOIHL, Dictionary<string, object> HMJOKPKOPCN)
		{
		}

		private ICGNGPIIFOH HJJGCAMMJGK(GKJFAKANILO BEODCPFFPCC)
		{
			return null;
		}

		private static HCIIHJLICJK ANDMDOJLAPG(GKJFAKANILO BEODCPFFPCC)
		{
			return default;
		}

		private bool KDHKPGEKFNA(GameObject HKPJJHILEBG, PhotonView OGMNKDNMJCB, in LNIAAMEHKAH HMJOKPKOPCN)
		{
			return false;
		}

		public Task PCOMLEKKAGE()
		{
			return null;
		}

		public Task LCBGPKHHMGL()
		{
			return null;
		}

		public void DCEFJAMJADE(Transform FGNGGLFNLIP)
		{
		}

		public void IGHOBKNFGFF(Transform FGNGGLFNLIP, PPKCAMHKMLL LIHCICHMNHE)
		{
		}

		public void AEFPPOHGOCN(Transform FGNGGLFNLIP, LMKFOACECEG IEMMIFODLAI)
		{
		}

		public void JLPIEPFJIDO(GameObject BMNLOPDIJGF, MGILGFFDBGH DJJGPBOHDAO)
		{
		}

		public Vector3 OBLHOONGEAP(GameObject BMNLOPDIJGF, int APFNAOPENNF)
		{
			return default;
		}

		public bool KECPLKANJEB(out Vector3 INLGLHIPOMC)
		{
			INLGLHIPOMC = default;
			return false;
		}

		public void DEEOILGICMI()
		{
		}

		private void JEKMHKEIIJA()
		{
		}

		public void CKGDNGHBLNA()
		{
		}

		public void CEPKDMGEBIH(GameObject BKBFAHMJCAL, bool FBHDABEFLKL)
		{
		}

		public CNKGPKGDJHD MIOCIEEKCDD(GameObject HKPJJHILEBG)
		{
			return CNKGPKGDJHD.None;
		}

		public int BIPFLOEPGLP(GameObject BMNLOPDIJGF)
		{
			return 0;
		}

		public object FHDPJCIGFHA(HPHBHAKAACD EHNNHDBEJOG, GameObject BMNLOPDIJGF, Action<HPHBHAKAACD, int> ONAFALABHKI)
		{
			return null;
		}

		public void JFMKILDOEEJ(GameObject BMNLOPDIJGF, object OHCNCHBJJIP)
		{
		}

		public void JKACEPJEHJN(GameObject BMNLOPDIJGF)
		{
		}

		public void JPGKLDPJCFK(GNFJJEDLPLM GGDPNBMCEHC)
		{
		}

		public void ELKJGNANKPE(GameObject HKPJJHILEBG)
		{
		}

		public void PGJNLKJFOJP(string OFCFPGACNJB)
		{
		}

		public int AKCFKHIDPNO(GameObject HKPJJHILEBG)
		{
			return 0;
		}

		public void AELIGADFGMN(NativeArray<int> NBMAMFKLAFJ)
		{
		}
	}
}
