using Asset.OnlyHuman.Characters;
using UnityEngine;

namespace Assets.Interactions
{
    public interface IInteraction
    {
        Transform InteractionSource { get; }
        //PerformInteractionCallback Perform { get; }
        void Perform(EntityController interactingEntity);
    }
}
