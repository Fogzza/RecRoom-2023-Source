using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using RecRoom.Avatars.Data.Shared;
using UnityEngine;

namespace RecRoom.Avatars.Data.Runtime
{
	[Serializable]
	public struct AvatarItem : IEquatable<AvatarItem>
	{
		[SerializeField]
		private AvatarItemData _avatarItemData;

		[SerializeField]
		private AvatarItemVisualData _avatarItemVisualData;

		private static Dictionary<string, AvatarItem> _avatarItemCache;

		private static readonly Regex AvatarItemDescriptionParsingRegex;

		public AvatarItemData AvatarItemData => null;

		public AvatarItemVisualData AvatarItemVisualData => null;

		public bool IsEarItem => false;

		public static void LIMNGKIEJGH(string ELDKAMCLDON, out string DDMKPBDHODM, out Guid JGNABAMMKMP, out Color NGEEIFEMNEC)
		{
			DDMKPBDHODM = null;
			JGNABAMMKMP = default;
			NGEEIFEMNEC = default;
		}

		private static void FICFJGBPPMI()
		{
		}

		public static bool KGBHEMKKOJH(string ELDKAMCLDON, bool EBBFPBAFIBI = false)
		{
			return false;
		}

		public AvatarItem(AvatarItemData EKGLMAPFMOE, AvatarItemVisualData IJKDIAOCIIC)
		{
			_avatarItemData = null;
			_avatarItemVisualData = null;
		}

		internal static AvatarItem MODMJFOGPAJ(string ELDKAMCLDON)
		{
			return default;
		}

		public static AvatarItem OJJFNFEPJGO(string EJPLJKIOGEJ, ArraySegment<string> FIFDFKHEPIK)
		{
			return default;
		}

		public string AKEGEMNIJND()
		{
			return null;
		}

		public static AvatarItem BBHHLOKGDAP(string ELDKAMCLDON)
		{
			return default;
		}

		public string GHKIEADOHKD()
		{
			return null;
		}

		public static bool IGJCLMPPAED(int APKKGFFBGLM, out AvatarItem ONIOMLIALGF)
		{
			ONIOMLIALGF = default;
			return false;
		}

		public static string EHMOACPIFFE(string ONOKJDEMIPN, string JGNABAMMKMP, Color NGEEIFEMNEC)
		{
			return null;
		}

		public static AvatarItem COPMOGFPPCA(LINLOKECLME LNKODFBLOKJ)
		{
			return default;
		}

		public static AvatarItem HFDMCFLJJPB()
		{
			return default;
		}

		public void KBPIOPKFLDJ(AvatarUgcOutfitData JOIHKFDAJAJ)
		{
		}

		public void KBPIOPKFLDJ(EDDPDJCKOBH.PACFAHJJKDC DFGPLOFKMDG)
		{
		}

		public void KBPIOPKFLDJ(Guid JGNABAMMKMP, Color OOLNAKAKIML)
		{
		}

		public bool Equals(AvatarItem HNPEBINPOBO)
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

		[SpecialName]
		public static bool IGOCGGBJBII(AvatarItem DNDNMGOKFEI, AvatarItem OHMMPNACNJO)
		{
			return false;
		}

		[SpecialName]
		public static bool BHBKJCPJNJN(AvatarItem DNDNMGOKFEI, AvatarItem OHMMPNACNJO)
		{
			return false;
		}

		public AvatarItem EKNKDADOBNE()
		{
			return default;
		}
	}
}
