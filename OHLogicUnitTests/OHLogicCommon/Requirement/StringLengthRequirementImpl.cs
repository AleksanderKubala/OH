using Assets.Common;

namespace OHLogicUnitTests.Requirement
{
    class StringLengthRequirementImpl : ValueRequirementAbstract<string, int>
    {
        public StringLengthRequirementImpl(ValueTypeInterval<int> requirementInterval, bool expectInside) : base(requirementInterval, expectInside) { }

        protected override bool CheckRequirement(string checkedObj)
        {
            var evaluationResults = CheckFor(checkedObj.Length);

            return evaluationResults;
        }
    }
}
