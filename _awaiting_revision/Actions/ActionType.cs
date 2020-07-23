using System;

namespace Assets.Actions
{
    [Flags]
    public enum ActionType
    {
        Undefined = 0,
        Neutral = 1,
        Attack = 2,
        Defence = 2 << 1,
        Combat = Attack | Defence,
    }
}
