using UnityEngine;

namespace Assets.Interactions
{
    public interface IInteraction
    {
        Transform InteractionSource { get; }
        InteractionPerformedCallback Perform { get; }
    }
}
