using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RecRoom.Core.UI.RoomChat
{
	public class CannedChatConfig : ScriptableObject, ISerializationCallbackReceiver
	{
		private sealed class NIGIJHCBDFI
		{
			public string pathPart;

			internal bool _003CSetDynamicData_003Eb__0(FONIJAOCJOO c)
			{
				return false;
			}

			internal bool _003CSetDynamicData_003Eb__1(FONIJAOCJOO c)
			{
				return false;
			}
		}

		private static CannedChatConfig _instance;

		internal FONIJAOCJOO root;

		[SerializeField]
		private List<CannedChatItemSerializable> serializedCannedChatItems;

		private int GGLBGABPKFK;

		public static CannedChatConfig Instance => null;

		public List<FONIJAOCJOO> CannedChatItems => null;

		public int MaxChildren
		{
			[CompilerGenerated]
			get
			{
				return 0;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		private void IHEKMEOIBOI()
		{
		}

		private void OPGAGIFCFMF(List<FONIJAOCJOO> JNAAHMPCPAB, string AOGKIAJGOJL = null, string HNCBNDOKEOC = null)
		{
		}

		private int BLLNLCDHMIG(List<FONIJAOCJOO> JNAAHMPCPAB, int OPEEDCHJIDO = 0)
		{
			return 0;
		}

		public void ANFKPIHFOPP(IEnumerable<string> EDCAGNCGCJL)
		{
		}

		public void LCMEEOJHBKE(IEnumerable<string> EDCAGNCGCJL)
		{
		}

		public void BFNMGJHCMEA(IEnumerable<string> LJMLAGDLBPE)
		{
		}

		private void MAOCGAKBIEE(IEnumerable<string> DJIPBDOEMCO, HJOADBLLCAG GLLFHCCFIGK, params string[] KDENKOIEIEI)
		{
		}

		public void OnBeforeSerialize()
		{
		}

		private void GCNAOJPHKBD(FONIJAOCJOO NDBMKFECLIL)
		{
		}

		public void OnAfterDeserialize()
		{
		}

		private int NELFDKEFKHH(int GMEHLIHLGEH, out FONIJAOCJOO KNBPIEINLIG)
		{
			KNBPIEINLIG = null;
			return 0;
		}
	}
}
