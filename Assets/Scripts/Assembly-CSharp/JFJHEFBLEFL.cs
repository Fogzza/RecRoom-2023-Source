using System;
using UnityEngine;

public interface JFJHEFBLEFL : IDisposable
{

 bool HasValidTarget
{
get ;
}

 Sprite ButtonIcon
{
get ;
}

 EFODFBBCBFH LinkType
{
get ;
}

 string LinkTypeDisplayName
{
get ;
}

 event Action<long> LinkTargetIdChanged;

 event Action LinkTargetDetailsUpdated;

	global::NCOKFFGPIJM<string> GetNameAsync();

	global::NCOKFFGPIJM<string> GetNameAsync(long IKHNIJKGJFD);

	global::NCOKFFGPIJM<string> GetImageNameAsync(out float GDMKKLNFDOP);

	global::NCOKFFGPIJM<string> GetImageNameAsync(long IKHNIJKGJFD, out float GDMKKLNFDOP);

	void SetActive(bool FBHDABEFLKL);

	void SetLinkTargetId(long IKHNIJKGJFD);

	DGMPBIPKJEB GetDynamicLinkTargetConfigurableSetting(Action<CLKEJFGKNDK, KCOKPCOFDIM> DGOMGMFAOFG);

	void FollowLink();
}
