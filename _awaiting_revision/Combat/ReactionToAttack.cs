using System;

namespace Assets.Combat
{
    public class ReactionToAttack
    {
        public event EventHandler<ReactionToAttack> ReactedToAttack;

        public ReactionToAttack(AttackAction attack, float reactionTimestamp)
        {
            Attack = attack;
            ReactionTimestamp = reactionTimestamp;
        }

        public float ReactionTimestamp { get; private set; }
        public AttackAction Attack { get; private set; }
        public DefenceAction Defence { get; set; }

        public void Abort()
        {
            ReactedToAttack = null;
        }

        public void Delay(float time)
        {
            ReactionTimestamp += time;
        }
    }
}
