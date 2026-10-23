using System.Collections.Generic;
using Photon.Pun;

namespace RecRoom.Activities.SubScenes
{
	public abstract class BaseActivitySubScene : MonoBehaviourPun
	{
		public delegate void BFJHONMNABE(BaseActivitySubScene KPFNANKNKLE);

		private int JNPNIPHMLHE;

		protected Tool[] FJPKJJJFOCB;

		protected Trap[] APPKMDCNBNP;

		private BFJHONMNABE HMCGJPCPEFI__BackingField;

		private BFJHONMNABE KCHBLPCLBMC__BackingField;

		private BFJHONMNABE HNBHHJJBMKK__BackingField;

		private BFJHONMNABE CNPKDLKPPML__BackingField;

		private BFJHONMNABE OPMJMFKEBFN__BackingField;

public int SubSceneIndex
{
get 		{
			return 0;
		}

private set {
		}
}

protected virtual bool OBIOFEFOLFN
{
get 		{
			return false;
		}

}

public IReadOnlyCollection<Tool> Tools
{
get 		{
			return null;
		}

}

public event BFJHONMNABE LocalInitializeEvent {
add {
		}
remove {
		}
}

public event BFJHONMNABE LocalPlayerEnterEvent {
add {
		}
remove {
		}
}

public event BFJHONMNABE LocalPlayerExitEvent {
add {
		}
remove {
		}
}

public event BFJHONMNABE StartRunningEvent {
add {
		}
remove {
		}
}

public event BFJHONMNABE StopRunningEvent {
add {
		}
remove {
		}
}

		public virtual void Initialize(int HAFOBFDBCJD)
		{
		}

		protected void PIFNHEEBDAN()
		{
		}

		protected void DGELPHFMJEI()
		{
		}

		public virtual void OnLocalPlayerEnter()
		{
		}

		public virtual void OnLocalPlayerExit()
		{
		}

		protected void DOGDBAGPGMO()
		{
		}

		protected void LIGMBLDMOBP()
		{
		}

		private void IDLJFCJCNAJ()
		{
		}

		protected void FHCMGOOIHKE()
		{
		}

		protected void ENIIIAKBHFI()
		{
		}

		private void AJGPBOBDGBG()
		{
		}
	}
}
