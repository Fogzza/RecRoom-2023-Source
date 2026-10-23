using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class SandboxSceneSpawnPoint : SceneSpawnPoint
	{
		private global::JPEBBAFCBEP<long, KKAPOPJBDOA.PKCADEJAJPO.OAPIMBPPIIB> GKPKHKPNJDH;

public long TargetRoomId
{
get 		{
			return 0L;
		}

set {
		}
}

public KKAPOPJBDOA.PKCADEJAJPO.OAPIMBPPIIB TargetRoomType
{
get 		{
			return KKAPOPJBDOA.PKCADEJAJPO.OAPIMBPPIIB.UnknownType;
		}

set {
		}
}

public override bool SupportsPreviousRoomCheck
{
get 		{
			return false;
		}

}

public override IList<long> PreviousRooms
{
get 		{
			return null;
		}

}

public override IList<long> PreviousSubRooms
{
get 		{
			return null;
		}

}

protected override Color BAFJOOPEPHO
{
get 		{
			return default;
		}

}

		public override bool IsBlockedAtPosition(Vector3 INLGLHIPOMC)
		{
			return false;
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
