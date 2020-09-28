using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Interactions;
using Assets.UI.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    public class UIInventoryInteractionButton : MonoBehaviour, IComparable<UIInventoryInteractionButton>
    {
        [SerializeField]
        private Text _label;
        private Interaction _interaction;
        private int interactablesSupportingInteraction;
        private int interactablesWithEffectiveInteraction;

        [HideInInspector]
        public InventoryInteractionSelectedEvent InteractionSelected;

        public Interaction Interaction
        {
            get
            {
                return _interaction;
            }
            set
            {
                _interaction = value;
                interactablesSupportingInteraction = 0;
                interactablesWithEffectiveInteraction = 0;
                SetLabel();
            }
        }

        public bool InteractionIsSupported => _interaction != null && interactablesSupportingInteraction > 0;

        private void Awake()
        {
            Interaction = _interaction;
            UpdateGameObjectActiveFlag();
        }

        public void OnInteractionButtonClicked()
        {
            InteractionSelected?.Invoke(new InventoryInteractionSelectedEventArgs() {
                Interaction = _interaction 
                }); 
        }

        public void SupportInteraction(IEnumerable<Interaction> interactions)
        {
            if (interactions.Contains(_interaction))
            {
                interactablesSupportingInteraction++;
                var concreteInteraction = interactions.Where(x => x.Equals(_interaction)).FirstOrDefault();
                if (concreteInteraction.IsEffective)
                {
                    interactablesWithEffectiveInteraction++;
                }
                UpdateGameObjectActiveFlag();
            }
        }

        public void WithdrawInteractionSupport(IEnumerable<Interaction> interactions)
        {
            if(interactions.Contains(_interaction))
            {
                if(interactablesSupportingInteraction > 0)
                {
                    interactablesSupportingInteraction --;
                }
                if(interactablesWithEffectiveInteraction > 0)
                {
                    interactablesWithEffectiveInteraction--;
                }
                if(interactablesSupportingInteraction <= 0)
                {
                    Interaction = null;
                }
                UpdateGameObjectActiveFlag();
            }
        }

        private void UpdateGameObjectActiveFlag()
        {
            if(_interaction != null && interactablesWithEffectiveInteraction > 0)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        private void SetLabel()
        {
            if (_interaction != null)
            {
                _label.text = _interaction.Name ?? "null";
            }
        }

        public int CompareTo(UIInventoryInteractionButton other)
        {
            if (other != null && other.Interaction != null && this.Interaction != null)
            {
                return Interaction.Name.CompareTo(other.Interaction.Name);
            }
            else if (this.Interaction != null && other.Interaction == null)
            {
                return -1;
            }
            else if (this.Interaction == null && other.Interaction != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }            
        }
    }
}
