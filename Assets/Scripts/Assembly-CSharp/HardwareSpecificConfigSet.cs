using System;

[Serializable]
public class HardwareSpecificConfigSet<ConfigType, ContentType> : SpecificRestrictionConfigSet<CILEIOOHEOB, ConfigType, ContentType> where ConfigType : HardwareSpecificConfig<ContentType>
{
}
