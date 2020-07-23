using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Combat.Events;
using OHLogic.Combat.Events;
using UnityEngine;

namespace Assets.Combat
{
    public class AttackDetection : MonoBehaviour
    {

        [SerializeField]
        private EntityCombatController entityCombatController;
        [SerializeField]
        private AttackSpotted AttackSpottedEvent;
        [SerializeField]
        private AttackSightLost AttackSightLostEvent;
        [SerializeField]
        private ReactedToAttacks ReactedToAttacksEvent;
        private Dictionary<AttackAction, float> incomingAttacks;
        private float reactionTime;

        public bool IsUnderAttack => incomingAttacks.Any();

        private void Awake()
        {
            incomingAttacks = new Dictionary<AttackAction, float>();
            enabled = false;
        }

        private void OnEnable()
        {
            reactionTime = reactionTime = entityCombatController.RaceData.NextReactionTime;
        }

        private void Update()
        {
            reactionTime -= Time.deltaTime;
            if (reactionTime <= 0.0f)
            {
                var attacksReactedOn = GetAttacksReactedOn();
                if(attacksReactedOn.Any())
                {
                    ReactedToAttacksEvent?.Invoke(attacksReactedOn);
                }
            }
        }

        public void OnGameObjectSpotted(GameObject gameObject, LayerMask mask)
        {
            if((mask & CommonValue.LayerMasks.Attack) != 0 && IsAttackAgainstMe(gameObject, out AttackAction attack))
            {
                RegisterAttack(attack);
            }
        }

        public void OnGameObjectSightLost(GameObject gameObject, LayerMask mask)
        {
            if((mask & CommonValue.LayerMasks.Attack) != 0 && IsAttackAgainstMe(gameObject, out AttackAction attack))
            {
                UnregisterAttack(attack);
            }
        }

        private bool IsAttackAgainstMe(GameObject gameObject, out AttackAction attack)
        {
            AttackBox attackBox = gameObject.GetComponent<AttackBox>();
            if (attackBox && attackBox.Attack.SourceEntity.TargetedEnemy == entityCombatController)
            {
                attack = attackBox.Attack;
                return true;
            }

            attack = null;
            return false;
        }

        private List<AttackAction> GetAttacksReactedOn()
        {
            var attacksReactedOn = incomingAttacks.Where(x => x.Value < Time.time).Select(x => x.Key).ToList();

            return attacksReactedOn;
        }

        private void RegisterAttack(AttackAction attack)
        {
            incomingAttacks[attack] = Time.time;
            AttackSpottedEvent?.Invoke(attack);

            enabled = true;
        }

        private void UnregisterAttack(AttackAction attack)
        {
            incomingAttacks.Remove(attack);

            AttackSightLostEvent?.Invoke(attack);

            if(!incomingAttacks.Any())
            {
                enabled = false;
            }
        }
    }
}
