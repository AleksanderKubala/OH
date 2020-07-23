using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Interactables
{
    [CreateAssetMenu(fileName = "State set", menuName = "Interactions/Interactable State Set")]
    public class InteractableStateSet : ScriptableObject
    {
        [SerializeField]
        private InteractableState[] statesGroup;

        public IEnumerable<InteractableState> IncludedStates => statesGroup;

        public bool ContainsState(InteractableState state)
        {
            for (int i = 0; i < statesGroup.Length; i++)
            {
                if (statesGroup[i] == state)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
