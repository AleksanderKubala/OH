using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHLogic.Common.Requirement
{
    /// <summary>
    /// Used to represents a need/demand that an instance of given type should satisfy in a way specified by implementing classes.
    /// Requirement base class for further inheritance, containing argument-not-null check implementation.
    /// </summary>
    /// <typeparam name="TChecked">Type containing data needed for a requirement satisfaction check</typeparam>
    public abstract class RequirementAbstract<TChecked> : IRequirement<TChecked>
    {
        /// <summary>
        /// Runs a requirement satisfaction check against an argument's state.
        /// Checks against the argument being null and throws ArgumentNullException if it is
        /// </summary>
        /// <param name="checkedObj">Instance of a type which state will be checked</param>
        /// <returns>Value returned from CheckRequirement method call. True - if instance's state/data meets the requirement. False - otherwise</returns>
        public bool CheckFor(TChecked checkedObj)
        {
            if(checkedObj == null) { throw new ArgumentNullException(nameof(checkedObj)); }

            var checkResult = CheckRequirement(checkedObj);

            return checkResult;
        }

        /// <summary>
        /// Contains requirement-specific implementation of instance's state or data satisfaction check.
        /// </summary>
        /// <param name="checkedObj">Instance of a type which state will be checked</param>
        /// <returns>True - if instance's state/data meets the requirement. False - otherwise</returns>
        protected abstract bool CheckRequirement(TChecked checkedObj);
    }
}
