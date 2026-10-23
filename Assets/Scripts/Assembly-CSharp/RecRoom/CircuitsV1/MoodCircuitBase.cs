using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.SceneMoods.MoodBlendData;
using RecRoom.Systems.PlayerRoles;
using UnityEngine;

namespace RecRoom.CircuitsV1
{
	public abstract class MoodCircuitBase<T> : MonoBehaviourPun, EGMLODPMKGI, DJLCHGFCFAD where T : MoodBlendData<T>
	{
		private global::MDAHOKBAGPC<bool, int, float> OOAFEJNNJOM;

		private global::MOBDJNEDDKC<int> LAGADKBKLAD;

		private global::MOBDJNEDDKC<float> CFIFMJGMMJE;

		private global::MOBDJNEDDKC<float> ONEHPFDHAIO;

		private global::MOBDJNEDDKC<bool> JBJBAMIAIII;

		private global::MOBDJNEDDKC<Guid> KLBONOOHBND;

		[SerializeField]
		private GameObject activeVisualization;

		[SerializeField]
		private Renderer activeVisualizationRenderer;

		private Material DHFJNFGEGFM;

		private static readonly int IBBKCOADNHO;

		private float JEAKLIOLJOL;

		private bool HDGPNICCKBK;

		private IDisposable DMOEGGIFPJE;

		private static List<MoodCircuitBase<T>> JGOHKEBHOBP;

private Material ABPINOJIHKG
{
get 		{
			return null;
		}

set {
		}
}

protected float EDLGIDKDMCA
{
get 		{
			return 0f;
		}

set {
		}
}

protected int LDHIBGALEDK
{
get 		{
			return 0;
		}

set {
		}
}

protected bool GDBABKDKICG
{
get 		{
			return false;
		}

set {
		}
}

protected int FODCNDDAKBJ
{
get 		{
			return 0;
		}

}

protected float GNDLDEGKMLE
{
get 		{
			return 0f;
		}

}

public float BlendInTime
{
get 		{
			return 0f;
		}

set {
		}
}

public float BlendOutTime
{
get 		{
			return 0f;
		}

set {
		}
}

private bool AGPKDHJFJAF
{
get 		{
			return false;
		}

}

private bool BGGLHEPHJFK
{
get 		{
			return false;
		}

}

private bool OJLOEKLPNEK
{
get 		{
			return false;
		}

}

private bool BJBPEGDBBNN
{
get 		{
			return false;
		}

}

private bool LIEHHCCKPEG
{
get 		{
			return false;
		}

}

private bool BPHPHGHGDLN
{
get 		{
			return false;
		}

set {
		}
}

private IDisposable NOIBNEGIPPL
{
get 		{
			return null;
		}

set {
		}
}

public abstract T BlendData
{
get ;
}

public abstract global::IBHLEFGNKPJ<T> Blender
{
get ;
}

private BNOPDNILAFA NAAMILPIIEJ
{
get 		{
			return null;
		}

}

private bool LEKKJHCJKDP
{
get 		{
			return false;
		}

}

private int IHBDKGBKIAL
{
get 		{
			return 0;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

		protected override void Awake()
		{
		}

		private void MOICMJKGIPB()
		{
		}

		protected virtual void Start()
		{
		}

		private void ABHCDLEEBLC()
		{
		}

		protected override void OnDestroy()
		{
		}

		public virtual void CircuitSignalUpdated(Dictionary<EDBMANFHGGO, int> signals)
		{
		}

		private float MFJHMEBONCD()
		{
			return 0f;
		}

		protected void EIBOOAMOHJO()
		{
		}

		private void FJPEMDJNHPH()
		{
		}

		private void HPGFILBGLNE()
		{
		}

		protected virtual void OCBIBPILFFA()
		{
		}

		public void OnToggleTopSettings(bool MDPBNDAEFHH)
		{
		}

		public virtual void OnForceSettings(bool MDPBNDAEFHH)
		{
		}

		public void OnForceUpdate()
		{
		}

		protected void HJHAHFNGDGI(bool FBHDABEFLKL)
		{
		}

		private void FDGLCNPPOID()
		{
		}

		private void JJCCCNKPPFE(Color HMCAFGCGFJF)
		{
		}

		private void OAPFJKOBPAE(CHILKDJABBF FBCDJHOIDJJ, GameRole DGNFCCOMMEL)
		{
		}

		private bool HDJAPEMBFLG()
		{
			return false;
		}

		private void FCIDBOHBLMI()
		{
		}

		protected void MNECEOLGCKC()
		{
		}

		protected abstract void LBLEKNIEBOC(CreationObject ICHBECDKHOJ, int LAGADKBKLAD);

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		protected abstract void AEEAMHBJJEL(KPCKNDCJELJ DNENFMFPGFO);

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		protected abstract void ANKEEHMDBOL(KPCKNDCJELJ DNENFMFPGFO);

		[CompilerGenerated]
		private void NJECLFNMMLF()
		{
		}

		[CompilerGenerated]
		private void IFFAOCGOFKF()
		{
		}

		[CompilerGenerated]
		private int CGCFMJJFBAJ()
		{
			return 0;
		}

		[CompilerGenerated]
		private void MGGIKLBLKGN(int DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private int FEIKBLOBBME()
		{
			return 0;
		}

		[CompilerGenerated]
		private void LOOBNEGPNGD(int DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private int AINNHJEBJNE()
		{
			return 0;
		}

		[CompilerGenerated]
		private void MEFCNBAOLDE(int DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private bool BNKKKFLIDNJ()
		{
			return false;
		}

		[CompilerGenerated]
		private void PMFHKMLKFEH(bool DGAGNFOEEIJ)
		{
		}
	}
}
