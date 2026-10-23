using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using AGUI.StackedUI.Dialog;
using TMPro;
using UnityEngine;

namespace RecRoom.Systems.PlayerRoles.UI
{
	public class RoleEditDialog : UIDialog<RoleEditDialog.PNEIPJGNIAF, List<string>, int, bool, RoleEditDialog.CAADGGIOLPL>
	{
		public enum PNEIPJGNIAF
		{
			Room = 0,
			Game = 1
		}

		public struct CAADGGIOLPL
		{
			public List<string> LLCGFDJNNDP;

			public HGKINAOMNIF IAMHCABOCOA;
		}

		[SerializeField]
		private TextInputUIDialog textInputDialogPrefab;

		[SerializeField]
		private RolePagedGrid pagedGrid;

		[SerializeField]
		private Button3D addRoleButton;

		internal List<string> GNECGCCFOKG;

		private int LENNCEGFHFN;

		private PNEIPJGNIAF LMEOABKDLHA;

		private bool CMAOBMFOGLH;

		private CAADGGIOLPL IFJFLEOJPFB(HGKINAOMNIF MLDANHIGANI)
		{
			return default;
		}

		public override void ForceCancel(bool EDLFMMEDNGP)
		{
		}

		public override global::NCOKFFGPIJM<CAADGGIOLPL> ShowDialog(PNEIPJGNIAF LMEOABKDLHA, List<string> CBHKIOIJNCG = null, int LENNCEGFHFN = 5, bool CMAOBMFOGLH = false)
		{
			return null;
		}

		public void Button_AddRole()
		{
		}

		private bool OCOGGOECGGJ(TextMeshProUGUI HADMIMJGCHD, string KAEDAICECGN)
		{
			return false;
		}

		public void Button_Done()
		{
		}

		internal void IJBIDKEOCAF(string AHNIMJDLOPB)
		{
		}

		private bool EEPAJIODOHE(string AHNIMJDLOPB)
		{
			return false;
		}

		private void MLGOHCCLHNE()
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<TextInputUIDialog.FOBELBLMBDE> NLJOGIMJBCN(TextInputUIDialog GDMKJGAKCND)
		{
			return null;
		}

		[CompilerGenerated]
		private void GHNNHLCKFKK(TextInputUIDialog.FOBELBLMBDE GOJCEBCMFJK)
		{
		}
	}
}
