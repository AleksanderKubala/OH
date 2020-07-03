namespace OHLogic.GameEntity
{
    public interface IGameEntityOwnershipTransferable : IGameEntityOwned
    {
        void TransferOwnership(IGameEntity newOwner);
    }
}
