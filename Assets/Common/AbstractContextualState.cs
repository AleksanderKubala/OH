using System;

namespace Assets.Common
{
    public abstract class AbstractContextualState<TContext> : IContextualState<TContext> where TContext : IStatefulContext
    {
        public AbstractContextualState(TContext context)
        {
            StateContext = context;
        }

        public abstract TContext StateContext { get; protected set; }

        protected void SolveSpecificReachableState<TState>(ref TState reachableState, Func<TContext, TState> creator) where TState : IContextualState<TContext>
        {
            //TODO: Replace with proper exception
            if (StateContext == null) { throw new Exception("Context for state is null"); }

            if (reachableState == null && (reachableState = StateContext.GetState<TState>()) == null)
            {
                reachableState = creator(StateContext);
                StateContext.RegisterState(reachableState);
            }
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Proceed();
        protected abstract void SolveAllReachableStates();
    }
}
