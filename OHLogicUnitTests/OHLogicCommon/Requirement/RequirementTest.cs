using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OHLogic.Common;
using OHLogic.Common.Requirement;
using OHLogicUnitTests.OHLogicCommon.Requirement;

namespace OHLogicUnitTests.Requirement
{
    [TestClass]
    public class RequirementTest
    {
        private IRequirement<object> failedRequirement = new FailedRequirement();
        private IRequirement<object> passedRequirement = new PassedRequirement();
        private object dummy = new object();

        [TestMethod]
        public void TestValueRequirementPassesOnlyForMatchingIntervalCheckResultAndIntervalCheckExpectation()
        {
            var interval = new ValueTypeInterval<int>()
            {
                LowerBound = 1,
                UpperBound = 5,
                BoundsCheckSetting = IntervalBoundsCheckSetting.BothExcluded
            };

            var requirement  = new StringLengthRequirementImpl(interval, expectInside: true);
            Assert.IsFalse(requirement.CheckFor("abracadabra"));
            
            requirement.ExpectValueInsideInterval = false;
            Assert.IsTrue(requirement.CheckFor("abracadabra"));

            requirement.ExpectValueInsideInterval = true;
            Assert.IsFalse(requirement.CheckFor(""));
            Assert.IsTrue(requirement.CheckFor("bump"));

            Assert.ThrowsException<ArgumentNullException>(() => requirement.CheckFor(null));
        }

        [TestMethod]
        public void TestCombinedRequirementConjunctionPassesOnlyWhenAllSubrequirementsPass()
        {
            Assert.ThrowsException<ArgumentException>(() => new CombinedRequirementConjunction<object>(new List<IRequirement<object>>()));

            ICombinedRequirement<object> conjunctionRequirement = new CombinedRequirementConjunction<object>(new List<IRequirement<object>> { passedRequirement });
            Assert.IsTrue(conjunctionRequirement.CheckFor(dummy));

            conjunctionRequirement = conjunctionRequirement.Combine(passedRequirement);
            Assert.IsTrue(conjunctionRequirement.CheckFor(dummy));

            conjunctionRequirement = conjunctionRequirement.Combine(failedRequirement);
            Assert.IsFalse(conjunctionRequirement.CheckFor(dummy));

            conjunctionRequirement = conjunctionRequirement.Combine(passedRequirement);
            Assert.IsFalse(conjunctionRequirement.CheckFor(dummy));
        }

        [TestMethod]
        public void TestCombinedRequirementDisjunctionPassesOnlyWhenAtLeastOneRubrequirementPasses()
        {
            Assert.ThrowsException<ArgumentException>(() => new CombinedRequirementDisjunction<object>(new List<IRequirement<object>>()));

            ICombinedRequirement<object> disjunctionRequirement = new CombinedRequirementDisjunction<object>(new List<IRequirement<object>> { failedRequirement });
            Assert.IsFalse(disjunctionRequirement.CheckFor(dummy));

            disjunctionRequirement = disjunctionRequirement.Combine(failedRequirement);
            Assert.IsFalse(disjunctionRequirement.CheckFor(dummy));

            disjunctionRequirement = disjunctionRequirement.Combine(passedRequirement);
            Assert.IsTrue(disjunctionRequirement.CheckFor(dummy));

            disjunctionRequirement = disjunctionRequirement.Combine(failedRequirement);
            Assert.IsTrue(disjunctionRequirement.CheckFor(dummy));
        }
    }
}
