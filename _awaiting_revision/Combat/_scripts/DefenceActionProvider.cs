using System;
using System.Collections.Generic;
using System.Linq;
using OHLogic.Actions;
using OHLogic.Combat.Data;
using UnityEngine;

namespace Assets.Combat
{
    public class DefenceActionProvider : MonoBehaviour, IActionProvider<DefenceAction>
    {
        [SerializeField]
        private List<DefensiveActionData> defences;
        private ICollection<DefenceAction> actions;
        public event EventHandler ActionProviderInactive;
        public event EventHandler ActionProviderActive;

        void Awake()
        {
            actions = new List<DefenceAction>(defences.Count);
        }

        void Start()
        {
            foreach(DefensiveActionData data in defences)
            {
                actions.Add(new DefenceAction(data));
            }
        }

        public ICollection<DefenceAction> GetActions()
        {
            return actions.ToList();
        }
    }
}
