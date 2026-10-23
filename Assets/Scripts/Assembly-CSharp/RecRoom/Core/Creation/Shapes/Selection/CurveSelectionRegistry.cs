using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RecRoom.Core.Creation.Shapes.Selection
{
	public class CurveSelectionRegistry : SingletonMonoBehaviour<CurveSelectionRegistry>
	{
		private sealed class HMBAJNLADLD
		{
			public CurveSelectionRegistry _003C_003E4__this;

			public CCLIFCHLEDD curve;

			public SphereCollider collider;

			internal void _003CMarkCurveBoundsDirty_003Eb__0()
			{
			}

			internal void _003CMarkCurveBoundsDirty_003Eb__1()
			{
			}

			internal void _003CMarkCurveBoundsDirty_003Eg__RebuildCurveBounds_007C2()
			{
			}
		}

		private readonly Dictionary<Collider, CCLIFCHLEDD> FNJPLDJABLB;

		private readonly Dictionary<Transform, Transform> DJOLEBFKCFH;

		private readonly Dictionary<CCLIFCHLEDD, SphereCollider> PCDBFHGIKAN;

		private readonly HashSet<CCLIFCHLEDD> LOHJHNMOBMI;

		public void MarkCurveBoundsDirty(CCLIFCHLEDD IGPGCPLDMCH)
		{
		}

		public void Register(CCLIFCHLEDD IGPGCPLDMCH)
		{
		}

		public void TransformChanged(Transform FGNGGLFNLIP)
		{
		}

		public bool TryGetCurve(Collider ADMCDJKKCIA, out CCLIFCHLEDD IGPGCPLDMCH)
		{
			IGPGCPLDMCH = null;
			return false;
		}

		public IEnumerable<CCLIFCHLEDD> TryGetCurves(IEnumerable<Collider> GHKNKHCKPII)
		{
			return null;
		}

		public void Unregister(CCLIFCHLEDD IGPGCPLDMCH)
		{
		}

		public void Unregister(Transform FMPHDMAKDKP)
		{
		}

		protected override void OnDestroy()
		{
		}

		private Transform CIJALFDBBIF(CCLIFCHLEDD IGPGCPLDMCH)
		{
			return null;
		}

		[CompilerGenerated]
		private CCLIFCHLEDD AMCOGBCIBOB(Collider DHNNLHJMKIH)
		{
			return null;
		}
	}
}
