using RecRoom.Broadcasting;

public interface HDCOAHEBHMA
{

 bool IsInitialized
{
get ;
}

 bool IsBroadcasting
{
get ;
}

 bool IsInBroadcastingRoom
{
get ;
}

 global::HHOBPMOCKMJ<(long, int)> EventAuthorizationStatusChanged
{
get ;
}

	void KCLJJKHIBKK(int IPMIIEAGJKC);

	void IOLDLNIMKAH(object[] LPHIPOLKJOK);

	void BHHMNJIIEFK(object PCPEJHIMHJJ);

	BroadcastingManager.DNGGEIPPHLG? GetEventBroadcastingAuthorization(int EJIHLJJMOBD);

	void Connect(IBINLLOMNPN EKOFNPFCLMO, BroadcastingManager.CGOKGJPDIAF LMCAEKEFKCH, string LEGPGAPNFKC = null);

	void Connect(BroadcastingManager.CGOKGJPDIAF LMCAEKEFKCH, string LEGPGAPNFKC = null);

	void StopBroadcasting(IBINLLOMNPN EKOFNPFCLMO);

	void StopBroadcasting();

	void RequestEventBroadcastingAuthorization();

	void SetEventBroadcastingAuthorizationStatus(int EJIHLJJMOBD, BroadcastingManager.DNGGEIPPHLG AJLDNMPIGNP);
}
