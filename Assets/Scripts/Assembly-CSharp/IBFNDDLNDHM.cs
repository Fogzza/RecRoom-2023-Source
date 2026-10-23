using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom;
using RecRoom.Core.Combat;
using RecRoom.Core.Controllers.ScreenBehaviors;
using RecRoom.Tools.Weapons;
using RecRoom.UI;
using UnityEngine;

public class IBFNDDLNDHM : global::PKMKGBILFKD<IBFNDDLNDHM, RangedWeaponScreenToolBehaviorConfig>
{
	private enum MGJJMNKCGPB
	{
		DISABLED = 0,
		IDLE = 1,
		FIRE_QUEUED = 2,
		FIRING = 3,
		RELOAD = 4
	}

	private enum ONOHJOBJNLH
	{
		DISABLED = 0,
		NORMAL = 1,
		AIM_DOWN_SIGHTS = 2
	}

	private enum IKPOJEMNCBB
	{
		NOT_SUPPORTED = 0,
		UNAVAILABLE = 1,
		BLOCKED_BY_OTHER_TOOl = 2,
		AVAILABLE = 3
	}

	private sealed class MFHPIIGIIFA : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public IBFNDDLNDHM _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public MFHPIIGIIFA(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
		{
			return null;
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private MDEJADHJOEJ CHNOKNNOIBI;

	private MDEJADHJOEJ AGHHNDNNOOB;

	private bool KIEIGNLPDEN;

	private int KGBOGIHCFNP;

	private NEJPICDKICB DFCPCPLPNFC;

	private NEJPICDKICB HNGKIMLEKAA;

	private NEJPICDKICB GGNGEHBIMID;

	private RangedWeapon KBPKGKEMHED;

	private WeaponReloader DBINEJHDFKC;

	private object NIMJIJBNGFL;

	private bool OGFEONLAFJJ;

	private float KPLOLOBPAMO;

	private float GPOOEMAHELP;

	private bool ININBEKOFON;

	private float EEDFBNGBFEA;

	private float JLDCJBDGLME;

	private float OJLOMHIHCPH;

	private float FNGMCJBGJJK;

	private LKGILLBEJEK PKHBNALAMKA;

	private static readonly DCMFJJFGEBC GPKEMIJLNMM;

public override int LDHIBGALEDK
{
get 	{
		return 0;
	}

}

public override bool HFDBOJHHDHK
{
get 	{
		return false;
	}

}

private FMNJCGLEDJO MKACNODFJDC
{
get 	{
		return FMNJCGLEDJO.SmartInteractButton;
	}

}

	public override void IHEKMEOIBOI(RangedWeaponScreenToolBehaviorConfig FPJKGKBOAOA, KHDONLOELFG HJOOFGLHNBG)
	{
	}

	public override void Dispose()
	{
	}

	protected override void LDBOEGKIPKO()
	{
	}

	protected override void LIKPEPFGGFO()
	{
	}

	public override void EHMICKMBCPH()
	{
	}

	public override void EMKNJNEKHFE()
	{
	}

	private void DHKNKKFJNMC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void KHCLBMBFPLC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void MPBJLGJNLMD()
	{
	}

	private void IEFKHCGHFCC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void BGCFHAHAIAE()
	{
	}

	private void LIGNDJBDFEA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void KPFJEIGBLNF(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void AHKLHABNGEB()
	{
	}

	private void PEALFPKCOIM(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void EGKDFECDPBH(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void NHMCEEOEAGE()
	{
	}

	private void DNMFJFHMCKL(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void LIJNEHCAOHM(PlayerAnimationEvent.BKEAPIGNCKG ENKMDOKIHHM, Vector3 LOPELAGELCJ, Vector3 NIPDPGEFIOB)
	{
	}

	private void HKHAEHOILPI(PlayerAnimationEvent.BKEAPIGNCKG ENKMDOKIHHM, Vector3 LOPELAGELCJ, Vector3 NIPDPGEFIOB)
	{
	}

	private void IIHFEILINCA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void OBNOMOLGDFH()
	{
	}

	private void ACDIJFOAAMP(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void PDKPLBPCNAK(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void PDAFMEOKMBB()
	{
	}

	private void ELJDCHHOPAH()
	{
	}

	private void ENLADIMDENA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void COJLNJBDBMN()
	{
	}

	private void KPJECGLAGGL()
	{
	}

	private void OICABKMKNCG(bool IMFOAGCMOMJ)
	{
	}

	private void GJIMBOMKFBD(bool HCLCIHDJDGJ)
	{
	}

	private void GLBDNFNJKEG()
	{
	}

	private void BFCKNLHNKCO()
	{
	}

	private bool MNBLHKAOGHJ()
	{
		return false;
	}

	private bool JBAMMHFICEE(bool HAJEBGCHIHH)
	{
		return false;
	}

	private bool LHPNHGPOLHM()
	{
		return false;
	}

	private bool EPHHJBPJNHF()
	{
		return false;
	}

	private void JNMCOAPJNJB()
	{
	}

	private bool OFLOMKPHOOB()
	{
		return false;
	}

	private void JHEAKBBACDL(RangedWeapon KBPKGKEMHED)
	{
	}

	private void NPPLPBBGCOB(bool HCLCIHDJDGJ)
	{
	}

	private bool NIPKFDFGNFI()
	{
		return false;
	}

	private bool KFBPBAOFJNK(float DPJBMHNFEMK)
	{
		return false;
	}

	private void DKAFOOHACFI()
	{
	}

	private float NDDDPPLEOOM(bool HCLCIHDJDGJ, out ScreenHUDCrosshair.IKNLFLEALLL EBBNMKKOLJD)
	{
		EBBNMKKOLJD = default;
		return 0f;
	}

	private float AGFCIHLLLOP(bool HCLCIHDJDGJ)
	{
		return 0f;
	}

	private bool PAMCFJCGKDF()
	{
		return false;
	}

	private void MAAELGFGMLN()
	{
	}

	private bool IAGGPGPEENM(bool HAJEBGCHIHH)
	{
		return false;
	}

	private IKPOJEMNCBB MFACKJJNIKG()
	{
		return IKPOJEMNCBB.NOT_SUPPORTED;
	}

	private bool DECEJENFDBJ()
	{
		return false;
	}

	private bool ILCGGCHKOLH()
	{
		return false;
	}

	private bool PHKMCGMMGOK()
	{
		return false;
	}

	private void CHBAHHJJBHN()
	{
	}

	private void LLNFMDOEBOO()
	{
	}

	private void CKGGFBFJKKN()
	{
	}

	private void MAMDNGMDGHH()
	{
	}

	private void ODJEIJCGFOD()
	{
	}

	private bool BGPHBNIKILI()
	{
		return false;
	}

	private bool ECCECICDALH()
	{
		return false;
	}

	private bool OCAGJGGLLDI()
	{
		return false;
	}

	private bool BENPKGAPELB()
	{
		return false;
	}

	private DLLIMLHNBON LKMIIMKBKME()
	{
		return default;
	}

	private void FLNDPOJFLJO(bool EPDJDCDHLMP)
	{
	}

	private void NKGELEFJMNI()
	{
	}

	private void DDGBJDPAEGP()
	{
	}

	private IEnumerator<EGGPGCCKPCO> PMMEIMPPNOO()
	{
		return null;
	}
}
