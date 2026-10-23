using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace RecRoom.Core.Creation.Holotars
{
	public abstract class HolotarBase : RecordableObject<FPDMEIABFON>, DJLCHGFCFAD, GAAKCFPLMHN
	{
		[SerializeField]
		private HolotarPreviewPuppet previewPuppetPrefab;

		[SerializeField]
		private HolotarPlaybackPuppet playbackPuppetPrefab;

		[SerializeField]
		private Transform puppetRoot;

		[SerializeField]
		private HolotarUIPivot puppetPivot;

		[NonSerialized]
		public bool LoadFromResources;

		protected HolotarPreviewPuppet FPMJOMCMJPH;

		protected HolotarPlaybackPuppet JLGJCCDKGJM;

		private global::MOBDJNEDDKC<bool> FPKKPMPAGEM;

public bool BillboardPlayback
{
get 		{
			return false;
		}

set {
		}
}

protected bool ENBMFJBHOKP
{
get 		{
			return false;
		}

}

public abstract bool IsPlaybackStopped
{
get ;
}

private bool DOLHDMJMHDA
{
get 		{
			return false;
		}

}

protected override bool NEMDEFFNDFG
{
get 		{
			return false;
		}

}

protected float EKEDPHOHBKM
{
get 		{
			return 0f;
		}

}

public virtual bool IsPlaybackPaused
{
get 		{
			return false;
		}

}

public float Timestamp
{
get 		{
			return 0f;
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

		protected override void INCGHMFPBFL()
		{
		}

		protected virtual IEnumerable<DGMPBIPKJEB> ONAJDNHGOJA()
		{
			return null;
		}

		public void ResetObject()
		{
		}

		private void LLBOFBKEIDG()
		{
		}

		public override void MasterSetResourceBlobName(string KNOPFGAGMCN)
		{
		}

		protected virtual void BLCKBNPODKB(float BBGNJMKOHPL)
		{
		}

		protected override void PBECKAIBLPA(ushort EHLPLCEJPDD, ushort DFNBMANKLGD)
		{
		}

		protected override void JMDILEHHBOL(ushort EHLPLCEJPDD, ushort DFNBMANKLGD)
		{
		}

		protected override void JBIGJNMJHBA(ushort ANAKIMJNHMH, ushort KJLHJFEJJGM)
		{
		}

		protected override void GLJMBIOFPBG()
		{
		}

		protected abstract void HICMIPHDOHF();

		private void DFMKDJIOBOC()
		{
		}

		private void AECOIAKAMAP()
		{
		}

		protected override void AGGENGGIKPN(ushort EHLPLCEJPDD, ushort DFNBMANKLGD)
		{
		}

		protected override void BBBDOCKAMAK(ushort ANAKIMJNHMH, ushort KJLHJFEJJGM)
		{
		}

		protected override void LLNFKHHNLLJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected override void PBKHIGPABCP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected override void JBGMNNKCHGC()
		{
		}

		protected override void IAKMFHGOONG()
		{
		}

		private void DEFHHMBPMJA(out FPDMEIABFON.BAGKGLJDBMA.DNKGILJELHJ CLOLACPGMFL)
		{
			CLOLACPGMFL = null;
		}

		protected override void DNBBAAJCLHK(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected override void JNNMOKMPBKP(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected override void POCPDPLFEDJ(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected override void FNGDAJACBKP()
		{
		}

		protected virtual void CNGBCMDPFOH()
		{
		}

		protected virtual void FPDAMENHOML()
		{
		}

		protected override FPDMEIABFON NJCEGKLCIHO()
		{
			return null;
		}

		protected override void GCPDKOBDKPE()
		{
		}

		protected override bool KDNOKDCPCNB()
		{
			return false;
		}

		protected virtual void KMAEAOHJJLE(FPDMEIABFON PCPEJHIMHJJ, bool KNMILELNMFH)
		{
		}

		private void PDFLMFILCDJ()
		{
		}

		protected void DCNMJEFGJEK(bool GMEKKCPLMOB)
		{
		}

		protected virtual void PEDODFLKPLI()
		{
		}

		private void IDOFGOIPOFH()
		{
		}

		private void LANOJCGLGAN()
		{
		}

		private bool LBDONDDCDHH(Tool IEGMBEPJMGC, Player EKOFNPFCLMO, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
		{
			return false;
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		protected virtual void MKEMEBAFJBH(PFMAFCHDGJL GEBEJEKEBJK)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		protected virtual void LIIIGKOOMHN(PFMAFCHDGJL GEBEJEKEBJK)
		{
		}

		[CompilerGenerated]
		private bool BNKIOFFKEDO()
		{
			return false;
		}

		[CompilerGenerated]
		private void HLKLBCPMNAA(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private void JEBCDIHFEFA(LDCCJDCBBPA MMEDLDHCDLP)
		{
		}

		[CompilerGenerated]
		private void PMINLKNMHAL(EKJDFEMBJGH.GOAHNLAOBJK EFNJCAIBDLA)
		{
		}
	}
}
