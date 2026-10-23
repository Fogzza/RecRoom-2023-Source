using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ExitGames.Client.Photon;
using Photon.Pun;
using RecRoom;
using UnityEngine;

[DisallowMultipleComponent]
public class ToolCleanup : MonoBehaviourPun, DJLCHGFCFAD, JICDMECOFLC
{
	public struct EBDFPPJCLLB
	{
		public const float JDFFIFNDMPE = 1.5f;

		public const float BPEIJKCJOOJ = 1f;

		public const float MEBECPEELNM = 30f;

		private const int LLDCOLKDGPC = 10;

		private static readonly ELFDKCLHAMN DGJEOFHPNDP;

		public Vector3 KIJJFLMPGME;

		public Quaternion NELEDPLLGGE;

		public float CPICIGDBCLL;

public static EBDFPPJCLLB FBJHBFFDBDJ
{
get 		{
			return default;
		}

}

		public static short IIADKJHBOIN(StreamBuffer HLHADAOGCMN, object PJGPNPBFMFD)
		{
			return 0;
		}

		public static object BBCFAILGGHN(StreamBuffer FAMJGEFEDDM, short MNKGPEKFPKK)
		{
			return null;
		}
	}

	public struct MMLAJCJPFGA
	{
		public bool GBMOBPKAHDB;

		public float FHFDDKOBFLG;
	}

	public delegate bool DADHOAFJANK(out Vector3 INLGLHIPOMC, out Quaternion POIOCLOKJGH);

	private const string BKJCJGGAMKA = "ToolCleanup";

	private const float MMNFNADJKCK = 15f;

	private const float OMBKHJDCLLC = 0.1f;

	[SerializeField]
	private bool excludeFromCleanup;

	[SerializeField]
	private bool allowUserOverrides;

	public float MinDisplacementBeforeCleanup;

	public float defaultMinPlayerDistanceBeforeCleanup;

	public float MinRotationAngleBeforeCleanup;

	public float defaultDelayUntilCleanup;

	public bool OnlyCleanupWhenSleeping;

	[NonSerialized]
	public Player Owner;

	public DADHOAFJANK CustomGetResetPositionAndOrientationBehavior;

	[EFEFIKFHIDK]
	[SerializeField]
	private Tool tool;

	private Vector3 LFOPANJOPOJ;

	private Quaternion POOCFDDPNAB;

	private global::MOBDJNEDDKC<bool> HBCKCPDBHGL;

	private global::MOBDJNEDDKC<EBDFPPJCLLB> IPJAKCNKGAP;

	private global::MOBDJNEDDKC<bool> HIAGMEKPNOI;

	private bool AKDBPHEHLAN;

	private float NCPFBCJHPMB;

	private FIHGBEHGLGB MKBDPAKFGIB;

	private FIHGBEHGLGB LCENBBMMCAO;

private bool KJKKEAICJLL
{
get 	{
		return false;
	}

set {
	}
}

private EBDFPPJCLLB CHFFCOFECHA
{
get 	{
		return default;
	}

set {
	}
}

public bool ForceCleanupQueued
{
get 	{
		return false;
	}

private set {
	}
}

public bool IsEnabled
{
get 	{
		return false;
	}

}

public bool IsRunningAutomatically
{
get 	{
		return false;
	}

}

private bool BINPEPPIBDJ
{
get 	{
		return false;
	}

}

private bool MPODHFDOADA
{
get 	{
		return false;
	}

}

private bool FCNMKNIPPLM
{
get 	{
		return false;
	}

}

private float IFDEMNBDGKM
{
get 	{
		return 0f;
	}

}

private float NBMHFPJOKAI
{
get 	{
		return 0f;
	}

}

public bool BlockObjectPersistance
{
get 	{
		return false;
	}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 	{
		return GKDCHLMLHBJ.RunForAuthorityOnly;
	}

}

	private static bool OOCFAJOFIHC(EBDFPPJCLLB FMMJFLMIBAO)
	{
		return false;
	}

	protected override void Awake()
	{
	}

	private void MANOIOFDEEM(RigidbodyEx NEJMOIPCOAO, bool LDEEGDEKBLJ)
	{
	}

	private void Start()
	{
	}

	private void NPMKBOLHHCN(bool DKJKJNEKKNA)
	{
	}

	protected override void OnDestroy()
	{
	}

	private void PLLGKABPABI(Tool IEGMBEPJMGC, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
	{
	}

	private void PLLGKABPABI(Tool IEGMBEPJMGC, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP, Space CFOHFHCKNNM)
	{
	}

	private bool JHPMOHFBCFJ(Vector3 EEEHDCHEKDB, Quaternion EBPFMKAKAKK, Vector3 LFIMDICFBCE, Quaternion MKFGBBACPBL)
	{
		return false;
	}

	private bool DAINEHLHBNM(out PAOFKDGAONA BGDMKGJPDBD)
	{
		BGDMKGJPDBD = default;
		return false;
	}

	private void FCLDJCODIJD(PAOFKDGAONA BGDMKGJPDBD)
	{
	}

	public void GetCleanupPositionRotation(Space CFOHFHCKNNM, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH)
	{
		INLGLHIPOMC = default;
		HEGBBJCMANH = default;
	}

	public void GetCleanupLocalPositionRotation(out Vector3 EGJKEDKNNAD, out Quaternion IBHAEICNMJI)
	{
		EGJKEDKNNAD = default;
		IBHAEICNMJI = default;
	}

	public void AuthorityQueueForceCleanup(bool GLKBGPHMMNC = false)
	{
	}

	public void PauseAutomaticCleanup(object IALNODEHBNN)
	{
	}

	public void ResumeAutomaticCleanup(object IALNODEHBNN)
	{
	}

	public void DisableCleanup(object IALNODEHBNN)
	{
	}

	public void EnableCleanup(object IALNODEHBNN)
	{
	}

	public void CheckCleanup()
	{
	}

	public void LogOwner()
	{
	}

	public bool InCleanupPositionRotation()
	{
		return false;
	}

	private void LNPGPPDNPPP()
	{
	}

	private void EAKHCJHMFCF(Player GCILADHGICM)
	{
	}

	private bool DMBKAOEKABB()
	{
		return false;
	}

	private bool PBEKIEFPAEF(Player EKOFNPFCLMO)
	{
		return false;
	}

	public void SetResetTransformToCurrent()
	{
	}

	public void SetResetTransform(in Vector3 EGJKEDKNNAD, in Quaternion IBHAEICNMJI)
	{
	}

	public void SandboxOverride_Set(MMLAJCJPFGA KPMMJCPBEDO)
	{
	}

	public MMLAJCJPFGA SandboxOverride_Get()
	{
		return default;
	}

	public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
	{
	}

	public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
	{
	}

	public IReadOnlyList<DGMPBIPKJEB> GetConfigurableDynamicUI(List<JICDMECOFLC> OKGFHDGAPBM = null)
	{
		return null;
	}

	[CompilerGenerated]
	private object MBCJLCPIKKG()
	{
		return null;
	}

	[CompilerGenerated]
	private object OBKFFNHKDCP()
	{
		return null;
	}

	[CompilerGenerated]
	private bool BPEKANODOPN()
	{
		return false;
	}

	[CompilerGenerated]
	private void PPNFFBPOOAL(bool IPMIIEAGJKC)
	{
	}

	[CompilerGenerated]
	private float BKHKIPOANMI()
	{
		return 0f;
	}

	[CompilerGenerated]
	private void HLDMILEJPGJ(float IPMIIEAGJKC)
	{
	}

	[CompilerGenerated]
	private bool FDDNDOGBDIG()
	{
		return false;
	}
}
