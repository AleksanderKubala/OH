using Assets.Data;
using UnityEngine;

namespace Assets.Vision
{

    [CreateAssetMenu(fileName = "VisionBodypart", menuName = "Characters/Bodyparts/Vision")]
    public class VisionData : ScriptableObject, IVisionData
    {
        [SerializeField]
        protected float maximumLeftAngle;
        [SerializeField]
        protected float maximumRightAngle;
        [SerializeField]
        protected float maximumTopAngle;
        [SerializeField]
        protected float maximumBottomAngle;
        [SerializeField]
        protected float radius;
        [SerializeField]
        protected float minimumLuminousIntensity;
        [SerializeField]
        protected float optimalLuminousIntensity;
        [SerializeField]
        protected LayerMask visionObstacles;

        public float MaximumLeftAngle => maximumLeftAngle;
        public float MaximumRightAngle => maximumRightAngle;
        public float MaximumTopAngle => maximumTopAngle;
        public float MaximumBottomAngle => maximumBottomAngle;
        public float Radius => radius;
        public float MinimumLuminousIntensity => minimumLuminousIntensity;
        public float OptimalLuminousIntensity => optimalLuminousIntensity;
        public LayerMask VisionObstacles => visionObstacles;
    }
}