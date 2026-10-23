using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RecRoom.Avatars;
using RecRoom.Avatars.Data.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RecRoom.Storefronts
{
	public abstract class StorefrontSlotDisplay : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private sealed class FAPAFOOLELH
		{
			public OutfitType outfitType;

			internal bool _003CSetUpSetSlot_003Eb__1(AvatarItemSelection x)
			{
				return false;
			}
		}

		private sealed class JFPDCJGLIMC
		{
			public StorefrontSlotDisplay _003C_003E4__this;

			public bool spawnInCenter;

			public Transform spawnUnderTransform;

			internal void _003CSpawnImposterInSet_003Eb__0(GameObject storeItemGO)
			{
			}
		}

		[SerializeField]
		protected Button[] buttons;

		[SerializeField]
		protected float hoveredItemRotationSpeed;

		[SerializeField]
		protected float hoveredItemRotateBackSpeed;

		[SerializeField]
		protected Transform hoveredTransform;

		[SerializeField]
		protected float hoveredItemSlerpSpeed;

		[SerializeField]
		protected Tooltip tooltip;

		[SerializeField]
		protected TextMeshProUGUI nameText;

		[SerializeField]
		protected TextMeshProUGUI[] additionalText;

		[SerializeField]
		protected Color inactiveTextColor;

		[SerializeField]
		protected StorefrontItemContainer itemContainer;

		[SerializeField]
		protected Transform previewTransform;

		[SerializeField]
		protected PlayerAvatarDisplay playerAvatarDisplay;

		[SerializeField]
		protected float playerAvatarDisplayHeadlessHeight;

		[SerializeField]
		protected float playerAvatarDisplayEarringScale;

		[SerializeField]
		protected bool ignoreInitialPosition;

		private List<EOKBGGOAFLF> LNOFDAOKEAM;

		private int POPCAJIDCCM;

		private string BNMLJPPPEBI;

		protected Storefront OCNGKLDCJKG;

		protected Color MFNKNNEOJHC;

		protected Color BECHEOOBGCK;

		protected AvatarItem? JJCIIGBLIJF;

		protected IDisposable CKFAHBNEKNH;

		protected bool JFMDLEGOEHG;

		protected float HMPFAIOLPCP;

		protected Quaternion JMDALKJDKBF;

		protected Vector3 PEJEOHJJKBA;

		protected Vector3 JOOOOKLDGHK;

		private bool KEHKNFIADOJ;

public List<EOKBGGOAFLF> SlotGiftDrops
{
get 		{
			return null;
		}

private set {
		}
}

public int SlotIndex
{
get 		{
			return 0;
		}

private set {
		}
}

protected string BPIIJGBNBGB
{
get 		{
			return null;
		}

set {
		}
}

public StorefrontItemContainer ItemContainer
{
get 		{
			return null;
		}

set {
		}
}

public bool Active
{
get 		{
			return false;
		}

set {
		}
}

		public void OnPointerEnter(PointerEventData OEPDOIOJPHD)
		{
		}

		public void OnPointerExit(PointerEventData OEPDOIOJPHD)
		{
		}

		public void Initialize(Storefront OCNGKLDCJKG, int GMEHLIHLGEH)
		{
		}

		public virtual void SetUpSlot(GKPEKOLBBJL HLFOMOKJKAM, List<EOKBGGOAFLF> IEFNJCGKHFD)
		{
		}

		protected void NNLNJPLCIAF()
		{
		}

		public void ClearSlot(bool GMOFADEALNB = false)
		{
		}

		protected virtual void Awake()
		{
		}

		public void SetAsComingSoon()
		{
		}

		private AvatarItem GCHBPGFIIDP(DBFJJLIGAFA OPKDMEIFDHL)
		{
			return default;
		}

		public virtual void SetUpSetSlot(List<EOKBGGOAFLF> IEFNJCGKHFD)
		{
		}

		protected void DIKLEIBPPLD(bool BFDBCMGIOBG)
		{
		}

		protected void CHEFJKIHFPE(DBFJJLIGAFA OPKDMEIFDHL, Transform OHJBPLHOANP, bool NPKPFFEFJEL = false)
		{
		}

		private void GAHHBGJBCCA(float OKBAJEAPIHG)
		{
		}

		private void MNDCGLPGFFB(AvatarItem LLJGCDCPPJK)
		{
		}

		private void PHBLFOLAEDI(POPLPJGHHIA.IBLMGFBJMDI AGBGHKCBCDL)
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected void DBPADBBECEH(DBFJJLIGAFA OPKDMEIFDHL)
		{
		}

		public abstract void UpdateUIText();

		protected abstract void HJAFKBLFHPM(GKPEKOLBBJL HLFOMOKJKAM, List<EOKBGGOAFLF> IEFNJCGKHFD);

		[CompilerGenerated]
		private void CAKHALAGKMO(GameObject MNDLCPLHJDN)
		{
		}
	}
}
