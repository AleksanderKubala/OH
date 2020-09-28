using System.Collections.Generic;
using Assets.GameEntity;
using Assets.Items;

namespace Assets.Equipment
{
    public interface IEquipment : IGameEntityOwned
    {
        IEnumerable<EquipmentSlot> GetEquipmentSlots();
        IEnumerable<EquipmentSlot> GetEquipmentSlotsMatchingItem(IItem item);
    }
}
