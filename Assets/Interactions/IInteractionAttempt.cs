using System.Collections.Generic;
using Asset.OnlyHuman.Characters;
using Assets.Common;
using Assets.GameEntity;
using Assets.Interactables;

namespace Assets.Interactions
{
    public interface IInteractionAttempt : IGameAction, IEnumerable<InteractionAttemptArgument>
    {
        EntityController InteractingEntity { get; set; }
    }
}
