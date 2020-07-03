using OHLogic.Items;

namespace OHLogic.Data
{
    public interface IItemData : IEquipableObjectData
    {
        ItemType ItemType { get; }

        IItem CreateItemInstance();
        float GetCarryingPerformanceCoefficient();
        float GetUsagePerformanceCoefficient();
    }
}
