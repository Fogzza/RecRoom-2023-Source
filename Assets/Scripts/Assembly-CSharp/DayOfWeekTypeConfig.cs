using System;

[Serializable]
public class DayOfWeekTypeConfig<ContentType, SetType, SingleType> : RestrictedTypeConfig<DayOfWeek, ContentType, SetType, SingleType> where SetType : DayOfWeekSpecificConfigSet<SingleType, ContentType> where SingleType : DayOfWeekSpecificConfig<ContentType>
{
}
