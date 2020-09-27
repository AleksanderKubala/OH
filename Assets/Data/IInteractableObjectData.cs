using Assets.Common;
using Assets.GameEntity;

namespace Assets.Data
{
    public interface IInteractableObjectData : INamedEntity, IDescribable
    {
        GameEntityType GameEntityType { get; }
    }
}
