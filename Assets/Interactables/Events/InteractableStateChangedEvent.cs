using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Assets.Interactables.Events
{
    [Serializable]
    public class InteractableStateChangedEvent : UnityEvent<HashSet<InteractableState>>
    {
    }
}
