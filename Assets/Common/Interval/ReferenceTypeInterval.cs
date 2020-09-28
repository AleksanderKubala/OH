using System;

namespace Assets.Common
{
    /// <summary>
    /// Handles reference-type-specific logic for intervals
    /// </summary>
    /// <typeparam name="TValue">Type of values the interval consists of</typeparam>
    public class ReferenceTypeInterval<TValue> : Interval<TValue> where TValue : class, IEquatable<TValue>, IComparable<TValue>
    {
        /// <summary>
        /// Value less than or equal to all interval elements.
        /// If null, interval is upper unbounded meaning every value is lower than upper bound
        /// </summary>
        public TValue UpperBound { get; set; }

        /// <summary>
        /// Value greater than or equals to all interval elements
        /// If null, interval is lower unbounded meaning every value is greater than lower bound
        /// </summary>
        public TValue LowerBound { get; set; }

        /// <summary>
        /// Compares checked value to interval's lower bound. Call to CompareTo method of IComparable<> interface is expected to align returned values with those expected by inclusion-checking logic. 
        /// </summary>
        /// <param name="value">Value checked for inclusion in interval</param>
        /// <returns>-1 - if checked value preceeds lower bound, 0 - if checked value is equal to lower bound, 1 - if checked value follows lower bound</returns>
        protected override int CompareValueToLowerBound(TValue value)
        {
            var comparisonResult = IsLowerBounded() ?  value.CompareTo(LowerBound) : 1;

            return comparisonResult; 
        }

        /// <summary>
        /// Compares checked value to interval's upperr bound. Call to CompareTo method of IComparable<> interface is expected to align returned values with those expected by inclusion-checking logic. 
        /// </summary>
        /// <param name="value">Value checked for inclusion in interval</param>
        /// <returns>-1 - if checked value preceeds upper bound, 0 - if checked value is equal to upper bound, 1 - if checked value follows upper bound</returns>
        protected override int CompareValueToUpperBound(TValue value)
        {
            var comparisonResult = IsUpperBounded() ? value.CompareTo(UpperBound) : -1;

            return comparisonResult;
        }

        /// <summary>
        /// Checks if interval lower bound exists.
        /// </summary>
        /// <returns>True - if lower bound is not null. False - otherwise</returns>
        protected override bool IsLowerBounded()
        {
            var isLowerBounded = LowerBound != null;

            return isLowerBounded;
        }

        /// <summary>
        /// Checks if interval upper bound exists.
        /// </summary>
        /// <returns>True - if upper bound is not null. False - otherwise</returns>
        protected override bool IsUpperBounded()
        {
            var isUpperBounded = UpperBound != null;

            return isUpperBounded;
        }
    }
}
