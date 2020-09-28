using System;
using Assets.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;

namespace OHLogicUnitTests.OHLogicCommon.Interval
{
    [TestClass]
    public class IntervalTest
    {
        private ReferenceTypeInterval<string> referenceTypeInterval = new ReferenceTypeInterval<string>();
        private ValueTypeInterval<int> valueTypeInterval = new ValueTypeInterval<int>() { };

        [TestMethod]
        public void TestBoundsChecksReturnTrueForNonNullValueIfIntervalBothUnbounded()
        {
            referenceTypeInterval.LowerBound = null;
            referenceTypeInterval.UpperBound = null;
            valueTypeInterval.LowerBound = null;
            valueTypeInterval.UpperBound = null;


            var valueTypeLowerBoundCheck = valueTypeInterval.ValueSatisfiesLowerBound(int.MinValue);
            var valueTypeUpperBoundCheck = valueTypeInterval.ValueSatisfiesUpperBound(int.MaxValue);
            var referenceTypeLowerBoundCheck = referenceTypeInterval.ValueSatisfiesLowerBound("");
            var referenceTypeUpperBoundCheck = referenceTypeInterval.ValueSatisfiesUpperBound(char.MaxValue.ToString());

            Assert.IsTrue(valueTypeLowerBoundCheck);
            Assert.IsTrue(valueTypeUpperBoundCheck);
            Assert.IsTrue(referenceTypeLowerBoundCheck);
            Assert.IsTrue(referenceTypeUpperBoundCheck);
        }

        [TestMethod]
        [DataRow(IntervalBoundsCheckSetting.BothExcluded, 0, 10, 1, 0)]
        [DataRow(IntervalBoundsCheckSetting.LowerIncluded, 0, 10, 0, -1)]
        [DataRow(IntervalBoundsCheckSetting.UpperIncluded, 0, 10, 10, 11)]
        [DataRow(IntervalBoundsCheckSetting.BothIncluded, 0, 10, 5, 243)]
        public void TestBoundedValueTypeIntervalReturnTrueOnlyForNonNullValueAndSatisfiedBounds(IntervalBoundsCheckSetting bounding, int lowerBound, int upperBound, int satisfyingValue, int unsatisfyingValue)
        {
            valueTypeInterval.BoundsCheckSetting = bounding;
            valueTypeInterval.LowerBound = lowerBound;
            valueTypeInterval.UpperBound = upperBound;

            var satisfyingValueCheck = valueTypeInterval.IsValueWithinInterval(satisfyingValue);
            var unsatisfyingValueCheck = valueTypeInterval.IsValueWithinInterval(unsatisfyingValue);

            Assert.IsTrue(satisfyingValueCheck);
            Assert.IsFalse(unsatisfyingValueCheck);
        }

        [TestMethod]
        [DataRow(IntervalBoundsCheckSetting.BothExcluded, "abc", "byz", "abd", "byz")]
        [DataRow(IntervalBoundsCheckSetting.LowerIncluded, "abc", "byz", "abc", "abb")]
        [DataRow(IntervalBoundsCheckSetting.UpperIncluded, "abc", "byz", "byz", "bzz")]
        [DataRow(IntervalBoundsCheckSetting.BothIncluded, "abc", "byz", "ayz", "abb")]
        public void TestBoundedReferenceTypeIntervalReturnTrueOnlyForNonNullValueAndSatisfiedBounds(IntervalBoundsCheckSetting bounding, string lowerBound, string upperBound, string satisfyingValue, string unsatisfyingValue)
        {
            referenceTypeInterval.BoundsCheckSetting = bounding;
            referenceTypeInterval.LowerBound = lowerBound;
            referenceTypeInterval.UpperBound = upperBound;

            var satisfyingValueCheck = referenceTypeInterval.IsValueWithinInterval(satisfyingValue);
            var unsatisfyingValueCheck = referenceTypeInterval.IsValueWithinInterval(unsatisfyingValue);

            Assert.IsTrue(satisfyingValueCheck);
            Assert.IsFalse(unsatisfyingValueCheck);
        }

        [TestMethod]
        public void TestReferenceTypeIntervalThrowsArgumentNullExceptionForCheckingNullValue()
        {
            Assert.ThrowsException<ArgumentNullException>(() => referenceTypeInterval.IsValueWithinInterval(null));
            Assert.ThrowsException<ArgumentNullException>(() => referenceTypeInterval.ValueSatisfiesLowerBound(null));
            Assert.ThrowsException<ArgumentNullException>(() => referenceTypeInterval.ValueSatisfiesUpperBound(null));
        }
    }
}
