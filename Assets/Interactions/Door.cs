using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset.OnlyHuman.Characters;
using Assets.Managers;
using Assets.UI;
using UnityEngine;

namespace Assets.Interactions
{
    public class Door : InteractableObject, IInteractableOpenable, IInteractableCloseable
    {
        [SerializeField]
        private GameObject _hinge;
        [SerializeField]
        private bool _isOpen;

        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            private set
            {
                if(value)
                {
                    DefaultInteraction = Close;
                }
                else
                {
                    DefaultInteraction = Open;
                }
                _isOpen = value;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            IsOpen = _isOpen;
        }

        public void Close(EntityController interactingEntity)
        {
            var interaction = new Interaction(gameObject);
            interaction.InteractionPerformed = OnInteractedClose;
            GameManager.Player.AddInteractionToPerform(interaction);
        }

        public void Open(EntityController interactingEntity)
        {
            var interaction = new Interaction(gameObject);
            interaction.InteractionPerformed = OnInteractedOpen;
            GameManager.Player.AddInteractionToPerform(interaction);
        }

        private void OnInteractedOpen()
        {
            if(!IsOpen)
            {
                _hinge.transform.rotation *= Quaternion.Euler(0.0f, 90.0f, 0.0f);
                IsOpen = true;
            }
        }

        private void OnInteractedClose()
        {
            if(IsOpen)
            {
                _hinge.transform.rotation *= Quaternion.Euler(0.0f, 90.0f, 0.0f);
                IsOpen = false;
            }
        }

        protected override IEnumerable<ContextActionSubscription> EnumerateInteractions()
        {
            var interactions = new LinkedList<ContextActionSubscription>();
            
            if(IsOpen)
            {
                interactions.AddLast(new ContextInteractionSubscription(Close, "Close"));
            }
            else
            {
                interactions.AddLast(new ContextInteractionSubscription(Open, "Open"));
            }

            return interactions;
        }
    }
}
