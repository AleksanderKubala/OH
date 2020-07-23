namespace Assets.GameEntity
{
    public interface IGameEntityOwned
    {
        IGameEntity OwningGameEntity { get; }
    }
}
