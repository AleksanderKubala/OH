﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Vision.Events
{
    [Serializable]
    public class GameObjectSightLostEvent : UnityEvent<GameObject, LayerMask>
    {
    }
}
