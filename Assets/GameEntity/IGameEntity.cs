using Assets.Body;
using Assets.Inventory;
using Assets.Items;

namespace Assets.GameEntity
{
    public interface IGameEntity
    {
        IGameEntityStatistics Statistics { get; }
        IGameEntityBody Body { get; }
        IInventory Inventory { get; }
        bool Equip(IItem item);
        bool Unequip(IItem item);
        bool PutToInventory(IItem item);
        bool Drop(IItem item);
    }
}
