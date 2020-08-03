using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Interactables;

namespace Assets.Inventory
{
    //NOTE: possibly will be reused for any kind of item container, not just inventory. If so, it shoud be renamed properly and moved elsewhere
    public interface IInventoryWithdrawSubscriber
    {
        void OnItemWithdrawn(object sender, IInteractable item);
    }
}
