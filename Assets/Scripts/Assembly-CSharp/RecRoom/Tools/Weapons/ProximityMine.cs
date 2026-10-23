using System.Collections.Generic;
using System.Text;
using RecRoom.Audio;
using RecRoom.Core;
using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class ProximityMine : Grenade, DJLCHGFCFAD, JICDMECOFLC
	{
		private enum COOMGDHPMLP
		{
			LAUNCHED = 3,
			ARMING = 4,
			TRIGGERED = 5
		}

		private static readonly int EBDOFLBHNJD;

		private static readonly int MJPIIGCHENN;

		private static readonly int MNLBCJFPNCC;

		[SerializeField]
		private SimpleSticky sticky;

		[SerializeField]
		private float armingTime;

		[SerializeField]
		private bool defaultTriggeredByTeammates;

		[SerializeField]
		private float triggeringTime;

		[SerializeField]
		private OverlapVolume detonationTriggerOverlapVolume;

		[SerializeField]
		private EnemyOverlapVolume detonationTriggerEnemyOverlapVolume;

		[SerializeField]
		private float timeAfterDetonationBeforeReset;

		[SerializeField]
		private Transform explosionRaycastOrigin;

		[SerializeField]
		private RecRoomAudioClip armingAudioClip;

		[SerializeField]
		private RecRoomAudioClip armedAudioClip;

		[SerializeField]
		private RecRoomAudioClip triggeredAudioClip;

		private ParticleEventListener OBINFJJHMPK;

		private Collider PHHDEAIFABO;

		private global::MOBDJNEDDKC<bool> BFICCDOONBH;

		private global::MOBDJNEDDKC<bool> AHDJEKBCDDE;

private bool LDOFCKGEGEC
{
get 		{
			return false;
		}

set {
		}
}

private bool FHKIOONEJFB
{
get 		{
			return false;
		}

set {
		}
}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void AuthorityArmGrenade()
		{
		}

		protected override void IFCFEJLCKCF(CHILKDJABBF ACNLJOAAJMA, Weapon PANFKBPMCFI, bool PLCBPELAHBM, bool NCBKFMHNIFD, bool HDJAIKKBLDI)
		{
		}

		private bool PJCFBMINANN(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
		{
			return false;
		}

		private void MCDBKGENIEA(Tool IEGMBEPJMGC)
		{
		}

		private void IEELJEBHDEI(Tool PMEFICGEDFK)
		{
		}

		private void GGBKANLJGCH(Tool IEGMBEPJMGC)
		{
		}

		private void KECCDJOPBKP(Tool BGMJMJKDNED)
		{
		}

		private void FMKBCBBCIIE(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void BEEPGDAFPGH()
		{
		}

		private void JOKANGGIBEG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void ACGKFONEIJC()
		{
		}

		protected override void FMJNDHMBJEC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected override void CJOMFNGPHEE()
		{
		}

		protected override void IOKNENCFBCE(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void PPOIJNACPLJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void DOAIGCAMADF()
		{
		}

		protected override void GPJPAEFLABD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void INDPMFJFBAE()
		{
		}

		protected override void BMFONHPBFAN(Player ACNLJOAAJMA, Weapon PANFKBPMCFI)
		{
		}

		private bool CCDIBEFBJGD(NGLCDIDOEMK BNFNJFKJEOA)
		{
			return false;
		}

		protected override void MGKPHCBKLEN(Player EKOFNPFCLMO, Player.NBPIPAJOGLC MKLOBAIKINA, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void HIMBHEKNECN(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private Collider ACILJKIKDMI(Collider BIBMKDDMLFI)
		{
			return null;
		}

		protected override void AJEBBOBCEED(Trap AOCKEAPKNDE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void OnCollisionEnter(Collision HNPEBINPOBO)
		{
		}

		private void LAPPJACOBHD(OverlapVolume COFONCKAJCK)
		{
		}

		private void INNBKFINMPD(OverlapVolume COFONCKAJCK, Enemy DPENEFKKNDN)
		{
		}

		protected void BLKIGJANNAO(bool OBFHBDLKFPA)
		{
		}

		protected override PooledParticle FFPFAECAFII()
		{
			return null;
		}

		private void HBOHADJADPJ(ParticleEventListener NFCDBEKMGLP, Collider HNPEBINPOBO, IEnumerable<ParticleCollisionEvent> LKLOMDKCAPK)
		{
		}

		public IReadOnlyList<DGMPBIPKJEB> GetConfigurableDynamicUI(List<JICDMECOFLC> OKGFHDGAPBM = null)
		{
			return null;
		}

		private bool KHBMNHJPJOG()
		{
			return false;
		}

		private void KEGKCEABGBC(bool IPMIIEAGJKC)
		{
		}

		private void OGMPGCHPGFH()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}
	}
}
