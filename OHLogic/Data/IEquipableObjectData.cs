using OHLogic.Body;

namespace OHLogic.Data
{
    public interface IEquipableObjectData : IPickupableObjectData
    {
        BodypartType RelevantBodypart { get; }
    }
}
