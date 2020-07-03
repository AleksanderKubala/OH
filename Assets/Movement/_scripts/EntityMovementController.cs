using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.OH.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EntityMovementController : MonoBehaviour
    {
        public const float StandardDistance = 0.52f;

        [SerializeField]
        protected NavMeshAgent navAgent;

        public float StoppingDistance
        {
            set => navAgent.stoppingDistance = value;
            get => navAgent.stoppingDistance;
        }

        protected void Awake()
        {
        }

        private void Start()
        {
        }

        protected void Update()
        {
        }

        public void TurnTowards(GameObject gameObject)
        {
            TurnTowards(gameObject.transform.position);
        }

        public void TurnTowards(Vector3 point)
        {
            StartCoroutine(TurnTowardsCoroutine(point));
        }

        public void LookAt(GameObject gameObject)
        {

        }

        private IEnumerator TurnTowardsCoroutine(Vector3 point)
        {
            float previousStoppingDistance = navAgent.stoppingDistance;
            navAgent.updatePosition = false;
            navAgent.stoppingDistance = 0.0f;

            point.y = transform.position.y;
            Vector3 direction = point - transform.position;

            navAgent.SetDestination(point);
            yield return new WaitUntil(() => Vector3.Angle(transform.forward, direction) < 2.0f);
            navAgent.ResetPath();

            navAgent.Warp(transform.position);
            navAgent.updatePosition = true;
            navAgent.stoppingDistance = previousStoppingDistance;
        }

        public void OnDestinationChanged(Vector3 newDestination)
        {
            navAgent.SetDestination(newDestination);
        }
    }
}


