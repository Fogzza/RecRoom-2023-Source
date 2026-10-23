using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.CircuitsV2.Config;
using TMPro;
using UnityEngine;

namespace RecRoom.CircuitsV2.Experience
{
	[Serializable]
	public sealed class ChipView
	{
		private enum IAICIIOBPGF
		{
			Standard = 0,
			LowRes = 1,
			Count = 2
		}

		private sealed class BBKKBHIGELK
		{
			public ChipView _003C_003E4__this;

			public CCFFIDBNKOF chipAdapter;

			public float baseMeshWidth;

			public Vector3 baseMeshExtents;

			public float chipWidth;

			public float chipRight;

			public CircuitsV2Config cv2Config;

			internal object _003CLayout_003Eb__2()
			{
				return null;
			}

			internal void _003CLayout_003Eg__ApplySharedEventFormatting_007C3(float x, float y)
			{
			}
		}

		private sealed class GLJJHFNHAHA : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public ChipView _003C_003E4__this;

			private GlobalChipConfig _003Cconfig_003E5__2;

			private float _003Ct_003E5__3;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public GLJJHFNHAHA(int _003C_003E1__state)
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
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private TextMeshPro titleText;

		[SerializeField]
		private GameObject chipMesh;

		[SerializeField]
		private GameObject innerContextIcon;

		[SerializeField]
		private GameObject innerContextIconBack;

		[SerializeField]
		private SpriteRenderer variableTypeIcon;

		[SerializeField]
		private SpriteRenderer chipCustomIcon;

		[SerializeField]
		private SpriteRenderer chipCustomIconBack;

		[SerializeField]
		private GameObject broadcastIcon;

		[SerializeField]
		private MeshRenderer[] broadcastIconRenderers;

		[SerializeField]
		private BoxCollider collider;

		[SerializeField]
		private GameObject culledChip;

		[SerializeField]
		private GameObject unculledChip;

		private MaterialPropertyBlock _materialPropertyBlock;

		private MaterialPropertyBlock _broadcastMaterialPropertyBlock;

		private static readonly Dictionary<Mesh, Mesh> instancedMeshes;

		private readonly Renderer[][] rendererCache;

		private readonly Collider[][] colliderCache;

		private bool visible;

		private bool useLowRes;

		private Color? originalTextColor;

		public Bounds Bounds => default;

		public Collider MainCollider => null;

		private MaterialPropertyBlock MaterialPropertyBlock => null;

		private MaterialPropertyBlock BroadcastMaterialPropertyBlock => null;

		public float ChipWidth { get; private set; }

		public float ChipHeight { get; private set; }

		public bool Visible => false;

		public void JEPCACOBCEA()
		{
		}

		public void KGGGKKAEKOG()
		{
		}

		public void AHABDCHNEAE(bool BMGEHFPFCBJ, bool BAHHDDNDJDD)
		{
		}

		private bool IBHHELBMGKA()
		{
			return false;
		}

		private void AEIPCJMFLDB()
		{
		}

		private void KJBCOJIGIOM<T>(ref T[] MGGAFPGBPKK, GameObject GLLFHCCFIGK)
		{
		}

		public void EHGKCOBNDPF(bool GNGKKJPOAPJ)
		{
		}

		private static Mesh JOBIHHEAIFH(Mesh GLLFHCCFIGK)
		{
			return null;
		}

		public void IFIGMJHIABP(HEJEFJABMHN ELCLBJBCJFB, ChipConfig KILCCDFGMGN, CCFFIDBNKOF JGCPMAMLCBA, Chip JJMNDCAFBDA)
		{
		}

		private void NEHNMJKEFKE(HEJEFJABMHN ELCLBJBCJFB, ChipConfig KILCCDFGMGN, CCFFIDBNKOF JGCPMAMLCBA, Chip JJMNDCAFBDA)
		{
		}

		public IEnumerator<EGGPGCCKPCO> HDJMFAGFPFL()
		{
			return null;
		}
	}
}
