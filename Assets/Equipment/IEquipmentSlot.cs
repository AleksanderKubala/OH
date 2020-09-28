using Assets.GameEntity;
using Assets.Items;

namespace Assets.Equipment
{
    public interface IEquipmentSlot : IGameEntityOwned
    {
        IItem EquippedItem { get; }

        //bool CanEquip(IItem objectToEquip);
        bool AssignItem(IItem itemToEquip);
        bool UnassignCurrentItem();
        bool IsOccupied();
        bool IsAvailable();
    }
}
