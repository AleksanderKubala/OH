using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Interactables;
using Assets.Interactions;

namespace Assets.UI.Events
{
    public class InventoryInteractionSelectedEventArgs : EventArgs
    {
        public IInteraction Interaction { get; set; }
        public IEnumerable<IInteractable> Interactables { get; set; }
    }
}
