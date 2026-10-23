using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google.Protobuf;
using Photon.Pun;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Core.Creation.Holotars
{
	public abstract class RecordableObject<T> : MonoBehaviourPun, BILDPPLNMGI where T : IMessage, IEquatable<T>
	{
		private sealed class DKDLBGJMAHO
		{
			public RecordableObject<T> _003C_003E4__this;

			public HolotarUploadingFlow uploadFlow;

			internal void _003COnEnterUploadRecordingSubstate_003Eb__0(string blobName)
			{
			}

			internal void _003COnEnterUploadRecordingSubstate_003Eb__1(string e)
			{
			}
		}

		protected static RecordableObject<T> FFHHJAGKEDG;

		[SerializeField]
		private RecordableStackedUI uiPrefab;

		[SerializeField]
		private Transform uiRoot;

		[SerializeField]
		private MonoBehaviour uiPivot;

		[SerializeField]
		protected float maxRecordingDuration;

		[SerializeField]
		protected string startRecordingPrompt;

		[SerializeField]
		protected string dataDeleteConfirmation;

		protected Func<bool> KOBGBOAGNNN;

		[SerializeField]
		protected Tool tool;

		[SerializeField]
		protected MicAudioRecorder micAudioRecorder;

		private JOJOABLFOBA FLGPKAIGIGI;

		private MDEJADHJOEJ KLOLMMOJNHJ;

		private CGOPOAFDIDN FIJHCMLFKJH;

		protected RecordableStackedUI MELDFJGPOOO;

		protected float COOCLFABLPH;

		private global::MOBDJNEDDKC<int> ANKEPLFJOGE;

		private CHILKDJABBF LHKBPMBLKAH;

		private global::MOBDJNEDDKC<string> ODJLHOINMGF;

		protected T IHNIPCOJINH;

		private T PMBJDIDFJJG;

		protected CreationObject BPEGJLIMPPJ;

		private bool FFPOJKDKJPA;

public CHILKDJABBF RecordingPlayer
{
get 		{
			return null;
		}

}

protected string OIHICALGIAI
{
get 		{
			return null;
		}

set {
		}
}

public T DataBlob
{
get 		{
			return default;
		}

set {
		}
}

public PFGOJGJOHAJ CurrentSynchronizedState
{
get 		{
			return PFGOJGJOHAJ.IDLE;
		}

}

public FOCGDPMCKFK CurrentLocalState
{
get 		{
			return FOCGDPMCKFK.IDLE;
		}

}

public FFPLCGDKNFK CurrentIdleSubState
{
get 		{
			return FFPLCGDKNFK.NO_DATA;
		}

}

public OHMOFFLPCKG CurrentRecordingSubState
{
get 		{
			return OHMOFFLPCKG.COUNTDOWN;
		}

}

public bool IsRecordingLocally
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool IsReadyForPlayback
{
get 		{
			return false;
		}

}

protected virtual bool NEMDEFFNDFG
{
get 		{
			return false;
		}

}

public bool CanStartLocalRecording
{
get 		{
			return false;
		}

}

private bool LOMBIOCCIDD
{
get 		{
			return false;
		}

}

public string StartRecordingPrompt
{
get 		{
			return null;
		}

}

public float LocalRecordingProgress
{
get 		{
			return 0f;
		}

}

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void LOGCDMFMOCI(JDCIJIEOFOL EKOFNPFCLMO)
		{
		}

		protected virtual void INCGHMFPBFL()
		{
		}

		protected virtual List<DGMPBIPKJEB> FADMKONBDMM()
		{
			return null;
		}

		protected virtual void Update()
		{
		}

		private void FDILJNJKEMH()
		{
		}

		private void HKLCLAPNICE()
		{
		}

		protected virtual void JDAOFNOOMFA(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
		{
		}

		private void HJIBEPFNBKO(bool CMOEMFDHEDO)
		{
		}

		private void AAGKCNIGEAG(Tool PMEFICGEDFK)
		{
		}

		private void OMPFMHJDHOC(RigidbodyEx ICHBECDKHOJ)
		{
		}

		private void BADODPLCJNK(Tool PMEFICGEDFK)
		{
		}

		private void OnPhotonPlayerDisconnected(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private void HAIMEPLMPAG()
		{
		}

		public virtual void MasterSetResourceBlobName(string KNOPFGAGMCN)
		{
		}

		private void CIOAHHCIOJC(CHILKDJABBF CBDPEOAABOH)
		{
		}

		private void ODJNEOECLID()
		{
		}

		protected virtual void JAJLGFPEAMP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected virtual void BIECDJOHMCP(ushort ANAKIMJNHMH, ushort KJLHJFEJJGM)
		{
		}

		private void KHCLBMBFPLC(ushort EHLPLCEJPDD, ushort DFNBMANKLGD)
		{
		}

		protected virtual void PBECKAIBLPA(ushort EHLPLCEJPDD, ushort DFNBMANKLGD)
		{
		}

		protected virtual void JMDILEHHBOL(ushort EHLPLCEJPDD, ushort DFNBMANKLGD)
		{
		}

		protected virtual void JBIGJNMJHBA(ushort ANAKIMJNHMH, ushort KJLHJFEJJGM)
		{
		}

		protected virtual void GLJMBIOFPBG()
		{
		}

		protected virtual void AGGENGGIKPN(ushort EHLPLCEJPDD, ushort DFNBMANKLGD)
		{
		}

		private void MFMAEHFCDHL(ushort EHLPLCEJPDD, ushort DFNBMANKLGD)
		{
		}

		protected virtual void BBBDOCKAMAK(ushort ANAKIMJNHMH, ushort KJLHJFEJJGM)
		{
		}

		protected virtual void LLNFKHHNLLJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void IABHHFKCGJO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected virtual void PBKHIGPABCP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void NELNDNLDCDB()
		{
		}

		protected virtual void JBGMNNKCHGC()
		{
		}

		protected void HAAACFCNGJJ(out global::NCOKFFGPIJM<LDCCJDCBBPA> DPGHLBJJLJP)
		{
			DPGHLBJJLJP = null;
		}

		protected void FNPPLBALDJL()
		{
		}

		protected virtual void DNBBAAJCLHK(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected virtual void JNNMOKMPBKP(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected virtual void COIOHLNPLBI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected virtual void POCPDPLFEDJ(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected virtual bool KDNOKDCPCNB()
		{
			return false;
		}

		protected void HAMINDPJLBH()
		{
		}

		private void CACPEKLAMFC()
		{
		}

		private RecordableUIFlow MHENACMEMHG<V>() where V : RecordableUIFlow
		{
			return null;
		}

		private void KGFMKAAFGJO()
		{
		}

		protected abstract T NJCEGKLCIHO();

		protected abstract void GCPDKOBDKPE();

		protected virtual void FNGDAJACBKP()
		{
		}

		protected abstract void IAKMFHGOONG();

		public void TryStartRecording()
		{
		}

		public void TryFinishRecording()
		{
		}

		public void TrySaveRecording()
		{
		}

		public void TryEnterRecordingFlow()
		{
		}

		public void TryExitRecordingFlow()
		{
		}

		public virtual void RequestDeleteData()
		{
		}

		public bool HasRecordableData()
		{
			return false;
		}

		[PBOMGCLBFHF]
		protected void RpcRequestMasterEnterRecordingFlow(GGGMJMEFFOC BDGGGHEOPBI)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcRequestMasterExitRecordingFlow()
		{
		}

		[PBOMGCLBFHF]
		protected void RpcRequestMasterSetBlobName(string AIGKNOMENDE, GGGMJMEFFOC BDGGGHEOPBI)
		{
		}

		[CompilerGenerated]
		private void CJOHOHCBDBC()
		{
		}
	}
}
