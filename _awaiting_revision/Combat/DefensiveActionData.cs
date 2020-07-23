namespace Assets.Combat
{
    public interface IDefensiveActionData : IActionData
    {
        int MaximumDefensibleAttacks { get; }
    }
}
