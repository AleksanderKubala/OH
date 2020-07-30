using System.Collections.Generic;
using System.Linq;
using Assets.Interactions;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    public class UIInventoryInteractionButton : MonoBehaviour
    {
        [SerializeField]
        private Text _label;
        private Interaction _interaction;
        private int interactablesSupportingInteraction;
        private int interactablesWithEffectiveInteraction;

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
                if (_interaction == null)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        private void Awake()
        {
            Interaction = _interaction;
        }

        public bool SupportInteraction(HashSet<Interaction> interactions)
        {
            var concreteInteraction = interactions.Where(x => x.Equals(_interaction)).FirstOrDefault();
            if (concreteInteraction != null)
            {
                interactablesSupportingInteraction++;
                if (concreteInteraction.IsEffective)
                {
                    interactablesWithEffectiveInteraction++;
                }
                UpdateUIElement();

                return true;
            }

            return false;
        }

        public bool WithdrawInteractionSupport(HashSet<Interaction> interactions)
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
                if(interactablesSupportingInteraction == 0)
                {
                    Interaction = null;
                }
                UpdateUIElement();

                return true;
            }

            return false;
        }

        private void UpdateUIElement()
        {
            if(interactablesWithEffectiveInteraction > 0 && interactablesWithEffectiveInteraction == interactablesSupportingInteraction)
            {
                if (!gameObject.activeSelf)
                {
                    gameObject.SetActive(true);
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
