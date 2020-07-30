using Assets.Common;

namespace OHLogicUnitTests.OHLogicCommon.Requirement
{
    public class FailedRequirement : RequirementAbstract<object>
    {
        protected override bool CheckRequirement(object checkedObj)
        {
            return false;
        }
    }
}
