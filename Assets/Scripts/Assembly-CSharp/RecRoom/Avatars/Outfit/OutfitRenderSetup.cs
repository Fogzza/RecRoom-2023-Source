using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using RecRoom.Avatars.Data.Runtime;
using UnityEngine;

namespace RecRoom.Avatars.Outfit
{
	public class OutfitRenderSetup : MonoBehaviour
	{
		private sealed class HJBBKEGEAKO
		{
			public OutfitRenderSetup _003C_003E4__this;

			public Color? primaryColor;

			public Color? secondaryColor;

			public Texture2D pattern;

			public Color? ugcColor;

			public RenderTexture ugcTexture;

			public Vector3 rotationOffset;

			internal LAHBDKNMNHN _003CLoadItemAsync_003Eb__0(JHHDMDHLNGF v)
			{
				return null;
			}

			internal void _003CLoadItemAsync_003Eb__1()
			{
			}
		}

		private sealed class GBPMBLOGJEE<T>
		{
			private sealed class _003C_003CSafeDisposeOfResourceHandle_003Eg__DisposeEOF_007C0_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public GBPMBLOGJEE<T> _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CSafeDisposeOfResourceHandle_003Eg__DisposeEOF_007C0_003Ed(int _003C_003E1__state)
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

			public global::EHOCIICLNGN<T> disposeHandle;

			internal IEnumerator<EGGPGCCKPCO> _003CSafeDisposeOfResourceHandle_003Eg__DisposeEOF_007C0()
			{
				return null;
			}
		}

		public static readonly int AVATAR_ITEM_PRIMARY_COLOR_ID;

		public static readonly int AVATAR_ITEM_DECAL_TEXTURE_ID;

		public static readonly int AVATAR_ITEM_MATERIAL_INDEX;

		public static readonly int HAIR_PRIMARY_COLOR_ID;

		public static readonly int HAIR_SECONDARY_COLOR_ID;

		public static readonly int HAIR_BASE_COLOR_ID;

		public static readonly int HAIR_TEXTURE_ID;

		public static readonly int HAIR_MATERIAL_INDEX;

		private static readonly Color32 OKLAJFNFJKF;

		[SerializeField]
		private GameObject loadingObject;

		[SerializeField]
		private BoxCollider _itemCollider;

		[SerializeField]
		private Renderer _itemRenderer;

		private CLMEHHLKBJG GGJJABOACII;

		private AnchorParams PNCEAPGCNEF;

		private AvatarItem DNJNMNEABFH;

		private global::EHOCIICLNGN<JHHDMDHLNGF> FFLHBOPABGK;

		private global::EHOCIICLNGN<Texture2D> COCMLLGHHKF;

		private Lazy<DCFGCHBJPOO> BBJDNEMJCIL;

		private Lazy<KNGMOOLONDN> OJFILDBIJFI;

		private Material[] GNNHHKFPEDM;

		private bool MCABCPCDGEL;

		private bool HBEBBPBJEKJ;

public Renderer ItemRenderer
{
get 		{
			return null;
		}

}

public CLMEHHLKBJG HatAnchorRestrictions
{
get 		{
			return null;
		}

}

public AnchorParams HatAnchorParams
{
get 		{
			return default;
		}

}

private Transform INGFDOMKBAD
{
get 		{
			return null;
		}

}

public AvatarItem Item
{
get 		{
			return default;
		}

}

public DCFGCHBJPOO recnetCustomAvatarItems
{
get 		{
			return null;
		}

}

private KNGMOOLONDN BBCNFMKNLFC
{
get 		{
			return null;
		}

}

		public LAHBDKNMNHN LoadItemAsync(AvatarItem ONCGIPFNENB)
		{
			return null;
		}

		public LAHBDKNMNHN LoadItemAsync(AvatarItem ONCGIPFNENB, Vector3 MNCDNIDIBMP, Color? LCLFBLLLNJP = null, Color? GGAIALCCGIG = null, [CanBeNull] Texture2D CDAJMFEANMG = null, Color? OOLNAKAKIML = null, RenderTexture CJENDCBKJMM = null)
		{
			return null;
		}

		private void FLDBHKLBKAI(bool KHIEHIFBCNF)
		{
		}

		private LAHBDKNMNHN CKFNFNNPCNN(AvatarItem ONCGIPFNENB, JHHDMDHLNGF LIHAJOLNINC, Color? LCLFBLLLNJP = null, Color? GGAIALCCGIG = null, [CanBeNull] Texture2D CDAJMFEANMG = null, Color? OOLNAKAKIML = null, RenderTexture CJENDCBKJMM = null)
		{
			return null;
		}

		private void MBOMPCBCPFO(Color? LCLFBLLLNJP = null, Color? GGAIALCCGIG = null, [CanBeNull] Texture2D CDAJMFEANMG = null)
		{
		}

		private LAHBDKNMNHN JHLJPCJDAPO(AvatarItem ONCGIPFNENB, Color? OOLNAKAKIML = null, RenderTexture CJENDCBKJMM = null)
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		private void GBEILGJPHID()
		{
		}

		private void DLJFCGBNDLO<T>(global::EHOCIICLNGN<T> HIDHNHCKGEH)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<Texture2D> FLIKOLLDKJD(LINLOKECLME LNKODFBLOKJ)
		{
			return null;
		}

		[CompilerGenerated]
		private void OONMIHLCILA(Texture2D CIONKGJFLOB)
		{
		}
	}
}
