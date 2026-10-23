using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using RecRoom.Core.Creation.SceneMoods.MoodBlendData;
using RecRoom.Core.Scene;
using RecRoom.Systems.PlayerRoles;

namespace RecRoom.CircuitsV2.RoomSettings
{
	public abstract class RoomMoodBase<T, U, V> : RoomElementBase, PJINIJOHANN, OJIHDJHLFFI, GAAKCFPLMHN where T : MoodBlendData<T> where U : global::KLEHLMGBIDJ<U>
	{
		private enum KFFNHPGIMHL
		{
			Enabled = 0,
			Disabled = 1
		}

		[StructLayout((LayoutKind)3)]
		private struct IIFFAHOCEOK : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public RoomMoodBase<T, U, V> _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

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

		private global::MOMJAPFGODO<bool, int, float> OOAFEJNNJOM;

		private global::CDLJMENCODC<int> LAGADKBKLAD;

		private global::CDLJMENCODC<float> JPFBBGIAHMH;

		private global::CDLJMENCODC<bool> JBJBAMIAIII;

		private global::CDLJMENCODC<int> FFOMPPBNPLP;

		private global::CDLJMENCODC<Guid[]> LGEIKKCKJHH;

		private global::CDLJMENCODC<Guid> IGDNNGJINDK;

		private global::MOBDJNEDDKC<bool> HKEHIIJKHII;

		private float JEAKLIOLJOL;

		private float BGBHCONDLEL;

		private bool HDGPNICCKBK;

		private IDisposable DMOEGGIFPJE;

		private global::PHLHFLLLDLK<bool> KBPNLLIMCEL;

		protected const int CLGBEHOBKFN = 0;

		protected Guid BABPEOJCHLC;

		protected const float FCJIJLKGPMA = 2f;

		protected const bool NMKIOCGFBEG = true;

		protected Guid[] GMMNAPDAOJE;

		protected bool GNALHAOAHHP;

protected SceneMoodSettings CLNDIDHFEEM
{
get 		{
			return null;
		}

}

protected float EDLGIDKDMCA
{
get 		{
			return 0f;
		}

set {
		}
}

public int Priority
{
get 		{
			return 0;
		}

set {
		}
}

public Guid MoodId
{
get 		{
			return default;
		}

set {
		}
}

public float BlendTime
{
get 		{
			return 0f;
		}

set {
		}
}

protected bool CMAGJMLIIGK
{
get 		{
			return false;
		}

set {
		}
}

protected int CJJIMCDBCLM
{
get 		{
			return 0;
		}

set {
		}
}

protected Guid[] FOGONIOEIAN
{
get 		{
			return null;
		}

set {
		}
}

public int DefaultPriority
{
get 		{
			return 0;
		}

set {
		}
}

public float DefaultBlendTime
{
get 		{
			return 0f;
		}

set {
		}
}

public bool DefaultEasInOut
{
get 		{
			return false;
		}

set {
		}
}

public int DefaultRoleFilterMode
{
get 		{
			return 0;
		}

set {
		}
}

protected Guid[] KBOEILPBGGC
{
get 		{
			return null;
		}

set {
		}
}

public Guid DefaultMoodId
{
get 		{
			return default;
		}

set {
		}
}

protected bool EMPCGCFCFKJ
{
get 		{
			return false;
		}

set {
		}
}

protected int FODCNDDAKBJ
{
get 		{
			return 0;
		}

}

protected float GNDLDEGKMLE
{
get 		{
			return 0f;
		}

}

protected float EDCENDBHCKL
{
get 		{
			return 0f;
		}

set {
		}
}

protected bool KEEMFLLNFHB
{
get 		{
			return false;
		}

}

private bool BGGLHEPHJFK
{
get 		{
			return false;
		}

}

private bool OJLOEKLPNEK
{
get 		{
			return false;
		}

}

private bool MKNAHLLCKPO
{
get 		{
			return false;
		}

}

protected bool ICPIEPBGOOO
{
get 		{
			return false;
		}

}

private bool AIKPALGOCGB
{
get 		{
			return false;
		}

}

private bool KOJMPFKGHLC
{
get 		{
			return false;
		}

}

protected bool BPHPHGHGDLN
{
get 		{
			return false;
		}

set {
		}
}

private IDisposable NOIBNEGIPPL
{
get 		{
			return null;
		}

set {
		}
}

public abstract global::MDOHLCGMNEE<T> PreviousMoodData
{
get ;
set ;
}

public abstract global::MDOHLCGMNEE<T> TopMoodData
{
get ;
set ;
}

public T BlendData
{
get 		{
			return null;
		}

}

public abstract global::IBHLEFGNKPJ<T> Blender
{
get ;
}

protected abstract string GKBAKEEKOOA
{
get ;
}

private int IHBDKGBKIAL
{
get 		{
			return 0;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ PersistableRunFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

		protected override void Awake()
		{
		}

		protected void Start()
		{
		}

		private void ABHCDLEEBLC()
		{
		}

		private void LMLAPKCIDDI()
		{
		}

		void GAAKCFPLMHN.ResetObject()
		{
			//ILSpy generated this explicit interface implementation from .override directive in LMLAPKCIDDI
			this.LMLAPKCIDDI();
		}

		public virtual void ResetRoomMood()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void SetMoodIdHomeValue()
		{
		}

		public virtual void SetSynchronizing(bool OFBGBGEKFIB)
		{
		}

		public void SetBlendTimeHomeValue(float BBGNJMKOHPL)
		{
		}

		public void SetEaseInHomeValue(bool MMFPPHDNIAH)
		{
		}

		public void SetRoleFilterModeHomeValue(int DNLPIHIBJDP)
		{
		}

		public void SetFilteredRolesHomeValue(Guid[] MBGBGHIAPDD)
		{
		}

		public virtual void ModifyMood(global::MDOHLCGMNEE<U> CAOIPCMMNMJ, float JPFBBGIAHMH, int FFOMPPBNPLP, Guid[] NDHCGCCIGAN, bool OFBGBGEKFIB, out global::PHLHFLLLDLK<bool> IIIPHEJINNO)
		{
			IIIPHEJINNO = null;
		}

		public virtual Task<bool> RoomMoodReset()
		{
			return null;
		}

		public virtual void PreviewMoodSettings(T LNFKLCGLAGL, bool MDPBNDAEFHH)
		{
		}

		protected virtual void GHBBBMELGHB()
		{
		}

		protected virtual void MOICMJKGIPB()
		{
		}

		protected void EIBOOAMOHJO()
		{
		}

		private void HALPDEDMLFF(bool PMAFFAHLNHK = false)
		{
		}

		private void HPGFILBGLNE()
		{
		}

		protected virtual void OCBIBPILFFA()
		{
		}

		public void OnToggleTopSettings(bool MDPBNDAEFHH)
		{
		}

		public void OnForceSettings(bool MDPBNDAEFHH)
		{
		}

		public void OnForceUpdate()
		{
		}

		public virtual void OnSceneMoodSettingChanged()
		{
		}

		private void OAPFJKOBPAE(CHILKDJABBF FBCDJHOIDJJ, GameRole DGNFCCOMMEL)
		{
		}

		private bool HDJAPEMBFLG(Guid[] LGEIKKCKJHH)
		{
			return false;
		}

		protected bool ENMGGBGFGGC()
		{
			return false;
		}

		private bool CCBGFMNLCMH()
		{
			return false;
		}

		private bool ALEKNJICPAG()
		{
			return false;
		}

		private bool OFILFKODHOK(Guid[] KHHEMINCDCM, int FFOMPPBNPLP)
		{
			return false;
		}

		private float MFJHMEBONCD()
		{
			return 0f;
		}

		private void JJPCINNDFJE()
		{
		}

		private void ABFJKBPIEHB()
		{
		}

		private void HAJKKLBOJEE()
		{
		}

		private void ADKCPDIJLID()
		{
		}

		private void EEMCDNAEFKO()
		{
		}

		protected virtual void HBJCNBIKNGG(bool IKHKGNJNLCD = false, bool OFBGBGEKFIB = true)
		{
		}

		public abstract Task DeserializeFrom(KHMOHFAFGBI KGMPBFBAMCF, CancellationToken NDKAKDJMDIF);

		protected bool GBKLENGNDKH()
		{
			return false;
		}

		protected void AEEAMHBJJEL(FONEHJLHJPD DNENFMFPGFO)
		{
		}

		public abstract void SerializeTo(ref KHMOHFAFGBI KGMPBFBAMCF);

		protected void ANKEEHMDBOL(ref FONEHJLHJPD DNENFMFPGFO)
		{
		}
	}
}
