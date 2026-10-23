using System;
using System.Collections.Generic;
using RecRoom.Core.AI;
using UnityEngine;

public class PlayerObjectiveTracker : MonoBehaviour
{
	public class NMOLINPDDFK
	{
		public int GMEHLIHLGEH;

		public int DDKCONDPEJF;

		public int FIABAMNGCHP;

		public bool ANCILMFLKOB;

		public bool OLIBMDDHKGA;

		public string OKPDGPAJCIE;

		public string PLLDABEEHMN;
	}

	public struct HLEKPIKPAMK
	{
		public PNLFAAAPEID AEIMECBNBPE;

		public float HIJDKOAMHHM;

		public long? EPOBIFCHLNM;
	}

	public enum ODDEAEHJAGJ
	{
		Dailies = 0,
		NewPlayerPunchCard = 1,
		OrientationChecklist = 2,
		NewPlayerChallenges = 3
	}

	private sealed class DDHBEAIFDJG
	{
		public PlayerObjectiveTracker _003C_003E4__this;

		public int objectiveIndex;

		internal void _003CCompleteObjectiveAndSave_003Eb__0()
		{
		}
	}

	public static global::HHOBPMOCKMJ<List<HLEKPIKPAMK>> EventBufferUpdated;

	private Player PGKEHBCKJKI;

	private BHNJIBDJFAL NJPJBDDAEFH;

	private GameManager KPCADKBOAFA;

	private List<HLEKPIKPAMK> LFJHCMNADEH;

	private const int IGKHGEHPICI = 0;

	public EEANDDJEMJC ObjectiveProgressUpdateEvent;

	private FIHGBEHGLGB DDGPCAPIJJI;

	private static readonly HashSet<ODCEOIGDCAH.CEFCGLCBIAM> APKICLJIBAP;

	private float EAIBCEKCKED;

public static bool HasSeenTodaysObjectives
{
get 	{
		return false;
	}

}

private bool NFLPNJIAKKB
{
get 	{
		return false;
	}

}

	public void AddObjectiveTrackingSuppressed(object IALNODEHBNN)
	{
	}

	public void RemoveObjectiveTrackingSuppressed(object IALNODEHBNN)
	{
	}

	private static void JCBEJCHIJFI()
	{
	}

	private static void GBEILGJPHID()
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void GetObjectiveDescription(int LCHIDIFOBCP, out ProgressionManager.ObjectiveTypeDescription GKHMKKBKEKC, out string LAHJFBJNIAC)
	{
		GKHMKKBKEKC = null;
		LAHJFBJNIAC = null;
	}

	public bool GetObjectiveProgress(int LCHIDIFOBCP, out int DDKCONDPEJF, out int FIABAMNGCHP)
	{
		DDKCONDPEJF = default;
		FIABAMNGCHP = default;
		return false;
	}

	public List<NMOLINPDDFK> GetAllObjectiveDetails()
	{
		return null;
	}

	public void CompleteObjective(PNLFAAAPEID JOOMFBGMEHA, float HIJDKOAMHHM = 1f)
	{
	}

	private void NCIFMOKFDAL(PNLFAAAPEID JOOMFBGMEHA, float HIJDKOAMHHM = 1f)
	{
	}

	public bool GetAllObjectivesCompleted()
	{
		return false;
	}

	private void PENCCBBMFKN(int EJIHLJJMOBD)
	{
	}

	private void MJGPHBGDHDJ(Player EKOFNPFCLMO)
	{
	}

	private void PHEGFEBIBKN(int AFBGIPGHBMO, ODCEOIGDCAH.CEFCGLCBIAM GLLFHCCFIGK)
	{
	}

	private void PGBLPIELNDK()
	{
	}

	private void IBMNCIOFBPE()
	{
	}

	private void KNOBKFONDCD()
	{
	}

	private void FFNFHAKABCO()
	{
	}

	private void HMOFFMPCLPN()
	{
	}

	private void LGBJFNKCBCC()
	{
	}

	private void OINAHJIGHEN()
	{
	}

	private void LCJPJPJKGPI(float DAMOGGANOJL)
	{
	}

	private void EABDIDKDMHH(bool JJDIFNOOOKO, bool AEKCMELAJFD)
	{
	}

	private void NFGFMOGDHCN()
	{
	}

	private void MEFBDPDGNPB()
	{
	}

	private void JAGFIPKLKDA()
	{
	}

	private void HKCOGOBHIGJ()
	{
	}

	private void KBIDLONHIIE()
	{
	}

	private void IBEFADKOGED()
	{
	}

	private void OAOIGKNMDLG()
	{
	}

	private void DLDEIKHFIBB()
	{
	}

	private void HJDFKMBOJHA(bool KOEEMOIFPBE, bool BBNCKBDJMJP)
	{
	}

	private void CMBCNEFEEAD(bool KOEEMOIFPBE, float HIJDKOAMHHM)
	{
	}

	private void GOELHPGDABH()
	{
	}

	private void EGKLIAMOEHC()
	{
	}

	private void FIDOMBBGFOA(int JOPOKBJLGOE)
	{
	}

	private void KKFGJCHJMAA()
	{
	}

	private void NNBFJEOIDLN()
	{
	}

	private void IKFOMGKFKNE()
	{
	}

	private void EBLAENJHKLG(CHILKDJABBF PLNGHFIMCDB)
	{
	}

	private void BHHCBHBEJCA(Enemy DPENEFKKNDN)
	{
	}

	private void JFDHPCLAEDP()
	{
	}

	private void BDBPOMAGKEI(CHILKDJABBF PLNGHFIMCDB)
	{
	}

	private void DALDEAKGDMO(CHILKDJABBF PLNGHFIMCDB)
	{
	}

	private void COGHFGNNKDG(Enemy DPENEFKKNDN)
	{
	}

	private void BLNHIJAAMJE()
	{
	}

	private void PJJIIFDGALO(CHILKDJABBF PLNGHFIMCDB)
	{
	}

	private void MLOEHNKIMAJ()
	{
	}

	private void LGIJNEDMAFP(int GMEHLIHLGEH, int HJKMBFELIDI, long? EPOBIFCHLNM)
	{
	}

	private PNLFAAAPEID KELOALIKCBD(int GMEHLIHLGEH)
	{
		return (PNLFAAAPEID)0;
	}

	private FCAOHDFPEAP GNEGNBJJODL(int GMEHLIHLGEH)
	{
		return null;
	}

	private static FCAOHDFPEAP[] CHFMIFODELA()
	{
		return null;
	}

	public void ClearStaleProgress(bool LCMLEKPGELN = false)
	{
	}

	private static DateTime GFCOINEDLOO()
	{
		return default;
	}

	public static void UpdateLastRecordedObjectiveDate()
	{
	}

	private CDNDHAMKCLJ JADNOLDOFHH(int LCHIDIFOBCP, int FKHDPLPGMAK)
	{
		return null;
	}

	private int LOEAIFLOCIC()
	{
		return 0;
	}

	private int OFJEKBGENNK(int LCHIDIFOBCP)
	{
		return 0;
	}

	private void AAGHOAKIFIJ(FCAOHDFPEAP JOOMFBGMEHA)
	{
	}

	private void PKOIHDOMGDB()
	{
	}

	private void FCMAFAICKID(ProgressionManager.ObjectiveTypeDescription GKHMKKBKEKC)
	{
	}

	private void DBFJMLPEBKC(ProgressionManager.ObjectiveTypeDescription GKHMKKBKEKC, FCAOHDFPEAP JOOMFBGMEHA)
	{
	}

	private LAHBDKNMNHN NHGMICLEIKD(int LCHIDIFOBCP, int PEPDFPCPJCJ)
	{
		return null;
	}

	private LAHBDKNMNHN HNOBCIGBMIO(int LCHIDIFOBCP, bool ANCILMFLKOB, int PEPDFPCPJCJ, bool? ALAJAHOMMJA = null)
	{
		return null;
	}

	private bool CDHHDOMJPKB(int LCHIDIFOBCP)
	{
		return false;
	}

	private void EMFIEBMMJGA()
	{
	}
}
