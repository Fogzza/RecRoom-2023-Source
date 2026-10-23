using System;

public static class ICEEEAHNICK
{
	public enum JBNDDFGPMAG
	{
		Invalid = 0,
		ApplicationBackgrounding = 1,
		ApplicationQuitting = 2,
		UnexpectedRoomDisconnect = 3,
		CouldNotEnterRoom = 4,
		LoggingOut = 5,
		PresumedCrash = 6
	}

	[Serializable]
	public struct RejoinData
	{
		[NonSerialized]
		public int SequenceNumber;

		public string RoomName;

		public long RoomId;

		public long SubRoomId;

		public long EventId;

		public long ClubId;

		public string RoomCode;

		public bool IsPrivate;

		[NonSerialized]
		public DateTimeOffset EntryTimestamp;

		[NonSerialized]
		public DateTimeOffset? ExitTimestamp;

		public JBNDDFGPMAG ExitReason;

		public bool IsValid => false;

		public override string ToString()
		{
			return null;
		}
	}

	[Serializable]
	private struct SerializableRejoinData
	{
		public RejoinData InMemoryRepresentation;

		public string EntryTimestampString;

		public string ExitTimestampString;

		public static SerializableRejoinData JDLJININBGM(RejoinData PEGIMOFCJBD)
		{
			return default;
		}

		public RejoinData LKFFFPJCFNC()
		{
			return default;
		}

		private static string NEDFIGBJJOJ(DateTimeOffset? NJBFGEONCIB)
		{
			return null;
		}

		private static DateTimeOffset? NHPCFIENODD(string EDAOGGLBKMG)
		{
			return null;
		}
	}

	private enum PJLMGNADJLC
	{
		Dismissed = 0,
		Used = 1,
		Expired = 2
	}

	private static readonly Lazy<BHNJIBDJFAL> MFEOLMGDBHF;

	private const string BFINNILIEMF = "RoomRejoinOfferRejoinData";

	private static readonly TimeSpan LMFJHJJBIEO;

	private static readonly TimeSpan BPBIEJHAMAJ;

	private static readonly RejoinData AGKJCHFBBED;

	private static int IHDHINDBHPA;

	private static RejoinData FKMEKLDJDMC;

	private static bool PLPIDHNCBCP;

public static bool IJGAMMNGEFB
{
get 	{
		return false;
	}

set {
	}
}

	public static void IEHBBGELLOD(EGGMEJDMHKF GPKOELKKOBP)
	{
	}

	public static void CFFPHBDEMHJ()
	{
	}

	public static void APCBLFHOMBI(JBNDDFGPMAG CKHHGBNHHCK)
	{
	}

	public static void BDOKLAOCDFC(JCDPHCELKHI KPFNANKNKLE)
	{
	}

	public static void BPJCCKDBHNG(int CLFDAOANHIA)
	{
	}

	public static bool KAOPFLIFECJ(out RejoinData DKIECBEMEDL)
	{
		DKIECBEMEDL = default;
		return false;
	}

	private static void CPJKPBFGBNH(RejoinData MACKIDHLPAG)
	{
	}

	private static void NADLLKCBNEJ()
	{
	}

	private static bool EEOAHHAABKN(out RejoinData MACKIDHLPAG)
	{
		MACKIDHLPAG = default;
		return false;
	}

	private static void MFPGNEDLBCF(RejoinData IPNBHKEMIBJ, PJLMGNADJLC CDNLFEOBNKB)
	{
	}
}
