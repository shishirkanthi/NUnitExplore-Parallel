using NUnitExplore.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitExplore.PageObjects
{
    /// <summary>
    /// This class inherits from Driver class which holds a driver property that resolves the instance of WebDriver
    /// from threadmap (a dictionary holding threadID against the webdriver instances)
    /// </summary>
    public class BasePage:Driver
    {
        //public IWebDriver driver;
        public WebDriverWait wait;
        public BasePage()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
    }
}
