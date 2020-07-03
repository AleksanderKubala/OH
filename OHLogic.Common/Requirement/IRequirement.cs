using System;

namespace OHLogic.Common.Requirement
{
    /// <summary>
    /// Used to represents a need/demand that an instance of given type should satisfy in a way specified by implementing classes.
    /// </summary>
    /// <typeparam name="TChecked">Type whose instance's state is relevant for the requirement satisfaction</typeparam>
    public interface IRequirement<in TChecked>
    {
        /// <summary>
        /// Runs a requirement satisfaction check against an argument's state.
        /// </summary>
        /// <param name="checkedObj">Instance of a type which state will be checked</param>
        /// <returns>True - if instance's state meets the requirement. False - otherwise</returns>
        bool CheckFor(TChecked checkedObj);
    }
}
