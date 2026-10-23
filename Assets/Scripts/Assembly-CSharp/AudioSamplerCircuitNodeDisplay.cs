using System;
using System.Collections.Generic;
using RecRoom.CircuitsV1;
using RecRoom.Core.Creation.CircuitsV1;
using UnityEngine;

public class AudioSamplerCircuitNodeDisplay : CircuitEventNodeDisplayBase
{
	public const EDBMANFHGGO PLAY_SLOT = EDBMANFHGGO.R;

	public const EDBMANFHGGO PAUSE_SLOT = EDBMANFHGGO.C;

	public const EDBMANFHGGO STOP_SLOT = EDBMANFHGGO.M;

	public const EDBMANFHGGO SPEED_SLOT = EDBMANFHGGO.G;

	public const EDBMANFHGGO VOLUME_SLOT = EDBMANFHGGO.B;

	private const float CCEPDIKPJHA = -1f;

	[SerializeField]
	private string playTooltip;

	[SerializeField]
	private string pauseTooltip;

	[SerializeField]
	private string resetTooltip;

	[SerializeField]
	private string speedTooltip;

	[SerializeField]
	private string volumeTooltip;

	[NonSerialized]
	private InputMetadata[] JOCLAIPHJHG;

	private bool GDGCJPFKLJC;

	private bool PCMNLOOCJPO;

	private bool PCJJOMGLOKI;

	private int MFBOGBCEFIH;

	private bool IEOJGIEHDAM;

	private int JAHFOMKIDGE;

	private Action OPGBNMDAJDC__BackingField;

public bool IsPlayActive
{
get 	{
		return false;
	}

private set {
	}
}

public bool IsPauseActive
{
get 	{
		return false;
	}

private set {
	}
}

public bool IsStopActive
{
get 	{
		return false;
	}

private set {
	}
}

public int VolumeSignal
{
get 	{
		return 0;
	}

private set {
	}
}

public bool VolumeConnected
{
get 	{
		return false;
	}

private set {
	}
}

public int SpeedSignal
{
get 	{
		return 0;
	}

private set {
	}
}

public override InputMetadata[] InputMeta
{
get 	{
		return null;
	}

set {
	}
}

public event Action OnCircuitInputsChanged {
add {
	}
remove {
	}
}

	protected override void OIONBPJBJPK()
	{
	}

	protected override void LGIICAFAHCP(BNOPDNILAFA HNPEBINPOBO, EDBMANFHGGO OBONMNBJMLD, BHEOAPLBNIE IHOMJCBGMCM)
	{
	}

	private bool NFIJEODOKBN(EDBMANFHGGO HHOGFBCFGAB)
	{
		return false;
	}

	protected override void BOIENBABEHB(Dictionary<EDBMANFHGGO, int> KLPFODAMNED)
	{
	}
}
