using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHLogic.Items.Events
{
    public class ItemUnequippedEventArgs : EventArgs
    {
        public ItemUnequippedEventArgs(IItem unequippedItem)
        {
            UnequippedItem = unequippedItem;
        }

        public IItem UnequippedItem;
    }
}
