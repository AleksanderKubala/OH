using System;
using System.Collections.Generic;
using System.Linq;

namespace OHLogic.Common.Requirement
{
    /// <summary>
    /// Evaluates itself using logical OR operator on contained subrequirements 
    /// </summary>
    /// <typeparam name="TChecked">Type whose instance's state is relevant for the requirement satisfaction</typeparam>
    public class CombinedRequirementDisjunction<TChecked> : CombinedRequirement<TChecked>
    {
        /// <summary>
        /// Checks for argument null value and throws ArgumentNullException if it is so.
        /// Checks if enumerable passed as argument is empty and throws ArgumentException if it is.
        /// </summary>
        /// <param name="orRequirements">Enumerable of subrequirements to evaluate.</param>
        public CombinedRequirementDisjunction(IEnumerable<IRequirement<TChecked>> orRequirements)
        {
            requirements = orRequirements  ?? throw new ArgumentException(nameof(orRequirements));
            if(!orRequirements.Any()) { throw new ArgumentException($"{nameof(orRequirements)} cannot be empty.");}
        }

        /// <summary>
        /// Evaluates all subrequirements using logical OR operator
        /// </summary>
        /// <param name="checkedObj">Instance of a type which state will be checked</param>
        /// <returns>True - if at least one subrequirement is evaluated to true. False - otherwise</returns>
        protected override bool CheckRequirement(TChecked checkedObj)
        {
            var result = false;
            var requirementIterator = requirements.GetEnumerator();

            while (!result && requirementIterator.MoveNext())
            {
                result |= requirementIterator.Current.CheckFor(checkedObj);
            }

            return result;
        }

        /// <summary>
        /// Creates CombinedRequirementDisjunction instance as a result of requirement combination.
        /// </summary>
        /// <param name="requirement">Enumerable of subrequirements to evaluate by created requirement</param>
        /// <returns>Requirement disjunction containing passed subrequirements that will be evaluated</returns>
        protected override ICombinedRequirement<TChecked> CreateCombinedRequirement(IEnumerable<IRequirement<TChecked>> requirement)
        {
            return new CombinedRequirementDisjunction<TChecked>(requirement);
        }
    }
}
