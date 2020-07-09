using Assets.Interactions.Events;
using UnityEngine;

namespace Assets.Interactions
{
    public abstract class InteractableObject : MonoBehaviour
    {
        protected abstract void UpdateInteractions();
    }
}
