using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Interactions
{
    public class InteractionSet : MonoBehaviour, IEnumerable<Interaction>
    {
        [SerializeField]
        private HashSet<Interaction> _interactions;

        private void Awake()
        {
            _interactions = new HashSet<Interaction>(GetComponents<Interaction>());
        }

        public IEnumerator<Interaction> GetEnumerator()
        {
            return _interactions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
