using System;
using System.Security.Cryptography;
using RecRoom.Core;
using UnityEngine;

[Serializable]
public class GiftPackageVariant : JMIIPNGAANF
{
	[Serializable]
	public enum DequeueBehaviors
	{
		WaitUntilOpenedOrPlayerMoved = 0,
		ConsumeImmediately = 1
	}

	[Serializable]
	public class GiftContextMapping : JMIIPNGAANF
	{
		[SerializeField]
		private string name;

		public IIGLDDDANPN context;

		public Material material;

		public string label;

		public void AppendToHash(IncrementalHash NDFMMDHCKFC)
		{
		}
	}

	public string name;

	public DequeueBehaviors dequeueBehavior;

	public GiftBox prefab;

	public GiftContextMapping[] giftContextMappings;

	public void AppendToHash(IncrementalHash NDFMMDHCKFC)
	{
	}
}
