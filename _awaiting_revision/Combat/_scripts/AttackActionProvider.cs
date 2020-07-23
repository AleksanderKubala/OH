using System;
using System.Collections.Generic;
using System.Linq;
using OHLogic.Actions;
using OHLogic.Combat.Data;
using UnityEngine;

namespace Assets.Combat
{
    [Serializable]
    public class AttackActionProvider : MonoBehaviour, IActionProvider<AttackAction>
    {
        [SerializeField]
        private AttackActionDictionary attackActions;
        private ICollection<AttackAction> actions;

        public event EventHandler ActionProviderInactive;
        public event EventHandler ActionProviderActive;

        void Awake()
        {
            actions = new List<AttackAction>(attackActions.Count);
        }

        void Start()
        {
            BuildActions();
        }

        public ICollection<AttackAction> GetActions()
        {
            return actions.ToList();
        }

        private void BuildActions()
        {
            foreach (KeyValuePair<OffensiveActionData, AttackBox> actionEntry in attackActions)
            {
                actions.Add(new AttackAction(actionEntry.Key, actionEntry.Value));
            }
        }
    }
}
