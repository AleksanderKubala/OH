using Assets.Common;

namespace OHLogicUnitTests.OHLogicCommon.Requirement
{
    class PassedRequirement : RequirementAbstract<object>
    {
        protected override bool CheckRequirement(object checkedObj)
        {
            return true;
        }
    }
}
