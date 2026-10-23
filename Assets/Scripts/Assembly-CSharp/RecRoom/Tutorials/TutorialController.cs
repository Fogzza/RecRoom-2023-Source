using System.Collections;
using RecRoom.Core.Animation;
using UnityEngine;

namespace RecRoom.Tutorials
{
	public abstract class TutorialController : MonoBehaviour
	{
		private enum DAAODFFDJFB
		{
			Inactive = 0,
			WaitingForDependencies = 1,
			Running = 2,
			Completed = 3,
			Error = 4
		}

		protected delegate IEnumerator LHJOFFLKOIP();

		private MDEJADHJOEJ BGBIFFLGANM;

		private Coroutine LMELHLBAOEO;

		private string COKEHKMDIDL;

		private string EHMIIANAPND;

		private readonly bool OAEDBAABHGG;

protected abstract TutorialManager.AGHBFNEFPAA EBKKEDNBHBE
{
get ;
}

protected virtual bool KLDEGNDBBLA
{
get 		{
			return false;
		}

}

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected void OGENIHDHADP(string COKEHKMDIDL, string EHMIIANAPND)
		{
		}

		protected abstract bool PADNEIPEELM();

		protected abstract bool BDJKHAEKPNF();

		protected virtual void CLMFJKBJPDK()
		{
		}

		protected virtual void HFLDIIHPOHM()
		{
		}

		protected virtual void OGBCOBDLGKJ()
		{
		}

		protected virtual void BDACPGCBACI()
		{
		}

		private void NCBCAFEIJPC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void KBLEMEAKLKI()
		{
		}

		private void IDPFNILJMNK(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void MCEHGFOHDIC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void AEJCJGCNDCL()
		{
		}

		private void JOPGJKMAMLF(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void OBGNCNJCCIE(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void EJKPIIAGILL(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		protected Coroutine AKKMKDBEFGC(PlayerAnimationVignette JIMMMHPAJDD)
		{
			return null;
		}

		protected void ANNJCKAIFMC(LHJOFFLKOIP PMFFOBGCJPE)
		{
		}

		protected void FBKFBHLCNEE()
		{
		}

		protected bool NIEGAFONBEB(SimpleVolume DMHECBKIEJH, Vector3 NEBFFLPJNDG, float GFEFEMENOGO)
		{
			return false;
		}
	}
}
