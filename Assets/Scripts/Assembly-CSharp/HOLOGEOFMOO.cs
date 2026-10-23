using UnityEngine;

public interface HOLOGEOFMOO
{

 PhysicalButtonBase.PhysicalButtonPressEvent PressEvent
{
get ;
}

 PhysicalButtonBase.PhysicalButtonStateEvent OnReleaseEvent
{
get ;
}

 PhysicalButtonBase.PhysicalButtonStateEvent OnPressTransferEvent
{
get ;
}

	CHILKDJABBF GetSomePressingPlayer();

	CHILKDJABBF GetSomePressingPlayer(out Collider ADMCDJKKCIA);

	bool PlayerPushedButton(CHILKDJABBF EKOFNPFCLMO);

	bool PlayerReleasedButton(CHILKDJABBF EKOFNPFCLMO);
}
