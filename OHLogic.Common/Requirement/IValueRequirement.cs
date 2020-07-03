using System;

namespace OHLogic.Common.Requirement
{
    /// <summary>
    /// More specific type of a requirement that strictly checks if the selected instance's data is within given range.
    /// </summary>
    /// <typeparam name="TChecked">Type which contains the data that is relevant for the requirement satisfaction</typeparam>
    /// <typeparam name="TValue">Type of checked data</typeparam>
    public interface IValueRequirement<TChecked, TValue> : IRequirement<TChecked> where TValue : IComparable<TValue>, IEquatable<TValue>
    {
        /// <summary>
        /// Runs a data check for passed instance.
        /// The implementation should define a general way in which the passed values are checked and should not be requirement-specific.
        /// Note: This method is generally expected to be called within a context of CheckFor(TChecked) method of IRequirement<> interface.
        /// </summary>
        /// <param name="checkedValue">Value checked for requirement satisfaction</param>
        /// <returns>True - if checkedValue satisfies the requirement. False - otherwise</returns>
        bool CheckFor(TValue checkedValue);
    }
}
