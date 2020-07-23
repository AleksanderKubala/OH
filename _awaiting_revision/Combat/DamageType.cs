using System;

namespace Assets.Combat
{
    [Flags]
    public enum DamageType
    {
        None = 0,
        Fire = 1,
        Cold = 2,
        Shock = 2 << 1,
        Poison = 2 << 2,
        Acid = 2 << 3,
        Slashing = 2 << 4,
        Piercing = 2 << 5,
        Bludgeoning = 2 << 6,
        Elemental = Fire | Cold | Shock | Acid | Poison,
        NonElemental = Slashing | Piercing | Bludgeoning
    }
}
