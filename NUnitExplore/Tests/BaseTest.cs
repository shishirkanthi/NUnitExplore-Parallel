using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnitExplore.Core;
using OpenQA.Selenium;

namespace NUnitExplore.Test
{
    [TestFixture]
    public class BaseTest:Driver
    {
        [SetUp]
        public void NavigateURL()
        {
            Driver.StartTest(BrowserType.chrome);
            driver.Url = "https://google.co.in";           
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            Driver.EndTest();
        }
    }
}
