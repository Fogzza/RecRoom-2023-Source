using RecRoom.Inputs;
using UnityEngine;

public abstract class OFABCKGIKCO<Runtime, Config> : global::KDIALCJLFBC<Runtime, Config> where Runtime : global::OFABCKGIKCO<Runtime, Config>, new() where Config : LegacyInputSourceConfig<Runtime, Config>
{
	private const float GHGIJAFOBCD = 0.25f;

	private const float MCKCHIKNDJC = 0.0625f;

	public override FIMLDFEDPAO DADAPOHKHIJ(InputConfig GOFBFKCJHGA, CDDOPEMBKHL CPMIJIMKLLM)
	{
		return FIMLDFEDPAO.Button;
	}

	public override bool IEPNNPFGNNG(InputConfig GOFBFKCJHGA, CDDOPEMBKHL CPMIJIMKLLM, out bool LJDIOIAOJBO)
	{
		LJDIOIAOJBO = default;
		return false;
	}

	public override bool JGNMJBGEKLO(InputConfig GOFBFKCJHGA, CDDOPEMBKHL CPMIJIMKLLM, out float DALFOKCKHIC, out bool OHAHOHOAINO)
	{
		DALFOKCKHIC = default;
		OHAHOHOAINO = default;
		return false;
	}

	public override bool MKMKNHPMPIO(InputConfig GOFBFKCJHGA, CDDOPEMBKHL CPMIJIMKLLM, out Vector2 EBGNPCKHKEE, out bool OHAHOHOAINO)
	{
		EBGNPCKHKEE = default;
		OHAHOHOAINO = default;
		return false;
	}

	public override bool FCBJIHHOHCD(InputConfig FPJKGKBOAOA, CDDOPEMBKHL CPMIJIMKLLM, out LBANDGNEOKM EBANKEIPBDO)
	{
		EBANKEIPBDO = default;
		return false;
	}

	public override bool CKPFNKGJBHN(out DFEJKGBJCPG HELFJBEPONI)
	{
		HELFJBEPONI = default;
		return false;
	}

	public override bool MIJIIAIPEIF(out Vector2 PCGHOJCDDLD)
	{
		PCGHOJCDDLD = default;
		return false;
	}

	protected abstract bool BHAEGEEGPBJ(InputConfig GOFBFKCJHGA, CDDOPEMBKHL CPMIJIMKLLM, out LegacyInputConfiguration FOCDHALGNDM);

	protected bool OHFKFEBAOBF(LegacyInputConfiguration FOCDHALGNDM)
	{
		return false;
	}

	protected bool FFGLAILLOLB(LegacyInputButtonConfiguration FPJKGKBOAOA)
	{
		return false;
	}

	protected bool MGOCIKAGGJO(LegacyInputCompositeButtonConfiguration FPJKGKBOAOA)
	{
		return false;
	}

	protected float NFACMPFLABK(LegacyInputAxis1DConfiguration FPJKGKBOAOA)
	{
		return 0f;
	}

	protected Vector2 KPDNOLPNABB(LegacyInputAxis2DConfiguration FPJKGKBOAOA)
	{
		return default;
	}

	protected virtual bool MNNKCDMJHNN(KeyCode FDAIMOMOHIG)
	{
		return false;
	}

	protected virtual float EACDNBCDDDL(string JLNCOOBCEKP)
	{
		return 0f;
	}

	private bool IFDGAGMCGPE()
	{
		return false;
	}
}
