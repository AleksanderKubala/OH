using Assets.Body;
using Assets.Data;
using Assets.Equipment;

namespace Assets.Items
{
    public interface IItem : IEquipable
    {
        IItemData ItemData { get; }
        ItemType ItemType { get; }
        BodypartType RelevantBodypart { get; }
    }
}
