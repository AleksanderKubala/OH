using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Common
{
    public abstract class ContextualStatefulBehaviour : MonoBehaviour, IStatefulContext
    {
        protected IDictionary<Type, IState> registeredStates;
        protected IState pendingStateChange;
        protected object lockObject;

        public ContextualStatefulBehaviour()
        {
            registeredStates = new Dictionary<Type, IState>();
            lockObject = new object();
        }

        public IState CurrentState { get; protected set; }

        protected virtual void Awake()
        {
            InitializeStateMachine();
        }

        protected virtual void Update()
        {
            if(pendingStateChange != null)
            {
                TransitionState();
            }
        }

        public virtual bool IsInState(IState state)
        {
            return ReferenceEquals(state, CurrentState);
        }

        public virtual bool IsInState(Type stateType)
        {
            return stateType == CurrentState.GetType();
        }

        public void ChangeState(IState callingState, IState newState)
        {
            lock (lockObject)
            {
                if(CurrentState == callingState)
                {
                    pendingStateChange = newState;
                    //SetState(newState);
                }
            }
        }

        public T GetState<T>() where T : IState
        {
            registeredStates.TryGetValue(typeof(T), out var state);
            return (T)state;
        }

        public void RegisterState(IState state)
        {
            registeredStates[state.GetType()] = state;
        }

        protected abstract void InitializeStateMachine();

        protected void SetState(IState newState)
        {
            if(CurrentState != newState)
            {
                CurrentState?.Exit();
                CurrentState = newState;
                CurrentState.Enter();
            }
        }

        protected void TransitionState()
        {
            SetState(pendingStateChange);
            pendingStateChange = null;
        }
    }
}
