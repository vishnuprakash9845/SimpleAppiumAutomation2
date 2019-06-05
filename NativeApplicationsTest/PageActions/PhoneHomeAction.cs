using NativeApplicationsTest.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApplicationsTest.PageActions
{
    public class PhoneHomeAction
    {
        private readonly PhoneHomePage _pageInstance;
        private AppiumDriver<IWebElement> driver;
        public PhoneHomeAction(AppiumDriver<IWebElement> driver)
        {
            this.driver = driver;
            _pageInstance = new PhoneHomePage(driver);
        }

        public void ClickOnSearchView()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            _pageInstance.SearchTextView.Click();
        }

        public void EnterNameofPerson(string name)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            _pageInstance.SearchTextBox.SendKeys(name);
        }

        public bool VerifyFilterName(string name)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            var contactList=_pageInstance.AllContacts;
            IList<IWebElement> namesList = _pageInstance.NumberDigit();
            //bool isPresent = namesList.ToList().Where(t => t.Text.Equals("")).SingleOrDefault();

            List<string> nameList=new List<string>();
            if(namesList.Count>0)
            {
                foreach (IWebElement element in namesList)
                {
                    nameList.Add(element.Text);
                }
            }
            

            bool isPresent = nameList.Contains(name);
            return isPresent;
        }
    }
}
