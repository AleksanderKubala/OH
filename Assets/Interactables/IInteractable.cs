using Assets.Common;
using Assets.Data;
using Assets.Interactions;

namespace Assets.Interactables
{
    public interface IInteractable : INamedEntity, IDescribable
    {
        InteractableObjectData InteractableData { get; } 
        InteractionSet Interactions { get; }
    }
}
