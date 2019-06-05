using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System.Threading;

namespace SimpleAppium
{
    [TestClass]
    public class WebApplicationTests
    {
        AppiumDriver<IWebElement> driver;

        [TestMethod]
        [TestCategory("WebApp")]
        public void GooglePageTest()
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("platformName", "Android");
            cap.SetCapability("platformVersion", "6.0");
            cap.SetCapability("deviceName", "Moto G");
            cap.SetCapability("browserName", "chrome");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            driver.Navigate().GoToUrl("http://www.google.com");

            driver.FindElementByName("q").SendKeys("Qspiders");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElementByClassName("Tg7LZd").Click();

        }

        [TestMethod]
        [TestCategory("WebApp")]
        public void FlipkartTest()
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("platformName", "Android");
            cap.SetCapability("platformVersion", "6.0");
            cap.SetCapability("deviceName", "Moto G");
            cap.SetCapability("browserName", "chrome");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            driver.Navigate().GoToUrl("http://www.flipkart.com");

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElementByClassName("_1eMB9R").SendKeys("Moto X4");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElementByClassName("dr5Smp").Click();
            
        }
    }
}
