using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Avatars.Data.Runtime;
using RecRoom.Avatars.Face;
using RecRoom.Avatars.Outfit;
using Unity.Jobs;
using UnityEngine;

namespace RecRoom.Avatars
{
	[DisallowMultipleComponent]
	public class PlayerAvatarDisplay : MonoBehaviour
	{
		public enum LMIHKAEHAPA
		{
			Default = 0,
			Invisible = 1,
			Pointing = 2,
			TPose = 4
		}

		internal enum BHFJCIMGEEC
		{
			None = 0,
			TeamItem = 1,
			SkinColor = 2,
			HairColor = 3,
			BeardColor = 4,
			UGCShirtColor = 5
		}

		internal enum HBALGEFAGIE
		{
			None = 0,
			HairTexture = 1,
			BeardTexture = 2,
			UGCShirtTexture = 3
		}

		public enum HBPOPOJNDKJ : byte
		{
			All = 0,
			LOD0Only = 1
		}

		private struct NLKPMMPABPA
		{
			public readonly Material LJDLKAAOHDN;

			public readonly BHFJCIMGEEC HLPCGADPEAK;

			public readonly HBALGEFAGIE FGPKKNECIAF;

			public readonly Player.NBPIPAJOGLC ECJKHMBOHLK;

			public NLKPMMPABPA(Material PMPDPBDKGPF, BHFJCIMGEEC EINECGEIEJO, HBALGEFAGIE HLLOOKAMOJD, Player.NBPIPAJOGLC MKLOBAIKINA)
			{
				LJDLKAAOHDN = null;
				HLPCGADPEAK = BHFJCIMGEEC.None;
				FGPKKNECIAF = HBALGEFAGIE.None;
				ECJKHMBOHLK = Player.NBPIPAJOGLC.Head;
			}

			public override string ToString()
			{
				return null;
			}

			public bool OFPEIHMPLIL(NLKPMMPABPA HNPEBINPOBO)
			{
				return false;
			}

			public override bool Equals(object ICHBECDKHOJ)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		private struct OKDELHDFKNO : IComparable<OKDELHDFKNO>
		{
			public int CJIGIPMJFAA;

			public PlayerAvatarDisplay HMHKJMAEDDK;

			public IList<AvatarItemSelection> MHHPIIHJCDL;

			public bool BHOKKBGLLFP;

			public int[] CBJDCDMBNIG;

			public float LDHIBGALEDK;

			public override string ToString()
			{
				return null;
			}

			public int CompareTo(OKDELHDFKNO HNPEBINPOBO)
			{
				return 0;
			}
		}

		private abstract class PGHHNLLGCIB
		{
			public class IOFCNAGAEHG
			{
				public readonly Mesh FIOJGABILKD;

				public readonly Material[] GOPNCMGHOPF;

				public readonly Transform[] LJJEFEHCKNG;

				public readonly Matrix4x4[] AFALMNGPLJL;

				public readonly Transform LEBCAOHIPGM;

				public readonly bool NAFJGONLMIM;

				private bool DIPDMHKPECD;

				private IOFCNAGAEHG()
				{
				}

				public IOFCNAGAEHG(Mesh AAKOJGEOGGC, Material[] LDFHAEGIADD, bool NONJBJLNBKO, Transform[] BLBKONLFICB, Transform ECLKMLGOOLB, Matrix4x4[] MKMIBICDJGA)
				{
				}

				public IOFCNAGAEHG(SkinnedMeshRenderer BMLILMNEJNA)
				{
				}

				public IOFCNAGAEHG(MeshRenderer EKCAEGPNHNA, Transform ECLKMLGOOLB)
				{
				}

				public static IOFCNAGAEHG GKNKGNMFAHA(Renderer LPCBHIEOFOB)
				{
					return null;
				}
			}

			public readonly Player.NBPIPAJOGLC ECJKHMBOHLK;

			public readonly Transform ACFDIFLDIBC;

			public readonly bool EOAJAOLIGEH;

public virtual bool ELCHFADPBEJ
{
get 			{
				return false;
			}

}

public virtual bool NCGICJEBIEP
{
get 			{
				return false;
			}

}

public bool JPOEDANBJJF
{
get 			{
				return false;
			}

}

			protected PGHHNLLGCIB(Player.NBPIPAJOGLC MKLOBAIKINA, Transform PEKFJHPOCFL, bool IMOPAPJIJII = false)
			{
				this.ACFDIFLDIBC = PEKFJHPOCFL;
				this.ECJKHMBOHLK = MKLOBAIKINA;
				this.EOAJAOLIGEH = IMOPAPJIJII;
			}

			public abstract LAHBDKNMNHN NIKKDCINIAA(int[] KPBFGIFOHDO, List<CEOIDCLNHCN> PNIJLLKGBCL, List<CEOIDCLNHCN> ODKGMJCKPCN);

			public abstract IOFCNAGAEHG DOJHAPEGONE(int EMMLNOGJBFM, PlayerHandBones MOFJHCJHHML);
		}

		private class FGFPHFMOCBF : PGHHNLLGCIB
		{
			private readonly BodyPartLODs KCMBGKPCIKE;

			private readonly Material[] CPOEGJMGDLJ;

			public FGFPHFMOCBF(Player.NBPIPAJOGLC MKLOBAIKINA, BodyPartLODs JDPAPIKFOHD, Material OEMMNFPAPND, Transform PEKFJHPOCFL = null, bool IMOPAPJIJII = false) : base(MKLOBAIKINA, PEKFJHPOCFL, IMOPAPJIJII)
			{
			}

			public override LAHBDKNMNHN NIKKDCINIAA(int[] KPBFGIFOHDO, List<CEOIDCLNHCN> EOMFECHEGNE, List<CEOIDCLNHCN> ODKGMJCKPCN)
			{
				return null;
			}

			public override IOFCNAGAEHG DOJHAPEGONE(int EMMLNOGJBFM, PlayerHandBones MOFJHCJHHML)
			{
				return null;
			}

			public override string ToString()
			{
				return null;
			}
		}

		private class CEFEKEBHDEB : PGHHNLLGCIB
		{
			public readonly AvatarItem AIKNOINHDGH;

			private global::EHOCIICLNGN<JHHDMDHLNGF> GNCPMLCMNMK;

			public JHHDMDHLNGF HDCMGPNAFCA;

			private global::EHOCIICLNGN<Material>[] BJNADNCPIFK;

			public List<Material> KHBCPLFELCG;

public override bool ELCHFADPBEJ
{
get 			{
				return false;
			}

}

public override bool NCGICJEBIEP
{
get 			{
				return false;
			}

}

			public CEFEKEBHDEB(Player.NBPIPAJOGLC MKLOBAIKINA, Transform PEKFJHPOCFL, AvatarItem JJCIIGBLIJF, bool IMOPAPJIJII = false) : base(MKLOBAIKINA, PEKFJHPOCFL, IMOPAPJIJII)
			{
				this.AIKNOINHDGH = JJCIIGBLIJF;
			}

			public override LAHBDKNMNHN NIKKDCINIAA(int[] KPBFGIFOHDO, List<CEOIDCLNHCN> EOMFECHEGNE, List<CEOIDCLNHCN> ODKGMJCKPCN)
			{
				return null;
			}

			public override IOFCNAGAEHG DOJHAPEGONE(int EMMLNOGJBFM, PlayerHandBones MOFJHCJHHML)
			{
				return null;
			}

			public static IOFCNAGAEHG ACAGLHFHNJB(OutfitPrefab PELIKPHKKAH, int EMMLNOGJBFM, PlayerHandBones NLMADAJFCOP)
			{
				return null;
			}

			public override string ToString()
			{
				return null;
			}

			[CompilerGenerated]
			private void JOAOPPGEMII(JHHDMDHLNGF CDNLFEOBNKB)
			{
			}

			[CompilerGenerated]
			private void KCKOPLCHNOI(global::EHOCIICLNGN<Material> NAGHFACMIJI)
			{
			}

			[CompilerGenerated]
			private void LFJDIMFCDFD(Material CDNLFEOBNKB)
			{
			}
		}

		public class BFEINBHPKOD
		{
			public static readonly int IHOALOKGNND;

			public static readonly int CAONJHLNBFE;

			public static readonly int FLEDAAAMNJC;

			private readonly PlayerHand.ICBKGDOJNDN BNNHCJJILFB;

			private readonly MDEJADHJOEJ LONGMDGPIHM;

			private readonly Animator EEFBNDMFJMF;

			private readonly Transform PBLIEOJBJEK;

			private readonly Vector3 AKJMGJMFCJG;

			private readonly Transform LMFKKIOGPMK;

			private readonly Vector3 JOPJEKEDCLF;

			private bool CFDDGHDKLNM;

			private bool IPAHLAPOLMG;

			private float DHMJGBPGLKN;

public bool COJNBIHLGFI
{
get 			{
				return false;
			}

set {
			}
}

public bool DPCMOCMKIOH
{
get 			{
				return false;
			}

set {
			}
}

public float KNEODENCOEE
{
get 			{
				return 0f;
			}

set {
			}
}

public LMIHKAEHAPA MBHNCCMHIPK
{
get 			{
				return LMIHKAEHAPA.Default;
			}

}

			public bool EGKKNDIELJH(LMIHKAEHAPA HDCJBCHGIOK)
			{
				return false;
			}

			private BFEINBHPKOD()
			{
			}

			public BFEINBHPKOD(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, Animator EEFBNDMFJMF, Transform PBLIEOJBJEK, Transform LMFKKIOGPMK, Vector3 AKJMGJMFCJG, Vector3 JOPJEKEDCLF)
			{
			}

			private void KHJGBNFCLIC(ushort BFCAFJCFELI, ushort JIDAFOMKMGC)
			{
			}

			private void HFKMFKHIOEM(ushort BFCAFJCFELI, ushort JIDAFOMKMGC)
			{
			}

			private void KEIGCGGOJKF(ushort BFCAFJCFELI, ushort JIDAFOMKMGC)
			{
			}

			private void HMCFIKFEIEB(ushort BFCAFJCFELI, ushort JIDAFOMKMGC)
			{
			}
		}

		public class LDGPIKAAJBF : IDisposable
		{
			public const int CPHEOEAGHDJ = 16;

			private MaterialPropertyBlock CCJNODPJDNN;

			public Color? GFGNHPFDDKC;

			public Color? PBMBGPGLKPM;

			public Color? JPGBNBIKOLH;

			public Color APAOCEFFCOL;

			public Color IMCONKDJHPE;

			public Color GLDFJPAAJNL;

			public Texture2D LMKJHJEOEBM;

			public Texture2D LDGBDEDCKEO;

			private Dictionary<NLKPMMPABPA, int> EDKJAOBDENB;

			private BHFJCIMGEEC[] PGACDHGMCIO;

			public Vector4[] CEGAMJEIOBG;

			public Vector4[] LECFCJJLJEL;

			public Vector4[] GBJKOFHJNPF;

			public Vector4[] FAEAEIOHJCB;

			public Vector4[] CBLMOKKDBAM;

			private List<Texture2D> IADGIFBODPA;

			private Vector4[] MKJOFKFNGIE;

			private List<Texture2D> MNPILLLMAED;

			private float[] PFBIMNBIDPP;

			private Vector4[] EFFFDDJOKOM;

			private float[] BFLMPFCOJDE;

			public float[] KMGEMFOOGIE;

			private List<Texture2D> DDEIPGONFKM;

			private float[] KFCIMCNAJDG;

			private Vector4[] ECHFMDDICHC;

			public float[] PDGDHODBMEA;

			public Texture2DArray EINPENHIMOF;

			public Texture2DArray ICMGHMGNADH;

			public Texture2DArray LLALOLGGKOF;

			private bool BKODCBCLGBL;

			private int AEDCDCNEBKD;

			private Vector2? MBPHIFNDDCP;

			private TextureFormat PGOOBKMAFAK;

			private Vector2? AMFGACHBLCP;

			private TextureFormat NIKMHKLAFBG;

			private Vector2? MHFEOCOHPLN;

			private TextureFormat HBLKDEEAAJF;

			private bool CAPGEKKMIBE;

			private static int DEJKFGPABJN;

			private static int HAEIOHIDKMK;

			private static int KOKGIBFEEAK;

			private static int LDLDCBGAIBH;

			private static int EECCPJHFKAA;

			private static int LIADINLLNNG;

			private static int GKHPOCLGBBB;

			private static int ICMFNPOOMLI;

			private static int KDGBINCLLDM;

			private static int LEEPFNGMJNO;

			private static int JHOBGNPCKGP;

			private static int DEOPOACMHLH;

			private static int HBPLOPHPEFH;

			private static int POBIDEHNJAG;

			private static int LPCFMNCOHAE;

			private static int OPAMPLEOBDJ;

public int HEIPHEGLBIF
{
get 			{
				return 0;
			}

}

			private LDGPIKAAJBF()
			{
			}

			public LDGPIKAAJBF(Color ONPHEDPFMOK, Color BANCACBOBOD, Color IGLKNLFGCPA, Color? OMBDNMCIMDP, Color? EEBEHJKFDFA, Color? BNLLLOGKPGN)
			{
			}

			internal int OMJEBBAPCKH(Material GJMKEAFCOAC, BHFJCIMGEEC EINECGEIEJO, HBALGEFAGIE HLLOOKAMOJD, Player.NBPIPAJOGLC MKLOBAIKINA)
			{
				return 0;
			}

			private int OMJEBBAPCKH(NLKPMMPABPA FDAIMOMOHIG)
			{
				return 0;
			}

			internal int OMAKDFCAGHN(Material GJMKEAFCOAC, Color EBMCKJCOLFP, Color DCELEFHEMED, Color MNHEMDHMGBM, Color IMHGDEOCJEG, Color PLNBDNKGFBB, Texture2D NDLAPHBBNOP, Vector4 HEIBNNMOHHB, Texture2D CAMBLMOCMFO, Vector4 NINGHLDNNEE, float IGEFLFIEOGH, float ODODDPBLPJC, Texture2D BLFJFCDMCIE, Vector4 LPLICDKNINB, float MDFMKCACMEM, BHFJCIMGEEC EINECGEIEJO, HBALGEFAGIE HLLOOKAMOJD, Player.NBPIPAJOGLC MKLOBAIKINA)
			{
				return 0;
			}

			private void PLMOLBOHALL(out Texture2DArray CKKBDKOPKEE, out Texture2DArray CLODHNHLDAG, out Texture2DArray EACKGBOOJDL)
			{
				CKKBDKOPKEE = null;
				CLODHNHLDAG = null;
				EACKGBOOJDL = null;
			}

			public void NOACGOADOPB(PlayerAvatarDisplay IOEMOOIENGD, Renderer LPCBHIEOFOB)
			{
			}

			private void FCHPJDINKJI(PlayerAvatarDisplay IOEMOOIENGD, Renderer LPCBHIEOFOB, int AHPAOIIKBFF)
			{
			}

			private Color KNDFLAOKLJN(Color ODEPIILPFHA, BHFJCIMGEEC EODEIOFOFHN)
			{
				return default;
			}

			private Color ALMLCAJNPGH(Color KPKNAFIPHFD, BHFJCIMGEEC EODEIOFOFHN)
			{
				return default;
			}

			private void HOOBNEJKAKB()
			{
			}

			public void Dispose()
			{
			}
		}

		[Serializable]
		public struct PlayerHandBones
		{
			public Transform[] LeftHandBones;

			public Transform LeftHandRoot;

			public Transform[] RightHandBones;

			public Transform RightHandRoot;

			public void EHHIJKOBIDL(Player.NBPIPAJOGLC MKLOBAIKINA, out Transform KPDGHDGLMHO, out Transform[] BLBKONLFICB)
			{
				KPDGHDGLMHO = null;
				BLBKONLFICB = null;
			}
		}

		[Serializable]
		private struct BodyPartLODs
		{
			public Mesh[] LODs;

			public bool UseHandBones;
		}

		private sealed class NCALCCGAPDJ
		{
			public PlayerAvatarDisplay display;

			internal bool _003CRunQueuedBuilds_003Eb__0()
			{
				return false;
			}
		}

		private sealed class CLLNNECFAKK : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
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
			public CLLNNECFAKK(int _003C_003E1__state)
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

		private sealed class HHLGDEOOLMB
		{
			public AvatarItemSelection avatarItemSelection;

			public LIKFFCKGMNN cancelablePromise;

			public PlayerAvatarDisplay _003C_003E4__this;

			internal LAHBDKNMNHN _003CDownloadUgcTextures_003Eb__1(LINLOKECLME item)
			{
				return null;
			}

			internal void _003CDownloadUgcTextures_003Eb__2()
			{
			}
		}

		private sealed class AEFOOMBLIMB
		{
			public global::EHOCIICLNGN<Texture2D> resourceHandle;

			internal void _003CDownloadUgcTextures_003Eb__3()
			{
			}
		}

		private sealed class PKBGICKMMNJ
		{
			public AvatarItem overrideItem;

			public Player.NBPIPAJOGLC overrideBodyPart;

			internal bool _003CApplyUgcItemOverrides_003Eb__0(AvatarItemSelection selection)
			{
				return false;
			}
		}

		private sealed class EFIFOAKHIHI
		{
			public PlayerAvatarDisplay _003C_003E4__this;

			public JKHCJAJHGAO buildMeshPromise;

			internal IALAJKBOKBN _003CSetOutfitSelectionsImpl_003Eb__8(int lod)
			{
				return IALAJKBOKBN.Default;
			}

			internal void _003CSetOutfitSelectionsImpl_003Eb__0()
			{
			}

			internal void _003CSetOutfitSelectionsImpl_003Eb__1(string err)
			{
			}

			internal LAHBDKNMNHN _003CSetOutfitSelectionsImpl_003Eb__2()
			{
				return null;
			}
		}

		private sealed class HDDLFKMNHNG
		{
			public List<JKHCJAJHGAO> innerPromises;

			internal void _003CBuildLODMeshes_003Eb__0()
			{
			}
		}

		private sealed class OGEJIGIEIJE
		{
			public JKHCJAJHGAO loadAssetsPromise;

			public int[] LODs;

			public PlayerAvatarDisplay _003C_003E4__this;

			public List<PGHHNLLGCIB> parts;

			public bool isFirstPerson;

			public Func<int, IALAJKBOKBN> getLayer;

			public LDGPIKAAJBF materialPropertyBlock;

			public Material materialInstance;

			public LIKFFCKGMNN allBuildPromise;

			public Action _003C_003E9__3;

			public Action<string> _003C_003E9__4;

			internal void _003CEditorBuildMeshes_003Eb__0()
			{
			}

			internal void _003CEditorBuildMeshes_003Eb__1()
			{
			}

			internal void _003CEditorBuildMeshes_003Eb__3()
			{
			}

			internal void _003CEditorBuildMeshes_003Eb__4(string err)
			{
			}
		}

		private sealed class BMCMHLFBKMF
		{
			public DNFNHECILLJ cancelCombined;

			internal void _003CEditorBuildMeshes_003Eb__2()
			{
			}
		}

		private sealed class FFAIDMJHKMA : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public PlayerAvatarDisplay _003C_003E4__this;

			public List<PGHHNLLGCIB> parts;

			public int[] LODs;

			public List<JKHCJAJHGAO> innerPromises;

			public bool isFirstPerson;

			public Func<int, IALAJKBOKBN> getLayer;

			public LDGPIKAAJBF materialPropertyBlock;

			public Material materialInstance;

			private int _003ClodIndex_003E5__2;

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
			public FFAIDMJHKMA(int _003C_003E1__state)
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

		private sealed class DBLPIDDNOEP
		{
			public int[] LODs;

			public PlayerAvatarDisplay _003C_003E4__this;

			internal LAHBDKNMNHN _003CLoadAssets_003Eb__0(PGHHNLLGCIB p)
			{
				return null;
			}
		}

		private sealed class KEEHFBGNDIL
		{
			public LIKFFCKGMNN cancelable;

			internal void _003CLoadAssets_003Eb__2()
			{
			}

			internal void _003CLoadAssets_003Eb__3(string err)
			{
			}
		}

		private sealed class GOOIIKBEHGC
		{
			public bool waitingForComplete;

			public JobHandle lodBuildJobHandle;

			public long jobComplete;

			public Stopwatch stopwatch;

			public Action onThen;

			public SkinnedMeshRenderer newLODRenderer;

			public EBMJGBIIHMJ newMesh;

			public int lod;

			public long meshCopyComplete;

			public LBPALKINANP boneCollection;

			public List<Material> newUniqueMaterials;

			public long meshComplete;

			public Action onFinally;

			public LLEPAMALOAA jobMeshGroup;

			internal void _003CBuildLODMesh_003Eb__0()
			{
			}

			internal void _003CBuildLODMesh_003Eb__1()
			{
			}
		}

		private sealed class OMBEKMGDIHN
		{
			public Mesh mesh;

			internal void _003CBuildLODMesh_003Eb__2()
			{
			}
		}

		private sealed class IGNDEBGMLFG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public JobHandle handle;

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
			public IGNDEBGMLFG(int _003C_003E1__state)
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

		private static readonly int IJJKPGJGOBL;

		private static readonly int BNDBOIGGIPB;

		private static readonly int JKHJNHMBLNN;

		private static readonly int IIEHIJBAHFL;

		private static readonly int KEOKKFHIJDB;

		private static readonly int PGCINIBFIBE;

		private static List<PlayerAvatarDisplay> NFCMGPKMEBC;

		private Action DBGHDCCKCEG__BackingField;

		private Lazy<DCFGCHBJPOO> BBJDNEMJCIL;

		private Lazy<KNGMOOLONDN> OJFILDBIJFI;

		private string JKNLOBJEJEG;

		private AvatarCustomizationSettings.JKCCIHPHNHL GNGKJLKCPCC;

		private bool DJLFOKGHHOH;

		private bool PJJHACNOBPP;

		private static readonly int[] EGDEKPKFJBM;

		private static readonly int[] KKLCHGLBLFG;

		private JKHCJAJHGAO JOHKFELPIHD;

		private bool EGEGIDDOCCP;

		[SerializeField]
		private LODGroup lodGroup;

		[SerializeField]
		private Material bodyPartMaterial;

		[SerializeField]
		private PlayerAvatarDisplayIgnoreEffect ignoreEffect;

		private readonly List<CEOIDCLNHCN> BKBLHAPKKFB;

		private readonly List<CEOIDCLNHCN> KKIJCPLHMCJ;

		private readonly List<CEOIDCLNHCN> FDAGNHLFNPO;

		private readonly List<CEOIDCLNHCN> KNJBCNCMNEO;

		private Dictionary<NLKPMMPABPA, Material> PFGIGBOMBIB;

		private Dictionary<NLKPMMPABPA, Material> MODIPKGINNO;

		[SerializeField]
		private bool ignorePlayerMesh;

		[SerializeField]
		private Transform trackingSpace;

		[SerializeField]
		private BodyPartLODs Head;

		[SerializeField]
		private BodyPartLODs Ear;

		[SerializeField]
		private BodyPartLODs Torso;

		[SerializeField]
		private BodyPartLODs Hand;

		[SerializeField]
		private BodyPartLODs HandPointing;

		[SerializeField]
		public PlayerHandBones HandBones;

		[SerializeField]
		public Transform remoteMeshBase;

		[NonSerialized]
		public SkinnedMeshRenderer[] CurrentDefaultSkinnedMeshRenderers;

		private SkinnedMeshRenderer[] KEKDABILIKH;

		[NonSerialized]
		public SkinnedMeshRenderer[] CurrentVisibleInFirstPersonSkinnedMeshRenderers;

		private SkinnedMeshRenderer[] KPEDFPPFHHF;

		[SerializeField]
		public Transform firstPersonMeshBase;

		[SerializeField]
		private Shader uberShader;

		[SerializeField]
		private Shader agAvatarShader;

		[NonSerialized]
		private Material PIGMDGKAJDJ;

		private AGKKCNLHMBG LKOPHHDELPB;

		[NonSerialized]
		private AvatarCustomizationSettings FKHIBIEMMFI;

		[NonSerialized]
		private Material ACKLODJPKND;

		[SerializeField]
		private Transform headPropAnchor;

		[SerializeField]
		private Transform hatAnchor;

		private FitMeshHemisphere HGDOGEPMIJA;

		private bool MBMFPLIMKOC;

		private bool GBPKNNLKFHN;

		private AnchorParams HPCGFGPCONG;

		private bool MIAGGKFHILK;

		private AnchorParamsRestrictions KEDANMNFFBB;

		private bool MDLKKJCJHHG;

		private Transform AGEFJNCIIFC;

		private bool NNMJEKFIDHH;

		private bool BMCALGNMBMA;

		private Vector3 INOJDIFLLAM;

		private Quaternion LEPKPKCLPFH;

		private Vector2 EBFGIIBCECF;

		private FitMeshHemisphere GOKCHMFKMGJ;

		[SerializeField]
		protected PlayerFacialAnimator facialAnimator;

		[SerializeField]
		private Transform torsoPropAnchor;

		[SerializeField]
		private Transform torsoRootBone;

		[SerializeField]
		private Transform headRootBone;

		[SerializeField]
		private Transform leftHandRoot;

		[SerializeField]
		private Transform leftHandDefaultScaleRoot;

		[SerializeField]
		private Transform rightHandRoot;

		[SerializeField]
		private Transform rightHandDefaultScaleRoot;

		[SerializeField]
		private Animator leftHandAnimator;

		[SerializeField]
		private Animator rightHandAnimator;

		[SerializeField]
		private Transform leftHandPointingRoot;

		[SerializeField]
		private Transform rightHandPointingRoot;

		[NonSerialized]
		private Collider[] KCJEGJOFADJ;

		[NonSerialized]
		private Collider[] JMMGKMIFAOF;

		[NonSerialized]
		private BFEINBHPKOD[] JDKCNKKHMKB;

		[SerializeField]
		private Mesh faceMesh;

		public Dictionary<Renderer, LDGPIKAAJBF> currentPropertyBlocks;

		private Dictionary<Renderer, LDGPIKAAJBF> ICCLGDLDNGF;

		private Dictionary<AvatarItemSelection, List<NLKPMMPABPA>> CJMPILHCGMC;

		private Dictionary<AvatarItemSelection, List<NLKPMMPABPA>> NOLEEHOLFCH;

		private readonly Dictionary<AvatarItemSelection, global::EHOCIICLNGN<Texture2D>> POBEOIPCPEP;

		private readonly Dictionary<AvatarItemSelection, global::EHOCIICLNGN<Texture2D>> FGONKBHCIBI;

		private GFLDGMFBNFM DNINHGJOFMN;

		private int NIKIOEKLJED;

		private bool BLDKHALKJFJ;

		private bool PHBIHODBCCG;

		private JNKNMMDAHCF JPKKAMIKFJO;

		private Action<PlayerHand.ICBKGDOJNDN, LMIHKAEHAPA> HKPMIGLDMFC__BackingField;

		private static int AMALILBCOIF;

		private static List<OKDELHDFKNO> GKHENPFBPCC;

		private static LKGILLBEJEK NLOGDNNNKAA;

		private Color? MFALKBIABFC;

		private bool EKFIAAIIFON;

		private Color KBOLEJKGLHN;

		private Color? OPNDLFNOOIK;

		private Color? PEIHENAJFAA;

		private AvatarHairPattern BAFAJEOKHAL;

		private Color BCHPANDFLND;

		private Color HADIOFLOOCB;

		private AvatarHairPattern FHBAMIHNOAL;

		private AvatarItem? FFOBJHIPAJF;

		private Color AMCGBKACIHJ;

		private AvatarItemSelection? OJIHBFACJGF;

		private Texture NJDNCHPMMPL;

		private Color FNDDHCCBBFM;

		[SerializeField]
		private IList<AvatarItemSelection> _currentEquippedOutfitSelections;

		[SerializeField]
		private IList<AvatarItemSelection> _currentOutfitSelections;

		[SerializeField]
		private AvatarFaceShape _currentFaceShape;

		[SerializeField]
		private AvatarBodyShape _currentBodyShape;

		[SerializeField]
		private bool _hideEars;

		private int[] MAIPOEONOLA;

		private bool EFBOMDKCMLK;

		private static readonly string NJAGMPDPIHG;

		private static readonly FIHGBEHGLGB LLPFOFKHDHN;

		private readonly FIHGBEHGLGB BDEAAAOMIDH;

		private readonly FIHGBEHGLGB KCPBLCLKCIP;

		private NPONIOGJIAI AJDJLFDMJGJ;

private DCFGCHBJPOO BFNHBAALLJH
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

public string CustomName
{
get 		{
			return null;
		}

set {
		}
}

private JKHCJAJHGAO LGCIKKGGPIB
{
get 		{
			return null;
		}

set {
		}
}

public bool WaitForUgcTextureLoads
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsLoading
{
get 		{
			return false;
		}

}

public bool IsBuilt
{
get 		{
			return false;
		}

}

public PlayerAvatarDisplayIgnoreEffect IgnoreEffect
{
get 		{
			return null;
		}

}

public AGKKCNLHMBG DisplaySystem
{
get 		{
			return null;
		}

set {
		}
}

private Material AKPLGJBHEKD
{
get 		{
			return null;
		}

}

private Material NDGLOEGBMID
{
get 		{
			return null;
		}

}

public bool FitMeshActive
{
get 		{
			return false;
		}

}

public PlayerFacialAnimator FacialAnimator
{
get 		{
			return null;
		}

}

public BFEINBHPKOD[] HandVisualControllers
{
get 		{
			return null;
		}

}

public Mesh FaceMesh
{
get 		{
			return null;
		}

}

private GFLDGMFBNFM CPMDDNDGKDI
{
get 		{
			return null;
		}

}

private bool CJNBKOCJIAL
{
get 		{
			return false;
		}

}

public int ManualLod
{
get 		{
			return 0;
		}

set {
		}
}

private bool NBPNFOAICKA
{
get 		{
			return false;
		}

}

private static bool OGAKBHAAOKP
{
get 		{
			return false;
		}

}

public bool TorsoHidden
{
get 		{
			return false;
		}

set {
		}
}

public bool IsInitialized
{
get 		{
			return false;
		}

private set {
		}
}

private static LKGILLBEJEK AIIAJJHAGIM
{
get 		{
			return null;
		}

set {
		}
}

private Texture2D FDEEOKKOAEB
{
get 		{
			return null;
		}

}

private AvatarItem? HFPNMPHABNK
{
get 		{
			return null;
		}

}

public AvatarItem? DisplayedHair
{
get 		{
			return null;
		}

}

private Texture2D CPDFPKHGMIK
{
get 		{
			return null;
		}

}

private IReadOnlyList<Camera> NOCHNEGFALK
{
get 		{
			return null;
		}

}

private static bool BBHHIGEIGHP
{
get 		{
			return false;
		}

}

private bool JHOGJHDBKPM
{
get 		{
			return false;
		}

}

private bool HJKAMENHDEG
{
get 		{
			return false;
		}

}

public event Action BuildCompleted {
add {
		}
remove {
		}
}

public event Action<PlayerHand.ICBKGDOJNDN, LMIHKAEHAPA> OnHandVisualStateChanged {
add {
		}
remove {
		}
}

		public void SetDeformation(bool DJLFOKGHHOH, bool PJJHACNOBPP)
		{
		}

		private static Material HGHOEPLGCBO(Dictionary<NLKPMMPABPA, Material> KJJMJOIOCMD, Material PJAPOIDGEJF, BHFJCIMGEEC EINECGEIEJO, HBALGEFAGIE HLLOOKAMOJD, Player.NBPIPAJOGLC MKLOBAIKINA)
		{
			return null;
		}

		private void NJELHEDMPFI()
		{
		}

		private bool NOIJADJCCMH()
		{
			return false;
		}

		private void IDAPALKDGPM()
		{
		}

		private static void CPAKHJPENHJ(Dictionary<AvatarItemSelection, List<NLKPMMPABPA>> GHKLFJFOHKO, PGHHNLLGCIB EEHMPJNEILN, Material PJAPOIDGEJF, BHFJCIMGEEC EODEIOFOFHN, HBALGEFAGIE PDGFGGNKPJL)
		{
		}

		private void BMCMNJJNKJK()
		{
		}

		private void Awake()
		{
		}

		private void KDBJBOGIJBI(GHCCKFEJDOA GADDGJANIGG)
		{
		}

		private void PBGONNDABHJ()
		{
		}

		private void OnDestroy()
		{
		}

		private static void ANCNKPMFMAE(ref List<Material> CNLOHNJIAOG)
		{
		}

		private static void MDJKBKBBAFE(ref Dictionary<NLKPMMPABPA, Material> KJJMJOIOCMD)
		{
		}

		private static void CCEBKCBHHJK(ref Dictionary<Renderer, LDGPIKAAJBF> GEGINOFOFLM)
		{
		}

		private void MHLFOCGHFAP(SkinnedMeshRenderer[] KJJMMGMBOFO)
		{
		}

		private void CMLIGPPKBDC(SkinnedMeshRenderer BMLILMNEJNA)
		{
		}

		private void CMLIGPPKBDC(MeshRenderer EKCAEGPNHNA)
		{
		}

		private void NLPEFMCGLDE(List<CEOIDCLNHCN> PKBLPPNGOEN)
		{
		}

		private void GBNAHHNMBMC(Dictionary<AvatarItemSelection, global::EHOCIICLNGN<Texture2D>> GHKLFJFOHKO, bool IAPCLLMBGJM)
		{
		}

		private void GFNPBLBHGGI(Dictionary<AvatarItemSelection, List<NLKPMMPABPA>> GHKLFJFOHKO)
		{
		}

		public void RenderOutlines()
		{
		}

		public float GetHandOpenClosedAxis(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
			return 0f;
		}

		public void SetHandOpenClosedAxis(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, float HPLFKABFBAH)
		{
		}

		public LMIHKAEHAPA GetHandVisualState(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
			return LMIHKAEHAPA.Default;
		}

		public bool SetHandVisualState(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, LMIHKAEHAPA HBHENCACCPA)
		{
			return false;
		}

		public bool GetThumbsUpActive(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
			return false;
		}

		public void SetThumbsUpActive(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, bool OLMFBDNFKPP)
		{
		}

		public bool GetHandshakeActive(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
			return false;
		}

		public void SetHandshakeActive(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, bool IAAMFKGLEKE)
		{
		}

		public void ForceUpdateHandsVisualState()
		{
		}

		public static void ClearQueuedBuilds()
		{
		}

		private static void PCMEJBIICGB(PlayerAvatarDisplay MBKELLMCHMH)
		{
		}

		public void Rebuild()
		{
		}

		private static void FABFOLHKOIJ(PlayerAvatarDisplay NEJPNLGLCLI)
		{
		}

		private static void FABFOLHKOIJ(PlayerAvatarDisplay NEJPNLGLCLI, IList<AvatarItemSelection> DOEMJLEEDFD, bool BEEMEFPJIIL, int[] KPBFGIFOHDO)
		{
		}

		private static void HNJEDEBOCLB(OKDELHDFKNO JAOGPGKGOOE)
		{
		}

		private static IEnumerator<EGGPGCCKPCO> ACEPGKJLFFL()
		{
			return null;
		}

		private static OKDELHDFKNO IDEDDKNBMLK(ref List<OKDELHDFKNO> DANFLFALHBN)
		{
			return default;
		}

		public void SetCustomizationSettings(AvatarCustomizationSettings EEOKNDBPOBG)
		{
		}

		public void SetTeamColors(Color? BNLLLOGKPGN, bool NCGBKLAGAAM, Color FEGGFHJBPFO)
		{
		}

		private void JEAMLIIPELJ(Material PGEBOJFFOOA)
		{
		}

		private void JFLEDLGIKHA(Material PGEBOJFFOOA, Color DCELEFHEMED)
		{
		}

		private void HEONJMFIPJK(Material PGEBOJFFOOA, Color MNHEMDHMGBM)
		{
		}

		private void LMGNJJAEIEA(Material PGEBOJFFOOA, Texture2D CIONKGJFLOB)
		{
		}

		private void OLGBOLMEFJA(Material PGEBOJFFOOA, Texture LODMCLANKBD)
		{
		}

		private void DJFKGNJAEMG(Action<LDGPIKAAJBF> IGGGMCFDBGG)
		{
		}

		private void GJPJICCJEKH()
		{
		}

		private void BKEPAFCBBMM()
		{
		}

		private void LEAJNJNHEIK()
		{
		}

		private JKHCJAJHGAO IIFGLIKOLIO()
		{
			return null;
		}

		private void BICHOFLAEJB()
		{
		}

		public void ApplyUgcItemOverrides()
		{
		}

		public void SetBeardPrimaryColor(Color? JBLMAEOCOGL)
		{
		}

		public void SetBeardSecondaryColor(Color? JBLMAEOCOGL)
		{
		}

		public void SetBeardPattern(AvatarHairPattern CDAJMFEANMG)
		{
		}

		public void SetHairPrimaryColor(Color ODGFPOLICNF)
		{
		}

		public void SetHairSecondaryColor(Color ODGFPOLICNF)
		{
		}

		public void SetHairPattern(AvatarHairPattern CDAJMFEANMG)
		{
		}

		public void SetSkinColor(Color ONPHEDPFMOK)
		{
		}

		public void SetUgcItemVisualOverrides(AvatarItemSelection LMJEFDNABLH, Texture MNBPAFDNLOG, Color FHMMDCPGMEL)
		{
		}

		public void ClearUgcItemVisualOverrides()
		{
		}

		public void SetFaceShape(AvatarCustomizationSettings EEOKNDBPOBG)
		{
		}

		public void SetFaceShape(AvatarFaceShape ENBGMHGEHPC)
		{
		}

		public void SetBodyShape(AvatarCustomizationSettings EEOKNDBPOBG)
		{
		}

		public void SetBodyShape(AvatarBodyShape FCOEDBCJENM)
		{
		}

		public void SetHideEars(AvatarCustomizationSettings EEOKNDBPOBG)
		{
		}

		public void SetHideEars(bool ACOJLFMMNML)
		{
		}

		public void SetHelmetHair(AvatarCustomizationSettings.JKCCIHPHNHL IDFEFNLLEPJ)
		{
		}

		public void SetHatAnchorParameters(AnchorParams HFPFIACOILH, bool BKFNLLIBPMB)
		{
		}

		public void SetOutfitSelections(IList<AvatarItemSelection> DOEMJLEEDFD)
		{
		}

		public void SetOutfitSelections(IList<AvatarItemSelection> DOEMJLEEDFD, bool BEEMEFPJIIL)
		{
		}

		public void SetOutfitSelections(IList<AvatarItemSelection> DOEMJLEEDFD, HBPOPOJNDKJ KHMCNEKEEEB, bool BEEMEFPJIIL, bool BBEMADABGJF = false)
		{
		}

		private void EMEOFKBPIMB(IList<AvatarItemSelection> DOEMJLEEDFD, bool BEEMEFPJIIL, HBPOPOJNDKJ KHMCNEKEEEB, bool BBEMADABGJF)
		{
		}

		private void EMEOFKBPIMB(IList<AvatarItemSelection> DOEMJLEEDFD, bool BEEMEFPJIIL, int[] CBJDCDMBNIG, bool BBEMADABGJF)
		{
		}

		private void PJAHBKALDMD(IList<AvatarItemSelection> DOEMJLEEDFD, bool BEEMEFPJIIL, int[] CBJDCDMBNIG)
		{
		}

		private AvatarItem GCKNPAHOHFD(string FFELBGBAMAP, string FGPIHHIOKIF, Color NBOIIFGDAFG)
		{
			return default;
		}

		private MJGJFLLCAJJ INDDKMFOPFM(AvatarItem JJCIIGBLIJF, Player.NBPIPAJOGLC MKLOBAIKINA)
		{
			return null;
		}

		private BONAMGJKPCM HKJBMJFKCLJ(IList<AvatarItemSelection> DOEMJLEEDFD)
		{
			return null;
		}

		public void CleanupDisplayMeshes()
		{
		}

		private void LGECIEFHICL(IList<AvatarItemSelection> DOEMJLEEDFD, bool BEEMEFPJIIL, int[] CBJDCDMBNIG)
		{
		}

		private void HHCAJNHAJFL()
		{
		}

		private void AELLHBEFOCI()
		{
		}

		private void HAOKNIJIBLO()
		{
		}

		private void HFELMKMGOLG()
		{
		}

		private void AOMCJPJMDIM()
		{
		}

		private JKHCJAJHGAO LEGEBALMFCK(bool BEEMEFPJIIL, List<PGHHNLLGCIB> CMJNPCAIJHK, int[] CBJDCDMBNIG, Func<int, IALAJKBOKBN> JOBNIMBMLEO)
		{
			return null;
		}

		private JKHCJAJHGAO ANBLLMMKGCK(bool BEEMEFPJIIL, List<PGHHNLLGCIB> CMJNPCAIJHK, int[] CBJDCDMBNIG, Func<int, IALAJKBOKBN> JOBNIMBMLEO, LDGPIKAAJBF APJGLDPNCLH, Material PGEBOJFFOOA)
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> DPJKLALCLFD(bool BEEMEFPJIIL, List<PGHHNLLGCIB> CMJNPCAIJHK, int[] CBJDCDMBNIG, Func<int, IALAJKBOKBN> JOBNIMBMLEO, LDGPIKAAJBF APJGLDPNCLH, Material PGEBOJFFOOA, List<JKHCJAJHGAO> NMHGKPNLGPA)
		{
			return null;
		}

		private JKHCJAJHGAO PNIMHEMHHDJ(List<PGHHNLLGCIB> CMJNPCAIJHK, int[] CBJDCDMBNIG)
		{
			return null;
		}

		private LKGILLBEJEK IGOJEPMAKPC(List<PGHHNLLGCIB> CMJNPCAIJHK, int EMMLNOGJBFM, bool BEEMEFPJIIL, IALAJKBOKBN KOADGMIKBAB, bool AFJCDCJGLOK, LDGPIKAAJBF APJGLDPNCLH, Material PGEBOJFFOOA)
		{
			return null;
		}

		private static SkinnedMeshRenderer FLNOLGLPMMP(Transform DGLIIMHOHEG, Transform APNECEOOGCB, SkinnedMeshRenderer[] KJJMMGMBOFO, int EMMLNOGJBFM, IALAJKBOKBN KOADGMIKBAB)
		{
			return null;
		}

		private LKGILLBEJEK KGLJOLLPAIO(SkinnedMeshRenderer NCKKOJFLNPE, int EMMLNOGJBFM, IList<PGHHNLLGCIB> ODHPALBIIGJ, bool AFJCDCJGLOK, LDGPIKAAJBF APJGLDPNCLH, Material PGEBOJFFOOA)
		{
			return null;
		}

		private static BHFJCIMGEEC DELLMHNMHKI(PGHHNLLGCIB CKKLDDOPGDA, int ILMNGICAIHI)
		{
			return BHFJCIMGEEC.None;
		}

		private static HBALGEFAGIE KNJLAKNLIBC(PGHHNLLGCIB CKKLDDOPGDA, int ILMNGICAIHI)
		{
			return HBALGEFAGIE.None;
		}

		private Transform PAPDAKHFEBO(Player.NBPIPAJOGLC MKLOBAIKINA, OutfitType EHGPLLEIIBB)
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> IBBIKABHIDK(JobHandle PLFCHHKILCM)
		{
			return null;
		}

		private void PDDGMMLMOLP(int MEHPHGGOMLI, Material PMPDPBDKGPF, PGHHNLLGCIB CKKLDDOPGDA, out Texture2D CNKMBJNLIOC, out Vector4 FFNNOFLDLPO, out Texture2D BJDFEGDMIHC, out Texture2D DBNOCKCADMB)
		{
			CNKMBJNLIOC = null;
			FFNNOFLDLPO = default;
			BJDFEGDMIHC = null;
			DBNOCKCADMB = null;
		}

		private void JEACBOBCJGL(int MEHPHGGOMLI, Material PMPDPBDKGPF, PGHHNLLGCIB CKKLDDOPGDA, out Color EBMCKJCOLFP, out Color DCELEFHEMED, out Color MNHEMDHMGBM, out Color IMHGDEOCJEG, out Color PLNBDNKGFBB)
		{
			EBMCKJCOLFP = default;
			DCELEFHEMED = default;
			MNHEMDHMGBM = default;
			IMHGDEOCJEG = default;
			PLNBDNKGFBB = default;
		}

		private void LNPKNNDFJJK(Vector3 JPBOBPIHNBD, Quaternion BFFEBCMOFHH)
		{
		}

		private void KMBNJEJHLKJ(List<PGHHNLLGCIB> ODHPALBIIGJ)
		{
		}

		public void SetHatAnchorParameters(AnchorParams HFPFIACOILH, AnchorParamsRestrictions LDEKJMDLNHP)
		{
		}

		public static void CalculateHatAnchorParams(FitMeshHemisphere HGDOGEPMIJA, Transform AGEFJNCIIFC, AnchorParams HFPFIACOILH, AnchorParamsRestrictions KEDANMNFFBB, out Vector3 EGJKEDKNNAD, out Quaternion IBHAEICNMJI, out AnchorParams NPJKFBPGPEN)
		{
			EGJKEDKNNAD = default;
			IBHAEICNMJI = default;
			NPJKFBPGPEN = default;
		}

		public void ResetHatAnchor(Vector2 KKAGKGBGIPC, Vector3 GIAMLDGABBP, Vector3 FNHKBCONGFN)
		{
		}

		public CLMEHHLKBJG GetAnchorParamsRestrictions()
		{
			return null;
		}

		public void ApplyBlocks()
		{
		}

		public void ApplyHairPattern()
		{
		}

		public void ApplyBeardPattern()
		{
		}

		public void HideFirstPersonRenderersThisFrame(IReadOnlyList<Camera> GPODDNLCBNL = null)
		{
		}

		public void HideHandsThisFrame(IReadOnlyList<Camera> GPODDNLCBNL = null)
		{
		}

		public void HideRenderersThisFrame(IEnumerable<Renderer> KJJMMGMBOFO, IReadOnlyList<Camera> GPODDNLCBNL = null)
		{
		}

		public static void AddStaticForceMatrixRecalculationPerRenderToken(object IALNODEHBNN)
		{
		}

		public static void RemoveStaticForceMatrixRecalculationPerRenderToken(object IALNODEHBNN)
		{
		}

		public void AddForceMatrixRecalculationPerRenderFlag(object IALNODEHBNN)
		{
		}

		public void RemoveForceMatrixRecalculationPerRenderFlag(object IALNODEHBNN)
		{
		}

		private void EMDBOGEFFAA()
		{
		}

		public void AddDisableDynamicOcclusionCullingFlag(object IALNODEHBNN)
		{
		}

		public void RemoveDisableDynamicOcclusionCullingFlag(object IALNODEHBNN)
		{
		}

		private void AFJBDFILPIK()
		{
		}

		internal static void CNMPOIABLNO(OutfitPrefab PELIKPHKKAH)
		{
		}

		public override string ToString()
		{
			return null;
		}

		private void BEFENEGOJLD()
		{
		}

		public void SetWaitForUgcTextureLoads(bool NBINNMFBNCB)
		{
		}

		public void SetUgcTextureParameters(NPONIOGJIAI HMJOKPKOPCN)
		{
		}

		[CompilerGenerated]
		private void JKKHNPDIFEG()
		{
		}

		[CompilerGenerated]
		private void JDOGFOOPOAC(LDGPIKAAJBF JOPPLHIIGPD)
		{
		}

		[CompilerGenerated]
		private void DBCHMNOBAGB()
		{
		}

		[CompilerGenerated]
		private void PNNHABKEANN(LDGPIKAAJBF JOPPLHIIGPD)
		{
		}

		[CompilerGenerated]
		private void AHBGKBALLHE()
		{
		}

		[CompilerGenerated]
		private void JCPPBCBMAKD(LDGPIKAAJBF JOPPLHIIGPD)
		{
		}

		[CompilerGenerated]
		private void MHLNBMNKLBM()
		{
		}

		[CompilerGenerated]
		private void MELAFOCNAFK(LDGPIKAAJBF JOPPLHIIGPD)
		{
		}

		[CompilerGenerated]
		private void LOPEHAGELKE()
		{
		}

		[CompilerGenerated]
		private void IOEONHKKCCD(LDGPIKAAJBF JOPPLHIIGPD)
		{
		}

		[CompilerGenerated]
		private void ODGJGMJKLNK()
		{
		}

		[CompilerGenerated]
		private void ACPGFGGOMMI(LDGPIKAAJBF JOPPLHIIGPD)
		{
		}

		[CompilerGenerated]
		private void OIKAFGALLMA(KeyValuePair<AvatarItemSelection, global::EHOCIICLNGN<Texture2D>> OJLALMPBEAD)
		{
		}

		[CompilerGenerated]
		private void AOBMJDJLEIL(LDGPIKAAJBF JOPPLHIIGPD)
		{
		}

		[CompilerGenerated]
		private void CNDGMLEAPOB(LDGPIKAAJBF JOPPLHIIGPD)
		{
		}
	}
}
