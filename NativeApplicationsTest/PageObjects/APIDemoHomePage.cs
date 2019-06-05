using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApplicationsTest.PageObjects
{
    public class APIDemoHomePage: PageBase
    {
        private AppiumDriver<IWebElement> driver;
        private WebDriverWait wait;

        public APIDemoHomePage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@text='Views']")]
        public IWebElement PlusButton { get; set; }

        public IWebElement HomePageOptions(string value)
        {
            return AppiumDriver.FindElementByAccessibilityId(value);
        }

        public IWebElement PageOneOptions(SelectorOptions selector, string value)
        {
            IWebElement element = null;
            switch (selector)
            {
                case SelectorOptions.AccessibilityId:
                    element=AppiumDriver.FindElementByAccessibilityId(value);
                    break;
                case SelectorOptions.ClassName:
                    element = AppiumDriver.FindElementByClassName(value);
                    break;
                case SelectorOptions.Id:
                    element = AppiumDriver.FindElementById(value);
                    break;
                case SelectorOptions.LinkText:
                    element = AppiumDriver.FindElementByLinkText(value);
                    break;
                case SelectorOptions.Name:
                    element = AppiumDriver.FindElementByName(value);
                    break;
                case SelectorOptions.PartialLinkText:
                    element = AppiumDriver.FindElementByPartialLinkText(value);
                    break;
                case SelectorOptions.TagName:
                    element = AppiumDriver.FindElementByTagName(value);
                    break;
                case SelectorOptions.XPath:
                    element = AppiumDriver.FindElementByXPath(value);
                    break;
                default:
                    Console.WriteLine("No Appropriate Selector found");
                    break;
            }
            return element;
        }

        public IWebElement PageTwoOptions(SelectorOptions selector,string value)
        {
            IWebElement element = null;
            switch (selector)
            {
                case SelectorOptions.AccessibilityId:
                    element = AppiumDriver.FindElementByAccessibilityId(value);
                    break;
                case SelectorOptions.ClassName:
                    element = AppiumDriver.FindElementByClassName(value);
                    break;
                case SelectorOptions.Id:
                    element = AppiumDriver.FindElementById(value);
                    break;
                case SelectorOptions.LinkText:
                    element = AppiumDriver.FindElementByLinkText(value);
                    break;
                case SelectorOptions.Name:
                    element = AppiumDriver.FindElementByName(value);
                    break;
                case SelectorOptions.PartialLinkText:
                    element = AppiumDriver.FindElementByPartialLinkText(value);
                    break;
                case SelectorOptions.TagName:
                    element = AppiumDriver.FindElementByTagName(value);
                    break;
                case SelectorOptions.XPath:
                    element = AppiumDriver.FindElementByXPath(value);
                    break;
                default:
                    Console.WriteLine("No Appropriate Selector found");
                    break;
            }
            return element;
        }

        public IWebElement PageThreeOptions(SelectorOptions selector,string value)
        {
            IWebElement element = null;
            switch (selector)
            {
                case SelectorOptions.AccessibilityId:
                    element = AppiumDriver.FindElementByAccessibilityId(value);
                    break;
                case SelectorOptions.ClassName:
                    element = AppiumDriver.FindElementByClassName(value);
                    break;
                case SelectorOptions.Id:
                    element = AppiumDriver.FindElementById(value);
                    break;
                case SelectorOptions.LinkText:
                    element = AppiumDriver.FindElementByLinkText(value);
                    break;
                case SelectorOptions.Name:
                    element = AppiumDriver.FindElementByName(value);
                    break;
                case SelectorOptions.PartialLinkText:
                    element = AppiumDriver.FindElementByPartialLinkText(value);
                    break;
                case SelectorOptions.TagName:
                    element = AppiumDriver.FindElementByTagName(value);
                    break;
                case SelectorOptions.XPath:
                    element = AppiumDriver.FindElementByXPath(value);
                    break;
                default:
                    Console.WriteLine("No Appropriate Selector found");
                    break;
            }
            return element;
        }

        public IWebElement PageFourOptions(SelectorOptions selector, string value)
        {
            IWebElement element = null;
            switch (selector)
            {
                case SelectorOptions.AccessibilityId:
                    element = AppiumDriver.FindElementByAccessibilityId(value);
                    break;
                case SelectorOptions.ClassName:
                    element = AppiumDriver.FindElementByClassName(value);
                    break;
                case SelectorOptions.Id:
                    element = AppiumDriver.FindElementById(value);
                    break;
                case SelectorOptions.LinkText:
                    element = AppiumDriver.FindElementByLinkText(value);
                    break;
                case SelectorOptions.Name:
                    element = AppiumDriver.FindElementByName(value);
                    break;
                case SelectorOptions.PartialLinkText:
                    element = AppiumDriver.FindElementByPartialLinkText(value);
                    break;
                case SelectorOptions.TagName:
                    element = AppiumDriver.FindElementByTagName(value);
                    break;
                case SelectorOptions.XPath:
                    element = AppiumDriver.FindElementByXPath(value);
                    break;
                default:
                    Console.WriteLine("No Appropriate Selector found");
                    break;
            }
            return element;
        }
    }
}
