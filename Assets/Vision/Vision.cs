using OHLogic.Data;
using OHLogic.Vision;
using UnityEngine;

namespace Assets.OH.Vision
{
    public class Vision : VisionField, IVision
    {
        public Vision(Quaternion rotationFromGameObjectForwardAxis, LayerMask visionObstacles, IVisionData visionData) : base(visionData)
        {
            FocusVectorRotation = rotationFromGameObjectForwardAxis;
            VisionObstacles = visionObstacles;
        }

        public Quaternion FocusVectorRotation { get; protected set; }
        public LayerMask VisionObstacles { get; protected set; }

        public bool CanSee(GameObject target, Ray ray)
        {
            var raycastHasHit = Physics.Raycast(ray, out RaycastHit hit, VisionData.Radius, VisionObstacles, QueryTriggerInteraction.Collide);
            if (raycastHasHit && hit.collider.gameObject == target)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
