using UnityEngine;
using Assets.OH.Movement;
using OHLogic.GameEntity;
using OHLogic.Body;
using OHLogic.Inventory;
using System.Collections.Generic;
using Assets.Common;
using Assets.Movement;
using System;
using OHLogic.Items;

namespace Asset.OnlyHuman.Characters
{
    public class EntityController : MonoBehaviour, IGameEntity
    {
        [SerializeField]
        protected EntityMovementController _movementController;

        [SerializeField]
        protected DestinationFlag _destinationFlag;
        protected LinkedList<IInteraction> _interactionQueue;


        public IGameEntityStatistics Statistics => throw new NotImplementedException();

        public IGameEntityBody Body => throw new NotImplementedException();

        public IInventory Inventory => throw new NotImplementedException();

        public DestinationFlag DestinationFlag => _destinationFlag;

        private void Awake()
        {
            _interactionQueue = new LinkedList<IInteraction>();
        }

        private void Start()
        {
        }

        private void Update()
        {
            
        }

        public void AddInteractionToPerform(IInteraction interactionToPerform)
        {
            _interactionQueue.AddLast(interactionToPerform);
        }

        public void CancelInteraction(IInteraction interaction)
        {
            _interactionQueue.Remove(interaction);
        }

        public void SetDestinationFlag(Vector3 worldSpaceDestination)
        {
            SetDestinationFlag(null, worldSpaceDestination, EntityMovementController.StandardDistance);
        }

        public void SetDestinationFlag(Vector3 worldSpaceDestination, float allowedDistanceFromDestination)
        {
            SetDestinationFlag(null, worldSpaceDestination, allowedDistanceFromDestination);
        }

        public void SetDestinationFlag(Transform parent)
        {
            SetDestinationFlag(parent, Vector3.zero, EntityMovementController.StandardDistance);
        }

        public void SetDestinationFlag(Transform parent, float allowedDistanceFromDestination)
        {
            SetDestinationFlag(parent, Vector3.zero, allowedDistanceFromDestination);
        }

        public void SetDestinationFlag(Transform parent, Vector3 relativePosition, float allowedDistanceFromDestination)
        {
            _destinationFlag.Set(parent, relativePosition);
            _movementController.StoppingDistance = allowedDistanceFromDestination;
        }

        public void ClearDestinationFlag()
        {
            SetDestinationFlag(null, transform.position, EntityMovementController.StandardDistance);
        }

        public IGameEntityGenericAttribute<T> GetAttribute<T>(GameEntityGenericAttributeType<T> attributeType) where T : struct, IComparable<T>, IEquatable<T>
        {
            throw new NotImplementedException();
        }

        public bool Equip(IItem item)
        {
            throw new NotImplementedException();
        }

        public bool Unequip(IItem item)
        {
            throw new NotImplementedException();
        }

        public bool PutToInventory(IItem item)
        {
            throw new NotImplementedException();
        }

        public bool Drop(IItem item)
        {
            throw new NotImplementedException();
        }
    }
}

