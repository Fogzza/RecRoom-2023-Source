using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using TMPro;
using UnityEngine;

public class PlayerEventSpecificText : MonoBehaviour
{
	public enum CPEADPNLCOL
	{
		Name = 0,
		Description = 1,
		Creator = 2,
		Room = 3,
		DateTime = 4,
		AttendeeCount = 5
	}

	[SerializeField]
	private PlayerEventSpecificUIBehaviour playerEventWatcher;

	[SerializeField]
	private TextMeshProUGUI text;

	[SerializeField]
	private CPEADPNLCOL playerEventPropertyToWatch;

	protected virtual void Awake()
	{
	}

	protected virtual void OnDestroy()
	{
	}

	protected virtual void OnEnable()
	{
	}

	private void OJGPLMMLJML(IMIJPHJKLIM OEPDOIOJPHD)
	{
	}

	[CompilerGenerated]
	private void HFGLMBGOKDA(DFDECAEJBIO ACBGBAAHOIM)
	{
	}

	[CompilerGenerated]
	private void HLINPEDPIJL(JCDPHCELKHI KPFNANKNKLE)
	{
	}
}
