using Assets.Data;
using Assets.GameEntity;
using UnityEngine;

namespace Assets.Interactables
{
    [CreateAssetMenu(fileName = "InteractableObjectData", menuName = "Interactables/Interactable Object Data")]
    public class InteractableObjectData : GameEntityIdentifier//, IInteractableObjectData
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private string _description;

        public string Name => _name;

        public string GetDescription()
        {
            return _description;
        }
    }
}
