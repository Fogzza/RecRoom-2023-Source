using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RecRoom
{
	public class MagicDoorManager : SingletonMonoBehaviour<MagicDoorManager>
	{
		private sealed class GFICJICAELA
		{
			public MagicDoorManager _003C_003E4__this;

			public DBECJLAIPEL loadSceneSource;

			internal void _003CVisitDestinationAsync_003Eb__0(JCDPHCELKHI room)
			{
			}
		}

		private const string CHCFEFIDGHP = "MagicDoor.NewDestinationText";

		private const string MIGBCFNNPIB = "MagicDoor.DestinationRefreshingText";

		private Action INIOCFNHPOK__BackingField;

		private Action LKGAJAPLKEC__BackingField;

		[SerializeField]
		private string defaultNewDestinationText;

		[SerializeField]
		private string defaultDestinationRefreshingText;

		private static DateTime? IEIAJAFGDJM;

		private static TimeSpan? KDLJOPNHIBG;

		private static bool PKBHNIJELOH;

		private static long? LENLFKFDKOC;

		private IILDCCEMGBA LCPOIILBNLD;

		private LKGILLBEJEK CCLFOIDMIDA;

public TimeSpan TimeUntilNextRefresh
{
get 		{
			return default;
		}

}

public bool HasVisitedCurrentDestination
{
get 		{
			return false;
		}

}

public event Action DataUpdated {
add {
		}
remove {
		}
}

public event Action DestinationRefreshed {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public string GetNewDestinationText()
		{
			return null;
		}

		public string GetDestinationRefreshingText()
		{
			return null;
		}

		public global::NCOKFFGPIJM<JCDPHCELKHI> GetDestinationAsync()
		{
			return null;
		}

		public LAHBDKNMNHN VisitDestinationAsync(DBECJLAIPEL CFBNOKOADFB)
		{
			return null;
		}

		private void PKHKIHIBJJI()
		{
		}

		private void OHFNLPLADGL()
		{
		}

		[CompilerGenerated]
		private void HAHJCMJLOLH(OFDELACPMNI CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void LLDIKOJAGBN()
		{
		}
	}
}
