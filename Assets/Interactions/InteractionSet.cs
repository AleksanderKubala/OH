using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Interactions
{
    public class InteractionSet : MonoBehaviour
    {
        [SerializeField]
        private HashSet<Interaction> _interactions;

        private void Awake()
        {
            _interactions = new HashSet<Interaction>(GetComponents<Interaction>());
        }


    }
}
