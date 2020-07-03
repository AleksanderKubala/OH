using OHLogic.Body;
using OHLogic.Data;
using OHLogic.DataObjects;
using OHLogic.Equipment;

namespace OHLogic.Items
{
    public interface IItem : IEquipable
    {
        IItemData ItemData { get; }
        ItemType ItemType { get; }
        BodypartType RelevantBodypart { get; }
    }
}
