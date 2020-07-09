using System;
using Asset.OnlyHuman.Characters;
using Assets.Managers;
using Assets.UI;
using Boo.Lang;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Interactions
{
    [RequireComponent(typeof(ContextMenuHandler))]
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
        public bool ShowInContextMenu { get; private set; }
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
        }

        void IContextActionSubscriber.OnSelectedByContextMenu()
        {
            GameManager.Player.AddInteractionToPerform(this);
        }

        public virtual bool Perform(EntityController interactingEntity)
        {
            //TODO: implement distance check
            return true;
        }
    }
}
