﻿using System.Linq;
using Asset.OnlyHuman.Characters;
using Assets.Interactables;
using UnityEngine;

namespace Assets.Interactions
{
    public class InteractionPutIntoInventory : Interaction
    {
        [SerializeField]
        private InteractablePickupable _pickupable;
        [SerializeField]
        private InteractableState _targetState;

        public override Transform InteractionSource => _pickupable.transform;
        protected override InteractableObject AssociatedInteractable => _pickupable;

        public override void Perform(EntityController interactingEntity)
        {
            var availableSpaces = interactingEntity.Inventory.GetInventorySpaces(x => x.HasEnoughSpace(_pickupable.Item));
            if(availableSpaces.Any())
            {
                //TODO: recode properly to go thorugh available spaces and select the best fitting one
                var isPlacedInInventory = availableSpaces.First().PutItemInside(_pickupable.Item);
                if(isPlacedInInventory)
                {
                    _pickupable.AddState(_targetState);
                    _pickupable.gameObject.SetActive(false);
                }
            }
        }
    }
}