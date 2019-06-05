using NativeApplicationsTest.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NativeApplicationsTest.Utilities;

namespace NativeApplicationsTest.PageActions
{
    public class MessagesHomeAction
    {
        private readonly MessagesHomePage _pageInstance;
        private AppiumDriver<IWebElement> driver;
        Utilities utl = new Utilities();
        public MessagesHomeAction(AppiumDriver<IWebElement> driver)
        {
            this.driver = driver;
            _pageInstance = new MessagesHomePage(driver);
        }

        public void ClickOnSearchButton()
        {
            _pageInstance.SearchButton().Click();
        }

        public void EnterSearchMessage(string value)
        {
            _pageInstance.SearchTextbox().SendKeys(value);
        }

        public void ClickOnSearchMessagesButton()
        {
            _pageInstance.SearchMessagesButton().Click();
        }

        public void ClickOnSpamProtectionOKButton()
        {
            _pageInstance.SpamProtectionOKButton().Click();
        }

        public void SearchMessagesByText(SelectorOptions selector, string value)
        {
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
                    _pageInstance.SelectIndividualMessage(selector, value).Click();
                    break;
                }
                catch (Exception ex)
                {
                    utl.VerticalSwipe(driver, ScrollOptions.down.ToString());
                }
            }
        }

        public List<string> GetMessageText(SelectorOptions selector, string value)
        {
            List<string> messges = new List<string>();
            IList<IWebElement> messages= _pageInstance.GetMessageText(selector, value);
            foreach (var msg in messages)
            {
                messges.Add(msg.Text);
            }
            return messges;
        }
    }
}
