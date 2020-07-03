using System;

namespace OHLogic.Common
{
    /// <summary>
    /// Implements general logic for value inclusion checking.
    /// Base class for inheritance and interval type specialization.
    /// </summary>
    /// <typeparam name="TValue">Type of values the interval consists of</typeparam>
    public abstract class Interval<TValue> : IInterval<TValue> where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        /// <summary>
        /// Defines whether bounds should be included in the interval
        /// </summary>
        public IntervalBoundsCheckSetting BoundsCheckSetting { get; set; }

        /// <summary>
        /// Checks if given value belongs to the interval.
        /// Checks against the argument being null and throws ArgumentNullException if it is.
        /// </summary>
        /// <param name="value">Value to check for inclusion.</param>
        /// <returns>True - if value satisfies interval bounds with regard to bounds inclusion/exclusion. False - if value in not within the interval</returns>
        public bool IsValueWithinInterval(TValue value)
        {
            if (value == null) { throw new ArgumentNullException(nameof(value)); }

            var lowerBoundCheck = ValueSatisfiesLowerBound(value);
            var upperBoundCheck = ValueSatisfiesUpperBound(value);
            var isWithinInterval = lowerBoundCheck && upperBoundCheck;

            return isWithinInterval;
        }

        /// <summary>
        /// Checks if given value equals/comes after the lower bound of the interval with regard to lower bound inclusion/exclusion setting
        /// Checks against the argument being null and throws ArgumentNullException if it is.
        /// </summary>
        /// <param name="value">Value to check for inclusion</param>
        /// <returns>True - if value equals/comes after the lower bound. False - otherwise</returns>
        public bool ValueSatisfiesLowerBound(TValue value)
        {
            if (value == null) { throw new ArgumentNullException(nameof(value)); }

            var valueToLowerBound = CompareValueToLowerBound(value);
            var lowerBoundCheck = (valueToLowerBound > 0) || (BoundsCheckSetting.HasFlag(IntervalBoundsCheckSetting.LowerIncluded) && (valueToLowerBound == 0));

            return lowerBoundCheck;
        }

        /// <summary>
        /// Checks if given value comes before/equals the upper bound of the interval with regard to upper bound inclusion/exclusion setting
        /// Checks against the argument being null and throws ArgumentNullException if it is. 
        /// </summary>
        /// <param name="value">Value to check for inclusion</param>
        /// <returns>True - if value comes before/equals the upper bound. False - otherwise</returns>
        public bool ValueSatisfiesUpperBound(TValue value)
        {
            if (value == null) { throw new ArgumentNullException(nameof(value)); }

            var valueToUpperBound = CompareValueToUpperBound(value);
            var upperBoundCheck = (valueToUpperBound < 0) || (BoundsCheckSetting.HasFlag(IntervalBoundsCheckSetting.UpperIncluded) && (valueToUpperBound == 0));

            return upperBoundCheck;
        }

        /// <summary>
        /// Checks if interval upper bound exists.
        /// </summary>
        /// <returns>True - if upper bound exists with reagrd to implementation. False - otherwise</returns>
        protected abstract bool IsUpperBounded();

        /// <summary>
        /// Checks if interval lower bound exists.
        /// </summary>
        /// <returns>True - if lower bound exists with regard to implementation. False - otherwise</returns>
        protected abstract bool IsLowerBounded();

        /// <summary>
        /// Compares checked value to interval's lower bound. Call to CompareTo method of IComparable<> interface is expected to align returned values with those expected by inclusion-checking logic. 
        /// </summary>
        /// <param name="value">Value checked for inclusion in interval</param>
        /// <returns>-1 - if checked value preceeds lower bound, 0 - if checked value is equal to lower bound, 1 - if checked value follows lower bound</returns>
        protected abstract int CompareValueToLowerBound(TValue value);

        /// <summary>
        /// Compares checked value to interval's upperr bound. Call to CompareTo method of IComparable<> interface is expected to align returned values with those expected by inclusion-checking logic. 
        /// </summary>
        /// <param name="value">Value checked for inclusion in interval</param>
        /// <returns>-1 - if checked value preceeds upper bound, 0 - if checked value is equal to upper bound, 1 - if checked value follows upper bound</returns>
        protected abstract int CompareValueToUpperBound(TValue value);
    }
}
