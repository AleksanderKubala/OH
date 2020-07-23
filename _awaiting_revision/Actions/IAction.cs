using System;

namespace Assets.Actions
{
    public interface IAction
    {
        bool IsAvailable { get; }

        event EventHandler<IAction> ActionFinished;

        void Attempt();
        void Cease();
    }
}
