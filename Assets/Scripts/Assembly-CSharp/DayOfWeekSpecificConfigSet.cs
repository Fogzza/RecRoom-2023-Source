using System;

[Serializable]
public class DayOfWeekSpecificConfigSet<ConfigType, ContentType> : SpecificRestrictionConfigSet<DayOfWeek, ConfigType, ContentType> where ConfigType : DayOfWeekSpecificConfig<ContentType>
{
}
