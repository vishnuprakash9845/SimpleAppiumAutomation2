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
    public class MessagesHomePage : PageBase
    {
        private AppiumDriver<IWebElement> driver;

        public MessagesHomePage(AppiumDriver<IWebElement> driver):base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        [FindsBy(How = How.XPath, Using = ".//*[@text='TMHDFCBK']")]
        public IWebElement SearchTextView { get; set; }

        public IWebElement SearchButton()
        {
            return AppiumDriver.FindElementById("action_zero_state_search");
        }

        public IWebElement SearchTextbox()
        {
            return AppiumDriver.FindElementById("zero_state_search_box_auto_complete");
        }

        public IWebElement SearchMessagesButton()
        {
            return AppiumDriver.FindElementById("zero_state_search_contacts_title");
        }

        public IWebElement SpamProtectionOKButton()
        {
            return AppiumDriver.FindElementByXPath(".//*[@text='OK']");
        }

        public IWebElement SelectIndividualMessage(string value)
        {
            return AppiumDriver.FindElementByXPath(value);
        }

        public IWebElement SelectIndividualMessage(SelectorOptions selector, string value)
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

        public IList<IWebElement> GetMessageText(SelectorOptions selector, string value)
        {
            IList<IWebElement> element = null;
            switch (selector)
            {
                case SelectorOptions.AccessibilityId:
                    element = AppiumDriver.FindElementsByAccessibilityId(value);
                    break;
                case SelectorOptions.ClassName:
                    element = AppiumDriver.FindElementsByClassName(value);
                    break;
                case SelectorOptions.Id:
                    element = AppiumDriver.FindElementsById(value);
                    break;
                case SelectorOptions.LinkText:
                    element = AppiumDriver.FindElementsByLinkText(value);
                    break;
                case SelectorOptions.Name:
                    element = AppiumDriver.FindElementsByName(value);
                    break;
                case SelectorOptions.PartialLinkText:
                    element = AppiumDriver.FindElementsByPartialLinkText(value);
                    break;
                case SelectorOptions.TagName:
                    element = AppiumDriver.FindElementsByTagName(value);
                    break;
                case SelectorOptions.XPath:
                    element = AppiumDriver.FindElementsByXPath(value);
                    break;
                default:
                    Console.WriteLine("No Appropriate Selector found");
                    break;
            }
            return element;
        }
    }
}
