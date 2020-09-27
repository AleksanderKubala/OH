using System;
using System.Collections.Generic;
using System.Linq;
using Asset.OnlyHuman.Characters;
using Assets.Common;
using Assets.GameEntity;
using Assets.Interactables;
using Assets.Managers;
using Assets.UI;
using UnityEngine;

namespace Assets.Interactions
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of better solution
    [Serializable]
    public abstract class Interaction : MonoBehaviour, IInteraction, INamedEntity, IContextActionSubscriber, IEquatable<Interaction>
    {
        [SerializeField]
        private string _interactionName;
        [SerializeField]
        private int _contextMenuPriority;
        [SerializeField]
        private Identifier Id;
        [SerializeField]
        private List<GameEntityIdentifier> _expects;

        public int ContextMenuPriority => _contextMenuPriority;
        public string ContextActionTitle => _interactionName;
        public bool ShowInContextMenu => IsEffective;
        public string Name => _interactionName;
        public bool IsEffective { get; protected set; }
        protected abstract Interactable AssociatedInteractable { get; }

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
            var interactionAttempt = GetInteractionAttempt();
            interactionAttempt.InteractingEntity = GameManager.Player;
            GameManager.Player.AddActionToPerform(interactionAttempt);
        }

        public IInteractionAttempt GetInteractionAttempt()
        {
            IInteractionAttempt attempt;

            if(_expects.Any())
            {
                attempt = new InteractionAttempt(this, _expects.Select(x => new InteractionAttemptArgument(x.GameEntityType)).ToList());
            }
            else
            {
                attempt = new InteractionAttempt(this);
            }

            return attempt;
        }

        protected bool AreArgumentsCorrect(List<InteractionAttemptArgument> arguments)
        {
            bool argumentsCorrect = true;
            var expectedArguments = _expects.GetEnumerator();

            while(argumentsCorrect && expectedArguments.MoveNext())
            {
                bool matched = false;
                var providedArguments = arguments.GetEnumerator();

                while(!matched && providedArguments.MoveNext())
                {
                    if(expectedArguments.Current.Equals(providedArguments.Current))
                    {
                        matched = true;
                    }
                }
                argumentsCorrect &= matched;
            }

            return argumentsCorrect;
        }

        public abstract Transform GetInteractionSource();
        public abstract void Attempt(EntityController interactingEntity, List<InteractionAttemptArgument> arguments);
        protected abstract void OnInteractableStateChanged();
    }
}
