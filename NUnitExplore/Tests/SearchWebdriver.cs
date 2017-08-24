using NUnit.Framework;
using NUnitExplore.PageObjects;
using System;
using System.Linq;
using NUnitExplore.Core;
using NUnitExplore.Test;

namespace NUnitExplore.Tests
{
    public class SearchWebdriver :BaseTest
    {
        [Test]
        [Parallelizable(ParallelScope.Fixtures)]
        public void searchWebdriver()
        {

            var ge = new GooglePage();
            
            ge.txtSearchBox.SendKeys("webdriver");
            ge.lblLogoSubText.Click();
            ge.btnSearh.Click();

            ge.wait.Until(driver => ge.resultsList.Count > 0);

            int count = ge.resultsList.Count();

            for(int i=0;i<count;i++)
            {
                Console.WriteLine(ge.resultsList[i].Text.ToString());
                if(ge.resultsList[i].Text!="")
                Assert.IsTrue(ge.resultsList[i].Text.ToLower().Contains("webdriver"), "the search is "+ ge.resultsList[i].Text);
            }
        }


    }
}
