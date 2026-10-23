using Photon.Pun;
using RecRoom;
using RecRoom.Core;

public abstract class BaseRecRallyVehicle : MonoBehaviourPun, IOMDCIACIMF
{

public abstract bool HasDriver
{
get ;
}

public abstract bool HasOccupant
{
get ;
}

public abstract RigidbodyEx Rigidbody
{
get ;
}

public abstract bool AllowsBoosting
{
get ;
}

	public abstract void SetSteering(float OHPLGHHAECG);

	public abstract void AuthoritySetGas(float KNFJJMDFBNI);

	public abstract void AuthorityApplyHandbrake();

	public abstract void AuthorityApplyBoost(bool BFJEOLLFOOC);

	public abstract void AuthorityApplyReset(EGMDNODKGIA EMCILMHMENA);

	public abstract void AuthoritySetDriving(bool ILLIAOKHBGE);

	public abstract void AuthorityResetSuspension();

	public abstract void AuthorityApplyLocalDriverFavoriteSkin(Player POAFANOMOJE);

	public abstract void AddRestrictionToSeats(SeatManagement.FDMADKNOFCI NAOILMPNIEO);

	public abstract void RemoveRestrictionToSeats(SeatManagement.FDMADKNOFCI NAOILMPNIEO);
}
