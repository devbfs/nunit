using System;
using UnityCompatNUnit.Framework.Internal;
using UnityCompatNUnit.Framework.Internal.Execution;
using NUnit.TestData;
using NUnit.TestData.TestCaseSourceAttributeFixture;
using NUnit.TestUtilities;

namespace UnityCompatNUnit.Framework.Tests.Attributes
{
    [TestFixture]
    public class TestOrderAttributeTests
    {
        [Test]
        public void CheckOrderIsCorrect()
        {
            var fixture = TestBuilder.MakeFixture(typeof (TestCaseOrderAttributeFixture));
            var work = TestBuilder.PrepareWorkItem(fixture, null) as CompositeWorkItem;

            // This triggers sorting
            TestBuilder.ExecuteWorkItem(work);
            
            Assert.AreEqual(work.Children.Count, 5);
            Assert.AreEqual(work.Children[0].Test.Name, "Y_FirstTest");
            Assert.AreEqual(work.Children[1].Test.Name, "Y_SecondTest");
            Assert.AreEqual(work.Children[2].Test.Name, "Z_ThirdTest");
        }
        
    }
}
