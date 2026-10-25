using UnityEngine;
using UnityEngine.AddressableAssets;

public class RecRoomGameRoot : GameRoot
{
	[SerializeField]
	private AssetReference startupObjectReference;

	private const float OMDCOLPEMOJ = 60f;

	private float HKLOLBJDDDL;

	private MFENCGHNPBJ JBOKGAJENGP;

	protected override void Awake()
	{
	}

	private void Start()
	{
		var operation = Addressables.InstantiateAsync(startupObjectReference, transform, false, true);
		operation.WaitForCompletion().SetActive(true);
		HPCJAAEDLCH();
	}

	protected override void HPCJAAEDLCH()
	{
		base.HPCJAAEDLCH();
		new UnityEngine.GameObject("BootSequence").AddComponent<BootSequence>();
	}

	protected override void OnDestroy()
	{
	}

	private void ADNHOPPILKF()
	{
	}
}
