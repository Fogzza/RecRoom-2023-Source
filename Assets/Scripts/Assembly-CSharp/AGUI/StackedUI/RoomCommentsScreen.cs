using System.Collections.Generic;
using RecNet;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class RoomCommentsScreen : WatchUIFlow
	{
		private sealed class NOGGCEELEDF
		{
			public RoomCommentsScreen _003C_003E4__this;

			public bool resetPage;

			public int lastPage;

			internal void _003CRefreshComments_003Eb__0(IEnumerable<RoomComment> comments)
			{
			}
		}

		private sealed class CNEKDJFKEHD
		{
			public int localPlayerId;

			internal bool _003CFilterComments_003Eb__3(RoomComment x)
			{
				return false;
			}
		}

		[SerializeField]
		private RadioButton3D filterFeedbackButton;

		[SerializeField]
		private RadioButton3D filterIdeasButton;

		[SerializeField]
		private RadioButton3D filterBugReportsButton;

		[SerializeField]
		private RadioGroup3D filterRadioGroup;

		[SerializeField]
		private RoomCommentsPagedGrid roomCommentsPagedGrid;

		[SerializeField]
		private Button3D newCommentButton;

		private long? EPOBIFCHLNM;

		public override void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
		{
		}

		public void ShowForRoom(long EPOBIFCHLNM)
		{
		}

		private void PBNPAEGIHPI(bool OPKEFNEECKK)
		{
		}

		private IEnumerable<RoomComment> MCENELBAOGN(IEnumerable<RoomComment> FKFOCGIKMOK)
		{
			return null;
		}

		private void CGLODOIBMEH()
		{
		}

		private void MMKFBHILCBI(long EPOBIFCHLNM, long? FPPOCBBEOPL)
		{
		}

		public void Button_NewComment()
		{
		}

		public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}
	}
}
