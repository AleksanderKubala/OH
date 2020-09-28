using System.Collections.Generic;

namespace Assets.Combat
{
    public interface IOffensiveActionData : IActionData
    {
        DamageType DamageType { get; }
        ISet<IDefensiveActionData> PossibleDefences{ get; }
    }
}
