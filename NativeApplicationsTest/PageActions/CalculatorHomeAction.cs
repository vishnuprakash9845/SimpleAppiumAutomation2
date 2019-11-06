using NativeApplicationsTest.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using static NativeApplicationsTest.Utilities;

namespace NativeApplicationsTest.PageActions
{
    public class CalculatorHomeAction
    {
        private readonly CalculatorHomePage _pageInstance;
        private AppiumDriver<IWebElement> driver;

        public CalculatorHomeAction(AppiumDriver<IWebElement> driver)
        {
            this.driver = driver;
            _pageInstance = new CalculatorHomePage(driver);
        }

        public void ClickOnNumber(int digit)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            _pageInstance.NumberDigit(digit.ToString()).Click();
        }      

        public string GetResultValue()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            return _pageInstance.ResultText.Text;
        }

        public void SelectCalculatorOperation(NativeApplicationsTest.Utilities.CalculatorOperations operation)
        {
            switch (operation)
            {
                case NativeApplicationsTest.Utilities.CalculatorOperations.Add:
                    {
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                        _pageInstance.PlusButton.Click();
                        break;
                    }
                case NativeApplicationsTest.Utilities.CalculatorOperations.Subtract:
                    {
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                        _pageInstance.SubButton.Click();
                        break;
                    }
                case NativeApplicationsTest.Utilities.CalculatorOperations.Multiply:
                    {
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                        _pageInstance.MultiplyButton.Click();
                        break;
                    }
                case NativeApplicationsTest.Utilities.CalculatorOperations.Divide:
                    {
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                        _pageInstance.DivideButton.Click();
                        break;
                    }
                case NativeApplicationsTest.Utilities.CalculatorOperations.Equals:
                    {
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                        _pageInstance.EqualsButton.Click();
                        break;
                    }
                case NativeApplicationsTest.Utilities.CalculatorOperations.Delete:
                    {
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                        _pageInstance.DeleteButton.Click();
                        break;
                    }
            }
        }
    }
}
