namespace OHLogic.GameEntity
{
    public interface IGameEntityOwned
    {
        IGameEntity OwningGameEntity { get; }
    }
}
