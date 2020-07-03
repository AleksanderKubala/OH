using OHLogic.Common;
using UnityEngine;

namespace OHLogic.Combat
{
    public class CombatBox : MonoBehaviour
    {
        [SerializeField]
        protected Collider hitbox;
        [SerializeField]
        protected DamageableObject damageableObject;

        public virtual void Ineffective()
        {
            hitbox.enabled = false;
        }

        public virtual void Effective()
        {
            hitbox.enabled = true;
        }
    }
}
