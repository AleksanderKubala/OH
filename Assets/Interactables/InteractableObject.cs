using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Common;
using Assets.Data;
using Assets.Interactables.Events;
using Assets.Interactions;
using UnityEngine;

namespace Assets.Interactables
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of better solution
    public abstract class InteractableObject : MonoBehaviour, IInteractable 
    {
        //TODO: consider refactoring InteractableStateSet class to use it here
        [SerializeField]
        private List<InteractableState> _initialStates;
        [SerializeField]
        private GameObject _interactions;
        private HashSet<InteractableState> _internalStateSet;

        [HideInInspector]
        public InteractableStateChangedEvent InternalStateChanged;

        //TODO: consider refactoring InteractableStateSet class to use it here
        public HashSet<InteractableState> CurrentState => new HashSet<InteractableState>(_internalStateSet);
        public abstract IInteractableObjectData InteractableData { get; }
        public HashSet<Interaction> Interactions => new HashSet<Interaction>(_interactions.GetComponents<Interaction>());
        public string Name => InteractableData.Name;

        protected virtual void Awake()
        {
            _internalStateSet = new HashSet<InteractableState>();
            foreach(var state in _initialStates)
            {
                _internalStateSet.Add(state);
            }
        }

        protected virtual void Start()
        {
            InternalStateChanged?.Invoke(_internalStateSet);
        }

        public void AddState(InteractableState newState)
        {
            _internalStateSet.ExceptWith(newState.ExclusiveStates);
            _internalStateSet.Add(newState);
            InternalStateChanged?.Invoke(CurrentState);
        }

        public void RemoveState(InteractableState removedState)
        {
            _internalStateSet.Remove(removedState);
            InternalStateChanged?.Invoke(CurrentState);
        }

        public bool IsInState(InteractableState state)
        {
            var containsState = _internalStateSet.Contains(state);

            return containsState;
        }

        public bool IsInState(IEnumerable<InteractableState> state)
        {
            var containsAllStates = _internalStateSet.IsSupersetOf(state);

            return containsAllStates;
        }

        public bool HasState(IEnumerable<InteractableState> state)
        {
            var containsSomeStates = _internalStateSet.Overlaps(state);

            return containsSomeStates;
        }

        public string GetDescription()
        {
            return InteractableData.GetDescription();
        }
    }
}
