using UnityEngine;
using OHLogic.Character.Statistics;
using OHLogic.Factions;
using OHLogic.Body;
using OHLogic.Movement;
using OHLogic.Vision;
using OHLogic.Combat;

namespace Asset.OnlyHuman.Characters
{
    public class EntityController : MonoBehaviour
    {
        [SerializeField]
        protected EntityMovementController movementController;
        [SerializeField]
        protected EntityCombatController combatController;
        [SerializeField]
        protected GameEntityBody body;

        public IGameEntityBody CharacterBody => body;
        public EntityCombatController Combat => combatController;
        public EntityMovementController Movement => movementController;

        void Start()
        {
            CharacterBody.RegisterBodypart(GetComponentsInChildren<IBodypart>());
        }
    }
}

