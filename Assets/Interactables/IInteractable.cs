using Assets.Common;
using Assets.Data;
using Assets.Interactions;

namespace Assets.Interactables
{
    public interface IInteractable : INamedObject, IDescribable
    {
        IInteractableObjectData InteractableData { get; } 
        InteractionSet Interactions { get; }
    }
}
