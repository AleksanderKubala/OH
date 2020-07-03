using OHLogic.Body;
using OHLogic.DataObjects;
using OHLogic.GameEntity;
using OHLogic.Inventory;

namespace OHLogic.Equipment
{
    public interface IEquipable : IPickupable
    {
        bool CanBeEquipped(Bodypart bodypartToEquipOn);
        bool CanBeUnequipped();
        void WhenEquipped();
        void WhenUnequipped();
    }
}
