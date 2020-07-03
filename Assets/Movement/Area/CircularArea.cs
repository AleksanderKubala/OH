using UnityEngine;

namespace Assets.OH.Movement
{
    public class CircularArea : IAreaDefinition
    {
        #region Fields

        private Transform center;
        [Range(0.0f, float.MaxValue)]
        private float externalRadius, internalRadius;

        #endregion

        #region Constructors

        public CircularArea(Transform center, float externalRadius, float internalRadius = 0.0f)
        {
            this.center = center;
            this.externalRadius = externalRadius;
            this.internalRadius = internalRadius;
        }

        #endregion

        #region Methods

        public Vector3 NextPoint()
        {
            float angle = UnityEngine.Random.value * 360.0f;
            float distance = UnityEngine.Random.Range(internalRadius, externalRadius);

            return center.position + (Quaternion.Euler(0.0f, angle, 0.0f) * Vector3.forward * distance);
        }

        #endregion
    }
}

