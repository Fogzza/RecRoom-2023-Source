using System;
using System.Collections.Generic;
using RecRoom.Core;
using RecRoom.Core.Creation;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public abstract class MakerPenTool
	{
		protected delegate bool BHIKJBJPFCB<T>(T CALIIBOOHJA);

		public enum JPAACPJFONC
		{
			PERMANENT = 0,
			PUSHED_ON_STACK = 1,
			PAUSE = 2,
			RESUME = 3
		}

		public static readonly DHJLEHBOGBG[] OBJECT_RAYCAST_RESULTS;

		public static readonly Guid[] SHAPE_RAYCAST_RESULTS;

		public static readonly ConnectionPoint[] CONNECTION_RAYCAST_RESULTS;

		protected static Collider ObjectRaycastLastColliderHit;

		protected static Collider ShapeRaycastLastColliderHit;

		[SerializeField]
		private bool pointerEnabled;

		[SerializeField]
		protected Color pointerColor;

		[NonSerialized]
		private CreationController creationController;

		[NonSerialized]
		private HHNPLBOFAGE targetMode;

		[NonSerialized]
		private FBEHJNCKJPN toolMode;

		[NonSerialized]
		private HashSet<HHNPLBOFAGE> supportedTargetModes;

		[NonSerialized]
		private DHJLEHBOGBG targetCreationContextObject;

		public CreationController CreationController => null;

		protected bool PointerEnabled => false;

		protected MakerPen MakerPen => null;

		protected MakerPenVisuals PenVisuals => null;

		public abstract string HudLabel { get; }

		public abstract Sprite HudSprite { get; }

		protected CreationContext ObjectContext => null;

		protected MMMPKIMPKKC ShapeContext => null;

		protected ConnectionCreationContext ConnectionContext => null;

		protected JJKLEAMOPMO ObjectClipboard => null;

		protected BBDAPJGONDD ColorableClipboard => null;

		protected MNDEIFKJEDE InventionEditPermission => null;

		protected CPNECPMDBEG OMScopeCapabilities => null;

		protected ALECMBNCDLJ OMScopeOperations => null;

		protected global::DDLEHONFEBP<DHJLEHBOGBG> MakerSelectionObject => null;

		protected global::AIGGMOPIIKJ<DHJLEHBOGBG> ObjectSelection => null;

		protected global::EOCHBHDFJOM<DHJLEHBOGBG> ObjectSelectionHighlight => null;

		protected global::GLEADKGGNKA<DHJLEHBOGBG> ObjectPicker => null;

		protected global::JMLHLJFACAP<DHJLEHBOGBG> ObjectConverter => null;

		protected AINHEFJAEPG ObjectSelectionBounds => null;

		protected GJPBOMNOBND ObjectCreationSettings => null;

		protected global::BAIMOJOCJOK<DHJLEHBOGBG> ObjectTransform => null;

		protected CAMIJPMLKOA ObjectSelectionColliders => null;

		protected global::HJIKCMILJMA<DHJLEHBOGBG> ObjectFrozenCommandReceiver => null;

		protected global::CJOLMILKEEG<DHJLEHBOGBG> ObjectSelectionCommandReceiver => null;

		protected global::JNKPGKLPGFB<DHJLEHBOGBG> ObjectRecolorCommandReceiver => null;

		protected global::ENDMHNLLGFN<DHJLEHBOGBG> ObjectDeleteCommandReceiver => null;

		protected global::DDLEHONFEBP<Guid> MakerSelectionShape => null;

		protected global::AIGGMOPIIKJ<Guid> ShapeSelection => null;

		protected global::EOCHBHDFJOM<Guid> ShapeSelectionHighlight => null;

		protected global::GLEADKGGNKA<Guid> ShapePicker => null;

		protected global::JMLHLJFACAP<Guid> ShapeConverter => null;

		protected AINHEFJAEPG ShapeSelectionBounds => null;

		protected GJPBOMNOBND ShapeCreationSettings => null;

		protected BMHNAMLFPHB ShapeAddAllCurrentScope => null;

		protected AHAGBOCIINO ShapeConfiguration => null;

		protected global::BAIMOJOCJOK<Guid> ShapeTransform => null;

		protected CAMIJPMLKOA ShapeSelectionColliders => null;

		protected global::CJOLMILKEEG<Guid> ShapeSelectionCommandReceiver => null;

		protected global::AGNNPIOFKPK<Guid> ShapeRecolorCommandReceiver => null;

		protected global::ENDMHNLLGFN<Guid> ShapeDeleteCommandReceiver => null;

		protected AJLCIODEHEA CircuitsConnectionPicker => null;

		protected global::JAHIGCAMOEO<ConnectionPoint> CircuitsConnectCommandReceiver => null;

		public virtual bool TouchTapSupported => false;

		protected void ENKEAILIJOM()
		{
		}

		protected void FCAAIAKFHHA(DHJLEHBOGBG GFCPAMJILIO, Collider LPGAJGPGKFM, LMKFOACECEG? PCJCGNMBNMF = null)
		{
		}

		public DHJLEHBOGBG CMGOCBBLLGM()
		{
			return null;
		}

		private void CKNHAPPPGPF(DHJLEHBOGBG GFCPAMJILIO, LMKFOACECEG? PCJCGNMBNMF)
		{
		}

		private void CKNHAPPPGPF(LMKFOACECEG DHFKEFOGFGM)
		{
		}

		public virtual void IHEKMEOIBOI(HHNPLBOFAGE IACECANFEKI, FBEHJNCKJPN CIMCLAFMGFE)
		{
		}

		public virtual void ALDDEDHEDDO(CreationController CDAIDKCCJJA)
		{
		}

		public virtual void BJDNGFKFKPK(JPAACPJFONC FFGKGJBJJIB, HHNPLBOFAGE HHOMFBOLLIJ)
		{
		}

		public virtual void KENBMBNOMKI(JPAACPJFONC FFGKGJBJJIB)
		{
		}

		public virtual void EHMICKMBCPH()
		{
		}

		public virtual bool HGLCADOJNPF(out string IEACNHGAIIE)
		{
			IEACNHGAIIE = null;
			return false;
		}

		public virtual LAHBDKNMNHN JAFIAHCBPBP()
		{
			return null;
		}

		public virtual void KPEMLOAHHBG()
		{
		}

		public virtual LAHBDKNMNHN JAFIAHCBPBP(EHLHPNPGFLN HANBCMDMCAG)
		{
			return null;
		}

		public virtual void ADFGMCFLMDL(HHNPLBOFAGE IACECANFEKI, EHLHPNPGFLN HANBCMDMCAG)
		{
		}

		public virtual void BDECNOADHFL(HHNPLBOFAGE IACECANFEKI)
		{
		}

		public virtual bool GLDCPHODIFE(Ray HAAAJDJGEFF)
		{
			return false;
		}

		protected Ray GFDICPJIEJB()
		{
			return default;
		}

		protected int GKKFEJCFKDN<T>(global::GLEADKGGNKA<T> OIBPGEEMMGM, global::JMLHLJFACAP<T> LMINEBCLHGO, T[] FBEIGBDGKIK, out Vector3 ONFGACKDJLO, out Collider DEJNJKMLELK)
		{
			ONFGACKDJLO = default;
			DEJNJKMLELK = null;
			return 0;
		}

		protected bool KHDIAAGJBJI<T>(global::GLEADKGGNKA<T> OIBPGEEMMGM, global::JMLHLJFACAP<T> LMINEBCLHGO, out T CDNLFEOBNKB, out Vector3 ADDOHKIBBAG, out Collider KKIFJDLKMKG)
		{
			CDNLFEOBNKB = default;
			ADDOHKIBBAG = default;
			KKIFJDLKMKG = null;
			return false;
		}

		protected bool OHCGHOMNELE(out bool AKBACLGJHKH, out bool FAJMJEDMEGB, BHIKJBJPFCB<DHJLEHBOGBG> INIDECMGBGH = null, LMKFOACECEG? IEMMIFODLAI = null)
		{
			AKBACLGJHKH = default;
			FAJMJEDMEGB = default;
			return false;
		}

		protected bool CKGPJJKKOBA(out bool AKBACLGJHKH, BHIKJBJPFCB<Guid> INIDECMGBGH = null, LMKFOACECEG? IEMMIFODLAI = null)
		{
			AKBACLGJHKH = default;
			return false;
		}

		protected bool BJBMABFAEII(out bool AKBACLGJHKH, BHIKJBJPFCB<Guid> INIDECMGBGH = null, LMKFOACECEG? IEMMIFODLAI = null)
		{
			AKBACLGJHKH = default;
			return false;
		}

		protected bool MGOFDIDJCHP<T>(global::AIGGMOPIIKJ<T> MPLIANHHNHG, global::GLEADKGGNKA<T> OIBPGEEMMGM, global::EOCHBHDFJOM<T> CNCPHGMKLML, global::CJOLMILKEEG<T> BLIGMIHDAID, global::JMLHLJFACAP<T> LMINEBCLHGO, T[] EELPNFMFDDB, bool OPOENEFCGFO, out Collider ADEJGIGBGHB, out bool AKBACLGJHKH, out bool FAJMJEDMEGB, BHIKJBJPFCB<T> INIDECMGBGH = null, LMKFOACECEG? IEMMIFODLAI = null)
		{
			ADEJGIGBGHB = null;
			AKBACLGJHKH = default;
			FAJMJEDMEGB = default;
			return false;
		}

		protected bool DCGCAJLAMDD(bool MJOJMCPFBML)
		{
			return false;
		}
	}
}
