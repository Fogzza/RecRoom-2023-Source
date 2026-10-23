using System;
using RecRoom.Inputs;
using UnityEngine;

namespace RecRoom.Core.VR.PlayerController
{
	[Serializable]
	public abstract class VRPlayerSteeringController
	{
		public abstract void KGMKIACPAOG(VRPlayerController BIEDNOLFJBE, Player EKOFNPFCLMO, Camera GAPPCJHIBEK, VRInputHandler APCLONJLBKH, VRInputHandler LLFLHHOFILH);

		public virtual void BEEAGBGBBPF()
		{
		}

		public virtual void BNJKHBPANNO()
		{
		}

		protected bool MPJCFKIMCHL(VRInputHandler LPHNBECFCJO, Camera GAPPCJHIBEK, bool DOMABNDIGOC, out Vector3 EDCANBIPEGG, out float OJMFBKHIOFM, out Vector3 EEPAMGLMMJE)
		{
			EDCANBIPEGG = default;
			OJMFBKHIOFM = default;
			EEPAMGLMMJE = default;
			return false;
		}

		protected void IKBCGEGICHA(VRInputHandler LPHNBECFCJO, Camera GAPPCJHIBEK, bool ABEJFBPPCIK, out Vector3 BPKEANIGKON, out Vector3 OHMMPNACNJO)
		{
			BPKEANIGKON = default;
			OHMMPNACNJO = default;
		}

		protected PlayerHand ENJJCEJMIDI(PlayerHand GBHOAABLEKO, PlayerHand BCLLPMALPJK)
		{
			return null;
		}

		protected VRInputHandler DBBFJJNHHAD(VRInputHandler LFJEJEOILJG, VRInputHandler DLGKNMMGGBP)
		{
			return null;
		}

		protected VRInputHandler LFPMEJCHCKB(VRInputHandler LFJEJEOILJG, VRInputHandler DLGKNMMGGBP)
		{
			return null;
		}

		protected void ICODFLAJNPE(Camera GAPPCJHIBEK, out Vector3 OHMMPNACNJO, out Vector3 FHKGPLLJFNJ, out Vector3 BPKEANIGKON)
		{
			OHMMPNACNJO = default;
			FHKGPLLJFNJ = default;
			BPKEANIGKON = default;
		}
	}
}
