using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OHLogic.Common.Requirement;

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
