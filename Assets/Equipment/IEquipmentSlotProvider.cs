using System.Collections.Generic;
using Assets.GameEntity;

namespace Assets.Equipment
{

    public interface IEquipmentSlotProvider : IGameEntityOwnershipTransferable
    {
        IEnumerable<EquipmentSlot> GetEquipmentSlots();
    }
}
