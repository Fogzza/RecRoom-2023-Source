using System;
using UnityEngine;

namespace RecRoom.CircuitsV2.Adapter
{
	[Serializable]
	public class MockTypeAdapter : CFDOOCPPGEI
	{
		[SerializeField]
		private TypeKey key;

		[SerializeField]
		private bool isArray;

		[SerializeField]
		private bool isSync;

		[SerializeField]
		private bool supportsDefaultValue;

		[SerializeField]
		private bool supportsDisplayValue;

		[SerializeField]
		private bool inputValueAsText;

		private BHANLMJAEPJ _type;

		public TypeKey Key => TypeKey.None;

		public bool IsArray => false;

		public bool IsSync => false;

		public bool SupportsDefaultValue => false;

		public bool SupportsDisplayValue => false;

		public bool InputValueAsText => false;

		public bool KGJLILKHDAI(string IPMIIEAGJKC, out OHAJOLBEFND LFHMOIAMKBF)
		{
			LFHMOIAMKBF = default;
			return false;
		}

		public MockTypeAdapter()
		{
		}

		public MockTypeAdapter(BHANLMJAEPJ NIFOGEBEDNG)
		{
		}

		public BHANLMJAEPJ BILNCJOLHKI()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
