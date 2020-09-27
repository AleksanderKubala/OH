using UnityEngine;

namespace Assets.Interactables
{
    //TODO: with current interaction design it will be cumbersome to implement AI logic in the future. Need to think of better solution
    public abstract class Openable : InteractableObjectProperty
    {
        public abstract void SetOpen();
        public abstract void SetClosed();
    }
}
