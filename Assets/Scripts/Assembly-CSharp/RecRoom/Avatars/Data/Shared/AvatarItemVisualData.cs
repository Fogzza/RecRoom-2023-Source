using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using RecRoom.Avatars.Outfit;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RecRoom.Avatars.Data.Shared
{
	[Serializable]
	public class AvatarItemVisualData
	{
		public struct KHDGFAKFFEA
		{
			private global::EHOCIICLNGN<JHHDMDHLNGF> FICDDMBKEMI;

			private global::EHOCIICLNGN<Material>[] ODKGMJCKPCN;

			public void JFAIFBLKKHI(out global::EHOCIICLNGN<JHHDMDHLNGF> PLFCHHKILCM)
			{
				PLFCHHKILCM = null;
			}

			public void CHOHJHBMJNL(out global::EHOCIICLNGN<Material>[] OBDCNEMMCJC)
			{
				OBDCNEMMCJC = null;
			}

			public KHDGFAKFFEA(global::EHOCIICLNGN<JHHDMDHLNGF> CDJJBKBDCNP, global::EHOCIICLNGN<Material>[] PMPDPBDKGPF)
			{
				FICDDMBKEMI = null;
				ODKGMJCKPCN = null;
			}
		}

		private class MHJLEJAEJKG : global::PJDDDFJIBDP<Task<(GameObject, AvatarItemMaterial)>, JHHDMDHLNGF>
		{
			[StructLayout((LayoutKind)3)]
			private struct KHAIHLFKDFI : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<(GameObject, AvatarItemMaterial)> _003C_003Et__builder;

				public Task<GameObject> goTask;

				public Task<AvatarItemMaterial> materialTask;

				private GameObject _003Cgo_003E5__2;

				private TaskAwaiter _003C_003Eu__1;

				private TaskAwaiter<GameObject> _003C_003Eu__2;

				private TaskAwaiter<AvatarItemMaterial> _003C_003Eu__3;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			private readonly global::EHOCIICLNGN<GameObject> PEEDPMPBPGC;

			private readonly global::EHOCIICLNGN<AvatarItemMaterial> OIBCFBNOMMG;

			private OutfitPrefab NEKEKFOPFBN;

			private AvatarItemMaterial DGLHEDJOJPB;

			private MHJLEJAEJKG(Task<(GameObject, AvatarItemMaterial)> BEONMNODOMN, global::EHOCIICLNGN<GameObject> PEEDPMPBPGC, global::EHOCIICLNGN<AvatarItemMaterial> OIBCFBNOMMG)
				: base((Task<(GameObject, AvatarItemMaterial)>)null)
			{
			}

			public static MHJLEJAEJKG IBCEBKJOOIP(AvatarItemVisualData JGPDDEPCGDK)
			{
				return null;
			}

			private static Task<(GameObject, AvatarItemMaterial)> LFNLPAJDPHG(Task<GameObject> OHCNNHJHJCM, Task<AvatarItemMaterial> JDNKMOBPCLA)
			{
				return null;
			}

			protected override JHHDMDHLNGF JKNICOLMDME(Task<(GameObject, AvatarItemMaterial)> NNKDCKHHNFC)
			{
				return default;
			}

			protected override void MHOLKAMLKBJ()
			{
			}
		}

		[NonSerialized]
		public AssetReference outfitPrefabReference;

		[NonSerialized]
		public AssetReference combinationReference;

		[NonSerialized]
		public AssetReference[] materialReferences;

		[SerializeField]
		private string prefabGuid;

		[SerializeField]
		private string combinationGuid;

		[NonSerialized]
		private string _cachedRecNetString;

		[NonSerialized]
		private int? _cachedHashCode;

		public string PrefabGuid => null;

		public string CombinationGuid => null;

		public Color UGCBaseColor { get; private set; }

		public AvatarItemVisualData()
		{
		}

		public AvatarItemVisualData(AvatarItemVisualData PCPEJHIMHJJ)
		{
		}

		public AvatarItemVisualData(string OHILEMGCIHI, string FGPIHHIOKIF = null, Color OOLNAKAKIML = default(Color))
		{
		}

		private static string KPBLGAPBMGC(string JMIFIJDBMNM)
		{
			return null;
		}

		public static AvatarItemVisualData OJJFNFEPJGO(string EJPLJKIOGEJ, ArraySegment<string> FIFDFKHEPIK)
		{
			return null;
		}

		public void KBPIOPKFLDJ(AvatarUgcOutfitData JOIHKFDAJAJ)
		{
		}

		public void KBPIOPKFLDJ(Color OOLNAKAKIML)
		{
		}

		public KHDGFAKFFEA EMHHJGILIEL(bool MGJKFNCIBPK = false)
		{
			return default;
		}

		private global::EHOCIICLNGN<Material>[] IKHFPOOOGHM()
		{
			return null;
		}

		public string AKEGEMNIJND()
		{
			return null;
		}

		public string MMMMOBJKPJO()
		{
			return null;
		}

		private bool OFPEIHMPLIL(AvatarItemVisualData HNPEBINPOBO)
		{
			return false;
		}

		private bool FOADEDCAJAM(string DNDNMGOKFEI, string OHMMPNACNJO)
		{
			return false;
		}

		private bool ODCMDKEOJIO(string DNDNMGOKFEI, string OHMMPNACNJO)
		{
			return false;
		}

		private static string LAFBHMFBIEP(string IBALDFBGBGL)
		{
			return null;
		}

		public override bool Equals(object ICHBECDKHOJ)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		[SpecialName]
		public static bool IGOCGGBJBII(AvatarItemVisualData DNDNMGOKFEI, AvatarItemVisualData OHMMPNACNJO)
		{
			return false;
		}

		[SpecialName]
		public static bool BHBKJCPJNJN(AvatarItemVisualData DNDNMGOKFEI, AvatarItemVisualData OHMMPNACNJO)
		{
			return false;
		}

		public void FGGNCNBMLNA()
		{
		}

		public AvatarItemVisualData EKNKDADOBNE()
		{
			return null;
		}

		[CompilerGenerated]
		internal static string MBAIANAHHOJ(string IBALDFBGBGL)
		{
			return null;
		}
	}
}
