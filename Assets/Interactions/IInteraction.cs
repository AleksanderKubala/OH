using System.Collections.Generic;
using Asset.OnlyHuman.Characters;
using UnityEngine;

namespace Assets.Interactions
{
    public interface IInteraction
    {
        Transform GetInteractionSource();
        IInteractionAttempt GetInteractionAttempt();
        void Attempt(EntityController interactingEntity, List<InteractionAttemptArgument> arguments);
    }
}
