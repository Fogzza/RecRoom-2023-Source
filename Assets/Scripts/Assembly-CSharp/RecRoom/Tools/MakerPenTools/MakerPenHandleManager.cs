using System;
using System.Collections.Generic;
using RecRoom.Core;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	public class MakerPenHandleManager : MonoBehaviour
	{
		private sealed class HKJMOINDDHH<T>
		{
			public MakerPenHandleManager _003C_003E4__this;

			public CreationController controller;

			public global::FNLEEFFPAAJ<T> legacyContext;

			public global::DDLEHONFEBP<T> makerSelection;

			public global::BAIMOJOCJOK<T> transformReceiver;

			public CAMIJPMLKOA selectionColliders;

			internal void _003CSetupButtonStateEvents_003Eb__0(global::CEPGHBPPOGO<MakerPenHandle>.FGPKNANOKMC eventData)
			{
			}

			internal void _003CSetupButtonStateEvents_003Eb__1(global::CEPGHBPPOGO<MakerPenHandle>.FGPKNANOKMC eventData)
			{
			}
		}

		[SerializeField]
		private MakerPenHandleManagerConfig screenConfig;

		[SerializeField]
		private MakerPenHandleManagerConfig vrConfig;

		[SerializeField]
		private MakerPenHandleManagerConfig iosConfig;

		public bool hideSidesWhenSmall;

		public bool hideCenterWhenSmall;

		public bool hideArrowsWhenSmall;

		public bool showSidesWhenOffCamera;

		private static MakerPenHandleManager EJDHGIDGKIB;

		private List<MakerPenHandle> LBCDNCEKEFI;

		private global::CEPGHBPPOGO<MakerPenHandle> ONMKHCBEKPF;

		private MakerPenHandle NHADHCKMAMC;

		private GJEAOEFGMJC EODIGHKIGIL;

		private bool HJBLBFPFBGA;

public MakerPenHandleManagerConfig ActiveConfig
{
get 		{
			return null;
		}

}

public static MakerPenHandleManager Instance
{
get 		{
			return null;
		}

}

public List<MakerPenHandle> ActiveHandles
{
get 		{
			return null;
		}

}

		private void OnDestroy()
		{
		}

		public bool HasActiveState()
		{
			return false;
		}

		public bool RayCast(Ray HAAAJDJGEFF, out MakerPenHandle PBKOJJOJGMB, out Vector3 HJODBKHINKL)
		{
			PBKOJJOJGMB = null;
			HJODBKHINKL = default;
			return false;
		}

		public bool UpdateHandles<T>(global::FNLEEFFPAAJ<T> KFGAPPJMKEB, global::DDLEHONFEBP<T> LBDKKGGNBPP, global::BAIMOJOCJOK<T> FJEHNLGPHLA, CAMIJPMLKOA DJKLHEEIMEO, CreationController IJIAEDONGKE)
		{
			return false;
		}

		private void ECLOMGGNCEP<T>(global::FNLEEFFPAAJ<T> KFGAPPJMKEB, global::DDLEHONFEBP<T> LBDKKGGNBPP, global::BAIMOJOCJOK<T> FJEHNLGPHLA, CAMIJPMLKOA DJKLHEEIMEO, CreationController IJIAEDONGKE, bool GCHCOOANFKE)
		{
		}

		public void DeactivateAll()
		{
		}

		public bool TrySetActiveStateOnObject<T>(global::DDLEHONFEBP<T> LBDKKGGNBPP, CreationController IJIAEDONGKE, T ICHBECDKHOJ, Func<GJEAOEFGMJC> HEOKLIGMEIA)
		{
			return false;
		}

		public void ClearActiveState(CreationController IJIAEDONGKE)
		{
		}

		private void GPFNBMIBKKP(CreationController IJIAEDONGKE, GJEAOEFGMJC DADHJJNJEFA, bool HJBLBFPFBGA)
		{
		}
	}
}
