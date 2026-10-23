using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom;
using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

public class DiscGolfManager : GameRuleManager
{
	private enum KPEGBKGMBBK
	{
		HOLE_RUNNING = 0,
		HOLE_FINISHED = 1,
		INVALID = 65535
	}

	private class PAFFFMOGCFJ
	{
		private global::MOBDJNEDDKC<int> KACHGIFHEBI;

		private global::MOBDJNEDDKC<Vector3> MPABKIFGHEG;

		private global::MOBDJNEDDKC<bool> ICJBLPBGHHJ;

		private global::MOBDJNEDDKC<bool> BOEKCGIPDAA;

public int LKMBAPJAKKF
{
get 		{
			return 0;
		}

set {
		}
}

public Vector3 BPKCMIPKDBN
{
get 		{
			return default;
		}

set {
		}
}

public bool EOCEHLIGNPE
{
get 		{
			return false;
		}

set {
		}
}

public bool BOELLCCINGL
{
get 		{
			return false;
		}

set {
		}
}

		public PAFFFMOGCFJ(GIBEGHKMCIE NEBNOBLPNEP, DiscGolfManager ACDHNMANGFE)
		{
		}

		private static string MJFAGAKLKCE(GIBEGHKMCIE NEBNOBLPNEP, string OIFCDJKHBEC)
		{
			return null;
		}
	}

	private sealed class GGMAFCLAEOC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DiscGolfManager _003C_003E4__this;

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
		public GGMAFCLAEOC(int _003C_003E1__state)
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

	private sealed class KFEEDEEPHOP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DiscGolfManager _003C_003E4__this;

		public DiscGolfDisc disc;

		public Killzone hazard;

		public CHILKDJABBF throwPlayer;

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
		public KFEEDEEPHOP(int _003C_003E1__state)
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

	private sealed class OIINOMKHFOF : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DiscGolfDisc disc;

		public DiscGolfManager _003C_003E4__this;

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
		public OIINOMKHFOF(int _003C_003E1__state)
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

	private sealed class OAKBDCCJKLM
	{
		public DiscGolfDisc disc;

		internal void _003CRpcMasterFinishHole_003Eb__0()
		{
		}
	}

	private sealed class DMMCOENKNKH : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DiscGolfManager _003C_003E4__this;

		public GIBEGHKMCIE team;

		public Vector3 anchorPoint;

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
		public DMMCOENKNKH(int _003C_003E1__state)
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
	private float strokeIncrementThreshold;

	[SerializeField]
	private float mercyRuleHoleScore;

	[SerializeField]
	private MFCPKKGGLNF firstHole;

	[SerializeField]
	private MFCPKKGGLNF lastHole;

	[SerializeField]
	private string scoreHoleInOne;

	[SerializeField]
	private string scoreLessThanNeg2;

	[SerializeField]
	private string scoreNeg2;

	[SerializeField]
	private string scoreNeg1;

	[SerializeField]
	private string scoreZero;

	[SerializeField]
	private string scorePos1;

	[SerializeField]
	private string scorePos2;

	[SerializeField]
	private string scorePos3;

	[SerializeField]
	private float gravityPickupDistanceOverride;

	[SerializeField]
	private EquipmentSkin discSkinOverride;

	[SerializeField]
	private float catchNotificationMetersPerScaleFactor;

	[SerializeField]
	private float catchNotificationDistanceBeforeScaling;

	[SerializeField]
	private RecRoomAudioClip catchSFX;

	[SerializeField]
	private RecRoomAudioClip playerOutSFX;

	[SerializeField]
	private RecRoomAudioClip goalSFX;

	[SerializeField]
	private RecRoomAudioClip powerupHitSFX;

	[SerializeField]
	private PooledParticle catchVFXPrefab;

	[SerializeField]
	private PooledParticle goalVFXPrefab;

	private const float CDMCAJGHBHG = 6f;

	private const int NADLGBLHLJD = 3;

	private const float FAFEPCNPCGO = 1f;

	private JOJOABLFOBA GFLBAKLKAJA;

	private HONEDBECDOK GCHCIJBHEDD;

	private bool AHKFBGKFFMB;

	private Dictionary<GIBEGHKMCIE, float> PEDGOGEMGDH;

	private List<DiscGolfDisc> DLOFGBIHAAL;

	private DiscGolfGoal[] PNKCGNOKBOJ;

	private DiscGolfTee[] PGEJAFKJOEK;

	private List<DiscGolfPowerUp> DCLPOOCFPLL;

	private List<DiscGolfDisc> FDCNOBMKKAN;

	private global::MOBDJNEDDKC<MFCPKKGGLNF> GPBDFPFNCDJ;

	private global::MOBDJNEDDKC<MFCPKKGGLNF> GEIHLNOCCKM;

	private global::MOBDJNEDDKC<MFCPKKGGLNF> ABNFMBAJJGG;

	private Dictionary<GIBEGHKMCIE, PAFFFMOGCFJ> LLGCFCIIDBB;

public new static DiscGolfManager Instance
{
get 	{
		return null;
	}

}

public new static bool IsInitialized
{
get 	{
		return false;
	}

}

private MFCPKKGGLNF LEPJNPOKFPA
{
get 	{
		return MFCPKKGGLNF.HOLE_1;
	}

set {
	}
}

private int JBEJCIJGJIH
{
get 	{
		return 0;
	}

}

private MFCPKKGGLNF ABCCJDGILIH
{
get 	{
		return MFCPKKGGLNF.HOLE_1;
	}

set {
	}
}

private MFCPKKGGLNF KEFIJANJPOL
{
get 	{
		return MFCPKKGGLNF.HOLE_1;
	}

set {
	}
}

public override string RuleTypeAutoTag
{
get 	{
		return null;
	}

}

public override bool AutoRunTimer
{
get 	{
		return false;
	}

}

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void Update()
	{
	}

	protected override void HDJBEAFJEHD()
	{
	}

	protected override void ENHEJEADGCH()
	{
	}

	private void NFKJFJMFLOI()
	{
	}

	private void LHOABNCJFAK(bool BIJHPJHGOEF)
	{
	}

	private void MNBFMCBPJAJ(DiscGolfDisc ENECPPAOOCM, DiscGolfGoal PDIBMCIEHIJ, CHILKDJABBF LAKIEOJMCKM)
	{
	}

	private IEnumerator PDHBPCIJADM()
	{
		return null;
	}

	private void PPBHKADHPIO(Tool IEGMBEPJMGC)
	{
	}

	private void IOELDLOAFCE(Tool IEGMBEPJMGC)
	{
	}

	private void JNEEJFJBKMA(DiscGolfDisc ENECPPAOOCM, CHILKDJABBF CLAAKJAFDLA, CHILKDJABBF HHCMHBBCCGO)
	{
	}

	private void JHFCLADBCEP(DiscGolfDisc ENECPPAOOCM, CHILKDJABBF CLAAKJAFDLA, CHILKDJABBF OKMAHALKICL, int IENNOMEFAHC)
	{
	}

	[PBOMGCLBFHF]
	private void RpcPlaySyncedDiscPickupFeedback(Vector3 NDNFFJMDJIM, float DMNDFEGEKOL)
	{
	}

	public bool CanReportVoluntaryHazard(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	public void LocalVoluntaryHazard(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	private IEnumerator BFHDLEFHMIP(DiscGolfDisc ENECPPAOOCM, Killzone FBLHHLJIGHM, CHILKDJABBF PELNHNOCCDO)
	{
		return null;
	}

	private void EHJPGMBBAIL(DiscGolfDisc ENECPPAOOCM, Killzone FBLHHLJIGHM, CHILKDJABBF PELNHNOCCDO)
	{
	}

	private IEnumerator EGKHLMOLGHE(DiscGolfDisc ENECPPAOOCM)
	{
		return null;
	}

	[PBOMGCLBFHF]
	private void RpcOnDiscHazard(DiscGolfDisc ENECPPAOOCM, CHILKDJABBF LAKIEOJMCKM)
	{
	}

	private void EFJOGGEHFAO(DiscGolfDisc ENECPPAOOCM, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ)
	{
	}

	private void DGKAABFLPMA(DiscGolfDisc ENECPPAOOCM, Collider ABFFPEJKIMC, CHILKDJABBF LAKIEOJMCKM)
	{
	}

	private void PPJNCDLBDFM(DiscGolfDisc ENECPPAOOCM, CHILKDJABBF LAKIEOJMCKM)
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterFinishHole(DiscGolfDisc ENECPPAOOCM, DiscGolfGoal PDIBMCIEHIJ, CHILKDJABBF LAKIEOJMCKM, bool HMGLJOFENHM)
	{
	}

	[PBOMGCLBFHF]
	private void RpcOnFinishHole(DiscGolfGoal PDIBMCIEHIJ, CHILKDJABBF LAKIEOJMCKM, bool HMGLJOFENHM, int DELMOKHLENM)
	{
	}

	private bool OKLCIKDBMND(DiscGolfDisc ENECPPAOOCM, DiscGolfGoal PDIBMCIEHIJ, CHILKDJABBF LAKIEOJMCKM)
	{
		return false;
	}

	private bool PLJDJFJOEOJ(DiscGolfDisc ENECPPAOOCM, CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	private bool LBNPKHPNMAI(DiscGolfDisc ENECPPAOOCM, CHILKDJABBF LAKIEOJMCKM, bool IFMLDFLFECF = true)
	{
		return false;
	}

	private DiscGolfDisc EAKPFHGHMBF(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	private List<DiscGolfDisc> GNDPCJAGFPL(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	private void IJPDDGJDIFO()
	{
	}

	private void ILMLCBAGEBK(DiscGolfPowerUp EHHMLGPJGDB, DiscGolfDisc ENECPPAOOCM, Player GBEPPMIOPGE)
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterRequestPowerup(DiscGolfDisc ENECPPAOOCM, DiscGolfPowerUp EHHMLGPJGDB, CHILKDJABBF GBEPPMIOPGE)
	{
	}

	[PBOMGCLBFHF]
	private void RpcOnPowerup(DiscGolfPowerUp EHHMLGPJGDB, CHILKDJABBF GBEPPMIOPGE)
	{
	}

	private bool BDOMGGCAJHJ(DiscGolfDisc ENECPPAOOCM, DiscGolfPowerUp EHHMLGPJGDB, CHILKDJABBF GBEPPMIOPGE)
	{
		return false;
	}

	private DiscGolfGoal CKILICMKKJM()
	{
		return null;
	}

	private DiscGolfTee PIEMLLJMBND(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	private void CCPFBENCFME()
	{
	}

	private void OLBINOHOENG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void GLECEFADBMG()
	{
	}

	private bool KLICAOLDOIB()
	{
		return false;
	}

	private void MDOMHLNANBM(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void BKMJOGHPBCM()
	{
	}

	private void EPJEKINNJPA()
	{
	}

	private PAFFFMOGCFJ AOJCLCDIMBO(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	private int BDOKEIFJGFI(int OBAFKEBLHCE, int IENNOMEFAHC)
	{
		return 0;
	}

	private int PHEFKFADLMA(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return 0;
	}

	private void IIICJDOEGMH(GIBEGHKMCIE NEBNOBLPNEP, int IENNOMEFAHC)
	{
	}

	private void DCINDPCPAEI(GIBEGHKMCIE NEBNOBLPNEP, int JMKKOEIAEGH)
	{
	}

	private Vector3 DOOMCDHNDEG(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return default;
	}

	private IEnumerator OFJLJJGIFJI(GIBEGHKMCIE NEBNOBLPNEP, Vector3 BLPADEHEEEF)
	{
		return null;
	}

	private void GEDNKPJAAOG(GIBEGHKMCIE NEBNOBLPNEP, Vector3 BLPADEHEEEF)
	{
	}

	private bool LMDOAEGEJCF(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return false;
	}

	private void BBFPAOGDOAM(GIBEGHKMCIE NEBNOBLPNEP, bool AJACIJAKKKA)
	{
	}

	private bool CIDAHIIEFCA(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return false;
	}

	private void KEFOCIMJPNB(GIBEGHKMCIE NEBNOBLPNEP, bool EGGCFMMJEHK)
	{
	}

	private void ICCHEJNKBCD()
	{
	}

	private string DLFKMNOKJIJ(int IENNOMEFAHC, int JOPOKBJLGOE)
	{
		return null;
	}

	protected void KBBOFBAFIFK()
	{
	}

	private void NDGCPKEKDBL(DiscGolfDisc ENECPPAOOCM)
	{
	}

	protected void OnPhotonPlayerDisconnected(CHILKDJABBF EKOFNPFCLMO)
	{
	}
}
