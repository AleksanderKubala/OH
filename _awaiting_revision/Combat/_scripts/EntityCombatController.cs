using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityRandom = UnityEngine.Random;
using OHLogic.Combat.Data;
using System;
using OHLogic.Actions.Data;
using OHLogic.Body;
using OHLogic.Movement;
using OHLogic.Common;
using Asset.OnlyHuman.Characters;
using OHLogic.Actions;

namespace Assets.Combat
{
    public class EntityCombatController : ContextualTickNotifierBehaviour
    {
        [SerializeField]
        private EntityMovementController movement;
        [SerializeField]
        private AttackDetection attackDetection;
        [SerializeField]
        private EnemyDetection enemyDetection;
        [SerializeField]
        private SphereCollider combatRange;
        [SerializeField]
        private RacialData raceData;
        [SerializeField]
        private CharacterBody body;
        private ISet<AttackAction> registeredAttacks;
        private ISet<DefenceAction> registeredDefences;
        private AttackAction performedAttack;

        public event EventHandler<IEnumerable<AttackAction>> ReactionToIncomingAttack;
        public event EventHandler CurrentTargetWithinRange;
        public event EventHandler CurrentTargetOutsideRange;
        public event EventHandler CurrentTargetUnavailable;

        public ICombatStrategy CurrentCombatStrategy { get; private set; }
        public ICharacterBody Body => body;
        public RacialData RaceData => raceData; 
        public EntityCombatController TargetedEnemy { get; private set; }
        public IBodypart CurrentTarget => PerformedAttack?.Target;
        public EnemyDetection EnemyDetection => enemyDetection;
        public AttackDetection AttackDetection => attackDetection;
        public AttackAction PerformedAttack
        {
            get
            {
                return performedAttack;
            }
            private set
            {
                if(value == null)
                {
                    combatRange.radius = 0.0f;
                }
                else
                {
                    combatRange.radius = value.ActionData.ActionRange;
                }
                performedAttack = value;
            }
        }
        public DefenceAction PerformedDefence { get; private set; }
        public bool IsTargetWithinRange => combatRange.bounds.Contains(CurrentTarget.Position);

        protected override void Awake()
        {
            base.Awake();
            registeredAttacks = new HashSet<AttackAction>();
            registeredDefences = new HashSet<DefenceAction>();
            CurrentCombatStrategy = new SimpleCombatStrategy(this);
        }

        void OnEnable()
        {
            combatRange.enabled = true;
            SetState(GetState<TargetingCombatState>());
        }

        void Start()
        {
        }

        protected override void Update()
        {
            base.Update();
        }

        void OnDisable()
        {
            combatRange.enabled = false;
        }

        void OnTriggerEnter(Collider other)
        {
            if(ReferenceEquals(other.gameObject, CurrentTarget?.GameObjectReference))
            {
                CurrentTargetWithinRange?.Invoke(this, EventArgs.Empty);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (ReferenceEquals(other.gameObject, CurrentTarget?.GameObjectReference))
            {
                CurrentTargetOutsideRange?.Invoke(this, EventArgs.Empty);
            }
        }

        public void SelectNextTarget()
        {
            if (TargetedEnemy == null)
            {
                //Probably will be replaced with combat strategy call
                TargetedEnemy = EnemyDetection.GetNearestEnemy();
            }
        }

        public void SelectPerformedAttack()
        {
            if (TargetedEnemy != null && registeredAttacks.Any())
            {
                PerformedAttack = CurrentCombatStrategy.SelectAttack(TargetedEnemy, registeredAttacks.Where(x => x.IsAvailable));
            }
        }

        public void ClearTarget()
        {
            TargetedEnemy = null;
        }

        public void ClearPerformedAttack()
        {
            PerformedAttack = null;
        }

        public void PursueTargetedEnemy()
        {
            movement.ChangeMovementStrategy(new ActiveFollowMovementStrategy(TargetedEnemy.transform));
        }

        public void StopPursuing()
        {
            movement.SwapMovementStrategy(new ActiveFollowMovementStrategy(transform));
        }

        public void PrepareDefence(IEnumerable<AttackAction> attacksToDefend)
        {
            if(registeredDefences.Any())
            {
                PerformedDefence = CurrentCombatStrategy.PrepareDefence(attacksToDefend, registeredDefences.Where(x => x.IsAvailable));
            }
        }

        public override void RegisterTickListener(IListener listener, float tickInterval)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeStateMachine()
        {
            RegisterState(new TargetingCombatState(this));
            RegisterState(new PursuingCombatState(this));
            RegisterState(new AttackingCombatState(this));
            RegisterState(new DefendingCombatState(this));
        }

        public void OnAttackActionGained(AttackActionProvider provider)
        {
            foreach(var attack in provider.GetActions())
            {
                registeredAttacks.Add(attack);
            }
        }

        public void OnDefenceActionGained(DefenceActionProvider provider)
        {
            foreach(var defence in provider.GetActions())
            {
                registeredDefences.Add(defence);
            }   
        }

        public void OnReactedToAttacks(List<AttackAction> attacksReactedOn)
        {
            ReactionToIncomingAttack?.Invoke(this, attacksReactedOn);
        }
    }
}

