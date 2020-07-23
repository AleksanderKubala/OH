using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Interactables
{
    //TODO: probably at some point it will be handy to have AND/OR/NOT condition included - check if Requirement class will be applicable having the Unity Inspector in regard. It might be necessary to write custom serializer for this feature
    [CreateAssetMenu(fileName = "State set", menuName = "Interactions/Interactable State Set")]
    public class InteractableStateSet : ScriptableObject
    {
        //TODO: it might be handy to implement it using HashSet and use array oonly for initializing the instance from unity inspector
        [SerializeField]
        private InteractableState[] statesGroup;
        [SerializeField]
        private bool _shouldNotBeSubset;
        private HashSet<InteractableState> stateSet;

        public IEnumerable<InteractableState> IncludedStates => statesGroup;

        private void OnEnable()
        {
            if(stateSet == null)
            {
                stateSet = new HashSet<InteractableState>();
            }
            foreach(var state in statesGroup)
            {
                stateSet.Add(state);
            }
        }

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

        //similar to value requirement class implementation
        public bool IsFulfilled(IEnumerable<InteractableState> multistate)
        {
            var multistateFulfillsStateSet = stateSet.IsSubsetOf(multistate) ^ _shouldNotBeSubset;

            return multistateFulfillsStateSet;
        }
    }
}
