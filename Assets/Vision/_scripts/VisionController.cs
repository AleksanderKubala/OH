using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Vision.Events;
using Assets.OH;

namespace Assets.Vision
{
    [RequireComponent(typeof(SphereCollider))]
    public class VisionController : MonoBehaviour
    {
        public VisionFieldDrawer fovRendererPrefab;
        [SerializeField]
        private SphereCollider visionSphere;
        private Dictionary<GameObject, LayerMask> objectsInVisionSphere;
        private HashSet<GameObject> objectsWithinSight;
        private Dictionary<Vision, Transform> registeredVisionFields;

        public GameObjectSpottedEvent ObjectSpotted;
        public GameObjectSightLostEvent ObjectSightLost;

        public ICollection<GameObject> ObservedObjects => objectsWithinSight.ToList();
        public IEnumerable<Vision> VisionFields => registeredVisionFields.Keys;

        void Awake()
        {
            transform.localScale = new Vector3(1.0f / transform.lossyScale.x, 1.0f / transform.lossyScale.y, 1.0f / transform.lossyScale.z);
            objectsInVisionSphere = new Dictionary<GameObject, LayerMask>();
            objectsWithinSight = new HashSet<GameObject>();
            registeredVisionFields = new Dictionary<Vision, Transform>();
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
                        ObjectSpotted?.Invoke(observed, objectsInVisionSphere[observed]);
                    }
                    if (!spotted && objectsWithinSight.Contains(observed))
                    {
                        objectsWithinSight.Remove(observed);
                        ObjectSightLost?.Invoke(observed, objectsInVisionSphere[observed]);
                    }
                }

                yield return new WaitForSeconds(0.1f);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            LayerMask mask = 2 << other.gameObject.layer; //LayerMask.GetMask(LayerMask.LayerToName(other.gameObject.layer));
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

        public void RegisterVisionField(Vision vision, Transform origin)
        {
            registeredVisionFields[vision] = origin;
            visionSphere.radius = registeredVisionFields.Keys.Max(x => x.Radius);
        }

        public bool IsWithinSight(GameObject gameObject)
        {
            return objectsWithinSight.Contains(gameObject);
        }

        private bool CanSee(GameObject target)
        {
            foreach (Vision visionField in registeredVisionFields.Keys)
            {
                var visionOrigin = registeredVisionFields[visionField];
                var fromVisionToTarget = target.transform.position - visionOrigin.position;
                var rotation = Quaternion.FromToRotation(Vector3.forward, visionOrigin.InverseTransformDirection(fromVisionToTarget));
                rotation *= visionField.FocusVectorRotation;
                float horizontalAngle = ReduceToHalfangle(rotation.eulerAngles.y);
                float verticalAngle = ReduceToHalfangle(rotation.eulerAngles.x);

                if (visionField.WithinVisionRange(horizontalAngle, verticalAngle))
                {
                    Ray ray = new Ray(visionOrigin.position, fromVisionToTarget);
                    if(visionField.CanSee(target, ray))
                    {
                        Debug.DrawRay(visionOrigin.position, fromVisionToTarget, Color.red, 0.1f);

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


