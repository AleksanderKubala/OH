using System.Collections.Generic;
using System.Linq;
using Asset.OnlyHuman.Characters;
using OHLogic.Combat.Events;
using OHLogic.Factions;
using OHLogic.Vision;
using UnityEngine;

namespace OHLogic.Combat
{
    public class EnemyDetection : MonoBehaviour
    {
        [SerializeField]
        private Sight vision;
        [SerializeField]
        private CharacterFaction faction;
        private ISet<EntityCombatController> enemiesWithinSight;
        private ISet<EntityCombatController> engagedEnemies;

        public EnemySpotted EnemySpottedEvent;
        public EnemySightLost EnemySightLostEvent;

        public int EnemiesCount => enemiesWithinSight.Count + engagedEnemies.Count;
        public bool AreEnemiesInVicinity => EnemiesCount > 0;

        private void Awake()
        {
            enemiesWithinSight = new HashSet<EntityCombatController>();
            engagedEnemies = new HashSet<EntityCombatController>();
            faction.FactionAttitudeChanged += OnFactionAttitudeChanged;
            enabled = false;
        }

        private void Update()
        {
            LookForEngagingEnemies();
        }

        public void OnGameObjectSpotted(GameObject gameObject, LayerMask mask)
        {
            if((mask & CommonValue.LayerMasks.Entity) != 0 && CheckIfEnemy(gameObject, out EntityCombatController enemy))
            {
                RegisterEnemy(enemy);
            }
        }

        public void OnGameObjectSightLost(GameObject gameObject, LayerMask mask)
        {
            if ((mask & CommonValue.LayerMasks.Entity) != 0 && CheckIfEnemy(gameObject, out EntityCombatController enemy))
            {
                UnregisterEnemy(enemy);
            }
        }

        public EntityCombatController GetNearestEnemy()
        {
            ISet<EntityCombatController> enemiesToChooseFrom = engagedEnemies.Count > 0 ? engagedEnemies : enemiesWithinSight;
            EntityCombatController chosenEnemy =  (from enemy in enemiesToChooseFrom
                                                   orderby (enemy.transform.position - transform.position).sqrMagnitude descending
                                                   select enemy).FirstOrDefault();

            return chosenEnemy;
        }

        private bool CheckIfEnemy(GameObject checkedObject, out EntityCombatController combatController)
        {
            var otherFaction = checkedObject.GetComponent<IFaction>();
            combatController = checkedObject.GetComponent<EntityController>().Combat;

            if (otherFaction != null && faction.AttitudeTowards(otherFaction) == RelationAttitude.Enemy)
            {
                return true;
            }

            return false;
        }

        private void OnFactionAttitudeChanged(object sender, IFaction faction)
        {
            ICollection<GameObject> observedObjects = vision.ObservedObjects;
            foreach (GameObject observedObject in observedObjects)
            {
                if (CheckIfEnemy(observedObject, out EntityCombatController enemy))
                {
                    RegisterEnemy(enemy);
                }
                else
                {
                    UnregisterEnemy(enemy);
                }
            }
        }

        private void LookForEngagingEnemies()
        {
            var enemiesTargetingMe = from enemy in enemiesWithinSight
                                     where enemy.TargetedEnemy == this
                                     select enemy;
            engagedEnemies.UnionWith(enemiesTargetingMe);
        }

        private void RegisterEnemy(EntityCombatController enemy)
        {
            enemiesWithinSight.Add(enemy);
            EnemySpottedEvent?.Invoke(enemy);

            enabled = true;
        }

        private void UnregisterEnemy(EntityCombatController enemy)
        {
            enemiesWithinSight.Remove(enemy);
            engagedEnemies.Remove(enemy);
            EnemySightLostEvent?.Invoke(enemy);

            if(!AreEnemiesInVicinity)
            {
                enabled = false;
            }
        }
    }
}
