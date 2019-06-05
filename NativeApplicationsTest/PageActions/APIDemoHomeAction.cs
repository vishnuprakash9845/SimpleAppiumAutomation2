using NativeApplicationsTest.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NativeApplicationsTest.Utilities;

namespace NativeApplicationsTest.PageActions
{
    public class APIDemoHomeAction:ActionBase
    {
        private readonly APIDemoHomePage _pageInstance;
        private AppiumDriver<IWebElement> driver;
        Utilities utl = new Utilities();
        public APIDemoHomeAction(AppiumDriver<IWebElement> driver):base(driver)
        {
            this.driver = driver;
            _pageInstance = new APIDemoHomePage(driver);
        }

        public void ClickOnHomePageOptions(string value)
        {
            _pageInstance.HomePageOptions(value).Click();
        }

        public void SelectViewsTabsContentByID(string option1, string option2, string option3)
        {
            bool flag = false;
            _pageInstance.HomePageOptions(option1).Click();
            for (int i = 0; i < 15; i++)
            {
                try
                {
                    _pageInstance.HomePageOptions(option2).Click();
                    break;
                }
                catch (Exception)
                {
                    utl.VerticalSwipe(driver, ScrollOptions.down.ToString());
                }
            }
            flag = driver.FindElementByAccessibilityId(option3).Displayed;
            if (flag)
            {
                Console.WriteLine("TestCase Passed");
            }
            else
            {
                Console.WriteLine("TestCase Failed");
            }
        }


        public void ClickOnPageOneOptions(SelectorOptions selector,string value)
        {
            _pageInstance.PageOneOptions(selector, value).Click();
        }

        public void ClickOnPageTwoOptions(SelectorOptions selector, string value)
        {
            _pageInstance.PageTwoOptions(selector, value).Click();
        }

        public void ClickOnPageThreeOptions(SelectorOptions selector, string value)
        {
            _pageInstance.PageThreeOptions(selector, value).Click();
        }

        public void ClickOnPageFourOptions(SelectorOptions selector, string value)
        {
            //_pageInstance.PageFourOptions(selector, value).Click();

            TapAppiumElement((AppiumWebElement)_pageInstance.PageFourOptions(selector, value));
        }

        public void TapAppiumElement(IWebElement element)
        {
            ((AppiumWebElement)element).Tap(1, 2000);
        }

        public void LongPressAppiumElement(IWebElement element)
        {
            ITouchAction touchAction;
            touchAction = new TouchAction(driver).LongPress(((AppiumWebElement)element), 50, 75);
            touchAction.Perform();
        }
    }
}
