using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Common.Requirement
{
    /// <summary>
    /// Evaluates itself using logical AND operator on contained subrequirements 
    /// </summary>
    /// <typeparam name="TChecked">Type whose instance's state is relevant for the requirement satisfaction</typeparam>
    public class CombinedRequirementConjunction<TChecked> : CombinedRequirement<TChecked>
    {
        /// <summary>
        /// Checks for argument null value and throws ArgumentNullException if it is so.
        /// Checks if enumerable passed as argument is empty and throws ArgumentException if it is.
        /// </summary>
        /// <param name="andRequirements">Enumerable of subrequirements to evaluate.</param>
        public CombinedRequirementConjunction(IEnumerable<IRequirement<TChecked>> andRequirements)
        {
            requirements = andRequirements ?? throw new ArgumentNullException(nameof(andRequirements));
            if(!andRequirements.Any()) {  throw new ArgumentException($"{nameof(andRequirements)} cannot be empty");}
        }

        /// <summary>
        /// Evaluates all subrequirements using logical AND operator
        /// </summary>
        /// <param name="checkedObj">Instance of a type which state will be checked</param>
        /// <returns>True - if all subrequirements are evaluated to true. False - otherwise</returns>
        protected override bool CheckRequirement(TChecked checkedObj)
        {
            var result = true;
            var requirementIterator = requirements.GetEnumerator();

            while (result && requirementIterator.MoveNext())
            {
                result &= requirementIterator.Current.CheckFor(checkedObj);
            }

            return result;
        }

        /// <summary>
        /// Creates CombinedRequirementConjunction instance as a result of requirement combination.
        /// </summary>
        /// <param name="requirement">Enumerable of subrequirements to evaluate by created requirement</param>
        /// <returns>Requirement conjunction containing passed subrequirements that will be evaluated</returns>
        protected override ICombinedRequirement<TChecked> CreateCombinedRequirement(IEnumerable<IRequirement<TChecked>> requirement)
        {
            return new CombinedRequirementConjunction<TChecked>(requirement);
        }
    }
}
