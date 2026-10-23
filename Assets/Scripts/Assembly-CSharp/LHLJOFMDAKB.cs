using System;
using UnityEngine;

public class LHLJOFMDAKB
{
	[Flags]
	public enum DGAEPJIOOBH
	{
		ACCESS = 1,
		MODIFY = 2,
		ATTRIB = 4,
		CLOSE_WRITE = 8,
		CLOSE_NOWRITE = 0x10,
		OPEN = 0x20,
		MOVED_FROM = 0x40,
		MOVED_TO = 0x80,
		CREATE = 0x100,
		DELETE = 0x200,
		DELETE_SELF = 0x400,
		MOVE_SELF = 0x800
	}

	public delegate void GEPIAIHLHJE(DGAEPJIOOBH NIFOGEBEDNG, string KDENKOIEIEI);

	private class ENOFOBAMCMK : AndroidJavaProxy, IDisposable
	{
		private sealed class FEGGAJLHACL
		{
			public ENOFOBAMCMK _003C_003E4__this;

			public int eventType;

			public string path;

			internal void _003CJNICallback_OnFileChanged_003Eb__0()
			{
			}
		}

		private AndroidJavaObject JGPGCLDMHEG;

		private GEPIAIHLHJE ONAFALABHKI;

		public ENOFOBAMCMK(GEPIAIHLHJE LJDEBIDKOCJ, string KDENKOIEIEI, params string[] GBCIOKEIOGN)
			: base((string)null)
		{
		}

		public void Dispose()
		{
		}

		public void JNICallback_OnFileChanged(int eventType, string path)
		{
		}
	}

	private static LHLJOFMDAKB EGAIHCNFOEN;

	private ENOFOBAMCMK EJOLHPDFKJG;

public static LHLJOFMDAKB OFDKPDDLIJC
{
get 	{
		return null;
	}

private set {
	}
}

	static LHLJOFMDAKB()
	{
	}

	public void IHEKMEOIBOI(GEPIAIHLHJE ONAFALABHKI)
	{
	}
}
