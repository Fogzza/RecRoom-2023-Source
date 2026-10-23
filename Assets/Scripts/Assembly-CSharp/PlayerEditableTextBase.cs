using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.Core.Creation.CircuitsV1;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[DisallowMultipleComponent]
public abstract class PlayerEditableTextBase : MonoBehaviourPun, DJLCHGFCFAD
{
	private class PCJDJDFJAGL
	{
		public string FPLKOKLLMBP;

		public string DHKPHNEJHOO;
	}

	[Serializable]
	public class UnityStringEvent : UnityEvent<string>
	{
	}

	[Serializable]
	public class CustomSafeStringAsciiConstraints
	{
		[SerializeField]
		private bool enabled;

		[SerializeField]
		private char min;

		[SerializeField]
		private char max;

		public bool Enabled => false;

		public bool PMEDNFDMJDB(char HOFAMEHDGKI)
		{
			return false;
		}
	}

	[SerializeField]
	private TextMesh textMesh;

	[SerializeField]
	private TextMeshPro textMeshPro;

	[SerializeField]
	private Text uiText;

	private readonly List<HJBBKOFENAJ> CBFILINHEKB;

	[SerializeField]
	protected string defaultMessage;

	[SerializeField]
	protected int maxMessageLength;

	[SerializeField]
	protected bool unescapeString;

	[SerializeField]
	private bool usesCircuits;

	[SerializeField]
	protected string dialogMessage;

	[SerializeField]
	protected DIKDHBKKFCM textInputMode;

	[SerializeField]
	private CircuitNodeDisplay nodeDisplay;

	[SerializeField]
	protected string purifyContext;

	[SerializeField]
	protected NCCCMIHAKMG purifyRuleset;

	public UnityStringEvent OnTextUpdated;

	[SerializeField]
	private CustomSafeStringAsciiConstraints customSafeStringAsciiConstraints;

	private readonly StringBuilder CHMIEDOFAHM;

	private static readonly Dictionary<EDBMANFHGGO, PCJDJDFJAGL> MCEOOFMGCNJ;

	private readonly Dictionary<EDBMANFHGGO, int> EIBBDDNDDMC;

	private string FFNJLIGNJNP;

	private bool KIOKNGCFMAH;

public IReadOnlyList<HJBBKOFENAJ> TextElements
{
get 	{
		return null;
	}

}

public bool BlockObjectPersistance
{
get 	{
		return false;
	}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 	{
		return GKDCHLMLHBJ.RunForAuthorityOnly;
	}

}

	protected override void Awake()
	{
	}

	protected void Start()
	{
	}

	public void RegisterEditables()
	{
	}

	protected abstract void ALGOHCLKDAD();

	protected override void OnDestroy()
	{
	}

	public void Circuit_UpdateText(Dictionary<EDBMANFHGGO, int> signals)
	{
	}

	public void Circuit_UpdateSingleSignalText(int LFHMOIAMKBF)
	{
	}

	private void DICLHJAALKP()
	{
	}

	protected void DDDHFOKNKKE()
	{
	}

	private void ADGHCPBCALC()
	{
	}

	private void MAOLBAOMADG()
	{
	}

	private string KJABCPFPOAG(string EIBIHJOIINF)
	{
		return null;
	}

	private bool MGMDGFPIJKI(string OFCFPGACNJB)
	{
		return false;
	}

	protected abstract string BJMJDEJMFKG();

	protected string FGFPONHPNAN(string HLIGBKANEEA, bool LEADDCGKMPF)
	{
		return null;
	}

	protected static string BIEMCIFIFGP(string OFCFPGACNJB, int AGMIFKKLEIF)
	{
		return null;
	}

	private void KCDOEADKDPM(string MAFKLMLIAOD)
	{
	}

	protected int POOKMCEECEK(EDBMANFHGGO HHOGFBCFGAB)
	{
		return 0;
	}

	public abstract void DeserializeFrom(NLOGDCDGECD FFILBGADKKN);

	public abstract void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM);

	[CompilerGenerated]
	private bool MFPHDDIBAAJ(char HOFAMEHDGKI)
	{
		return false;
	}
}
