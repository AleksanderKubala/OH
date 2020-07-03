using System;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

namespace OHLogic.Combat
{
    [Serializable]
    public class Hitbox : CombatBox
    {
        void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer == CommonValue.Layers.Attack)
            {
                AttackBox attackBox = other.gameObject.GetComponent<AttackBox>();
                if(attackBox && ReferenceEquals(attackBox.Attack.Target, damageableObject))
                {
                    attackBox.Ineffective();
                    damageableObject.ReceiveDamage(UnityRandom.value * 3.0f);
                }
            }
        }
    }
}
