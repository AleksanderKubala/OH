using System;

namespace OHLogic.Common
{
    [Flags]
    public enum IntervalBoundsCheckSetting
    {
        BothExcluded = 0,
        UpperIncluded = 1,
        LowerIncluded = 2,
        BothIncluded = LowerIncluded | UpperIncluded
    }
}
