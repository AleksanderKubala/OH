using Assets.Body;

namespace Assets.Data
{
    public interface IEquipableObjectData : IPickupableObjectData
    {
        BodypartType RelevantBodypart { get; }
    }
}
