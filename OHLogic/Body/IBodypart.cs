using OHLogic.Common;
using OHLogic.Data;
using OHLogic.GameEntity;

namespace OHLogic.Body
{
    public interface IBodypart: IGameEntityOwned, IDamageable
    {
        IBodypartData BodypartData { get; }
    }
}

