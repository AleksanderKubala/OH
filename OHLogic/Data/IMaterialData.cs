namespace OHLogic.Data
{
    public interface IMaterialData
    {
        float YieldStrength { get; }
        float TensileStrength { get; }
        float CombustionTemperature { get; }
        float MeltingTemperature { get; }
    }
}
