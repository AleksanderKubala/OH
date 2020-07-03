using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OHLogic.Body;
using OHLogic.Vision.Events;

namespace OHLogic.Vision
{

    public class Sight
    {
        private IDictionary<GameObject, LayerMask> objectsInVisionSphere;
        private ISet<GameObject> objectsWithinSight;
        private Dictionary<Eye, FieldOfVisionRenderer> attachedEyes;

        public GameObjectSpotted ObjectSpottedEvent;
        public GameObjectSightLost ObjectSightLostEvent;

        public ICollection<GameObject> ObservedObjects => objectsWithinSight.ToList();

        void Awake()
        {
            transform.localScale = new Vector3(1.0f / transform.lossyScale.x, 1.0f / transform.lossyScale.y, 1.0f / transform.lossyScale.z);
            objectsInVisionSphere = new Dictionary<GameObject, LayerMask>();
            objectsWithinSight = new HashSet<GameObject>();
            attachedEyes = new Dictionary<Eye, FieldOfVisionRenderer>();
        }

        void Start()
        {
            StartCoroutine(Detect());
        }

        IEnumerator Detect()
        {
            while (true)
            {
                foreach (GameObject observed in objectsInVisionSphere.Keys)
                {
                    bool spotted = CanSee(observed);
                    if (spotted && !objectsWithinSight.Contains(observed))
                    {
                        objectsWithinSight.Add(observed);
                        ObjectSpottedEvent?.Invoke(observed, objectsInVisionSphere[observed]);
                    }
                    if (!spotted && objectsWithinSight.Contains(observed))
                    {
                        objectsWithinSight.Remove(observed);
                        ObjectSightLostEvent?.Invoke(observed, objectsInVisionSphere[observed]);
                    }
                }

                yield return new WaitForSeconds(0.1f);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            LayerMask mask = LayerMask.GetMask(LayerMask.LayerToName(other.gameObject.layer));
            if((mask & CommonValue.LayerMasks.VisionLayersOfInterest) != 0)
            {
                GameObject rootObject = other.transform.root.gameObject;
                if (!objectsInVisionSphere.Keys.Contains(other.gameObject) && !transform.IsChildOf(rootObject.transform))
                {
                    objectsInVisionSphere[other.gameObject] = mask;
                }
            }
        }

        void OnTriggerExit(Collider other)
        {
            objectsInVisionSphere.Remove(other.gameObject);
        }

        public void RegisterEye(Eye eye)
        {
            FieldOfVisionRenderer fov = Instantiate(fovRendererPrefab, transform.position, Quaternion.FromToRotation(Vector3.forward, eye.VisionForward), transform);
            fov.eye = eye;
            attachedEyes[eye] = fov;
            float maxRadius = attachedEyes.Keys.Max(x => x.Radius);
            visionSphere.radius = maxRadius;
        }

        public bool IsWithinSight(GameObject gameObject)
        {
            return objectsWithinSight.Contains(gameObject);
        }

        private bool CanSee(GameObject other)
        {
            Vector3 fromTo = other.transform.position - transform.position;
            foreach (Eye eye in attachedEyes.Keys)
            {
                Quaternion rotation = Quaternion.FromToRotation(transform.InverseTransformDirection(eye.transform.forward), transform.InverseTransformDirection(fromTo));
                float horizontalAngle = ReduceToHalfangle(rotation.eulerAngles.y);
                float verticalAngle = ReduceToHalfangle(rotation.eulerAngles.x);
                if (eye.WithinVisionRange(horizontalAngle, verticalAngle))
                {
                    Ray ray = new Ray(transform.position, fromTo);
                    if (Physics.Raycast(ray, out RaycastHit hit, eye.Radius, eye.VisionObstacles, QueryTriggerInteraction.Collide) 
                        && hit.collider.gameObject == other)
                    {
                        Debug.DrawRay(transform.position, fromTo, Color.red, 0.1f);

                        return true;
                    }
                }
            }
            return false;
        }

        private float ReduceToHalfangle(float angle)
        {
            return angle > 180.0f ? 360.0f - angle : angle;
        }
    }
}


