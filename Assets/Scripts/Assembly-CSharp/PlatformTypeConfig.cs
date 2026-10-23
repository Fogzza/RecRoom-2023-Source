using System;

[Serializable]
public class PlatformTypeConfig<ContentType, SetType, SingleType> : RestrictedTypeConfig<EAFLPCNDJNK, ContentType, SetType, SingleType> where SetType : PlatformSpecificConfigSet<SingleType, ContentType> where SingleType : PlatformSpecificConfig<ContentType>
{
}
