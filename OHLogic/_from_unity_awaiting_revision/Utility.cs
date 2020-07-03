using System;
using System.Collections.Generic;
using System.Linq;

namespace OHLogic.Utils
{
    public static partial class Utility
    {
        private static readonly Random systemRandom;

        static Utility()
        {
            systemRandom = new Random();
        }

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

        public static bool RollUniform(float trueProbability)
        {
            return UnityEngine.Random.value <= trueProbability;
        }
    }
}
