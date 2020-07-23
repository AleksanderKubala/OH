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

        public int ContextMenuPriority => _contextMenuPriority;
        public string ContextActionTitle => _interactionName;
        public bool ShowInContextMenu { get; protected set; }
        public bool IsEffective { get; protected set; }
        protected abstract InteractableObject AssociatedInteractable { get; }
        public abstract Transform InteractionSource { get; }

        private void Awake()
        {
            AssociatedInteractable.InternalStateChanged.AddListener(OnInteractableStateChanged);
        }

        protected virtual void Start()
        {
            if(_contextMenuHandler != null)
            {
                _contextMenuHandler.Subscribe(this);
            }
        }

        void IContextActionSubscriber.OnSelectedInContextMenu()
        {
            GameManager.Player.AddInteractionToPerform(this);
        }

        protected virtual void OnInteractableStateChanged(HashSet<InteractableState> interactableNewState)
        {
            if(enablingStateSet.IsFulfilled(AssociatedInteractable.CurrentState))
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
