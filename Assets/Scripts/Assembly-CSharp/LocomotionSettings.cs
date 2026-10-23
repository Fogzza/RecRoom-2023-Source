using UnityEngine;

[DisallowMultipleComponent]
public class LocomotionSettings : MonoBehaviour
{
	public enum ONLKKJMBAFN
	{
		Restrict = 0,
		Allow = 1
	}

	public delegate bool JKLOLDPIHAA(CHILKDJABBF EKOFNPFCLMO);

	public delegate bool GHCDFDMKDAK(CHILKDJABBF EKOFNPFCLMO);

	private JKLOLDPIHAA BMFPEMPGONM;

	public bool SupportsClimbing;

	public bool SupportsClambering;

	public bool SupportsWallRunning;

	public GHCDFDMKDAK GetCollisionIgnoredDelegate;

	public void SetSupportsLocomotionForPlayer(JKLOLDPIHAA ONAFALABHKI)
	{
	}

	public bool SupportsClimbingForLocalPlayer()
	{
		return false;
	}

	public bool SupportsClimbingForPlayer(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	public bool SupportsClamberingForLocalPlayer()
	{
		return false;
	}

	public bool SupportsClamberingForPlayer(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	public bool SupportsWallRunningForLocalPlayer()
	{
		return false;
	}

	public bool SupportsWallRunningForPlayer(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	public bool PlayerIgnoresCollisionWith(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	public static bool TryGetFromCollider(Collider ADMCDJKKCIA, out LocomotionSettings CIEEFNAILGB)
	{
		CIEEFNAILGB = null;
		return false;
	}

	public static bool TryGetFromTool(Tool IEGMBEPJMGC, out LocomotionSettings CIEEFNAILGB)
	{
		CIEEFNAILGB = null;
		return false;
	}

	public static bool TryGetOrAddFromTool(Tool IEGMBEPJMGC, out LocomotionSettings CIEEFNAILGB)
	{
		CIEEFNAILGB = null;
		return false;
	}
}
