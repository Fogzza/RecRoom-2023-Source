using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace RecRoom.Core.Creation.Audio
{
	public class AudioEffectZone : ConfigurableMonoBehaviorSelector<AudioEffectZoneShape>, CNDHJIBBLCN
	{
		public const float DEFAULT_TRANSITION_TIME = 1f;

		private const AudioListenerSingleton.PBDPLBGCFIP JDBGPEGKFFH = AudioListenerSingleton.PBDPLBGCFIP.Space;

		private const float LOAJMFODLCL = 1f;

		private const float JNPOOFOKIOD = 0.5f;

		private const float ONNCNDLIHMF = 1f;

		private const int CLGBEHOBKFN = 5;

		private const int DGCJFFIEPMP = 0;

		private const int MDHOPHMAOGO = 10;

		[SerializeField]
		private Tool tool;

		private bool OIAGGKIPINH;

		private global::MOBDJNEDDKC<AudioListenerSingleton.PBDPLBGCFIP> MDILDPALOMC;

		private global::MOBDJNEDDKC<float> DOEJGDJILAD;

		private global::MOBDJNEDDKC<int> LAGADKBKLAD;

		private static CNDHJIBBLCN KNOACLKAKHM;

public AudioListenerSingleton.PBDPLBGCFIP EffectType
{
get 		{
			return AudioListenerSingleton.PBDPLBGCFIP.None;
		}

private set {
		}
}

public float HighPassScale
{
get 		{
			return 0f;
		}

}

public bool IsActive
{
get 		{
			return false;
		}

private set {
		}
}

public float LowPassScale
{
get 		{
			return 0f;
		}

}

public int Priority
{
get 		{
			return 0;
		}

private set {
		}
}

public float ReverbScale
{
get 		{
			return 0f;
		}

}

public float TransitionTime
{
get 		{
			return 0f;
		}

}

public static CNDHJIBBLCN PreviewAudioZone
{
get 		{
			return null;
		}

private set {
		}
}

public float Intensity
{
get 		{
			return 0f;
		}

private set {
		}
}

protected override string IEABLNBBGBM
{
get 		{
			return null;
		}

}

		public override void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public override void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		public void UpdateIsActive(Vector3 AECDEGDBFHD)
		{
		}

		public override int GetOptionId(AudioEffectZoneShape AAFNLLCIFBP)
		{
			return 0;
		}

		private void GEJNBEFOCGI()
		{
		}

		private void EMCHJFDPKJI()
		{
		}

		private void IEBCNPAOACM()
		{
		}

		protected override void Awake()
		{
		}

		protected void OnDisable()
		{
		}

		protected void OnEnable()
		{
		}

		[CompilerGenerated]
		private int ODIDCIJHEHB()
		{
			return 0;
		}

		[CompilerGenerated]
		private void NDPKOFBDOMN(int IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private int BKEFDBCBFAL()
		{
			return 0;
		}

		[CompilerGenerated]
		private void KECHBBIFKAD(int IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private int HBKKPOABGGM()
		{
			return 0;
		}

		[CompilerGenerated]
		private void FDBMIPFIHAE(int IPMIIEAGJKC)
		{
		}
	}
}
