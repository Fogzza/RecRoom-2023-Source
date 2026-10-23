using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomOrPlaylistSpecificText : MonoBehaviour
{
	public enum OJGKHLOAMHA
	{
		Name = 0,
		Description = 1,
		Creator = 2,
		Cheers = 3,
		Visits = 4
	}

	[SerializeField]
	private RoomOrPlaylistSpecificUIBehaviour roomwatcher;

	[SerializeField]
	private TextMeshProUGUI text;

	[SerializeField]
	private Image icon;

	[SerializeField]
	private OJGKHLOAMHA roomPropertyToWatch;

	protected virtual void Awake()
	{
	}

	protected virtual void OnDestroy()
	{
	}

	protected virtual void OnEnable()
	{
	}

	private void IMKKOLDCCDE(RoomOrPlaylistSpecificUIBehaviour.EBIKMOHGHOJ JDBHABEFGKF, RoomOrPlaylistSpecificUIBehaviour.OPBALFHHAFF BFFCGPJEHGB, BNKIKFBACEL NIFOGEBEDNG)
	{
	}

	[CompilerGenerated]
	private void MCLOIEODFMC(DFDECAEJBIO ACBGBAAHOIM)
	{
	}
}
