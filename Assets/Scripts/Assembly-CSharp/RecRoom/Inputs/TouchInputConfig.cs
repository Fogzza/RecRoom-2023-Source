using System;
using UnityEngine;

namespace RecRoom.Inputs
{
	[Serializable]
	public class TouchInputConfig : BaseInputConfig
	{
		[SerializeField]
		private OLJFMMNFKAP touchInputType;

		[SerializeField]
		private MIKAPGMDNAD touchRegionType;

		public OLJFMMNFKAP TouchInputType => OLJFMMNFKAP.TouchInput;

		public MIKAPGMDNAD TouchRegionType => MIKAPGMDNAD.AimRegion;
	}
}
