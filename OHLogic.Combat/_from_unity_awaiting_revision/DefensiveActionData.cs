namespace OHLogic.Combat
{
    public interface IDefensiveActionData : IActionData
    {
        int MaximumDefensibleAttacks { get; }
    }
}
