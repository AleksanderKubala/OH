using Assets.GameEntity;
using Assets.Interactables;

namespace Assets.Interactions
{
    public struct InteractionAttemptArgument
    {
        private IInteractable _argumentValue;

        public InteractionAttemptArgument(GameEntityType argument)
        {
            Argument = argument;
            _argumentValue = null;
        }

        public GameEntityType Argument { get; }
        public IInteractable Value
        {
            get => _argumentValue;
            set
            {
                if (value == null || value.InteractableData.GameEntityType.BelongsToType(Argument))
                {
                    _argumentValue = value;
                }
            }
        }
    }
}
