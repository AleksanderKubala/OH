using System;
using UnityEngine.Events;

namespace Assets.UI.Events
{
    [Serializable]
    public class ContextMenuCalledEvent : UnityEvent<ContextMenuHandler>
    {
    }
}
