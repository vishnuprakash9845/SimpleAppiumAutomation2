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
    public class CalculatorHomePage
    {
        private AppiumDriver<IWebElement> driver;
        private WebDriverWait wait;

        public CalculatorHomePage(AppiumDriver<IWebElement> driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "op_add")]
        public IWebElement PlusButton { get; set; }

        [FindsBy(How = How.Id, Using = "op_sub")]
        public IWebElement SubButton { get; set; }

        [FindsBy(How = How.Id, Using = "eq")]
        public IWebElement EqualsButton { get; set; }

        [FindsBy(How = How.Id, Using = "op_mul")]
        public IWebElement MultiplyButton { get; set; }

        [FindsBy(How = How.Id, Using = "op_div")]
        public IWebElement DivideButton { get; set; }

        [FindsBy(How = How.Id, Using = "del")]
        public IWebElement DeleteButton { get; set; }

        [FindsBy(How = How.Id, Using = "formula")]
        public IWebElement ResultText { get; set; }

        public IWebElement NumberDigit(string digit)
        {
            return driver.FindElement(By.Id("digit_" + digit));
        }


    }
}
