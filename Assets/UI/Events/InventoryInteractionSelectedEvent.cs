using System;
using Assets.Interactions;
using UnityEngine.Events;

namespace Assets.UI.Events
{
    [Serializable]
    public class InventoryInteractionSelectedEvent : UnityEvent<InventoryInteractionSelectedEventArgs>
    {
    }
}
