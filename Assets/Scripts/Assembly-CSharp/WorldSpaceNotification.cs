using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.UI.Notifications;
using UnityEngine;

public class WorldSpaceNotification : MonoBehaviour
{
	private sealed class CLKAMDGEHME : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WorldSpaceNotification _003C_003E4__this;

		public string titleText;

		public string subtitleText;

		public bool billboard;

		public bool followPlayer;

		public float duration;

		private float _003CeaseOutDuration_003E5__2;

		private float _003CwaitDuration_003E5__3;

		private float _003CstartTime_003E5__4;

		private float _003CendTime_003E5__5;

		private Vector3 _003CinitialPosition_003E5__6;

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
		public CLKAMDGEHME(int _003C_003E1__state)
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

	private sealed class BLCHONDBOCC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WorldSpaceNotification _003C_003E4__this;

		public float waitDuration;

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
		public BLCHONDBOCC(int _003C_003E1__state)
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
	private VRModeNotificationText title;

	[SerializeField]
	private VRModeNotificationText subtitle;

	[SerializeField]
	private FloatValueCurve alphaEaseInCurve;

	[SerializeField]
	private FloatValueCurve heightEaseInCurve;

	private Coroutine ENOJOIGJMNG;

	private FollowTarget NFABAIKELNN;

	private static WorldSpaceNotification PCFBEFLCEMA;

	private float MNKBEGIKAIF;

	private bool MDNBIJGKCLM;

public bool IsPlaying
{
get 	{
		return false;
	}

}

public FollowTarget FollowTarget
{
get 	{
		return null;
	}

private set {
	}
}

public Color Color
{
set {
	}
}

public static WorldSpaceNotification DefaultNotificationPrefab
{
get 	{
		return null;
	}

}

	private void Awake()
	{
	}

	public void Stop()
	{
	}

	private void NOIOGEDNFDJ(string BOGCJKAMALE, float FGBPJMKCMAO = 5f, string PCFACAKIICE = null, bool EFDJONAEHCK = true, bool OBAOLJPGHAD = false)
	{
	}

	private IEnumerator CCPKGEHDGNM(string BOGCJKAMALE, string PCFACAKIICE, float FGBPJMKCMAO, bool EFDJONAEHCK, bool OBAOLJPGHAD, WorldSpaceNotification GDEKLMNKJBC = null)
	{
		return null;
	}

	public bool RefreshNotificationText(string BOGCJKAMALE, float FGBPJMKCMAO, string PCFACAKIICE = null)
	{
		return false;
	}

	private IEnumerator JDNJPIMMIHD(float OAHHLHGOIPK)
	{
		return null;
	}

	public static WorldSpaceNotification PlayNext(string BOGCJKAMALE, float FGBPJMKCMAO = 5f, string PCFACAKIICE = null, bool EFDJONAEHCK = true, Vector3? DLOLGDANPLJ = null, float FPOJOEIHIKH = 1f, bool OBAOLJPGHAD = false)
	{
		return null;
	}

	public static WorldSpaceNotification PlayNext(WorldSpaceNotification GDEKLMNKJBC, string BOGCJKAMALE, float FGBPJMKCMAO = 5f, string PCFACAKIICE = null, bool EFDJONAEHCK = true, Vector3? DLOLGDANPLJ = null, float FPOJOEIHIKH = 1f, bool OBAOLJPGHAD = false)
	{
		return null;
	}
}
