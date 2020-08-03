using System.Runtime.Remoting.Messaging;
using Assets.Common;
using Assets.Data;
using UnityEngine;

namespace Assets.Interactables
{
    [CreateAssetMenu(fileName = "InteractableObjectData", menuName = "Interactables/Interactable Object Data")]
    public class InteractableObjectData : ScriptableObject, IInteractableObjectData
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private GameObjectType _gameObjectType;
        [SerializeField]
        private string _description;

        public GameObjectType ObjectType => _gameObjectType;
        public string Name => _name;
        public string GetDescription()
        {
            return _description;
        }
    }
}
