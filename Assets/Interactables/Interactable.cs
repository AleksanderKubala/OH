using System.Collections.Generic;
using Assets.Data;
using Assets.Interactables.Events;
using Assets.Interactions;
using UnityEngine;

namespace Assets.Interactables
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of better solution
    public class Interactable : MonoBehaviour, IInteractable 
    {
        [SerializeField]
        private List<InteractableState> _initialStates;
        [SerializeField]
        private InteractionSet _interactions;
        private HashSet<InteractableState> _internalStateSet;
        [SerializeField]
        private InteractableObjectData _interactableData;

        public InteractableStateChangedEvent InternalStateChanged;

        public InteractableObjectData InteractableData { get; }
        public InteractionSet Interactions => _interactions;
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
            InternalStateChanged?.Invoke();
        }

        public void AddState(InteractableState newState)
        {
            _internalStateSet.ExceptWith(newState.ExclusiveStates);
            _internalStateSet.Add(newState);
            InternalStateChanged?.Invoke();
        }

        public void RemoveState(InteractableState removedState)
        {
            _internalStateSet.Remove(removedState);
            InternalStateChanged?.Invoke();
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
