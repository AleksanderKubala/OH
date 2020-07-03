using System.Collections.Generic;

namespace OHLogic.Combat
{
    public interface IOffensiveActionData : IActionData
    {
        DamageType DamageType { get; }
        ISet<IDefensiveActionData> PossibleDefences{ get; }
    }
}
