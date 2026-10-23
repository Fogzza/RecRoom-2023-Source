using System.Collections.Generic;
using UnityEngine;

public class SceneSpawnPoint : SpawnPoint
{
	private class DBFGCJIAKLC : global::HPIEEIFGNBA<SceneSpawnPoint>
	{
		public override int Compare(SceneSpawnPoint NNMPJECKECI, SceneSpawnPoint EFNJCAIBDLA)
		{
			return 0;
		}
	}

	private struct JGBHCCAHGLL
	{
		public string PLCCFFIMOEP;

		public bool NANMHNJEJIO;
	}

	public static global::HPIEEIFGNBA<SceneSpawnPoint> Comparer;

	private bool MGPLPMBFNED;

	private bool IBIIKLDMFFI;

	[SerializeField]
	[Space]
	private bool useDoorId;

	[SerializeField]
	private string doorQueryID;

	[SerializeField]
	private string roomSelectionQuery;

	private List<List<JGBHCCAHGLL>> EOPKENHPFPM;

public virtual bool IsDefaultSpawnPoint
{
get 	{
		return false;
	}

set {
	}
}

public virtual bool SupportsPreviousRoomCheck
{
get 	{
		return false;
	}

}

public virtual IList<long> PreviousRooms
{
get 	{
		return null;
	}

}

public virtual IList<long> PreviousSubRooms
{
get 	{
		return null;
	}

}

protected override Color BAFJOOPEPHO
{
get 	{
		return default;
	}

}

private List<List<JGBHCCAHGLL>> APPPCMOEFFI
{
get 	{
		return null;
	}

set {
	}
}

	private void Start()
	{
	}

	public bool HasValidPreviousRoomConfig(long DPGFOHLBLPF, long JAAHKAHCILF, string IDCGKCGIMGJ)
	{
		return false;
	}
}
