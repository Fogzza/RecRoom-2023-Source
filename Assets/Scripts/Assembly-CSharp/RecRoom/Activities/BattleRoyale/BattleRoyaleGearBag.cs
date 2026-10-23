using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.Activities.BattleRoyale
{
	public class BattleRoyaleGearBag : MonoBehaviourPun
	{
		private enum MNMGKOGBHJG
		{
			ON_BACK = 0,
			NOT_ON_BACK = 1
		}

		[Serializable]
		private struct BattleRoyaleGearSlotDescriptor
		{
			[SerializeField]
			public string Name;

			[SerializeField]
			public Transform SlotTransform;

			[SerializeField]
			public SerializedGuid[] SupportedEquipmentTypeIds;

			[NonSerialized]
			private JBGFOIKBKED[] _supportedEquipmentTypes;

			public JBGFOIKBKED[] SupportedEquipmentTypes => null;
		}

		private sealed class KFKEKPMDPMB : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BattleRoyaleGearBag _003C_003E4__this;

			public Tool tool;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public KFKEKPMDPMB(int _003C_003E1__state)
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
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private Collider easyAccessCollider;

		[SerializeField]
		private BattleRoyaleGearSlotDescriptor[] bagSlotDescriptors;

		[SerializeField]
		private RecRoomAudioClip putOnSFX;

		[SerializeField]
		private RecRoomAudioClip takeOffSFX;

		[SerializeField]
		private RecRoomAudioClip hipAttachSFX;

		[SerializeField]
		private RecRoomAudioClip hipDetachSFX;

		[SerializeField]
		private RecRoomAudioClip[] modifyStoredToolSFX;

		private MDEJADHJOEJ KLOLMMOJNHJ;

		private CHILKDJABBF OAKJCBAELHE;

		private Player HCGGCNEIEII;

		public List<CHNLCOIEBMH> bagSlots;

		private static Dictionary<string, object> HGOEFCGCHHK;

		private Tool DEPNLBCGOLM;

		private static readonly string PNLNIKGNHMO;

public Tool Tool
{
get 		{
			return null;
		}

}

private bool KINAJPBDOKP
{
get 		{
			return false;
		}

}

private Vector3 GOLOLEJAPPC
{
get 		{
			return default;
		}

}

private Quaternion BJLIDMPKNMF
{
get 		{
			return default;
		}

}

private bool DCHGKOFGJDG
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public void DropAllEquipment()
		{
		}

		private Tool FBLHAIPNEEN()
		{
			return null;
		}

		private void HAJACOHFHBE(Tool IEGMBEPJMGC)
		{
		}

		private void GHPJGMOFEKE(Tool IEGMBEPJMGC)
		{
		}

		private void PLLGKABPABI(Tool IEGMBEPJMGC, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		private bool OOHKHCNBJBC(Tool IEGMBEPJMGC, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
		{
			return false;
		}

		private bool KIMOIOCBDDG(out Vector3 INLGLHIPOMC, out Quaternion POIOCLOKJGH)
		{
			INLGLHIPOMC = default;
			POIOCLOKJGH = default;
			return false;
		}

		private bool FEBIHAJPMBF(Tool IEGMBEPJMGC, PlayerToolEquipSlot JMEEAMAPEDC)
		{
			return false;
		}

		private bool OLHLOAMJKOJ(Tool IEGMBEPJMGC, PlayerToolEquipSlot HHOGFBCFGAB)
		{
			return false;
		}

		private void FMMMHHEIGEL(Tool IEGMBEPJMGC, PlayerToolEquipSlot HHOGFBCFGAB)
		{
		}

		private void BOJDFLHLGNN(Tool IEGMBEPJMGC, PlayerToolEquipSlot HHOGFBCFGAB)
		{
		}

		public bool TryStoreToolInBag(Tool IEGMBEPJMGC)
		{
			return false;
		}

		private void GDEIKEAJJLG(Tool NDDJJBFNILI, CHNLCOIEBMH IKEAPCLKEPD)
		{
		}

		private void LMILHDNFBOH(Tool EPAANJHGANA, CHNLCOIEBMH IKEAPCLKEPD)
		{
		}

		private bool NFONNMEOJNK(Tool IEGMBEPJMGC, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
		{
			return false;
		}

		private void KODDOCJPEJA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void AKLEGHEADCJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private IEnumerator GNIGNHODMBO(Tool IEGMBEPJMGC)
		{
			return null;
		}

		public static BattleRoyaleGearBag InstantiateForLocalPlayer(BattleRoyaleGearBag GDEKLMNKJBC)
		{
			return null;
		}

		private bool KICAJPMGJMG(Player EKOFNPFCLMO)
		{
			return false;
		}
	}
}
