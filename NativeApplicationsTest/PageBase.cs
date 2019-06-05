using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApplicationsTest
{
    public abstract class PageBase:Utilities
    {
        public PageBase(AppiumDriver<IWebElement> driver)
        {
            AppiumDriver = driver;
        }
        protected AppiumDriver<IWebElement> AppiumDriver { get; }

      
    }
}
