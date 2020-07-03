using System;

namespace OHLogic.Actions
{
    public interface IAction
    {
        bool IsAvailable { get; }

        event EventHandler<IAction> ActionFinished;

        void Attempt();
        void Cease();
    }
}
