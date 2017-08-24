using NUnit.Framework;
using NUnitExplore.PageObjects;
using NUnitExplore.Test;
using System.Threading;

namespace NUnitExplore
{
    [TestFixture]
    
    public class TestClass1:BaseTest
    {
        [Test]
        [Parallelizable(ParallelScope.Fixtures)]
        public void SearchWebSelenium()
        {
            GooglePage gPO = new GooglePage();
            gPO.txtSearchBox.SendKeys("selenium");
            Thread.Sleep(2000);
            gPO.btnSearh.Click();
            gPO.wait.Until(driver => gPO.resultsList.Count > 3);
            int resultCount = gPO.resultsList.Count;
            for (int i = 0; i<resultCount; i++)
            {
                TestContext.WriteLine(gPO.resultsList[i].Text);
                Assert.IsTrue(gPO.resultsList[i].Text.ToLower().Contains("selenium")
                    , "Expected: selenium; Actual: " + gPO.resultsList[i].Text);
            }
        }
    }
}
