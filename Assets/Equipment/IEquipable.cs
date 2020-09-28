using Assets.Body;
using Assets.Inventory;

namespace Assets.Equipment
{
    public interface IEquipable : IPickupable
    {
        bool CanBeEquipped(Bodypart bodypartToEquipOn);
        bool CanBeUnequipped();
        void WhenEquipped();
        void WhenUnequipped();
    }
}
