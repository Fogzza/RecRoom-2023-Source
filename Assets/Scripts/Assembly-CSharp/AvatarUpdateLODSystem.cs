using System;
using RecRoom.Avatars;
using UnityEngine;

public class AvatarUpdateLODSystem : MonoBehaviour, DFBGLPCFOHL
{
	private sealed class HIIECMDLMGI
	{
		public AvatarUpdateLODSystem _003C_003E4__this;

		public int level;

		internal void _003CSetAvatarLOD_003Eb__0()
		{
		}
	}

	private IDisposable LBKDICIFEGK;

	private JNKNMMDAHCF DHCLACKALOF;

	[SerializeField]
	private PlayerAvatarDisplay PlayerAvatarDisplay;

	[SerializeField]
	private Player Player;

	public global::AJDJDHGLIEC<AvatarUpdateLODSystem> otherPlayerCullingGroup;

	private AMBBOEBJPNH GOOLGBMBJLA;

private static LHMPPJKHCJG JHAIBHMKHBE
{
get 	{
		return null;
	}

}

private Transform ELEMBGELFOE
{
get 	{
		return null;
	}

}

public AMBBOEBJPNH MyUpdateLod
{
get 	{
		return AMBBOEBJPNH.TwoPointFiveMeters;
	}

set {
	}
}

public static AMBBOEBJPNH MinOtherPlayerUpdateLOD
{
get 	{
		return AMBBOEBJPNH.TwoPointFiveMeters;
	}

set {
	}
}

 Transform global::DFBGLPCFOHL.transform
{
get 	{
		return null;
	}

}

	public void Awake()
	{
	}

	public void OnChangedDistanceBand(AMBBOEBJPNH MOCEBLJHGPF, AMBBOEBJPNH ELOPMNNDIJD)
	{
	}

	public void OnChangedVisibility(bool GMEKKCPLMOB)
	{
	}

	public void UpdateAvatarLODs(AMBBOEBJPNH KBOFMFGOHIM, AMBBOEBJPNH DJNFNJHEMHB)
	{
	}

	public void SetAvatarLOD(int OFMKJBIBDCL)
	{
	}

	private void BJFICNONGKL(int OFMKJBIBDCL)
	{
	}

	private int DODACEELJLK(AMBBOEBJPNH OHEJDBOPOCH, GHCCKFEJDOA PKJIEOPNCHK)
	{
		return 0;
	}

	private int NPAAGOFINEM(AMBBOEBJPNH OHEJDBOPOCH)
	{
		return 0;
	}

	private int AGPACIDAJPL(AMBBOEBJPNH OHEJDBOPOCH)
	{
		return 0;
	}

	public void RecalculateMinOtherPlayerUpdateLOD()
	{
	}

	protected void OnDestroy()
	{
	}
}
