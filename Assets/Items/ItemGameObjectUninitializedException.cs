using Assets.Common;
using Assets.Interactions;
using Boo.Lang.Runtime;

namespace Assets.Items
{
    public class ItemGameObjectUninitializedException : RuntimeException
    {
        public ItemGameObjectUninitializedException(InteractableObject itemGameObject) : base($"Tried to retrieve item from existing and uninitialized ItemGameObject, name {itemGameObject.name}") { }
    }
}
