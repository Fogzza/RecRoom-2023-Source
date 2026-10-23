using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using AGUI.StackedUI;
using Photon.Pun;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.CircuitsV1;
using RecRoom.Systems.PlayerRoles;
using UnityEngine;

public class GameRoleNodeWrapper : MonoBehaviourPun, DJLCHGFCFAD, AAGHAEPCFKP
{
	private sealed class EOMDINHGODM
	{
		public KLNOBKBCIEK roleId;

		public string newRoleName;

		public GameRoleNodeWrapper _003C_003E4__this;

		internal void _003CSetCurrentRoleName_003Eb__0(GMBCDOMHMFF.HLMOCMHMIEN response)
		{
		}
	}

	[SerializeField]
	private Tool tool;

	[SerializeField]
	private CircuitNodeDisplay circuitNodeDisplay;

	private static List<GameRoleNodeWrapper> CLMOILKOIDE;

	[SerializeField]
	private CreationObject creationObject;

	[SerializeField]
	private SimplePlayerEditableText editableRoleName;

	private CreationObjectSettingButtonUIControl IHFPCFGEPAC;

	private Guid? EKLMGLLOMDN;

	private string GBNFBFLNLLL;

	public const string ROLE_ID_INSTANTIATION_PARAM = "grn_rid";

public static IReadOnlyList<GameRoleNodeWrapper> AllGameRoleNodes
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

public Guid? CurrentRoleGuid
{
get 	{
		return null;
	}

private set {
	}
}

public string CachedRoleName
{
get 	{
		return null;
	}

set {
	}
}

	public static KeyValuePair<string, object> GameRoleInstantationParam(Guid JKHAGFEKALE)
	{
		return default;
	}

	public static Guid? GetGuidFromInstantationParam(Dictionary<string, object> ENFEHHMJMLG)
	{
		return null;
	}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	private void DJMOEIIJICL()
	{
	}

	private void CGBCDMFLCJP()
	{
	}

	private void JONJDLKNMPJ(string DPCMNOBDEDM)
	{
	}

	private bool ECBKEHFBGGP()
	{
		return false;
	}

	private string LEOFDFMEMLA()
	{
		return null;
	}

	protected override void OnDestroy()
	{
	}

	private void DFMCBFADKBB()
	{
	}

	private void MBJJANCBHGF(GameRole LLPLEAAKJPA)
	{
	}

	private void JHLKDLMEPKI()
	{
	}

	private void GBIJEOFODLE(FBLAHKFEHNM LJFNCCMLIDM, OELBDAKHAFC FCJBDJOMIHI)
	{
	}

	void AAGHAEPCFKP.PreDeserialize(FBLAHKFEHNM LJFNCCMLIDM, OELBDAKHAFC FCJBDJOMIHI)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GBIJEOFODLE
		this.GBIJEOFODLE(LJFNCCMLIDM, FCJBDJOMIHI);
	}

	public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
	{
	}

	public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
	{
	}

	[CompilerGenerated]
	private void IEEIPJMCPGL()
	{
	}

	[CompilerGenerated]
	private bool PKMMAMAPECJ()
	{
		return false;
	}

	[CompilerGenerated]
	private bool JHKLIKEALHO(GameRoleNodeWrapper KLLPAOHMCDE)
	{
		return false;
	}
}
