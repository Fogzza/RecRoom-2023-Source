using System;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.Tools;
using UnityEngine;

namespace RecRoom.Activities.Toys
{
	public class RCCarRemoteControl : MonoBehaviourPun, DJLCHGFCFAD, LEJOPAFDMEE
	{
		[SerializeField]
		private RemoteControllable controlledObject;

		[SerializeField]
		private Transform resetControlledObjectTransform;

		[SerializeField]
		private CollisionForwarder leftResetButtonForwarder;

		[SerializeField]
		private CollisionForwarder rightResetButtonForwarder;

		[SerializeField]
		private Renderer screenRenderer;

		[SerializeField]
		private int screenMaterialIndex;

		[SerializeField]
		private Material screenRenderMaterial;

		[SerializeField]
		private Material defaultScreenMaterial;

		[SerializeField]
		private CollisionForwarder screenButtonForwarder;

		[SerializeField]
		private Vector2 resolution;

		[SerializeField]
		private Tool _tool;

		[SerializeField]
		private RemoteControlAnimation rcAnimation;

		[SerializeField]
		private TeamColorRenderer teamColorRenderer;

		private global::MOBDJNEDDKC<int> BEBAPNAKFDH;

		private bool EEKLGMACNPK;

		private Material BMPJADGEPHH;

		private RenderTexture KAACGMLIKHK;

		private float EOPIJLDMFED;

		private float PCGDGJOAODB;

		private Guid HNJEIEMGIPE;

public Tool Tool
{
get 		{
			return null;
		}

}

public RemoteControllable ControlledObject
{
get 		{
			return null;
		}

set {
		}
}

public bool HasControlledObject
{
get 		{
			return false;
		}

private set {
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

		private void Start()
		{
		}

		private void CMCHIOBKLNF(Tool PMEFICGEDFK, Vector2 FDPINLJAOOP, float FJNAAEFPLBO, bool CDEDFFHMNCD)
		{
		}

		protected override void OnDestroy()
		{
		}

		private void IEELJEBHDEI(Tool PMEFICGEDFK)
		{
		}

		private void JFGMIGPAJNO(Tool PMEFICGEDFK)
		{
		}

		private void BDBILDAKKCJ()
		{
		}

		public void AuthorityResetCar()
		{
		}

		private void AOKJHKGCBIK(Collider HNPEBINPOBO)
		{
		}

		private void HJJBLPIJHKG(Collider HNPEBINPOBO, bool DIOOGJDGEDC)
		{
		}

		public void OnCarReset(Tool PMEFICGEDFK, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		public void OnCarDestroyed(Tool PMEFICGEDFK)
		{
		}

		private void KKJLDNAAGLL(Color HMCAFGCGFJF)
		{
		}

		private void KKJLDNAAGLL()
		{
		}

		private void PFEHOFFPPDG(Material PMPDPBDKGPF)
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void PostDeserialize(GNFJMCHKBIK ALCJDCGEBLM)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		[CompilerGenerated]
		private void MICBDNPHPHC(Collider DHNNLHJMKIH)
		{
		}

		[CompilerGenerated]
		private void FODADHEPIKA(Collider DHNNLHJMKIH)
		{
		}
	}
}
