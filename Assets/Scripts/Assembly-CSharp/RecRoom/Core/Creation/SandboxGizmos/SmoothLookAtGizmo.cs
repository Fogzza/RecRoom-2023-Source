using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using RecRoom.Systems.PlayerRoles;
using UnityEngine;

namespace RecRoom.Core.Creation.SandboxGizmos
{
	public class SmoothLookAtGizmo : InfluencerGizmo, LEJOPAFDMEE, DJLCHGFCFAD
	{
		private enum ODDDHPALMPG : byte
		{
			Average = 0,
			Closest = 1
		}

		private enum LGBEMJICJCG : byte
		{
			Object = 0,
			Player = 1
		}

		private enum NAMGDICKFKE
		{
			Head = 0,
			Hands = 1,
			LeftHand = 2,
			RightHand = 3
		}

		private const float NDONFEJLCKK = 1080f;

		private static readonly Dictionary<string, MIBJNNKFLND> MHJNOPPNNLF;

		[SerializeField]
		private Vector3 AxleRendererRotation;

		[SerializeField]
		private Tooltip tooltip;

		private global::MOBDJNEDDKC<string[]> DPAJJPGHLGA;

		private global::MOBDJNEDDKC<Guid> GGKHKMLKEBH;

		private global::MOBDJNEDDKC<int> JLNFIKBLMJF;

		private global::MOBDJNEDDKC<ODDDHPALMPG> BLHMCHDPEAA;

		private global::MOBDJNEDDKC<LGBEMJICJCG> PLHGIKHNPPP;

		private global::MOBDJNEDDKC<NAMGDICKFKE> HMHFCBOJDKI;

		private float IMPPFABBIDM;

		private List<Vector3> OGNPEONANBH;

		private bool KFHJOONNOMK;

public string[] CurrentTags
{
get 		{
			return null;
		}

set {
		}
}

public Guid CurrentRole
{
get 		{
			return default;
		}

set {
		}
}

public int SmoothingAmount
{
get 		{
			return 0;
		}

set {
		}
}

private ODDDHPALMPG JBCKKMEJAOM
{
get 		{
			return ODDDHPALMPG.Average;
		}

set {
		}
}

private LGBEMJICJCG CMDGCBOFENN
{
get 		{
			return LGBEMJICJCG.Object;
		}

set {
		}
}

private NAMGDICKFKE AMCHBBAOIHF
{
get 		{
			return NAMGDICKFKE.Head;
		}

set {
		}
}

protected override string BLDIMIHMMGD
{
get 		{
			return null;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void MBJJANCBHGF(GameRole DHFJFGFHFEG)
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override AKCHPHOMHLH MNECEOLGCKC()
		{
			return null;
		}

		protected override void IHLNPHDKJOO()
		{
		}

		private void BDMJGBHHIGM()
		{
		}

		private void FCIIMKBJADO(Player EKOFNPFCLMO)
		{
		}

		private Vector3 GPBOLNNBLII(List<Vector3> ODFEKFPHMMP)
		{
			return default;
		}

		private Vector3 OHJNHGDBLGD(List<Vector3> ODFEKFPHMMP)
		{
			return default;
		}

		private Quaternion IKDBNFHOGBB(Vector3 INLGLHIPOMC, float KCDONHKCFBI)
		{
			return default;
		}

		private int DPDJBKIHDFI()
		{
			return 0;
		}

		private void LGIJOHMEJBP(int DLEMNBPMGBG)
		{
		}

		private int DPGNGFGMGGD()
		{
			return 0;
		}

		private void DLDOBAPKCLL(int DLEMNBPMGBG)
		{
		}

		private int DGLAOFFMPMK()
		{
			return 0;
		}

		private void LNOGOFECIKC(int DLEMNBPMGBG)
		{
		}

		private string IPGKMABCNKC()
		{
			return null;
		}

		private void JMJLBNOPEPC(Guid JKHAGFEKALE)
		{
		}

		private Guid IPILLIJHOGB()
		{
			return default;
		}

		private void LJANPHLPDPE(string OMMKMMMFFCK)
		{
		}

		private int OGMPAJLKIJP()
		{
			return 0;
		}

		private void KDPNJDAPJLH(int IPMIIEAGJKC)
		{
		}

		private void LJLGPPDAKDK()
		{
		}

		private void EJCNALHBFFJ()
		{
		}

		private void OHDKMIAEEEI()
		{
		}

		private void LACIHFDMIKG()
		{
		}

		public override void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		public override void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void PostDeserialize(GNFJMCHKBIK ALCJDCGEBLM)
		{
		}

		[CompilerGenerated]
		private bool EECMHMJFPJL()
		{
			return false;
		}

		[CompilerGenerated]
		private bool LGGDKOFHOKK()
		{
			return false;
		}

		[CompilerGenerated]
		private bool LEHHCFJMHEJ()
		{
			return false;
		}
	}
}
