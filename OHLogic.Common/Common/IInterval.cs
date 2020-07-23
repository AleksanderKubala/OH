using System;

namespace Assets.Common
{
    /// <summary>
    /// Represents subset of orderable values laying inbetween given bounds ordered from lower bound to upper bound.
    /// </summary>
    /// <typeparam name="TValue">Type of values the interval consists of</typeparam>
    public interface IInterval<TValue> where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        /// <summary>
        /// Defines whether bounds should be included in the interval
        /// </summary>
        IntervalBoundsCheckSetting BoundsCheckSetting { get; set; }

        /// <summary>
        /// Checks if given value belongs to the interval.
        /// </summary>
        /// <param name="value">Value to check for inclusion.</param>
        /// <returns>True - if value satisfies interval bounds with regard to bounds inclusion/exclusion. False - if value in not within the interval</returns>
        bool IsValueWithinInterval(TValue value);

        /// <summary>
        /// Checks if given value equals/comes after the lower bound of the interval with regard to lower bound inclusion/exclusion setting
        /// </summary>
        /// <param name="value">Value to check for inclusion</param>
        /// <returns>True - if value equals/comes after the lower bound. False - otherwise</returns>
        bool ValueSatisfiesLowerBound(TValue value);

        /// <summary>
        /// Checks if given value comes before/equals the upper bound of the interval with regard to upper bound inclusion/exclusion setting
        /// </summary>
        /// <param name="value">Value to check for inclusion</param>
        /// <returns>True - if value comes before/equals the upper bound. False - otherwise</returns>
        bool ValueSatisfiesUpperBound(TValue value);
    }
}
