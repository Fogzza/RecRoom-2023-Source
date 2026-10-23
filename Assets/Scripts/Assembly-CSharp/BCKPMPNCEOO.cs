using System.Collections.Generic;
using RecRoom.Core.AI;
using UnityEngine;

public class BCKPMPNCEOO
{
	private readonly struct HCGMFJJICOJ
	{
		public readonly Collider LPGAJGPGKFM;

		public readonly Vector3 HJHIKGCKAEM;

		public readonly float DAMOGGANOJL;

		public readonly float DFNFFJOPOBK;

		public HCGMFJJICOJ(Collider LPGAJGPGKFM, Vector3 EACDPPBEIJF, float NNLEGJGIGHA)
		{
			this.LPGAJGPGKFM = null;
			HJHIKGCKAEM = default;
			DAMOGGANOJL = 0f;
			DFNFFJOPOBK = 0f;
		}

		public HCGMFJJICOJ(float DAMOGGANOJL)
		{
			LPGAJGPGKFM = null;
			HJHIKGCKAEM = default;
			this.DAMOGGANOJL = 0f;
			DFNFFJOPOBK = 0f;
		}

		public bool PJAJGNFHPGD()
		{
			return false;
		}
	}

	private class DDDHJGMKFHL
	{
		private HCGMFJJICOJ FJJEDMMBAGH;

		private IPBPLFFIEHJ JDMCNJMDDBD;

		public DDDHJGMKFHL(IPBPLFFIEHJ JDMCNJMDDBD)
		{
		}

		public void CPCILMEHKPA(in HCGMFJJICOJ BNFNJFKJEOA)
		{
		}

		public void HABKHEOJPHG(Vector3 EACDPPBEIJF, float COPOILGLIAJ, AnimationCurve JIPMBHFPKLF, AnimationCurve FPBFHPMCDPL)
		{
		}
	}

	public delegate void MEGKCJLOCIF(Player EKOFNPFCLMO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA);

	public delegate void ILNGIHLHFNH(Enemy DPENEFKKNDN, BHHAHFFCKJO GFHNJGJNNCK, NGLCDIDOEMK BNFNJFKJEOA);

	public delegate void APCEMKEIGKJ(Tool IEGMBEPJMGC, NGLCDIDOEMK BNFNJFKJEOA);

	public delegate void JCFIMHPBJNM(Trap MBLENDJGFCI, NGLCDIDOEMK BNFNJFKJEOA);

	private delegate void IPBPLFFIEHJ(NGLCDIDOEMK BNFNJFKJEOA);

	private sealed class GHFADAFJDLO
	{
		public Player hitPlayer;

		public BCKPMPNCEOO _003C_003E4__this;

		internal void _003CExplode_003Eb__0(NGLCDIDOEMK impact)
		{
		}
	}

	private sealed class PANIGFGPMBH
	{
		public Enemy hitEnemy;

		public GHFADAFJDLO CS_0024_003C_003E8__locals1;

		internal void _003CExplode_003Eb__1(NGLCDIDOEMK impact)
		{
		}
	}

	private sealed class LFGIFCCADFO
	{
		public Tool hitTool;

		public PANIGFGPMBH CS_0024_003C_003E8__locals2;

		internal void _003CExplode_003Eb__2(NGLCDIDOEMK impact)
		{
		}
	}

	private sealed class HHLPLHMIJIN
	{
		public Trap hitTrap;

		public LFGIFCCADFO CS_0024_003C_003E8__locals3;

		internal void _003CExplode_003Eb__3(NGLCDIDOEMK impact)
		{
		}
	}

	private static readonly AnimationCurve JCFPBPEAOAP;

	private MEGKCJLOCIF NNGIDPFDOOJ__BackingField;

	private ILNGIHLHFNH PGHPEMJPIPD__BackingField;

	private APCEMKEIGKJ CJFAIHCGHIH__BackingField;

	private JCFIMHPBJNM BOIFECJJOGJ__BackingField;

	private static readonly Dictionary<GameObject, DDDHJGMKFHL> NEHKHEJACNK;

public event MEGKCJLOCIF NNGIDPFDOOJ {
add {
	}
remove {
	}
}

public event ILNGIHLHFNH PGHPEMJPIPD {
add {
	}
remove {
	}
}

public event APCEMKEIGKJ CJFAIHCGHIH {
add {
	}
remove {
	}
}

public event JCFIMHPBJNM BOIFECJJOGJ {
add {
	}
remove {
	}
}

	public void KAONGFGOMNK(Vector3 INLGLHIPOMC, float NNLEGJGIGHA, float COPOILGLIAJ, Player FKNDHMLHEON = null)
	{
	}

	public void KAONGFGOMNK(Vector3 INLGLHIPOMC, float NNLEGJGIGHA, float COPOILGLIAJ, AnimationCurve JIPMBHFPKLF, AnimationCurve FPBFHPMCDPL, float LBBEABKFDAN, Player FKNDHMLHEON = null)
	{
	}
}
