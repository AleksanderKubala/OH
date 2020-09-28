using Assets.GameEntity;

namespace Assets.Inventory
{
    public interface IPickupable : IGameEntityOwnershipTransferable
    {
        bool CanBeTaken(IGameEntity takingGameEntity);
        bool CanBeDropped();
        void WhenTaken();
        void WhenDropped();
    }
}
