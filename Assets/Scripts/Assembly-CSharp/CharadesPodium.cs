using System;
using UnityEngine;
using UnityEngine.UI;

public class CharadesPodium : MonoBehaviour
{
	[Serializable]
	public struct PodiumConfiguration
	{
		public CharadesManager.FMBJBJOIIDH Mode;

		public GIBEGHKMCIE Team;

		public POEOMLLLCAI TeamPlayerIndex;
	}

	[SerializeField]
	private PodiumConfiguration[] podiumConfig;

	[SerializeField]
	private Image playerNameBackground;

	[SerializeField]
	private Text playerNameLabel;

	[SerializeField]
	private Image teamNameBackground;

	[SerializeField]
	private Text teamNameLabel;

	[SerializeField]
	private Tool podiumTool;

public Tool PodiumHandleTool
{
get 	{
		return null;
	}

}

	public POEOMLLLCAI GetPlayerIndex(int DNLPIHIBJDP)
	{
		return POEOMLLLCAI.INDEX_0;
	}

	public GIBEGHKMCIE GetTeam(int DNLPIHIBJDP)
	{
		return GIBEGHKMCIE.TEAM_1;
	}

	public PodiumConfiguration[] GetPodiumConfig()
	{
		return null;
	}

	public void SetPodiumColor(int DNLPIHIBJDP)
	{
	}

	public void SetPlayerName(string KKMCHAOLGFB)
	{
	}

	public void ClearPlayerName()
	{
	}
}
