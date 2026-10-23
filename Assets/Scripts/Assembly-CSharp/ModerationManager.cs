using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class ModerationManager : SingletonMonoBehaviour<ModerationManager>
{
	[Serializable]
	public class ReportReasonVisual
	{
		public string text;

		public IBPKDJLFBHM.OMLBCKDFMHL reason;

		public List<string> cannedMessages;
	}

	[Serializable]
	public class CheerCategoryVisual
	{
		public LocalizedString localizedText;

		public DINMFHPHBEG.MMCGOCLBAEG cheerCategory;

		public Color color;
	}

	[SerializeField]
	private float vtkActiveDuration;

	[SerializeField]
	private List<ReportReasonVisual> reportReasonVisuals;

	[SerializeField]
	private List<CheerCategoryVisual> cheerCategoryVisuals;

public float VtkActiveDuration
{
get 	{
		return 0f;
	}

}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void LPHEHEELNOF()
	{
	}

	private void JFMJADHEMGO(JOIKJABJNEE AFIAEIAHDNE)
	{
	}

	private void PNDCENNFMAG(IBPKDJLFBHM.MCFHHMMIEHP NIFOGEBEDNG, string OFCFPGACNJB, int? AFBGIPGHBMO)
	{
	}

	public void Initialize()
	{
	}

	public ReportReasonVisual GetReportReasonVisual(IBPKDJLFBHM.OMLBCKDFMHL CKHHGBNHHCK)
	{
		return null;
	}

	public string GetCheerCategoryText(DINMFHPHBEG.MMCGOCLBAEG KGEBKKHKJGD)
	{
		return null;
	}

	public CheerCategoryVisual GetCheerCategoryVisual(DINMFHPHBEG.MMCGOCLBAEG KGEBKKHKJGD)
	{
		return null;
	}

	public static string GetBannedText()
	{
		return null;
	}

	public static string GetBannedTitle()
	{
		return null;
	}

	public static string GetBannedSubTitle()
	{
		return null;
	}

	private static string MIAOMBJFIJP(int BGGBEMDBOHE)
	{
		return null;
	}
}
