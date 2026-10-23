using System.Collections.Generic;
using UnityEngine;

public abstract class GNEENOANCIM
{
	[OFENKFBEDDN]
	public enum IMNMCGGINJG
	{
		Invalid = -1,
		PrecisePhase = 0,
		BroadPhase = 1
	}

	public delegate bool ABLDJLKKHJP(LMFLCFFHNOF PCNPMPMHGHF, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, IMNMCGGINJG IFEOGBCJEBI);

	protected struct LABCHKLKFJM
	{
		public LMFLCFFHNOF BJEHKJKAMEA;

		public LMFLCFFHNOF JKKMCNGKOFP;
	}

	private readonly List<ABLDJLKKHJP> CHFOGAJOJIP;

	public abstract bool MKGOGNPMHEM(LMFLCFFHNOF PCNPMPMHGHF, Player BBHMKAPPKOD, PlayerHand GHODAKHBECE);

	public abstract LMFLCFFHNOF HIDCLHJDPGP(Ray CMDHIGCJLEH, Player BBHMKAPPKOD, PlayerHand GHODAKHBECE, out Collider FIJIODDNINO);

	public abstract LMFLCFFHNOF GAANCDIEOIE(Ray CMDHIGCJLEH, Player BBHMKAPPKOD, PlayerHand GHODAKHBECE, out Collider FIJIODDNINO);

	public void KBHEHEFFOKF(ABLDJLKKHJP NHJPBHJLFOD)
	{
	}

	public void KPFCKHNHGPC(ABLDJLKKHJP NHJPBHJLFOD)
	{
	}

	protected bool NAHHJJLFGCN(LMFLCFFHNOF PCNPMPMHGHF, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, IMNMCGGINJG IFEOGBCJEBI)
	{
		return false;
	}

	protected LABCHKLKFJM KEDNLPDDPCE(Collider LPGAJGPGKFM)
	{
		return default;
	}

	protected bool JDLFBFCKCMO(LABCHKLKFJM GNEFJMKLFBL, Collider ADMCDJKKCIA, Player BBHMKAPPKOD)
	{
		return false;
	}
}
