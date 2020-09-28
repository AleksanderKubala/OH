using System;
using System.Collections.Generic;

namespace Assets.Actions
{
    public interface IActionProvider<TAction> where TAction : IAction
    {
        event EventHandler ActionProviderInactive;
        event EventHandler ActionProviderActive;

        ICollection<TAction> GetActions();
    }
}
