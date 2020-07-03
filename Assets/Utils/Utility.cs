using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

namespace Assets.OH.Utils
{
    public static class Utility
    {
        #region Fields

        private static readonly System.Random systemRandom;

        #endregion

        #region Constructors

        static Utility()
        {
            systemRandom = new System.Random();
        }

        #endregion

        #region Methods

        public static float RandomGaussian(float mean, float standardDeviation)
        {
            if (standardDeviation < 0)
            {
                throw new ArgumentException("standard deviation cannot be negative");
            }

            Vector2 uniform = UnityEngine.Random.insideUnitCircle;
            float s = uniform.sqrMagnitude;
            float gaussianValue = mean + (standardDeviation * (uniform[0] * Mathf.Sqrt(-2.0f * Mathf.Log(s) / s)));

            return gaussianValue;
        }

        public static T SelectRandomlyFromEnumerable<T>(IEnumerable<T> enumerable) where T : class
        {
            T selected = null;
            if(enumerable.Any())
            {
                var index = systemRandom.Next(enumerable.Count());
                selected = enumerable.ElementAt(index);
            }

            return selected;
        }

        public static bool SelectRandomlyFromEnumerable<T>(IEnumerable<T> enumerable, out T? value) where T : struct
        {
            value = null;
            if(enumerable.Any())
            {
                var index = systemRandom.Next(enumerable.Count());
                value = enumerable.ElementAt(index);

                return true;
            }

            return false;
        }

        public static int RandomIntZeroInMaxOut(int maximum)
        {
            return systemRandom.Next(maximum);
        }

        public static int RandomIntWithinInRangeMaxOut(int minimum, int maximum)
        {
            return systemRandom.Next(minimum, maximum);
        }

        public static int RandomIntZeroInMaxIn(int maximum)
        {
            return systemRandom.Next(maximum + 1);
        }

        public static int RandomIntWithinRange(int minimum, int maximum)
        {
            return systemRandom.Next(minimum, maximum + 1);
        }

        public static float RandomNormalFloat()
        {
            return UnityEngine.Random.value;
        }

        public static float RandomFloatWithinRange(float minimum, float maximum)
        {
            return UnityEngine.Random.Range(minimum, maximum);
        }

        public static Vector2 RandomVectorInUnitCircle()
        {
            return UnityEngine.Random.insideUnitCircle;
        }

        public static Vector2 RandomNormal2DVector()
        {
            return UnityEngine.Random.insideUnitCircle.normalized;
        }

        public static Vector3 RandomVectorInUnitySphere()
        {
            return UnityEngine.Random.insideUnitSphere;
        }

        public static Vector3 RandomNormal3DVector()
        {
            return UnityEngine.Random.onUnitSphere;
        }

        public static bool RollUniform(float trueProbability)
        {
            return UnityEngine.Random.value <= trueProbability;
        }

        #endregion
    }
}
