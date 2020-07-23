namespace Assets.GameEntity
{
    public interface IGameEntityOwnershipTransferable : IGameEntityOwned
    {
        void TransferOwnership(IGameEntity newOwner);
    }
}
