using System;
using Asset.OnlyHuman.Characters;
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
        public Interaction[] exclusiveWith;
        [SerializeField]
        private string _interactionName;
        [SerializeField]
        private int _contextMenuPriority;

        public Transform InteractionSource => transform;
        public int ContextMenuPriority => _contextMenuPriority;
        public string ContextActionTitle => _interactionName;
        public bool ShowInContextMenu { get; protected set; }
        public bool IsEffective
        {
            get
            {   //possible problems if asynchronous access shows up
                return ShowInContextMenu;
            }
            set
            {
                ShowInContextMenu = value;
                foreach (var exclusive in exclusiveWith)
                {
                    exclusive.ShowInContextMenu = !value;
                }
            }
        }

        protected virtual void Start()
        {
           _contextMenuHandler.Subscribe(this);
            SetEffectiveByInteractableState();
        }

        void IContextActionSubscriber.OnSelectedInContextMenu()
        {
            GameManager.Player.AddInteractionToPerform(this);
        }

        public abstract void Perform(EntityController interactingEntity);
        protected abstract void SetEffectiveByInteractableState();
    }
}
