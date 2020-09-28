using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Interactables
{
    public abstract class InteractableObjectProperty : MonoBehaviour
    {
        [SerializeField]
        private Interactable _interactable;

        public Interactable AssociatedInteractable => _interactable;
    }
}
