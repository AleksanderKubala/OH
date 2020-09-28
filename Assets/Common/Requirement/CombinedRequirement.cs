using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Common
{
    /// <summary>
    /// Implements a argument-not-null check for combining logic and throws ArgumentNullException if it is so.
    /// Base class for inheriting and implementing specific combined requirement types. 
    /// </summary>
    /// <typeparam name="TChecked">Type whose instance's state is relevant for the requirement satisfaction</typeparam>
    public abstract class CombinedRequirement<TChecked> : RequirementAbstract<TChecked>,  ICombinedRequirement<TChecked>
    {
        /// <summary>
        /// Enumerable of subrequirements to evaluate.
        /// </summary>
        protected IEnumerable<IRequirement<TChecked>> requirements;

        /// <summary>
        /// Combines this instance with an argument into single requirement.
        /// Performs argument-not-null check and throws ArgumentNullExcpetion if it is so.
        /// </summary>
        /// <param name="requirement">Requirement to combine the instance with.</param>
        /// <returns>Combined requirement instance whose is based on subrequirements evaluations</returns>
        public ICombinedRequirement<TChecked> Combine(IRequirement<TChecked> requirementToCombine)
        {
            if(requirementToCombine == null) { throw new ArgumentNullException(nameof(requirementToCombine)); }

            var combinedRequirementsList = requirements.ToList();
            combinedRequirementsList.Add(requirementToCombine);

            var combinedRequirement = CreateCombinedRequirement(combinedRequirementsList);

            return combinedRequirement;
        }

        /// <summary>
        /// Defines a ICombinedRequirement subtype created as a result of requirement combination
        /// </summary>
        /// <param name="requirement">Enumerable of subrequirements to evaluate by created requirement</param>
        /// <returns>Combined requirement object containing passed subrequirements that will be evaluated</returns>
        protected abstract ICombinedRequirement<TChecked> CreateCombinedRequirement(IEnumerable<IRequirement<TChecked>> requirement);
    }
}
