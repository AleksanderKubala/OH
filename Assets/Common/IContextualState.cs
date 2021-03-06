﻿namespace Assets.Common
{
    public interface IContextualState<TContext> : IState where TContext : IStatefulContext
    {
        TContext StateContext { get; }
    }
}
