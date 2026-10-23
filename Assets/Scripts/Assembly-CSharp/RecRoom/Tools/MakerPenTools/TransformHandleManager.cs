using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	public class TransformHandleManager : HandleManagerBase
	{
		private sealed class HEMAGGNPDGP : IEnumerable<MakerPenHandle>, IEnumerable, IEnumerator<MakerPenHandle>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private MakerPenHandle _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public TransformHandleManager _003C_003E4__this;

			private ScaleAxisHandleBase[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			private RotationCircleAxisHandle[] _003C_003E7__wrap3;

			private TranslationArrowCenterHandle[] _003C_003E7__wrap4;

			private TranslationSideHandle[] _003C_003E7__wrap5;

			MakerPenHandle IEnumerator<MakerPenHandle>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public HEMAGGNPDGP(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<MakerPenHandle> IEnumerable<MakerPenHandle>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct JHEEIGPGPKD<T>
		{
			public TransformHandleManager _003C_003E4__this;

			public MakerPenHandleManagerConfig config;
		}

		[StructLayout((LayoutKind)3)]
		private struct FBLMGLNHODI
		{
			public MakerPenHandleManagerConfig config;

			public TransformHandleManager _003C_003E4__this;
		}

		[StructLayout((LayoutKind)3)]
		private struct ANHJDEDJGFD
		{
			public TranslationPlaneHandle prefab;

			public Transform parent;
		}

		[StructLayout((LayoutKind)3)]
		private struct GGPLAPEMMAN
		{
			public MakerPenHandleManagerConfig config;

			public TransformHandleManager _003C_003E4__this;
		}

		[StructLayout((LayoutKind)3)]
		private struct PBFOBOEGAOB
		{
			public MakerPenHandleManagerConfig config;

			public TransformHandleManager _003C_003E4__this;
		}

		private static readonly Vector3[] GMCHBNKPPOJ;

		private static readonly Vector3[] IPJGBGFCHHO;

		private static readonly MakerPenHandle.KAAACAIMIBI[] OOPEJAEKEBL;

		private static readonly Quaternion BKJGAJEOPBN;

		private static readonly Quaternion FDKHBPPEHPM;

		private static readonly Quaternion EDCHHKOBHHP;

		private static readonly Quaternion BFCKIFMJCHJ;

		private static readonly Quaternion FDCPELEECMI;

		private static readonly Quaternion PEGLDFLBPKL;

		private int PCMPNGANKAI;

		private int AEEOPDIDOOM;

		private int LCNKIPMOJBE;

		private int MEDLLPKKDAO;

		private int NLMEDDCMOJD;

		private int PKFGBLBBOEH;

		private int JECOMHGIOAP;

		private GameObject BNFIMOOFIHB;

		private TranslationPlaneHandle LMOOGPHGLOO;

		private TranslationPlaneHandle MLKOCHPGNPE;

		private TranslationPlaneHandle OMPFCNEHEBI;

		private readonly TranslationArrowCenterHandle[] KPCIFJGGFCA;

		private readonly TranslationSideHandle[] AJJOLMIIAFM;

		private GameObject FCBMLDCHDAD;

		private RotationCircleAxisHandle KKLMPHMGPJK;

		private readonly RotationCircleAxisHandle[] JCFOGEIGOPA;

		private GameObject BKHHAJIHKBE;

		private ScaleAxisHandleBase LDKCKAGFEJO;

		private readonly ScaleAxisHandleBase[] LODJEOLAHLK;

public override IEnumerable<MakerPenHandle> AllHandles
{
get 		{
			return null;
		}

}

		private void OMBHHIGHMCI(MakerPenHandleManagerConfig FPJKGKBOAOA)
		{
		}

		private void OnDestroy()
		{
		}

		public static TransformHandleManager Create()
		{
			return null;
		}

		private void LLLPMINBGLL()
		{
		}

		public void UpdateHandles<T>(global::FNLEEFFPAAJ<T> DELCOFCGDFF)
		{
		}

		private void HNNAHGKHGHJ(MakerPenHandleManagerConfig FPJKGKBOAOA)
		{
		}

		private void BPIHLMNFEIB(MakerPenHandleManagerConfig FPJKGKBOAOA)
		{
		}

		private void BALEGNHBEDK(MakerPenHandleManagerConfig FPJKGKBOAOA)
		{
		}

		private void GFDKIPNHFOD(NNBAJLCGAOK CAOIPCMMNMJ, MakerPenHandleManager ACDHNMANGFE, MakerPenHandleManagerConfig FPJKGKBOAOA, Bounds DBPFJELGIGI, Quaternion HEGBBJCMANH)
		{
		}

		private void COHPNJCKKHF(NNBAJLCGAOK CAOIPCMMNMJ, MakerPenHandleManagerConfig FPJKGKBOAOA, Bounds DBPFJELGIGI)
		{
		}

		private void HBMBKJDABCM(NNBAJLCGAOK CAOIPCMMNMJ, MakerPenHandleManagerConfig FPJKGKBOAOA, Bounds DBPFJELGIGI)
		{
		}

		private static bool NEODHPGKLFC(Camera GAPPCJHIBEK, Vector3 ADJINPMOILO)
		{
			return false;
		}

		[CompilerGenerated]
		private void GLDIIGPNOCD<T>(ref JHEEIGPGPKD<T> P_0)
		{
		}

		[CompilerGenerated]
		private void BMGINLAFBOG(ref FBLMGLNHODI P_0)
		{
		}

		[CompilerGenerated]
		private void KCMPLKMLMMF(ref TranslationPlaneHandle PLFCHHKILCM, MakerPenHandle.KAAACAIMIBI OJBODCOIDJO, Quaternion HEGBBJCMANH, ref FBLMGLNHODI P_3, ref ANHJDEDJGFD P_4)
		{
		}

		[CompilerGenerated]
		private void PJIDLPBLJNM(ref FBLMGLNHODI P_0)
		{
		}

		[CompilerGenerated]
		private void NEFBBAFNJOA(TranslationPlaneHandle PLFCHHKILCM, ref FBLMGLNHODI P_1)
		{
		}

		[CompilerGenerated]
		private void OMOGEKBEJPI(ref FBLMGLNHODI P_0)
		{
		}

		[CompilerGenerated]
		private void DCGHIDGOFKD(ref FBLMGLNHODI P_0)
		{
		}

		[CompilerGenerated]
		private void PELMCGPDBAF(ref FBLMGLNHODI P_0)
		{
		}

		[CompilerGenerated]
		private void OEKBMFPCNOA(ref FBLMGLNHODI P_0)
		{
		}

		[CompilerGenerated]
		private void ALDCDMOMDDL(ref GGPLAPEMMAN P_0)
		{
		}

		[CompilerGenerated]
		private void NNMIGGFGNOE(ref RotationCircleAxisHandle PLFCHHKILCM, RotationCircleAxisHandle GDEKLMNKJBC, MakerPenHandle.KAAACAIMIBI OJBODCOIDJO, Quaternion HEGBBJCMANH, bool ANMLHKBEJPC, ref GGPLAPEMMAN P_5)
		{
		}

		[CompilerGenerated]
		private void PLBLHDDPFHE(ref GGPLAPEMMAN P_0)
		{
		}

		[CompilerGenerated]
		private void OIAOKMDDILB(RotationCircleAxisHandle PLFCHHKILCM, float JFJHGLAHPBA, float MNHJMPBCBJH, float KODINFOOMKO, Mesh AHBGBAEKDFH, int LAGADKBKLAD, float LODJNKGBDFA, ref GGPLAPEMMAN P_7)
		{
		}

		[CompilerGenerated]
		private void LJAGEBPMPOE(ref PBFOBOEGAOB P_0)
		{
		}

		[CompilerGenerated]
		private void GMNMADLEMMJ(ref PBFOBOEGAOB P_0)
		{
		}

		[CompilerGenerated]
		private void FHGCKDBLAKB(ref PBFOBOEGAOB P_0)
		{
		}

		[CompilerGenerated]
		private void DMNCCKOHJHO(ref PBFOBOEGAOB P_0)
		{
		}
	}
}
