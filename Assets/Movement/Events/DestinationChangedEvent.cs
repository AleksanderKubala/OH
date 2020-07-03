using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Movement.Events
{
    [Serializable]
    public class DestinationChangedEvent : UnityEvent<Vector3>
    {
    }
}
