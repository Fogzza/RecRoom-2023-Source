using System;
using UnityEngine;

public interface MMECCKDCDCE
{

 GameObject ProxyCollision
{
get ;
}

 bool IsProxyingEnabled
{
get ;
}

 event Action<(MMECCKDCDCE, bool)> IsProxyingEnabledChanged;
}
