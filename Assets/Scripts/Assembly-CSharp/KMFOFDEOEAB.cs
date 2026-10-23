public interface KMFOFDEOEAB
{

 bool IsLocalStateDifferentFromRemote
{
get ;
}

 bool DiffersFromRoomData
{
get ;
}

 short CurrentLocalRevision
{
get ;
}

	short MasterIncrementDataRevision();

	short AuthorityIncrementDataRevision();

	void AuthorityStartActiveModification();

	void AuthorityStopActiveModification();

	void SetDeserializedRevision(short LCOJBACNGFG);
}
