using System.Collections.Generic;
using RRUI.Navigation;
using UnityEngine;

namespace RRUI
{
	[CreateAssetMenu]
	public class AutomationUIConfig : ScriptableObject
	{
		[SerializeField]
		private bool takeScreenshots;

		[SerializeField]
		private bool createADOTickets;

		[SerializeField]
		private List<Uri> baseUris;

		[SerializeField]
		private List<Uri> skipUris;

		[SerializeField]
		private List<RoutesConfig> prunedConfigs;

		[SerializeField]
		private bool verboseLogs;

		[SerializeField]
		private bool useTestUri;

		[SerializeField]
		private Uri testUri;

		public bool TakeScreenshots => false;

		public bool CreateADOTickets => false;

		public IReadOnlyList<Uri> BaseUris => null;

		public IReadOnlyList<Uri> SkipUris => null;

		public IReadOnlyList<RoutesConfig> PrunedConfigs => null;

		public bool VerboseLogs => false;

		public bool UseTestUri => false;

		public Uri TestUri => null;
	}
}
