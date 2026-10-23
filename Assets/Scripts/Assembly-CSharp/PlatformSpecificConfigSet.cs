using System;

[Serializable]
public class PlatformSpecificConfigSet<ConfigType, ContentType> : SpecificRestrictionConfigSet<EAFLPCNDJNK, ConfigType, ContentType> where ConfigType : PlatformSpecificConfig<ContentType>
{
}
