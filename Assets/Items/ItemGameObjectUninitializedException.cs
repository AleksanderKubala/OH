using System;
using Assets.Interactions;

namespace Assets.Items
{
    public class ItemGameObjectUninitializedException : Exception
    {
        public ItemGameObjectUninitializedException(InteractiveObjectHighlight itemGameObject) : base($"Tried to retrieve item from existing and uninitialized ItemGameObject, name {itemGameObject.name}") { }
    }
}
