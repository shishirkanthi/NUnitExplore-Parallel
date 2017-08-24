using OpenQA.Selenium;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NUnitExplore.Core
{
    public enum BrowserType { chrome,firefox,IE }
    
    public class Driver
    {
        private static Dictionary<int, IWebDriver> driverThreadMap = new Dictionary<int, IWebDriver>();
        static string packagesPath = String.Empty;
        
        //Static constructor to initialize the static vaiables of the class
        //Note: static constructor does not have a access modifier (public)
        static Driver()
        {
            packagesPath = TestContext.CurrentContext.TestDirectory
                .Remove(TestContext.CurrentContext.TestDirectory.IndexOf("NUnitExplore\\bin")) + "\\packages";            
        }

        /// <summary>
        /// Property which verifies if webdriver instance exists for current thread ID and returns same if existed
        /// </summary>
        public static IWebDriver driver
        {
            get
            {
                IWebDriver currentThreadDriver = null;
                if (driverThreadMap.TryGetValue(Thread.CurrentThread.ManagedThreadId, out currentThreadDriver))
                    return currentThreadDriver;
                else
                    throw new Exception("Driver not found for test in driver thread map");                
            }
        }

        /// <summary>
        /// Initializes the WebDriver for current test thread and adds it to the driver thread map and returns the driver instance
        /// This way separate instance for driver would be created and maintained for each test thread and hence, isloated driver
        /// will be created for each test during parallel execution.
        /// </summary>
        /// <param name="browserType"></param>
        /// <returns></returns>
        public static IWebDriver StartTest(BrowserType browserType)
        {
            string chromeDriverPath;
            switch (browserType)
            {
                case BrowserType.chrome:
                    chromeDriverPath = Directory.GetDirectories(packagesPath).FirstOrDefault(dir => dir.Contains("Selenium.WebDriver.ChromeDriver") == true) + "\\driver";
                    driverThreadMap.Add(Thread.CurrentThread.ManagedThreadId, new ChromeDriver());
                    break;
                case BrowserType.firefox:
                    driverThreadMap.Add(Thread.CurrentThread.ManagedThreadId, new FirefoxDriver());
                    break;                    
                case BrowserType.IE:
                    //This case to be completed yet
                    throw new NotImplementedException();
                    break;
            }
            return driver;
        }

        public static void EndTest()
        {
            driverThreadMap.Remove(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
