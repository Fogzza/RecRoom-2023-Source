using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GiftPackageVariantMap : HashableScriptableObject
{
	public enum NDFJGAOMJMK : byte
	{
		Ok = 0,
		Invalid = 1,
		NotFound = 2
	}

	[SerializeField]
	private GiftPackageVariant defaultVariant;

	[SerializeField]
	private Material defaultGiftBoxMaterial;

	[SerializeField]
	private GiftPackageVariant[] variants;

	private readonly Dictionary<IIGLDDDANPN, GiftPackageVariant> giftPackageVariantMappings;

	private readonly Dictionary<IIGLDDDANPN, GiftPackageVariant.GiftContextMapping> giftContextMappings;

	public GiftPackageVariant DefaultVariant => null;

	public Material DefaultGiftBoxMaterial => null;

	public override void OnAfterDeserialize()
	{
	}

	public NDFJGAOMJMK HCMOPJOCPME(IIGLDDDANPN DELCOFCGDFF, bool NAOOBAMOCHJ, out GiftPackageVariant JFIBNJGEOKC)
	{
		JFIBNJGEOKC = null;
		return NDFJGAOMJMK.Ok;
	}

	public GiftPackageVariant.GiftContextMapping NLDOPADCAMJ(IIGLDDDANPN DELCOFCGDFF)
	{
		return null;
	}

	private GiftPackageVariant LMPGDBGPEGP(IIGLDDDANPN DELCOFCGDFF, out GiftPackageVariant.GiftContextMapping MAAGNKLNEDD)
	{
		MAAGNKLNEDD = null;
		return null;
	}

	public override void AppendToHash(IncrementalHash NDFMMDHCKFC)
	{
	}
}
