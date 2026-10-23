using AGUI.StackedUI;
using UnityEngine;

public abstract class RoomOrPlaylistBasedConditionalButton<T> : ConditionalButton<T> where T : Button3DBase
{
	[SerializeField]
	protected RoomOrPlaylistSpecificUIBehaviour roomWatcher;

	[SerializeField]
	protected DBECJLAIPEL loadSceneSource;

public BNKIKFBACEL CurrentType
{
get 	{
		return BNKIKFBACEL.Room;
	}

}

	protected virtual void Awake()
	{
	}

	protected virtual void OnDestroy()
	{
	}

	private void IMKKOLDCCDE(RoomOrPlaylistSpecificUIBehaviour.EBIKMOHGHOJ JDBHABEFGKF, RoomOrPlaylistSpecificUIBehaviour.OPBALFHHAFF BFFCGPJEHGB, BNKIKFBACEL NIFOGEBEDNG)
	{
	}

	protected override void GFCICHDHHJG()
	{
	}

	protected sealed override void OEGMENAEEAE()
	{
	}

	protected abstract void NBELKGEKBFD();
}
