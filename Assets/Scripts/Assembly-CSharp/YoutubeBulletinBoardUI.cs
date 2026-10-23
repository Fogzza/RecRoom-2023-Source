using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Video;

public class YoutubeBulletinBoardUI : MonoBehaviour
{
	private sealed class CKKMPPMKEDP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public YoutubeBulletinBoardUI _003C_003E4__this;

		public YoutubeBulletinCard youtubeBulletinCard;

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
		public CKKMPPMKEDP(int _003C_003E1__state)
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
	private BulletinBoardController bulletinBoardController;

	[SerializeField]
	private VideoPlayer videoPlayer;

	[SerializeField]
	private MeshRenderer largeVideoRenderer;

	[SerializeField]
	private GameObject loadingVisual;

	[SerializeField]
	private Transform contentRoot;

	[SerializeField]
	private YoutubeBulletinCard cardPrefab;

	private List<YoutubeBulletinCard> FOEFHDLOMLC;

	private Coroutine DFEGHLDPKFA;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void GODLBKDFPDG()
	{
	}

	public void PlayYoutubeCard(YoutubeBulletinCard AGKEHMGBJDH)
	{
	}

	private IEnumerator HCKDGAOOOOO(YoutubeBulletinCard AGKEHMGBJDH)
	{
		return null;
	}

	public void Button_CloseVideoPlayer()
	{
	}
}
