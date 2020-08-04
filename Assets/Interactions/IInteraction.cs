using Asset.OnlyHuman.Characters;
using UnityEngine;

namespace Assets.Interactions
{
    public interface IInteraction
    {
        void Perform(EntityController interactingEntity);
        Transform GetInteractionSource();
    }
}
