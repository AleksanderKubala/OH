using System;
using Assets.Interactables;
using UnityEngine.Events;

namespace Assets.UI.Events
{
    [Serializable]
    public class InventoryItemToggledEvent : UnityEvent<bool, IInteractable>
    {
    }
}
