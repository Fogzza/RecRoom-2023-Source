using System;
using System.Collections.Generic;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.Shapes;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public class MakerPenMergeOperation : MakerPenOperation
	{
		private sealed class KLHAIIAPLMO
		{
			public MakerPenMergeOperation _003C_003E4__this;

			public global::PHLHFLLLDLK<string> promise;

			internal void _003CTryMergeSelection_003Eb__0()
			{
			}

			internal void _003CTryMergeSelection_003Eb__1(DKDHCAHPJGP result)
			{
			}

			internal void _003CTryMergeSelection_003Eb__2(string error)
			{
			}
		}

		private sealed class IMJIGJDPCGA
		{
			public List<ShapeContainer> containersToMerge;

			public IReadOnlyCollection<Guid> currentSelection;

			public MakerPenMergeOperation _003C_003E4__this;

			public ShapeContainer destContainer;

			public global::PHLHFLLLDLK<string> promise;

			public Action<string> _003C_003E9__8;

			public Action<HGKINAOMNIF> _003C_003E9__9;

			public Action<string> _003C_003E9__10;

			internal void _003CTryMergeContainers_003Eg__mergeObjects_007C0()
			{
			}

			internal void _003CTryMergeContainers_003Eb__5(CreationManager.BFEKGCMDJNM serializeResult)
			{
			}

			internal void _003CTryMergeContainers_003Eb__8(string errorMsg)
			{
			}

			internal void _003CTryMergeContainers_003Eb__6(string errMsg)
			{
			}

			internal void _003CTryMergeContainers_003Eb__2(bool doPermissionsMatch)
			{
			}

			internal void _003CTryMergeContainers_003Eb__9(HGKINAOMNIF result)
			{
			}

			internal void _003CTryMergeContainers_003Eb__10(string error)
			{
			}

			internal void _003CTryMergeContainers_003Eb__3(string error)
			{
			}
		}

		private sealed class NBHAPNKMLBM
		{
			public ABIEMJKLLJP undoEntry;

			public IMJIGJDPCGA CS_0024_003C_003E8__locals1;

			internal void _003CTryMergeContainers_003Eb__7(bool mergeResult)
			{
			}
		}

		private const float MERGE_REQUEST_TIMEOUT_DURATION = 5f;

		private global::PHLHFLLLDLK<string> pendingTryMergeSelectionRequest;

		private float lastMergeRequestTime;

		public bool CanMergeSelection => false;

		public global::NCOKFFGPIJM<string> LFPHFGPLMFB()
		{
			return null;
		}

		private void OJJKFOAJILC(global::PHLHFLLLDLK<string> BOJDPAGLBLI)
		{
		}

		private void KHJEANCJJAI(ShapeContainer NLINPCMLDBE, List<ShapeContainer> GJODKIOFJLP, global::PHLHFLLLDLK<string> BOJDPAGLBLI)
		{
		}
	}
}
