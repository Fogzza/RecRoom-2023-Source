using System;
using System.Collections.Generic;
using UnityEngine;

public interface ALCGFACOHOF : IDisposable
{

 Sprite TargetIcon
{
get ;
}

 Transform TargetDisplay
{
get ;
}

 bool HasValidTarget
{
get ;
}

 string ContentTypeDisplayName
{
get ;
}

 Dictionary<string, MIBJNNKFLND> DisplayFlagOptions
{
get ;
}

 NHGKMDCGGIM ContentType
{
get ;
}

 event Action<long> ContentTargetIdChanged;

 event Action ContentTargetDetailsUpdated;

	global::NCOKFFGPIJM<string> GetNameAsync();

	global::NCOKFFGPIJM<string> GetNameAsync(long IKHNIJKGJFD);

	void SetActive(bool FBHDABEFLKL);

	void SetContentTargetId(long IKHNIJKGJFD);

	void SetUIBehaviourElement(long PACFOLBJLAK);

	void ToggleContentTypeDisplay(bool FBHDABEFLKL);

	void SetDisplayType(out float MAPNJIMLAMD, out GameObject CECLGJEOAPE, NFMBFHFPDOA LMCPAOHFDNH);

	DGMPBIPKJEB GetDynamicLinkTargetConfigurableSetting(Action<CLKEJFGKNDK, KCOKPCOFDIM> DHIELHGFHKK);
}
