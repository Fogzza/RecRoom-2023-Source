using System.Collections.Generic;

public abstract class GONBPKCPFNK<T> : ILNJNAIHNJF where T : global::GONBPKCPFNK<T>.LAPIKJJOIDP
{
	public interface LAPIKJJOIDP
	{

 ABDCCOJEOCH CAMGEHFMCEK
{
get ;
}

 ABDCCOJEOCH INMCOCBHIJB
{
get ;
}

 HAMLJAHAGPF EHMICKMBCPH
{
get ;
}
	}

	private Dictionary<uint, T> AEFKINBPBDL = new Dictionary<uint, T>();

	private bool KJLBHFCAHDG;

	private DGKBCFAHNKA KLBFNLDJBAP__BackingField;

	private ushort MFHOAFKBLGN;

	private ushort IKBFPENHJDP;

	private ushort BPEBGOHANGP;

	private ushort MBGIJCKLLGI;

	private HAMLJAHAGPF IKADKOMHGFD;

	private HAMLJAHAGPF GKJMEKILNAC;

public bool DAJOPFCNENF
{
 get { return this.KJLBHFCAHDG; }
 set { this.KJLBHFCAHDG = value; }
}

public ushort CPDFJCCALIA
{
 get { return this.MFHOAFKBLGN; }
 private set { this.MFHOAFKBLGN = value; }
}

public ushort BKPPGHCMHED
{
 get { return this.IKBFPENHJDP; }
 private set { this.IKBFPENHJDP = value; }
}

public ushort LIBGEBFKJBH
{
 get { return this.BPEBGOHANGP; }
 private set { this.BPEBGOHANGP = value; }
}

public ushort IJBIHBMGMCK
{
 get { return this.MBGIJCKLLGI; }
 private set { this.MBGIJCKLLGI = value; }
}

protected bool LJGBCCKAGLC { get { return this.IKADKOMHGFD != null; } }

protected bool DMAENNNJLPI { get { return this.GKJMEKILNAC != null; } }

public event DGKBCFAHNKA KLBFNLDJBAP {
 add {
  DGKBCFAHNKA current = this.KLBFNLDJBAP__BackingField;
  DGKBCFAHNKA compared;
  do {
   compared = current;
   DGKBCFAHNKA updated = (DGKBCFAHNKA)System.Delegate.Combine(compared, value);
   current = System.Threading.Interlocked.CompareExchange(ref this.KLBFNLDJBAP__BackingField, updated, compared);
  } while (!object.ReferenceEquals(current, compared));
 }
 remove {
  DGKBCFAHNKA current = this.KLBFNLDJBAP__BackingField;
  DGKBCFAHNKA compared;
  do {
   compared = current;
   DGKBCFAHNKA updated = (DGKBCFAHNKA)System.Delegate.Remove(compared, value);
   current = System.Threading.Interlocked.CompareExchange(ref this.KLBFNLDJBAP__BackingField, updated, compared);
  } while (!object.ReferenceEquals(current, compared));
 }
}

	private T HNFNLBCPCOO(ushort EGGIGBGPDIH) { T result = default(T); if (EGGIGBGPDIH != ushort.MaxValue) { var states = this.AEFKINBPBDL; uint key = EHGDJMICDEI(EGGIGBGPDIH, ushort.MaxValue); states.TryGetValue(key, out result); } return result; }

	private T DGPILKHFFJE(ushort EGGIGBGPDIH, ushort BEOILOFKEIA) { T result = default(T); if (EGGIGBGPDIH != ushort.MaxValue && BEOILOFKEIA != ushort.MaxValue) { var states = this.AEFKINBPBDL; uint key = EHGDJMICDEI(EGGIGBGPDIH, BEOILOFKEIA); states.TryGetValue(key, out result); } return result; }

	protected T FGFAHJPHEEP(uint CLAMMGOCJAF) { T result = default(T); this.AEFKINBPBDL.TryGetValue(CLAMMGOCJAF, out result); return result; }

	public void KFGGILLHJNK(ushort ANAKIMJNHMH) { KFGGILLHJNK(ANAKIMJNHMH, ushort.MaxValue); }

	public void KFGGILLHJNK(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK) { KFGGILLHJNK(EHGDJMICDEI(ANAKIMJNHMH, EDNNIIPAKCK)); }

	protected virtual void KFGGILLHJNK(uint CEHLNHJIFBD) { uint old = EHGDJMICDEI(CPDFJCCALIA, BKPPGHCMHED); LIGCPPMJHNB(CEHLNHJIFBD, old); }

	protected void LIGCPPMJHNB(uint CEHLNHJIFBD, uint ANEPEKOBOKI)
 {
  ushort requestedSuper = BKBFDMBLOAP(CEHLNHJIFBD);
  ushort requestedSub = NNDBLIANPEM(CEHLNHJIFBD);
  ushort oldSuper = CPDFJCCALIA;
  ushort oldSub = BKPPGHCMHED;
  T oldPair = DGPILKHFFJE(CPDFJCCALIA, BKPPGHCMHED);
  bool superChanged = requestedSuper != oldSuper;
  bool subChanged = requestedSub != oldSub;
  if ((superChanged || subChanged) && (object)oldPair != null && oldPair.INMCOCBHIJB != null)
   oldPair.INMCOCBHIJB(requestedSuper, requestedSub);
  T oldSuperState = HNFNLBCPCOO(CPDFJCCALIA);
  if (superChanged && (object)oldSuperState != null && oldSuperState.INMCOCBHIJB != null)
   oldSuperState.INMCOCBHIJB(requestedSuper, requestedSub);
  LIBGEBFKJBH = BKBFDMBLOAP(ANEPEKOBOKI);
  IJBIHBMGMCK = NNDBLIANPEM(ANEPEKOBOKI);
  CPDFJCCALIA = requestedSuper;
  BKPPGHCMHED = requestedSub;
  if (superChanged)
  {
   T superState = HNFNLBCPCOO(CPDFJCCALIA);
   if ((object)superState == null)
    this.IKADKOMHGFD = null;
   else
   {
    this.IKADKOMHGFD = superState.EHMICKMBCPH;
    ABDCCOJEOCH entered = superState.CAMGEHFMCEK;
    if (entered != null) entered(LIBGEBFKJBH, IJBIHBMGMCK);
   }
  }
  if (superChanged || subChanged)
  {
   T subState = DGPILKHFFJE(CPDFJCCALIA, BKPPGHCMHED);
   if ((object)subState == null)
    this.GKJMEKILNAC = null;
   else
   {
    this.GKJMEKILNAC = subState.EHMICKMBCPH;
    ABDCCOJEOCH entered = subState.CAMGEHFMCEK;
    if (entered != null) entered(LIBGEBFKJBH, IJBIHBMGMCK);
   }
  }
  DGKBCFAHNKA changed = this.KLBFNLDJBAP__BackingField;
  if (changed != null) changed(requestedSuper, LIBGEBFKJBH, requestedSub, IJBIHBMGMCK);
 }

	protected void BDPIJBIEIOA(ushort LMLDKMMPDFD, T DADHJJNJEFA) { BDPIJBIEIOA(LMLDKMMPDFD, ushort.MaxValue, DADHJJNJEFA); }

	protected void BDPIJBIEIOA(ushort EGGIGBGPDIH, ushort BEOILOFKEIA, T DADHJJNJEFA) { uint key = EHGDJMICDEI(EGGIGBGPDIH, BEOILOFKEIA); LCOAEEMJNFD(key, DADHJJNJEFA); }

	private void LCOAEEMJNFD(uint CLAMMGOCJAF, T DADHJJNJEFA) { this.AEFKINBPBDL[CLAMMGOCJAF] = DADHJJNJEFA; }

	protected void JJGKILLDMPK(float OKBAJEAPIHG)
 {
  HAMLJAHAGPF superUpdate = this.IKADKOMHGFD;
  HAMLJAHAGPF originalSubUpdate = this.GKJMEKILNAC;
  HAMLJAHAGPF afterSuperUpdate = originalSubUpdate;
  if (superUpdate != null)
  {
   superUpdate();
   afterSuperUpdate = this.GKJMEKILNAC;
  }
  if (afterSuperUpdate != originalSubUpdate && this.GKJMEKILNAC != null && BKPPGHCMHED != ushort.MaxValue)
  {
   if (DAJOPFCNENF) return;
   string first = string.Format("Changed state during super state ({0}) update. ", LIBGEBFKJBH);
   string second = string.Format("Sub state ({0}) updating before its super state ({1}). ", BKPPGHCMHED, CPDFJCCALIA);
   string message = string.Concat(first, second, "Consider enabling SkipSubStateUpdateIfSuperStateTriggersStateChange");
   HJDBOADFHMC? category = null;
   PNAABCMOHGM.HFJIPLOFPOB((object)message, category, "D:\\Jenkins\\workspace\\RecRoom\\Steam\\project\\Assets\\Core\\Scripts\\DataStructures\\StateMachines\\AbstractStateMachine.cs", 260);
  }
  HAMLJAHAGPF subUpdate = this.GKJMEKILNAC;
  if (subUpdate != null) subUpdate();
 }

	protected uint EHGDJMICDEI(ushort EGGIGBGPDIH, ushort BEOILOFKEIA) { return unchecked(((uint)EGGIGBGPDIH << 16) + BEOILOFKEIA); }

	protected ushort BKBFDMBLOAP(uint FKGGPDDILEJ) { return (ushort)(FKGGPDDILEJ >> 16); }

	protected ushort NNDBLIANPEM(uint FKGGPDDILEJ) { return unchecked((ushort)FKGGPDDILEJ); }

 protected GONBPKCPFNK()
 {
  LIBGEBFKJBH = ushort.MaxValue;
  IJBIHBMGMCK = ushort.MaxValue;
  CPDFJCCALIA = ushort.MaxValue;
  BKPPGHCMHED = ushort.MaxValue;
 }
}
