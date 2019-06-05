using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using NativeApplicationsTest.PageActions;
using System.Threading;
using static NativeApplicationsTest.Utilities;
using NativeApplicationsTest;

namespace SimpleAppium
{
    [TestClass]
    public class CalculatorSanityTests
    {
        AppiumDriver<IWebElement> driver = null;
        public static DesiredCapabilities cap;
        

        [TestInitialize]
        public void TestSetUp()
        {
            cap = new DesiredCapabilities();
            cap.SetCapability("platformName", "Android");
            cap.SetCapability("platformVersion", "6.0");
            cap.SetCapability("deviceName", "Moto G");
            cap.SetCapability("appPackage", "com.android.calculator2");
            cap.SetCapability("appActivity", "com.android.calculator2.Calculator");
        }

        [TestMethod]
        [TestCategory("Sanity_Calculator")]
        public void LaunchingCalculatorTest()
        {
            Console.WriteLine("Test Execution Started");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            Console.WriteLine("Test Execution Completed");
        }

        [TestMethod]
        [TestCategory("Sanity_Calculator")]
        public void AddFunctionalityTest()
        {
            Console.WriteLine("Test Execution Started");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            CalculatorHomeAction action = new CalculatorHomeAction(driver);

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            action.ClickOnNumber(5);
            action.SelectCalculatorOperation(CalculatorOperations.Add);
            action.ClickOnNumber(5);
            action.SelectCalculatorOperation(CalculatorOperations.Equals);

            string result = action.GetResultValue();
            Assert.AreEqual(10, Convert.ToInt32(result), "Sum is not maching the expected result");

            Console.WriteLine("Result is: " + result);

            Console.WriteLine("Test Execution Completed");
        }

        [TestMethod]
        [TestCategory("Sanity_Calculator")]
        public void SubtractFunctionalityTest()
        {
            Console.WriteLine("Test Execution Started");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            CalculatorHomeAction action = new CalculatorHomeAction(driver);

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            action.ClickOnNumber(5);
            action.SelectCalculatorOperation(CalculatorOperations.Subtract);
            action.ClickOnNumber(5);
            action.SelectCalculatorOperation(CalculatorOperations.Equals);

            string result = action.GetResultValue();
            Assert.AreEqual(0, Convert.ToInt32(result), "Subtraction result value is not maching the expected result");

            Console.WriteLine("Result is: " + result);

            Console.WriteLine("Test Execution Completed");
        }

        [TestMethod]
        [TestCategory("Sanity_Calculator")]
        public void MultiplyFunctionalityTest()
        {
            Console.WriteLine("Test Execution Started");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            CalculatorHomeAction action = new CalculatorHomeAction(driver);

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            action.ClickOnNumber(5);
            action.SelectCalculatorOperation(CalculatorOperations.Multiply);
            action.ClickOnNumber(5);
            action.SelectCalculatorOperation(CalculatorOperations.Equals);

            string result = action.GetResultValue();
            Assert.AreEqual(25, Convert.ToInt32(result), "Multiply result value is not maching the expected result");

            Console.WriteLine("Result is: " + result);

            Console.WriteLine("Test Execution Completed");
        }

        [TestMethod]
        [TestCategory("Sanity_Calculator")]
        public void DivideFunctionalityTest()
        {
            Console.WriteLine("Test Execution Started");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            CalculatorHomeAction action = new CalculatorHomeAction(driver);

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            action.ClickOnNumber(5);
            action.SelectCalculatorOperation(CalculatorOperations.Divide);
            action.ClickOnNumber(5);
            action.SelectCalculatorOperation(CalculatorOperations.Equals);

            string result = action.GetResultValue();
            Assert.AreEqual(1, Convert.ToInt32(result), "Divide result value is not maching the expected result");

            Console.WriteLine("Result is: " + result);

            Console.WriteLine("Test Execution Completed");
        }

        
    }
}
