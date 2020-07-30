using System;
using System.Collections.Generic;
using System.Dynamic;
using Asset.OnlyHuman.Characters;
using Assets.Common;
using Assets.Interactables;
using Assets.Managers;
using Assets.UI;
using UnityEngine;

namespace Assets.Interactions
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of better solution
    [Serializable]
    public abstract class Interaction : MonoBehaviour, IInteraction, INamedObject, IContextActionSubscriber, IEquatable<Interaction>
    {
        [SerializeField]
        protected InteractableStateSet enablingStateSet;
        [SerializeField]
        protected InteractableStateSet failingStateSet;
        [SerializeField]
        private string _interactionName;
        [SerializeField]
        private int _contextMenuPriority;
        [SerializeField]
        private Identifier Id;

        public int ContextMenuPriority => _contextMenuPriority;
        public string ContextActionTitle => _interactionName;
        public Transform InteractionSource => AssociatedInteractable.transform;
        public bool ShowInContextMenu => IsEffective;
        public string Name => _interactionName;
        public bool IsEffective { get; protected set; }
        protected abstract InteractableObject AssociatedInteractable { get; }

        private void Awake()
        {
            AssociatedInteractable.InternalStateChanged.AddListener(OnInteractableStateChanged);
        }

        protected virtual void Start()
        {
            GetComponentInParent<ContextMenuHandler>().Subscribe(this);
        }

        public bool Equals(Interaction other)
        {
            if (other != null)
            {
                return ReferenceEquals(this, other) || this.Id.Equals(other.Id);
            }

            return false;
        }

        public override bool Equals(object other)
        {
            var casted = other as Interaction;

            return Equals(casted);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        void IContextActionSubscriber.OnSelectedInContextMenu()
        {
            GameManager.Player.AddInteractionToPerform(this);
        }
        protected virtual void OnInteractableStateChanged(HashSet<InteractableState> interactableNewState)
        {
            IsEffective = enablingStateSet.IsFulfilled(AssociatedInteractable.CurrentState);
        }


        public abstract void Perform(EntityController interactingEntity);
    }
}
