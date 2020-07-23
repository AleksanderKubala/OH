using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Common
{
    public abstract class ContextualTickNotifierBehaviour : ContextualStatefulBehaviour, ITickNotifier
    {
        private readonly ISet<IListener> listenersToAdd;
        private readonly ISet<IListener> listenersToRemove;
        private readonly ISet<IListener> registeredTickListeners;

        public ContextualTickNotifierBehaviour() : base()
        {
            listenersToAdd = new HashSet<IListener>();
            listenersToRemove = new HashSet<IListener>();
            registeredTickListeners = new HashSet<IListener>();
        }

        protected override void Update()
        {
            base.Update();

            registeredTickListeners.ExceptWith(listenersToRemove);
            listenersToRemove.Clear();

            registeredTickListeners.UnionWith(listenersToAdd);
            listenersToAdd.Clear();

            if (registeredTickListeners.Any())
            {
                foreach (var listener in registeredTickListeners)
                {
                    listener.Notify();
                }
            }
        }

        public void RegisterTickListener(IListener listener)
        {
            listenersToAdd.Add(listener);
        }

        public abstract void RegisterTickListener(IListener listener, float tickInterval);

        public void UnregisterTickListener(IListener listener)
        {
            listenersToRemove.Add(listener);
        }
    }
}
