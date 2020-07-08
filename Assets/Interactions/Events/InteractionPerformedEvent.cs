using System;
using Asset.OnlyHuman.Characters;
using UnityEngine.Events;

namespace Assets.Interactions.Events
{
    [Serializable]
    public class InteractionPerformedEvent : UnityEvent<EntityController>
    {
    }
}
