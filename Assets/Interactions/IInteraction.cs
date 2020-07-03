using Asset.OnlyHuman.Characters;
using UnityEngine;

namespace Assets.Interactions
{
    public interface IInteraction
    {
        Transform InteractionSource { get; }
        void Perform(EntityController interactingEntity);
    }
}
