using Assets.Common;

namespace Assets.Data
{
    public interface IInteractableObjectData : INamedObject, IDescribable
    {
        GameObjectType ObjectType { get; }
    }
}
