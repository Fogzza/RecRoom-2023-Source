using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using RecRoom.Core.Pools;
using UnityEngine;

public class BreakableObject : MonoBehaviourPun, DJLCHGFCFAD, JCPJHDPNDKB, JICDMECOFLC
{
	private sealed class ABJNOLDBNDP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BreakableObject _003C_003E4__this;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public ABJNOLDBNDP(int _003C_003E1__state)
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
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private MeleeWeapon thisWeapon;

	private bool IMMNMHHLLEF;

	[SerializeField]
	private ToolPlayerAttractor attractor;

	[SerializeField]
	private GameObject wholeObject;

	[SerializeField]
	private GameObject fracturedObject;

	[SerializeField]
	private bool shatterOnAnyImpact;

	[SerializeField]
	private float shatterSpeed;

	[SerializeField]
	private float brokenLifetime;

	[SerializeField]
	private DJBEHNDMJDL[] OnlyAllowDamageFromSources;

	[SerializeField]
	private DJBEHNDMJDL[] DisallowDamageFromSources;

	[SerializeField]
	private float advancedPhysicsPortionOfVelocityUsedForShattering;

	[SerializeField]
	private float advancedPhysicsMinimumImpulseForBreakage;

	[SerializeField]
	private PooledParticle smashParticlePrefab;

	[SerializeField]
	private RecRoomAudioClip[] smashSounds;

	private global::MOBDJNEDDKC<int> CMOCBCIONGB;

	private global::MOBDJNEDDKC<bool> FHNFEELBAAL;

	private FIHGBEHGLGB AGDMCCILFOJ;

	private RagdollPiece[] DOEMJLEEDFD;

	private bool IFCDBMHFABD;

	private Coroutine GKIOLICFDAA;

	private NGLCDIDOEMK EEBMLPBCOLF;

	public Action OnShatterEvent;

	private Tool IEGMBEPJMGC;

public bool SuppressShatter
{
get 	{
		return false;
	}

set {
	}
}

public int Health
{
get 	{
		return 0;
	}

set {
	}
}

public bool CanShatter
{
get 	{
		return false;
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

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	protected override void OnDestroy()
	{
	}

	protected virtual void OCDJNBNDDIK()
	{
	}

	private void AFOGLACDGPJ()
	{
	}

	private void LKDNMALGGCH()
	{
	}

	private void PGHLHNBFFPF()
	{
	}

	private IEnumerator FPKPBLHGGCA()
	{
		return null;
	}

	private void OEFIDOAICEL(Tool IEGMBEPJMGC)
	{
	}

	private bool KJJHJKGGBNI(Tool PMEFICGEDFK)
	{
		return false;
	}

	public void SetBreakable(bool PAJGFPDGMOE, object NCJCLJGCIMF)
	{
	}

	private bool DBHKPOENHMH()
	{
		return false;
	}

	private void AADKKHBMBBA(bool PAJGFPDGMOE)
	{
	}

	private bool BOIDKAGCANN(DJBEHNDMJDL IKEDGLGPGEA)
	{
		return false;
	}

	private void IJBMKMAIIMD(Weapon PLOGNHIJBNB, Enemy INIEKKNFPDP, NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD)
	{
	}

	private void CKCMGBJDICL(Weapon PLOGNHIJBNB, Player EKOFNPFCLMO, Player.NBPIPAJOGLC MKLOBAIKINA, NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD)
	{
	}

	private void NCGFBKIKNEO(Weapon PLOGNHIJBNB, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD)
	{
	}

	private void MHHBEPLCDDA(Weapon PLOGNHIJBNB, NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD)
	{
	}

	private void KJBJAOGKMBH(Player KJCCPIIFNGO)
	{
	}

	private void HEJILBPJDDK(NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD)
	{
	}

	private void LPEFCLNHFKI(NGLCDIDOEMK BNFNJFKJEOA)
	{
	}

	private void LPEFCLNHFKI(Vector3 PDFEDMAOMNH, Vector3 OIEPDFJCEHE)
	{
	}

	private void CLKKEFDJGPK()
	{
	}

	protected virtual void MBIOLEBFOOM(Tool IEGMBEPJMGC, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JJOPIKLAKMM, bool DFAOAOMFDKE)
	{
	}

	protected virtual void PIBDCBNAMLB(Tool PMEFICGEDFK, MonoBehaviourPun GLLFHCCFIGK, DJBEHNDMJDL IKEDGLGPGEA, Vector3 PDFEDMAOMNH, Vector3 COPOILGLIAJ, ForceMode OJOAKAEAKAC)
	{
	}

	public bool CanBeShatteredByDamageType(DJBEHNDMJDL IKEDGLGPGEA)
	{
		return false;
	}

	private void FJPDADCNHJB(Vector3 OGEABPMOJJB, Vector3 COPOILGLIAJ, ForceMode OJOAKAEAKAC, DJBEHNDMJDL IKEDGLGPGEA)
	{
	}

	[PBOMGCLBFHF]
	protected void RpcShatter(Vector3 OGEABPMOJJB, Vector3 KGIOBJMPLKI, DJBEHNDMJDL IKEDGLGPGEA)
	{
	}

	public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
	{
	}

	public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
	{
	}

	private void GLKBCCNFINJ(MNENEENPCFE HMJOKPKOPCN)
	{
	}

	void JCPJHDPNDKB.PrepareImposter(MNENEENPCFE HMJOKPKOPCN)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GLKBCCNFINJ
		this.GLKBCCNFINJ(HMJOKPKOPCN);
	}

	public IReadOnlyList<DGMPBIPKJEB> GetConfigurableDynamicUI(List<JICDMECOFLC> OKGFHDGAPBM = null)
	{
		return null;
	}

	[CompilerGenerated]
	private void PBPLMDDDPIH()
	{
	}
}
