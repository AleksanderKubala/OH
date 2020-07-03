using System;

namespace OHLogic.Common.Requirement
{
    /// <summary>
    /// Uses IInterval<> objects to verify checked value.
    /// Base class for specific value requirements implementations. 
    /// </summary>
    /// <typeparam name="TChecked">Type which contains the data that is relevant for the requirement satisfaction</typeparam>
    /// <typeparam name="TValue">Type of checked data</typeparam>
    public abstract class ValueRequirementAbstract<TChecked, TValue> : RequirementAbstract<TChecked>, IValueRequirement<TChecked, TValue> where TValue : IComparable<TValue>, IEquatable<TValue>
    {
        /// <summary>
        /// Checks interval argument against null and throws ArgumentNullException if it is so. 
        /// </summary>
        /// <param name="requiredValueInterval">Interval object defining a range for (un)accepted values for this requirement</param>
        /// <param name="expectValueInsideInterval">Flag defining whether the interval is supposed to be treated as accepted or unaccepted values. True - range defines accepted values. False - unaccepted values. By default set to True</param>
        public ValueRequirementAbstract(IInterval<TValue> requiredValueInterval, bool expectValueInsideInterval = true)
        {
            RequiredValueInterval = requiredValueInterval ?? throw new ArgumentNullException(nameof(requiredValueInterval));
            ExpectValueInsideInterval = expectValueInsideInterval;
        }

        /// <summary>
        /// Flag defining whether the interval is supposed to be treated as accepted or unaccepted values. True - range defines accepted values. False - unaccepted values.
        /// </summary>
        public bool ExpectValueInsideInterval { get; set; }

        /// <summary>
        /// Interval object defining a range for (un)accepted values for this requirement.
        /// </summary>
        protected IInterval<TValue> RequiredValueInterval { get; set; }

        /// <summary>
        /// Implements a data check run for the requirement.
        /// Checks against null argument and throws ArgumentNullException if it is so.
        /// </summary>
        /// <param name="checkedValue">Value checked for requirement satisfaction</param>
        /// <returns>True - if checkedValue satisfies the requirement. False - otherwise</returns>
        public bool CheckFor(TValue checkedValue)
        {
            if(checkedValue == null) { throw new ArgumentNullException(nameof(checkedValue)); }

            var evaluationResult = !(RequiredValueInterval.IsValueWithinInterval(checkedValue) ^ ExpectValueInsideInterval);

            return evaluationResult;
        }
    }
}
