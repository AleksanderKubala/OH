using System.Collections;
using System.Collections.Generic;
using Assets.Common;
using Assets.Data;
using Assets.Interactions;
using UnityEngine;

namespace Assets.Interactables
{
    public interface IInteractable : INamedObject, IDescribable
    {
        IInteractableObjectData InteractableData { get; } 
        HashSet<Interaction> Interactions { get; }
    }
}
