using Assets.Common;
using Assets.Data;
using Assets.GameEntity;

namespace Assets.Body
{
    public interface IBodypart: IGameEntityOwned, IDamageable
    {
        IBodypartData BodypartData { get; }
    }
}

