namespace OHLogic.Common.Requirement
{
    /// <summary>
    /// Used to combine different types of requirements into one requirement and evaluating all subrequirements collectively as implemented.
    /// </summary>
    /// <typeparam name="TChecked">Type whose instance's state is relevant for the requirement satisfaction</typeparam>
    public interface ICombinedRequirement<TChecked> : IRequirement<TChecked>
    {
        /// <summary>
        /// Combines this instance with an argument into single requirement.
        /// </summary>
        /// <param name="requirement">Requirement to combine the instance with.</param>
        /// <returns>Combined requirement instance whose is based on subrequirements evaluations</returns>
        ICombinedRequirement<TChecked> Combine(IRequirement<TChecked> requirement);
    }
}
