using Assets.Items;

namespace Assets.Data
{
    public interface IItemData : IEquipableObjectData
    {
        ItemType ItemType { get; }

        IItem CreateItemInstance();
    }
}
