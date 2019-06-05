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
    public class PhoneHomePage
    {
        private AppiumDriver<IWebElement> driver;
        private WebDriverWait wait;

        public PhoneHomePage(AppiumDriver<IWebElement> driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "search_box_start_search")]
        public IWebElement SearchTextView { get; set; }

        [FindsBy(How = How.Id, Using = "search_view")]
        public IWebElement SearchTextBox { get; set; }

        [FindsByAll]
        [FindsBy(How = How.XPath, Using = "//ListView[@id='list']/ViewGroup", Priority = 0)]
        //[FindsBy(How = How.Name, Using = "someForm", Priority = 1)]
        public IWebElement AllContacts;

        public IList<IWebElement> NumberDigit()
        {
            var ttt= driver.FindElements(By.Id("list"));
            var tt= driver.FindElements(By.XPath("//*[@class='android.view.ViewGroup']/*[@class='android.widget.TextView' and @index='1']"));
            return tt;
        }

    }
}
