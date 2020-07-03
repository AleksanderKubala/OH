using Asset.OnlyHuman.Characters;

namespace Assets.Interactions
{
    public interface IInteractableOpenable
    {
        void Open(EntityController interactingEntity);
    }
}
