namespace OHLogic.GameEntity
{
    public abstract class TransferableOwnershipObject : IGameEntityOwnershipTransferable
    {
        public IGameEntity OwningGameEntity { get; protected set; }

        public virtual void TransferOwnership(IGameEntity newOwner)
        {
            OwningGameEntity = newOwner;
        }
    }
}
