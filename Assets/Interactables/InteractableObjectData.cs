using Assets.Common;
using Assets.Data;
using UnityEngine;

namespace Assets.Interactables
{
    public class InteractableObjectData : ScriptableObject, IInteractableObjectData
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private GameObjectType _gameObjectType;
        [SerializeField]
        private string _description;

        public GameObjectType ObjectType => throw new System.NotImplementedException();
        public string Name => throw new System.NotImplementedException();
        public string GetDescription()
        {
            throw new System.NotImplementedException();
        }
    }
}
