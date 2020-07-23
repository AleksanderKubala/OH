using System;
using System.Collections.Generic;
using Asset.OnlyHuman.Characters;
using Assets.Interactables;
using Assets.Managers;
using Assets.UI;
using UnityEngine;

namespace Assets.Interactions
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of better solution
    [Serializable]
    public abstract class Interaction : ContextMenuSubscriber, IInteraction, IContextActionSubscriber
    {
        [SerializeField]
        protected InteractableStateSet enablingStateSet;
        [SerializeField]
        protected InteractableStateSet failingStateSet;
        [SerializeField]
        private string _interactionName;
        [SerializeField]
        private int _contextMenuPriority;

        public Transform InteractionSource => transform;
        public int ContextMenuPriority => _contextMenuPriority;
        public string ContextActionTitle => _interactionName;
        public bool ShowInContextMenu { get; protected set; }
        public bool IsEffective { get; protected set; }
        protected abstract InteractableObject AssociatedInteractable { get; }

        private void Awake()
        {
            AssociatedInteractable.InternalStateChanged.AddListener(OnInteractableStateChanged);
        }

        protected virtual void Start()
        {
           _contextMenuHandler.Subscribe(this);
           // SetEffectiveByInteractableState();
        }

        void IContextActionSubscriber.OnSelectedInContextMenu()
        {
            GameManager.Player.AddInteractionToPerform(this);
        }

        protected virtual void OnInteractableStateChanged(HashSet<InteractableState> interactableNewState)
        {
            if(interactableNewState.Overlaps(enablingStateSet.IncludedStates))
            {
                IsEffective = true;
                ShowInContextMenu = true;
            }
            else
            {
                IsEffective = false;
                ShowInContextMenu = false;
            }
        }

        public abstract void Perform(EntityController interactingEntity);
    }
}
