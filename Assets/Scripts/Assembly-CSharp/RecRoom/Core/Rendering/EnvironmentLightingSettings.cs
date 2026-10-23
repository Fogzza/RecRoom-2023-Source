using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace RecRoom.Core.Rendering
{
	[Serializable]
	public class EnvironmentLightingSettings
	{
		private sealed class BFCFLGEFJBH : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

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
			public BFCFLGEFJBH(int _003C_003E1__state)
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
		private Material skybox;

		[SerializeField]
		private Light sun;

		[SerializeField]
		private AmbientMode ambientMode;

		[SerializeField]
		private SphericalHarmonicsL2 ambientProbe;

		[SerializeField]
		private float ambientIntensity;

		[SerializeField]
		private Color ambientSkyColor;

		[SerializeField]
		private Color ambientEquatorColor;

		[SerializeField]
		private Color ambientGroundColor;

		[SerializeField]
		private Color ambientLight;

		[SerializeField]
		private DefaultReflectionMode defaultReflectionMode;

		[SerializeField]
		private int defaultReflectionResolution;

		[SerializeField]
		private Cubemap customReflection;

		[SerializeField]
		private float reflectionIntensity;

		[SerializeField]
		private int reflectionBounces;

		private static EnvironmentLightingSettings defaultSceneSettings;

		public void MAHLEKHKDGC()
		{
		}

		public void EIPJIMFJMJH()
		{
		}

		public static void BGGJNIAGIPH()
		{
		}

		public static void PKCFNDNKGFN()
		{
		}

		[CompilerGenerated]
		internal static IEnumerator<EGGPGCCKPCO> BHENLHMFLIL()
		{
			return null;
		}
	}
}
