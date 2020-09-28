using System;
using System.Collections.Generic;
using OHLogic.Common;
using UnityEngine;

namespace Assets.Combat
{
    public class TargetingCombatState : CombatState, IListener
    {              
        private PursuingCombatState pursuingState;
        private DefendingCombatState defendingState;
        private float reactionTime;

        public TargetingCombatState(EntityCombatController context) : base(context)
        {
            StateContext.ReactionToIncomingAttack += OnReactionToIncomingAttack;
            StateContext.CurrentTargetUnavailable += OnCurrentTargetUnavailable;
        }

        ~TargetingCombatState()
        {
            StateContext.ReactionToIncomingAttack -= OnReactionToIncomingAttack;
            StateContext.CurrentTargetUnavailable -= OnCurrentTargetUnavailable;
        }
        public static TargetingCombatState Creator(EntityCombatController context)
        {
            return new TargetingCombatState(context);
        }

        public override void Enter()
        {
            base.Enter();
            StateContext.RegisterTickListener(this);
            reactionTime = StateContext.RaceData.NextReactionTime;
        }

        public override void Exit()
        {
            StateContext.UnregisterTickListener(this);
        }

        public void Notify()
        {
            reactionTime -= Time.deltaTime;
            if (reactionTime <= 0.0f)
            {
                StateContext.SelectNextTarget();
                if(StateContext.TargetedEnemy != null)
                {
                    StateContext.ChangeState(this, pursuingState);
                }
            }
        }

        protected override void SolveAllReachableStates()
        {
            SolveSpecificReachableState(ref pursuingState, PursuingCombatState.Creator);
            SolveSpecificReachableState(ref defendingState, DefendingCombatState.Creator);
        }

        private void OnReactionToIncomingAttack(object sender, IEnumerable<AttackAction> attacksReactedOn)
        {
            if(StateContext.CurrentState == this && StateContext.CurrentCombatStrategy.DecideToDefend(attacksReactedOn))
            {
                StateContext.PrepareDefence(attacksReactedOn);
                if (StateContext.PerformedDefence != null)
                {
                    StateContext.ChangeState(this, defendingState);
                }
            }
        }

        private void OnCurrentTargetUnavailable(object sender, EventArgs args)
        {
            if(StateContext.CurrentState == this)
            {
                reactionTime = StateContext.RaceData.NextReactionTime;
            }
        }
    }
}
