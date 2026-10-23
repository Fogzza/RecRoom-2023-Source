using System;

[Serializable]
public class HardwareTypeConfig<ContentType, SetType, SingleType> : RestrictedTypeConfig<CILEIOOHEOB, ContentType, SetType, SingleType> where SetType : HardwareSpecificConfigSet<SingleType, ContentType> where SingleType : HardwareSpecificConfig<ContentType>
{
}
