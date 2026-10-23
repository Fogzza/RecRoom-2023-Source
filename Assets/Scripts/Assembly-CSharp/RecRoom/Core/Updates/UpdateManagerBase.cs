using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace RecRoom.Core.Updates
{
	public abstract class UpdateManagerBase<TGroup, TObject> : MonoBehaviour where TGroup : global::DDBNAGCMHEM<TObject> where TObject : EECFEKHMMHP
	{
		private Dictionary<string, TGroup> DMHFBFFLDOD;

		private List<TGroup> JFEFPJPNLKL;

		private BHNJIBDJFAL NJPJBDDAEFH;

		private IRecRoomQualityConfigProvider DABJFKPDEIL;

		public bool IsGroupRegistered(string LMCPBPEPKNG)
		{
			return false;
		}

		protected void HEBOGCGIAFC(string LMCPBPEPKNG, TGroup JAACCLPIBOC)
		{
		}

		protected void NMFKEDAKFPP(string LMCPBPEPKNG, TObject DBEHNMKAOAP)
		{
		}

		public void UnregisterObject(string LMCPBPEPKNG, Behaviour NPODHMILIGI)
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		protected abstract void DMDLCPBCBLH(List<TGroup> DBFMCDMHPMN, UpdateRateLimitType NBCIJGBGOPI);
	}
}
