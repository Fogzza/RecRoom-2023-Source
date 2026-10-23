using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Consumable
{
	public abstract class ConsumableEffect : MonoBehaviourPun
	{
		private sealed class CKOAMGDJMFI
		{
			public HMJFJMPLFEO category;

			internal bool _003CLocalGetAll_003Eb__0(ConsumableEffect e)
			{
				return false;
			}
		}

		private sealed class HKHKIPMCCMA
		{
			public IELGHJEOPKB consumable;

			internal bool _003CLocalDeactivateConsumable_003Eb__0(string d)
			{
				return false;
			}
		}

		public static List<ConsumableEffect> AllLocal;

		private List<HMJFJMPLFEO> NHKKKOGJIBH;

		private bool IIDPJMIBHCG;

		private global::MOBDJNEDDKC<bool> NPAIIDEJOIB;

		private global::MOBDJNEDDKC<string[]> BIKKFKDCGIC;

		private HashSet<string> AOAEMIINPAB;

		protected List<IELGHJEOPKB> KDCDLKALHAA;

		private Dictionary<string, GameObject> DKFLIEKCPBO;

public List<HMJFJMPLFEO> SupportedCategories
{
get 		{
			return null;
		}

set {
		}
}

public bool IsMine
{
get 		{
			return false;
		}

private set {
		}
}

		protected ConsumableItem LEHAKOPFOHB()
		{
			return null;
		}

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public bool LocalActivateConsumable(IELGHJEOPKB KIJHICGIKFM, bool LIEPJABJLAD)
		{
			return false;
		}

		public static IEnumerable<ConsumableEffect> LocalGetAll(HMJFJMPLFEO JNKJFJLJKNJ)
		{
			return null;
		}

		public bool LocalDeactivateConsumable(IELGHJEOPKB KIJHICGIKFM, bool LIEPJABJLAD)
		{
			return false;
		}

		private void KILEOGCHBHC(bool KNJFJONOBHP = false)
		{
		}

		protected void NLLFNKECHKJ(IELGHJEOPKB KIJHICGIKFM, int BMGEEHKMMDG)
		{
		}

		protected virtual void ACEICABLIJL(ConsumableItem FOMOODCMAEA, bool LIEPJABJLAD)
		{
		}

		protected Dictionary<string, GameObject>.ValueCollection DJLHDHCBEHK()
		{
			return null;
		}

		protected GameObject MLFNGLJOCCM(ConsumableItem FOMOODCMAEA)
		{
			return null;
		}

		protected virtual void LLELENOALIP(ConsumableItem FOMOODCMAEA, bool LIEPJABJLAD)
		{
		}

		protected void GJDEEILOGJB(string OFCFPGACNJB)
		{
		}

		[CompilerGenerated]
		private void FLHOPBFKCBN()
		{
		}

		[CompilerGenerated]
		private void PEHOAIEPKIJ()
		{
		}
	}
}
