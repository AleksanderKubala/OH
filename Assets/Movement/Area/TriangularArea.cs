using UnityEngine;

namespace Assets.OH.Movement
{
    [System.Serializable]
    public class TriangularArea : IAreaDefinition
    {
        #region Fields

        private Transform origin, firstAxisCorner, secondAxisCorner;

        #endregion

        #region Constructors

        public TriangularArea(Transform origin, Transform firstCorner, Transform secondCorner)
        {
            this.origin = origin;
            this.firstAxisCorner = firstCorner;
            this.secondAxisCorner = secondCorner;
        }

        #endregion

        #region Properties

        private Vector3 FirstAxis => firstAxisCorner.position - origin.position;
        private Vector3 SecondAxis => secondAxisCorner.position - origin.position;

        #endregion

        #region Methods

        public Vector3 NextPoint()
        {
            float firstAxisCoefficient = Random.value, secondAxisCoefficient = Random.value, coefficientSum = firstAxisCoefficient + secondAxisCoefficient;
            if (coefficientSum > 1.0f)
            {
                firstAxisCoefficient /= coefficientSum;
                secondAxisCoefficient /= coefficientSum;
            }
            Vector3 generatedPoint = origin.position + firstAxisCoefficient * FirstAxis + secondAxisCoefficient * SecondAxis;

            return generatedPoint;
        }

        #endregion
    }

}

