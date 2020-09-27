using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Interactables
{
    [CreateAssetMenu(fileName = "InteractableState", menuName = "Interactions/Interactable State")]
    [Serializable]
    public class InteractableState : ScriptableObject
    {
        [SerializeField]
        private InteractableState[] _exclusiveStates;

        public HashSet<InteractableState> ExclusiveStates => new HashSet<InteractableState>(_exclusiveStates);

    }
}
